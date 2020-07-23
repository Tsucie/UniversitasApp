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
            try
            {
                
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