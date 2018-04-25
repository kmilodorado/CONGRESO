using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class asistencia
    {
        Conexion conexion = new Conexion();
        public int idasistencia { get; set; }
        public string fecha { get; set; }
        public string date { get; set; }
        public string estado { get; set; }
        public int fk_idpartic { get; set; }
        public string sesion { get; set; }
        public string tipo { get; set; }
        public string idusuario { get; set; }

        public asistencia() { }

        public asistencia(int idasistencia, string fecha, string estado, int fk_idpartic)
        {
            this.idasistencia = idasistencia; this.fecha = fecha; this.estado = estado; this.fk_idpartic = fk_idpartic;
        }

        public DataTable get_asistencia() { string sql = "SELECT * FROM asistencia"; return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text); }

        public DataTable get_reg_asistencia(asistencia obj)
        {
            string sql = "SELECT * FROM asistencia a WHERE a.FK_idPartic='" + obj.fk_idpartic + "' AND DATE(a.Fecha)='" + obj.fecha + "' AND a.Sesion='" + obj.sesion + "'";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable get_asistencias()
        {
            string sql = "SELECT * FROM asistencia a INNER JOIN participacion par ON a.FK_idPartic=par.idPartic INNER JOIN usuario u ON par.FK_idUsuario=u.idUsuario INNER JOIN persona p ON u.FK_idPersona=p.idPersona ORDER BY a.Fecha DESC";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable get_asistencias_tipo(asistencia obj)
        {
            string sql = "SELECT * FROM asistencia a WHERE DATE(a.Fecha)='" + obj.date + "' AND a.Sesion='" + obj.sesion + "' AND a.Tipo='" + obj.tipo + "'";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public bool insert_asistencia(asistencia obj)
        {
            string sql = "INSERT INTO asistencia (fecha,estado,fk_idpartic,sesion,tipo, date, FK_idUsuario) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.fecha, obj.estado, obj.fk_idpartic, obj.sesion, obj.tipo, obj.date, obj.idusuario);
            return conexion.RealizarTransaccion(ar);
        }

        public bool borrar_asistencia(asistencia obj)
        {
            string sql = "DELETE FROM asistencia WHERE idAsistencia = '" + obj.idasistencia + "'";
            string[] ar = new string[1];
            ar[0] = string.Format(sql);
            return conexion.RealizarTransaccion(ar);
        }


        public bool update_asistencia(asistencia obj) { string sql = "UPDATE asistencia SET fecha = {0}, estado = {1}, fk_idpartic = {2} WHERE idasistencia = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.fecha, obj.estado, obj.fk_idpartic); return conexion.RealizarTransaccion(ar); }
    }
}
