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
        public string IDMUNICIPIO { get; set; }
        public string MUNICIPIO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string PAIS { get; set; }

        public MunicipioModel()
        {
            IDMUNICIPIO = "";
            MUNICIPIO = "";
            DEPARTAMENTO = "";
            PAIS = "";
        }

        public MunicipioModel(string id,string municipio, string departamento, string pais)
        {
            IDMUNICIPIO = id;
            MUNICIPIO = municipio;
            DEPARTAMENTO = departamento;
            PAIS = pais;
        }

        public MunicipioModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_MUNICIPIO_CONSULTAR_ID`('" + id + "')");
            return new MunicipioModel(
                consulta.Rows[0]["IDMUNICIPIO"].ToString(),
                consulta.Rows[0]["MUNI_NOMBRE"].ToString(),
                consulta.Rows[0]["DEPA_NOMBRE"].ToString(),
                consulta.Rows[0]["PAIS_NOMBRE"].ToString());
        }

        public DataTable ConsultarDepartamento()
        {
            return new Datos().ConsultarDatos("CALL `PR_DEPARTAMENTO_CONSULTAR`()");
        }
        public DataTable ConsultarMunicipio(string departamento)
        {
            return new Datos().ConsultarDatos("CALL `PR_MUNICIPIO_CONSULTAR_DEP`('" + departamento + "')");
        }
    }
}