using Eventos.AccesoDatos.Interface;
using Eventos.AccesoDatos.Conexion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Eventos.AccesoDatos.Clase
{
    public class Datos : Connection, IDatos
    {
        //Realizar operaciones en la base de datos
        public bool OperarDatos(string sql)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, Conectar());
                if (comando.ExecuteNonQuery() > 0)
                {
                    Desconector();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        //Realizar consulta en la base de datos.
        public DataTable ConsultarDatos(string sql)
        {
            DataTable datos = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, Conectar());
                da.Fill(datos);
                Desconector();
                return datos;
            }
            catch
            {
                return null;
            }
        }
    }
}
