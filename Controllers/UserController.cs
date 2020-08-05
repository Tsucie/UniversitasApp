using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniversitasApp.Models;
using UniversitasApp.General;
using UniversitasApp.CRUD;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitasApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Index() => View();

        [HttpGet("GetList")]
        public JsonResult ReadAllList()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                var users = UserCRUD.ReadAllActivity(Startup.db_kampus_ConnStr);
                if(users.Equals(null)) throw new Exception("", new Exception("Data tidak ditemukan!"));

                Object[] data = {
                    new {DataName = users.Select(u => u.u_username).ToArray()},
                    new {DataKategori = users.Select(ut => ut.ut_name).ToArray()},
                    new {DataLogin = users.Select(u => u.u_login_time).ToArray()},
                    new {DataLogout = users.Select(u => u.u_logout_time).ToArray()},
                    new {DataStatus = users.Select(u => u.u_login_status).ToArray()},
                    new {DataId = users.Select(u => u.u_id).ToArray()}
                };
                return Json(data);
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

        // [HttpGet("GetCategoryList")]
        // public JsonResult CategoryList()
        // {
        //     ReturnMessage ress = new ReturnMessage();
        //     try
        //     {
        //         var category = UserCRUD.ReadList(Startup.db_kampus_ConnStr);
        //         if(category.Equals(null)) throw new Exception("", new Exception("Data Not Found!"));

        //         Object[] data = {
        //             new{Nilai = category.Select(c => c.ut_id).ToArray()},
        //             new{Tampil = category.Select(c => c.ut_name).ToArray()},
        //             new{Judul = category.Select(c => c.ut_desc).ToArray()}
        //         };
        //         return Json(data);
        //     }
        //     catch (Exception ex)
        //     {
        //         ress.Error(ex);
        //     }
        //     return Json(new {
        //         Code = ress.Code,
        //         Pesan = ress.Message
        //     });
        // }
    }
}