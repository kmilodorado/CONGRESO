using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class GeneroModel
    {
        public string IDGENERO { get; set; }
        public string DETALLE { get; set; }

        public GeneroModel()
        {
            IDGENERO = "";
            DETALLE = "";
        }

        public GeneroModel(string id, string detalle)
        {
            IDGENERO = id;
            DETALLE = detalle;
        }

        public GeneroModel(string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public GeneroModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_GENERO_CONSULTAR_ID`('"+id+"')");
            return new GeneroModel(
                consulta.Rows[0]["IDGENERO"].ToString(),
                consulta.Rows[0]["GENE_DETALLE"].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("CALL `PR_GENERO_CONSULTAR`()");
        }
    }
}