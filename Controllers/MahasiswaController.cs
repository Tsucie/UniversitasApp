using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversitasApp.Models;
using UniversitasApp.General;
using UniversitasApp.CRUD;

namespace UniversitasApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MahasiswaController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("u_id") == null)
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }

        [HttpGet("GetMhsList")]
        public async Task<JsonResult> GetAllData()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                List<UserMahasiswa> mhs = await Task.Run(() => MahasiswaCRUD.ReadAllAsync(Startup.db_kampus_ConnStr));
                if(mhs.Equals(null)) throw new Exception("", new Exception("Data Not Found!"));

                Object[] data = {
                    new {Nama = mhs.Select(s => s.mhs_fullname).ToArray()},
                    new {Fakultas = mhs.Select(s => s.fks_name).ToArray()},
                    new {Nim = mhs.Select(s => s.mhs_nim).ToArray()},
                    new {Kelas = mhs.Select(s => s.mhs_kelas).ToArray()},
                    new {Email = mhs.Select(s => s.mhs_email).ToArray()},
                    new {Stat = mhs.Select(s => s.mhs_stat).ToArray()},
                    new {Number = mhs.Select(s => s.mhs_u_id).ToArray()}
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

        [HttpGet("GetMhsById/{mhs_u_id}")]
        public JsonResult GetData([FromRoute] int mhs_u_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(mhs_u_id.Equals(null)) throw new Exception("", new Exception("Data Not Found, Incomplete Data!"));

                var data = MahasiswaCRUD.Read(Startup.db_kampus_ConnStr, mhs_u_id);
                if(data.Equals(null)) throw new Exception("", new Exception("Data Not Found in Database!"));

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

        [HttpPost("AddMhs/Create")]
        public JsonResult CreateMhs([FromBody] UserMahasiswa mhs)
        {
            ReturnMessage ress = new ReturnMessage();
            Random rand = new Random();
            try
            {
                if(string.IsNullOrEmpty(mhs.u_username) || string.IsNullOrEmpty(mhs.u_password) || mhs.mhs_fks_id.Equals(null) || mhs.mhs_ps_id.Equals(null)  || string.IsNullOrEmpty(mhs.mhs_fullname) || string.IsNullOrEmpty(mhs.mhs_nim) || string.IsNullOrEmpty(mhs.mhs_kelas) || string.IsNullOrEmpty(mhs.mhs_address) || string.IsNullOrEmpty(mhs.mhs_province) || string.IsNullOrEmpty(mhs.mhs_city) || string.IsNullOrEmpty(mhs.mhs_birthplace) || string.IsNullOrEmpty(mhs.mhs_birthdate) || string.IsNullOrEmpty(mhs.mhs_gender) || string.IsNullOrEmpty(mhs.mhs_religion) || string.IsNullOrEmpty(mhs.mhs_state) || string.IsNullOrEmpty(mhs.mhs_email) || mhs.mhs_stat.Equals(null) || string.IsNullOrEmpty(mhs.mhs_contact)) throw new Exception("", new Exception("Gagal menambahkan data, Data Tidak Komplit!"));

                mhs.mhs_id = rand.Next();
                mhs.mhs_fks_id = mhs.mhs_fks_id;
                mhs.mhs_ps_id = mhs.mhs_ps_id;
                mhs.mhs_fullname = mhs.mhs_fullname;
                mhs.mhs_nim = mhs.mhs_nim;
                mhs.mhs_kelas = mhs.mhs_kelas;
                mhs.mhs_address = mhs.mhs_address;
                mhs.mhs_province = mhs.mhs_province;
                mhs.mhs_city = mhs.mhs_city;
                mhs.mhs_birthplace = mhs.mhs_birthplace;
                mhs.mhs_birthdate = Convert.ToDateTime(mhs.mhs_birthdate).ToString("yyyy-MM-dd");
                mhs.mhs_gender = mhs.mhs_gender;
                mhs.mhs_religion = mhs.mhs_religion;
                mhs.mhs_state = mhs.mhs_state;
                mhs.mhs_email = mhs.mhs_email;
                mhs.mhs_stat = mhs.mhs_stat;
                mhs.mhs_contact = mhs.mhs_contact;

                Users u = new Users();
                u.u_id = rand.Next();
                mhs.mhs_u_id = u.u_id;
                u.u_ut_id = 4;
                u.u_username = mhs.u_username;
                u.u_password = Crypto.Hash(mhs.u_password);
                u.u_login_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_logout_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_login_status = Convert.ToInt16(false);
                u.u_rec_status = 1;
                u.u_rec_creator = HttpContext.Session.GetString("u_username");
                u.u_rec_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if(!MahasiswaCRUD.CreateMhsAndUser(Startup.db_kampus_ConnStr, mhs, u)) throw new Exception("", new Exception("Failed Add Data in Database!"));

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

        [HttpPut("UpdateMhs/Edit")]
        public JsonResult ChangeData([FromBody] UserMahasiswa mhs)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(mhs.mhs_id.Equals(null) || mhs.mhs_u_id.Equals(null) || string.IsNullOrEmpty(mhs.u_username)) throw new Exception("", new Exception("Data is not Updated, Incomplete Data!"));

                mhs.mhs_fks_id = mhs.mhs_fks_id;
                mhs.mhs_ps_id = mhs.mhs_ps_id;
                mhs.mhs_fullname = mhs.mhs_fullname;
                mhs.mhs_nim = mhs.mhs_nim;
                mhs.mhs_kelas = mhs.mhs_kelas;
                mhs.mhs_address = mhs.mhs_address;
                mhs.mhs_province = mhs.mhs_province;
                mhs.mhs_city = mhs.mhs_city;
                mhs.mhs_birthplace = mhs.mhs_birthplace;
                mhs.mhs_birthdate = Convert.ToDateTime(mhs.mhs_birthdate).ToString("yyyy-MM-dd");
                mhs.mhs_gender = mhs.mhs_gender;
                mhs.mhs_religion = mhs.mhs_religion;
                mhs.mhs_state = mhs.mhs_state;
                mhs.mhs_email = mhs.mhs_email;
                mhs.mhs_stat = mhs.mhs_stat;
                mhs.mhs_contact = mhs.mhs_contact;

                Users u = new Users();
                u.u_id = mhs.mhs_u_id;
                u.u_username = mhs.u_username;
                u.u_rec_updator = HttpContext.Session.GetString("u_username");
                u.u_rec_updated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if(mhs.u_password != null) u.u_password = Crypto.Hash(mhs.u_password);

                if(!MahasiswaCRUD.UpdateMhsAndUser(Startup.db_kampus_ConnStr, mhs, u)) throw new Exception("", new Exception("Data gagal di update di Database!"));

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

        [HttpDelete("DeleteMhs")]
        public JsonResult DeleteData([FromBody] UserMahasiswa mhs)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(mhs.mhs_u_id.Equals(null)) throw new Exception("", new Exception("Gagal hapus data, Data tidak komplit!"));

                Users u = new Users();
                u.u_id = mhs.mhs_u_id;
                if(!MahasiswaCRUD.DeleteMhsAndUser(Startup.db_kampus_ConnStr, mhs, (int)u.u_id)) throw new Exception("", new Exception("Data tidak terhapus di database!"));

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