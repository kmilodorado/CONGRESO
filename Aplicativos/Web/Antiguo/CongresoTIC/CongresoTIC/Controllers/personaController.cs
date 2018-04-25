using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class personaController : ApiController
    {
        persona obj_persona = new persona();
        public DataRow[] allpersona()
        {
            DataTable dt = obj_persona.get_persona();
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
        public persona[] data()
        {
            DataTable dt = obj_persona.get_persona();
            DataRow row;
            persona[] personas = null;
            if (dt.Rows.Count > 0)
            {
                personas = new persona[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    personas[i] = new persona(Convert.ToInt64(row["idpersona"].ToString()), row["nombres"].ToString(), row["apellidos"].ToString(), row["correo"].ToString(), row["institucion"].ToString(), row["observaciones"].ToString(), Convert.ToInt32(row["fk_idtipodoc"].ToString()), Convert.ToInt32(row["fk_idmpio"].ToString()));
                }
            }
            return personas;
        }
        public IEnumerable<persona> get_persona()
        {
            return data();
        }

        public DataTable get_persona_bycedula(persona obj)
        {
            return obj_persona.get_persona_bycedula(obj);
        }

       
        [HttpPost]
        public bool insert_persona(persona obj, usuario user, participacion partic)
        {
            if (obj_persona.insert_persona(obj, user, partic))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        public string update_persona(persona obj)
        {
            if (obj_persona.update_persona(obj))
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
