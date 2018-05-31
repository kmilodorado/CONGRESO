﻿using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class Tipo_ParticipanteModel
    {
        public string IDTIPO_PARTICIPANTE { get; set; }
        public string DETALLE { get; set; }

        public Tipo_ParticipanteModel()
        {
            IDTIPO_PARTICIPANTE = "";
            DETALLE = "";
        }

        public Tipo_ParticipanteModel(string id, string detalle)
        {
            IDTIPO_PARTICIPANTE = id;
            DETALLE = detalle;
        }
        public Tipo_ParticipanteModel( string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public Tipo_ParticipanteModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_TIPO_PARTICIPANTE_CONSULTAR_ID`('"+id+"');");
            return new Tipo_ParticipanteModel(consulta.Rows[0]["IDTIPO_PARTICIPANTE"].ToString(), consulta.Rows[0]["TIPO_DETALLE"].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("CALL `PR_TIPO_PARTICIPANTE_CONSULTAR_G`();");
        }
        public DataTable ConsultarTodos()
        {
            return new Datos().ConsultarDatos("CALL `PR_TIPO_PARTICIPANTE_CONSULTAR_TODOS`();");
        }
    }
}