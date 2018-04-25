using System;
using CongresoTIC.AccesoDatos;
using System.Collections.Generic;
using System.Data;
namespace CongresoTIC.Models
{
    public class usuario
    {
        Conexion conexion = new Conexion();
        public int idusuario { get; set; }
        public string username { get; set; }
        public string contraseña { get; set; }
        public string estado { get; set; }
        public int fkl_idrol { get; set; }
        public long fk_idpersona { get; set; }

        public usuario() { }

        public usuario(int idusuario, string username, string contraseña, string estado, int fkl_idrol, long fk_idpersona)
        {
            this.idusuario = idusuario;
            this.username = username;
            this.contraseña = contraseña;
            this.estado = estado;
            this.fkl_idrol = fkl_idrol;
            this.fk_idpersona = fk_idpersona;
        }
        public DataTable get_usuario() { string sql = "SELECT * FROM usuario"; return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text); }
        public bool insert_usuario(usuario obj) { string sql = "INSERT INTO usuario (username,contraseña,estado,fkl_idrol,fk_idpersona) VALUES ({0},{1},{2},{3},{4})"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.username, obj.contraseña, obj.estado, obj.fkl_idrol, obj.fk_idpersona); return conexion.RealizarTransaccion(ar); }
        public bool update_usuario(usuario obj) { string sql = "UPDATE usuario SET username = {0}, contraseña = {1}, estado = {2}, fkl_idrol = {3}, fk_idpersona = {4} WHERE idusuario = {0}"; string[] ar = new string[1]; ar[0] = string.Format(sql, obj.username, obj.contraseña, obj.estado, obj.fkl_idrol, obj.fk_idpersona); return conexion.RealizarTransaccion(ar); }

        public DataTable validarUsuario(usuario user)
        {
            string sql = "SELECT * FROM usuario c INNER JOIN persona p ON c.username='" + user.username + "' AND c.FK_idPersona=p.idPersona AND c.Estado='T';";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable isLector(usuario user)
        {
            string sql = "SELECT * FROM logistica l WHERE l.FK_idUsuario='" + user.idusuario + "' AND l.Estado='T';";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable get_users()
        {
            string sql = "SELECT * FROM usuario;";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable get_id_user()
        {
            string sql = "SELECT MAX(u.idUsuario) as id FROM usuario u";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable consultar_persona(usuario user)
        {
            string sql = "SELECT *, CONCAT_WS(' ', Nombres, Apellidos) AS Nombre FROM usuario u INNER JOIN persona p ON u.idUsuario='" + user.idusuario + "' AND u.FK_idPersona=p.idPersona INNER JOIN rol r ON u.FK_idRol=r.idRol";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }
    }
}
