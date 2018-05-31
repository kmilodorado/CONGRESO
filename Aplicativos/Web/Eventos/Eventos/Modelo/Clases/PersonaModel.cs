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
        public GeneroModel GENERO { get; set; }
        public DateTime FECHA_NAC { get; set; }
        public string PAIS_NAC { get; set; }
        public string CORREO { get; set; }
        public string CELULAR { get; set; }
        public MunicipioModel MUNICIPIO_RES { get; set; }
        public string DIRECCION { get; set; }
        public string INSTITUCION { get; set; }
        public FormacionModel FORMACION { get; set; }
        public OcupacionModel OCUPACION { get; set; }
        public EspecialModel CONDICION { get; set; }
        public CircunscripcionModel CIRCUNSCRIPCION { get; set; }

        public PersonaModel()
        {
            IDPERSONA = "";
            IDENTIFICACION = "";
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel();
            NOMBRE = "";
            APELLIDO = "";
            GENERO = new GeneroModel();
            FECHA_NAC = new DateTime();
            PAIS_NAC = "";
            CORREO = "";
            CELULAR = "";
            MUNICIPIO_RES = new MunicipioModel();
            DIRECCION = "";
            INSTITUCION = "";
            FORMACION = new FormacionModel();
            OCUPACION = new OcupacionModel();
            CONDICION = new EspecialModel();
            CIRCUNSCRIPCION = new CircunscripcionModel();
        }

        public PersonaModel(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_PERSONA_CONSULTAR_ID`('" + id + "')");
            IDPERSONA = id;
            IDENTIFICACION = consulta.Rows[0]["PERS_IDENTIFICACION"].ToString();
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel().Consultar(consulta.Rows[0]["PERS_IDTIPO_DOCUMENTO"].ToString());
            NOMBRE = consulta.Rows[0]["PERS_NOMBRES"].ToString();
            APELLIDO = consulta.Rows[0]["PERS_APELLIDOS"].ToString();
            GENERO = new GeneroModel().Consultar(consulta.Rows[0]["PERS_IDGENERO"].ToString());
            FECHA_NAC = DateTime.Parse(consulta.Rows[0]["PERS_FECHA_NAC"].ToString());
            PAIS_NAC = consulta.Rows[0]["PERS_PAIS_NAC"].ToString();
            CORREO = consulta.Rows[0]["PERS_CORREO"].ToString();
            CELULAR = consulta.Rows[0]["PERS_CELULAR"].ToString();
            MUNICIPIO_RES = new MunicipioModel().Consultar(consulta.Rows[0]["PERS_IDMUNICIPIO"].ToString());
            DIRECCION = consulta.Rows[0]["PERS_DIRECCION"].ToString();
            INSTITUCION = consulta.Rows[0]["PERS_INSTITUCION"].ToString();
            FORMACION = new FormacionModel().Consultar(consulta.Rows[0]["PERS_IDFORMACION"].ToString());
            OCUPACION = new OcupacionModel().Consultar(consulta.Rows[0]["PERS_IDOCUPACION"].ToString());
            CONDICION = new EspecialModel().Consultar(consulta.Rows[0]["PERS_IDCOND_ESPECIAL"].ToString());
            CIRCUNSCRIPCION = new CircunscripcionModel().Consultar(consulta.Rows[0]["PERS_IDCIRCUNSCRIPCION"].ToString());
        }

        public PersonaModel(string idpersona, string identificacion, string tipo_documento, string nombre, string apellido, string genero,string fecha,string pais_nac, string correo, string celular, string municipio, string direccion, string institucion, string formacion, string ocupacion,string especial,string circunscripcion)
        {
            IDPERSONA = idpersona;
            IDENTIFICACION = identificacion;
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel().Consultar(tipo_documento);
            NOMBRE = nombre;
            APELLIDO = apellido;
            GENERO = new GeneroModel().Consultar(genero);
            FECHA_NAC = DateTime.Parse(fecha);
            PAIS_NAC = pais_nac;
            CORREO = correo;
            CELULAR = celular;
            MUNICIPIO_RES = new MunicipioModel().Consultar(municipio);
            DIRECCION = direccion;
            INSTITUCION = institucion;
            FORMACION = new FormacionModel().Consultar(formacion);
            OCUPACION = new OcupacionModel().Consultar(ocupacion);
            CONDICION = new EspecialModel().Consultar(especial);
            CIRCUNSCRIPCION = new CircunscripcionModel().Consultar(circunscripcion);
        }

        public PersonaModel(string identificacion, string tipo_documento, string nombre, string apellido, string genero, string fecha, string pais_nac, string correo, string celular, string municipio, string direccion, string institucion, string formacion, string ocupacion, string especial, string circunscripcion)
        {
            IDENTIFICACION = identificacion;
            TIPO_IDENTIFICACION = new Tipo_IdentificacionModel().Consultar(tipo_documento);
            NOMBRE = nombre;
            APELLIDO = apellido;
            GENERO = new GeneroModel().Consultar(genero);
            FECHA_NAC = DateTime.Parse(fecha);
            PAIS_NAC = pais_nac;
            CORREO = correo;
            CELULAR = celular;
            MUNICIPIO_RES = new MunicipioModel().Consultar(municipio);
            DIRECCION = direccion;
            INSTITUCION = institucion;
            FORMACION = new FormacionModel().Consultar(formacion);
            OCUPACION = new OcupacionModel().Consultar(ocupacion);
            CONDICION = new EspecialModel().Consultar(especial);
            CIRCUNSCRIPCION = new CircunscripcionModel().Consultar(circunscripcion);
        }

        public string RegistrarPersona()
        {
            return new Datos().ConsultarDatos("CALL `PR_PERSONA_REGISTRAR`('" + IDENTIFICACION + "', '" + TIPO_IDENTIFICACION.IDTIPO_IDENTIFICACION + "', '" + NOMBRE + "', '" + APELLIDO + "', '" + CORREO + "', '" + CELULAR + "', '" + MUNICIPIO_RES.IDMUNICIPIO + "', '" + DIRECCION + "', '" + INSTITUCION + "', '" + FORMACION.IDFORMACION + "', '" + OCUPACION.IDOCUPACION + "')").Rows[0]["ID"].ToString();
        }

        public PersonaModel ConsultarPersona(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_PERSONA_CONSULTAR_ID`('" + id + "')");
            return new PersonaModel(
                consulta.Rows[0]["IDPERSONA"].ToString(),
                consulta.Rows[0]["PERS_IDENTIFICACION"].ToString(),
                consulta.Rows[0]["PERS_IDTIPO_DOCUMENTO"].ToString(),
                consulta.Rows[0]["PERS_NOMBRES"].ToString(),
                consulta.Rows[0]["PERS_APELLIDOS"].ToString(),
                consulta.Rows[0]["PERS_IDGENERO"].ToString(),
                consulta.Rows[0]["PERS_FECHA_NAC"].ToString(),
                consulta.Rows[0]["PERS_PAIS_NAC"].ToString(),
                consulta.Rows[0]["PERS_CORREO"].ToString(),
                consulta.Rows[0]["PERS_CELULAR"].ToString(),
                consulta.Rows[0]["PERS_IDMUNICIPIO"].ToString(),
                consulta.Rows[0]["PERS_DIRECCION"].ToString(),
                consulta.Rows[0]["PERS_INSTITUCION"].ToString(),
                consulta.Rows[0]["PERS_IDFORMACION"].ToString(),
                consulta.Rows[0]["PERS_IDOCUPACION"].ToString(),
                consulta.Rows[0]["PERS_IDCOND_ESPECIAL"].ToString(),
                consulta.Rows[0]["PERS_IDCIRCUNSCRIPCION"].ToString());
        }

        public PersonaModel ConsultarIdentificacion(string identificacion)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_PERSONA_CONSULTAR_IDENTIFICACION`('" + identificacion + "')");
            return new PersonaModel(
                consulta.Rows[0]["IDPERSONA"].ToString(),
                consulta.Rows[0]["PERS_IDENTIFICACION"].ToString(),
                consulta.Rows[0]["PERS_IDTIPO_DOCUMENTO"].ToString(),
                consulta.Rows[0]["PERS_NOMBRES"].ToString(),
                consulta.Rows[0]["PERS_APELLIDOS"].ToString(),
                consulta.Rows[0]["PERS_IDGENERO"].ToString(),
                consulta.Rows[0]["PERS_FECHA_NAC"].ToString(),
                consulta.Rows[0]["PERS_PAIS_NAC"].ToString(),
                consulta.Rows[0]["PERS_CORREO"].ToString(),
                consulta.Rows[0]["PERS_CELULAR"].ToString(),
                consulta.Rows[0]["PERS_IDMUNICIPIO"].ToString(),
                consulta.Rows[0]["PERS_DIRECCION"].ToString(),
                consulta.Rows[0]["PERS_INSTITUCION"].ToString(),
                consulta.Rows[0]["PERS_IDFORMACION"].ToString(),
                consulta.Rows[0]["PERS_IDOCUPACION"].ToString(),
                consulta.Rows[0]["PERS_IDCOND_ESPECIAL"].ToString(),
                consulta.Rows[0]["PERS_IDCIRCUNSCRIPCION"].ToString());
        }

        public PersonaModel ConsultarCorreo(string Correo)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_PERSONA_CONSULTAR_CORREO`('" + Correo + "')");
            return new PersonaModel(
                consulta.Rows[0]["IDPERSONA"].ToString(),
                consulta.Rows[0]["PERS_IDENTIFICACION"].ToString(),
                consulta.Rows[0]["PERS_IDTIPO_DOCUMENTO"].ToString(),
                consulta.Rows[0]["PERS_NOMBRES"].ToString(),
                consulta.Rows[0]["PERS_APELLIDOS"].ToString(),
                consulta.Rows[0]["PERS_IDGENERO"].ToString(),
                consulta.Rows[0]["PERS_FECHA_NAC"].ToString(),
                consulta.Rows[0]["PERS_PAIS_NAC"].ToString(),
                consulta.Rows[0]["PERS_CORREO"].ToString(),
                consulta.Rows[0]["PERS_CELULAR"].ToString(),
                consulta.Rows[0]["PERS_IDMUNICIPIO"].ToString(),
                consulta.Rows[0]["PERS_DIRECCION"].ToString(),
                consulta.Rows[0]["PERS_INSTITUCION"].ToString(),
                consulta.Rows[0]["PERS_IDFORMACION"].ToString(),
                consulta.Rows[0]["PERS_IDOCUPACION"].ToString(),
                consulta.Rows[0]["PERS_IDCOND_ESPECIAL"].ToString(),
                consulta.Rows[0]["PERS_IDCIRCUNSCRIPCION"].ToString());
        }

        public DataTable ConsultarPersona()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}