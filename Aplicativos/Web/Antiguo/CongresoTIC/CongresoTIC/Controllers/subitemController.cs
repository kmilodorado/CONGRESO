using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class subitemController : ApiController
    {
        subitem obj_subitem = new subitem();
        public DataRow[] allsubitem()
        {
            DataTable dt = obj_subitem.get_subitem();
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
        public subitem[] data()
        {
            DataTable dt = obj_subitem.get_subitem();
            DataRow row;
            subitem[] subitems = null;
            if (dt.Rows.Count > 0)
            {
                subitems = new subitem[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    subitems[i] = new subitem(Convert.ToInt32(row["idsubitem"].ToString()), row["nombresubitem"].ToString(), row["url"].ToString(), Convert.ToInt32(row["fk_iditem"].ToString()));
                }
            }
            return subitems;
        }
        public IEnumerable<subitem> get_subitem()
        {
            return data();
        }
        public IHttpActionResult get_subitem(int id)
        {
            var obj = data().FirstOrDefault((o) => o.idsubitem == id);
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
        public string insert_subitem(subitem obj)
        {
            if (obj_subitem.insert_subitem(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_subitem(subitem obj)
        {
            if (obj_subitem.update_subitem(obj))
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
