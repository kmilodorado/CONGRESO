using ServicioEvento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioEvento.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ValidarUsuario(string user,string pass)
        {
            return Json(new ModeloMaster().ValidarUsuario(user, pass,"5"));
        }
    }
}
