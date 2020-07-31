using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UniversitasApp.Models;
using UniversitasApp.General;
using UniversitasApp.CRUD;

namespace UniversitasApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        public IActionResult Index() => View();
        
        [HttpGet("GetAll")]
        public JsonResult GetAllData()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                var roles = RoleCRUD.ReadAll(Startup.db_kampus_ConnStr);
                if(roles.Equals(null)) throw new Exception("", new Exception("Data Not Found!"));

                Object[] data = {
                    new {RoleId = roles.Select(s => s.r_id).ToArray()},
                    new {RoleTypeName = roles.Select(s => s.rt_name).ToArray()},
                    new {RoleName = roles.Select(s => s.r_name).ToArray()}
                };
                if(!roles.Select(s => s.r_c_id).Equals(null)) data.Append(new {c_id = roles.Select(s => s.r_c_id).ToArray()});
                if(!roles.Select(s => s.r_s_id).Equals(null)) data.Append(new {s_id = roles.Select(s => s.r_s_id).ToArray()});

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

        [HttpGet("GetPreviledge/{r_id}")]
        public JsonResult GetPrevData([FromRoute] int r_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(r_id.Equals(null)) throw new Exception("", new Exception("Data Not Found, Incomplete Data!"));

                var data = RolePreviledgeCRUD.Read(Startup.db_kampus_ConnStr, r_id);
                if(data.Equals(null)) throw new Exception("", new Exception("Data Not Found!"));

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

        [HttpPut("UpdatePreviledge")]
        public JsonResult ChangePrevData([FromBody] RolePreviledge rp)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(rp.rp_id.Equals(null) || rp.rp_r_id.Equals(null) || rp.rp_view.Equals(null) || rp.rp_add.Equals(null) || rp.rp_edit.Equals(null) || rp.rp_delete.Equals(null)) throw new Exception("", new Exception("Can't Update data, Incomplete Data!"));

                rp.rp_id = rp.rp_id;
                rp.rp_r_id = rp.rp_r_id;
                rp.rp_view = rp.rp_view;
                rp.rp_add = rp.rp_add;
                rp.rp_edit = rp.rp_edit;
                rp.rp_delete = rp.rp_delete;
                rp.rp_rec_updator = HttpContext.Session.GetString("u_username");
                rp.rp_rec_updated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if(RolePreviledgeCRUD.Update(Startup.db_kampus_ConnStr, rp) != 1) throw new Exception("", new Exception("Failed update data in Database!"));

                ress.Code = 1;
                ress.Message = "Data Berhasil di Update!";
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