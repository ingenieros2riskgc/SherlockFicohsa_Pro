using ListasSarlaft.Classes;
using System;
using System.Web.UI;

namespace ListasSarlaft.Formularios.Riesgos.Admin
{
    public partial class ParRieCausas : System.Web.UI.Page
    {
        private cCuenta cCuenta = new cCuenta();
        cParametrizacionRiesgos cParametrizacionRiesgos = new cParametrizacionRiesgos();

        protected override void OnLoad(EventArgs e)
        {

            //llama al metodo base

            base.OnLoad(e);

            //vuelve a recrear la etiqueta head de la master que tiene el script del resolve url, por lo que recrea de nuevo la ruta para esta pagina de los archivos

            Page.Header.DataBind();

        }

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