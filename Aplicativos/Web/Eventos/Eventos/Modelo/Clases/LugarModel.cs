using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class LugarModel
    {
        public string IDLUGAR { get; set; }
        public string NOMBRE { get; set; }
        public MunicipioModel MUNICIPIO { get; set; }

        public LugarModel()
        {
            IDLUGAR = "";
            NOMBRE = "";
            MUNICIPIO = new MunicipioModel();
        }

        public LugarModel(string id, string nombre, string municipio)
        {
            IDLUGAR = id;
            NOMBRE =nombre;
            MUNICIPIO = new MunicipioModel().Consultar(municipio);
        }

        public LugarModel(string nombre, string municipio)
        {
            NOMBRE = nombre;
            MUNICIPIO = new MunicipioModel().Consultar(municipio);
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(LugarModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public LugarModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new LugarModel(
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