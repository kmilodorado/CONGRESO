using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class itemController : ApiController
    {
        item obj_item = new item();
        public DataRow[] allitem()
        {
            DataTable dt = obj_item.get_item();
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
        public item[] data()
        {
            DataTable dt = obj_item.get_item();
            DataRow row;
            item[] items = null;
            if (dt.Rows.Count > 0)
            {
                items = new item[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    items[i] = new item(Convert.ToInt32(row["iditem"].ToString()), row["nombreitem"].ToString(), row["icon"].ToString());
                }
            }
            return items;
        }
        public IEnumerable<item> get_item()
        {
            return data();
        }
        public IHttpActionResult get_item(int id)
        {
            var obj = data().FirstOrDefault((o) => o.iditem == id);
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
        public string insert_item(item obj)
        {
            if (obj_item.insert_item(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_item(item obj)
        {
            if (obj_item.update_item(obj))
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
