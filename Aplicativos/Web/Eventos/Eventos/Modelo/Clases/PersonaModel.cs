using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class PersonaModel
    {
        public string IDPERSONA { get; set; }
        public string IDENTIFICACION { get; set; }
        public Tipo_IdentificacionModel TIPO_IDENTIFICACION { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CORREO { get; set; }
        public string INSTITUCION { get; set; }
        public MunicipioModel MUNICIPIO { get; set; }
        public Tipo_PersonaModel TIPO_PERSONA { get; set; }

        public PersonaModel()
        {
            IDPERSONA = "";
            IDENTIFICACION = "";
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel();
            NOMBRE = "";
            APELLIDO = "";
            CORREO = "";
            INSTITUCION = "";
            MUNICIPIO = new MunicipioModel();
            TIPO_PERSONA = new Tipo_PersonaModel();
        }

        public PersonaModel(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            IDPERSONA = id;
            IDENTIFICACION = consulta.Rows[0][""].ToString();
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel().Consultar(consulta.Rows[0][""].ToString());
            NOMBRE = consulta.Rows[0][""].ToString();
            APELLIDO = consulta.Rows[0][""].ToString();
            CORREO = consulta.Rows[0][""].ToString();
            INSTITUCION = consulta.Rows[0][""].ToString();
            MUNICIPIO = new MunicipioModel().Consultar(consulta.Rows[0][""].ToString());
            TIPO_PERSONA = new Tipo_PersonaModel().Consultar(consulta.Rows[0][""].ToString());
        }

        public PersonaModel(string idpersona, string identificacion, string tipo_documento, string nombre, string apellido, string correo, string institucion, string municipio, string tipo_persona)
        {
            IDPERSONA = idpersona;
            IDENTIFICACION = identificacion;
            TIPO_IDENTIFICACION =new Tipo_IdentificacionModel().Consultar(tipo_documento);
            NOMBRE = nombre;
            APELLIDO = apellido;
            CORREO = correo;
            INSTITUCION = institucion;
            MUNICIPIO = new MunicipioModel().Consultar(municipio);
            TIPO_PERSONA = new Tipo_PersonaModel().Consultar(tipo_persona);
        }

        public PersonaModel(string identificacion, string tipo_documento, string nombre, string apellido, string correo, string institucion, string municipio, string tipo_persona)
        {
            IDENTIFICACION = identificacion;
            TIPO_IDENTIFICACION.IDTIPO_IDENTIFICACION = tipo_documento;
            NOMBRE = nombre;
            APELLIDO = apellido;
            CORREO = correo;
            INSTITUCION = institucion;
            MUNICIPIO.MUNICIPIO = municipio;
            TIPO_PERSONA.IDTIPO_PERSONA = tipo_persona;
        }

        public bool RegistrarPersona()
        {
            return new Datos().OperarDatos("");
        }

        public PersonaModel ConsultarPersona(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new PersonaModel(
                consulta.Rows[0][""].ToString(), 
                consulta.Rows[0][""].ToString(), 
                consulta.Rows[0][""].ToString(), 
                consulta.Rows[0][""].ToString(), 
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(), 
                consulta.Rows[0][""].ToString());
        }

        public PersonaModel ConsultarIdentificacion(string identificacion)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new PersonaModel(
                 consulta.Rows[0][""].ToString(),
                 consulta.Rows[0][""].ToString(),
                 consulta.Rows[0][""].ToString(),
                 consulta.Rows[0][""].ToString(),
                 consulta.Rows[0][""].ToString(),
                 consulta.Rows[0][""].ToString(),
                 consulta.Rows[0][""].ToString(),
                 consulta.Rows[0][""].ToString());
        }

        public DataTable ConsultarPersona()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}