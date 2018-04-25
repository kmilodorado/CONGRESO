using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models{
public class rol{
Conexion conexion = new Conexion();
public int idrol { get; set; }
public string nombrerol { get; set; }
public rol (){}
public rol (int idrol,string nombrerol){
this.idrol = idrol;this.nombrerol = nombrerol;
}
public DataTable get_rol(){string sql = "SELECT * FROM rol";return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);}
public bool insert_rol(rol obj ){string sql = "INSERT INTO rol (idrol,nombrerol) VALUES ({0},{1})";string[] ar = new string[1];ar[0] = string.Format(sql, obj.idrol,obj.nombrerol);return conexion.RealizarTransaccion(ar); }
public bool update_rol(rol obj ){string sql = "UPDATE rol SET idrol = {0}, nombrerol = {1} WHERE idrol = {0}";string[] ar = new string[1];ar[0] = string.Format(sql, obj.idrol, obj.nombrerol);return conexion.RealizarTransaccion(ar);}
}}
