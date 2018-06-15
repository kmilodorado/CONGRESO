using ServicioEventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioEvento.Models
{
    public class ModeloMaster
    {
        /// <summary>
        /// Metodo para validar los usuario
        /// </summary>
        /// <param name="user">Usuario o nick</param>
        /// <param name="pass">Constraseña</param>
        /// <returns>bool</returns>
        public bool ValidarUsuario(string user, string pass,string tipo)
        {
            Datos consulta = new Datos();
            if (consulta.ConsultarDatos(string.Format("CALL `PR_USUARIO_VALIDAR_SERVICIO`('{0}', '{1}','{2}')", user, pass,tipo)).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo para gestionar la asistencia de los participantes
        /// </summary>
        /// <param name="codigo">identificación QR</param>
        /// <param name="evento">id del Evento asistido</param>
        /// <param name="hora">hora del ingreso</param>
        /// <returns></returns>
        public bool GestionarAsistencia(string codigo, string evento, string hora)
        {
           return new Datos().OperarDatos(string.Format("CALL `PR_ASISTENCIA_GESTIONAR`('{0}', '{1}', '{2}')`", codigo, evento, hora));
        }

        /// <summary>
        /// Metodo para gestionar la asistencia de los participantes
        /// </summary>
        /// <param name="codigo">identificación QR</param>
        /// <param name="evento">id del Evento asistido</param>
        /// <param name="hora">hora del ingreso</param>
        /// <returns></returns>
        public string GestionarRefrigerio(string codigo, string evento, string hora)
        {
            try
            {
                return new Datos().ConsultarDatos(string.Format("CALL `PR_REFRIGERIO_GESTIONAR`('{0}', '{1}', '{2}')`", codigo, evento, hora)).Rows[0]["MENSAJE"].ToString();
            }
            catch
            {
                return "Su petición de refrigerio esta fuera del horario establecido.";
            }
        }
    }
}