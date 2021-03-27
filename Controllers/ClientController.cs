using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using MySql.Data.MySqlClient;
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
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("u_id") == null)
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }

        [HttpGet("GetAll")]
        public JsonResult GetAllDataClient()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                List<Client> clients = ClientCRUD.ReadAll(Startup.db_kampus_ConnStr);
                if(clients.Count == 0) throw new Exception("", new Exception(HttpStatusCode.InternalServerError.ToString()));

                Object[] obj = {
                    new {DataId = clients.Select(s => s.c_u_id).ToArray()},
                    new {DataCode = clients.Select(s => s.c_code).ToArray()},
                    new {DataUsername = clients.Select(s => s.u_username).ToArray()},
                    new {DataName = clients.Select(s => s.c_name).ToArray()},
                    new {DataRemark = clients.Select(s => s.c_remark).ToArray()},
                    new {PhotoFilename = clients.Select(s => s.up_filename).ToArray()},
                    new {PhotoData = clients.Select(s => s.up_photo).ToArray()}
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
        public JsonResult GetDataById([FromRoute] int? c_u_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(c_u_id == null) throw new Exception("", new Exception("incomplete data!"));

                Client data = ClientCRUD.Read(Startup.db_kampus_ConnStr, (int)c_u_id);
                if(data == null) throw new Exception("", new Exception(HttpStatusCode.NoContent.ToString()));

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
        public JsonResult AddData([FromForm] Client c, [FromForm] IFormFile u_file)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(string.IsNullOrEmpty(c.c_name)) throw new Exception("", new Exception("Cant Add data, Incomplete Data!"));

                if(u_file != null) ImageProcessor.CheckExtention(u_file);

                c.c_code = "C"+DateTime.Now.Ticks.GetHashCode().ToString();
                c.c_name = c.c_name;
                c.c_remark = c.c_remark;

                Users u = new Users();
                u.u_ut_id = UserEnum.Client_user.GetHashCode();
                u.u_username = c.u_username;
                u.u_password = Crypto.Hash(c.u_password, UserEnum.Client_user.GetHashCode());
                u.u_login_time = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_logout_time = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_login_status = Convert.ToInt16(false);
                u.u_rec_status = Convert.ToInt16(true);
                u.u_rec_creator = HttpContext.Session.GetString("u_username");
                u.u_rec_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                UserPhoto up = null;
                if(u_file != null)
                {
                    up = ImageProcessor.ConvertToThumbnail(u_file, "Client", c.u_username);
                    up.up_rec_status = 1;
                }

                Role r = new Role();
                r.r_rt_id = RoleEnum.Client_User.GetHashCode();
                r.r_name = "Client";
                r.r_desc = c.c_remark;
                r.r_rec_status = 1;
                r.r_rec_creator = HttpContext.Session.GetString("u_username");
                r.r_rec_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                RolePreviledge rp = new RolePreviledge();
                rp.rp_view = 1;
                rp.rp_add = 1;
                rp.rp_edit = 1;
                rp.rp_delete = 1;
                rp.rp_rec_status = 1;
                rp.rp_rec_creator = HttpContext.Session.GetString("u_username");
                rp.rp_rec_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if(!ClientCRUD.CreateClientAndUser(Startup.db_kampus_ConnStr, c, u, r, rp, up)) throw new Exception("", new Exception("Data is not Added in Database!"));

                ress.Code = 1;
                ress.Message = "Data Berhasil ditambahkan!";
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    ress.Code = 0;
                    ress.Message = "Cant Add Data, Duplicate Username!";
                }
                else
                {
                    ress.Code = -1;
                    ress.Message = ex.Message;
                }
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
        public JsonResult UpdateData([FromForm] Client c, [FromForm] IFormFile u_file)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                Console.WriteLine("c_id : {0} \n c_u_id : {1}", c.c_id, c.c_u_id);
                if(c.c_id.Equals(null) || c.c_u_id.Equals(null)) throw new Exception("", new Exception("Can not Update, Incomplete Data!"));
                Console.WriteLine("Validation Pass");

                if(u_file != null) ImageProcessor.CheckExtention(u_file);
                Console.WriteLine("Validation Photo Pass");

                Users u = new Users();
                u.u_id = c.c_u_id;
                u.u_username = c.u_username;
                u.u_rec_updator = HttpContext.Session.GetString("u_username");
                u.u_rec_updated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_r_id = (c.u_r_id == null) ? null : c.u_r_id;
                u.u_password = (c.u_password == null) ? null : Crypto.Hash(c.u_password, UserEnum.Client_user.GetHashCode());

                UserPhoto up = null;
                if(u_file != null)
                {
                    Console.WriteLine("Processing Photo ...");
                    up = ImageProcessor.ConvertToThumbnail(u_file, "Client", c.u_username);
                    Console.WriteLine("Converting sucessed");
                    up.up_id = UserCRUD.ReadPhoto(Startup.db_kampus_ConnStr, (int)u.u_id);
                    Console.WriteLine("up_id: {0}, up_photo: {1}", up.up_id, up.up_photo.Length);
                    Console.WriteLine("Photo Processed");
                }

                if(!ClientCRUD.UpdateClientAndUser(Startup.db_kampus_ConnStr, c, u, up)) throw new Exception("", new Exception("Data gagal di update di Database!"));

                ress.Code = 1;
                ress.Message = "Data Berhasil Di Update!";
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    ress.Code = 0;
                    ress.Message = "Cant Edit Data, Duplicate Username!";
                }
                else
                {
                    ress.Code = -1;
                    ress.Message = ex.Message;
                }
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

                Users u = UserCRUD.ReadRole(Startup.db_kampus_ConnStr, (int)c.c_u_id);
                if (u == null) throw new Exception("", new Exception("Incorrect Data"));

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