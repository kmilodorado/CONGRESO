using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CongresoTIC.Controllers
{
    public class refrigerioController : ApiController
    {
        refrigerio obj_refrigerio = new refrigerio();
        participacion part = new participacion();
        usuario user = new usuario();
        persona pers = new persona();

        [HttpPost]
        public bool insert_refrigerio(refrigerio obj)
        {
            return obj_refrigerio.insert_refrigerio(obj);
        }

        public IHttpActionResult registrar_refrigerio(participacion obj)
        {
            int h;
            pers.idpersona = obj.fk_idusuario;
            DataTable dt = pers.get_persona_bycedula(pers);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                part.idpartic = Convert.ToInt32(r["idPartic"].ToString());
                DateTime time = DateTime.Now;

                obj_refrigerio.fecha = time.ToString("yyyy-MM-dd HH:mm:ss");
                obj_refrigerio.fk_idpartic = Convert.ToInt32(r["idPartic"].ToString());
                obj_refrigerio.estado = "T";
                obj_refrigerio.idusuario = obj.userid;

                h = Convert.ToInt32(time.ToString("HH"));

                obj_refrigerio.sesion = h <= 12 ? "1" : "2";
                obj_refrigerio.name = "Name";
                obj_refrigerio.date = time.ToString("yyyy-MM-dd");

                refrigerioController rc = new refrigerioController();

                if (rc.insert_refrigerio(obj_refrigerio))
                {
                    return Json(new
                    {
                        data = "Registro exitoso. Nombre: " + r["Nombres"].ToString() + " " + r["Apellidos"].ToString() + ", Sesion: " + obj_refrigerio.sesion,
                        result = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        data = "Registro fallido. Nombre: " + r["Nombres"].ToString() + " " + r["Apellidos"].ToString() + ", Sesion: " + obj_refrigerio.sesion,
                        result = false
                    });
                }
            }
            else
            {
                return Json(new
                {
                    data = "Participante no encontrado",
                    result = false
                });
            }
        }
    }
}
