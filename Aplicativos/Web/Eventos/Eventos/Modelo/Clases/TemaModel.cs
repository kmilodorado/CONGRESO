using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class TemaModel
    {
        public string IDTEMA { get; set; }
        public string NOMBRE { get; set; }
        public string PARTICIPANTE { get; set; }
        public string URL { get; set; }
        public string ESTADO { get; set; }

        public TemaModel()
        {
            IDTEMA = "";
            NOMBRE = "";
            PARTICIPANTE = "";
            URL = "";
            ESTADO = "";
        }

        public TemaModel(string id, string nombre, string participante, string archivo, string estado)
        {
            IDTEMA = id;
            NOMBRE = nombre;
            PARTICIPANTE = participante;
            URL = archivo;
            ESTADO = estado;
        }
        public TemaModel(string nombre, string participante, string archivo, string estado)
        {
            NOMBRE = nombre;
            PARTICIPANTE = participante;
            URL = archivo;
            ESTADO = estado;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(TemaModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public DataTable ConsultarTemas(string evento)
        {
            return new Datos().ConsultarDatos("");
        }

        public DataTable ConsultarParticipantes(string participante)
        {
            return new Datos().ConsultarDatos("");
        }
    }
}