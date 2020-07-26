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
    public class ClientController : Controller
    {
        public IActionResult Index() => View();

        [HttpGet("GetAll")]
        public JsonResult GetAllDataClient()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                var clients = ClientCRUD.ReadAll(Startup.db_kampus_ConnStr);
                if(clients.Equals(null)) throw new Exception("", new Exception("Data Not Found!"));

                Object[] obj = {
                    new {DataId = clients.Select(s => s.c_u_id).ToArray()},
                    new {DataCode = clients.Select(s => s.c_code).ToArray()},
                    new {DataUsername = clients.Select(s => s.u_username).ToArray()},
                    new {DataName = clients.Select(s => s.c_name).ToArray()},
                    new {DataRemark = clients.Select(s => s.c_remark).ToArray()}
                };
                return Json(obj);
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

        [HttpGet("GetById/{c_u_id}")]
        public JsonResult GetDataById([FromRoute] int c_u_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(c_u_id.Equals(null)) throw new Exception("", new Exception("Data not found, incomplete data!"));

                var data = ClientCRUD.Read(Startup.db_kampus_ConnStr, c_u_id);
                if(data.Equals(null)) throw new Exception("", new Exception("Data not found in Databas!"));

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

        [HttpPost("Create")]
        public JsonResult AddData([FromForm] Client c)
        {
            ReturnMessage ress = new ReturnMessage();
            Random rand = null;
            try
            {
                if(string.IsNullOrEmpty(c.c_name)) throw new Exception("", new Exception("Cant Add data, Incomplete Data!"));
                rand = new Random();
                c.c_id = rand.Next();
                c.c_code = "C"+DateTime.Now.Ticks.GetHashCode().ToString();
                c.c_name = c.c_name;
                c.c_remark = c.c_remark;

                Users u = new Users();
                u.u_id = rand.Next();
                c.c_u_id = u.u_id;
                u.u_ut_id = 1;
                u.u_username = c.u_username;
                u.u_password = Crypto.Hash(c.u_password);
                u.u_login_time = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_logout_time = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_login_status = Convert.ToInt16(false);
                u.u_rec_status = Convert.ToInt16(true);
                u.u_rec_creator = HttpContext.Session.GetString("u_username");
                u.u_rec_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if(!ClientCRUD.CreateClientAndUser(Startup.db_kampus_ConnStr, c, u)) throw new Exception("", new Exception("Data is not Added in Database!"));

                ress.Code = 1;
                ress.Message = "Data Berhasil ditambahkan!";
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

        [HttpPut("Update")]
        public JsonResult UpdateData([FromBody] Client c)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(c.c_id.Equals(null) || c.c_u_id.Equals(null) || string.IsNullOrEmpty(c.u_username) || string.IsNullOrEmpty(c.c_name)) throw new Exception("", new Exception("Can not Update, Incomplete Data!"));

                Users u = new Users();
                u.u_id = c.c_u_id;
                u.u_username = c.u_username;
                u.u_rec_updator = HttpContext.Session.GetString("u_username");
                u.u_rec_updated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if(!c.u_r_id.Equals(null)) u.u_r_id = c.u_r_id;
                if(!c.u_password.Equals(null)) u.u_password = Crypto.Hash(c.u_password);

                if(!ClientCRUD.UpdateClientAndUser(Startup.db_kampus_ConnStr, c, u)) throw new Exception("", new Exception("Data gagal di update di Database!"));

                ress.Code = 1;
                ress.Message = "Data Berhasil Di Update!";
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

        [HttpDelete("Delete")]
        public JsonResult RemoveCU([FromBody] Client c)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(c.c_u_id.Equals(null)) throw new Exception("", new Exception("Cant Delete, Incomplete Data!"));

                Users u =  new Users();
                u.u_id = c.c_u_id;
                if(!ClientCRUD.DeleteClientAndUser(Startup.db_kampus_ConnStr, c, u)) throw new Exception("", new Exception("Failed Delete data in Database!"));

                ress.Code = 1;
                ress.Message = "Data Berhasil dihapus!";
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