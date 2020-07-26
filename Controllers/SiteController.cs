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
    public class SiteController : Controller
    {
        public IActionResult Index() => View();

        [HttpGet("GetSiteList")]
        public JsonResult TakeAllSite()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                var sites = SiteCRUD.ReadAll(Startup.db_kampus_ConnStr);
                if(sites.Equals(null)) throw new Exception("", new Exception("Data Not Found!"));

                Object[] data = {
                    new {Nomor = sites.Select(s => s.s_u_id).ToArray()},
                    new {Username = sites.Select(s => s.u_username).ToArray()},
                    new {Fullname = sites.Select(s => s.s_fullname).ToArray()},
                    new {Nik = sites.Select(s => s.s_nik).ToArray()},
                    new {Status = sites.Select(s => s.s_stat).ToArray()}
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
        public JsonResult TakeOne([FromRoute] int s_u_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(s_u_id.Equals(null)) throw new Exception("", new Exception("Data not Found, Incomplete Data!"));

                var data = SiteCRUD.Read(Startup.db_kampus_ConnStr, s_u_id);
                if(data.Equals(null)) throw new Exception("", new Exception("Data not found in Database!"));

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

        [HttpPost("AddSite")]
        public JsonResult MakeData([FromForm] Site s)
        {
            ReturnMessage ress = new ReturnMessage();
            Random rand = new Random();
            try
            {
                if(string.IsNullOrEmpty(s.u_username) || string.IsNullOrEmpty(s.u_password) || s.u_ut_id.Equals(null) || string.IsNullOrEmpty(s.s_fullname) || string.IsNullOrEmpty(s.s_nik) || string.IsNullOrEmpty(s.s_address) || string.IsNullOrEmpty(s.s_province) || string.IsNullOrEmpty(s.s_city) || string.IsNullOrEmpty(s.s_birthplace) || string.IsNullOrEmpty(s.s_birthdate) || string.IsNullOrEmpty(s.s_gender) || string.IsNullOrEmpty(s.s_religion) || string.IsNullOrEmpty(s.s_state) || string.IsNullOrEmpty(s.s_email) || s.s_stat.Equals(null) || string.IsNullOrEmpty(s.s_contact)) throw new Exception("", new Exception("Gagal menambahkan data, Data Tidak Komplit!"));

                s.s_id = rand.Next();
                s.s_fullname = s.s_fullname;
                s.s_nik = s.s_nik;
                s.s_address = s.s_address;
                s.s_province = s.s_province;
                s.s_city = s.s_city;
                s.s_birthplace = s.s_birthplace;
                s.s_birthdate = s.s_birthdate;
                s.s_gender = s.s_gender;
                s.s_religion = s.s_religion;
                s.s_state = s.s_state;
                s.s_email = s.s_email;
                s.s_stat = s.s_stat;
                s.s_contact = s.s_contact;

                Users u = new Users();
                u.u_id = rand.Next();
                s.s_u_id = u.u_id;
                u.u_ut_id = s.u_ut_id;
                u.u_username = s.u_username;
                u.u_password = Crypto.Hash(s.u_password);
                u.u_login_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_logout_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_login_status = Convert.ToInt16(false);
                u.u_rec_status = Convert.ToInt16(true);
                // u_rec_creator is default to System or get User Principal info;
                u.u_rec_creator = HttpContext.Session.GetString("u_username");
                u.u_rec_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if(!SiteCRUD.CreateSiteAndUser(Startup.db_kampus_ConnStr, s, u)) throw new Exception("", new Exception("Data is not added in Database"));

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

        [HttpPut("EditSite")]
        public JsonResult ChangeData([FromBody] Site s)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(s.s_id.Equals(null) || s.s_u_id.Equals(null) || string.IsNullOrEmpty(s.u_username)) throw new Exception("", new Exception("Data is not Updated, Incomplete Data!"));

                s.s_fullname = s.s_fullname;
                s.s_nik = s.s_nik;
                s.s_address = s.s_address;
                s.s_province = s.s_province;
                s.s_city = s.s_city;
                s.s_birthplace = s.s_birthplace;
                s.s_birthdate = s.s_birthdate;
                s.s_gender = s.s_gender;
                s.s_religion = s.s_religion;
                s.s_state = s.s_state;
                s.s_email = s.s_email;
                s.s_stat = s.s_stat;
                s.s_contact = s.s_contact;

                Users u = new Users();
                u.u_id = s.s_u_id;
                u.u_username = s.u_username;
                u.u_rec_updator = HttpContext.Session.GetString("u_username");
                u.u_rec_updated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if(!s.u_r_id.Equals(null)) u.u_r_id = s.u_r_id;
                if(!s.u_password.Equals(null)) u.u_password = Crypto.Hash(s.u_password);

                if(!SiteCRUD.UpdateSiteAndUser(Startup.db_kampus_ConnStr, s, u)) throw new Exception("", new Exception("Data gagal di update di Database!"));

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

        [HttpDelete("DeleteSite")]
        public JsonResult EraseData([FromBody] Site s)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(s.s_u_id.Equals(null)) throw new Exception("", new Exception("Data won't be Deleted, Incomplete Data!"));

                Users u = new Users();
                u.u_id = s.s_u_id;
                if(!SiteCRUD.DeleteSiteAndUser(Startup.db_kampus_ConnStr, s, (int)u.u_id)) throw new Exception("", new Exception("Data isn't Deleted in Database!"));

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