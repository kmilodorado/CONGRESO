using CongresoTIC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CongresoTIC.Models
{
    public class refrigerio
    {
        Conexion conexion = new Conexion();
        public int idrefrigerio { get; set; }
        public string fecha { get; set; }
        public string estado { get; set; }
        public int fk_idpartic { get; set; }
        public string sesion { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string idusuario { get; set; }

        public refrigerio() { }

        public DataTable get_refrigerio()
        {
            string sql = "SELECT * FROM refrigerios";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable get_refrigerios()
        {
            string sql = "SELECT * FROM refrigerios a INNER JOIN participacion par ON a.FK_idPartic=par.idPartic INNER JOIN usuario u ON par.FK_idUsuario=u.idUsuario INNER JOIN persona p ON u.FK_idPersona=p.idPersona ORDER BY a.Fecha DESC";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public bool insert_refrigerio(refrigerio obj)
        {
            string sql = "INSERT INTO refrigerios (fecha,estado,sesion,fk_idpartic, Name, Date, FK_idUsuario) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.fecha, obj.estado, obj.sesion, obj.fk_idpartic, obj.name, obj.date, obj.idusuario);
            return conexion.RealizarTransaccion(ar);
        }

        public bool borrar_refrigerio(refrigerio obj)
        {
            string sql = "DELETE FROM refrigerios WHERE idRefrigerio = '" + obj.idrefrigerio + "'";
            string[] ar = new string[1];
            ar[0] = string.Format(sql);
            return conexion.RealizarTransaccion(ar);
        }
    }
}
