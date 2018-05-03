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

        public AlertaModel(string id)
        {
            VISIBLE = true;
            switch (id)
            {
                case "1":
                    ESTILO = "alert alert-success";
                    MENSAJE = "Se ha registrado exitosamente";
                    break;
                case "2":
                    ESTILO = "alert alert-success";
                    MENSAJE = "Se ha modificado exitosamente";
                    break;
                case "3":
                    ESTILO = "alert alert-success";
                    MENSAJE = "Se ha eliminado exitosamente";
                    break;
                case "4":
                    ESTILO = "alert alert-danger";
                    MENSAJE = "Error en la operación, la acción realizado no cumple con los requerimiento.";
                    break;
                case "5":
                    ESTILO = "alert alert-danger";
                    MENSAJE = "Error, contraseñas no compatibles.";
                    break;
            }
        }

    }
}