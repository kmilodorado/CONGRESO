using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class tipo_participanteController : ApiController
    {
        tipo_participante obj_tipo_participante = new tipo_participante();
        public DataRow[] alltipo_participante()
        {
            DataTable dt = obj_tipo_participante.get_tipo_participante();
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
        public tipo_participante[] data()
        {
            DataTable dt = obj_tipo_participante.get_tipo_participante();
            DataRow row;
            tipo_participante[] tipo_participantes = null;
            if (dt.Rows.Count > 0)
            {
                tipo_participantes = new tipo_participante[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    tipo_participantes[i] = new tipo_participante(Convert.ToInt32(row["idtipopart"].ToString()), row["nombretipopart"].ToString(), row["estado"].ToString());
                }
            }
            return tipo_participantes;
        }

        public DataTable get_tipo_participantes()
        {
            return obj_tipo_participante.get_tipo_participante();
        }

        public DataTable get_tipo_persona()
        {
            return obj_tipo_participante.get_tipo_persona();
        }

        public IEnumerable<tipo_participante> get_tipo_participante()
        {
            return data();
        }
        public IHttpActionResult get_tipo_participante(int id)
        {
            var obj = data().FirstOrDefault((o) => o.idtipopart == id);
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public string insert_tipo_participante(tipo_participante obj)
        {
            if (obj_tipo_participante.insert_tipo_participante(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_tipo_participante(tipo_participante obj)
        {
            if (obj_tipo_participante.update_tipo_participante(obj))
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
