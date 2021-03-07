using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversitasApp.Models;
using UniversitasApp.General;
using UniversitasApp.CRUD;

namespace UniversitasApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FakultasController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("u_id") == null)
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }

        [HttpGet("GetList")]
        public async Task<JsonResult> FakultasList()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                List<Fakultas> fks = await Task.Run(() => FakultasCRUD.ReadAllAsync(Startup.db_kampus_ConnStr));
                if(fks == null) throw new Exception("", new Exception(HttpStatusCode.InternalServerError.ToString()));

                Object[] data = {
                    new{Nomor = fks.Select(c => c.fks_id).ToArray()},
                    new{Fakultas = fks.Select(c => c.fks_name).ToArray()},
                    new{Deskripsi = fks.Select(c => c.fks_desc).ToArray()}
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

        [HttpGet("GetListById/{ps_fks_id}")]
        public async Task<JsonResult> GetListById([FromRoute] int? ps_fks_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(ps_fks_id == null) throw new Exception("", new Exception("Fail to render Program Studi Data, no data parameter!"));

                List<ProgramStudi> ps = await Task.Run(() => ProgramStudiCRUD.ReadListByFksAsync(Startup.db_kampus_ConnStr, (int)ps_fks_id));
                if(ps == null) throw new Exception("", new Exception("Data not Found!"));

                Object[] data = {
                    new {Nomor = ps.Select(s => s.ps_id).ToArray()},
                    new {pnumber = ps.Select(s => s.ps_fks_id).ToArray()},
                    new {Prodi = ps.Select(s => s.ps_name).ToArray()},
                    new {Deskripsi = ps.Select(s => s.ps_desc).ToArray()}
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

        [HttpGet("GetFksById/{fks_id}")]
        public JsonResult GetFks([FromRoute] int? fks_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(fks_id == null) throw new Exception("", new Exception("Failed Read data, incomplete Data!"));

                Fakultas data = FakultasCRUD.Read(Startup.db_kampus_ConnStr, (int)fks_id);
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

        [HttpGet("GetProdiById/{ps_id}")]
        public JsonResult GetProdi([FromRoute] int? ps_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(ps_id == null) throw new Exception("", new Exception("Failed Read data, incomplete Data!"));

                ProgramStudi data = ProgramStudiCRUD.Read(Startup.db_kampus_ConnStr, (int)ps_id);
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
        public JsonResult AddFakultas([FromBody] Fakultas fks)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(string.IsNullOrEmpty(fks.fks_name)) throw new Exception("", new Exception("Data Not added, incomplete Data!"));

                fks.fks_name = fks.fks_name;
                fks.fks_desc = fks.fks_desc;

                if(FakultasCRUD.Create(Startup.db_kampus_ConnStr, fks) != 1) throw new Exception("", new Exception("Data not added in database!"));

                ress.Code = 1;
                ress.Message = "Data berhasil ditambahkan!";
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

        [HttpPost("Prodi/Create")]
        public JsonResult AddProdi([FromBody] ProgramStudi ps)
        {
            ReturnMessage ress = new ReturnMessage();
            Random rand = new Random();
            try
            {
                if(ps.ps_fks_id == null || string.IsNullOrEmpty(ps.ps_name)) throw new Exception("", new Exception("Data Not added, incomplete Data!"));

                ps.ps_id = rand.Next();
                ps.ps_fks_id = ps.ps_fks_id;
                ps.ps_name = ps.ps_name;
                ps.ps_desc = ps.ps_desc;

                if(ProgramStudiCRUD.Create(Startup.db_kampus_ConnStr, ps) != 1) throw new Exception("", new Exception("Data not added in database!"));

                ress.Code = 1;
                ress.Message = "Data berhasil ditambahkan!";
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
        public JsonResult ChangeFks([FromBody] Fakultas fks)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(fks.fks_id == null || string.IsNullOrEmpty(fks.fks_name)) throw new Exception("", new Exception("Data Not updated, incomplete Data!"));

                fks.fks_name = fks.fks_name;
                fks.fks_desc = fks.fks_desc;

                if(FakultasCRUD.Update(Startup.db_kampus_ConnStr, (int)fks.fks_id, fks) != 1) throw new Exception("", new Exception("Data is not updated in database!"));

                ress.Code = 1;
                ress.Message = "Data berhasil di update!";
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

        [HttpPut("Prodi/Update")]
        public JsonResult ChangeProdi([FromBody] ProgramStudi ps)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(ps.ps_id == null || ps.ps_fks_id == null || string.IsNullOrEmpty(ps.ps_name)) throw new Exception("", new Exception("Data Not updated, incomplete Data!"));

                ps.ps_name = ps.ps_name;
                ps.ps_desc = ps.ps_desc;

                if(ProgramStudiCRUD.Update(Startup.db_kampus_ConnStr, (int)ps.ps_id, (int)ps.ps_fks_id, ps) != 1) throw new Exception("", new Exception("Data is not updated in database!"));

                ress.Code = 1;
                ress.Message = "Data berhasil di update!";
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
        public JsonResult DeleteFks([FromBody] Fakultas fks)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(fks.fks_id == null) throw new Exception("", new Exception("Data Not deleted, incomplete Data!"));

                if(FakultasCRUD.Delete(Startup.db_kampus_ConnStr, (int)fks.fks_id) != 1) throw new Exception("", new Exception("Data is not deleted in database!"));

                ress.Code = 1;
                ress.Message = "Data berhasil dihapus!";
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

        [HttpDelete("Prodi/Delete")]
        public JsonResult DeleteProdi([FromBody] ProgramStudi ps)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(ps.ps_id == null) throw new Exception("", new Exception("Data Not deleted, incomplete Data!"));

                if(ProgramStudiCRUD.Delete(Startup.db_kampus_ConnStr, (int)ps.ps_id) != 1) throw new Exception("", new Exception("Data is not deleted in database!"));

                ress.Code = 1;
                ress.Message = "Data berhasil dihapus!";
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