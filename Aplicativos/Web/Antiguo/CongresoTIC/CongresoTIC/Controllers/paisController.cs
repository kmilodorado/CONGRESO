using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class paisController : ApiController
    {
        pais obj_pais = new pais();
        public DataRow[] allpais()
        {
            DataTable dt = obj_pais.get_pais();
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
        public pais[] data()
        {
            DataTable dt = obj_pais.get_pais();
            DataRow row;
            pais[] paiss = null;
            if (dt.Rows.Count > 0)
            {
                paiss = new pais[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    paiss[i] = new pais(Convert.ToInt32(row["idpais"].ToString()), row["nombrepais"].ToString());
                }
            }
            return paiss;
        }
        public IEnumerable<pais> get_pais()
        {
            return data();
        }
        public IHttpActionResult get_pais(int id)
        {
            var obj = data().FirstOrDefault((o) => o.idpais == id);
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
        public string insert_pais(pais obj)
        {
            if (obj_pais.insert_pais(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_pais(pais obj)
        {
            if (obj_pais.update_pais(obj))
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
