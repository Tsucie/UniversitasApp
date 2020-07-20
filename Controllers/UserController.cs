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

        // [HttpGet("GetFakultasList")]
        // public JsonResult FakultasList()
        // {
        //     ReturnMessage ress = new ReturnMessage();
        //     try
        //     {
        //         var fks = FakultasCRUD.ReadAll(Startup.db_kampus_ConnStr);
        //         if(fks.Equals(null)) throw new Exception("", new Exception("Data Not Found!"));

        //         Object[] data = {
        //             new{Nilai = fks.Select(c => c.fks_id).ToArray()},
        //             new{Tampil = fks.Select(c => c.fks_name).ToArray()},
        //             new{Judul = fks.Select(c => c.fks_desc).ToArray()}
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

        // [HttpPost("AddMhs/Create")]
        // public JsonResult CreateMhs([FromBody] UserMahasiswa mhs)
        // {
        //     ReturnMessage ress = new ReturnMessage();
        //     Random rand = new Random();
        //     try
        //     {
        //         if(string.IsNullOrEmpty(mhs.u_username) || string.IsNullOrEmpty(mhs.u_password) || mhs.u_ut_id.Equals(null) || mhs.mhs_fks_id.Equals(null) || string.IsNullOrEmpty(mhs.mhs_fullname) || string.IsNullOrEmpty(mhs.mhs_nim) || string.IsNullOrEmpty(mhs.mhs_kelas) || string.IsNullOrEmpty(mhs.mhs_address) || string.IsNullOrEmpty(mhs.mhs_province) || string.IsNullOrEmpty(mhs.mhs_city) || string.IsNullOrEmpty(mhs.mhs_birthplace) || string.IsNullOrEmpty(mhs.mhs_birthdate) || string.IsNullOrEmpty(mhs.mhs_gender) || string.IsNullOrEmpty(mhs.mhs_religion) || string.IsNullOrEmpty(mhs.mhs_state) || string.IsNullOrEmpty(mhs.mhs_email) || mhs.mhs_stat.Equals(null) || string.IsNullOrEmpty(mhs.mhs_contact)) throw new Exception("", new Exception("Gagal menambahkan data, Data Tidak Komplit!"));

        //         mhs.mhs_id = rand.Next();
        //         mhs.mhs_fullname = mhs.mhs_fullname;
        //         mhs.mhs_nim = mhs.mhs_nim;
        //         mhs.mhs_kelas = mhs.mhs_kelas;
        //         mhs.mhs_address = mhs.mhs_address;
        //         mhs.mhs_province = mhs.mhs_province;
        //         mhs.mhs_city = mhs.mhs_city;
        //         mhs.mhs_birthplace = mhs.mhs_birthplace;
        //         mhs.mhs_birthdate = mhs.mhs_birthdate;
        //         mhs.mhs_gender = mhs.mhs_gender;
        //         mhs.mhs_religion = mhs.mhs_religion;
        //         mhs.mhs_state = mhs.mhs_state;
        //         mhs.mhs_email = mhs.mhs_email;
        //         mhs.mhs_stat = mhs.mhs_stat;
        //         mhs.mhs_contact = mhs.mhs_contact;

        //         Users u = new Users();
        //         u.u_id = rand.Next();
        //         mhs.mhs_u_id = u.u_id;
        //         u.u_ut_id = mhs.u_ut_id;
        //         u.u_username = mhs.u_username;
        //         // Hash Percobaan
        //         // mhs.u_password = Crypto.Hash(mhs.u_password, Convert.ToInt32(mhs.u_password));
        //         u.u_password = mhs.u_password;
        //         u.u_login_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //         u.u_logout_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //         // u_login_stat is default 0 (false)
        //         u.u_login_status = Convert.ToInt16(false);
        //         // u_creator is default to System or get staff_category info;
        //         u.u_rec_creator = "System";
        //         u.u_rec_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        

        //         ress.Code = 1;
        //         ress.Message = "Data Berhasil ditambahkan!";
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