using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class departamento
    {
        Conexion conexion = new Conexion();
        public int iddpto { get; set; }
        public string nombredpto { get; set; }
        public int fk_idpais { get; set; }
        public departamento() { }
        public departamento(int iddpto, string nombredpto, int fk_idpais)
        {
            this.iddpto = iddpto; this.nombredpto = nombredpto; this.fk_idpais = fk_idpais;
        }
        public DataTable get_departamento() { string sql = "SELECT * FROM departamento"; return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text); }
        public bool insert_departamento(departamento obj) { string sql = "INSERT INTO departamento (iddpto,nombredpto,fk_idpais) VALUES ({0},{1},{2})"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.iddpto, obj.nombredpto, obj.fk_idpais); return conexion.RealizarTransaccion(ar); }
        public bool update_departamento(departamento obj) { string sql = "UPDATE departamento SET iddpto = {0}, nombredpto = {1}, fk_idpais = {2} WHERE iddpto = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.iddpto, obj.nombredpto, obj.fk_idpais); return conexion.RealizarTransaccion(ar); }
    }
}
