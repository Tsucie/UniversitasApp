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
                if(u_data.u_r_id != null) HttpContext.Session.SetInt32("u_r_id", (int)u_data.u_r_id);

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