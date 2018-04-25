using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class evento
    {
        Conexion conexion = new Conexion();
        public int idevento { get; set; }
        public string nombreevento { get; set; }
        public string fechainicio { get; set; }
        public string fechafin { get; set; }
        public string estado { get; set; }
        public int cupos { get; set; }
        public string lugar { get; set; }
        public evento() { }
        public evento(int idevento, string nombreevento, string fechainicio, string fechafin, string estado, int cupos, string lugar)
        {
            this.idevento = idevento; this.nombreevento = nombreevento; this.fechainicio = fechainicio; this.fechafin = fechafin; this.estado = estado; this.cupos = cupos; this.lugar = lugar;
        }
        public DataTable get_evento() { string sql = "SELECT * FROM evento"; return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text); }
        public bool insert_evento(evento obj) { string sql = "INSERT INTO evento (nombreevento,fechainicio,fechafin,estado,cupos,lugar) VALUES ({0},{1},{2},{3},{4},{5})"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.nombreevento, obj.fechainicio, obj.fechafin, obj.estado, obj.cupos, obj.lugar); return conexion.RealizarTransaccion(ar); }
        public bool update_evento(evento obj) { string sql = "UPDATE evento SET nombreevento = {0}, fechainicio = {1}, fechafin = {2}, estado = {3}, cupos = {4}, lugar = {5} WHERE idevento = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.nombreevento, obj.fechainicio, obj.fechafin, obj.estado, obj.cupos, obj.lugar); return conexion.RealizarTransaccion(ar); }
    }
}
