using CongresoTIC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CongresoTIC.Models
{
    public class recibo_pago
    {
        Conexion conexion = new Conexion();

        public int idrecibo { get; set; }
        public string fecha { get; set; }
        public string partic { get; set; }
        public string ruta { get; set; }
        public string file { get; set; }
        public string referencia { get; set; }

        public recibo_pago() { }


        public DataTable get_recibopago()
        {
            string sql = "SELECT * FROM participacion p INNER JOIN usuario u ON p.FK_idUsuario = u.idUsuario INNER JOIN persona pe ON u.FK_idPersona=pe.idPersona INNER JOIN recibo_pago r ON r.FK_idParticipacion=p.idPartic INNER JOIN tipo_participante tp ON p.FK_idTipoPart=tp.idTipoPart ORDER BY p.Fecha DESC";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable get_recibopago_id(recibo_pago obj)
        {
            string sql = "SELECT * FROM recibo_pago r WHERE r.idRecibo='" + obj.idrecibo + "'";
            return conexion.EjecutarConsulta(sql, System.Data.CommandType.Text);
        }

        public DataTable recibos_por_persona(usuario user)
        {
            string sql = "SELECT * FROM recibo_pago rp INNER JOIN participacion p ON rp.FK_idParticipacion=p.idPartic AND p.FK_idUsuario='" + user.idusuario + "' INNER JOIN tipo_participante tp ON p.FK_idTipoPart=tp.idTipoPart";
            return conexion.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool insert_recibopago(recibo_pago obj)
        {
            string sql = "INSERT INTO recibo_pago (FechaRecibo, FK_idParticipacion, Ruta, File, Referencia) VALUES (NOW(),'{0}','{1}','{2}','{3}')";
            string[] ar = new string[1];
            ar[0] = string.Format(sql, obj.partic, obj.ruta, obj.file, obj.referencia);
            return conexion.RealizarTransaccion(ar);
        }

    }
}