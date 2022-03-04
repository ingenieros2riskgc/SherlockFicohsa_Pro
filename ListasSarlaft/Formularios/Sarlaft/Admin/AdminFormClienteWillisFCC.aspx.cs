using ListasSarlaft.Classes;
using System;

namespace ListasSarlaft.Formularios.Admin
{
    public partial class AdminFormClienteWillisFCC : System.Web.UI.Page
    {
        private cCuenta cCuenta = new cCuenta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated == false)
                cCuenta.notAuthenticated();
        }
    }
}