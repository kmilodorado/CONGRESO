using ServicioEvento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioEvento.Controllers
{
    public class AsistenciaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GestionarAsistencia(string codigo, string evento)
        {
            return Json(new ModeloMaster().GestionarAsistencia(codigo,evento, DateTime.Now.ToString("H:mm:ss")));
        }
        [HttpGet]
        public IHttpActionResult RegistrarRefigerio(string codigo,string evento)
        {
            return Json(new ModeloMaster().GestionarRefrigerio(codigo, evento, DateTime.Now.ToString("H:mm:ss")));
        }
    }
}
