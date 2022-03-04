using ListasSarlaft.Classes;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListasSarlaft.UserControls.Gestion
{
    public partial class RptCuadorMandoIntegral : System.Web.UI.UserControl
    {
        cGestion cGestion = new cGestion();
        private void Mensaje(String Mensaje)
        {
            lblMsgBox.Text = Mensaje;
            mpeMsgBox.Show();
        }

        #region Propierties

        private DataTable infGrid;
        private DataTable InfoGrid
        {
            get
            {
                infGrid = (DataTable)ViewState["infGrid"];
                return infGrid;
            }
            set
            {
                infGrid = value;
                ViewState["infGrid"] = infGrid;
            }
        }

        private int idexRow;
        private int IdexRow
        {
            get
            {
                idexRow = (int)ViewState["idexRow"];
                return idexRow;
            }
            set
            {
                idexRow = value;
                ViewState["idexRow"] = idexRow;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadDDLPlanEstrategico();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox8.Text = DropDownList1.SelectedValue.ToString().Trim();
            ReportViewer1.LocalReport.Refresh();
        }
        private void loadDDLPlanEstrategico()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cGestion.PlanEstrategico();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    DropDownList1.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["Nombre"].ToString().Trim(), dtInfo.Rows[i]["CodigoPlan"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error al cargar planes de acción. " + ex.Message);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaObjEstrattegico();
        }
        private void CargaObjEstrattegico()
        {
            try
            {
                DataTable dtInfoObj = new DataTable();
                cGestionCMI cGestionCMI = new cGestionCMI();
                ddlObjetivos.Items.Clear();
                ddlObjetivos.Items.Add("---");
                ddlObjetivos.SelectedIndex = 0;
                dtInfoObj = cGestionCMI.ObjEstrategicoByCodPlan(DropDownList1.SelectedValue.ToString().Trim());
                for (int i = 0; i < dtInfoObj.Rows.Count; i++)
                {
                    ddlObjetivos.Items.Insert(i + 1, new ListItem(dtInfoObj.Rows[i]["Descripcion"].ToString().Trim(), dtInfoObj.Rows[i]["CodigoObjetivo"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error al cargar objetivos. " + ex.Message);
            }
        }
    }
}