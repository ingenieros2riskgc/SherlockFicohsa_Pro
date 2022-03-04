using ListasSarlaft.Classes;
using System;

namespace ListasSarlaft.UserControls.Notificaciones
{
    public partial class NotificacionesTest : System.Web.UI.UserControl
    {
        string IdFormulario = "2002";
        cCuenta cCuenta = new cCuenta();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["IdUsuario"].ToString().Trim()))
                {
                    Response.Redirect("~/Formularios/Sitio/Login.aspx", false);
                }
                else
                {
                    if (cCuenta.permisosConsulta(IdFormulario) == "False")
                        Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1", false);
                    else
                    {

                    }
                }
            }
            catch
            {
                Response.Redirect("~/Formularios/Sitio/Login.aspx", false);
            }
        }
    }
}