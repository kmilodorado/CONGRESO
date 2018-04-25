using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class menu_usuario
    {
        Conexion conexion = new Conexion();
        public int fk_idsubitem { get; set; }
        public int fk_idrol { get; set; }
        public string estado { get; set; }
        public menu_usuario() { }
        public menu_usuario(int fk_idsubitem, int fk_idrol, string estado)
        {
            this.fk_idsubitem = fk_idsubitem; this.fk_idrol = fk_idrol; this.estado = estado;
        }
        public DataTable get_menu_usuario() { string sql = "SELECT * FROM menu_usuario"; return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text); }
        public bool insert_menu_usuario(menu_usuario obj) { string sql = "INSERT INTO menu_usuario (fk_idsubitem,fk_idrol,estado) VALUES ({0},{1},{2})"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.fk_idsubitem, obj.fk_idrol, obj.estado); return conexion.RealizarTransaccion(ar); }
        public bool update_menu_usuario(menu_usuario obj) { string sql = "UPDATE menu_usuario SET fk_idsubitem = {0}, fk_idrol = {1}, estado = {2} WHERE fk_idsubitem = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.fk_idsubitem, obj.fk_idrol, obj.estado); return conexion.RealizarTransaccion(ar); }
    }
}
