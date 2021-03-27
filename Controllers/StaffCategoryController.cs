using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public class StaffCategoryController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("u_id") == null)
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }

        [HttpGet("GetCategoryList")]
        public async Task<JsonResult> GetDataList()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                List<StaffCategory> list = await Task.Run(() => StaffCategoryCRUD.ReadAllAsync(Startup.db_kampus_ConnStr));
                if(list.Count == 0) throw new Exception("", new Exception(HttpStatusCode.InternalServerError.ToString()));

                Object[] data = {
                    new{Nomor = list.Select(c => c.sc_id).ToArray()},
                    new{Kategori = list.Select(c => c.sc_name).ToArray()},
                    new{Deskripsi = list.Select(c => c.sc_desc).ToArray()}
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

        [HttpGet("GetCategory/{sc_id}")]
        public JsonResult GetData([FromRoute] int? sc_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(sc_id == null) throw new Exception("", new Exception("Data Not Found, Incomplete data"));

                StaffCategory data = StaffCategoryCRUD.Read(Startup.db_kampus_ConnStr, (int)sc_id);
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

        [HttpPost("AddCategory")]
        public JsonResult AddData([FromForm] StaffCategory sc)
        {
            ReturnMessage ress = new ReturnMessage();
            Random rand = new Random();
            try
            {
                if(string.IsNullOrEmpty(sc.sc_name)) throw new Exception("", new Exception("Data not added, Incomplete Data!"));
                sc.sc_id = rand.Next();
                sc.sc_name = sc.sc_name;
                sc.sc_desc = sc.sc_desc;

                if(StaffCategoryCRUD.Create(Startup.db_kampus_ConnStr, sc) != 1) throw new Exception("", new Exception("Data is not added in Database!"));

                ress.Code = 1;
                ress.Message = "Data berhasil di tambahkan!";
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    ress.Code = 0;
                    ress.Message = "Cant Add Data, Duplicate Category name!";
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

        [HttpPut("EditCategory")]
        public JsonResult UpdateData([FromBody] StaffCategory sc)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(sc.sc_id == null || string.IsNullOrEmpty(sc.sc_name)) throw new Exception("", new Exception("Data is not Updated, Incomplete Data!"));

                if(StaffCategoryCRUD.Update(Startup.db_kampus_ConnStr, (int)sc.sc_id, sc) != 1) throw new Exception("", new Exception("Data gagal di update di Database!"));

                ress.Code = 1;
                ress.Message = "Data Berhasil Di Update!";
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    ress.Code = 0;
                    ress.Message = "Cant Edit Data, Duplicate Category name!";
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

        [HttpDelete("DeleteCategory")]
        public JsonResult DeleteData([FromBody] StaffCategory sc)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(sc.sc_id == null) throw new Exception("", new Exception("Data is not Deleted, Incomplete Data!"));

                if(StaffCategoryCRUD.Delete(Startup.db_kampus_ConnStr, (int)sc.sc_id) != 1) throw new Exception("", new Exception("Data is not Deleted in Database!"));

                ress.Code = 1;
                ress.Message = "Data berhasil di Delete!";
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

        [HttpGet("GetStaffList")]
        public async Task<JsonResult> GetAll()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                List<UserStaff> staff = await StaffCRUD.ReadAllAsync(Startup.db_kampus_ConnStr);
                if(staff.Count == 0) throw new Exception("", new Exception(HttpStatusCode.InternalServerError.ToString()));

                Object[] obj = {
                    new {Nomor = staff.Select(s => s.stf_u_id).ToArray()},
                    new {Username = staff.Select(s => s.u_username).ToArray()},
                    new {DataNama = staff.Select(s => s.stf_fullname).ToArray()},
                    new {DataKategori = staff.Select(s => s.sc_name).ToArray()},
                    new {DataNIK = staff.Select(s => s.stf_nik).ToArray()},
                    // new {DataEmail = staff.Select(s => s.stf_email).ToArray()},
                    // new {DataTelp = staff.Select(s => s.stf_contact).ToArray()},
                    new {DataStat = staff.Select(s => s.stf_stat).ToArray()},
                    new {PhotoFilename = staff.Select(s => s.up_filename).ToArray()},
                    new {PhotoData = staff.Select(s => s.up_photo).ToArray()}
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

        [HttpPost("AddStaff/Create")]
        public JsonResult CreateStf([FromBody] UserStaff stf)
        {
            ReturnMessage ress = new ReturnMessage();
            Random rand = new Random();
            try
            {
                if(string.IsNullOrEmpty(stf.u_username) || string.IsNullOrEmpty(stf.u_password) || stf.stf_sc_id == null  || string.IsNullOrEmpty(stf.stf_fullname) || string.IsNullOrEmpty(stf.stf_nik) || string.IsNullOrEmpty(stf.stf_address) || string.IsNullOrEmpty(stf.stf_province) || string.IsNullOrEmpty(stf.stf_city) || string.IsNullOrEmpty(stf.stf_birthplace) || string.IsNullOrEmpty(stf.stf_birthdate) || string.IsNullOrEmpty(stf.stf_gender) || string.IsNullOrEmpty(stf.stf_religion) || string.IsNullOrEmpty(stf.stf_state) || string.IsNullOrEmpty(stf.stf_email) || stf.stf_stat == null || string.IsNullOrEmpty(stf.stf_contact)) throw new Exception("", new Exception("Gagal menambahkan data, Data Tidak Komplit!"));

                stf.stf_id = rand.Next();
                stf.stf_sc_id = stf.stf_sc_id;
                stf.stf_fks_id = stf.stf_fks_id;
                stf.stf_ps_id = stf.stf_ps_id;
                stf.stf_mk_id = stf.stf_mk_id;
                stf.stf_fullname = stf.stf_fullname;
                stf.stf_nik = stf.stf_nik;
                stf.stf_address = stf.stf_address;
                stf.stf_province = stf.stf_province;
                stf.stf_city = stf.stf_city;
                stf.stf_birthplace = stf.stf_birthplace;
                stf.stf_birthdate = Convert.ToDateTime(stf.stf_birthdate).ToString("yyyy-MM-dd");
                stf.stf_gender = stf.stf_gender;
                stf.stf_religion = stf.stf_religion;
                stf.stf_state = stf.stf_state;
                stf.stf_email = stf.stf_email;
                stf.stf_stat = stf.stf_stat;
                stf.stf_contact = stf.stf_contact;

                Users u = new Users();
                u.u_id = rand.Next();
                stf.stf_u_id = u.u_id;
                u.u_ut_id = 3;
                u.u_username = stf.u_username;
                u.u_password = Crypto.Hash(stf.u_password);
                u.u_login_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_logout_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u.u_login_status = Convert.ToInt16(false);
                u.u_rec_status = Convert.ToInt16(true);
                u.u_rec_creator = HttpContext.Session.GetString("u_username");
                u.u_rec_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if(!StaffCRUD.CreateStaffAndUsers(Startup.db_kampus_ConnStr, stf, u)) throw new Exception("", new Exception("Data is not added in Database!"));
                
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

        [HttpGet("UpdateStaff/GetById/{stf_u_id}")]
        public JsonResult GetOneStf([FromRoute] int? stf_u_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(stf_u_id == null) throw new Exception("", new Exception("Cant Read data, incomplete Data!"));

                UserStaff data = StaffCRUD.Read(Startup.db_kampus_ConnStr, (int)stf_u_id);
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

        [HttpPut("UpdateStaff/Update")]
        public JsonResult EditUS([FromBody] UserStaff stf)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(stf.stf_id == null || stf.stf_u_id == null || string.IsNullOrEmpty(stf.u_username)) throw new Exception("", new Exception("Data is not Updated, Incomplete Data!"));

                stf.stf_sc_id = stf.stf_sc_id;
                stf.stf_fks_id = stf.stf_fks_id;
                stf.stf_ps_id = stf.stf_ps_id;
                stf.stf_mk_id = stf.stf_mk_id;
                stf.stf_fullname = stf.stf_fullname;
                stf.stf_nik = stf.stf_nik;
                stf.stf_address = stf.stf_address;
                stf.stf_province = stf.stf_province;
                stf.stf_city = stf.stf_city;
                stf.stf_birthplace = stf.stf_birthplace;
                stf.stf_birthdate = Convert.ToDateTime(stf.stf_birthdate).ToString("yyyy-MM-dd");
                stf.stf_gender = stf.stf_gender;
                stf.stf_religion = stf.stf_religion;
                stf.stf_state = stf.stf_state;
                stf.stf_email = stf.stf_email;
                stf.stf_stat = stf.stf_stat;
                stf.stf_contact = stf.stf_contact;

                Users u = new Users();
                u.u_id = stf.stf_u_id;
                u.u_username = stf.u_username;
                u.u_rec_updator = HttpContext.Session.GetString("u_username");
                u.u_rec_updated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if(stf.u_password != null) u.u_password = Crypto.Hash(stf.u_password);

                if(!StaffCRUD.UpdateStaffandUser(Startup.db_kampus_ConnStr, stf, u)) throw new Exception("", new Exception("Data gagal di update di Database!"));

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

        [HttpDelete("DeleteUserStaff")]
        public JsonResult RemoveUS([FromBody] UserStaff us)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(us.stf_u_id == null) throw new Exception("", new Exception("Data won't be Deleted, Incomplete Data!"));

                if(!StaffCRUD.DeleteStaffandUser(Startup.db_kampus_ConnStr, us, (int)us.stf_u_id)) throw new Exception("", new Exception("Data isn't Deleted in Database!"));

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