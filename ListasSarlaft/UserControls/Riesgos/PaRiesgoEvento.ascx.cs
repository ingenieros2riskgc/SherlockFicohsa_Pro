using ClosedXML.Excel;
using ListasSarlaft.Classes;
using ListasSarlaft.Classes.BLL.Riesgos.Parametrizacion;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListasSarlaft.UserControls.Riesgos
{
    public partial class PaRiesgoEvento : System.Web.UI.UserControl
    {
        #region Globales
        private string IdFormulario = "11009";
        cControl cControl = new cControl();
        //private string PestanaControl = "5004";
        cParametrizacionRiesgos cParametrizacionRiesgos = new cParametrizacionRiesgos();
        private cCuenta cCuenta = new cCuenta();
        private string MensajeError = string.Empty;
        private static int LastInsertIdCE;
        private clsDTOPlanes objPlanes = new clsDTOPlanes();
        private List<clsDTOPlanes> listaPlanes = new List<clsDTOPlanes>();
        private clsBLLPlanes cPlanes = new clsBLLPlanes();
        private cRiesgo cRiesgo = new cRiesgo();
        private cEvento Eventos = new cEvento();
        #endregion Globales       

        #region SetVariables
        private DataTable todosPlanes;
        private DataTable dtCumplimiento;
        private DataTable dtSeguimiento;
        private int pagIndexPlanes;
        private int pagIndexInfoGridRiesgos;
        private int rowGridGridRiesgosAsociados;
        private int pagIndexInfoGridEventosAsociados;
        private int pagIndexInfoGridEventos;
        private int pagIndexCumplimiento;
        private int pagIndexSeguimiento;


        private int idGestion;
        private int IdGestion
        {
            get
            {
                idGestion = (int)ViewState["idGestion"];
                return idGestion;
            }
            set
            {
                idGestion = value;
                ViewState["idGestion"] = idGestion;
            }
        }


        private int metagestion;
        private int MetaGestion
        {
            get
            {
                metagestion = (int)ViewState["metagestion"];
                return metagestion;
            }
            set
            {
                metagestion = value;
                ViewState["metagestion"] = metagestion;
            }
        }

        private DateTime fechaRevision;
        private DateTime FechaRevision
        {
            get
            {
                fechaRevision = (DateTime)ViewState["fechaRevision"];
                return fechaRevision;
            }
            set
            {
                fechaRevision = value;
                ViewState["fechaRevision"] = fechaRevision;
            }
        }

        private int rowGridPlanes;
        private int RowGridPlanes
        {
            get
            {
                rowGridPlanes = (int)ViewState["rowGridPlanes"];
                return rowGridPlanes;
            }
            set
            {
                rowGridPlanes = value;
                ViewState["rowGridRiesgos"] = rowGridPlanes;
            }
        }

        private int rowGridRiesgos;
        private int RowGridRiesgos
        {
            get
            {
                rowGridRiesgos = (int)ViewState["rowGridRiesgos"];
                return rowGridRiesgos;
            }
            set
            {
                rowGridRiesgos = value;
                ViewState["rowGridRiesgos"] = rowGridRiesgos;
            }
        }

        private int rowGridEventos;
        private int RowGridEventos
        {
            get
            {
                rowGridEventos = (int)ViewState["rowGridEventos"];
                return rowGridEventos;
            }
            set
            {
                rowGridEventos = value;
                ViewState["rowGridEventos"] = rowGridEventos;
            }
        }

        private int PagIndexPlanes
        {
            get
            {
                pagIndexPlanes = (int)ViewState["pagIndexPlanes"];
                return pagIndexPlanes;
            }
            set
            {
                pagIndexPlanes = value;
                ViewState["pagIndexPlanes"] = pagIndexPlanes;
            }
        }
        private int PagIndexInfoGridRiesgos
        {
            get
            {
                pagIndexInfoGridRiesgos = (int)ViewState["pagIndexInfoGridRiesgos"];
                return pagIndexInfoGridRiesgos;
            }
            set
            {
                pagIndexInfoGridRiesgos = value;
                ViewState["pagIndexInfoGridRiesgos"] = pagIndexInfoGridRiesgos;
            }
        }

        private int PagIndexInfoGridEventos
        {
            get
            {
                pagIndexInfoGridEventos = (int)ViewState["pagIndexInfoGridEventos"];
                return pagIndexInfoGridEventos;
            }
            set
            {
                pagIndexInfoGridEventos = value;
                ViewState["pagIndexInfoGridEventos"] = pagIndexInfoGridEventos;
            }
        }

        private int RowGridGridRiesgosAsociados
        {
            get
            {
                rowGridGridRiesgosAsociados = (int)ViewState["rowGridGridRiesgosAsociados"];
                return rowGridGridRiesgosAsociados;
            }
            set

            {
                rowGridGridRiesgosAsociados = value;
                ViewState["rowGridGridRiesgosAsociados"] = rowGridGridRiesgosAsociados;
            }
        }

        private int rowGridGridCumplimiento;
        private int RowGridCumplimiento
        {
            get
            {
                rowGridGridCumplimiento = (int)ViewState["rowGridGridCumplimiento"];
                return rowGridGridCumplimiento;
            }
            set

            {
                rowGridGridCumplimiento = value;
                ViewState["rowGridGridCumplimiento"] = rowGridGridCumplimiento;
            }
        }

        private int PagIndexInfoGridEventosAsociados
        {
            get
            {
                pagIndexInfoGridEventosAsociados = (int)ViewState["pagIndexInfoGridEventosAsociados"];
                return pagIndexInfoGridEventosAsociados;
            }
            set

            {
                pagIndexInfoGridEventosAsociados = value;
                ViewState["pagIndexInfoGridEventosAsociados"] = pagIndexInfoGridEventosAsociados;
            }
        }

        private DataTable TodosPlanes
        {
            get
            {
                todosPlanes = (DataTable)ViewState["infoGridTodosPlanes"];
                return todosPlanes;
            }
            set
            {
                todosPlanes = value;
                ViewState["infoGridTodosPlanes"] = todosPlanes;
            }
        }
        private DataTable DtCumplimiento
        {
            get
            {
                dtCumplimiento = (DataTable)ViewState["infoGridCumplimiento"];
                return dtCumplimiento;
            }
            set
            {
                dtCumplimiento = value;
                ViewState["infoGridCumplimiento"] = todosPlanes;
            }
        }

        private DataTable infoGridRiesgos;
        private DataTable InfoGridRiesgos
        {
            get
            {
                infoGridRiesgos = (DataTable)ViewState["infoGridRiesgos"];
                return infoGridRiesgos;
            }
            set
            {
                infoGridRiesgos = value;
                ViewState["infoGridRiesgos"] = infoGridRiesgos;
            }
        }

        private DataTable infoGridRiesgosAsociados;
        private DataTable InfoGridRiesgosAsociados
        {
            get
            {
                infoGridRiesgosAsociados = (DataTable)ViewState["infoGridRiesgosAsociados"];
                return infoGridRiesgosAsociados;
            }
            set
            {
                infoGridRiesgosAsociados = value;
                ViewState["infoGridRiesgosAsociados"] = infoGridRiesgosAsociados;
            }
        }

        private DataTable infoGridEventosAsociados;
        private DataTable InfoGridEventosAsociados
        {
            get
            {
                infoGridEventosAsociados = (DataTable)ViewState["infoGridEventosAsociados"];
                return infoGridEventosAsociados;
            }
            set
            {
                infoGridEventosAsociados = value;
                ViewState["infoGridEventosAsociados"] = infoGridEventosAsociados;
            }
        }

        private DataTable infoGridEventos;
        private DataTable InfoGridEventos
        {
            get
            {
                infoGridEventos = (DataTable)ViewState["infoGridEventos"];
                return infoGridEventos;
            }
            set
            {
                infoGridEventos = value;
                ViewState["infoGridEventos"] = infoGridEventos;
            }
        }

        private DataTable infoGridCumplimiento;
        private DataTable InfoGridCumplimiento
        {
            get
            {
                infoGridCumplimiento = (DataTable)ViewState["infoGridCumplimiento"];
                return infoGridCumplimiento;
            }
            set
            {
                infoGridCumplimiento = value;
                ViewState["infoGridCumplimiento"] = infoGridCumplimiento;
            }
        }

        private DataTable infoGridSeguimiento;
        private DataTable InfoGridSeguimiento
        {
            get
            {
                infoGridSeguimiento = (DataTable)ViewState["infoGridSeguimiento"];
                return infoGridSeguimiento;
            }
            set
            {
                infoGridSeguimiento = value;
                ViewState["infoGridSeguimiento"] = infoGridSeguimiento;
            }
        }

        private DataTable infoGridArchivoPlanes;
        private DataTable InfoGridArchivoPlanes
        {
            get
            {
                infoGridArchivoPlanes = (DataTable)ViewState["infoGridArchivoPlanes"];
                return infoGridArchivoPlanes;
            }
            set
            {
                infoGridArchivoPlanes = value;
                ViewState["infoGridArchivoPlanes"] = infoGridArchivoPlanes;
            }
        }

        private DataTable infoGridJustificacion;
        private DataTable InfoGridJustificacion
        {
            get
            {
                infoGridJustificacion = (DataTable)ViewState["infoGridJustificacion"];
                return infoGridJustificacion;
            }
            set
            {
                infoGridJustificacion = value;
                ViewState["infoGridJustificacion"] = infoGridJustificacion;
            }
        }

        private int rowGridArchivoPlan;
        private int RowGridArchivoPlan
        {
            get
            {
                rowGridArchivoPlan = (int)ViewState["rowGridArchivoPlan"];
                return rowGridArchivoPlan;
            }
            set
            {
                rowGridArchivoPlan = value;
                ViewState["rowGridArchivoPlan"] = rowGridArchivoPlan;
            }
        }
        #endregion SetVariables

        #region ConsultaRapida
        private DataTable GetTreeViewData()
        {
            string selectCommand = "SELECT Parametrizacion.JerarquiaOrganizacional.IdHijo, Parametrizacion.JerarquiaOrganizacional.IdPadre, Parametrizacion.JerarquiaOrganizacional.NombreHijo, Parametrizacion.DetalleJerarquiaOrg.NombreResponsable, Parametrizacion.DetalleJerarquiaOrg.CorreoResponsable FROM Parametrizacion.JerarquiaOrganizacional LEFT JOIN Parametrizacion.DetalleJerarquiaOrg ON Parametrizacion.JerarquiaOrganizacional.idHijo = Parametrizacion.DetalleJerarquiaOrg.idHijo";
            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable ConsultaPlanesFiltro(string CodigoPlan, string NombrePlan)
        {
            string condicion = string.Empty;

            if (!string.IsNullOrEmpty(CodigoPlan))
            {
                if (!string.IsNullOrEmpty(NombrePlan))
                {
                    condicion = " WHERE CodigoPlan LIKE ('%" + CodigoPlan + "%') AND  NombrePlan LIKE ('%" + NombrePlan + "%')";
                }
                else
                {
                    condicion = " WHERE CodigoPlan LIKE ('%" + CodigoPlan + "%')";
                }
            }
            else if (!string.IsNullOrEmpty(NombrePlan))
            {
                condicion = " WHERE NombrePlan LIKE ('%" + NombrePlan + "%')";
            }

            string selectCommand = "SELECT planes.Id, planes.CodigoPlan, \n"
           + "       planes.NombrePlan,       \n"
           + "       planes.Usuario, \n"
           + "       planes.FechaRegistro        \n"
           + "FROM riesgos.planes " + condicion;

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }
        private DataTable ConsultaCumplimiento(string CodigoPlan)
        {
            string selectCommand = "SELECT id, convert(VARCHAR(10), Periodo,103) AS Periodo,\n"
           + "      Meta, \n"
           + "      Cumplimiento, \n"
           + "     convert(VARCHAR(10),FechaRegistro,103) AS FechaRegistro, \n"
           + "      Usuario\n"
           + "FROM [Riesgos].[IndicadorCumplimientoPlanes] WHERE CodigoPlan = ('" + CodigoPlan + "')";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable ConsultaSeguimiento(string CodigoPlan)
        {
            string selectCommand = "SELECT SeguimientosPlanes.CodigoPlan, \n"
           + "       SeguimientosPlanes.Seguimiento, \n"
           + "       SeguimientosPlanes.FechaRegistro, \n"
           + "       SeguimientosPlanes.Usuario\n"
           + "FROM [Riesgos].[SeguimientosPlanes] WHERE SeguimientosPlanes.CodigoPlan = ('" + CodigoPlan + "')";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable ConsultaRiesgosAsociados(string CodigoPlan)
        {
            string selectCommand = "SELECT planesRiesgosAsociados.Id, \n"
           + "       planesRiesgosAsociados.CodigoPlan, \n"
           + "       planesRiesgosAsociados.CodigoRiesgo, \n"
           + "       planesRiesgosAsociados.FechaRegistro, \n"
           + "       planesRiesgosAsociados.Usuario\n"
           + "FROM riesgos.planesRiesgosAsociados WHERE  planesRiesgosAsociados.codigoPlan = ('" + CodigoPlan + "')";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable DesasociarRiesgo(int id, string CodigoRiesgo)
        {
            string selectCommand = "DELETE FROM riesgos.planesRiesgosAsociados WHERE id = (" + id + ")" + " AND " + " CodigoRiesgo= ('" + CodigoRiesgo + "')";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable DesasociarEvento(int id, string CodigoEvento)
        {
            string selectCommand = "DELETE FROM Riesgos.planesEventosAsociados WHERE Id = (" + id + ")";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }
        private DataTable ConsultaEventosAsociados(string CodigoPlan)
        {
            //string selectCommand = "SELECT rpe.IdPlanes_EvsEIncs as 'Id', rp.CodigoPlan, rei.CodigoEvsEIncs as 'CodigoEvento', rpe.FechaRegistro, rpe.IdUsuario as 'Usuario' FROM Riesgos.planes rp INNER JOIN Riesgos.Planes_EvsEIncs rpe ON rp.Id = rpe.IdPlanes INNER JOIN Riesgos.EventosIncidentes rei " +
            //    "ON rei.IdEvsEIncs = rpe.IdEvsEIncs WHERE rp.CodigoPlan = '" + CodigoPlan + "'";
            string selectCommand = "SELECT PEA.Id as 'Id', rp.CodigoPlan, rei.CodigoEvsEIncs as 'CodigoEvento', rei.FechaRegistro, CONCAT(lu.Nombres, ' ', lu.Apellidos) as 'Usuario' FROM Riesgos.PlanesEventosAsociados PEA INNER JOIN Riesgos.planes rp ON rp.CodigoPlan = PEA.CodigoPlan INNER JOIN Riesgos.EventosIncidentes rei ON rei.CodigoEvsEIncs = PEA.CodigoEvento LEFT JOIN Listas.Usuarios lu ON rei.IdUsuarioRegistro = lu.IdUsuario" +
                " WHERE rp.CodigoPlan = '" + CodigoPlan + "'";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable UltimoCodigoPlan()
        {
            string selectCommand = "SELECT  'PA' + Convert( varchar, MAX(id))  AS codigo FROM riesgos.planes ";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable ReportePlanes()
        {
            string selectCommand =
            //     "SELECT distinct\n"
            //+ "	     p.CodigoPlan, \n"
            //+ "       ISNULL(pra.CodigoRiesgo, '-') CodigoRiesgo, \n"
            //+ "       ISNULL(pea.CodigoEvento, '-') CodigoEvento, \n"
            //+ "       ISNULL(ic.Meta, 0) Meta, \n"
            //+ "       ISNULL(ic.Gestion, 0) Gestion, \n"
            //+ "       ISNULL(ic.Cumplimiento, 0) Cumplimiento, \n"
            //+ "       ISNULL(sp.Seguimiento, '-') Seguimiento, \n"
            //+ "       ISNULL(jp.Justificacion, '-') Justificacion, \n"
            //+ "       p.FechaRegistro, \n"
            //+ "       p.Usuario\n"
            //+ "	     FROM riesgos.planes p \n"
            //+ "	     LEFT JOIN [riesgos].[PlanesRiesgosAsociados] pra ON pra.CodigoPlan = p.CodigoPlan\n"
            //+ "	     LEFT JOIN  [riesgos].[PlanesEventosAsociados] pea ON pea.CodigoPlan = p.CodigoPlan\n"
            //+ "	     LEFT JOIN [Riesgos].[IndicadorCumplimientoPlanes] ic ON ic.CodigoPlan = p.CodigoPlan\n"
            //+ "	     LEFT JOIN [Riesgos].[SeguimientosPlanes] sp ON sp.CodigoPlan = p.CodigoPlan\n"
            //+ "	     LEFT JOIN [riesgos].[JustificacionPlanes] jp ON jp.CodPlan = p.CodigoPlan; ";

            "SELECT p.CodigoPlan, " +
            "p.NombrePlan, " +
            "p.DescripcionPlan, " +
            "A.NombreArea, " +
            "dj.NombreResponsable, " +
            "dj.CargoResponsable, " +
            "p.Estado, ERG.RiesgoGlobal, " +
            "p.FechaRegistro, " +
            "p.FechaCompromiso, " +
            "p.FechaExtension, " +
            "ISNULL(pea.CodigoEvento, '-') CodigoEvento " +
            "from Riesgos.planes p " +
            "LEFT JOIN[Parametrizacion].[JerarquiaOrganizacional] JO on Jo.idHijo = p.IdResponsable " +
            "LEFT JOIN[Parametrizacion].[DetalleJerarquiaOrg] DJ on DJ.idHijo = Jo.idHijo " +
            "LEFT JOIN[Parametrizacion].[Area] A on A.IdArea = DJ.IdArea " +
            "LEFT JOIN[riesgos].[PlanesEventosAsociados] pea ON pea.CodigoPlan = p.CodigoPlan " +
            "LEFT JOIN [Eventos].[RiesgoGlobal] ERG ON P.IdClasificacionRiesgo = ERG.IdRiesgoGlobal " +
            "order by p.Id";


            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable ResponsablePlan(int IdResponsable)
        {
            string selectCommand = " SELECT Parametrizacion.JerarquiaOrganizacional.IdHijo, \n"
           + "       Parametrizacion.JerarquiaOrganizacional.IdPadre, \n"
           + "       Parametrizacion.JerarquiaOrganizacional.NombreHijo,       \n"
           + "       Parametrizacion.DetalleJerarquiaOrg.CorreoResponsable\n"
           + "FROM Parametrizacion.JerarquiaOrganizacional\n"
           + "     LEFT JOIN Parametrizacion.DetalleJerarquiaOrg ON Parametrizacion.JerarquiaOrganizacional.idHijo = Parametrizacion.DetalleJerarquiaOrg.idHijo\n"
           + "WHERE Parametrizacion.JerarquiaOrganizacional.idHijo = (" + IdResponsable + ")";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable mtdCargarNombreEstado(string EstadoPlan)
        {
            string selectCommand = "select IdEstadoPlanAccion, NombreEstadoPlanAccion from Parametrizacion.EstadoPlanAccion"
           + " WHERE IdEstadoPlanAccion = " + EstadoPlan + "";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable mtdconsultaResponsable(string codigoPlan)
        {
            string selectCommand = "select * from Riesgos.planes where CodigoPlan = '" + codigoPlan + "'";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable mtdCargarPlan(string codigoPlan)
        {
            string selectCommand = "select RP.IdClasificacionRiesgo, ERG.RiesgoGlobal " +
                "from Riesgos.planes RP " +
                "LEFT JOIN Eventos.RiesgoGlobal ERG ON RP.IdClasificacionRiesgo = ERG.IdRiesgoGlobal"
           + " WHERE RP.CodigoPlan = '" + codigoPlan + "'";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }


        private DataTable mtdCargarNombreEstado1(string EstadoPlan)
        {
            string selectCommand = "select IdEstadoPlanAccion, NombreEstadoPlanAccion from Parametrizacion.EstadoPlanAccion"
           + " WHERE NombreEstadoPlanAccion = '" + EstadoPlan + "'";

            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private void AddTopTreeViewNodes(DataTable treeViewData)
        {
            DataView view = new DataView(treeViewData)
            {
                RowFilter = "IdPadre = -1"
            };
            foreach (DataRowView row in view)
            {
                TreeNode newNode = new TreeNode(row["NombreHijo"].ToString().Trim(), row["IdHijo"].ToString());
                TvResponsable.Nodes.Add(newNode);
                AddChildTreeViewNodes(treeViewData, newNode);
            }

        }

        private void AddChildTreeViewNodes(DataTable treeViewData, TreeNode parentTreeViewNode)
        {
            DataView view = new DataView(treeViewData)
            {
                RowFilter = "IdPadre = " + parentTreeViewNode.Value
            };
            foreach (DataRowView row in view)
            {
                TreeNode newNode = new TreeNode(row["NombreHijo"].ToString().Trim(), row["IdHijo"].ToString())
                {
                    ToolTip = "Nombre: " + row["NombreResponsable"].ToString() + "\rCorreo: " + row["CorreoResponsable"].ToString().Trim()
                };
                parentTreeViewNode.ChildNodes.Add(newNode);
                AddChildTreeViewNodes(treeViewData, newNode);
            }

            if (TvResponsable.SelectedNode != null)
            {
                TvResponsable.SelectedNode.Selected = false;
            }
        }
        #endregion ConsultaRapida

        //Eventos 
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            scriptManager.RegisterPostBackControl(GvFiltroCarga);
            scriptManager.RegisterPostBackControl(GvCumplimiento);

            if (cCuenta.permisosConsulta(IdFormulario) == "False")
            {
                Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    objPlanes.FechaCompromiso = DateTime.Now;
                    objPlanes.FechaImplementacion = DateTime.Now;
                    objPlanes.FechaExtension = DateTime.Now;
                    GrillaPlanes();
                    CargarGrillaPlanes();
                    TvPopUp();
                    //Combos Riesgos 
                    CargarCargaCadenaValor();
                    LimpiarPDA();
                    CargarPDARiesgosGlobales();
                    if (!IsPostBack)
                        PopulateTreeView();
                    EstadoPlan.Items.Clear();
                    mtdCargarEstadosPlanAccion();
                    loadDDLArea();

                    int trans = 6;
                    TcPrincipal.ActiveTabIndex = 0;
                    string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                    FiltroNombrePlan.Focus();

                }
            }
        }

        private void PopulateTreeView()
        {
            DataTable treeViewData = GetTreeViewData();
            AddTopTreeViewNodes1(treeViewData);
            TreeView4.ExpandAll();
        }

        private void AddTopTreeViewNodes1(DataTable treeViewData)
        {
            DataView view = new DataView(treeViewData);
            view.RowFilter = "IdPadre = -1";

            foreach (DataRowView row in view)
            {
                TreeNode newNode = new TreeNode(row["NombreHijo"].ToString(), row["IdHijo"].ToString());
                TreeView4.Nodes.Add(newNode);
                AddChildTreeViewNodes(treeViewData, newNode);
            }
        }

        protected void TreeView4_SelectedNodeChanged(object sender, EventArgs e)
        {
            tbxResponsable.Text = TreeView4.SelectedNode.Text;
            lblIdDependencia4.Text = TreeView4.SelectedNode.Value;
        }

        protected void SqlDataSource200_On_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            LastInsertIdCE = (int)e.Command.Parameters["@NewParameter2"].Value;
        }

        // Nuevo
        protected void AgregarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            TbRegistrarPlan.Visible = true;
            CargaGvRiesgosAsociados();
            CargaGvEventosAsociados();
            GrillaArchivoPlanes();
            GrillaCumplimiento();
            GrillaSeguimiento();
            CargaGvRiesgos();
            LimpiarCamposPlanes();
            LimpiarFiltroRiesgos();
            LimpiarFiltroEventos();
            LimpiarCumplimiento();
            LimpiarSeguimiento();
            EstadoPlan.Items.Clear();
            mtdCargarEstadosPlanAccion();
            TbCarga.Visible = false;
            CodigoPlan.Text = string.Empty;
            NombrePlan.Text = string.Empty;
            Descripcion.Text = string.Empty;
            Responsable.Text = string.Empty;
            EstadoPlan.SelectedIndex = 0;
            FechaCompromiso.Text = string.Empty;
            FechaImplementacion.Text = string.Empty;
            FechaExtension.Text = string.Empty;
            Justificacion.Text = string.Empty;
            EtiquetaCargas.Visible = false;
            lblRiesgosEncontrados.Visible = false;
            lblEventosEncontrados.Visible = false;
            EtiquetaJustificacion.Visible = false;
            JustificacionCambios.Visible = false;
            TablaJustificacion.Visible = false;
            PanelJustificacion.Visible = false;
            TcPrincipal.ActiveTabIndex = 0;
            Usuario.Text = Session["NombreUsuario"].ToString();
            FechaSeguimiento.Text = DateTime.Now.ToShortDateString();

            int trans = 0;
            TcPrincipal.ActiveTabIndex = 0;
            string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
            NombrePlan.Focus();
        }
        //Limpia todo
        protected void Limpiar_Click(object sender, ImageClickEventArgs e)
        {
            TbRegistrarPlan.Visible = false;
            TcPrincipal.ActiveTabIndex = 0;
            GrillaCumplimiento();
            //  CargarGrillaCumplimiento();
            GrillaSeguimiento();
            // CargarGrillaSeguimiento();

            LimpiarCamposPlanes();
            LimpiarFiltroRiesgos();
            LimpiarFiltroEventos();
            LimpiarCumplimiento();
            LimpiarSeguimiento();
            GrillaArchivoPlanes();
            CargaGvRiesgos();
            CargaGvEventos();
            TbCarga.Visible = false;
            lblRiesgosEncontrados.Visible = false;
            TbRiesgos.Visible = false;
            lblEventosEncontrados.Visible = false;
            TbEventos.Visible = false;
            EtiquetaJustificacion.Visible = false;
            JustificacionCambios.Visible = false;
            TablaJustificacion.Visible = false;
            PanelJustificacion.Visible = false;
            PanelFiltroPlanes.Visible = false;
            CuantosPlanes.Text = "0";
            FiltroCodigoPlan.Text = string.Empty;
            FiltroNombrePlan.Text = string.Empty;
            GrillaPlanes();
            CargarGrillaPlanes();
            FiltroCodigoPlan.Focus();
            TcPrincipal.ActiveTabIndex = 0;

            GvPlanesFiltro.Visible = false;
            GvPlanes.Visible = true;
            ddlEstadoFiltro.SelectedIndex = 0;
            tbxResponsable.Text = string.Empty;
        }

        private bool mtdCargarEstadosPlanAccion()
        {
            #region Vars
            string strErrMsg = "";
            bool booResult = false;
            clsCadenaValor objCadenaValor = new clsCadenaValor();
            List<clsEstadoPlan> lstEstados = new List<clsEstadoPlan>();
            clsMacroProcesoBLL cMacroproceso = new clsMacroProcesoBLL();
            #endregion Vars

            try
            {
                lstEstados = cMacroproceso.mtdConsultarEstado(ref strErrMsg);
                EstadoPlan.Items.Clear();
                EstadoPlan.Items.Insert(0, new System.Web.UI.WebControls.ListItem("", "0"));

                if (string.IsNullOrEmpty(strErrMsg))
                {

                    if (lstEstados != null)
                    {
                        int intCounter = 1;

                        foreach (clsEstadoPlan objEstadoPlan in lstEstados)
                        {
                            EstadoPlan.Items.Insert(intCounter, new System.Web.UI.WebControls.ListItem(objEstadoPlan.strNombreEstado, objEstadoPlan.intId.ToString()));
                            ddlEstadoFiltro.Items.Insert(intCounter, new System.Web.UI.WebControls.ListItem(objEstadoPlan.strNombreEstado, objEstadoPlan.intId.ToString()));
                            intCounter++;
                        }
                        booResult = true;
                    }
                }
                else
                {
                    strErrMsg = "Error al cargar la información";
                    booResult = false;
                }
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error durante la consulta de macroprocesos. [{0}]", ex.Message);
                booResult = false;
            }

            return booResult;
        }

        private void loadDDLArea()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cControl.loadDDLAreas();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    DDLArea.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreArea"].ToString().Trim(), dtInfo.Rows[i]["IdArea"].ToString()));
                }
            }
            catch (Exception ex)
            {
                //Mensaje("Error al cargar las áreas. " + ex.Message);
            }
        }

        protected void TvResponsable_SelectedNodeChanged(object sender, EventArgs e)
        {
            Responsable.Text = TvResponsable.SelectedNode.Text;
            lblIdDependencia.Text = TvResponsable.SelectedNode.Value;
        }

        protected void Exportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ReportePlanes();
                dt.TableName = "Reporte-Planes";
                if (dt.Rows.Count > 0)
                {
                    exportExcel(dt, Response, "Reporte Planes de Acción " + DateTime.Now + "");
                }
                else
                {
                    int trans = 7;
                    TcPrincipal.ActiveTabIndex = 0;
                    string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                    FiltroCodigoPlan.Focus();
                    PanelFiltroPlanes.Visible = false;
                    CuantosPlanes.Text = "0";
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al exportar el reporte de planes de acción:" + ex.Message.ToString(), 1, "Error");
            }
        }

        protected void GvPlanes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            pagIndexPlanes = e.NewPageIndex;
            GvPlanes.PageIndex = pagIndexPlanes;
            GvPlanes.DataSource = TodosPlanes;
            GvPlanes.DataBind();
        }

        protected void GvPlanesfiltro_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            pagIndexPlanes = e.NewPageIndex;
            GvPlanesFiltro.PageIndex = pagIndexPlanes;
            GvPlanesFiltro.DataSource = listaPlanes;
            GvPlanesFiltro.DataBind();
        }

        protected void GvPlanes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Editar":
                        RowGridPlanes = (Convert.ToInt16(GvPlanes.PageSize) * pagIndexPlanes) + Convert.ToInt16(e.CommandArgument);
                        GridViewRow row = GvPlanes.Rows[Convert.ToInt16(e.CommandArgument)];
                        System.Collections.Specialized.IOrderedDictionary colsNoVisible = GvPlanes.DataKeys[Convert.ToInt16(e.CommandArgument)].Values;
                        objPlanes.Codigo = colsNoVisible[0].ToString();
                        string estadoPlan = colsNoVisible[1].ToString();
                        objPlanes.Estado = colsNoVisible[1].ToString();
                        int Transaccion = 2;
                        RegistrarPlan(ref objPlanes, Transaccion, estadoPlan); // Cargo los campos básicos
                                                                               //EstadoPlan.Items.Clear();
                                                                               //mtdCargarEstadosPlanAccion();
                        TbRegistrarPlan.Visible = true;
                        TcPrincipal.ActiveTabIndex = 0;
                        CodigoPlan.Focus();
                        TbCarga.Visible = true;
                        lblRiesgosEncontrados.Visible = false;
                        tpEventosAsociados.Visible = true;
                        //lblEventosEncontrados.Visible = false;
                        EtiquetaCargas.Visible = true;
                        EtiquetaJustificacion.Visible = true;
                        JustificacionCambios.Visible = true;
                        TablaJustificacion.Visible = true;
                        PanelJustificacion.Visible = true;
                        GrillaCumplimiento();
                        CargarGrillaCumplimiento();
                        GrillaArchivoPlanes();
                        CargaArchivosPlanes();
                        GrillaJustificacion();
                        CargaGrillaJustificacion();
                        InicializarValoresGvRiesgosAsociados();
                        CargaGvRiesgosAsociados();
                        LlenarGvRiesgosAsociados();
                        InicializarValoresGvEventosAsociados();
                        CargaGvEventosAsociados();
                        LlenarGvEventosAsociados();
                        GrillaSeguimiento();
                        CargarGrillaSeguimiento();
                        //EstadoPlan.Items.Clear();
                        //mtdCargarEstadosPlanAccion();
                        string codigoPlan = objPlanes.Codigo;

                        PDARiesgoGLobal.Items.Clear();
                        mtdCargarRoesgosGlobales();
                        DataTable dt1 = mtdCargarPlan(codigoPlan);
                        PDARiesgoGLobal.SelectedItem.Text = dt1.Rows[0]["RiesgoGlobal"].ToString().Trim();

                        int trans = 8;
                        TcPrincipal.ActiveTabIndex = 0;
                        string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                        Justificacion.Focus();

                        break;
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al mostrar plan de acción: " + ex.Message.ToString(), 1, "Error");
            }
        }

        protected void GvPlanesFiltro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Editar":
                        RowGridPlanes = (Convert.ToInt16(GvPlanesFiltro.PageSize) * pagIndexPlanes) + Convert.ToInt16(e.CommandArgument);
                        GridViewRow row = GvPlanesFiltro.Rows[Convert.ToInt16(e.CommandArgument)];
                        System.Collections.Specialized.IOrderedDictionary colsNoVisible = GvPlanesFiltro.DataKeys[Convert.ToInt16(e.CommandArgument)].Values;
                        objPlanes.Codigo = colsNoVisible[0].ToString();
                        string estadoPlan = colsNoVisible[1].ToString();
                        objPlanes.Estado = colsNoVisible[1].ToString();
                        int Transaccion = 2;
                        RegistrarPlan(ref objPlanes, Transaccion, estadoPlan); // Cargo los campos básicos
                                                                               //EstadoPlan.Items.Clear();
                                                                               //mtdCargarEstadosPlanAccion();
                        TbRegistrarPlan.Visible = true;
                        TcPrincipal.ActiveTabIndex = 0;
                        CodigoPlan.Focus();
                        TbCarga.Visible = true;
                        lblRiesgosEncontrados.Visible = false;
                        tpEventosAsociados.Visible = true;
                        //lblEventosEncontrados.Visible = false;
                        EtiquetaCargas.Visible = true;
                        EtiquetaJustificacion.Visible = true;
                        JustificacionCambios.Visible = true;
                        TablaJustificacion.Visible = true;
                        PanelJustificacion.Visible = true;
                        GrillaCumplimiento();
                        CargarGrillaCumplimiento();
                        GrillaArchivoPlanes();
                        CargaArchivosPlanes();
                        GrillaJustificacion();
                        CargaGrillaJustificacion();
                        InicializarValoresGvRiesgosAsociados();
                        CargaGvRiesgosAsociados();
                        LlenarGvRiesgosAsociados();
                        InicializarValoresGvEventosAsociados();
                        CargaGvEventosAsociados();
                        LlenarGvEventosAsociados();
                        GrillaSeguimiento();
                        CargarGrillaSeguimiento();
                        //EstadoPlan.Items.Clear();
                        //mtdCargarEstadosPlanAccion();
                        string codigoPlan = objPlanes.Codigo;

                        PDARiesgoGLobal.Items.Clear();
                        mtdCargarRoesgosGlobales();
                        DataTable dt1 = mtdCargarPlan(codigoPlan);
                        PDARiesgoGLobal.SelectedItem.Text = dt1.Rows[0]["RiesgoGlobal"].ToString().Trim();

                        int trans = 8;
                        TcPrincipal.ActiveTabIndex = 0;
                        string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                        Justificacion.Focus();

                        break;
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al mostrar plan de acción: " + ex.Message.ToString(), 1, "Error");
            }
        }

        private bool mtdCargarRoesgosGlobales()
        {
            #region Vars
            string strErrMsg = "";
            bool booResult = false;
            clsRiesgoGlobal clsRiesgoGlobal = new clsRiesgoGlobal();
            List<clsRiesgoGlobal> lstRiesgosGlobales = new List<clsRiesgoGlobal>();
            clsMacroProcesoBLL cMacroproceso = new clsMacroProcesoBLL();
            #endregion Vars

            try
            {
                lstRiesgosGlobales = cMacroproceso.mtdConsultarRiesgosGlobales(ref strErrMsg);
                PDARiesgoGLobal.Items.Clear();
                PDARiesgoGLobal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("", "0"));

                if (string.IsNullOrEmpty(strErrMsg))
                {

                    if (lstRiesgosGlobales != null)
                    {
                        int intCounter = 1;

                        foreach (clsRiesgoGlobal objEstadoPlan in lstRiesgosGlobales)
                        {
                            PDARiesgoGLobal.Items.Insert(intCounter, new System.Web.UI.WebControls.ListItem(objEstadoPlan.strNombreRiesgo, objEstadoPlan.intId.ToString()));
                            intCounter++;
                        }
                        booResult = true;
                    }
                }
                else
                {
                    strErrMsg = "Error al cargar la información";
                    booResult = false;
                }
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error durante la consulta de Riesgos Globales. [{0}]", ex.Message);
                booResult = false;
            }

            return booResult;
        }

        protected void GvCumplimiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            pagIndexCumplimiento = e.NewPageIndex;
            GvCumplimiento.PageIndex = pagIndexCumplimiento;
            GvCumplimiento.DataSource = InfoGridCumplimiento;
            GvCumplimiento.DataBind();
        }

        protected void GvCumplimiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Editar":

                    if (cCuenta.permisosActualizar(IdFormulario) == "False")
                    {
                        omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción!", 1, "Atención");
                    }
                    else
                    {
                        int Index = Convert.ToInt16(e.CommandArgument);
                        RowGridCumplimiento = (Convert.ToInt16(GvCumplimiento.PageSize) * pagIndexCumplimiento) + Convert.ToInt16(e.CommandArgument);
                        System.Collections.Specialized.IOrderedDictionary colsNoVisible = GvCumplimiento.DataKeys[Index].Values;
                        string Id = colsNoVisible[0].ToString();
                        string Meta = colsNoVisible[1].ToString();
                        string Periodo = colsNoVisible[2].ToString();

                        IdGestion = Convert.ToInt32(Id);
                        MetaGestion = Convert.ToInt32(Meta);
                        ModalMeta.Text = Meta + "%";
                        ModalGestion.Focus();
                        MPCumplimiento.Show();




                    }
                    break;
            }

        }

        protected void GvSeguimiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            pagIndexSeguimiento = e.NewPageIndex;
            GvSeguimiento.PageIndex = pagIndexSeguimiento;
            GvSeguimiento.DataSource = InfoGridSeguimiento;
            GvSeguimiento.DataBind();
        }

        protected void GvSeguimiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Para los adjuntos nada mas

        }

        // Aceptar - Guardar todo
        protected void Aceptar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string nombreUsuario = Session["NombreUsuario"].ToString();
                int Transaccion = 1;

                #region captura
                objPlanes.Codigo = CodigoPlan.Text;
                objPlanes.NombrePlan = NombrePlan.Text;
                objPlanes.DescripcionPlan = Descripcion.Text;
                objPlanes.Responsable = Responsable.Text;

                objPlanes.RiesgoGlobal = PDARiesgoGLobal.Text;
                if (objPlanes.RiesgoGlobal == "0")
                {
                    DataTable dt = mtdconsultaResponsable(objPlanes.Codigo);
                    objPlanes.RiesgoGlobal = dt.Rows[0]["IdClasificacionRiesgo"].ToString();
                }
                else
                {
                    objPlanes.RiesgoGlobal = PDARiesgoGLobal.Text;
                }

                objPlanes.IdDependencia = lblIdDependencia.Text;
                if (objPlanes.IdDependencia == "")
                {
                    if (objPlanes.Codigo.Equals(""))
                    {
                        throw new Exception("Se debe asignar el responsable de decisión del plan de acción.");
                    }
                    else
                    {
                        DataTable dt = mtdconsultaResponsable(objPlanes.Codigo);
                        objPlanes.IdDependencia = dt.Rows[0]["IdResponsable"].ToString();
                    }
                }
                else
                {
                    objPlanes.IdDependencia = lblIdDependencia.Text;
                }

                objPlanes.Estado = EstadoPlan.SelectedItem.Text;
                if (objPlanes.Estado == "0" || objPlanes.Estado == "")
                {
                    DataTable dt = mtdconsultaResponsable(objPlanes.Codigo);
                    objPlanes.Estado = dt.Rows[0]["Estado"].ToString();
                }
                else
                {
                    objPlanes.Estado = EstadoPlan.SelectedItem.Text;
                }

                //DataTable dt1 = mtdCargarNombreEstado(EstadoPlan.Text);
                //if (dt1.Rows.Count > 0)
                //{
                //    string NombreEstado = dt1.Rows[0]["NombreEstadoPlanAccion"].ToString();
                //    objPlanes.Estado = NombreEstado;
                //}
                objPlanes.Justificacion = Justificacion.Text;
                objPlanes.CodigoRiesgo = RiesgoAsociar.Text;
                objPlanes.CodigoEvento = AsociarEvento.Text;
                if (string.IsNullOrEmpty(Periodo.Text)) { objPlanes.Periodo = null; } else { objPlanes.Periodo = Convert.ToDateTime(Periodo.Text); }
                if (string.IsNullOrEmpty(Meta.Text))
                {
                    objPlanes.Meta = null;
                }
                else
                {
                    objPlanes.Meta = Convert.ToInt32(Meta.Text);
                }
                objPlanes.Usuario = nombreUsuario;
                objPlanes.Seguimiento = Seguimiento.Text;
                int cuantos = FechaCompromiso.Text.Length;

                DateTime hoy = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                #endregion captura
                if (cuantos >= 9)
                {
                    validarFechas(objPlanes);
                    rellenarFechas();

                    objPlanes.FechaCompromiso = Convert.ToDateTime(FechaCompromiso.Text);
                    objPlanes.FechaImplementacion = Convert.ToDateTime(FechaImplementacion.Text);
                    objPlanes.FechaExtension = Convert.ToDateTime(FechaExtension.Text);

                    int compararFecha = DateTime.Compare(Convert.ToDateTime(FechaCompromiso.Text), hoy);

                    // primero validar permisos
                    if (cCuenta.permisosAgregar(IdFormulario) == "False")
                    {
                        {
                            omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 1, "Atención");
                        }
                    }
                    else
                    {
                        bool validarRiesgo = tieneRiesgo();
                        if (!validarRiesgo)
                        {
                            omb.ShowMessage("Debe agregar un riesgo.", 1, "Atención");
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(objPlanes.Codigo))
                            {
                                if (compararFecha >= 0)
                                {
                                    if (string.IsNullOrEmpty(Periodo.Text) && string.IsNullOrEmpty(Meta.Text))
                                    {
                                        //Registrar 
                                        RegistrarPlan(ref objPlanes, Transaccion, string.Empty);

                                        if (objPlanes.Resultado == "OK")
                                        {
                                            omb.ShowMessage("Se ha registrado el plan exitosamente! ", 3, "Atención");
                                            DataTable dt = ResponsablePlan(Convert.ToInt32(objPlanes.IdDependencia));
                                            string idResponsable = dt.Rows[0]["IdPadre"].ToString();
                                            string CuerpoCorreo = string.Empty;
                                            if (string.IsNullOrEmpty(objPlanes.Codigo))
                                            {
                                                if (string.IsNullOrEmpty(RiesgoAsociar.Text))
                                                {
                                                    if (string.IsNullOrEmpty(AsociarEvento.Text))
                                                    {
                                                        UltimoCodigo();
                                                        CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                              "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                              "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                              "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                              "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                              "<br />";
                                                        EnviarNotificacion(11, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                    }
                                                    else
                                                    {
                                                        UltimoCodigo();
                                                        CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                              "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                              "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                              "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                              "<br /><B> Evento asociado: </B>" + AsociarEvento.Text +
                                                              "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                              "<br />";
                                                        EnviarNotificacion(11, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                    }
                                                }
                                                else
                                                {
                                                    if ((string.IsNullOrEmpty(AsociarEvento.Text))) // solo el riesgo
                                                    {
                                                        UltimoCodigo();
                                                        CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                              "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                              "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                              "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                              "<br /><B> Riesgo Asociado: </B>" + RiesgoAsociar.Text +
                                                              "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                              "<br />";
                                                        EnviarNotificacion(11, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                    }
                                                    else // Ambos - riesgo / evento
                                                    {
                                                        UltimoCodigo();
                                                        CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                              "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                              "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                              "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                              "<br /><B> Riesgo Asociado: </B>" + RiesgoAsociar.Text +
                                                              "<br /><B> Evento asociado: </B>" + AsociarEvento.Text +
                                                              "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                              "<br />";
                                                        EnviarNotificacion(11, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                    }
                                                }
                                            }

                                            GrillaPlanes();
                                            GrillaArchivoPlanes();
                                            CargaArchivosPlanes();
                                            GrillaArchivoPlanes();
                                            GrillaJustificacion();
                                            CargaGrillaJustificacion();
                                            CargarGrillaPlanes();
                                            CargaGvRiesgos(); // Filtro
                                            InicializarValoresGvRiesgosAsociados();
                                            CargaGvRiesgosAsociados();
                                            LlenarGvRiesgosAsociados();
                                            CargaGvEventos(); // Filtro
                                            InicializarValoresGvEventosAsociados();
                                            CargaGvEventosAsociados();
                                            LlenarGvEventosAsociados();
                                            GrillaCumplimiento();
                                            CargarGrillaCumplimiento();
                                            GrillaSeguimiento();
                                            CargarGrillaSeguimiento();
                                            LimpiarCamposPlanes();
                                            LimpiarFiltroRiesgos();
                                            LimpiarFiltroEventos();
                                            LimpiarCumplimiento();
                                            LimpiarSeguimiento();
                                            TbCarga.Visible = true;
                                            EtiquetaJustificacion.Visible = true;
                                            JustificacionCambios.Visible = true;
                                            TablaJustificacion.Visible = true;
                                            PanelJustificacion.Visible = true;
                                            TcPrincipal.ActiveTabIndex = 0;

                                            int trans = 8;
                                            TcPrincipal.ActiveTabIndex = 0;
                                            string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                                            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                                            Justificacion.Focus();
                                        }
                                    }

                                    else
                                    {
                                        if (string.IsNullOrEmpty(Periodo.Text))
                                        {
                                            int trans = 1;
                                            Periodo.Focus();
                                            string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                                            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                                            TcPrincipal.ActiveTabIndex = 3;
                                        }
                                        else if (string.IsNullOrEmpty(Meta.Text))
                                        {
                                            int trans = 2;
                                            Meta.Focus();
                                            string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                                            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                                            TcPrincipal.ActiveTabIndex = 3;
                                        }
                                        else
                                        {
                                            //Registrar 
                                            RegistrarPlan(ref objPlanes, Transaccion, string.Empty);

                                            if (objPlanes.Resultado == "OK")
                                            {
                                                omb.ShowMessage("Se ha registrado el plan exitosamente! ", 3, "Atención");
                                                DataTable dt = ResponsablePlan(Convert.ToInt32(objPlanes.IdDependencia));
                                                string idResponsable = dt.Rows[0]["IdPadre"].ToString();
                                                string CuerpoCorreo = string.Empty;
                                                if (string.IsNullOrEmpty(objPlanes.Codigo))
                                                {
                                                    if (string.IsNullOrEmpty(RiesgoAsociar.Text))
                                                    {
                                                        if (string.IsNullOrEmpty(AsociarEvento.Text))
                                                        {
                                                            UltimoCodigo();
                                                            CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                                  "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                                  "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                                  "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                                  "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                                  "<br />";
                                                            EnviarNotificacion(11, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                        }
                                                        else
                                                        {
                                                            UltimoCodigo();
                                                            CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                                  "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                                  "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                                  "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                                  "<br /><B> Evento asociado: </B>" + AsociarEvento.Text +
                                                                  "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                                  "<br />";
                                                            EnviarNotificacion(11, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if ((string.IsNullOrEmpty(AsociarEvento.Text))) // solo el riesgo
                                                        {
                                                            UltimoCodigo();
                                                            CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                                  "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                                  "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                                  "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                                  "<br /><B> Riesgo Asociado: </B>" + RiesgoAsociar.Text +
                                                                  "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                                  "<br />";
                                                            EnviarNotificacion(11, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                        }
                                                        else // Ambos - riesgo / evento
                                                        {
                                                            UltimoCodigo();
                                                            CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                                  "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                                  "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                                  "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                                  "<br /><B> Riesgo Asociado: </B>" + RiesgoAsociar.Text +
                                                                  "<br /><B> Evento asociado: </B>" + AsociarEvento.Text +
                                                                  "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                                  "<br />";
                                                            EnviarNotificacion(11, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                        }
                                                    }
                                                }

                                                GrillaPlanes();
                                                GrillaArchivoPlanes();
                                                CargaArchivosPlanes();
                                                GrillaArchivoPlanes();
                                                GrillaJustificacion();
                                                CargaGrillaJustificacion();
                                                CargarGrillaPlanes();
                                                CargaGvRiesgos(); // Filtro
                                                InicializarValoresGvRiesgosAsociados();
                                                CargaGvRiesgosAsociados();
                                                LlenarGvRiesgosAsociados();
                                                CargaGvEventos(); // Filtro
                                                InicializarValoresGvEventosAsociados();
                                                CargaGvEventosAsociados();
                                                LlenarGvEventosAsociados();
                                                GrillaCumplimiento();
                                                CargarGrillaCumplimiento();
                                                GrillaSeguimiento();
                                                CargarGrillaSeguimiento();
                                                LimpiarCamposPlanes();
                                                LimpiarFiltroRiesgos();
                                                LimpiarFiltroEventos();
                                                LimpiarCumplimiento();
                                                LimpiarSeguimiento();
                                                TbCarga.Visible = true;
                                                EtiquetaJustificacion.Visible = true;
                                                JustificacionCambios.Visible = true;
                                                TablaJustificacion.Visible = true;
                                                PanelJustificacion.Visible = true;
                                                TcPrincipal.ActiveTabIndex = 0;

                                                int trans = 0;
                                                TcPrincipal.ActiveTabIndex = 0;
                                                string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                                                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                                                NombrePlan.Focus();
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    int trans = 4;
                                    TcPrincipal.ActiveTabIndex = 0;
                                    string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                                    FechaCompromiso.Focus();
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(Justificacion.Text))
                                {
                                    if (string.IsNullOrEmpty(Periodo.Text) && string.IsNullOrEmpty(Meta.Text))
                                    {
                                        Transaccion = 3;
                                        RegistrarPlan(ref objPlanes, Transaccion, string.Empty);
                                        if (objPlanes.Resultado == "OK")
                                        {
                                            omb.ShowMessage("Se ha registrado el plan exitosamente! ", 3, "Atención");

                                            DataTable dt = ResponsablePlan(Convert.ToInt32(objPlanes.IdDependencia));
                                            string idResponsable = dt.Rows[0]["IdPadre"].ToString();
                                            string CuerpoCorreo = string.Empty;

                                            if (!string.IsNullOrEmpty(RiesgoAsociar.Text))
                                            {
                                                CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                    "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                    "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                    "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                    "<br /><B> Riesgo Asociado: </B>" + RiesgoAsociar.Text +
                                                    "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                    "<br />";
                                                EnviarNotificacion(6, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                            }
                                            if (!string.IsNullOrEmpty(AsociarEvento.Text))
                                            {
                                                CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                          "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                          "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                          "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                          "<br /><B> Evento asociado: </B>" + AsociarEvento.Text +
                                                          "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                          "<br />";
                                                EnviarNotificacion(10, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                            }

                                            GrillaPlanes();
                                            GrillaArchivoPlanes();
                                            CargaArchivosPlanes();
                                            CargarGrillaPlanes();
                                            GrillaJustificacion();
                                            CargaGrillaJustificacion();
                                            CargaGvRiesgos(); // Filtro
                                            InicializarValoresGvRiesgosAsociados();
                                            CargaGvRiesgosAsociados();
                                            LlenarGvRiesgosAsociados();
                                            CargaGvEventos(); // Filtro
                                            InicializarValoresGvEventosAsociados();
                                            CargaGvEventosAsociados();
                                            LlenarGvEventosAsociados();
                                            GrillaCumplimiento();
                                            CargarGrillaCumplimiento();
                                            GrillaSeguimiento();
                                            CargarGrillaSeguimiento();
                                            LimpiarCamposPlanes();
                                            LimpiarFiltroRiesgos();
                                            LimpiarFiltroEventos();
                                            LimpiarCumplimiento();
                                            LimpiarSeguimiento();
                                            TbCarga.Visible = true;
                                            EtiquetaJustificacion.Visible = true;
                                            JustificacionCambios.Visible = true;
                                            TablaJustificacion.Visible = true;
                                            PanelJustificacion.Visible = true;
                                            TcPrincipal.ActiveTabIndex = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(Periodo.Text))
                                        {
                                            int trans = 1;
                                            Periodo.Focus();
                                            string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                                            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                                            TcPrincipal.ActiveTabIndex = 3;
                                        }
                                        else if (string.IsNullOrEmpty(Meta.Text))
                                        {
                                            int trans = 2;
                                            Meta.Focus();
                                            string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                                            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                                            TcPrincipal.ActiveTabIndex = 3;
                                        }
                                        else
                                        {
                                            Transaccion = 3;
                                            RegistrarPlan(ref objPlanes, Transaccion, string.Empty);
                                            if (objPlanes.Resultado == "OK")
                                            {
                                                omb.ShowMessage("Se ha realizado el registrado exitosamente! ", 3, "Atención");

                                                DataTable dt = ResponsablePlan(Convert.ToInt32(objPlanes.IdDependencia));
                                                if (dt.Rows.Count > 0)
                                                {
                                                    string idResponsable = dt.Rows[0]["IdPadre"].ToString();
                                                    string CuerpoCorreo = string.Empty;

                                                    if (!string.IsNullOrEmpty(RiesgoAsociar.Text))
                                                    {
                                                        CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                                 "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                                 "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                                 "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                                 "<br /><B> Riesgo Asociado: </B>" + RiesgoAsociar.Text +
                                                                 "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                                 "<br />";
                                                        EnviarNotificacion(6, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                    }
                                                    if (!string.IsNullOrEmpty(AsociarEvento.Text))
                                                    {
                                                        CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan.Text +
                                                                  "<br /><B> Nombre del plan: </B>" + objPlanes.NombrePlan +
                                                                  "<br /><B> Descripción de la Acción: </B>" + objPlanes.DescripcionPlan +
                                                                  "<br /><B> Estado: </B>" + objPlanes.Estado +
                                                                  "<br /><B> Evento asociado: </B>" + AsociarEvento.Text +
                                                                  "<br /><B> Fecha de Compromiso: </B>" + objPlanes.FechaCompromiso.ToString() +
                                                                  "<br />";
                                                        EnviarNotificacion(10, 0, Convert.ToInt32(idResponsable), "", CuerpoCorreo);
                                                    }

                                                    GrillaPlanes();
                                                    GrillaArchivoPlanes();
                                                    CargaArchivosPlanes();
                                                    CargarGrillaPlanes();
                                                    GrillaJustificacion();
                                                    CargaGrillaJustificacion();
                                                    CargaGvRiesgos(); // Filtro
                                                    InicializarValoresGvRiesgosAsociados();
                                                    CargaGvRiesgosAsociados();
                                                    LlenarGvRiesgosAsociados();
                                                    CargaGvEventos(); // Filtro
                                                    InicializarValoresGvEventosAsociados();
                                                    CargaGvEventosAsociados();
                                                    LlenarGvEventosAsociados();
                                                    GrillaCumplimiento();
                                                    CargarGrillaCumplimiento();
                                                    GrillaSeguimiento();
                                                    CargarGrillaSeguimiento();
                                                    LimpiarCamposPlanes();
                                                    LimpiarFiltroRiesgos();
                                                    LimpiarFiltroEventos();
                                                    LimpiarCumplimiento();
                                                    LimpiarSeguimiento();
                                                    TbCarga.Visible = true;
                                                    EtiquetaJustificacion.Visible = true;
                                                    JustificacionCambios.Visible = true;
                                                    TablaJustificacion.Visible = true;
                                                    PanelJustificacion.Visible = true;
                                                    TcPrincipal.ActiveTabIndex = 0;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    TcPrincipal.ActiveTabIndex = 0;
                                    string script = @"<script type='text/javascript'>FocusJustificacion();" + "</script>";
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                                    Justificacion.Focus();
                                }
                            }
                        }
                    }
                }
                else
                {
                    int trans = 3;
                    TcPrincipal.ActiveTabIndex = 0;
                    string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                    FechaCompromiso.Focus();
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error en el método para registrar: " + ex.Message.ToString(), 1, "Error");
            }
        }

        protected bool tieneRiesgo()
        {
            if (GvRiesgosAsociados.Rows.Count > 0 || !RiesgoAsociar.Text.Trim().Equals(""))
                return true;
            else
                return false;
        }

        protected void FiltroBusquedaPlan_Click(object sender, ImageClickEventArgs e)
        {
            string CodigoPlan = FiltroCodigoPlan.Text.Trim();
            string NombrePlan = FiltroNombrePlan.Text.Trim();

            if (CodigoPlan == "" && NombrePlan == "")
            {
                omb.ShowMessage("Debe ingresar por lo menos un parámetro de consulta.", 2, "Atención");
                int trans = 6;
                TcPrincipal.ActiveTabIndex = 0;
                string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                FiltroNombrePlan.Focus();
            }
            else
            {
                GrillaPlanes();
                CargarGrillaPlanesFiltro(CodigoPlan, NombrePlan);
            }
        }

        protected void CancelarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            PanelFiltroPlanes.Visible = false;
            CuantosPlanes.Text = "0";
            FiltroCodigoPlan.Text = string.Empty;
            FiltroNombrePlan.Text = string.Empty;
            GrillaPlanes();
            CargarGrillaPlanes();
            FiltroCodigoPlan.Focus();
        }

        protected void BuscarRiesgo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (CodigoRiesgo.Text.Trim() == "" && NombreRiesgo.Text.Trim() == "" && CadenaValorRiesgo.SelectedValue.ToString().Trim() == "---" &&
                    MacroprocesoRiesgo.SelectedValue.ToString().Trim() == "---" && SubprocesoRiesgo.SelectedValue.ToString().Trim() == "---" &&
                    RiesgosGlobales.SelectedValue.ToString().Trim() == "---")
                {
                    omb.ShowMessage("Debe ingresar por lo menos un parámetro de consulta.", 2, "Atención");
                }
                else
                {
                    InicializarValoresGvRiesgos();
                    CargaGvRiesgos();
                    LlenarGvRiesgos();
                    GvFiltroRiesgos.Visible = true;
                    lblRiesgosEncontrados.Visible = true;
                    TbRiesgos.Visible = true;

                    int trans = 10;
                    TcPrincipal.ActiveTabIndex = 1;
                    string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BuscarEvento_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (CodigoEvento.Text.Trim() == "" && DescripcionEvento.Text.Trim() == "")
                {
                    omb.ShowMessage("Debe ingresar por lo menos un parámetro de consulta.", 2, "Atención");
                }
                else
                {
                    InicializarValoresGvRiesgos();
                    CargaGvEventos();
                    LlenarGvEventos();
                    GvFiltroEventos.Visible = true;

                    int trans = 10;
                    TcPrincipal.ActiveTabIndex = 2;
                    string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al consultar eventos: " + ex.Message.ToString(), 1, "Error");
            }
        }

        protected void GvFiltroRiesgos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Asociar":
                    try
                    {
                        int Index = Convert.ToInt16(e.CommandArgument);
                        int Encontrados = 0;
                        RowGridRiesgos = (Convert.ToInt16(GvFiltroRiesgos.PageSize) * PagIndexInfoGridRiesgos) + Convert.ToInt16(e.CommandArgument);
                        System.Collections.Specialized.IOrderedDictionary colsNoVisible = GvFiltroRiesgos.DataKeys[Index].Values;
                        string CodigoRiesgo = colsNoVisible[1].ToString();
                        string CodigoRiesgoAsociado = string.Empty;

                        for (int i = 0; i < GvRiesgosAsociados.Rows.Count; i++)
                        {
                            System.Collections.Specialized.IOrderedDictionary colsNoVisibleAsociados = GvRiesgosAsociados.DataKeys[i].Values;
                            CodigoRiesgoAsociado = colsNoVisibleAsociados[2].ToString();
                            if (CodigoRiesgo == CodigoRiesgoAsociado)
                            {
                                omb.ShowMessage("El riesgo ya se encuentra relacionado al plan, intente con otro riesgo", 2, "Atención");
                                Encontrados = 1;
                                break;
                            }
                        }
                        if (Encontrados < 1)
                        {
                            AsociarRiesgo(CodigoRiesgo);
                        }
                    }
                    catch (Exception ex)
                    {
                        omb.ShowMessage("Error al asociar: " + ex.Message.ToString() + ". En el evento: GvFiltroRiesgos_RowCommand. Código-Clase: PaRiesgoEvento.ascx.cs ", 1, "Error");
                    }

                    break;
            }
        }

        protected void GvFiltroRiesgos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridRiesgos = e.NewPageIndex;
            GvFiltroRiesgos.PageIndex = PagIndexInfoGridRiesgos;
            GvFiltroRiesgos.DataSource = InfoGridRiesgos;
            GvFiltroRiesgos.DataBind();
        }

        protected void GvFiltroEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Asociar":
                    try
                    {
                        int Index = Convert.ToInt16(e.CommandArgument);
                        int Encontrados = 0;
                        RowGridEventos = (Convert.ToInt16(GvFiltroEventos.PageSize) * pagIndexInfoGridEventos) + Convert.ToInt16(e.CommandArgument);
                        System.Collections.Specialized.IOrderedDictionary colsNoVisible = GvFiltroEventos.DataKeys[Index].Values;
                        string CodigoEvento = colsNoVisible[0].ToString();
                        string CodigoEventoAsociado = string.Empty;

                        for (int i = 0; i < GvEventosAsociados.Rows.Count; i++)
                        {
                            System.Collections.Specialized.IOrderedDictionary colsNoVisibleAsociados = GvEventosAsociados.DataKeys[i].Values;
                            CodigoEventoAsociado = colsNoVisibleAsociados[1].ToString();
                            if (CodigoEvento == CodigoEventoAsociado)
                            {
                                omb.ShowMessage("El evento ya se encuentra relacionado al plan, intente con otro evento", 2, "Atención");
                                Encontrados = 1;
                                break;
                            }
                        }
                        if (Encontrados < 1)
                        {
                            AsociaEvento(CodigoEvento);
                        }
                    }
                    catch (Exception ex)
                    {
                        omb.ShowMessage("Error al asociar: " + ex.Message.ToString() + ". En el evento: GvFiltroEventos_RowCommand. Código-Clase: PaRiesgoEvento.ascx.cs ", 1, "Error");
                    }

                    break;
            }
        }

        protected void GvFiltroEventos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            pagIndexInfoGridEventos = e.NewPageIndex;
            GvFiltroEventos.PageIndex = pagIndexInfoGridEventos;
            GvFiltroEventos.DataSource = InfoGridEventos;
            GvFiltroEventos.DataBind();
        }

        protected void LimpiarFiltroRiesgo_Click(object sender, ImageClickEventArgs e)
        {
            LimpiarFiltroRiesgos();
            CargaGvRiesgos();
        }

        protected void LimpiarFiltroEvento_Click(object sender, ImageClickEventArgs e)
        {
            LimpiarFiltroEventos();
            CargaGvEventos();
            CargaGvEventosAsociados();
            lblEventosEncontrados.Visible = false;
            lblAsociarEvento.Visible = false;
            TbEventos.Visible = false;
        }

        protected void EstadoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (EstadoPlan.SelectedValue.Equals("6") || EstadoPlan.SelectedValue.Equals("7"))
                {
                    FechaImplementacion.Enabled = true;
                }
                else
                {
                    FechaImplementacion.Text = "";
                    FechaImplementacion.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                omb.ShowMessage($"Error en la acción Estado Plan de Acción: {ex}", 3, "Atención");
            }
        }

        // Filtros
        protected void CadenaValorRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MacroprocesoRiesgo.Items.Clear();
            MacroprocesoRiesgo.Items.Insert(0, new ListItem("---", "---"));

            if (CadenaValorRiesgo.SelectedValue.ToString().Trim() != "---")
            {
                CargarMacroproceso(CadenaValorRiesgo.SelectedValue.ToString().Trim(), 1);
            }
        }

        protected void MacroprocesoRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcesoRiesgo.Items.Clear();
            ProcesoRiesgo.Items.Insert(0, new ListItem("---", "---"));
            if (MacroprocesoRiesgo.SelectedValue.ToString().Trim() != "---")
            {
                CargarProcesoRiesgo(MacroprocesoRiesgo.SelectedValue.ToString().Trim(), 1);
            }
        }

        protected void ProcesoRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubprocesoRiesgo.Items.Clear();
            SubprocesoRiesgo.Items.Insert(0, new ListItem("---", "---"));
            if (MacroprocesoRiesgo.SelectedValue.ToString().Trim() != "---")
            {
                CargarSubProcesoRiesgo(ProcesoRiesgo.SelectedValue.ToString().Trim(), 1);
            }
        }

        protected void SubprocesoRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RiesgosGlobales.Items.Clear();
            RiesgosGlobales.Items.Insert(0, new ListItem("---", "---"));
            if (ProcesoRiesgo.SelectedValue.ToString().Trim() != "---")
            {
                CargarRiesgosGlobales(ProcesoRiesgo.SelectedValue.ToString().Trim(), 1);
            }
        }

        #region Validaciones

        protected void FechaExtension_TextChanged(object sender, EventArgs e)
        {
            bool validate = true;
            string mensaje = "";
            if (!FechaCompromiso.Text.Equals(""))
            {
                DateTime FechaBase = Convert.ToDateTime(FechaCompromiso.Text);
                DateTime FComparar = Convert.ToDateTime(FechaExtension.Text);

                if (FComparar < FechaBase)
                {
                    validate = false;
                    mensaje = "La fecha de extensión no puede ser menor a la fecha de compromiso.";
                }
            }
            else
            {
                validate = false;
                mensaje = "Debe llenar la fecha de compromiso.";
            }

            if (!validate)
            {
                FechaExtension.Text = string.Empty;
                omb.ShowMessage(mensaje, 3, "Atención");
            }

        }
        #endregion


        protected void CargarArchivo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (cCuenta.permisosAgregar(IdFormulario) == "False")
                {
                    omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 3, "Atención");
                }
                else
                {
                    if (FUCarga.HasFile)
                    {
                        CargarArchivoPlanes();
                        omb.ShowMessage("Se asoció el archivo al plan satisfactoriamente!", 3, "");
                        GrillaArchivoPlanes();
                        CargaArchivosPlanes();
                    }
                    else
                    {
                        int trans = 9;
                        TcPrincipal.ActiveTabIndex = 0;
                        string script = @"<script type='text/javascript'>FocusPeriodo(" + trans + ");" + "</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                        NombrePlan.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al cargar archivo: " + ex.Message.ToString(), 1, "Error");

            }
        }

        protected void GvFiltroCarga_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            RowGridArchivoPlan = Convert.ToInt16(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Descargar":
                    //descargarArchivo();
                    mtdDescargarPdfRiesgo();
                    break;
            }
        }

        protected void GvRiesgosAsociados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RowGridGridRiesgosAsociados = e.NewPageIndex;
            GvRiesgosAsociados.PageIndex = RowGridGridRiesgosAsociados;
            GvRiesgosAsociados.DataSource = InfoGridRiesgosAsociados;
            GvRiesgosAsociados.DataBind();
        }

        protected void GvRiesgosAsociados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            RowGridGridRiesgosAsociados = Convert.ToInt16(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Desasociar":
                    MensajeModalRiesgo.Text = "¿Está seguro que desea Desasociar el riesgo?";
                    MPRiesgo.Show();
                    break;
            }
        }

        protected void GvEventosAsociados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridEventosAsociados = e.NewPageIndex;
            GvEventosAsociados.PageIndex = PagIndexInfoGridEventosAsociados;
            GvEventosAsociados.DataSource = InfoGridEventosAsociados;
            GvEventosAsociados.DataBind();
        }

        protected void GvEventosAsociados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PagIndexInfoGridEventosAsociados = Convert.ToInt16(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Desasociar":
                    MensajeModalEvento.Text = "¿Está seguro que desea Desasociar el evento?";
                    MPEvento.Show();
                    break;
            }
        }

        protected void EliminarRiesgo_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = GvRiesgosAsociados.Rows[Convert.ToInt16(RowGridGridRiesgosAsociados)];
                System.Collections.Specialized.IOrderedDictionary colsNoVisible = GvRiesgosAsociados.DataKeys[Convert.ToInt16(RowGridGridRiesgosAsociados)].Values;
                int id = Convert.ToInt32(colsNoVisible[0]);
                string CodigoRiesgo = colsNoVisible[2].ToString();

                DesasociarRiesgo(id, CodigoRiesgo);
                omb.ShowMessage("Se desasoció el riesgo satisfactoriamente !", 3, "Atención");
                objPlanes.Codigo = colsNoVisible[1].ToString();
                CargaGvRiesgosAsociados();
                LlenarGvRiesgosAsociados();

            }
            catch (Exception)
            {

                omb.ShowMessage("Error al eliminar el riesgo", 1, "Error");
            }

        }

        protected void EliminarEvento_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = GvEventosAsociados.Rows[Convert.ToInt16(PagIndexInfoGridEventosAsociados)];
                System.Collections.Specialized.IOrderedDictionary colsNoVisible = GvEventosAsociados.DataKeys[Convert.ToInt16(PagIndexInfoGridEventosAsociados)].Values;
                int id = Convert.ToInt32(colsNoVisible[0]);
                string CodigoEvento = colsNoVisible[1].ToString();

                DesasociarEvento(id, CodigoEvento);
                omb.ShowMessage("Se desasoció el riesgo satisfactoriamente !", 3, "Atención");
                objPlanes.Codigo = colsNoVisible[2].ToString();
                CargaGvEventosAsociados();
                LlenarGvEventosAsociados();
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al eliminar el evento", 1, "Error");
            }
        }

        protected void CancelarC_Click(object sender, EventArgs e)
        {
            ModalGestion.Text = string.Empty;
        }

        protected void GuardarCumplimiento_Click(object sender, EventArgs e)
        {
            try
            {
                string Gestion = ModalGestion.Text;
                objPlanes.Gestion = Convert.ToInt32(Gestion);
                GuardarGestion();
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error en GuardarCumplimiento " + ex.Message.ToString(), 1, "Error");
            }
        }
        #endregion Eventos

        //Métodos 
        #region Métodos
        private void TvPopUp()
        {
            DataTable treeViewData = GetTreeViewData();
            AddTopTreeViewNodes(treeViewData);
            TvResponsable.ExpandAll();
        }
        private void mtdInicializarValores()
        {
            pagIndexPlanes = 0;
        }
        private void UltimoCodigo()
        {
            DataTable dt = UltimoCodigoPlan();
            CodigoPlan.Text = dt.Rows[0]["Codigo"].ToString().Trim();
        }
        private void GrillaPlanes()
        {
            DataTable grid = new DataTable();

            grid.Columns.Add("Codigo", typeof(string));
            grid.Columns.Add("NombrePlan", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Estado", typeof(string));
            grid.Columns.Add("EditarRegistro", typeof(string));

            GvPlanes.DataSource = grid;
            GvPlanes.DataBind();
            TodosPlanes = grid;
        }
        public bool CargarGrillaPlanes()
        {
            bool resultado = false;

            int IdTransaccion = 0;
            try
            {
                listaPlanes = cPlanes.ConsultarPlanes(ref listaPlanes, objPlanes, IdTransaccion, string.Empty);
                if (listaPlanes != null)
                {
                    GrillaPlanes();
                    CargaPlanes(listaPlanes);
                    GvPlanes.DataSource = listaPlanes;
                    GvPlanes.PageIndex = pagIndexPlanes;
                    GvPlanes.DataBind();
                    resultado = true;
                    GvPlanes.Visible = true;
                    GvPlanesFiltro.Visible = false;
                }
                else
                {
                    omb.ShowMessage("No hay planes registrados", 2, "Atención");
                }

                FiltroCodigoPlan.Focus();
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al procesar carga de planes: " + ex.Message.ToString(), 1, "Error");
            }

            return resultado;
        }
        public bool CargarGrillaPlanesFiltro(string CodigoPlan, string NombrePlan)
        {
            bool resultado = false;

            try
            {
                DataTable dtFiltroPlan = new DataTable();
                dtFiltroPlan = ConsultaPlanesFiltro(CodigoPlan, NombrePlan);
                int Cuantos = dtFiltroPlan.Rows.Count;
                // Llenar la grilla 
                if (dtFiltroPlan.Rows.Count > 0)
                {
                    for (int i = 0; i < dtFiltroPlan.Rows.Count; i++)
                    {
                        TodosPlanes.Rows.Add(new object[]
                            {
                                 dtFiltroPlan.Rows[i]["CodigoPlan"].ToString().Trim(),
                                 dtFiltroPlan.Rows[i]["NombrePlan"].ToString().Trim(),
                                 dtFiltroPlan.Rows[i]["Usuario"].ToString().Trim(),
                                 dtFiltroPlan.Rows[i]["FechaRegistro"].ToString().Trim(),
                            });
                    }
                    GvPlanes.PageIndex = pagIndexPlanes;
                    GvPlanes.DataSource = TodosPlanes;
                    GvPlanes.DataBind();

                    CuantosPlanes.Text = Convert.ToString(Cuantos);
                    PanelFiltroPlanes.Visible = true;
                }
                else
                {
                    omb.ShowMessage("No se encontraron resultados con los parámetros de búsqueda!", 2, "Atención");
                    CuantosPlanes.Text = Convert.ToString(0);
                    PanelFiltroPlanes.Visible = true;
                    FiltroCodigoPlan.Focus();
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al cargar los planes: " + ex.Message.ToString(), 1, "Error");
            }

            return resultado;
        }
        private void GrillaCumplimiento()
        {
            DataTable grid = new DataTable();

            grid.Columns.Add("Id", typeof(string));
            grid.Columns.Add("Periodo", typeof(string));
            grid.Columns.Add("Meta", typeof(string));
            grid.Columns.Add("Cumplimiento", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Editar", typeof(string));

            GvCumplimiento.DataSource = grid;
            GvCumplimiento.DataBind();
            InfoGridCumplimiento = grid;
        }
        public bool CargarGrillaCumplimiento()
        {
            bool resultado = false;

            try
            {
                DataTable dtCumplimiento = new DataTable();

                dtCumplimiento = ConsultaCumplimiento(CodigoPlan.Text);
                // Llenar la grilla 
                if (dtCumplimiento.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCumplimiento.Rows.Count; i++)
                    {
                        InfoGridCumplimiento.Rows.Add(new object[]
                            {
                                 dtCumplimiento.Rows[i]["Id"].ToString().Trim(),
                                 dtCumplimiento.Rows[i]["Periodo"].ToString().Trim(),
                                 dtCumplimiento.Rows[i]["Meta"].ToString().Trim(),
                                 dtCumplimiento.Rows[i]["Cumplimiento"].ToString().Trim(),
                                 dtCumplimiento.Rows[i]["FechaRegistro"].ToString().Trim(),
                            });
                    }
                    GvCumplimiento.PageIndex = pagIndexCumplimiento;
                    GvCumplimiento.DataSource = InfoGridCumplimiento;
                    GvCumplimiento.DataBind();
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("No se pudo cargar el Cumplimiento: " + ex.Message.ToString(), 1, "Error");
            }

            return resultado;
        }
        private void GrillaSeguimiento()
        {
            DataTable grid = new DataTable();

            grid.Columns.Add("CodigoPlan", typeof(string));
            grid.Columns.Add("Seguimiento", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));

            GvSeguimiento.DataSource = grid;
            GvSeguimiento.DataBind();
            InfoGridSeguimiento = grid;
        }
        public bool CargarGrillaSeguimiento()
        {
            bool resultado = false;
            Usuario.Text = Session["NombreUsuario"].ToString();
            FechaSeguimiento.Text = Convert.ToString(DateTime.Now.ToShortDateString());
            try
            {
                DataTable dtSeguimiento = new DataTable();

                dtSeguimiento = ConsultaSeguimiento(CodigoPlan.Text);
                // Llenar la grilla 
                if (dtSeguimiento.Rows.Count > 0)
                {
                    for (int i = 0; i < dtSeguimiento.Rows.Count; i++)
                    {
                        InfoGridSeguimiento.Rows.Add(new object[]
                            {
                                 dtSeguimiento.Rows[i]["CodigoPlan"].ToString().Trim(),
                                 dtSeguimiento.Rows[i]["Seguimiento"].ToString().Trim(),
                                 dtSeguimiento.Rows[i]["Usuario"].ToString().Trim(),
                                 dtSeguimiento.Rows[i]["FechaRegistro"].ToString().Trim(),
                            });
                    }
                    GvSeguimiento.PageIndex = pagIndexSeguimiento;
                    GvSeguimiento.DataSource = InfoGridSeguimiento;
                    GvSeguimiento.DataBind();
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("No se pudo cargar el Seguimiento: " + ex.Message.ToString(), 1, "Error");
            }

            return resultado;
        }
        private void CargaPlanes(List<clsDTOPlanes> listaPlanes)
        {
            string strErrMsg = string.Empty;

            foreach (clsDTOPlanes objPlanes in listaPlanes)
            {

                TodosPlanes.Rows.Add(new object[] {
                    objPlanes.Codigo.ToString().Trim(),
                    objPlanes.NombrePlan.ToString().Trim(),
                    objPlanes.Usuario.ToString().Trim(),
                    objPlanes.FechaRegistro.ToString().Trim(),
                    objPlanes.Usuario.ToString().Trim()
                    });
            }
        }
        private bool RegistrarPlan(ref clsDTOPlanes objPlanes, int Transaccion, string estadoPlan)
        {
            bool resultado = false;
            try
            {
                listaPlanes = cPlanes.ConsultarPlanes(ref listaPlanes, objPlanes, Transaccion, string.Empty);
                if (Transaccion == 2)
                {
                    foreach (clsDTOPlanes item in listaPlanes)
                    {
                        CodigoPlan.Text = item.Codigo;
                        NombrePlan.Text = item.NombrePlan;
                        Descripcion.Text = item.DescripcionPlan;
                        Responsable.Text = item.Responsable;
                        FechaCompromiso.Text = item.FechaCompromiso == Convert.ToDateTime("1900-01-01 00:00:00.000") ? "9999-12-31" : Convert.ToString(item.FechaCompromiso);
                        FechaImplementacion.Text = item.FechaImplementacion == Convert.ToDateTime("1900-01-01 00:00:00.000") ? "9999-12-31" : Convert.ToString(item.FechaImplementacion);
                        FechaExtension.Text = item.FechaExtension == Convert.ToDateTime("1900-01-01 00:00:00.000") ? "9999-12-31" : Convert.ToString(item.FechaExtension);

                        EstadoPlan.Items.Clear();
                        mtdCargarEstadosPlanAccion();
                        DataTable dtInfo = new DataTable();
                        //dtInfo = cRiesgo.loadDDLNombreEstado(Convert.ToInt32(item.Estado));
                        dtInfo = cRiesgo.loadDDLNombreEstado(Convert.ToString(item.Estado));
                        //EstadoPlan.SelectedItem.Text = dtInfo.Rows[0][0].ToString().Trim();
                        EstadoPlan.SelectedItem.Text = dtInfo.Rows[0]["NombreEstadoPlanAccion"].ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al registrar plan: " + ex.Message.ToString(), 1, "Error");
            }
            return resultado;
        }
        private void rellenarFechas()
        {
            if (FechaExtension.Text.Trim().Equals("")) FechaExtension.Text = "9999-12-31";
            if (FechaImplementacion.Text.Trim().Equals("")) FechaImplementacion.Text = "9999-12-31";
        }
        private void validarFechas(clsDTOPlanes objPlanes)
        {
            if (EstadoPlan.SelectedValue.Trim().Equals("13") && FechaExtension.Text.Trim().Equals(""))
                throw new Exception("Para el estado 'Extensión del Comité', es obligatoria la Fecha de Extensión");

            if ((EstadoPlan.SelectedValue.Trim().Equals("6") || EstadoPlan.SelectedValue.Trim().Equals("7")) && FechaImplementacion.Text.Trim().Equals(""))
                throw new Exception("Para los estados 'Implementado' y 'Cancelado', es obligatoria la Fecha de Implementación");
        }
        private void LimpiarCamposPlanes()
        {
            //  Descripcion.Text = string.Empty;
            //  Responsable.Text = string.Empty;
            //  EstadoPlan.SelectedIndex = 0;           
            //  FechaCompromiso.Text = string.Empty;
            Justificacion.Text = string.Empty;
            RiesgoAsociar.Text = string.Empty;
            lblRiesgoAsociar.Visible = false;
            lblAsociarEvento.Visible = false;
            RiesgoAsociar.Visible = false;
            AsociarEvento.Text = string.Empty;
            AsociarEvento.Visible = false;
        }

        //Asociar Riesgo
        private void InicializarValoresGvRiesgos()
        {
            PagIndexInfoGridRiesgos = 0;
        }

        private void InicializarValoresGvRiesgosAsociados()
        {
            RowGridGridRiesgosAsociados = 0;
        }

        private void InicializarValoresGvEventosAsociados()
        {
            PagIndexInfoGridEventosAsociados = 0;
        }

        private void CargaGvRiesgos()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("IdRiesgo", typeof(string));
            grid.Columns.Add("IdRegion", typeof(string));
            grid.Columns.Add("IdPais", typeof(string));
            grid.Columns.Add("IdDepartamento", typeof(string));
            grid.Columns.Add("IdCiudad", typeof(string));
            grid.Columns.Add("IdOficinaSucursal", typeof(string));
            grid.Columns.Add("IdCadenaValor", typeof(string));
            grid.Columns.Add("IdMacroproceso", typeof(string));
            grid.Columns.Add("IdProceso", typeof(string));
            grid.Columns.Add("IdSubProceso", typeof(string));
            //grid.Columns.Add("IdActividad", typeof(string));
            grid.Columns.Add("IdClasificacionRiesgo", typeof(string));
            grid.Columns.Add("IdClasificacionGeneralRiesgo", typeof(string));
            grid.Columns.Add("IdClasificacionParticularRiesgo", typeof(string));
            grid.Columns.Add("NombreClasificacionRiesgo", typeof(string));
            grid.Columns.Add("IdFactorRiesgoOperativo", typeof(string));
            grid.Columns.Add("IdTipoRiesgoOperativo", typeof(string));
            grid.Columns.Add("IdTipoEventoOperativo", typeof(string));
            grid.Columns.Add("IdRiesgoAsociadoOperativo", typeof(string));
            grid.Columns.Add("ListaRiesgoAsociadoLA", typeof(string));
            grid.Columns.Add("ListaFactorRiesgoLAFT", typeof(string));
            grid.Columns.Add("Codigo", typeof(string));
            grid.Columns.Add("Nombre", typeof(string));
            grid.Columns.Add("Descripcion", typeof(string));
            grid.Columns.Add("ListaCausas", typeof(string));
            grid.Columns.Add("ListaConsecuencias", typeof(string));
            grid.Columns.Add("IdResponsableRiesgo", typeof(string));
            grid.Columns.Add("IdProbabilidad", typeof(string));
            grid.Columns.Add("OcurrenciaEventoDesde", typeof(string));
            grid.Columns.Add("OcurrenciaEventoHasta", typeof(string));
            grid.Columns.Add("IdImpacto", typeof(string));
            grid.Columns.Add("PerdidaEconomicaDesde", typeof(string));
            grid.Columns.Add("PerdidaEconomicaHasta", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Nombres", typeof(string));
            grid.Columns.Add("NombreHijo", typeof(string));
            grid.Columns.Add("ListaTratamiento", typeof(string));
            grid.Columns.Add("idResponsableTratamiento", typeof(string));
            grid.Columns.Add("Estado", typeof(string));
            InfoGridRiesgos = grid;
            GvFiltroRiesgos.DataSource = InfoGridRiesgos;
            GvFiltroRiesgos.DataBind();
        }

        private void LlenarGvRiesgos()
        {
            DataTable dtInfo = new DataTable();
            if (LCodRiesgo.Text != "")
            {
                dtInfo = cRiesgo.loadInfoRiesgos(Sanitizer.GetSafeHtmlFragment(LCodRiesgo.Text.Trim()), Sanitizer.GetSafeHtmlFragment(NombreRiesgo.Text.Trim()), CadenaValorRiesgo.SelectedValue.ToString().Trim(), MacroprocesoRiesgo.SelectedValue.ToString().Trim(), ProcesoRiesgo.SelectedValue.ToString().Trim(), SubprocesoRiesgo.SelectedValue.ToString().Trim(), RiesgosGlobales.SelectedValue.ToString().Trim(), "---", "");
            }
            else
            {
                dtInfo = cRiesgo.loadInfoRiesgos(Sanitizer.GetSafeHtmlFragment(CodigoRiesgo.Text.Trim()), Sanitizer.GetSafeHtmlFragment(NombreRiesgo.Text.Trim()), CadenaValorRiesgo.SelectedValue.ToString().Trim(), MacroprocesoRiesgo.SelectedValue.ToString().Trim(), ProcesoRiesgo.SelectedValue.ToString().Trim(), SubprocesoRiesgo.SelectedValue.ToString().Trim(), RiesgosGlobales.SelectedValue.ToString().Trim(), "---", "");
            }
            if (dtInfo.Rows.Count > 0)
            {
                for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                {
                    InfoGridRiesgos.Rows.Add(new object[] {dtInfo.Rows[rows]["IdRiesgo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdRegion"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdPais"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdDepartamento"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdCiudad"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdOficinaSucursal"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdCadenaValor"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdMacroproceso"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdProceso"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdSubProceso"].ToString().Trim(),
                                                           //dtInfo.Rows[rows]["IdActividad"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdClasificacionRiesgo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdClasificacionGeneralRiesgo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdClasificacionParticularRiesgo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["NombreClasificacionRiesgo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdFactorRiesgoOperativo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdTipoRiesgoOperativo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdTipoEventoOperativo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdRiesgoAsociadoOperativo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["ListaRiesgoAsociadoLA"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["ListaFactorRiesgoLAFT"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["Codigo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["Nombre"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["Descripcion"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["ListaCausas"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["ListaConsecuencias"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdResponsableRiesgo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdProbabilidad"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["OcurrenciaEventoDesde"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["OcurrenciaEventoHasta"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["IdImpacto"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["PerdidaEconomicaDesde"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["PerdidaEconomicaHasta"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["Nombres"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["NombreHijo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["ListaTratamiento"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["idResponsableTratamiento"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["Estado"].ToString().Trim()
                                                          });
                }
                GvFiltroRiesgos.PageIndex = PagIndexInfoGridRiesgos;
                GvFiltroRiesgos.DataSource = InfoGridRiesgos;
                GvFiltroRiesgos.DataBind();
            }
            else
            {
                //loadGridRiesgos();
                //Mensaje("El registro no existe o su información no es suficiente para ser visualizada.");
            }
        }

        private void CargaGvRiesgosAsociados()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("Id", typeof(string));
            grid.Columns.Add("CodigoPlan", typeof(string));
            grid.Columns.Add("CodigoRiesgo", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));

            InfoGridRiesgosAsociados = grid;
            GvRiesgosAsociados.DataSource = InfoGridRiesgosAsociados;
            GvRiesgosAsociados.DataBind();
        }

        private void LlenarGvRiesgosAsociados()
        {
            DataTable dtInfo = new DataTable();
            dtInfo = ConsultaRiesgosAsociados(CodigoPlan.Text);

            if (dtInfo.Rows.Count > 0)
            {
                for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                {
                    InfoGridRiesgosAsociados.Rows.Add(new object[] {dtInfo.Rows[rows]["Id"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["CodigoPlan"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["CodigoRiesgo"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["Usuario"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                          });
                }
                GvRiesgosAsociados.PageIndex = RowGridGridRiesgosAsociados;
                GvRiesgosAsociados.DataSource = InfoGridRiesgosAsociados;
                GvRiesgosAsociados.DataBind();
            }
            else
            {
                //loadGridRiesgos();
                //Mensaje("El registro no existe o su información no es suficiente para ser visualizada.");
            }
        }

        private void CargaGvEventosAsociados()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("Id", typeof(string));
            grid.Columns.Add("CodigoPlan", typeof(string));
            grid.Columns.Add("CodigoEvento", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));

            InfoGridEventosAsociados = grid;
            GvEventosAsociados.DataSource = InfoGridEventosAsociados;
            GvEventosAsociados.DataBind();
        }

        private void LlenarGvEventosAsociados()
        {
            DataTable dtInfo = new DataTable();
            dtInfo = ConsultaEventosAsociados(CodigoPlan.Text);

            if (dtInfo.Rows.Count > 0)
            {
                for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                {
                    InfoGridEventosAsociados.Rows.Add(new object[] { dtInfo.Rows[rows]["Id"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["CodigoPlan"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["CodigoEvento"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                           dtInfo.Rows[rows]["Usuario"].ToString().Trim(),
                                                          });
                }
                GvEventosAsociados.PageIndex = PagIndexInfoGridEventosAsociados;
                GvEventosAsociados.DataSource = InfoGridEventosAsociados;
                GvEventosAsociados.DataBind();
            }
            else
            {
                //loadGridRiesgos();
                //Mensaje("El registro no existe o su información no es suficiente para ser visualizada.");
            }
        }

        private void CargarCargaCadenaValor()
        {

            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLCadenaValor();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    CadenaValorRiesgo.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreCadenaValor"].ToString().Trim(), dtInfo.Rows[i]["IdCadenaValor"].ToString()));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarMacroproceso(string IdCadenaValor, int Tipo)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLMacroproceso(IdCadenaValor);
                switch (Tipo)
                {
                    case 1:
                        for (int i = 0; i < dtInfo.Rows.Count; i++)
                        {
                            MacroprocesoRiesgo.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreMacroproceso"].ToString().Trim(), dtInfo.Rows[i]["IdMacroproceso"].ToString()));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al cargar macroproceso: " + ex.Message.ToString(), 1, "Error");
            }
        }

        private void CargarProcesoRiesgo(string IdMacroproceso, int Tipo)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLProceso(IdMacroproceso);
                switch (Tipo)
                {
                    case 1:
                        for (int i = 0; i < dtInfo.Rows.Count; i++)
                        {
                            ProcesoRiesgo.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreProceso"].ToString().Trim(), dtInfo.Rows[i]["IdProceso"].ToString()));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("No se pudo cargar el combo proceso: " + ex.Message.ToString(), 1, "Error");
            }
        }

        private void CargarSubProcesoRiesgo(string IdProcesoRiesgo, int Tipo)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLSubProceso(IdProcesoRiesgo);
                switch (Tipo)
                {
                    case 1:
                        for (int i = 0; i < dtInfo.Rows.Count; i++)
                        {
                            SubprocesoRiesgo.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreSubProceso"].ToString().Trim(), dtInfo.Rows[i]["IdSubProceso"].ToString()));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("No se pudo cargar el combo proceso: " + ex.Message.ToString(), 1, "Error");
            }
        }

        private void CargarRiesgosGlobales(string IdSubProcesoRiesgo, int Tipo)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLClasificacion();
                switch (Tipo)
                {
                    case 1:
                        for (int i = 0; i < dtInfo.Rows.Count; i++)
                        {
                            RiesgosGlobales.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreClasificacionRiesgo"].ToString().Trim(), dtInfo.Rows[i]["IdClasificacionRiesgo"].ToString()));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("No se pudo cargar el combo proceso: " + ex.Message.ToString(), 1, "Error");
            }
        }

        private void CargarPDARiesgosGlobales()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLClasificacion();

                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    PDARiesgoGLobal.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreClasificacionRiesgo"].ToString().Trim(), dtInfo.Rows[i]["IdClasificacionRiesgo"].ToString()));
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("No se pudo cargar los riesgos globales: " + ex.Message.ToString(), 1, "Error");
            }
        }

        private void LimpiarPDA()
        {
            PDARiesgoGLobal.Items.Clear();
            PDARiesgoGLobal.Items.Insert(0, new ListItem("---", "---"));
        }

        private void LimpiarFiltroRiesgos()
        {
            CodigoRiesgo.Text = string.Empty;
            CadenaValorRiesgo.SelectedIndex = 0;
            MacroprocesoRiesgo.Items.Clear();
            MacroprocesoRiesgo.Items.Insert(0, new ListItem("---", "---"));
            ProcesoRiesgo.SelectedIndex = 0;
            ProcesoRiesgo.Items.Insert(0, new ListItem("---", "---"));
            SubprocesoRiesgo.Items.Clear();
            SubprocesoRiesgo.Items.Insert(0, new ListItem("---", "---"));
            RiesgosGlobales.SelectedIndex = 0;
            RiesgoAsociar.Text = string.Empty;
            lblRiesgoAsociar.Visible = false;
            lblAsociarEvento.Visible = false;
            RiesgoAsociar.Visible = false;
            lblRiesgosEncontrados.Visible = false;
            TbRiesgos.Visible = false;
        }

        private void LimpiarFiltroEventos()
        {
            CodigoEvento.Text = string.Empty;
            AsociarEvento.Text = string.Empty;
            AsociarEvento.Visible = false;
        }

        private void LimpiarCumplimiento()
        {
            Periodo.Text = string.Empty;
            Meta.Text = string.Empty;
            // Cumplimiento.Text = string.Empty;
        }

        private void LimpiarSeguimiento()
        {
            Seguimiento.Text = string.Empty;
        }

        private void AsociarRiesgo(string CodigoRiesgo)
        {
            RiesgoAsociar.Text = CodigoRiesgo;
            lblRiesgoAsociar.Visible = true;
            RiesgoAsociar.Visible = true;
            lblRiesgosEncontrados.Visible = false;
            GvFiltroRiesgos.Visible = false;
        }

        //Asociar Evento
        private void AsociaEvento(string CodigoEvento)
        {
            AsociarEvento.Text = CodigoEvento;
            AsociarEvento.Visible = true;
            lblAsociarEvento.Visible = true;
            GvFiltroEventos.Visible = false;
            lblEventosEncontrados.Visible = false;
        }

        private void InicializarValoresGvEventos()
        {
            PagIndexInfoGridEventos = 0;
        }



        private void inicializarValores()
        {
            PagIndexInfoGridEventos = 0;
        }

        private void CargaGvEventos()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("IdEvento", typeof(string));
            grid.Columns.Add("CodigoEvento", typeof(string));
            grid.Columns.Add("DescripcionEvento", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));

            InfoGridEventos = grid;
            GvFiltroEventos.DataSource = InfoGridEventos;
            GvFiltroEventos.DataBind();
        }

        private void LlenarGvEventos()
        {
            DataTable dtInfo = new DataTable();
            int IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
            int IdUsuarioJerarquia = Convert.ToInt32(Session["IdJerarquia"].ToString());

            cEvento cEvento = new cEvento();
            DataTable DtIdArea = cEvento.TipoArea(Convert.ToString(IdUsuarioJerarquia));
            string IdPadre = DtIdArea.Rows[0]["IdPadre"].ToString();
            string TipoArea = DtIdArea.Rows[0]["TipoArea"].ToString();


            dtInfo = Eventos.loadInfoEventos(Sanitizer.GetSafeHtmlFragment(CodigoEvento.Text.Trim()), Sanitizer.GetSafeHtmlFragment(DescripcionEvento.Text.Trim()),
                 CodigoPlan.Text);



            if (dtInfo.Rows.Count > 0)
            {
                for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                {
                    lblEventosEncontrados.Visible = true;
                    TbEventos.Visible = true;
                    InfoGridEventos.Rows.Add(new Object[] {
                                                            dtInfo.Rows[rows]["IdEvento"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["CodigoEvento"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["DescripcionEvento"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["Usuario"].ToString().Trim(),
                                                          });
                }

                GvFiltroEventos.PageIndex = pagIndexInfoGridEventos;
                GvFiltroEventos.DataSource = InfoGridEventos;
                GvFiltroEventos.DataBind();
            }
            else
            {
                CargaGvEventos();
                lblEventosEncontrados.Visible = false;
                TbEventos.Visible = false;
                omb.ShowMessage("El usuario no tiene eventos reportados", 2, "Atención");
            }
        }

        // Carga de Archivos
        private void CargarArchivoPlanes()
        {
            #region Vars
            DataTable dtInfo = new DataTable();
            string strNombreArchivo = string.Empty, strIdControl = "3";
            cControl cControlCarga = new cControl();
            #endregion Vars

            dtInfo = cControlCarga.CuantosCargados();

            #region Nombre Archivo
            if (dtInfo.Rows.Count > 0)
            {

                strNombreArchivo = CodigoPlan + "-" + DateTime.Now + "-" + FUCarga.FileName.ToString().Trim();
            }
            else
            {
                strNombreArchivo = CodigoPlan.Text + "-" + DateTime.Now + "-" + FUCarga.FileName.ToString().Trim();
            }
            #endregion Nombre Archivo

            Stream fs = FUCarga.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bPdfData = br.ReadBytes((int)fs.Length);

            cRiesgo.InsertarArchivo(strIdControl, CodigoPlan.Text, strNombreArchivo, bPdfData);
        }

        private void GrillaArchivoPlanes()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("CodPlan", typeof(string));
            grid.Columns.Add("NombreUsuario", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("UrlArchivo", typeof(string));
            InfoGridArchivoPlanes = grid;
            GvFiltroCarga.DataSource = InfoGridArchivoPlanes;
            GvFiltroCarga.DataBind();
        }

        private void CargaArchivosPlanes()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.ConsultarArchivosPlanes(CodigoPlan.Text);
                if (dtInfo.Rows.Count > 0)
                {
                    for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                    {
                        InfoGridArchivoPlanes.Rows.Add(new object[] {dtInfo.Rows[rows]["CodPlan"].ToString().Trim(),
                                                                 dtInfo.Rows[rows]["NombreUsuario"].ToString().Trim(),
                                                                 dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                                 dtInfo.Rows[rows]["UrlArchivo"].ToString().Trim()
                                                                });
                    }
                    GvFiltroCarga.DataSource = InfoGridArchivoPlanes;
                    GvFiltroCarga.DataBind();
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al procesar Archivos Cargados: " + ex.Message.ToString(), 1, "Error");
            }

        }

        private void mtdDescargarPdfRiesgo()
        {
            #region Vars
            string strNombreArchivo = InfoGridArchivoPlanes.Rows[RowGridArchivoPlan]["UrlArchivo"].ToString().Trim();
            byte[] bPdfData = cRiesgo.DescargarArchivoPlan(strNombreArchivo);
            #endregion Vars

            if (bPdfData != null)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "Application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + strNombreArchivo);
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bPdfData);
                Response.End();
            }
        }

        private void GrillaJustificacion()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("CodPlan", typeof(string));
            grid.Columns.Add("Justificacion", typeof(string));
            grid.Columns.Add("NombreUsuario", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));

            InfoGridJustificacion = grid;
            GvJustificacionCambios.DataSource = InfoGridJustificacion;
            GvJustificacionCambios.DataBind();
        }

        private void CargaGrillaJustificacion()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.ConsultarJustificacion(CodigoPlan.Text);
                if (dtInfo.Rows.Count > 0)
                {
                    for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                    {
                        InfoGridJustificacion.Rows.Add(new object[] {dtInfo.Rows[rows]["CodPlan"].ToString().Trim(),
                                                                 dtInfo.Rows[rows]["Justificacion"].ToString().Trim(),
                                                                 dtInfo.Rows[rows]["NombreUsuario"].ToString().Trim(),
                                                                 dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                                });
                    }
                    GvJustificacionCambios.DataSource = InfoGridJustificacion;
                    GvJustificacionCambios.DataBind();
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error al procesar Grilla Justificacion: " + ex.Message.ToString(), 1, "Error");
            }

        }

        private bool GuardarGestion()
        {
            bool resultado = false;
            try
            {
                int CalculoCumplimiento = 0;

                CalculoCumplimiento = (objPlanes.Gestion * MetaGestion) / 100;
                if (CalculoCumplimiento <= 100)
                {
                    cRiesgo.GuardarGestion(IdGestion, objPlanes.Gestion, CalculoCumplimiento);
                    omb.ShowMessage("Se ha guardado la información satisfactoriamente!", 3, "Atención");
                    ModalGestion.Text = string.Empty;
                    GrillaCumplimiento();
                    CargarGrillaCumplimiento();
                }
                else
                {
                    omb.ShowMessage("El valor supera el 100%, intente con otro!", 1, "Atención");
                    ModalGestion.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Error en método GuardarCumplimiento: " + ex.Message.ToString(), 1, "Error");
            }

            return resultado;
        }

        //Exportar
        public void exportExcel(DataTable dt, HttpResponse Response, string filename)
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                workbook.Worksheets.Add(dt);

                HttpResponse httpResponse = Response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + filename + ".xlsx\"");

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();

                }
                httpResponse.End();
            }
            catch (Exception ex)
            {
                //omb.ShowMessage("Error al exportar el reporte de usuarios: Error  ->" + ex.Message.ToString(), 3, "Error");
            }
            finally
            {

            }

        }

        //Enviar correo
        private bool EnviarNotificacion(int idEvento, int idRegistro, int idNodoJerarquia, string FechaFinal, string textoAdicional)
        {
            bool err = false;
            string Destinatario = "", Copia = "", Asunto = "", Otros = "", Cuerpo = "", NroDiasRecordatorio = "";
            string selectCommand = "", AJefeInmediato = "", AJefeMediato = "", RequiereFechaCierre = "";
            string idJefeInmediato = "", idJefeMediato = "";
            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;

            try
            {
                //Consulta la informacion basica necesario para enviar el correo de la tabla correos destinatarios
                selectCommand = "SELECT CD.Copia,CD.Otros,CD.Asunto,CD.Cuerpo,CD.NroDiasRecordatorio,CD.AJefeInmediato,CD.AJefeMediato,E.RequiereFechaCierre FROM [Notificaciones].[CorreosDestinatarios] AS CD, [Notificaciones].[Evento] AS E WHERE E. IdEvento = '" + idEvento + "' AND CD.IdEvento = E.IdEvento";
                SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
                DataTable dtblDiscuss = new DataTable();
                dad.Fill(dtblDiscuss);
                DataView view = new DataView(dtblDiscuss);

                foreach (DataRowView row in view)
                {
                    Copia = row["Copia"].ToString().Trim();
                    Otros = row["Otros"].ToString().Trim();
                    Asunto = row["Asunto"].ToString().Trim();
                    Cuerpo = textoAdicional + "<br />***Nota: " + row["Cuerpo"].ToString().Trim();
                    NroDiasRecordatorio = row["NroDiasRecordatorio"].ToString().Trim();
                    AJefeInmediato = row["AJefeInmediato"].ToString().Trim();
                    AJefeMediato = row["AJefeMediato"].ToString().Trim();
                    RequiereFechaCierre = row["RequiereFechaCierre"].ToString().Trim();
                }

                selectCommand = "SELECT  Parametrizacion.DetalleJerarquiaOrg.CorreoResponsable FROM Parametrizacion.JerarquiaOrganizacional LEFT JOIN Parametrizacion.DetalleJerarquiaOrg ON Parametrizacion.JerarquiaOrganizacional.idHijo = Parametrizacion.DetalleJerarquiaOrg.idHijo where Parametrizacion.JerarquiaOrganizacional.NombreHijo='" + Responsable.Text + "'";
                dad = new SqlDataAdapter(selectCommand, conString);
                dtblDiscuss = new DataTable();
                dad.Fill(dtblDiscuss);
                view = new DataView(dtblDiscuss);

                foreach (DataRowView row in view)
                {
                    Copia = Copia + ", " + row["CorreoResponsable"].ToString().Trim();
                }




                //Consulta el correo del Destinatario segun el nodo de la Jerarquia Organizacional
                selectCommand = "SELECT DJ.CorreoResponsable, JO.idPadre FROM [Parametrizacion].[JerarquiaOrganizacional] AS JO, [Parametrizacion].[DetalleJerarquiaOrg] AS DJ WHERE JO.idHijo = '" + idNodoJerarquia + "' AND DJ.idHijo = JO.idHijo";
                dad = new SqlDataAdapter(selectCommand, conString);
                dtblDiscuss.Clear();
                dad.Fill(dtblDiscuss);
                view = new DataView(dtblDiscuss);

                foreach (DataRowView row in view)
                {
                    Destinatario = row["CorreoResponsable"].ToString().Trim();
                    idJefeInmediato = row["idPadre"].ToString().Trim();
                }

                //Consulta el correo del Jefe Inmediato
                if (AJefeInmediato == "SI")
                {
                    selectCommand = "SELECT DJ.CorreoResponsable, JO.idPadre FROM [Parametrizacion].[JerarquiaOrganizacional] AS JO, [Parametrizacion].[DetalleJerarquiaOrg] AS DJ WHERE JO.idHijo = '" + idJefeInmediato + "' AND DJ.idHijo = JO.idHijo";
                    dad = new SqlDataAdapter(selectCommand, conString);
                    dtblDiscuss.Clear();
                    dad.Fill(dtblDiscuss);
                    view = new DataView(dtblDiscuss);

                    foreach (DataRowView row in view)
                    {
                        Destinatario = Destinatario + ";" + row["CorreoResponsable"].ToString().Trim();
                        idJefeMediato = row["idPadre"].ToString().Trim();
                    }
                }

                //Consulta el correo del Jefe Mediato
                if (AJefeMediato == "SI")
                {
                    selectCommand = "SELECT DJ.CorreoResponsable, JO.idPadre FROM [Parametrizacion].[JerarquiaOrganizacional] AS JO, [Parametrizacion].[DetalleJerarquiaOrg] AS DJ WHERE JO.idHijo = '" + idJefeMediato + "' AND DJ.idHijo = JO.idHijo";
                    dad = new SqlDataAdapter(selectCommand, conString);
                    dtblDiscuss.Clear();
                    dad.Fill(dtblDiscuss);
                    view = new DataView(dtblDiscuss);

                    foreach (DataRowView row in view)
                    {
                        Destinatario = Destinatario + ";" + row["CorreoResponsable"].ToString().Trim();
                    }
                }

                //Insertar el Registro en la tabla de Correos Enviados
                SqlDataSource200.InsertParameters["Destinatario"].DefaultValue = Destinatario.Trim();
                SqlDataSource200.InsertParameters["Copia"].DefaultValue = Copia;
                SqlDataSource200.InsertParameters["Otros"].DefaultValue = Otros;
                SqlDataSource200.InsertParameters["Asunto"].DefaultValue = Asunto;
                SqlDataSource200.InsertParameters["Cuerpo"].DefaultValue = Cuerpo;
                SqlDataSource200.InsertParameters["Estado"].DefaultValue = "POR ENVIAR";
                SqlDataSource200.InsertParameters["Tipo"].DefaultValue = "CIERRE";
                SqlDataSource200.InsertParameters["FechaEnvio"].DefaultValue = "";
                SqlDataSource200.InsertParameters["IdEvento"].DefaultValue = idEvento.ToString().Trim();
                SqlDataSource200.InsertParameters["IdRegistro"].DefaultValue = idRegistro.ToString().Trim();
                SqlDataSource200.InsertParameters["IdUsuario"].DefaultValue = Session["idUsuario"].ToString().Trim(); //Aca va el id del Usuario de la BD
                SqlDataSource200.InsertParameters["FechaRegistro"].DefaultValue = System.DateTime.Now.ToString().Trim();
                SqlDataSource200.Insert();
            }
            catch (Exception except)
            {
                // Handle the Exception.
                omb.ShowMessage("Error en el envío de la notificación." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
                err = true;
            }

            if (!err)
            {
                // Si no existe error en la creacion del registro en el log de correos enviados se procede a escribir en la tabla CorreosRecordatorios y a enviar el correo 
                if (RequiereFechaCierre == "SI" && FechaFinal != "")
                {
                    //Si los NroDiasRecordatorio es diferente de vacio se inserta el registro correspondiente en la tabla CorreosRecordatorio
                    SqlDataSource201.InsertParameters["IdCorreosEnviados"].DefaultValue = LastInsertIdCE.ToString().Trim();
                    SqlDataSource201.InsertParameters["NroDiasRecordatorio"].DefaultValue = NroDiasRecordatorio;
                    SqlDataSource201.InsertParameters["Estado"].DefaultValue = "POR ENVIAR";
                    SqlDataSource201.InsertParameters["FechaFinal"].DefaultValue = FechaFinal;
                    SqlDataSource201.InsertParameters["IdUsuario"].DefaultValue = Session["idUsuario"].ToString().Trim(); //Aca va el id del Usuario de la BD
                    SqlDataSource201.InsertParameters["FechaRegistro"].DefaultValue = System.DateTime.Now.ToString().Trim();
                    SqlDataSource201.Insert();
                }

                try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtpClient = new SmtpClient();
                    MailAddress fromAddress = new MailAddress(((System.Net.NetworkCredential)(smtpClient.Credentials)).UserName, "Software Sherlock");

                    message.From = fromAddress;//here you can set address

                    #region
                    foreach (string substr in Destinatario.Split(';'))
                    {
                        if (!string.IsNullOrEmpty(substr.Trim()))
                        {
                            message.To.Add(substr);
                        }
                    }
                    #endregion

                    #region
                    if (Copia.Trim() != "")
                    {
                        foreach (string substr in Copia.Split(';'))
                        {
                            if (!string.IsNullOrEmpty(substr.Trim()))
                            {
                                message.CC.Add(substr);
                            }
                        }
                    }
                    #endregion

                    #region
                    if (Otros.Trim() != "")
                    {
                        foreach (string substr in Otros.Split(';'))
                        {
                            if (!string.IsNullOrEmpty(substr.Trim()))
                            {
                                message.CC.Add(substr);
                            }
                        }
                    }
                    #endregion

                    message.Subject = Asunto;//subject of email
                    message.IsBodyHtml = true;//To determine email body is html or not
                    message.Body = Cuerpo;

                    smtpClient.Send(message);
                }
                catch (Exception ex)
                {
                    //throw exception here you can write code to handle exception here
                    omb.ShowMessage("Error en el envío de la notificación." + "<br/>" + "Descripción: " + ex.Message.ToString().Trim(), 1, "Atención");
                    err = true;
                }

                if (!err)
                {
                    //Actualiza el Estado del Correo Enviado
                    SqlDataSource200.UpdateParameters["IdCorreosEnviados"].DefaultValue = LastInsertIdCE.ToString().Trim();
                    SqlDataSource200.UpdateParameters["Estado"].DefaultValue = "ENVIADO";
                    SqlDataSource200.UpdateParameters["FechaEnvio"].DefaultValue = System.DateTime.Now.ToString().Trim();
                    SqlDataSource200.Update();
                }
            }

            return (err);
        }

        #endregion Métodos

        protected void GenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtNot = new DataTable();
                DataTable dtExc = new DataTable();
                dtNot = ReportePlanesVencidosNot();
                dtExc = ReportePlanesVencidosExc();


                //dtExc.TableName = "Reporte-Planes-Vencidos";
                ////Excel planes vencidos hasta la fecha
                //if (dtExc.Rows.Count > 0)
                //{
                //    exportExcel(dtExc, Response, "Reporte Planes de Acción " + DateTime.Now + "");
                //}


                //Envío notificación si el plan se vence hoy
                if (dtNot.Rows[0]["CodigoPlan"].ToString() != null)
                {
                    for (int rows = 0; rows < dtNot.Rows.Count; rows++)
                    {
                        string idPadre = dtNot.Rows[rows]["IdPadre"].ToString();
                        string idHijo = dtNot.Rows[rows]["IdHijo"].ToString();
                        string CodigoPlan = dtNot.Rows[rows]["CodigoPlan"].ToString();
                        string NombrePlan = dtNot.Rows[rows]["NombrePlan"].ToString();
                        string NomResponsable = dtNot.Rows[rows]["NombreResponsable"].ToString();
                        string FechaCompromiso = dtNot.Rows[rows]["FechaCompromiso"].ToString();
                        string FechaExtension = dtNot.Rows[rows]["FechaExtension"].ToString();
                        string CuerpoCorreo = string.Empty;

                        CuerpoCorreo = "<B> Código del plan: </B>" + CodigoPlan +
                            "<br /><B> Nombre del plan: </B>" + NombrePlan +
                            "<br /><B> Fecha de Compromiso: </B>" + FechaCompromiso +
                            "<br /><B> Fecha de Extensión: </B>" + FechaExtension +
                            "<br /><B> Responsable: </B>" + NomResponsable +
                            "<br />" +
                            "<br /><B> El plan de acción cumple hoy con la fecha de compromiso y/o extensión. </B>" +
                            "<br />";
                        EnviarNotificacion(23, 0, Convert.ToInt32(idHijo), "", CuerpoCorreo);
                        omb.ShowMessage("Notificaciones enviadas a los correos de los responsables.", 3, "Aviso");
                    }
                }
                else
                {
                    omb.ShowMessage("Ningún plan de acción vence el día de hoy.", 2, "Aviso");
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage("Ningún plan de acción vence el día de hoy.", 2, "Aviso");
            }
        }


        private DataTable ReportePlanesVencidosNot()
        {
            string selectCommand =

            "select distinct PDJ.idHijo, PJO.idPadre, RP.NombrePlan, RP.CodigoPlan, RP.FechaCompromiso, RP.FechaExtension, " +
            "PDJ.NombreResponsable, PDJ.CorreoResponsable " +
            "from Riesgos.planes RP " +
            "LEFT JOIN Parametrizacion.DetalleJerarquiaOrg PDJ ON RP.IdResponsable = PDJ.idHijo " +
            "LEFT JOIN Parametrizacion.JerarquiaOrganizacional PJO ON PDJ.idHijo = PJO.idHijo " +
            "where CONVERT(date,RP.FechaCompromiso) = CONVERT (date, GETDATE()) " +
            "OR CONVERT(date,RP.FechaExtension) = CONVERT (date, GETDATE())";


            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        private DataTable ReportePlanesVencidosExc()
        {
            string selectCommand =

            "select distinct RP.NombrePlan, RP.CodigoPlan, RP.FechaCompromiso, PDJ.NombreResponsable, RP.FechaExtension " +
            "from Riesgos.planes RP " +
            "LEFT JOIN Parametrizacion.DetalleJerarquiaOrg PDJ ON RP.Responsable = PDJ.CargoResponsable " +
            "where CONVERT(date,RP.FechaCompromiso) < CONVERT (date, GETDATE()) " +
            "OR CONVERT(date,RP.FechaExtension) = CONVERT (date, GETDATE());";


            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
            DataTable dtblDiscuss = new DataTable();
            dad.Fill(dtblDiscuss);
            return dtblDiscuss;
        }

        protected void IBconsultar_Click(object sender, ImageClickEventArgs e)
        {

            string strErrMsg = string.Empty;

            int IdAreaInt = 0;
            int IdAreaInt1 = 0;
            string IdArea = "";

            if (DDLArea.SelectedValue != "---")
            {
                IdAreaInt = Convert.ToInt32(DDLArea.SelectedValue);
                IdArea = Convert.ToString(IdAreaInt);
            }
            else
            {
                IdAreaInt1 = 0;
                IdArea = Convert.ToString(IdAreaInt1);
            }
            Session["IdArea"] = IdArea;

            int IdEstadoint = 0;
            int IdEstadoint1 = 0;
            string IdEstado = "";

            if (ddlEstadoFiltro.SelectedValue != "---")
            {
                IdEstadoint = Convert.ToInt32(ddlEstadoFiltro.SelectedValue);
                IdEstado = Convert.ToString(IdEstadoint);
            }
            else
            {
                IdEstadoint1 = 0;
                IdEstado = Convert.ToString(IdEstadoint1);
            }
            Session["IdEstado"] = IdEstado;

            int Responsable1 = 0;
            if (lblIdDependencia4.Text != "")
                Responsable1 = Convert.ToInt32(Sanitizer.GetSafeHtmlFragment(lblIdDependencia4.Text));
            string Responsable = Convert.ToString(Responsable1);
            Session["Responsable"] = Responsable;
            string responsableText = tbxResponsable.Text;

            GrillaPlanesFiltro();
            //CargarGrillaPlanes();

            DataTable dtCarga = new DataTable();
            dtCarga = ConsultaFiltroPlanes(Responsable, responsableText, IdEstado, IdArea);

            if (dtCarga != null)
            {
                if (dtCarga.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtCarga.Rows)
                    {
                        clsDTOPlanes objPlanes = new clsDTOPlanes();
                        objPlanes.Codigo = dr["CodigoPlan"].ToString().Trim();
                        objPlanes.NombrePlan = dr["NombrePlan"].ToString().Trim();
                        objPlanes.Usuario = dr["Usuario"].ToString().Trim();
                        objPlanes.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString().Trim());
                        objPlanes.Responsable = dr["NombreResponsable"].ToString().Trim();
                        objPlanes.Estado = dr["Estado"].ToString().Trim();

                        listaPlanes.Add(objPlanes);
                    }
                }
                else
                { listaPlanes = null; }
            }
            else
            { listaPlanes = null; }

            CargaPlanesFiltro(listaPlanes);

            GvPlanesFiltro.DataSource = listaPlanes;
            GvPlanesFiltro.PageIndex = pagIndexPlanes;
            GvPlanesFiltro.DataBind();

            GvPlanesFiltro.Visible = true;
            GvPlanes.Visible = false;

        }

        private void GrillaPlanesFiltro()
        {
            DataTable grid = new DataTable();

            grid.Columns.Add("Codigo", typeof(string));
            grid.Columns.Add("NombrePlan", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Responsable", typeof(string));
            grid.Columns.Add("Estado", typeof(string));

            GvPlanesFiltro.DataSource = grid;
            GvPlanesFiltro.DataBind();
            TodosPlanes = grid;
        }

        private void CargaPlanesFiltro(List<clsDTOPlanes> listaPlanes)
        {
            string strErrMsg = string.Empty;

            foreach (clsDTOPlanes objPlanes in listaPlanes)
            {

                TodosPlanes.Rows.Add(new object[] {
                    objPlanes.Codigo.ToString().Trim(),
                    objPlanes.NombrePlan.ToString().Trim(),
                    objPlanes.Usuario.ToString().Trim(),
                    objPlanes.FechaRegistro.ToString().Trim(),
                    objPlanes.Responsable.ToString().Trim(),
                    objPlanes.Estado.ToString().Trim()
                    });
            }
        }

        protected void IBcancel_Click(object sender, ImageClickEventArgs e)
        {
            ddlEstadoFiltro.SelectedIndex = 0;
            ddlEstadoFiltro.Items.Clear();
            ddlEstadoFiltro.Items.Insert(0, new ListItem("---", "---"));
            mtdCargarEstadosPlanAccion();
            DDLArea.SelectedIndex = 0;
            DDLArea.Items.Clear();
            DDLArea.Items.Insert(0, new ListItem("---", "---"));
            loadDDLArea();
            tbxResponsable.Text = string.Empty;
            GrillaPlanes();
            CargarGrillaPlanes();
        }

        private DataTable ConsultaFiltroPlanes(string Responsable, string responsableText, string IdEstado, string IdArea)
        {
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            DataTable dtCaracOut = new DataTable();
            String condicion = "";

            if (Responsable != "0" || responsableText == "Banco Ficohsa")
            {
                condicion = "WHERE p.IdResponsable = '" + Responsable + "' ";
            }
            if (IdEstado != "0")
            {
                if (condicion.Trim() == "")
                {
                    condicion = "WHERE PEP.IdEstadoPlanAccion = '" + IdEstado + "' ";
                }
                else
                {
                    condicion += "AND PEP.IdEstadoPlanAccion = '" + IdEstado + "' ";
                }
            }
            if (IdArea != "0")
            {
                if (condicion.Trim() == "")
                {
                    condicion = "WHERE PDJ.IdArea = '" + IdArea + "' ";
                }
                else
                {
                    condicion += "AND PDJ.IdArea = '" + IdArea + "' ";
                }
            }


            strConsulta = string.Format("SELECT DISTINCT p.Id, p.CodigoPlan,p.NombrePlan,p.FechaRegistro,p.Usuario," +
                "PEP.IdEstadoPlanAccion,p.Estado, p.IdResponsable,PDJ.NombreResponsable " +
                "FROM Riesgos.planes p " +
                "LEFT JOIN Parametrizacion.DetalleJerarquiaOrg PDJ ON p.IdResponsable = PDJ.idHijo " +
                "LEFT JOIN Parametrizacion.EstadoPlanAccion PEP ON p.Estado = PEP.NombreEstadoPlanAccion " +
                " " + condicion + " ORDER BY id DESC");

            cDataBase.conectar();
            dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
            cDataBase.desconectar();

            return dtCaracOut;
        }

        protected void SqlDataSource201_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ImagenJerarquia_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Responsable_TextChanged(object sender, EventArgs e)
        {

        }
    } // Fin nombre de espacios
}