using ListasSarlaft.Classes;
using System;
using System.Web.UI;

namespace ListasSarlaft.Formularios.Gestion
{
    public partial class VisionEmpresa : System.Web.UI.Page
    {
        private cCuenta cCuenta = new cCuenta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
            if (User.Identity.IsAuthenticated == false)
            {
                cCuenta.notAuthenticated();
            }
        }
    }
}