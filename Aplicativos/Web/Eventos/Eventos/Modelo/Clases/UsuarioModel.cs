﻿using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class UsuarioModel:PersonaModel
    {
        public string IDUSUARIO { get; set; }
        public string USERNAME { get; set; }
        public string PASS { get; set; }
        public string ESTADO { get; set; }
        public RolModel ROL { get; set; }

        public UsuarioModel()
            :base()
        {
            IDUSUARIO = "";
            USERNAME = "";
            ESTADO = "";
            ROL = new RolModel();
        }

        public UsuarioModel(string id,string usuario,string estado,string rol,string idpersona)
            :base(idpersona)
        {
            IDUSUARIO = id;
            USERNAME = usuario;
            ESTADO = estado;
            ROL = new RolModel().Consultar(rol);
        }

        public bool RegistrarUsuario()
        {
            return new Datos().OperarDatos("");
        }

        public bool ModificarUsuario(UsuarioModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public UsuarioModel ConsultarUsuario(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new UsuarioModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(), 
                consulta.Rows[0][""].ToString());
        }

        public UsuarioModel ConsultarUser(string user)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new UsuarioModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString());
        }

        public UsuarioModel Validar(string user,string pass)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new UsuarioModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}