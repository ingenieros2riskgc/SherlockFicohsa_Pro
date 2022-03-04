using ListasSarlaft.Classes;
using Microsoft.Security.Application;
using System;
using System.Web.UI;

namespace ListasSarlaft.UserControls.Eventos
{
    public partial class ReporteConsolidado : System.Web.UI.UserControl
    {
        cCuenta cCuenta = new cCuenta();
        String IdFormulario = "5015";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cCuenta.permisosConsulta(IdFormulario) == "False")
            {
                Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
            }
            if (!Page.IsPostBack)
            {
                //ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = new Microsoft.Reporting.WebForms.ReportParameter[2];
                parameters[0] = new Microsoft.Reporting.WebForms.ReportParameter("FechaInicial", Sanitizer.GetSafeHtmlFragment(TextBox1.Text.Trim()));
                parameters[1] = new Microsoft.Reporting.WebForms.ReportParameter("FechaFinal", Sanitizer.GetSafeHtmlFragment(TextBox2.Text.Trim()));
                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.LocalReport.Refresh();
                RptEventos.Visible = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
    }
}