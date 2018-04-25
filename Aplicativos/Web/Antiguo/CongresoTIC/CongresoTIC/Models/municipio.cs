using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class municipio
    {
        Conexion conexion = new Conexion();
        public int idmpio { get; set; }
        public string nombrempio { get; set; }
        public int fk_iddpto { get; set; }
        public municipio() { }
        public municipio(int idmpio, string nombrempio, int fk_iddpto)
        {
            this.idmpio = idmpio; this.nombrempio = nombrempio; this.fk_iddpto = fk_iddpto;
        }
        
        public DataTable get_municipio(departamento dpto)
        {
            string sql = "SELECT * FROM municipio m WHERE m.FK_idDpto='" + dpto.iddpto + "'";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }
        public bool insert_municipio(municipio obj) { string sql = "INSERT INTO municipio (idmpio,nombrempio,fk_iddpto) VALUES ({0},{1},{2})"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.idmpio, obj.nombrempio, obj.fk_iddpto); return conexion.RealizarTransaccion(ar); }
        public bool update_municipio(municipio obj) { string sql = "UPDATE municipio SET idmpio = {0}, nombrempio = {1}, fk_iddpto = {2} WHERE idmpio = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.idmpio, obj.nombrempio, obj.fk_iddpto); return conexion.RealizarTransaccion(ar); }
    }
}
