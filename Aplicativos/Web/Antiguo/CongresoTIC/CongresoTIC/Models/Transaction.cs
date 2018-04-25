using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CongresoTIC.Models
{
    public class Transaction
    {
        public string Procedure { get; set; }
        public Parametro[] Parameters { get; set; }

        public Transaction(string Procedure, Parametro[] Parameters)
        {
            this.Procedure = Procedure;
            this.Parameters = Parameters;
        }
    }
}