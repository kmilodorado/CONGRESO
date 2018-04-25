using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models{
public class tipo_documento{
Conexion conexion = new Conexion();
public int idtipodoc { get; set; }
public string nombretipodoc { get; set; }
public tipo_documento (){}
public tipo_documento (int idtipodoc,string nombretipodoc){
this.idtipodoc = idtipodoc;this.nombretipodoc = nombretipodoc;
}
public DataTable get_tipo_documento(){string sql = "SELECT * FROM tipo_documento";return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);}
public bool insert_tipo_documento(tipo_documento obj ){string sql = "INSERT INTO tipo_documento (nombretipodoc) VALUES ({0})";string[] ar = new string[1];ar[0] = string.Format(sql, obj.nombretipodoc);return conexion.RealizarTransaccion(ar); }
public bool update_tipo_documento(tipo_documento obj ){string sql = "UPDATE tipo_documento SET nombretipodoc = {0} WHERE idtipodoc = {0}";string[] ar = new string[1];ar[0] = string.Format(sql, obj.nombretipodoc);return conexion.RealizarTransaccion(ar);}
}}
