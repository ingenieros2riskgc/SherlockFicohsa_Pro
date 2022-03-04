using System;

namespace ListasSarlaft.Formularios.Auditoria.Admin
{
    public partial class PruebadeReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.Refresh();
        }
    }
}