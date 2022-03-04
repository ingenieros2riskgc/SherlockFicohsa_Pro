using ListasSarlaft.Classes;
using System;
using System.Web.UI;

namespace ListasSarlaft.Formularios.Auditoria.Reportes
{
    public partial class ReporteRecomendaciones : System.Web.UI.Page
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