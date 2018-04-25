using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class tipo_documentoController : ApiController
    {
        tipo_documento obj_tipo_documento = new tipo_documento();
        public DataRow[] alltipo_documento()
        {
            DataTable dt = obj_tipo_documento.get_tipo_documento();
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
        public tipo_documento[] data()
        {
            DataTable dt = obj_tipo_documento.get_tipo_documento();
            DataRow row;
            tipo_documento[] tipo_documentos = null;
            if (dt.Rows.Count > 0)
            {
                tipo_documentos = new tipo_documento[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    tipo_documentos[i] = new tipo_documento(Convert.ToInt32(row["idtipodoc"].ToString()), row["nombretipodoc"].ToString());
                }
            }
            return tipo_documentos;
        }

        public DataTable get_tipo_documentos()
        {
            return obj_tipo_documento.get_tipo_documento();
        }

        public IEnumerable<tipo_documento> get_tipo_documento()
        {
            return data();
        }
        public IHttpActionResult get_tipo_documento(int id)
        {
            var obj = data().FirstOrDefault((o) => o.idtipodoc == id);
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
        public string insert_tipo_documento(tipo_documento obj)
        {
            if (obj_tipo_documento.insert_tipo_documento(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_tipo_documento(tipo_documento obj)
        {
            if (obj_tipo_documento.update_tipo_documento(obj))
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
