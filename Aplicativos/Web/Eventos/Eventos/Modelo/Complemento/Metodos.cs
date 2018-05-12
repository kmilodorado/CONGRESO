using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Complemento
{
    public class Metodos
    {
        public static string ordenarfecha(string fecha)
        {
            string[] fech = fecha.Split('/');
            return new DateTime(Convert.ToInt32(fech[2]), Convert.ToInt32(fech[0]), Convert.ToInt32(fech[1])).ToString("dd/MM/yyyy");
        }
    }
}