using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class municipioController : ApiController
    {
        municipio obj_municipio = new municipio();
        
        public municipio[] data()
        {
            departamento dpro = new departamento();
            DataTable dt = obj_municipio.get_municipio(dpro);
            DataRow row;
            municipio[] municipios = null;
            if (dt.Rows.Count > 0)
            {
                municipios = new municipio[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    municipios[i] = new municipio(Convert.ToInt32(row["idmpio"].ToString()), row["nombrempio"].ToString(), Convert.ToInt32(row["fk_iddpto"].ToString()));
                }
            }
            return municipios;
        }

        public DataTable get_mpio_by_dpto(departamento dpto)
        {
            return obj_municipio.get_municipio(dpto);
        }

        public IEnumerable<municipio> get_municipio()
        {
            return data();
        }
        public IHttpActionResult get_municipio(int id)
        {
            var obj = data().FirstOrDefault((o) => o.idmpio == id);
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
        public string insert_municipio(municipio obj)
        {
            if (obj_municipio.insert_municipio(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_municipio(municipio obj)
        {
            if (obj_municipio.update_municipio(obj))
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
