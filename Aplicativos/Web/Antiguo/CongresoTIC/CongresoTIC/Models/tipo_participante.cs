using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class tipo_participante
    {
        Conexion conexion = new Conexion();
        public int idtipopart { get; set; }
        public string nombretipopart { get; set; }
        public string estado { get; set; }
        public tipo_participante() { }
        public tipo_participante(int idtipopart, string nombretipopart, string estado)
        {
            this.idtipopart = idtipopart; this.nombretipopart = nombretipopart; this.estado = estado;
        }
        public DataTable get_tipo_participante() {
            string sql = "SELECT * FROM tipo_participante";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable get_tipo_persona()
        {
            string sql = "SELECT * FROM tipo_persona";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }
        public bool insert_tipo_participante(tipo_participante obj) { string sql = "INSERT INTO tipo_participante (nombretipopart,estado) VALUES ({0},{1})"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.nombretipopart, obj.estado); return conexion.RealizarTransaccion(ar); }
        public bool update_tipo_participante(tipo_participante obj) { string sql = "UPDATE tipo_participante SET nombretipopart = {0}, estado = {1} WHERE idtipopart = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.nombretipopart, obj.estado); return conexion.RealizarTransaccion(ar); }
    }
}
