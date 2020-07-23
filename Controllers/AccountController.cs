using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UniversitasApp.Models;
using UniversitasApp.CRUD;
using UniversitasApp.General;

namespace UniversitasApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<ActionResult> Validate([FromForm] string username, string password)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                var u_data = await Task.Run(() => UserCRUD.Read(Startup.db_kampus_ConnStr, username));
                if(u_data.Equals(null)) throw new Exception("", new Exception("Login Gagal, Data tidak ditemukan"));
            
                if(u_data.u_username.Equals("@"+username))
                {
                    if(u_data.u_password.Equals(password) || Crypto.Verify(password, u_data.u_password))
                    {
                        HttpContext.Session.SetString("u_username", u_data.u_username);
                        HttpContext.Session.SetInt32("u_id", (int)u_data.u_id);
                        HttpContext.Session.SetString("ut_name", u_data.ut_name);
                        // if(!u_data.u_r_id.Equals(null)) HttpContext.Session.SetInt32("u_r_id", (int)u_data.u_r_id);

                        if(await Task.Run(() => UserCRUD.LoginUpdate(Startup.db_kampus_ConnStr, (int)u_data.u_id)) != 1) throw new Exception("", new Exception("An Error Accoured, Login Failed!"));
                        
                        return Json(new { status = true, message = "Login Successfull!"});
                    }
                    return Json(new { status = true, message = "Password Salah!" });
                }
                return Json(new { status = false, message = "Username Salah!" });
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

        public ActionResult Logout()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(UserCRUD.LogoutUpdate(Startup.db_kampus_ConnStr, (int)HttpContext.Session.GetInt32("u_id")) != 1) throw new Exception("", new Exception("An Error Accoured, Cant Logout!"));

                HttpContext.Session.Clear();

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