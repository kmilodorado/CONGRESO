using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CongresoTIC.Models
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public Object Value { get; set; }

        public Parametro(string Nombre, Object Value)
        {
            this.Nombre = Nombre;
            this.Value = Value;
        }
    }
}