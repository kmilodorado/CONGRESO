using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventos.Models.Complemento
{
    public class AlertaModel
    {
        public bool VISIBLE { get; set; }
        public string ESTILO { get; set; }
        public string MENSAJE { get; set; }
        public string AFIRMACION { get; set; }

        public AlertaModel(string id)
        {
            VISIBLE = true;
            switch (id)
            {
                case "1":
                    AFIRMACION ="Éxito";
                    ESTILO = "alert alert-success";
                    MENSAJE = "La acción realizada se ejecutó satisfactoriamente.";
                    break;
                case "2":
                    AFIRMACION ="Error";
                    ESTILO = "alert alert-danger";
                    MENSAJE = "La acción realizado no cumple con los requerimiento.";
                    break;
                case "3":
                    AFIRMACION = "Error";
                    ESTILO = "alert alert-danger";
                    MENSAJE = "En el envió del correo.";
                    break;
                case "4":
                    AFIRMACION = "Error";
                    ESTILO = "alert alert-danger";
                    MENSAJE = "Te falto por Seleccionar un campo";
                    break;

            }
        }

    }
}