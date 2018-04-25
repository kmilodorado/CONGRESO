using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class usuarioController : ApiController
    {
        usuario obj_usuario = new usuario();
        public DataRow[] allusuario()
        {
            DataTable dt = obj_usuario.get_usuario();
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
        public usuario[] data()
        {
            DataTable dt = obj_usuario.get_usuario();
            DataRow row;
            usuario[] usuarios = null;
            if (dt.Rows.Count > 0)
            {
                usuarios = new usuario[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    usuarios[i] = new usuario(Convert.ToInt32(row["idusuario"].ToString()), row["username"].ToString(), row["contraseña"].ToString(), row["estado"].ToString(), Convert.ToInt32(row["fkl_idrol"].ToString()), Convert.ToInt64(row["fk_idpersona"].ToString()));
                }
            }
            return usuarios;
        }
        public IHttpActionResult get_usuario()
        {
            return Json(obj_usuario.get_usuario());
        }

        public DataTable validarUsuario(usuario obj)
        {
            return obj_usuario.validarUsuario(obj);
        }

        public IHttpActionResult select_usuario(usuario user)
        {
            DataTable dt = obj_usuario.validarUsuario(user);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                bool logis;
                obj_usuario.idusuario = Convert.ToInt32(r["idUsuario"].ToString());
                DataTable dl = obj_usuario.isLector(obj_usuario);

                logis = dl.Rows.Count > 0;
                Security sec = new Security();
                if (sec.Encripta(user.contraseña).Equals(r["Contraseña"].ToString()))
                {
                    return Json(new
                    {
                        data = obj_usuario.validarUsuario(user),
                        result = true,
                        logistica = logis
                    });
                }
                else
                {
                    return Json(new
                    {
                        data = "Datos incorrectos",
                        result = false,
                        logistica = false
                    });
                }
            }
            else
            {
                return Json(new
                {
                    result = false
                });
            }
        }


        [HttpPost]
        public string insert_usuario(usuario obj)
        {
            if (obj_usuario.insert_usuario(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_usuario(usuario obj)
        {
            if (obj_usuario.update_usuario(obj))
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
