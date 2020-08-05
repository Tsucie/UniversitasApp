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
    public class FakultasController : Controller
    {
        [HttpGet("GetList")]
        public JsonResult FakultasList()
        {
            ReturnMessage ress = new ReturnMessage();
            try
            {
                var fks = FakultasCRUD.ReadAll(Startup.db_kampus_ConnStr);
                if(fks.Equals(null)) throw new Exception("", new Exception("Data Not Found!"));

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
    }
}