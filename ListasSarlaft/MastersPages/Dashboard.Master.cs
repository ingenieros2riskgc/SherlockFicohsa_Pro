using ListasSarlaft.Classes;
using System;
using System.Web.UI;

namespace ListasSarlaft.MastersPages
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["NombreUsuario"] != null && Session["Usuario"] != null)
                {
                    this.LblNombreDato.Text = Session["NombreUsuario"].ToString().Trim();
                    this.LblUsuarioDato.Text = Session["Usuario"].ToString().Trim();
                    this.LblNombreTime.Text = System.DateTime.Now.ToString().Trim();
                }
                /*else
                {
                    Response.Redirect("~/Formularios/Sitio/Login.aspx");
                }*/
            }
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            cCuenta cCuenta = new cCuenta();
            Session.Abandon();
            cCuenta.notAuthenticated();
            Response.Redirect("~/Formularios/Sitio/NuevoLogin.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            cCuenta cCuenta = new cCuenta();
            Session.Abandon();
            cCuenta.notAuthenticated();
            Response.Redirect("~/Formularios/Sitio/NuevoLogin.aspx");
        }
    }
}