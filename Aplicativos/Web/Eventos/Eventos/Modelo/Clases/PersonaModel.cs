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
        public string CELULAR { get; set; }
        public MunicipioModel MUNICIPIO { get; set; }
        public string DIRECCION { get; set; }
        public string INSTITUCION { get; set; }
        public Tipo_PersonaModel TIPO_PERSONA { get; set; }
        public FormacionModel FORMACION { get; set; }
        public OcupacionModel OCUPACION { get; set; }

        public PersonaModel()
        {
            IDPERSONA = "";
            IDENTIFICACION = "";
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel();
            NOMBRE = "";
            APELLIDO = "";
            CORREO = "";
            CELULAR = "";
            MUNICIPIO = new MunicipioModel();
            DIRECCION = "";
            INSTITUCION = "";
            TIPO_PERSONA = new Tipo_PersonaModel();
            FORMACION = new FormacionModel();
            OCUPACION = new OcupacionModel();
        }

        public PersonaModel(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_PERSONA_CONSULTAR_ID`('" + id + "')");
            IDPERSONA = id;
            IDENTIFICACION = consulta.Rows[0]["PERS_IDENTIFICACION"].ToString();
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel().Consultar(consulta.Rows[0]["PERS_IDTIPO_DOCUMENTO"].ToString());
            NOMBRE = consulta.Rows[0]["PERS_NOMBRE"].ToString();
            APELLIDO = consulta.Rows[0]["PERS_APELLIDO"].ToString();
            CORREO = consulta.Rows[0]["PERS_CORREO"].ToString();
            CELULAR = consulta.Rows[0]["PERS_CELULAR"].ToString();
            MUNICIPIO = new MunicipioModel().Consultar(consulta.Rows[0]["PERS_IDMUNICIPIO"].ToString());
            DIRECCION = consulta.Rows[0]["PERS_DIRECCION"].ToString();
            INSTITUCION = consulta.Rows[0]["PERS_INSTITUCION"].ToString();
            FORMACION = new FormacionModel().Consultar(consulta.Rows[0]["PERS_IDFORMACION"].ToString());
            OCUPACION = new OcupacionModel().Consultar(consulta.Rows[0]["PERS_IDOCUPACION"].ToString());
        }

        public PersonaModel(string idpersona, string identificacion, string tipo_documento, string nombre, string apellido, string correo, string celular, string municipio, string direccion, string institucion, string formacion, string ocupacion)
        {
            IDPERSONA = idpersona;
            IDENTIFICACION = identificacion;
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel().Consultar(tipo_documento);
            NOMBRE = nombre;
            APELLIDO = apellido;
            CORREO = correo;
            CELULAR = celular;
            MUNICIPIO = new MunicipioModel().Consultar(municipio);
            DIRECCION = direccion;
            INSTITUCION = institucion;
            FORMACION = new FormacionModel().Consultar(formacion);
            OCUPACION = new OcupacionModel().Consultar(ocupacion);
        }

        public PersonaModel(string identificacion, string tipo_documento, string nombre, string apellido, string correo, string celular, string municipio, string direccion, string institucion,  string formacion, string ocupacion)
        {
            IDENTIFICACION = identificacion;
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel().Consultar(tipo_documento);
            NOMBRE = nombre;
            APELLIDO = apellido;
            CORREO = correo;
            CELULAR = celular;
            MUNICIPIO = new MunicipioModel().Consultar(municipio);
            DIRECCION = direccion;
            INSTITUCION = institucion;
            FORMACION = new FormacionModel().Consultar(formacion);
            OCUPACION = new OcupacionModel().Consultar(ocupacion);
        }

        public string RegistrarPersona()
        {
            return new Datos().ConsultarDatos("CALL `PR_PERSONA_REGISTRAR`('"+IDENTIFICACION+ "', '" + TIPO_IDENTIFICACION.IDTIPO_IDENTIFICACION + "', '" + NOMBRE + "', '" + APELLIDO + "', '" + CORREO + "', '" + CELULAR + "', '" + MUNICIPIO.IDMUNICIPIO+ "', '" + DIRECCION+ "', '" + INSTITUCION+ "', '" + FORMACION.IDFORMACION + "', '" + OCUPACION.IDOCUPACION+ "')").Rows[0]["ID"].ToString();
        }

        public PersonaModel ConsultarPersona(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_PERSONA_CONSULTAR_ID`('" + id + "')");
            return new PersonaModel(
                consulta.Rows[0]["PERS_IDPERSONA"].ToString(),
                consulta.Rows[0]["PERS_IDENTIFICACION"].ToString(),
                consulta.Rows[0]["PERS_IDTIPO_DOCUMENTO"].ToString(),
                consulta.Rows[0]["PERS_NOMBRE"].ToString(),
                consulta.Rows[0]["PERS_APELLIDO"].ToString(),
                consulta.Rows[0]["PERS_CORREO"].ToString(),
                consulta.Rows[0]["PERS_CELULAR"].ToString(),
                consulta.Rows[0]["PERS_IDMUNICIPIO"].ToString(),
                consulta.Rows[0]["PERS_DIRECCION"].ToString(),
                consulta.Rows[0]["PERS_INSTITUCION"].ToString(),
                consulta.Rows[0]["PERS_IDFORMACION"].ToString(),
                consulta.Rows[0]["PERS_IDOCUPACION"].ToString());
        }

        public PersonaModel ConsultarIdentificacion(string identificacion)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_PERSONA_CONSULTAR_IDENTIFICACION`('"+identificacion+"')");
            return new PersonaModel(
               consulta.Rows[0]["PERS_IDPERSONA"].ToString(),
               consulta.Rows[0]["PERS_IDENTIFICACION"].ToString(),
               consulta.Rows[0]["PERS_IDTIPO_DOCUMENTO"].ToString(),
               consulta.Rows[0]["PERS_NOMBRE"].ToString(),
               consulta.Rows[0]["PERS_APELLIDO"].ToString(),
               consulta.Rows[0]["PERS_CORREO"].ToString(),
               consulta.Rows[0]["PERS_CELULAR"].ToString(),
               consulta.Rows[0]["PERS_IDMUNICIPIO"].ToString(),
               consulta.Rows[0]["PERS_DIRECCION"].ToString(),
               consulta.Rows[0]["PERS_INSTITUCION"].ToString(),
               consulta.Rows[0]["PERS_IDFORMACION"].ToString(),
               consulta.Rows[0]["PERS_IDOCUPACION"].ToString());
        }

        public DataTable ConsultarPersona()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}