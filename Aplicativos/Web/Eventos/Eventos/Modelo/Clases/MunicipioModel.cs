using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class MunicipioModel
    {
        public string MUNICIPIO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string PAIS { get; set; }
        
        public MunicipioModel()
        {
            MUNICIPIO = "";
            DEPARTAMENTO = "";
            PAIS = "";
        }

        public MunicipioModel(string municipio, string departamento, string pais)
        {
            MUNICIPIO = municipio;
            DEPARTAMENTO = departamento;
            PAIS = pais;
        }

        public MunicipioModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new MunicipioModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString());
        }

        public DataTable ConsultarDepartamento()
        {
            return new Datos().ConsultarDatos("");
        }
        public DataTable ConsultarMunicipio(string departamento)
        {
            return new Datos().ConsultarDatos("");
        }
    }
}