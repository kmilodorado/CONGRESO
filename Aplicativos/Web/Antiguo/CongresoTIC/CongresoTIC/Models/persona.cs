using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class persona
    {
        Conexion conexion = new Conexion();
        public long idpersona { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string institucion { get; set; }
        public string observaciones { get; set; }
        public int fk_idtipodoc { get; set; }
        public int fk_idtipopers { get; set; }
        public int fk_idmpio { get; set; }
        public persona() { }
        public persona(long idpersona, string nombres, string apellidos, string correo, string institucion, string observaciones, int fk_idtipodoc, int fk_idmpio)
        {
            this.idpersona = idpersona; this.nombres = nombres; this.apellidos = apellidos; this.correo = correo; this.institucion = institucion; this.observaciones = observaciones; this.fk_idtipodoc = fk_idtipodoc; this.fk_idmpio = fk_idmpio;
        }
        public DataTable get_persona() { string sql = "SELECT * FROM persona"; return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text); }

        //public DataTable get_persona_bycedula(persona obj)
        //{
        //    string sql = "SELECT * FROM participacion pa INNER JOIN usuario u ON pa.EstadoPart='T' AND pa.FK_idUsuario = u.idUsuario INNER JOIN persona p ON p.idPersona='" + obj.idpersona + "' AND u.FK_idPersona = p.idPersona INNER JOIN tipo_participante tp ON pa.FK_idTipoPart=tp.idTipoPart";
        //    return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        //}

        public DataTable get_persona_bycedula(persona obj)
        {
            string sql = "SELECT *, CONCAT_WS(' ', Nombres, Apellidos) AS Nombre FROM participacion pa INNER JOIN usuario u ON pa.FK_idUsuario = u.idUsuario INNER JOIN persona p ON p.idPersona='" + obj.idpersona + "' AND u.FK_idPersona = p.idPersona INNER JOIN tipo_participante tp ON pa.FK_idTipoPart=tp.idTipoPart";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public bool insert_persona(persona obj, usuario user, participacion partic)
        {
            string sql = "INSERT INTO persona (idpersona,nombres,apellidos,correo,institucion,observaciones,fk_idtipodoc,fk_idtipopersona,fk_idmpio) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
            string sql2 = "INSERT INTO usuario (idusuario, username,contraseña,estado,fk_idrol,fk_idpersona) VALUES ('{0}','{1}','{2}','T','2','{3}')";
            string sql3 = "INSERT INTO participacion (FK_idTipoPart,FK_idEvento,FK_idUsuario,EstadoPart,Fecha) VALUES ('{0}','{1}','{2}','E',NOW())";
            string[] ar = new string[3];
            ar[0] = string.Format(sql, obj.idpersona, obj.nombres, obj.apellidos, obj.correo, obj.institucion, obj.observaciones, obj.fk_idtipodoc, obj.fk_idtipopers, obj.fk_idmpio);
            ar[1] = string.Format(sql2, user.idusuario, user.username, user.contraseña, obj.idpersona);
            ar[2] = string.Format(sql3, partic.fk_idtipopart, partic.fk_idevento, partic.fk_iduser);
            return conexion.RealizarTransaccion(ar);
        }

        public bool ver_encuesta(string cedula)
        {
            string sql = "UPDATE persona SET Encuesta = 'T' WHERE idPersona = '" + cedula + "';";
            string[] ar = new string[1];
            ar[0] = string.Format(sql);
            return conexion.RealizarTransaccion(ar);
        }


        public bool update_persona(persona obj)
        {
            string sql = "UPDATE persona SET idpersona = {0}, nombres = {1}, apellidos = {2}, correo = {3}, institucion = {4}, observaciones = {5}, fk_idtipodoc = {6}, fk_idmpio = {7} WHERE idpersona = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.idpersona, obj.nombres, obj.apellidos, obj.correo, obj.institucion, obj.observaciones, obj.fk_idtipodoc, obj.fk_idmpio); return conexion.RealizarTransaccion(ar);
        }
    }
}
