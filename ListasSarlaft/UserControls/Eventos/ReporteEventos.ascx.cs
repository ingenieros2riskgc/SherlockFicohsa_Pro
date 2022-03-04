using ListasSarlaft.Classes;
using Microsoft.Security.Application;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListasSarlaft.UserControls.Eventos
{
    public partial class ReporteEventos : System.Web.UI.UserControl
    {
        cRiesgo cRiesgo = new cRiesgo();
        cCuenta cCuenta = new cCuenta();
        cEvsEIncs cEvsEIncs = new cEvsEIncs();
        String IdFormulario = "5015";
        cEvento cEvento = new cEvento();

        #region Properties
        private DataTable infoGridReporteRiesgos;
        private DataTable InfoGridReporteRiesgos
        {
            get
            {
                infoGridReporteRiesgos = (DataTable)ViewState["infoGridReporteRiesgos"];
                return infoGridReporteRiesgos;
            }
            set
            {
                infoGridReporteRiesgos = value;
                ViewState["infoGridReporteRiesgos"] = infoGridReporteRiesgos;
            }
        }

        private int pagIndexInfoGridReporteRiesgos;
        private int PagIndexInfoGridReporteRiesgos
        {
            get
            {
                pagIndexInfoGridReporteRiesgos = (int)ViewState["pagIndexInfoGridReporteRiesgos"];
                return pagIndexInfoGridReporteRiesgos;
            }
            set
            {
                pagIndexInfoGridReporteRiesgos = value;
                ViewState["pagIndexInfoGridReporteRiesgos"] = pagIndexInfoGridReporteRiesgos;
            }
        }

        private DataTable infoGridReporteRiesgosControles;
        private DataTable InfoGridReporteRiesgosControles
        {
            get
            {
                infoGridReporteRiesgosControles = (DataTable)ViewState["infoGridReporteRiesgosControles"];
                return infoGridReporteRiesgosControles;
            }
            set
            {
                infoGridReporteRiesgosControles = value;
                ViewState["infoGridReporteRiesgosControles"] = infoGridReporteRiesgosControles;
            }
        }

        private int pagIndexInfoGridReporteRiesgosControles;
        private int PagIndexInfoGridReporteRiesgosControles
        {
            get
            {
                pagIndexInfoGridReporteRiesgosControles = (int)ViewState["pagIndexInfoGridReporteRiesgosControles"];
                return pagIndexInfoGridReporteRiesgosControles;
            }
            set
            {
                pagIndexInfoGridReporteRiesgosControles = value;
                ViewState["pagIndexInfoGridReporteRiesgosControles"] = pagIndexInfoGridReporteRiesgosControles;
            }
        }

        private DataTable infoGridReporteRiesgosEventos;
        private DataTable InfoGridReporteRiesgosEventos
        {
            get
            {
                infoGridReporteRiesgosEventos = (DataTable)ViewState["infoGridReporteRiesgosEventos"];
                return infoGridReporteRiesgosEventos;
            }
            set
            {
                infoGridReporteRiesgosEventos = value;
                ViewState["infoGridReporteRiesgosEventos"] = infoGridReporteRiesgosEventos;
            }
        }

        private int pagIndexInfoGridReporteRiesgosEventos;
        private int PagIndexInfoGridReporteRiesgosEventos
        {
            get
            {
                pagIndexInfoGridReporteRiesgosEventos = (int)ViewState["pagIndexInfoGridReporteRiesgosEventos"];
                return pagIndexInfoGridReporteRiesgosEventos;
            }
            set
            {
                pagIndexInfoGridReporteRiesgosEventos = value;
                ViewState["pagIndexInfoGridReporteRiesgosEventos"] = pagIndexInfoGridReporteRiesgosEventos;
            }
        }

        private DataTable infoGridReporteEventosIncidentes;
        private DataTable InfoGridReporteEventosIncidentes
        {
            get
            {
                infoGridReporteEventosIncidentes = (DataTable)ViewState["infoGridReporteEventosIncidentes"];
                return infoGridReporteEventosIncidentes;
            }
            set
            {
                infoGridReporteEventosIncidentes = value;
                ViewState["infoGridReporteEventosIncidentes"] = infoGridReporteEventosIncidentes;
            }
        }

        private int pagIndexInfoGridReporteEventosIncidentes;
        private int PagIndexInfoGridReporteEventosIncidentes
        {
            get
            {
                pagIndexInfoGridReporteEventosIncidentes = (int)ViewState["pagIndexInfoGridReporteEventosIncidentes"];
                return pagIndexInfoGridReporteEventosIncidentes;
            }
            set
            {
                pagIndexInfoGridReporteEventosIncidentes = value;
                ViewState["pagIndexInfoGridReporteEventosIncidentes"] = pagIndexInfoGridReporteEventosIncidentes;
            }
        }

        private DataTable infoGridReporteSinRepEventos;
        private DataTable InfoGridReporteSinRepEventos
        {
            get
            {
                infoGridReporteSinRepEventos = (DataTable)ViewState["infoGridReporteRiesgosPlanesAccion"];
                return infoGridReporteSinRepEventos;
            }
            set
            {
                infoGridReporteSinRepEventos = value;
                ViewState["infoGridReporteRiesgosPlanesAccion"] = infoGridReporteSinRepEventos;
            }
        }

        private int pagIndexInfoGridReporteSinRepEventos;
        private int PagIndexInfoGridReporteSinRepEventos
        {
            get
            {
                pagIndexInfoGridReporteSinRepEventos = (int)ViewState["pagIndexInfoGridReporteRiesgosPlanesAccion"];
                return pagIndexInfoGridReporteSinRepEventos;
            }
            set
            {
                pagIndexInfoGridReporteSinRepEventos = value;
                ViewState["pagIndexInfoGridReporteRiesgosPlanesAccion"] = pagIndexInfoGridReporteSinRepEventos;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cCuenta.permisosConsulta(IdFormulario) == "False")
            {
                Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
            }
            if (!Page.IsPostBack)
            {
                LoadDDLCadenaValor();
                LoadDDLProcesoEvento();
                LoadDDLClasificacion();
                LoadDDLAnioReporte();
                inicializarValores();
                mtdHide();
            }
        }

        private void mtdHide()
        {
            LblCadenaValor.Visible = false;
            DDLCadenaValor.Visible = false;
            LblMacroProceso.Visible = false;
            DDLMacroProceso.Visible = false;
            LblProceso.Visible = false;
            DDLProceso.Visible = false;
        }

        private void mtdShow()
        {
            LblCadenaValor.Visible = true;
            DDLCadenaValor.Visible = true;
            LblMacroProceso.Visible = true;
            DDLMacroProceso.Visible = true;
            LblProceso.Visible = true;
            DDLProceso.Visible = true;
        }

        #region Loads
        private void LoadDDLCadenaValor()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLCadenaValor();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    DropDownList52.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreCadenaValor"].ToString().Trim(), dtInfo.Rows[i]["IdCadenaValor"].ToString()));
                    DDLCadenaValor.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreCadenaValor"].ToString().Trim(), dtInfo.Rows[i]["IdCadenaValor"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error al cargar cadena valor. " + ex.Message);
            }
        }

        private void LoadDDLProcesoEvento()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cEvsEIncs.LoadDDLProcesoAfectado();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    DDLProceso.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["Nombre"].ToString().Trim(), dtInfo.Rows[i]["IdProceso"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error al cargar cadena valor. " + ex.Message);
            }
        }

        private void LoadDDLClasificacion()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLClasificacion();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    DropDownList56.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreClasificacionRiesgo"].ToString().Trim(), dtInfo.Rows[i]["IdClasificacionRiesgo"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error al cargar clasificación riesgo. " + ex.Message);
            }
        }

        private void LoadDDLMacroproceso(String IdCadenaValor, int Tipo)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLMacroproceso(IdCadenaValor);
                switch (Tipo)
                {
                    case 2:
                        for (int i = 0; i < dtInfo.Rows.Count; i++)
                        {
                            DropDownList53.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreMacroproceso"].ToString().Trim(), dtInfo.Rows[i]["IdMacroproceso"].ToString()));
                            DDLMacroProceso.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreMacroproceso"].ToString().Trim(), dtInfo.Rows[i]["IdMacroproceso"].ToString()));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error al cargar macroproceso. " + ex.Message);
            }
        }

        private void LoadDDLProceso(String IdMacroproceso, int Tipo)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLProceso(IdMacroproceso);
                switch (Tipo)
                {
                    case 2:
                        for (int i = 0; i < dtInfo.Rows.Count; i++)
                        {
                            DropDownList54.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreProceso"].ToString().Trim(), dtInfo.Rows[i]["IdProceso"].ToString()));
                            DDLProceso.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreProceso"].ToString().Trim(), dtInfo.Rows[i]["IdProceso"].ToString()));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error al cargar proceso. " + ex.Message);
            }
        }

        private void LoadDDLClasificacionGeneral(String IdClasificacionRiesgo, int Tipo)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.loadDDLClasificacionGeneral(IdClasificacionRiesgo);
                switch (Tipo)
                {
                    case 2:
                        for (int i = 0; i < dtInfo.Rows.Count; i++)
                        {
                            DropDownList57.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["NombreClasificacionGeneralRiesgo"].ToString().Trim(), dtInfo.Rows[i]["IdClasificacionGeneralRiesgo"].ToString()));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error al cargar clasificación general. " + ex.Message);
            }
        }

        private void LoadDDLAnioReporte()
        {
            try
            {
                DropDownList58.Items.Clear();
                DropDownList58.Items.Insert(0, new ListItem("---", "0"));
                DropDownList58.SelectedValue = "0";

                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;
                int AuxCont = 0;

                dtInfo = cEvsEIncs.LoadAnios();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    AuxCont = i + 1;
                    DropDownList58.Items.Insert(AuxCont, new ListItem(dtInfoRow["Anio"].ToString().Trim(), dtInfoRow["IdAnio"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion Loads

        #region Eventos Vs. Planes Accion
        private void LoadGridReporteRiesgosEventos()
        {
            DataTable grid = new DataTable();

            grid.Columns.Add("Código", typeof(string));
            grid.Columns.Add("Fecha Registro", typeof(string));
            grid.Columns.Add("Descripción Evento", typeof(string));
            grid.Columns.Add("Fecha Ocurrencia", typeof(string));
            grid.Columns.Add("Fecha Cierre", typeof(string));
            grid.Columns.Add("Fecha Descubrimiento", typeof(string));
            grid.Columns.Add("Monto Exposicion", typeof(string));
            grid.Columns.Add("Código Plan Acción", typeof(string));
            grid.Columns.Add("Plan Acción", typeof(string));
            grid.Columns.Add("Responsable Plan Acción", typeof(string));
            grid.Columns.Add("Estado Plan Acción", typeof(string));
            grid.Columns.Add("Fecha Compromiso Plan Acción", typeof(string));

            InfoGridReporteRiesgosEventos = grid;
            GridView3.DataSource = InfoGridReporteRiesgosEventos;
            GridView3.DataBind();
        }

        private void LoadInfoReporteRiesgosEventos()
        {
            DataTable dtInfo = new DataTable();
            dtInfo = cEvento.ReporteEventos(DropDownList52.SelectedValue.ToString().Trim(),
                DropDownList53.SelectedValue.ToString().Trim(), DropDownList54.SelectedValue.ToString().Trim(),
                DropDownList56.SelectedValue.ToString().Trim(), DropDownList57.SelectedValue.ToString().Trim(),
                DropDownList2.SelectedValue.ToString().Trim(), DropDownList3.SelectedValue.ToString().Trim(),
                DropDownList4.SelectedValue.ToString().Trim(),
                "3", "---", Sanitizer.GetSafeHtmlFragment(TextBox1.Text.Trim()), Sanitizer.GetSafeHtmlFragment(TextBox2.Text.Trim()));

            if (dtInfo.Rows.Count > 0)
            {
                for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                {
                    InfoGridReporteRiesgosEventos.Rows.Add(new Object[] {
                        dtInfo.Rows[rows]["Código"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Registro"].ToString().Trim(),
                        dtInfo.Rows[rows]["Descripción Evento"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Ocurrencia"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Cierre"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Descubrimiento"].ToString().Trim(),
                        dtInfo.Rows[rows]["Monto Exposicion"].ToString().Trim(),
                        dtInfo.Rows[rows]["Código Plan Acción"].ToString().Trim(),
                        dtInfo.Rows[rows]["Plan Acción"].ToString().Trim(),
                        dtInfo.Rows[rows]["Responsable Plan Acción"].ToString().Trim(),
                        dtInfo.Rows[rows]["Estado Plan Acción"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Compromiso Plan Acción"].ToString().Trim()
                        });
                }

                GridView3.PageIndex = PagIndexInfoGridReporteRiesgosEventos;
                GridView3.DataSource = InfoGridReporteRiesgosEventos;
                GridView3.DataBind();
            }
            else
            {
                LoadGridReporteRiesgosEventos();
                Mensaje("No existen registros asociados a los parámetros de consulta.");
            }
        }
        #endregion Eventos Vs. Planes Accion

        #region No hubo evento
        private void LoadGridReporteRiesgos()
        {
            DataTable grid = new DataTable();

            grid.Columns.Add("CodigoEvento", typeof(string));
            grid.Columns.Add("Empresa", typeof(string));
            grid.Columns.Add("FechaNoHuboEvento", typeof(string));
            grid.Columns.Add("NombreResponsable", typeof(string));
            grid.Columns.Add("Cargo", typeof(string));
            grid.Columns.Add("Area", typeof(string));

            InfoGridReporteRiesgos = grid;
            GridView1.DataSource = InfoGridReporteRiesgos;
            GridView1.DataBind();
        }

        private void LoadInfoReporteRiesgos()
        {
            DataTable dtInfo = new DataTable();

            dtInfo = cEvento.ReporteEventos(DropDownList52.SelectedValue.ToString().Trim(),
                DropDownList53.SelectedValue.ToString().Trim(), DropDownList54.SelectedValue.ToString().Trim(),
                DropDownList56.SelectedValue.ToString().Trim(), DropDownList57.SelectedValue.ToString().Trim(),
                DropDownList2.SelectedValue.ToString().Trim(), DropDownList3.SelectedValue.ToString().Trim(),
                DropDownList4.SelectedValue.ToString().Trim(),
                "1", "---", Sanitizer.GetSafeHtmlFragment(TextBox1.Text.Trim()), Sanitizer.GetSafeHtmlFragment(TextBox2.Text.Trim()));

            if (dtInfo.Rows.Count > 0)
            {
                for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                {

                    InfoGridReporteRiesgos.Rows.Add(new Object[] {
                        dtInfo.Rows[rows]["CodigoEvento"].ToString().Trim(),
                        dtInfo.Rows[rows]["Empresa"].ToString().Trim(),
                        dtInfo.Rows[rows]["FechaNoHuboEvento"].ToString().Trim(),
                        dtInfo.Rows[rows]["NombreResponsable"].ToString().Trim(),
                        dtInfo.Rows[rows]["Cargo"].ToString().Trim(),
                        dtInfo.Rows[rows]["Area"].ToString().Trim()
                        });
                }

                GridView1.PageIndex = PagIndexInfoGridReporteRiesgos;
                GridView1.DataSource = InfoGridReporteRiesgos;
                GridView1.DataBind();
            }
            else
            {
                LoadGridReporteRiesgos();
                Mensaje("No existen registros asociados a los parámetros de consulta.");
            }
        }
        #endregion No hubo evento

        #region Eventos
        private void LoadGridReporteRiesgosControles()
        {
            DataTable grid = new DataTable();

            grid.Columns.Add("Código", typeof(string));
            grid.Columns.Add("Empresa", typeof(string));
            grid.Columns.Add("Area", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));
            grid.Columns.Add("NombreUsuarioRegistro", typeof(string));
            grid.Columns.Add("Fecha Registro", typeof(string));
            grid.Columns.Add("Región", typeof(string));
            grid.Columns.Add("Pais", typeof(string));
            grid.Columns.Add("Departamento", typeof(string));
            grid.Columns.Add("Ciudad", typeof(string));
            grid.Columns.Add("Oficina/Sucursal", typeof(string));
            grid.Columns.Add("Detalle Ubicación", typeof(string));
            grid.Columns.Add("Descripción Evento", typeof(string));
            grid.Columns.Add("Título Evento", typeof(string));
            grid.Columns.Add("Servicio/Producto", typeof(string));
            grid.Columns.Add("SubServicio/SubProducto", typeof(string));
            grid.Columns.Add("Fecha Inicio", typeof(string));
            grid.Columns.Add("Hora Inicio", typeof(string));
            grid.Columns.Add("Fecha Finalización", typeof(string));
            grid.Columns.Add("Hora Finalización", typeof(string));
            grid.Columns.Add("Fecha Descubrimiento", typeof(string));
            grid.Columns.Add("Hora Descubrimiento", typeof(string));
            grid.Columns.Add("Canal", typeof(string));
            grid.Columns.Add("Generador del Evento", typeof(string));
            grid.Columns.Add("Responsable Evento", typeof(string));
            grid.Columns.Add("Posible Cuantía de Pérdida ", typeof(string));
            grid.Columns.Add("Cadena Valor", typeof(string));
            grid.Columns.Add("MacroProceso", typeof(string));
            grid.Columns.Add("Proceso", typeof(string));
            grid.Columns.Add("SubProceso", typeof(string));
            grid.Columns.Add("Actividad", typeof(string));
            grid.Columns.Add("Responsable Solución", typeof(string));
            grid.Columns.Add("Clase de Riesgo", typeof(string));
            grid.Columns.Add("SubClase de Riesgo", typeof(string));
            grid.Columns.Add("Tipo de Pérdida", typeof(string));
            grid.Columns.Add("Línea Operativa ", typeof(string));
            grid.Columns.Add("SubLínea Operativa", typeof(string));
            grid.Columns.Add("Más Líneas Operativas", typeof(string));
            grid.Columns.Add("Afecta Continuidad", typeof(string));
            grid.Columns.Add("Estado", typeof(string));
            grid.Columns.Add("Observaciones", typeof(string));
            grid.Columns.Add("Responsable Contabilidad", typeof(string));
            grid.Columns.Add("Cuenta PUC", typeof(string));
            grid.Columns.Add("Cuenta de Orden", typeof(string));
            grid.Columns.Add("Tasa de Cambio", typeof(string));
            grid.Columns.Add("Valor en Pesos", typeof(string));
            grid.Columns.Add("Valor Recuperado Total", typeof(string));
            grid.Columns.Add("Tasa de Cambio 2", typeof(string));
            grid.Columns.Add("Valor en Pesos 2", typeof(string));
            grid.Columns.Add("Recuperación ", typeof(string));
            grid.Columns.Add("Fuente de la Recuperación", typeof(string));
            grid.Columns.Add("Fecha Contabilización", typeof(string));

            InfoGridReporteRiesgosControles = grid;
            GridView2.DataSource = InfoGridReporteRiesgosControles;
            GridView2.DataBind();
        }

        private void LoadGridReporteEventosIncidentes()
        {
            DataTable grid = new DataTable();

            #region dataEventosIncidentes
            grid.Columns.Add("Código Evento/Incidente", typeof(string));
            grid.Columns.Add("Código de Identificación", typeof(string));
            grid.Columns.Add("Fuente del Reporte", typeof(string));
            grid.Columns.Add("Riesgo Global", typeof(string));
            grid.Columns.Add("Estado del Reporte", typeof(string));
            grid.Columns.Add("Código Banco", typeof(string));
            grid.Columns.Add("Fecha de Ocurrencia", typeof(string));
            grid.Columns.Add("Fecha de Descubrimiento", typeof(string));
            grid.Columns.Add("Descripcion del Evento", typeof(string));
            grid.Columns.Add("Titulo del Evento", typeof(string));
            grid.Columns.Add("Categoria", typeof(string));
            grid.Columns.Add("Modalidad Ocurrencia", typeof(string));
            grid.Columns.Add("Linea de negocio 1 (nivel 1)", typeof(string));
            grid.Columns.Add("Linea de negocio 1 (nivel 2)", typeof(string));
            grid.Columns.Add("Linea de negocio 2 (nivel 1)", typeof(string));
            grid.Columns.Add("Linea de negocio 2 (nivel 2)", typeof(string));
            grid.Columns.Add("Tipo de Riesgo", typeof(string));
            grid.Columns.Add("Causa Riesgo Nivel 1", typeof(string));
            grid.Columns.Add("Causa Riesgo Nivel 2", typeof(string));
            grid.Columns.Add("Código Riesgo", typeof(string));
            grid.Columns.Add("Factor RO", typeof(string));
            grid.Columns.Add("Origen", typeof(string));
            grid.Columns.Add("Producto Afectado", typeof(string));
            grid.Columns.Add("Nombres Procesos Originador", typeof(string));
            grid.Columns.Add("Proceso Afectado", typeof(string));
            grid.Columns.Add("Proceso afectado - Título del evento", typeof(string));
            grid.Columns.Add("Monto Bruto de Exposición Inicial", typeof(string));
            grid.Columns.Add("Monto Bruto de Exposicion", typeof(string));
            grid.Columns.Add("Cuenta Contable de la Pérdida", typeof(string));
            grid.Columns.Add("Fecha de Registro Contable de la Pérdida", typeof(string));
            grid.Columns.Add("Monto Recuperado por Seguro", typeof(string));
            grid.Columns.Add("Monto de Otras Recuperaciones", typeof(string));
            grid.Columns.Add("Monto Total Recuperado", typeof(string));
            grid.Columns.Add("Valor Severidad", typeof(string));
            grid.Columns.Add("Cuenta Registro Recuperación", typeof(string));
            grid.Columns.Add("Fecha Registro Contable de la Recuperación", typeof(string));
            grid.Columns.Add("Número de eventos (frecuencia)", typeof(string));
            grid.Columns.Add("Frecuencia Previa", typeof(string));
            grid.Columns.Add("Severidad Previa", typeof(string));
            grid.Columns.Add("Nivel de Riesgo (Límite global) PREVIO", typeof(string));
            grid.Columns.Add("Criticidad de la Frecuencia", typeof(string));
            grid.Columns.Add("Criticidad de la Severidad", typeof(string));
            grid.Columns.Add("Nivel de Riesgo (Límite global)", typeof(string));
            grid.Columns.Add("Criticidad de la frecuencia (límite específico)", typeof(string));
            grid.Columns.Add("Criticidad de la severidad (límite específico)", typeof(string));
            grid.Columns.Add("Nivel de Riesgo (Límite específico)", typeof(string));
            grid.Columns.Add("Códigos Planes Relacionados", typeof(string));
            grid.Columns.Add("Estatus del proceso", typeof(string));
            grid.Columns.Add("Fecha de cierre", typeof(string));
            grid.Columns.Add("Notas", typeof(string));
            grid.Columns.Add("Fecha Registro", typeof(string));
            grid.Columns.Add("Usuario Registro", typeof(string));
            grid.Columns.Add("Titulo_Proceso", typeof(string));
            grid.Columns.Add("Proceso_Originador", typeof(string));
            #endregion

            InfoGridReporteEventosIncidentes = grid;
            GridView5.DataSource = InfoGridReporteEventosIncidentes;
            GridView5.DataBind();
        }

        private void LoadInfoReporteRiesgosControles()
        {
            DataTable dtInfo = new DataTable();
            dtInfo = cEvento.ReporteEventos(DropDownList52.SelectedValue.ToString().Trim(),
                DropDownList53.SelectedValue.ToString().Trim(), DropDownList54.SelectedValue.ToString().Trim(),
                DropDownList56.SelectedValue.ToString().Trim(), DropDownList57.SelectedValue.ToString().Trim(),
                DropDownList2.SelectedValue.ToString().Trim(), DropDownList3.SelectedValue.ToString().Trim(),
                DropDownList4.SelectedValue.ToString().Trim(),
                "2", "---", Sanitizer.GetSafeHtmlFragment(TextBox1.Text.Trim()), Sanitizer.GetSafeHtmlFragment(TextBox2.Text.Trim()));

            if (dtInfo.Rows.Count > 0)
            {
                for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                {
                    InfoGridReporteRiesgosControles.Rows.Add(new Object[] {
                        dtInfo.Rows[rows]["Código"].ToString().Trim(),
                        dtInfo.Rows[rows]["Empresa"].ToString().Trim(),
                        dtInfo.Rows[rows]["Area"].ToString().Trim(),
                        dtInfo.Rows[rows]["Usuario"].ToString().Trim(),
                        dtInfo.Rows[rows]["NombreUsuarioRegistro"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Registro"].ToString().Trim(),
                        dtInfo.Rows[rows]["Región"].ToString().Trim(),
                        dtInfo.Rows[rows]["Pais"].ToString().Trim(),
                        dtInfo.Rows[rows]["Departamento"].ToString().Trim(),
                        dtInfo.Rows[rows]["Ciudad"].ToString().Trim(),
                        dtInfo.Rows[rows]["Oficina/Sucursal"].ToString().Trim(),
                        dtInfo.Rows[rows]["Detalle Ubicación"].ToString().Trim(),
                        dtInfo.Rows[rows]["Descripción Evento"].ToString().Trim(),
                        dtInfo.Rows[rows]["Servicio/Producto"].ToString().Trim(),
                        dtInfo.Rows[rows]["SubServicio/SubProducto"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Inicio"].ToString().Trim(),
                        dtInfo.Rows[rows]["Hora Inicio"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Finalización"].ToString().Trim(),
                        dtInfo.Rows[rows]["Hora Finalización"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Descubrimiento"].ToString().Trim(),
                        dtInfo.Rows[rows]["Hora Descubrimiento"].ToString().Trim(),
                        dtInfo.Rows[rows]["Canal"].ToString().Trim(),
                        dtInfo.Rows[rows]["Generador del Evento"].ToString().Trim(),
                        dtInfo.Rows[rows]["Responsable Evento"].ToString().Trim(),
                        dtInfo.Rows[rows]["Posible Cuantía de Pérdida"].ToString().Trim(),
                        dtInfo.Rows[rows]["Cadena Valor"].ToString().Trim(),
                        dtInfo.Rows[rows]["MacroProceso"].ToString().Trim(),
                        dtInfo.Rows[rows]["Proceso"].ToString().Trim(),
                        dtInfo.Rows[rows]["SubProceso"].ToString().Trim(),
                        dtInfo.Rows[rows]["Actividad"].ToString().Trim(),
                        dtInfo.Rows[rows]["Responsable Solución"].ToString().Trim(),
                        dtInfo.Rows[rows]["Clase de Riesgo"].ToString().Trim(),
                        dtInfo.Rows[rows]["SubClase de Riesgo"].ToString().Trim(),
                        dtInfo.Rows[rows]["Tipo de Pérdida"].ToString().Trim(),
                        dtInfo.Rows[rows]["Línea Operativa"].ToString().Trim(),
                        dtInfo.Rows[rows]["SubLínea Operativa"].ToString().Trim(),
                        dtInfo.Rows[rows]["Más Líneas Operativas"].ToString().Trim(),
                        dtInfo.Rows[rows]["Afecta Continuidad"].ToString().Trim(),
                        dtInfo.Rows[rows]["Estado"].ToString().Trim(),
                        dtInfo.Rows[rows]["Observaciones"].ToString().Trim(),
                        dtInfo.Rows[rows]["Responsable Contabilidad"].ToString().Trim(),
                        dtInfo.Rows[rows]["Cuenta PUC"].ToString().Trim(),
                        dtInfo.Rows[rows]["Cuenta de Orden"].ToString().Trim(),
                        dtInfo.Rows[rows]["Tasa de Cambio"].ToString().Trim(),
                        dtInfo.Rows[rows]["Valor en Pesos"].ToString().Trim(),
                        dtInfo.Rows[rows]["Valor Recuperado Total"].ToString().Trim(),
                        dtInfo.Rows[rows]["Tasa de Cambio 2"].ToString().Trim(),
                        dtInfo.Rows[rows]["Valor en Pesos 2"].ToString().Trim(),
                        dtInfo.Rows[rows]["Recuperación"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fuente de la Recuperación"].ToString().Trim(),
                        dtInfo.Rows[rows]["Fecha Contabilización"].ToString().Trim()
                        });
                }

                GridView2.PageIndex = PagIndexInfoGridReporteRiesgosControles;
                GridView2.DataSource = InfoGridReporteRiesgosControles;
                GridView2.DataBind();
            }
            else
            {
                LoadGridReporteRiesgosControles();
                Mensaje("No existen registros asociados a los parámetros de consulta.");
            }
        }

        private void LoadInfoReporteEventosIncidentes()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                int idAnio = DropDownList58.SelectedIndex;
                if (idAnio != 0 && DDLFiltrarSegun.SelectedValue.Equals("---"))
                {
                    Mensaje("Debe seleccionar un tipo de filtro");
                }
                else
                {
                    dtInfo = cEvento.ReporteEventosIncidentes(idAnio, DDLFiltrarSegun.SelectedValue, DDLProceso.SelectedValue);
                    string Titulo_Proceso;
                    string Proceso_Afectado;

                    if (dtInfo.Rows.Count > 0)
                    {
                        for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                        {
                            Titulo_Proceso = dtInfo.Rows[rows]["Titulo_Proceso"].ToString().Trim();
                            Proceso_Afectado = dtInfo.Rows[rows]["Proceso_Afectado"].ToString().Trim();

                            InfoGridReporteEventosIncidentes.Rows.Add(new Object[] {
                            dtInfo.Rows[rows]["Código Evento/Incidente"].ToString().Trim(),
                            dtInfo.Rows[rows]["Código de Identificación"].ToString().Trim(),
                            dtInfo.Rows[rows]["Fuente del Reporte"].ToString().Trim(),
                            dtInfo.Rows[rows]["Riesgo Global"].ToString().Trim(),
                            dtInfo.Rows[rows]["Estado del Reporte"].ToString().Trim(),
                            dtInfo.Rows[rows]["Código Banco"].ToString().Trim(),
                            toDate(dtInfo.Rows[rows]["Fecha de Ocurrencia"].ToString().Trim()),
                            toDate(dtInfo.Rows[rows]["Fecha de Descubrimiento"].ToString().Trim()),
                            dtInfo.Rows[rows]["Descripcion del Evento"].ToString().Trim(),
                            dtInfo.Rows[rows]["Titulo del Evento"].ToString().Trim(),
                            dtInfo.Rows[rows]["Categoria"].ToString().Trim(),
                            dtInfo.Rows[rows]["Modalidad Ocurrencia"].ToString().Trim(),
                            dtInfo.Rows[rows]["Linea de negocio 1 (nivel 1)"].ToString().Trim(),
                            dtInfo.Rows[rows]["Linea de negocio 1 (nivel 2)"].ToString().Trim(),
                            dtInfo.Rows[rows]["Linea de negocio 2 (nivel 1)"].ToString().Trim(),
                            dtInfo.Rows[rows]["Linea de negocio 2 (nivel 2)"].ToString().Trim(),
                            dtInfo.Rows[rows]["Tipo de Riesgo"].ToString().Trim(),
                            dtInfo.Rows[rows]["Causa Riesgo Nivel 1"].ToString().Trim(),
                            dtInfo.Rows[rows]["Causa Riesgo Nivel 2"].ToString().Trim(),
                            dtInfo.Rows[rows]["Código Riesgo"].ToString().Trim(),
                            dtInfo.Rows[rows]["Factor RO"].ToString().Trim(),
                            dtInfo.Rows[rows]["Origen"].ToString().Trim(),
                            dtInfo.Rows[rows]["Producto Afectado"].ToString().Trim(),
                            dtInfo.Rows[rows]["Nombres Procesos Originador"].ToString().Trim(),
                            dtInfo.Rows[rows]["Proceso Afectado"].ToString().Trim(),
                            dtInfo.Rows[rows]["Proceso Afectado - Título del evento"].ToString().Trim(),
                            dtInfo.Rows[rows]["Monto Bruto de Exposición Inicial"].ToString().Trim(),
                            dtInfo.Rows[rows]["Monto Bruto de Exposicion"].ToString().Trim(),
                            dtInfo.Rows[rows]["Cuenta Contable de la Pérdida"].ToString().Trim(),
                            toDate(dtInfo.Rows[rows]["Fecha de Registro Contable de la Pérdida"].ToString().Trim()),
                            dtInfo.Rows[rows]["Monto Recuperado por Seguro"].ToString().Trim(),
                            dtInfo.Rows[rows]["Monto de Otras Recuperaciones"].ToString().Trim(),
                            dtInfo.Rows[rows]["Monto Total Recuperado"].ToString().Trim(),
                            dtInfo.Rows[rows]["Valor Severidad"].ToString().Trim(),
                            dtInfo.Rows[rows]["Cuenta Registro Recuperación"].ToString().Trim(),
                            toDate(dtInfo.Rows[rows]["Fecha Registro Contable de la Recuperación"].ToString().Trim()),
                            dtInfo.Rows[rows]["Número de eventos (frecuencia)"].ToString().Trim(),
                            dtInfo.Rows[rows]["Frecuencia Previa"].ToString().Trim(),
                            dtInfo.Rows[rows]["Severidad Previa"].ToString().Trim(),
                            dtInfo.Rows[rows]["Nivel de Riesgo (Límite global) PREVIO"].ToString().Trim(),
                            dtInfo.Rows[rows]["Criticidad de la Frecuencia"].ToString().Trim(),
                            dtInfo.Rows[rows]["Criticidad de la Severidad"].ToString().Trim(),
                            dtInfo.Rows[rows]["Nivel de Riesgo (Límite global)"].ToString().Trim(),
                            dtInfo.Rows[rows]["Criticidad de la frecuencia (límite específico)"].ToString().Trim(),
                            dtInfo.Rows[rows]["Criticidad de la severidad (límite específico)"].ToString().Trim(),
                            dtInfo.Rows[rows]["Nivel de Riesgo (Límite específico)"].ToString().Trim(),
                            dtInfo.Rows[rows]["Códigos Planes Relacionados"].ToString().Trim(),
                            dtInfo.Rows[rows]["Estatus del proceso"].ToString().Trim(),
                            toDate(dtInfo.Rows[rows]["Fecha de cierre"].ToString().Trim()),
                            dtInfo.Rows[rows]["Notas"].ToString().Trim(),
                            toDate(dtInfo.Rows[rows]["Fecha Registro"].ToString().Trim()),
                            dtInfo.Rows[rows]["Usuario Registro"].ToString().Trim(),
                            ValLongitud(Titulo_Proceso, 151),
                            ValLongitud(Proceso_Afectado, 81)
                        }); ;
                        }

                        GridView5.PageIndex = PagIndexInfoGridReporteEventosIncidentes;
                        GridView5.DataSource = InfoGridReporteEventosIncidentes;
                        GridView5.DataBind();
                    }
                    else
                    {
                        LoadGridReporteEventosIncidentes();
                        Mensaje("No existen registros asociados a los parámetros de consulta.");
                    }
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString());
            }
        }

        private string toDate(string Fecha) { return Fecha.Equals("") ? "" : Convert.ToDateTime(Fecha).ToString("yyyy-MM-dd"); }
        #endregion Eventos

        #region Sin Reporte
        private void mtdLoadGridReporte_SinReporte()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("Area", typeof(string));
            grid.Columns.Add("FechaInicio", typeof(string));
            grid.Columns.Add("FechaFinal", typeof(string));

            InfoGridReporteSinRepEventos = grid;
            GridView4.DataSource = InfoGridReporteSinRepEventos;
            GridView4.DataBind();
        }

        private void mtdLoadInfoReporte_SinReporte()
        {
            DataTable dtInfo = new DataTable();
            string FechaInicio = string.Empty, FechaFinal = string.Empty;// "Todo";

            dtInfo = cEvento.ReporteEventos(DropDownList52.SelectedValue.ToString().Trim(),
                DropDownList53.SelectedValue.ToString().Trim(), DropDownList54.SelectedValue.ToString().Trim(),
                DropDownList56.SelectedValue.ToString().Trim(), DropDownList57.SelectedValue.ToString().Trim(),
                DropDownList2.SelectedValue.ToString().Trim(), DropDownList3.SelectedValue.ToString().Trim(),
                DropDownList4.SelectedValue.ToString().Trim(),
                "4", "---", Sanitizer.GetSafeHtmlFragment(TextBox1.Text.Trim()), Sanitizer.GetSafeHtmlFragment(TextBox2.Text.Trim()));

            if (dtInfo.Rows.Count > 0)
            {

                if (!string.IsNullOrEmpty(Sanitizer.GetSafeHtmlFragment(TextBox1.Text.Trim())))
                    FechaInicio = Sanitizer.GetSafeHtmlFragment(TextBox1.Text.Trim());
                else
                    FechaInicio = "Todo";

                if (!string.IsNullOrEmpty(Sanitizer.GetSafeHtmlFragment(TextBox2.Text.Trim())))
                    FechaFinal = Sanitizer.GetSafeHtmlFragment(TextBox2.Text.Trim());
                else
                    FechaFinal = "Todo";

                for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                {
                    InfoGridReporteSinRepEventos.Rows.Add(new Object[] {
                        dtInfo.Rows[rows]["Area"].ToString().Trim(),
                        FechaInicio,
                        FechaFinal
                        });
                }
                GridView4.PageIndex = PagIndexInfoGridReporteSinRepEventos;
                GridView4.DataSource = InfoGridReporteSinRepEventos;
                GridView4.DataBind();
            }
            else
            {
                mtdLoadGridReporte_SinReporte();
                Mensaje("No existen registros asociados a los parámetros de consulta.");
            }
        }
        #endregion Sin Reporte

        #region Loads



        #endregion Loads

        #region DDLs

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "6")
            {
                Tr3.Visible = false;
                mtdShow();
            }
            else
            {
                Tr3.Visible = true;
                mtdHide();
            }
        }
        protected void DropDownList52_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList53.Items.Clear();
            DropDownList53.Items.Insert(0, new ListItem("---", "---"));
            DropDownList54.Items.Clear();
            DropDownList54.Items.Insert(0, new ListItem("---", "---"));
            if (DropDownList52.SelectedValue.ToString().Trim() != "---")
            {
                LoadDDLMacroproceso(DropDownList52.SelectedValue.ToString().Trim(), 2);
            }
        }

        protected void DropDownList53_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList54.Items.Clear();
            DropDownList54.Items.Insert(0, new ListItem("---", "---"));
            if (DropDownList53.SelectedValue.ToString().Trim() != "---")
            {
                LoadDDLProceso(DropDownList53.SelectedValue.ToString().Trim(), 2);
            }
        }

        protected void DropDownList56_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList57.Items.Clear();
            DropDownList57.Items.Insert(0, new ListItem("---", "---"));
            if (DropDownList56.SelectedValue.ToString().Trim() != "---")
            {
                LoadDDLClasificacionGeneral(DropDownList56.SelectedValue.ToString().Trim(), 2);
            }

        }

        protected void DDLCadenaValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLMacroProceso.Items.Clear();
            DDLMacroProceso.Items.Insert(0, new ListItem("---", "---"));
            DDLProceso.Items.Clear();
            DDLProceso.Items.Insert(0, new ListItem("---", "---"));
            if (DDLCadenaValor.SelectedValue.ToString().Trim() != "---")
            {
                LoadDDLMacroproceso(DDLCadenaValor.SelectedValue.ToString().Trim(), 2);
            }
        }

        protected void DDLMacroProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLProceso.Items.Clear();
            DDLProceso.Items.Insert(0, new ListItem("---", "---"));
            if (DDLMacroProceso.SelectedValue.ToString().Trim() != "---")
            {
                LoadDDLProceso(DDLMacroProceso.SelectedValue.ToString().Trim(), 2);
            }
        }

        #endregion DDLs

        #region Buttons
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                inicializarValores();
                Tr3.Visible = true;

                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView4.Visible = false;
                GridView3.Visible = false;
                GridView5.Visible = false;
                Button6.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                Button4.Visible = false;
                Button3.Visible = false;

                switch (DropDownList1.SelectedValue.ToString().Trim())
                {
                    case "1":
                        #region No hubo Eventos
                        LoadGridReporteRiesgos();
                        LoadInfoReporteRiesgos();
                        resetValuesConsulta();
                        ReporteRiesgos.Visible = true;
                        GridView1.Visible = true;
                        Button6.Visible = true;
                        #endregion
                        break;
                    case "2":
                        #region RiesgosControles
                        LoadGridReporteRiesgosControles();
                        LoadInfoReporteRiesgosControles();
                        resetValuesConsulta();
                        ReporteRiesgosControles.Visible = true;
                        GridView2.Visible = true;
                        Button1.Visible = true;
                        #endregion
                        break;
                    case "3":
                        #region Eventos VS Plan Accion
                        LoadGridReporteRiesgosEventos();
                        LoadInfoReporteRiesgosEventos();
                        resetValuesConsulta();
                        ReporteRiesgosEventos.Visible = true;
                        GridView3.Visible = true;
                        Button2.Visible = true;
                        #endregion
                        break;
                    case "4":
                        #region Sin Reporte
                        mtdLoadGridReporte_SinReporte();
                        mtdLoadInfoReporte_SinReporte();
                        resetValuesConsulta();
                        ReporteRiesgosPlanesAccion.Visible = true;
                        GridView4.Visible = true;
                        Button3.Visible = true;
                        #endregion
                        break;
                    case "5":
                        #region Consolidado
                        verreporteconsolidado();
                        resetValuesConsulta();
                        #endregion
                        break;
                    case "6":
                        #region Eventos E Incidentes
                        //if (DDLCadenaValor.SelectedItem.Value != "---" && DDLMacroProceso.SelectedItem.Value != "---" && DDLProceso.SelectedItem.Value != "---") {
                            Tr3.Visible = false;
                            LoadGridReporteEventosIncidentes();
                            LoadInfoReporteEventosIncidentes();
                            ReporteEventosIncidentes.Visible = true;
                            GridView5.Visible = true;
                            Button4.Visible = true;
                        //}
                        #endregion
                        break;
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error al realizar la busqueda. " + ex.Message);
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            resetValuesConsulta();
            LoadGridReporteRiesgos();
            LoadGridReporteRiesgosControles();
            LoadGridReporteRiesgosEventos();
            mtdLoadGridReporte_SinReporte();
            inicializarValores();
            mtdHide();
            Tr3.Visible = true;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            exportExcel(InfoGridReporteRiesgos, Response, "Reporte No Hubo Eventos " + System.DateTime.Now.ToString("yyyy-MM-dd"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            exportExcel(InfoGridReporteRiesgosControles, Response, "Reporte Eventos");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                exportExcel(InfoGridReporteRiesgosEventos, Response, "Reporte Eventos vrs Planes de Accion");
            }
            catch (Exception ex)
            {
                Mensaje("Error al exportar Reporte Eventos vrs Planes de Acción." + ex.Message);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            exportExcel(InfoGridReporteSinRepEventos, Response, "Reporte Areas sin Reporte de Eventos");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            exportExcel(InfoGridReporteEventosIncidentes, Response, "Reporte Eventos_Incidentes " + System.DateTime.Now.ToString("yyyy-MM-dd"));
        }
        #endregion Buttons

        #region GridViews
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridReporteRiesgos = e.NewPageIndex;
            GridView1.PageIndex = PagIndexInfoGridReporteRiesgos;
            GridView1.DataSource = InfoGridReporteRiesgos;
            GridView1.DataBind();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridReporteRiesgosControles = e.NewPageIndex;
            GridView2.PageIndex = PagIndexInfoGridReporteRiesgosControles;
            GridView2.DataSource = InfoGridReporteRiesgosControles;
            GridView2.DataBind();
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridReporteRiesgosEventos = e.NewPageIndex;
            GridView3.PageIndex = PagIndexInfoGridReporteRiesgosEventos;
            GridView3.DataSource = InfoGridReporteRiesgosEventos;
            GridView3.DataBind();
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridReporteSinRepEventos = e.NewPageIndex;
            GridView4.PageIndex = PagIndexInfoGridReporteSinRepEventos;
            GridView4.DataSource = InfoGridReporteSinRepEventos;
            GridView4.DataBind();
        }
        protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridReporteEventosIncidentes = e.NewPageIndex;
            GridView5.PageIndex = PagIndexInfoGridReporteEventosIncidentes;
            GridView5.DataSource = InfoGridReporteEventosIncidentes;
            GridView5.DataBind();
        }
        #endregion GridViews

        private void inicializarValores()
        {
            PagIndexInfoGridReporteRiesgos = 0;
            PagIndexInfoGridReporteRiesgosControles = 0;
            PagIndexInfoGridReporteRiesgosEventos = 0;
            PagIndexInfoGridReporteEventosIncidentes = 0;
            PagIndexInfoGridReporteSinRepEventos = 0;
        }

        private String causas(String Causas)
        {
            DataTable dtInfoCausas = new DataTable();
            dtInfoCausas = cRiesgo.causas(Causas);
            Causas = "";
            for (int ca = 0; ca < dtInfoCausas.Rows.Count; ca++)
            {
                Causas += dtInfoCausas.Rows[ca]["NombreCausas"].ToString().Trim() + ". ";
            }
            return Causas;
        }

        private String consecuencias(String Consecuencias)
        {
            DataTable dtInfoConsecuencias = new DataTable();
            dtInfoConsecuencias = cRiesgo.consecuencias(Consecuencias);
            Consecuencias = "";
            for (int con = 0; con < dtInfoConsecuencias.Rows.Count; con++)
            {
                Consecuencias += dtInfoConsecuencias.Rows[con]["NombreConsecuencia"].ToString().Trim() + ". ";
            }
            return Consecuencias;
        }

        private void verreporteconsolidado()
        {
            //Response.Redirect("~/Formularios/Eventos/ReporteConsolidado.aspx?Denegar=1");
            string str;
            str = "window.open('ReporteConsolidado.aspx?','Reporte','width=800,height=600,scrollbars=yes,resizable=yes')";
            Response.Write("<script languaje=javascript>" + str + "</script>");
        }

        public static void exportExcel(DataTable dt, HttpResponse Response, string filename)
        {
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
            Response.ContentEncoding = System.Text.Encoding.Default;
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
            dg.DataSource = dt;
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        private void resetValuesConsulta()
        {
            DropDownList1.SelectedIndex = 0;
            DropDownList52.SelectedIndex = 0;
            DropDownList53.Items.Clear();
            DropDownList53.Items.Insert(0, new ListItem("---", "---"));
            DropDownList54.Items.Clear();
            DropDownList54.Items.Insert(0, new ListItem("---", "---"));
            DropDownList56.SelectedIndex = 0;
            DropDownList57.Items.Clear();
            DropDownList57.Items.Insert(0, new ListItem("---", "---"));
            DropDownList58.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
            DropDownList4.SelectedIndex = 0;
            ReporteRiesgos.Visible = false;
            ReporteRiesgosControles.Visible = false;
            ReporteRiesgosEventos.Visible = false;
            ReporteEventosIncidentes.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        private void Mensaje(String Mensaje)
        {
            lblMsgBox.Text = Mensaje;
            mpeMsgBox.Show();
        }

        private String ValLongitud(String Texto, int Limite)
        {
            int valor = Int32.Parse(Texto);
            if (Texto != "")
            {
                if (valor < Limite) Texto = "Ok";
                else Texto = "Error";
            }
            else Texto = "N/A";

            return Texto;
        }
    }
}