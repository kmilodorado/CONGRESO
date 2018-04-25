using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class asistenciaController : ApiController
    {
        asistencia obj_asistencia = new asistencia();
        participacion part = new participacion();
        usuario user = new usuario();
        persona pers = new persona();

        public DataRow[] allasistencia()
        {
            DataTable dt = obj_asistencia.get_asistencia();
            DataRow[] rows = null;
            if (dt.Rows.Count > 0)
            {
                rows = new DataRow[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rows[i] = dt.Rows[i];
                }
            }
            return rows;
        }
        public asistencia[] data()
        {
            DataTable dt = obj_asistencia.get_asistencia();
            DataRow row;
            asistencia[] asistencias = null;
            if (dt.Rows.Count > 0)
            {
                asistencias = new asistencia[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    asistencias[i] = new asistencia(Convert.ToInt32(row["idasistencia"].ToString()), row["fecha"].ToString(), row["estado"].ToString(), Convert.ToInt32(row["fk_idpartic"].ToString()));
                }
            }
            return asistencias;
        }
        public IEnumerable<asistencia> get_asistencia()
        {
            return data();
        }
        public IHttpActionResult get_asistencia(int id)
        {
            var obj = data().FirstOrDefault((o) => o.idasistencia == id);
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult registrar_asistencia(participacion obj)
        {
            int h;
            string tip = "";
            pers.idpersona = obj.fk_idusuario;
            DataTable dt = pers.get_persona_bycedula(pers);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                part.idpartic = Convert.ToInt32(r["idPartic"].ToString());
                DateTime time = DateTime.Now;

                string Date = time.ToString("yyyy-MM-dd");

                obj_asistencia.fk_idpartic = Convert.ToInt32(r["idPartic"].ToString());
                obj_asistencia.estado = "T";

                h = Convert.ToInt32(time.ToString("HH"));

                obj_asistencia.sesion = h <= 12 ? "1" : "2";

                //if ((h >= 7 && h <= 9) || (h >= 14 && h <= 15))
                //{
                //    tip = "Entrada";
                //}
                //else if ((h >= 11 && h <= 13) || (h >= 17 && h <= 19))
                //{
                //    tip = "Salida";
                //}

                obj_asistencia.fecha = Date;
                DataTable data = obj_asistencia.get_reg_asistencia(obj_asistencia);
                if (data.Rows.Count == 0)
                {
                    tip = "Entrada";
                }
                else
                {
                    tip = "Salida";
                }

                obj_asistencia.idusuario = obj.userid;
                obj_asistencia.tipo = tip;
                obj_asistencia.date = Date;
                obj_asistencia.fecha = time.ToString("yyyy-MM-dd HH:mm:ss");

                asistenciaController rc = new asistenciaController();

                if (rc.insert_asistencia(obj_asistencia))
                {
                    return Json(new
                    {
                        data = "Registro exitoso. Nombre: " + r["Nombres"].ToString() + " " + r["Apellidos"].ToString() + ", Sesion: " + obj_asistencia.sesion + ", Tipo: " + obj_asistencia.tipo,
                        result = true
                    });
                }

                else
                {
                    return Json(new
                    {
                        data = "Registro fallido. Nombre: " + r["Nombres"].ToString() + " " + r["Apellidos"].ToString() + ", Sesion: " + obj_asistencia.sesion + ", Tipo: " + obj_asistencia.tipo,
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

        [HttpPost]
        public bool insert_asistencia(asistencia obj)
        {
            return obj_asistencia.insert_asistencia(obj);
        }

        [HttpPost]
        public string update_asistencia(asistencia obj)
        {
            if (obj_asistencia.update_asistencia(obj))
            {
                return "U200";
            }
            else
            {
                return "U500";
            }
        }
    }
}
