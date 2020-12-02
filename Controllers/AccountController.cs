using System;
using System.Text.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using UniversitasApp.Models;
using UniversitasApp.CRUD;
using UniversitasApp.General;

namespace UniversitasApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration setting;
        private readonly IDistributedCache sessionCache; // Save as Hashes in RedisServer

        public AccountController(IConfiguration config, IDistributedCache redisCache)
        {
            setting = config;
            this.sessionCache = redisCache;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<ActionResult> Validate([FromForm] string username, string password)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                // Get user data from db
                var u_data = await Task.Run(() => UserCRUD.ReadAsync(Startup.db_kampus_ConnStr, username));

                // Validation Start >>
                if (u_data.u_password != password && Crypto.Verify(password, u_data.u_password) != true)
                    throw new Exception("", new Exception("Login Gagal, Password Salah!"));
                // Validation End <<

                // Saving user session
                HttpContext.Session.SetInt32("u_id", (int)u_data.u_id);
                HttpContext.Session.SetString("u_username", u_data.u_username);
                HttpContext.Session.SetString("ut_name", u_data.ut_name);
                // if(u_data.u_r_id != null) HttpContext.Session.SetInt32("u_r_id", (int)u_data.u_r_id);

                // Saving to redis
                string uid = u_data.u_id.ToString();
                Object userData = new
                {
                    u_id = u_data.u_id,
                    u_username = u_data.u_username,
                    ut_name = u_data.ut_name,
                    u_r_id = (u_data.u_r_id == null) ? null : u_data.u_r_id
                };
                string user = JsonSerializer.Serialize(userData);
                Console.WriteLine("\n user: {0}", user);
                sessionCache.SetString(uid, user); // Save as Hashes in RedisServer with key: RedisKey+uid (See appsetting.json section: "redis:name") + "uid"

                // Check value in redis
                string sessionData = sessionCache.GetString(uid); // Get with command HGET key field
                if (!string.IsNullOrEmpty(sessionData))
                {
                    Console.WriteLine("\n Successfully store session to redis!\n");
                    Console.WriteLine("{0} : {1} \n", uid, sessionData);
                }

                // Update login status
                if(await Task.Run(() => UserCRUD.LoginUpdate(Startup.db_kampus_ConnStr, (int)u_data.u_id)) != 1)
                    throw new Exception("", new Exception("An Error Accoured, Login Failed!"));
                
                ress.Code = 1;
                ress.Message = "Login Berhasil!";
            }
            catch (Exception ex)
            {
                ress.Error(ex);
            }
            return Json(new {
                Code = ress.Code,
                Message = ress.Message
            });
        }

        public ActionResult Logout()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                int u_id = (int)HttpContext.Session.GetInt32("u_id");
                if(UserCRUD.LogoutUpdate(Startup.db_kampus_ConnStr, u_id) != 1) throw new Exception("", new Exception("An Error Accoured, Cant Logout!"));

                HttpContext.Session.Clear();
                string uid = u_id.ToString();
                sessionCache.Remove(uid);
                if (string.IsNullOrEmpty(sessionCache.GetString(uid))) Console.WriteLine("\n Successfully delete session cache from redis!");

                return RedirectToAction("Login","Account");
            }
            catch (Exception ex)
            {
                ress.Error(ex);
            }
            return Json(new {
                Code = ress.Code,
                Pesan = ress.Message
            });
        }
    }
}