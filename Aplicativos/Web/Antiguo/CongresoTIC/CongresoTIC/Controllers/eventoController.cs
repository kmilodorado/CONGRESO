using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class eventoController : ApiController
    {
        evento obj_evento = new evento();
        public DataRow[] allevento()
        {
            DataTable dt = obj_evento.get_evento();
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
        public evento[] data()
        {
            DataTable dt = obj_evento.get_evento();
            DataRow row;
            evento[] eventos = null;
            if (dt.Rows.Count > 0)
            {
                eventos = new evento[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    eventos[i] = new evento(Convert.ToInt32(row["idevento"].ToString()), row["nombreevento"].ToString(), row["fechainicio"].ToString(), row["fechafin"].ToString(), row["estado"].ToString(), Convert.ToInt32(row["cupos"].ToString()), row["lugar"].ToString());
                }
            }
            return eventos;
        }
        public IEnumerable<evento> get_evento()
        {
            return data();
        }
        public IHttpActionResult get_evento(int id)
        {
            var obj = data().FirstOrDefault((o) => o.idevento == id);
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
        public string insert_evento(evento obj)
        {
            if (obj_evento.insert_evento(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_evento(evento obj)
        {
            if (obj_evento.update_evento(obj))
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
