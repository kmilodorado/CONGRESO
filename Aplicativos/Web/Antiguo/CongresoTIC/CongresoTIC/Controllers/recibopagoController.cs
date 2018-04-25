using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CongresoTIC.Controllers
{
    public class recibopagoController : ApiController
    {
        recibo_pago obj_recibo = new recibo_pago();
        
        
        public DataTable get_recibos()
        {
            return obj_recibo.get_recibopago();
        }

        public DataTable recibos_por_persona(usuario user)
        {
            return obj_recibo.recibos_por_persona(user);
        }


        [HttpPost]
        public bool insert_recibopago(recibo_pago obj)
        {
            if (obj_recibo.insert_recibopago(obj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
