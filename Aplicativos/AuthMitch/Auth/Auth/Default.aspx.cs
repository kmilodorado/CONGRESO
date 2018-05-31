using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auth
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList Arl = new ArrayList();
            Arl.Add("https://theobromaparalapaz.azurewebsites.net/");
            Arl.Add("http://registro.theobromaparalapaz.com.co/");
            Arl.Add("http://191.102.85.226/theobromaparalapaz/");
            Random rm = new Random();
            Response.Redirect(Arl[rm.Next(0,Arl.Count)].ToString()+ Convert.ToString(Request.QueryString["ValueDec"]));
        }
    }
}