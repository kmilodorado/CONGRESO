using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class item
    {
        Conexion conexion = new Conexion();

        public int iditem { get; set; }
        public string nombreitem { get; set; }
        public string icon { get; set; }
        

        public item() { }

        public item(int iditem, string nombreitem, string icon)
        {
            this.iditem = iditem;
            this.nombreitem = nombreitem;
            this.icon = icon;
        }
        public DataTable get_item()
        {
            string sql = "SELECT * FROM item";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public bool insert_item(item obj)
        {
            string sql = "INSERT INTO item (nombreitem,icon) VALUES ('{0}','{1}')";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.nombreitem, obj.icon);
            return conexion.RealizarTransaccion(ar);
        }

        public bool update_item(item obj) { string sql = "UPDATE item SET nombreitem = {0}, icon = {1} WHERE iditem = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.nombreitem, obj.icon); return conexion.RealizarTransaccion(ar); }

        public DataTable ConsultarPermisos(rol obj)
        {
            string sql = "SELECT * FROM menu_usuario mp " +
                        "INNER JOIN subitem sp ON mp.FK_idRol = '" + obj.idrol + "' AND mp.FK_idSubitem = sp.idSubitem AND mp.Estado='T' " +
                        "INNER JOIN item p ON sp.FK_idItem = p.idItem GROUP BY p.NombreItem;";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }
        public DataTable ConsultarPermisosGenerales()
        {
            string sql = "SELECT * FROM menu_usuario mp " +
                        "INNER JOIN subitem sp ON mp.FK_idSubitem = sp.idSubitem AND mp.Estado='T' " +
                        "INNER JOIN item p ON sp.FK_idItem = p.idItem GROUP BY p.NombreItem;";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public string updateMenu(subitem sub, rol rol)
        {
            string SQL = "UPDATE menu_usuario m SET m.Estado='" + sub.estado + "' WHERE m.FK_idSubitem='" + sub.idsubitem + "' AND m.FK_idRol='" + rol.idrol + "';";
            return SQL;
        }

        public bool updateMenuTotal(string[] ar)
        {
            return conexion.RealizarTransaccion(ar);
        }
    }
}
