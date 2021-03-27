using System;
using System.Net;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    public class SiteController : Controller
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
        public JsonResult TakeAllSite()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                List<Site> sites = SiteCRUD.ReadAll(Startup.db_kampus_ConnStr);
                if(sites.Count == 0) throw new Exception("", new Exception(HttpStatusCode.InternalServerError.ToString()));

                Object[] data = {
                    new {Nomor = sites.Select(s => s.s_u_id).ToArray()},
                    new {Username = sites.Select(s => s.u_username).ToArray()},
                    new {Fullname = sites.Select(s => s.s_fullname).ToArray()},
                    new {Nik = sites.Select(s => s.s_nik).ToArray()},
                    new {Role = sites.Select(s => s.r_desc).ToArray()},
                    new {Status = sites.Select(s => s.s_stat).ToArray()},
                    new {PhotoFilename = sites.Select(s => s.up_filename).ToArray()},
                    new {PhotoData = sites.Select(s => s.up_photo).ToArray()}
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

        [HttpGet("GetById/{s_u_id}")]
        public JsonResult TakeOne([FromRoute] int? s_u_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(s_u_id == null) throw new Exception("", new Exception("Incomplete Data!"));

                var data = SiteCRUD.Read(Startup.db_kampus_ConnStr, (int)s_u_id);
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
        public JsonResult MakeData([FromForm] Site s, [FromForm] IFormFile u_file)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(string.IsNullOrEmpty(s.u_username) || string.IsNullOrEmpty(s.u_password) || string.IsNullOrEmpty(s.s_fullname) || string.IsNullOrEmpty(s.s_nik) || string.IsNullOrEmpty(s.s_address) || string.IsNullOrEmpty(s.s_province) || string.IsNullOrEmpty(s.s_city) || string.IsNullOrEmpty(s.s_birthplace) || string.IsNullOrEmpty(s.s_birthdate) || string.IsNullOrEmpty(s.s_gender) || string.IsNullOrEmpty(s.s_religion) || string.IsNullOrEmpty(s.s_state) || string.IsNullOrEmpty(s.s_email) || s.s_stat.Equals(null) || string.IsNullOrEmpty(s.s_contact)) throw new Exception("", new Exception("Cant Add data, Incomplete Data!"));

                if(u_file != null) ImageProcessor.CheckExtention(u_file);

                s.s_birthdate = Convert.ToDateTime(s.s_birthdate).ToString("yyyy-MM-dd");

                Users u = new Users();
                u.u_ut_id = UserEnum.Site_user.GetHashCode();
                u.u_username = s.u_username;
                u.u_password = Crypto.Hash(s.u_password, UserEnum.Site_user.GetHashCode());
                u.u_login_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_logout_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_login_status = Convert.ToInt16(false);
                u.u_rec_status = Convert.ToInt16(true);
                u.u_rec_creator = HttpContext.Session.GetString("u_username");
                u.u_rec_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                UserPhoto up = null;
                if(u_file != null)
                {
                    up = ImageProcessor.ConvertToThumbnail(u_file, "Site", s.u_username);
                    up.up_rec_status = 1;
                }

                Role r = new Role();
                r.r_rt_id = RoleEnum.Site_User.GetHashCode();
                r.r_name = "Site";
                r.r_desc = s.r_desc;
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

                if(!SiteCRUD.CreateSiteAndUser(Startup.db_kampus_ConnStr, s, u, r, rp, up)) throw new Exception("", new Exception("Data is not added in Database"));

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
        public JsonResult ChangeData([FromForm] Site s, [FromForm] IFormFile u_file)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(s.s_id.Equals(null) || s.s_u_id.Equals(null) || string.IsNullOrEmpty(s.u_username)) throw new Exception("", new Exception("Data is not Updated, Incomplete Data!"));

                if(u_file != null) ImageProcessor.CheckExtention(u_file);

                s.s_birthdate = Convert.ToDateTime(s.s_birthdate).ToString("yyyy-MM-dd");

                Users u = new Users();
                u.u_id = s.s_u_id;
                u.u_username = s.u_username;
                u.u_rec_updator = HttpContext.Session.GetString("u_username");
                u.u_rec_updated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_r_id = (s.u_r_id == null) ? null : s.u_r_id;
                u.u_password = (s.u_password == null) ? null : Crypto.Hash(s.u_password, UserEnum.Site_user.GetHashCode());

                UserPhoto up = null;
                if(u_file != null)
                {
                    up = ImageProcessor.ConvertToThumbnail(u_file, "Site", s.u_username);
                    up.up_id = UserCRUD.ReadPhoto(Startup.db_kampus_ConnStr, (int)u.u_id);
                }

                if(!SiteCRUD.UpdateSiteAndUser(Startup.db_kampus_ConnStr, s, u, up)) throw new Exception("", new Exception("Data gagal di update di Database!"));

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
        public JsonResult EraseData([FromBody] Site s)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(s.s_u_id.Equals(null)) throw new Exception("", new Exception("Data won't be Deleted, Incomplete Data!"));

                Users u = UserCRUD.ReadRole(Startup.db_kampus_ConnStr, (int)s.s_u_id);
                if (u == null) throw new Exception("", new Exception("Incorrect Data"));

                if(!SiteCRUD.DeleteSiteAndUser(Startup.db_kampus_ConnStr, s, u)) throw new Exception("", new Exception("Data isn't Deleted in Database!"));

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