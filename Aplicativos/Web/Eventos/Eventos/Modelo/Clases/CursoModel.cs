using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class CursoModel
    {
        public bool RegistrarSeleccion(string identificacion, string curso)
        {
            return new Datos().OperarDatos("CALL `PR_CURSO_SELECCIONAR`('"+identificacion+"', '"+curso+"')");
        }
        public DataTable ConsultarCurso(string dia)
        {
            return new Datos().ConsultarDatos("CALL `PR_CURSO_CONSULTAR_DIA`('"+dia+"')");
        }
    }
}