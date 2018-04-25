using CongresoTIC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC.Views.Home
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        //persona obj = new persona();
        item per = new item();
        usuario user = new usuario();
        public ArrayList NameP = new ArrayList();
        public ArrayList ImgP = new ArrayList();
        public ArrayList IdP = new ArrayList();
        public ArrayList NameS = new ArrayList();
        public ArrayList RutaS = new ArrayList();
        public ArrayList IdS = new ArrayList();
        subitem sub = new subitem();
        rol rol = new rol();
        int permiso = 0;
        string permisos = "";

        public void clearListP()
        {
            NameP.Clear();
            ImgP.Clear();
            IdP.Clear();
        }
        public void clearListS()
        {
            NameS.Clear();
            RutaS.Clear();
            IdS.Clear();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString().Equals("T"))
                {
                    this.clearListP();
                    this.clearListS();

                    //user.idusuario = Convert.ToInt32(Request.Cookies["idUsuario"].Value);
                    user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());

                    DataTable datos_cuenta = user.consultar_persona(user);
                    DataRow data = datos_cuenta.Rows[0];
                    rol.idrol = Convert.ToInt32(data["FK_idRol"].ToString());
                    Session["Rol"] = data["FK_idRol"].ToString();
                    TUser.Text = data["Nombres"].ToString() + " " + data["Apellidos"].ToString();
                    LRol.Text = data["NombreRol"].ToString();


                    DataTable dt = per.ConsultarPermisos(rol), dt2;
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            fila = dt.Rows[i];
                            NameP.Add(fila["NombreItem"].ToString());
                            IdP.Add(fila["idItem"].ToString());
                            ImgP.Add(fila["Icon"].ToString());
                            permiso = Convert.ToInt32(fila["idItem"].ToString());
                            per.iditem = permiso;
                            dt2 = sub.ConsultarSubpermisos(rol, per);
                            //menuPrimary.Items.Add(P);
                            if (dt2.Rows.Count > 0)
                            {
                                DataRow fila2;

                                for (int j = 0; j < dt2.Rows.Count; j++)
                                {
                                    fila2 = dt2.Rows[j];
                                    permisos += fila2["idSubitem"].ToString() + ",";
                                    NameS.Add(fila2["NombreSubitem"].ToString());
                                    RutaS.Add(fila2["URL"].ToString() + "?id=" + fila2["idSubitem"].ToString());
                                    IdS.Add(fila2["FK_idItem"].ToString());
                                    //menuPrimary.Items[i].ChildItems.Add(S);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("../../Login.aspx");
            }
        }

        protected void MostrarMensaje(string Mensaje, Page Pagina)
        {
            string scriptStr = "alert(\'" + Mensaje + "\');";
            ScriptManager.RegisterStartupScript(Pagina, Pagina.GetType(), "msgBox", scriptStr, true);
        }

        protected void Salir_Click(object sender, EventArgs e)
        {
            Session["Estado"] = "F";
            Session.Clear();
            Session.Abandon();
            Response.Redirect("../../Login.aspx");
        }
    }
}