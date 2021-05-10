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
    public class MataKuliahController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("u_id") == null)
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }

        [HttpGet("GetListById/{ps_id}")]
        public async Task<JsonResult> GetDataList([FromRoute] int? ps_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if (ps_id == null) throw new Exception("", new Exception("Fail to render Mata Kuliah Data, no data parameter!"));

                List<MataKuliah> mk = await Task.Run(() => MataKuliahCRUD.ReadAllById(Startup.db_kampus_ConnStr, (int)ps_id));
                if (mk == null) throw new Exception("", new Exception(HttpStatusCode.InternalServerError.ToString()));

                Object[] data = {
                    new {Nomor = mk.Select(s => s.mk_id).ToArray()},
                    new {Psnomor = mk.Select(s => s.mk_ps_id).ToArray()},
                    new {Smnomor = mk.Select(s => s.mk_sm_id).ToArray()},
                    new {Sks = mk.Select(s => s.mk_sks).ToArray()},
                    new {Mutu = mk.Select(s => s.mk_mutu).ToArray()},
                    new {Mkcode = mk.Select(s => s.mk_code).ToArray()},
                    new {Name = mk.Select(s => s.mk_name).ToArray()},
                    new {Desc = mk.Select(s => s.mk_desc).ToArray()},
                    new {Smcode = mk.Select(s => s.sm_code).ToArray()}
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

        [HttpGet("GetMatkulById/{mk_id}")]
        public JsonResult GetData([FromRoute] int? mk_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if (mk_id == null) throw new Exception("", new Exception("Failed Read data, incomplete Data!"));

                MataKuliah data = MataKuliahCRUD.Read(Startup.db_kampus_ConnStr, (int)mk_id);
                if (data == null) throw new Exception("", new Exception(HttpStatusCode.NoContent.ToString()));

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

        [HttpPost("Add")]
        public JsonResult AddData([FromBody] MataKuliah mk)
        {
            ReturnMessage ress = new ReturnMessage();
            Random rand = new Random();
            try
            {
                if (mk.mk_ps_id == null || mk.mk_sm_id == null || mk.mk_sks == null || mk.mk_mutu == null || string.IsNullOrEmpty(mk.mk_code) || string.IsNullOrEmpty(mk.mk_name))
                    throw new Exception("", new Exception("Data is not added, Incomplete Data"));
                
                mk.mk_id = rand.Next();

                if (MataKuliahCRUD.Create(Startup.db_kampus_ConnStr, mk) == 0) throw new Exception("", new Exception("Data is not added in database"));

                ress.Code = 1;
                ress.Message = "Data berhasil ditambahkan!";
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    ress.Code = 0;
                    ress.Message = "Data is not added, duplicate code";
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

        [HttpPut("Edit")]
        public JsonResult EditData([FromBody] MataKuliah mk)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if (mk.mk_id == null || mk.mk_ps_id == null || string.IsNullOrEmpty(mk.mk_code) || string.IsNullOrEmpty(mk.mk_name))
                    throw new Exception("", new Exception("Data is not updated, Incomplete data"));

                if (MataKuliahCRUD.Update(Startup.db_kampus_ConnStr, (int)mk.mk_id, (int)mk.mk_ps_id, mk) != 1)
                    throw new Exception("", new Exception("Data is not edited in database"));
                
                ress.Code = 1;
                ress.Message = "Data berhasil di Ubah";
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    ress.Code = 0;
                    ress.Message = "Data is not edited, duplicate code";
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
        public JsonResult DeleteData([FromBody] MataKuliah mk)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if (mk.mk_id == null || mk.mk_ps_id == null) throw new Exception("", new Exception("Data is not deleted, Incomplete data"));

                if (MataKuliahCRUD.Delete(Startup.db_kampus_ConnStr, (int)mk.mk_id, (int)mk.mk_ps_id) != 1)
                    throw new Exception("", new Exception("Data is note deleted in database"));
                
                ress.Code = 1;
                ress.Message = "Data berhasil dihapus";
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