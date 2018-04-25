using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models{
public class pais{
Conexion conexion = new Conexion();
public int idpais { get; set; }
public string nombrepais { get; set; }
public pais (){}
public pais (int idpais,string nombrepais){
this.idpais = idpais;this.nombrepais = nombrepais;
}
public DataTable get_pais(){string sql = "SELECT * FROM pais";return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);}
public bool insert_pais(pais obj ){string sql = "INSERT INTO pais (nombrepais) VALUES ({0})";string[] ar = new string[1];ar[0] = string.Format(sql, obj.nombrepais);return conexion.RealizarTransaccion(ar); }
public bool update_pais(pais obj ){string sql = "UPDATE pais SET nombrepais = {0} WHERE idpais = {0}";string[] ar = new string[1];ar[0] = string.Format(sql, obj.nombrepais);return conexion.RealizarTransaccion(ar);}
}}
