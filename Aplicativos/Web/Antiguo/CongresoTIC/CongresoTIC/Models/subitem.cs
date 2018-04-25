using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class subitem
    {
        Conexion conexion = new Conexion();

        public int idsubitem { get; set; }
        public string nombresubitem { get; set; }
        public string url { get; set; }
        public int fk_iditem { get; set; }
        public string estado { get; set; }

        public subitem() { }

        public subitem(int idsubitem, string nombresubitem, string url, int fk_iditem)
        {
            this.idsubitem = idsubitem;
            this.nombresubitem = nombresubitem;
            this.url = url;
            this.fk_iditem = fk_iditem;
        }
        public DataTable get_subitem() { string sql = "SELECT * FROM subitem"; return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text); }
        public bool insert_subitem(subitem obj) { string sql = "INSERT INTO subitem (idsubitem,nombresubitem,url,fk_iditem) VALUES ({0},{1},{2},{3})"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.idsubitem, obj.nombresubitem, obj.url, obj.fk_iditem); return conexion.RealizarTransaccion(ar); }
        public bool update_subitem(subitem obj) { string sql = "UPDATE subitem SET idsubitem = {0}, nombresubitem = {1}, url = {2}, fk_iditem = {3} WHERE idsubitem = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.idsubitem, obj.nombresubitem, obj.url, obj.fk_iditem); return conexion.RealizarTransaccion(ar); }

        public DataTable ConsultarSubpermisos(rol obj, item per)
        {
            string sql = "SELECT * FROM menu_usuario mp " +
                        "INNER JOIN subitem sp ON mp.FK_idRol = '" + obj.idrol + "' AND mp.FK_idSubitem = sp.idSubitem AND mp.Estado='T' " +
                        "INNER JOIN item p ON sp.FK_idItem='" + per.iditem + "' AND sp.FK_idItem = p.idItem ORDER BY sp.NombreSubitem";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable ConsultarSubpermisosGenerales(rol obj)
        {
            string sql = "SELECT * FROM menu_usuario mp INNER JOIN subitem sp ON mp.FK_idRol = '" + obj.idrol + "' AND mp.FK_idSubitem = sp.idSubitem INNER JOIN permiso p ON sp.FK_idItem = p.idItem";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public bool validarAcceso(string sub, string rol)
        {
            string sql = "SELECT * FROM menu_usuario m WHERE m.FK_idSubitem='" + sub + "' AND m.FK_idRol='" + rol + "' AND m.Estado='T'";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text).Rows.Count > 0 ? true : false;
        }
    }
}
