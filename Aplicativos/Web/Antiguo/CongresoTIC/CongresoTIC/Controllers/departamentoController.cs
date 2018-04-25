using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class departamentoController : ApiController
    {
        departamento obj_departamento = new departamento();
        

        public departamento[] data()
        {
            DataTable dt = obj_departamento.get_departamento();
            DataRow row;
            departamento[] departamentos = null;
            if (dt.Rows.Count > 0)
            {
                departamentos = new departamento[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    departamentos[i] = new departamento(Convert.ToInt32(row["iddpto"].ToString()), row["nombredpto"].ToString(), Convert.ToInt32(row["fk_idpais"].ToString()));
                }
            }
            return departamentos;
        }

        public DataTable get_departamentos()
        {
            return obj_departamento.get_departamento();
        }

        public IEnumerable<departamento> get_departamento()
        {
            return data();
        }
        public IHttpActionResult get_departamento(int id)
        {
            var obj = data().FirstOrDefault((o) => o.iddpto == id);
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
        public string insert_departamento(departamento obj)
        {
            if (obj_departamento.insert_departamento(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_departamento(departamento obj)
        {
            if (obj_departamento.update_departamento(obj))
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
