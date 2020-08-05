using System;
using System.Collections.Generic;
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
    public class ProgramStudiController : Controller
    {
        [HttpGet("GetListById/{ps_fks_id}")]
        public JsonResult GetListById([FromRoute] int ps_fks_id)
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                if(ps_fks_id.Equals(null)) throw new Exception("", new Exception("Fail to render Program Studi Combo box, Incomplete data!"));

                var ps = ProgramStudiCRUD.ReadListByFks(Startup.db_kampus_ConnStr, ps_fks_id);
                if(ps.Equals(null)) throw new Exception("", new Exception("Data not Found!"));

                Object[] data = {
                    new {Nomor = ps.Select(s => s.ps_id).ToArray()},
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
    }
}