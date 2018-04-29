﻿using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class RolModel
    {
        public string IDROL { get; set; }
        public string DETALLE { get; set; }

        public RolModel()
        {
            IDROL = "";
            DETALLE = "";
        }

        public RolModel(string id, string detalle)
        {
            IDROL = id;
            DETALLE = detalle;
        }

        public RolModel (string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public RolModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new RolModel(consulta.Rows[0][""].ToString(), consulta.Rows[0][""].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}