using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class participacion
    {
        Conexion conexion = new Conexion();
        public int idpartic { get; set; }
        public int fk_idtipopart { get; set; }
        public int fk_idevento { get; set; }
        public int fk_iduser { get; set; }
        public string userid { get; set; }
        public long fk_idusuario { get; set; }
        public long fk_idpersona { get; set; }
        public int fk_tipopersona { get; set; }
        public string estado { get; set; }
        public string fecha { get; set; }
        public string calificador { get; set; }

        public participacion() { }
        public participacion(int idpartic, int fk_idtipopart, int fk_idevento, int fk_idusuario, string estado, string fecha)
        {
            this.idpartic = idpartic; this.fk_idtipopart = fk_idtipopart; this.fk_idevento = fk_idevento; this.fk_iduser = fk_idusuario; this.estado = estado; this.fecha = fecha;
        }
        public DataTable get_participacion()
        {
            string sql = "SELECT * FROM participacion";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable get_participacion_persona(usuario obj)
        {
            string sql = "SELECT * FROM participacion p INNER JOIN tipo_participante t ON p.FK_idUsuario='" + obj.idusuario + "' AND p.FK_idTipoPart= t.idTipoPart";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable get_certificados(participacion obj)
        {
            string sql = "SELECT * FROM asistencia a WHERE a.FK_idPartic='" + obj.idpartic + "' AND a.Tipo='Entrada'";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable get_inscritos()
        {
            string sql = "SELECT * FROM participacion p INNER JOIN usuario u ON p.FK_idUsuario = u.idUsuario INNER JOIN persona pe ON u.FK_idPersona=pe.idPersona INNER JOIN tipo_participante tp ON p.FK_idTipoPart=tp.idTipoPart ORDER BY p.Fecha DESC";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable get_inscritos2()
        {
            string sql = "SELECT * FROM participacion p INNER JOIN usuario u ON p.FK_idUsuario = u.idUsuario INNER JOIN persona pe ON u.FK_idPersona=pe.idPersona INNER JOIN tipo_participante tp ON p.FK_idTipoPart=tp.idTipoPart ORDER BY pe.Nombres";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable get_activos()
        {
            string sql = "SELECT * FROM participacion p INNER JOIN usuario u ON p.EstadoPart='T' AND p.FK_idUsuario=u.idUsuario INNER JOIN persona pr ON u.FK_idPersona=pr.idPersona INNER JOIN tipo_participante tp ON p.FK_idTipoPart=tp.idTipoPart INNER JOIN recibo_pago rp ON rp.FK_idParticipacion=p.idPartic INNER JOIN municipio m ON pr.FK_idMpio=m.idMpio";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable get_dato_participacion(string id_partic)
        {
            string sql = "SELECT * FROM participacion p INNER JOIN usuario u ON p.idPartic = '"+ id_partic + "' AND p.FK_idUsuario=u.idUsuario INNER JOIN persona pr ON u.FK_idPersona=pr.idPersona";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable get_activos_uno(persona p)
        {
            string sql = "SELECT * FROM participacion p INNER JOIN usuario u ON p.FK_idUsuario=u.idUsuario INNER JOIN persona pr ON pr.idPersona='" + p.idpersona + "' AND u.FK_idPersona=pr.idPersona INNER JOIN tipo_participante tp ON p.FK_idTipoPart=tp.idTipoPart INNER JOIN municipio m ON pr.FK_idMpio=m.idMpio";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool update_inscripcion(participacion obj)
        {
            string sql = "UPDATE participacion p SET p.EstadoPart='{0}', p.Calificador ='{1}' WHERE p.idPartic='{2}';";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.estado, obj.calificador, obj.idpartic);
            return conexion.RealizarTransaccion(ar);

        }

        public bool insert_participacion(participacion obj)
        {
            string sql = "INSERT INTO participacion (idpartic,fk_idtipopart,fk_idevento,fk_idusuario,estado,fecha) VALUES ({0},{1},{2},{3},{4},{5})";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.idpartic, obj.fk_idtipopart, obj.fk_idevento, obj.fk_iduser, obj.estado, obj.fecha);
            return conexion.RealizarTransaccion(ar);
        }

        public bool insert_logistica(participacion obj)
        {
            string sql = "INSERT INTO logistica (FK_idUsuario, Fecha, Estado) VALUES ('{0}',NOW(),'T') ";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.fk_iduser);
            return conexion.RealizarTransaccion(ar);
        }

        public DataTable get_logistica()
        {
            string sql = "SELECT* FROM logistica l INNER JOIN usuario u ON l.FK_idUsuario = u.idUsuario INNER JOIN persona p ON u.FK_idPersona= p.idPersona ORDER BY l.Fecha DESC";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }



        public bool update_participacion(participacion obj) { string sql = "UPDATE participacion SET idpartic = {0}, fk_idtipopart = {1}, fk_idevento = {2}, fk_idusuario = {3}, estado = {4}, fecha = {5} WHERE idpartic = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.idpartic, obj.fk_idtipopart, obj.fk_idevento, obj.fk_iduser, obj.estado, obj.fecha); return conexion.RealizarTransaccion(ar); }
    }
}
