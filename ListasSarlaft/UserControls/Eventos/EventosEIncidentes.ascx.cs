using ListasSarlaft.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ListasSarlaft.UserControls.Eventos
{
    public partial class EvsEIncs : System.Web.UI.UserControl
    {
        #region Variables Globales
        private cEvsEIncs cEvsEIncs = new cEvsEIncs();
        private string strCodigoNHEvento = string.Empty, strCodigoEvento = string.Empty;
        private string FechaFin = string.Empty;
        private string NombreResponsable = string.Empty;
        private string personalizado = string.Empty;
        private int cantEventosMaximos = 0;
        private int cantEventosFrecuenciaExisten = 0;
        private int pagIndexPlanes;
        private cRiesgo cRiesgo = new cRiesgo();
        private cEvento cEvento = new cEvento();
        private cControl cControl = new cControl();
        private cCuenta cCuenta = new cCuenta();
        private clsDTOPlanes objPlanes = new clsDTOPlanes();
        private List<clsDTOPlanes> listaPlanes = new List<clsDTOPlanes>();

        //private static int LastInsertId;
        private static int LastInsertIdCE;
        #endregion Variables Globales

        #region Properties

        private DataTable infoGridEvsEIncs;
        private DataTable InfoGridEvsEIncs
        {
            get
            {
                infoGridEvsEIncs = (DataTable)ViewState["infoGridEventos"];
                return infoGridEvsEIncs;
            }
            set
            {
                infoGridEvsEIncs = value;
                ViewState["infoGridEventos"] = infoGridEvsEIncs;
            }
        }

        private DataTable infoGridPlanes;
        private DataTable InfoGridPlanes
        {
            get
            {
                infoGridPlanes = (DataTable)ViewState["infoGridPlanes"];
                return infoGridPlanes;
            }
            set
            {
                infoGridPlanes = value;
                ViewState["infoGridPlanes"] = infoGridPlanes;
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

        private DataTable infoGridProcesoO;
        private DataTable InfoGridProcesoO
        {
            get
            {
                infoGridProcesoO = (DataTable)ViewState["infoGridProcesoO"];
                return infoGridProcesoO;
            }
            set
            {
                infoGridProcesoO = value;
                ViewState["infoGridProcesoO"] = infoGridProcesoO;
            }
        }

        private DataTable infoGridProcesoA;
        private DataTable InfoGridProcesoA
        {
            get
            {
                infoGridProcesoA = (DataTable)ViewState["infoGridProcesoA"];
                return infoGridProcesoA;
            }
            set
            {
                infoGridProcesoA = value;
                ViewState["infoGridProcesoA"] = infoGridProcesoA;
            }
        }

        private DataTable infoGridArchivos;
        private DataTable InfoGridArchivos
        {
            get
            {
                infoGridArchivos = (DataTable)ViewState["infoGridArchivos"];
                return infoGridArchivos;
            }
            set
            {
                infoGridArchivos = value;
                ViewState["infoGridArchivos"] = infoGridArchivos;
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

        private int pagIndexInfoGridEvsEIncs;
        private int PagIndexInfoGridEvsEIncs
        {
            get
            {
                pagIndexInfoGridEvsEIncs = (int)ViewState["pagIndexInfoGridEvsEIncs"];
                return pagIndexInfoGridEvsEIncs;
            }
            set
            {
                pagIndexInfoGridEvsEIncs = value;
                ViewState["pagIndexInfoGridEvsEIncs"] = pagIndexInfoGridEvsEIncs;
            }
        }

        private int pagIndexInfoGridPlanes;
        private int PagIndexInfoGridPlanes
        {
            get
            {
                pagIndexInfoGridPlanes = (int)ViewState["pagIndexInfoGridPlanes"];
                return pagIndexInfoGridPlanes;
            }
            set
            {
                pagIndexInfoGridPlanes = value;
                ViewState["pagIndexInfoGridPlanes"] = pagIndexInfoGridPlanes;
            }
        }

        private int pagIndexInfoGridRiesgos;
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

        private int pagIndexInfoGridProcesoO;
        private int PagIndexInfoGridProcesoO
        {
            get
            {
                pagIndexInfoGridProcesoO = (int)ViewState["pagIndexInfoGridProcesoO"];
                return pagIndexInfoGridProcesoO;
            }
            set
            {
                pagIndexInfoGridProcesoO = value;
                ViewState["pagIndexInfoGridProcesoO"] = pagIndexInfoGridProcesoO;
            }
        }

        private int pagIndexInfoGridJustificacion;
        private int PagIndexInfoGridJustificacion
        {
            get
            {
                pagIndexInfoGridJustificacion = (int)ViewState["pagIndexInfoGridJustificacion"];
                return pagIndexInfoGridJustificacion;
            }
            set
            {
                pagIndexInfoGridJustificacion = value;
                ViewState["pagIndexInfoGridJustificacion"] = pagIndexInfoGridJustificacion;
            }
        }

        private int pagIndexInfoGridProcesoA;
        private int PagIndexInfoGridProcesoA
        {
            get
            {
                pagIndexInfoGridProcesoA = (int)ViewState["pagIndexInfoGridProcesoA"];
                return pagIndexInfoGridProcesoA;
            }
            set
            {
                pagIndexInfoGridProcesoA = value;
                ViewState["pagIndexInfoGridProcesoA"] = pagIndexInfoGridProcesoA;
            }
        }

        private int pagIndexInfoGridArchivos;
        private int PagIndexInfoGridArchivos
        {
            get
            {
                pagIndexInfoGridArchivos = (int)ViewState["pagIndexInfoGridArchivos"];
                return pagIndexInfoGridArchivos;
            }
            set
            {
                pagIndexInfoGridArchivos = value;
                ViewState["pagIndexInfoGridArchivos"] = pagIndexInfoGridArchivos;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TabPanelCreaEvento.Focus();
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            ScriptManager scrtManager = ScriptManager.GetCurrent(this.Page);
            scrtManager.RegisterPostBackControl(BtnSubirArchivo);
            scrtManager.RegisterPostBackControl(GVArchivos);

            if (!Page.IsPostBack)
            {
                resetDataBaseInfo();
                resetInputs();
                loadInitialData();
                mtdLoadDDLEmpresa1();
            }

        }

        private void mtdLoadDDLEmpresa1()
        {


            try
            {
                DataTable dtInfo = new DataTable();
                dtInfo = cRiesgo.mtdLoadEmpresa(true);
                ddlEmpresa.Items.Insert(0, new ListItem("---", "---"));
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    ddlEmpresa.Items.Insert(i + 1, new ListItem(dtInfo.Rows[i]["Descripcion"].ToString().Trim(), dtInfo.Rows[i]["IdEmpresa"].ToString()));
                }
            }
            catch (Exception ex)
            {
                //Mensaje("Error al cargar Empresas. " + ex.Message);
                ShowMessage($"Error al cargar Empresas: {ex}", 1, "Atención");
            }
        }
        #endregion Properties

        #region Treeview

        #endregion Treeview

        #region PrivateFunctions

        private void LlenarEnBlanco()
        {
            List<TextBox> camposNumericos = new List<TextBox>();
            camposNumericos.Add(TBMontoBruto);
            camposNumericos.Add(TBMontoExposicion);
            camposNumericos.Add(TBValorFrecuencia);
            camposNumericos.Add(TBRecuperacionSeguro);
            camposNumericos.Add(TBRecuperaciones);

            foreach (TextBox campo in camposNumericos)
            {
                if (campo.Text.ToString().Equals("")) campo.Text = "0";
            }
        }
        private void GuardarEvento()
        {
            try
            {
                string ValidationMessage = ValOnSave();

                if (!ValidationMessage.Equals(""))
                    ShowMessage(ValidationMessage, 1, "Atención");
                else
                {
                    LlenarEnBlanco();

                    TBIdEvsEIncs.Text = cEvsEIncs.ModificarEvsEIncs(
                        TBIdEvsEIncs.Text.ToString().Trim(),
                        DDLFuenteReporte.SelectedValue.ToString().Trim(),
                        DDLRiesgoGlobal.SelectedValue.ToString().Trim(),
                        DDLEstadoReporte.SelectedValue.ToString().Trim(),
                        DDLCodigoBanco.SelectedValue.ToString().Trim(),
                        TBFechaOcurrencia.Text.ToString().Trim(),
                        TBFechaDescubrimiento.Text.ToString().Trim(), 
                        TBDescripcionEvento.Text.ToString().Trim(),
                        TBTituloEvento.Text.ToString().Trim(),
                        DDLCategoria.SelectedValue.ToString().Trim(),
                        DDLModalidad.SelectedValue.ToString().Trim(),
                        DDLFiltroLineaUno.SelectedValue.ToString().Trim(),
                        DDLLineaNegocioUno.SelectedValue.ToString().Trim(),
                        DDLFiltroLineaDos.SelectedValue.ToString().Trim(),
                        DDLLineaNegocioDos.SelectedValue.ToString().Trim(),
                        DDLTipoRiesgo.SelectedValue.ToString().Trim(),
                        DDLCausaRiesgoUno.SelectedValue.ToString().Trim(),
                        DDLCausaRiesgoDos.SelectedValue.ToString().Trim(),
                        DDLFactorRO.SelectedValue.ToString().Trim(),
                        DDLOrigen.SelectedValue.ToString().Trim(),
                        DDLProductoAfectado.SelectedValue.ToString().Trim(),
                        TBMontoBruto.Text.ToString().Trim(),
                        TBMontoExposicion.Text.ToString().Trim(),
                        DDLCuentasPerdida.SelectedValue.ToString().Trim(),
                        TBFRegistroPerdida.Text.ToString().Trim(),
                        TBRecuperacionSeguro.Text.ToString().Trim(),
                        TBRecuperaciones.Text.ToString().Trim(),
                        TBCuentaRecuperacion.Text.ToString().Trim(),
                        TBFRegistroContable.Text.ToString().Trim(),
                        TBValorFrecuencia.Text.ToString().Trim(),
                        DDLCriticidad.SelectedValue.ToString().Trim(),
                        DDLCriticidadSeveridadNota.SelectedValue.ToString().Trim(),
                        DDLCriticidadFrecuencia.SelectedValue.ToString().Trim(),
                        DDLCriticidadSeveridad.SelectedValue.ToString().Trim(),
                        DDLEstatus.SelectedValue.ToString().Trim(),
                        TBFCierre.Text.ToString().Trim(),
                        TBNotas.Text.ToString().Trim(),
                        TBJustificacion.Text.ToString().Trim());

                    string codigoEvsEIncs = TBHiddenCodigoEvsEIncs.Text.ToString().Trim();
                    codigoEvsEIncs = codigoEvsEIncs.Equals("") ? "EI"+TBIdEvsEIncs.Text : codigoEvsEIncs;

                    ShowMessage($"Evento/Incidente {codigoEvsEIncs} Creado correctamente", 3, "Atención");
                    TBHiddenCodigoEvsEIncs.Text = codigoEvsEIncs;

                    MostrarTablasMultiples();

                    string CodigoEvento = TBHiddenCodigoEvsEIncs.Text;
                    
                    mtdGenerarNotificacionCreaccionEvento(CodigoEvento, string.Empty, string.Empty, 37, 0);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ModificarEvento()
        {
            try
            {
                string ValidationMessage = ValOnSave();

                if (!ValidationMessage.Equals(""))
                    ShowMessage(ValidationMessage, 1, "Atención");
                else
                {
                    LlenarEnBlanco();

                    TBIdEvsEIncs.Text = cEvsEIncs.ModificarEvsEIncs(
                        TBIdEvsEIncs.Text.ToString().Trim(),
                        DDLFuenteReporte.SelectedValue.ToString().Trim(),
                        DDLRiesgoGlobal.SelectedValue.ToString().Trim(),
                        DDLEstadoReporte.SelectedValue.ToString().Trim(),
                        DDLCodigoBanco.SelectedValue.ToString().Trim(),
                        TBFechaOcurrencia.Text.ToString().Trim(),
                        TBFechaDescubrimiento.Text.ToString().Trim(),
                        TBDescripcionEvento.Text.ToString().Trim(),
                        TBTituloEvento.Text.ToString().Trim(),
                        DDLCategoria.SelectedValue.ToString().Trim(),
                        DDLModalidad.SelectedValue.ToString().Trim(),
                        DDLFiltroLineaUno.SelectedValue.ToString().Trim(),
                        DDLLineaNegocioUno.SelectedValue.ToString().Trim(),
                        DDLFiltroLineaDos.SelectedValue.ToString().Trim(),
                        DDLLineaNegocioDos.SelectedValue.ToString().Trim(),
                        DDLTipoRiesgo.SelectedValue.ToString().Trim(),
                        DDLCausaRiesgoUno.SelectedValue.ToString().Trim(),
                        DDLCausaRiesgoDos.SelectedValue.ToString().Trim(),
                        DDLFactorRO.SelectedValue.ToString().Trim(),
                        DDLOrigen.SelectedValue.ToString().Trim(),
                        DDLProductoAfectado.SelectedValue.ToString().Trim(),
                        TBMontoBruto.Text.ToString().Trim(),
                        TBMontoExposicion.Text.ToString().Trim(),
                        DDLCuentasPerdida.SelectedValue.ToString().Trim(),
                        TBFRegistroPerdida.Text.ToString().Trim(),
                        TBRecuperacionSeguro.Text.ToString().Trim(),
                        TBRecuperaciones.Text.ToString().Trim(),
                        TBCuentaRecuperacion.Text.ToString().Trim(),
                        TBFRegistroContable.Text.ToString().Trim(),
                        TBValorFrecuencia.Text.ToString().Trim(),
                        DDLCriticidad.SelectedValue.ToString().Trim(),
                        DDLCriticidadSeveridadNota.SelectedValue.ToString().Trim(),
                        DDLCriticidadFrecuencia.SelectedValue.ToString().Trim(),
                        DDLCriticidadSeveridad.SelectedValue.ToString().Trim(),
                        DDLEstatus.SelectedValue.ToString().Trim(),
                        TBFCierre.Text.ToString().Trim(),
                        TBNotas.Text.ToString().Trim(),
                        TBJustificacion.Text.ToString().Trim());

                    string justificacion = TBJustificacion.Text.ToString().Trim();

                    string codigoEvsEIncs = TBHiddenCodigoEvsEIncs.Text.ToString().Trim();
                    codigoEvsEIncs = codigoEvsEIncs.Equals("") ? "EI" + TBIdEvsEIncs.Text : codigoEvsEIncs;

                    ShowMessage($"Evento/Incidente {codigoEvsEIncs} actualizado correctamente", 3, "Atención");
                    TBHiddenCodigoEvsEIncs.Text = codigoEvsEIncs;

                    MostrarTablasMultiples();

                    string CodigoEvento = TBHiddenCodigoEvsEIncs.Text;

                    mtdGenerarNotificacionModificacionEvento(CodigoEvento, string.Empty, string.Empty, 37, 0, justificacion);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool validarCriticidades()
        {
            bool validar = true;
            if (!TBValorFrecuencia.Text.Trim().Equals("") && DDLCriticidadFrecuencia.SelectedValue.Equals("0")) validar = false;
            if (!TBMontoExposicion.Text.Trim().Equals("") && DDLCriticidadSeveridad.SelectedValue.Equals("0")) validar = false;

            return validar;
        }
        private void MostrarTablasMultiples()
        {
            if (!TBIdEvsEIncs.Text.ToString().Trim().Equals(""))
            {
                TbRelMultiple.Visible = true;
                GVPlanes_reload();
                GVRiesgos_reload();
                GVProcesoO_reload();
                GVProcesoA_reload();
                GVJustificacion_reload();
            }
        }

        private void LoadCriticidadRiesgoByRiesgo(string IdRiesgo)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadCriticidadRiesgoByRiesgo(IdRiesgo);
                if (dtInfo.Rows.Count > 0)
                {
                    dtInfoRow = dtInfo.Rows[0];

                    TBFrecuenciaPrevia.Text = dtInfoRow["ProbabilidadResidual"].ToString();
                    TBSeveridadPrevia.Text = dtInfoRow["ImpactoResidual"].ToString();

                    LoadMedicionRiesgo(TBFrecuenciaPrevia.Text, TBSeveridadPrevia.Text, TBNRiesgoPrevio);
                }
                else
                {
                    TBFrecuenciaPrevia.Text = "";
                    TBSeveridadPrevia.Text = "";
                    TBNRiesgoPrevio.Text = "";
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error cargando la criticidad del riesgo: {ex}", 1, "Atención");
            }
        }

        private void LoadCriticidadRiesgoByEvento(string IdEvsEIncs)
        {
            if (!IdEvsEIncs.Equals(""))
            {
                try
                {
                    DataTable dtInfo = new DataTable();
                    DataRow dtInfoRow = null;

                    dtInfo = cEvsEIncs.LoadCriticidadRiesgoByEvento(IdEvsEIncs);
                    if (dtInfo.Rows.Count > 0)
                    {
                        dtInfoRow = dtInfo.Rows[0];

                        TBFrecuenciaPrevia.Text = dtInfoRow["ProbabilidadResidual"].ToString();
                        TBSeveridadPrevia.Text = dtInfoRow["ImpactoResidual"].ToString();
                        LoadMedicionRiesgo(TBFrecuenciaPrevia.Text, TBSeveridadPrevia.Text, TBNRiesgoPrevio);
                    }
                    else
                    {
                        TBFrecuenciaPrevia.Text = "";
                        TBSeveridadPrevia.Text = "";
                        TBNRiesgoPrevio.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage($"Error cargando la criticidad del riesgo: {ex}", 1, "Atención");
                }
            }
        }

        private void LoadMedicionRiesgo(string Frecuencia, string Severidad, TextBox TBNivel)
        {
            if (!Frecuencia.Equals("") && !Severidad.Equals(""))
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadMedicionRiesgo(Frecuencia, Severidad);
                if (dtInfo.Rows.Count > 0)
                {
                    dtInfoRow = dtInfo.Rows[0];
                    TBNivel.Text = dtInfoRow["Resultado"].ToString();
                }
            }
            else
            {
                TBNivel.Text = "";
            }
        }
        private void ConsultarDescFrecuencia()
        {
            try
            {
                string IdTipoRiesgo = DDLTipoRiesgo.SelectedValue.ToString();
                string ValorFrecuencia = TBValorFrecuencia.Text.Trim();

                if (!IdTipoRiesgo.Equals("0") && !ValorFrecuencia.Equals(""))
                    DDLCriticidadFrecuencia.SelectedValue = cEvsEIncs.ConsultarDescFrecuencia(IdTipoRiesgo, ValorFrecuencia);
            }
            catch (IndexOutOfRangeException) { DDLCriticidadFrecuencia.SelectedValue = "4"; }
            catch (Exception ex)
            {
                ShowMessage($"Error al consultar Frecuencia (Límite específico): {ex}", 1, "Atención");
            }
        }
        private void ConsultarDescSeveridad()
        {
            try
            {
                string IdTipoRiesgo = DDLTipoRiesgo.SelectedValue.ToString();
                string MontoExposicion = TBMontoExposicion.Text.Trim().Replace(',', '.');

                if (!IdTipoRiesgo.Equals("0") && !MontoExposicion.Equals(""))
                    DDLCriticidadSeveridad.SelectedValue = cEvsEIncs.ConsultarDescSeveridad(IdTipoRiesgo, MontoExposicion);
            }
            catch (IndexOutOfRangeException) { DDLCriticidadSeveridad.SelectedValue = "4"; }
            catch (Exception ex)
            {
                ShowMessage($"Error al consultar Severidad (Límite específico): {ex}", 1, "Atención");
            }
        }

        private void GVPlanes_reload()
        {
            TbPlanes.Visible = false;
            inicializarPlanes();
            loadGridPlanes();
            loadInfoPlanes();
        }

        private void GVRiesgos_reload(bool bLoadCriticidad = true)
        {
            TbRiesgos.Visible = false;
            inicializarRiesgos();
            loadGridRiesgos();
            loadInfoRiesgos();

            if (bLoadCriticidad)
                LoadCriticidadRiesgoByEvento(TBIdEvsEIncs.Text);
        }

        private void GVProcesoO_reload()
        {
            TbProcesoO.Visible = false;
            inicializarProcesoO();
            loadGridProcesoO();
            loadInfoProcesoO();
        }
        private void GVProcesoA_reload()
        {
            TbProcesoA.Visible = false;
            inicializarProcesoA();
            loadGridProcesoA();
            loadInfoProcesoA();
        }

        private void GVArchivos_reload()
        {
            TbArchivos.Visible = false;
            inicializarArchivos();
            loadGridArchivos();
            loadInfoArchivos();
        }

        private void GVJustificacion_reload()
        {
            TBJustificacion.Text = "";
            inicializarJustificacion();
            loadGridJustificacion();
            loadInfoJustificacion();
        }

        #endregion

        #region DDL

        protected void DDLCausaRiesgoUno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DDLCausaRiesgoDos.Items.Clear();
                DDLCausaRiesgoDos.Items.Insert(0, new ListItem("---", "0"));

                if (DDLCausaRiesgoUno.SelectedValue != "")
                    loadDDLCausaRiesgoDos();

            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar información causa riesgo nivel 2: {ex}", 1, "Atención");
            }
        }

        protected void DDLCausaRiesgoDos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadDDLFactorRO();
                loadDDLOrigen();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar información causa riesgo nivel 2: {ex}", 1, "Atención");
            }
        }

        protected void DDLModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bloquearPorModalidad();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar información lina negocio nivel 2: {ex}", 1, "Atención");
            }
        }

        protected void DDLFiltroLineaUno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadDescripcionLineas(DDLLineaNegocioUno, DDLFiltroLineaUno.SelectedValue);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al validar información en líneas de negocio: {ex}", 1, "Atención");
            }
        }

        protected void DDLFiltroLineaDos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLModalidad.SelectedValue.Equals("2") && DDLFiltroLineaDos.SelectedValue.Equals("9"))
                {
                    DDLFiltroLineaDos.SelectedValue = "0";
                    resetDDL(DDLLineaNegocioDos);
                    ShowMessage($"Valor en 'Línea de negocio 1 (Nivel 2) no válido", 1, "Atención");
                    throw new ArgumentException("");
                }
                loadDescripcionLineas(DDLLineaNegocioDos, DDLFiltroLineaDos.SelectedValue);
            }
            catch (ArgumentException aex) { }
            catch (Exception ex)
            {
                ShowMessage($"Error en líneas de negocio: {ex}", 1, "Atención");
            }
        }

        protected void DDLLineaNegocioUno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ValMsgDDLLineas();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al validar información en líneas de negocio: {ex}", 1, "Atención");
            }
        }

        protected void DDLLineaNegocioDos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ValMsgDDLLineas();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al validar información en líneas de negocio", 1, "Atención");
            }
        }

        protected void DDLTipoRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DDLCausaRiesgoUno.Items.Clear();
                DDLCausaRiesgoUno.Items.Insert(0, new ListItem("---", "0"));
                loadDDLCausaRiesgoUno();

                ConsultarDescSeveridad();
                ConsultarDescFrecuencia();
                LoadMedicionRiesgo(DDLCriticidadFrecuencia.SelectedItem.ToString(), DDLCriticidadSeveridad.SelectedItem.ToString(), TBNRiesgoEspecifico);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al validar información de estado del proceso: {ex}", 1, "Atención");
            }
        }

        protected void DDLEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ValEstatusProceso();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al validar información de estado del proceso: {ex}", 1, "Atención");
            }
        }
        protected void DDLCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bloquearPorCategoria();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al habilitar/deshabilitar campos: {ex}", 1, "Atención");
            }
        }

        #region DDLB
        protected void DDLBCadenaValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadDDLBMacroproceso();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar macroproceso: {ex}", 1, "Atención");
            }
        }

        protected void DDLBMacroproceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadDDLBProceso();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar proceso: {ex}", 1, "Atención");
            }
        }

        protected void DDLBProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadDDLBSubproceso();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar proceso: {ex}", 1, "Atención");
            }
        }

        protected void DDLBSubproceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadDDLBActividad();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar proceso: {ex}", 1, "Atención");
            }
        }
        #endregion

        #endregion DDL

        #region TB

        protected void TBValorFrecuencia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowMessage($"Calculando criticidad de la frecuencia...", 2, "Atención");

                string valorFrecuencia = TBValorFrecuencia.Text.Trim();
                int nValorFrecunecia = Convert.ToInt32(valorFrecuencia);

                string criticidad = cEvsEIncs.ConsultarCriticidadFq(valorFrecuencia);
                DDLCriticidad.SelectedValue = criticidad;
                LoadMedicionRiesgo(DDLCriticidad.SelectedItem.ToString(), DDLCriticidadSeveridadNota.SelectedItem.ToString(), TBNRiesgo);

                ConsultarDescFrecuencia();
                LoadMedicionRiesgo(DDLCriticidadFrecuencia.SelectedItem.ToString(), DDLCriticidadSeveridad.SelectedItem.ToString(), TBNRiesgoEspecifico);

                mpeMsgBox.Hide();
            }
            catch (IndexOutOfRangeException) { DDLCriticidad.SelectedValue = "4"; }
            catch (FormatException)
            {
                ShowMessage($"Error al evaluar la criticidad de la frecuencia: 'Valor de Frecuencia no es un número entero'", 1, "Atención");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al evaluar la criticidad de la frecuencia: {ex}", 1, "Atención");
            }
        }

        protected void TBMontoExposicion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowMessage($"Calculando criticidad de la severidad...", 2, "Atención");

                PageValidate_AddneRCamposDecimal();

                string criticidad = cEvsEIncs.ConsultarCriticidadSv(TBMontoExposicion.Text.Replace(',', '.'));
                

                DDLCriticidadSeveridadNota.SelectedValue = criticidad;
                mpeMsgBox.Hide();
                LoadMedicionRiesgo(DDLCriticidad.SelectedItem.ToString(), DDLCriticidadSeveridadNota.SelectedItem.ToString(), TBNRiesgo);

                ConsultarDescSeveridad();
                LoadMedicionRiesgo(DDLCriticidadFrecuencia.SelectedItem.ToString(), DDLCriticidadSeveridad.SelectedItem.ToString(), TBNRiesgoEspecifico);

            }
            catch (IndexOutOfRangeException) { DDLCriticidadSeveridadNota.SelectedValue = "4"; }
            catch (FormatException)
            {
                ShowMessage($"Error al evaluar la criticidad de la severidad: 'Monto Bruto de Exposición no es un número válido'", 1, "Atención");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al evaluar la criticidad de la severidad: {ex}", 1, "Atención");
            }
        }

        protected void TBMontoBruto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PageValidate_AddneRCamposDecimal();
                TBMontoBruto.Text = TBMontoBruto.Text.Replace('.', ',');
            }
            catch (FormatException)
            {
                ShowMessage($"Error al evaluar la criticidad de la severidad: 'Monto Bruto de Exposición Inicial no es un número válido'", 1, "Atención");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error evaluando campo '': {ex}", 1, "Atención");
            }
        }
        protected void TBRecuperacionSeguro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TBRecuperacionSeguro.Text = TBRecuperacionSeguro.Text.Replace('.', ',');
            }
            catch (Exception ex)
            {
                ShowMessage($"Error evaluando campo '': {ex}", 1, "Atención");
            }
        }
        protected void TBRecuperaciones_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TBRecuperaciones.Text = TBRecuperaciones.Text.Replace('.', ',');
            }
            catch (Exception ex)
            {
                ShowMessage($"Error evaluando campo '': {ex}", 1, "Atención");
            }
        }

        protected void TBFechaDescubrimiento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValDates(TBFechaDescubrimiento, TBFechaOcurrencia, "fecha de ocurrencia", true);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al evaluar fechas", 1, "Atención");
            }
        }

        protected void TBFRegistroContable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValDates(TBFRegistroContable, TBFechaOcurrencia, "fecha de ocurrencia", true);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al evaluar evaluar fechas", 1, "Atención");
            }
        }

        protected void TBFCierre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValDates(TBFCierre, TBFechaDescubrimiento, "fecha de descubrimiento");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al evaluar fechas", 1, "Atención");
            }
        }

        protected void TBFRegistroPerdida_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValDates(TBFRegistroPerdida, TBFechaOcurrencia, "fecha de ocurrencia", true);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al evaluar evaluar fechas", 1, "Atención");
            }
        }
        #endregion

        #region Reset
        private void resetDataBaseInfo()
        {
            try
            {
                DDLFuenteReporte.Items.Clear();
                DDLRiesgoGlobal.Items.Clear();
                DDLEstadoReporte.Items.Clear();
                DDLCodigoBanco.Items.Clear();
                DDLCategoria.Items.Clear();
                DDLModalidad.Items.Clear();
                DDLCuentasPerdida.Items.Clear();
                DDLFiltroLineaUno.Items.Clear();
                DDLFiltroLineaDos.Items.Clear();
                DDLLineaNegocioUno.Items.Clear();
                DDLLineaNegocioDos.Items.Clear();
                DDLCausaRiesgoUno.Items.Clear();
                DDLCausaRiesgoDos.Items.Clear();
                DDLFactorRO.Items.Clear();
                DDLOrigen.Items.Clear();
                DDLProductoAfectado.Items.Clear();
                DDLCriticidad.Items.Clear();
                DDLCriticidadSeveridadNota.Items.Clear();
                DDLCriticidadSeveridad.Items.Clear();
                DDLCriticidadFrecuencia.Items.Clear();
                DDLCuentasPerdida.Items.Clear();

                DDLBCadenaValor.Items.Clear();
                DDLBMacroproceso.Items.Clear();
                DDLBProceso.Items.Clear();
                DDLBSubproceso.Items.Clear();
                DDLBActividad.Items.Clear();

                DDLBPOMacroproceso.Items.Clear();

                DDLBPAMacroproceso.Items.Clear();
                DDLEstatus.Items.Clear();

                DDLFuenteReporte.Items.Insert(0, new ListItem("---", "0"));
                DDLRiesgoGlobal.Items.Insert(0, new ListItem("---", "0"));
                DDLEstadoReporte.Items.Insert(0, new ListItem("---", "0"));
                DDLCodigoBanco.Items.Insert(0, new ListItem("---", "0"));
                DDLCategoria.Items.Insert(0, new ListItem("---", "0"));
                DDLModalidad.Items.Insert(0, new ListItem("---", "0"));
                DDLCuentasPerdida.Items.Insert(0, new ListItem("---", "0"));
                DDLFiltroLineaUno.Items.Insert(0, new ListItem("---", "0"));
                DDLFiltroLineaDos.Items.Insert(0, new ListItem("---", "0"));
                DDLLineaNegocioUno.Items.Insert(0, new ListItem("---", "0"));
                DDLLineaNegocioDos.Items.Insert(0, new ListItem("---", "0"));
                DDLTipoRiesgo.Items.Insert(0, new ListItem("---", "0"));
                DDLCausaRiesgoUno.Items.Insert(0, new ListItem("---", "0"));
                DDLCausaRiesgoDos.Items.Insert(0, new ListItem("---", "0"));
                DDLFactorRO.Items.Insert(0, new ListItem("---", "0"));
                DDLOrigen.Items.Insert(0, new ListItem("---", "0"));
                DDLProductoAfectado.Items.Insert(0, new ListItem("---", "0"));
                DDLCriticidad.Items.Insert(0, new ListItem("---", "0"));
                DDLCriticidadSeveridadNota.Items.Insert(0, new ListItem("---", "0"));
                DDLCriticidadSeveridad.Items.Insert(0, new ListItem("---", "0"));
                DDLCriticidadFrecuencia.Items.Insert(0, new ListItem("---", "0"));
                DDLCuentasPerdida.Items.Insert(0, new ListItem("---", "0"));

                DDLBCadenaValor.Items.Insert(0, new ListItem("---", "0"));
                DDLBMacroproceso.Items.Insert(0, new ListItem("---", "0"));
                DDLBProceso.Items.Insert(0, new ListItem("---", "0"));
                DDLBSubproceso.Items.Insert(0, new ListItem("---", "0"));
                DDLBActividad.Items.Insert(0, new ListItem("---", "0"));

                DDLBPOMacroproceso.Items.Insert(0, new ListItem("---", "0"));

                DDLBPAMacroproceso.Items.Insert(0, new ListItem("---", "0"));
                DDLEstatus.Items.Insert(0, new ListItem("---", "0"));

            }
            catch (Exception ex)
            {
                ShowMessage($"Error al reiniciar: {ex}", 1, "Atención");
            }
        }

        private void resetInputs()
        {
            try
            {
                TBCodigo.Text = "";
                TBDescripcion.Text = "";
                TBFRegistro.Text = "";
                TBFechaOcurrencia.Text = "";
                TBFechaDescubrimiento.Text = "";
                TBDescripcionEvento.Text = "";
                TBTituloEvento.Text = "";
                TBMontoBruto.Text = "";
                TBMontoExposicion.Text = "";
                TBFRegistroPerdida.Text = "";
                TBRecuperacionSeguro.Text = "";
                TBRecuperaciones.Text = "";
                TBCuentaRecuperacion.Text = "";
                TBFRegistroContable.Text = "";
                TBValorFrecuencia.Text = "";
                TBNotas.Text = "";

                TBBCodigoPlan.Text = "";
                TBBNombrePlan.Text = "";

                TBBCodigoRiesgo.Text = "";
                TBBNombreRiesgo.Text = "";

                TBBPONombre.Text = "";

            }
            catch (Exception ex)
            {
                ShowMessage($"Error al reiniciar: {ex}", 1, "Atención");
            }
        }

        private void resetFormEvsEIncs()
        {
            TBIdEvsEIncs.Text = "";
            TbConEventos.Visible = false;
            TbRelMultiple.Visible = false;
        }

        private void resetDDL(DropDownList DDLReset)
        {
            DDLReset.Items.Clear();
            DDLReset.Items.Insert(0, new ListItem("---", "0"));
        }
        #endregion Reset

        #region Buttons
        protected void BtnBuscarEvento_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                inicializarEvsEIncs();
                loadGridEvsEIncs();
                loadInfoEvsEIncs();
                TBCodigo.Text = TBDescripcion.Text = TBFRegistro.Text = string.Empty;
                RBLEventoIncident.Items.Clear();
                resetFormEvsEIncs();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al realizar la consulta: {ex}", 1, "Atención");
            }
        }

        protected void BtnBuscarEventoCancel_Click(object sender, ImageClickEventArgs e)
        {
            TBCodigo.Text = TBDescripcion.Text = TBFRegistro.Text = string.Empty;
            RBLEventoIncident.Items.Clear();
            resetFormEvsEIncs();
        }

        protected void BtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                PageValidate_Addne();
                PageValidate_AddneCamposDecimal();
                PageValidate_TabRiesgo();
                

                if (string.IsNullOrEmpty(TBHiddenCodigoEvsEIncs.Text))
                {
                    GuardarEvento();
                }
                else
                {
                    ModificarEvento();
                }

            }
            catch (FormatException)
            {
                ShowMessage("Revise los campos numéricos, alguno(s) no son válidos", 1, "Atencion");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, 1, "Atencion");
            }
        }

        protected void BtnGuardarCancel_Click(object sender, ImageClickEventArgs e)
        {
            resetFormEvsEIncs();
        }

        protected void BtnGuardarTodo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                PageValidate_Addne();
                PageValidate_AddneCamposDecimal();
                PageValidate_TabRiesgo();
                PageValidate_AddneRCamposDecimal();
                if (string.IsNullOrEmpty(TBHiddenCodigoEvsEIncs.Text))
                {
                    GuardarEvento();
                }
                else
                {
                    ModificarEvento();
                }


            }
            catch (FormatException)
            {
                ShowMessage("Revise los campos numéricos, alguno(s) no son válidos", 1, "Atencion");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, 1, "Atencion");
            }
        }

        protected void BtnGuardarTodoCancel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void BtnDesEnlazarPlan_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (!TBIdPlan.Text.Equals(""))
                {
                    cEvsEIncs.RelacionarPlanes(TBIdEvsEIncs.Text.ToString(), TBIdPlan.Text);
                    GVPlanes_reload();
                    TBCodigoPlan.Focus();
                }
                else
                {
                    ShowMessage("Seleccione un plan", 1, "Atención");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error asociando/desasociando plan: {ex}", 1, "Atención");
            }
        }

        protected void BtnBuscarPlan_Click(object sender, ImageClickEventArgs e)
        {
            GVPlanes_reload();
        }

        protected void BtnBuscarPlanCancel_Click(object sender, ImageClickEventArgs e)
        {
            TBBCodigoPlan.Text = "";
            TBBNombrePlan.Text = "";
            GVPlanes_reload();
        }

        protected void BtnDesEnlazarRiesgo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                if (!TBIdRiesgo.Text.Equals(""))
                {
                    if(cEvsEIncs.RelacionarRiesgos(TBIdEvsEIncs.Text.ToString(), TBIdRiesgo.Text).Equals("0"))
                    {
                        ShowMessage("No se puede asociar el riesgo. Supera el límite de eventos relacionados", 1, "Atención"); 
                    }
                    else
                    {
                        LoadCriticidadRiesgoByRiesgo(TBIdRiesgo.Text);
                        GVRiesgos_reload();
                    }
                }
                else
                {
                    ShowMessage("Seleccione un riesgo", 1, "Atención");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error asociando/desasociando riesgo: {ex}", 1, "Atención");
            }
        }

        protected void BtnBuscarRiesgo_Click(object sender, ImageClickEventArgs e)
        {
            GVRiesgos_reload();
        }

        protected void BtnBuscarRiesgoCancel_Click(object sender, ImageClickEventArgs e)
        {
            DDLBCadenaValor.Items.Clear();
            DDLBMacroproceso.Items.Clear();
            DDLBProceso.Items.Clear();
            DDLBSubproceso.Items.Clear();
            DDLBActividad.Items.Clear();

            DDLBCadenaValor.Items.Insert(0, new ListItem("---", "0"));
            DDLBMacroproceso.Items.Insert(0, new ListItem("---", "0"));
            DDLBProceso.Items.Insert(0, new ListItem("---", "0"));
            DDLBSubproceso.Items.Insert(0, new ListItem("---", "0"));
            DDLBActividad.Items.Insert(0, new ListItem("---", "0"));

            loadInitialData();

            TBBCodigoRiesgo.Text = "";
            TBBNombreRiesgo.Text = "";

            GVRiesgos_reload();
        }

        protected void BtnDesEnlazarProcesoO_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                if (!TBIdProcesoO.Text.Equals(""))
                {
                    cEvsEIncs.RelacionarProcesoOriginador(TBIdEvsEIncs.Text.ToString(), TBIdProcesoO.Text);
                    GVProcesoO_reload();
                }
                else
                {
                    ShowMessage("Seleccione un proceso originador", 1, "Atención");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error asociando/desasociando proceso originador: {ex}", 1, "Atención");
            }
        }

        protected void BtnBuscarProcesoO_Click(object sender, ImageClickEventArgs e)
        {
            GVProcesoO_reload();
        }

        protected void BtnBuscarProcesoOCancel_Click(object sender, ImageClickEventArgs e)
        {
            DDLBPOMacroproceso.Items.Clear();
            DDLBPOMacroproceso.Items.Insert(0, new ListItem("---", "0"));

            TBBPONombre.Text = "";

            loadInitialData();
            GVProcesoO_reload();
        }

        protected void BtnDesEnlazarProcesoA_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                if (!TBIdProcesoA.Text.Equals(""))
                {
                    cEvsEIncs.RelacionarProcesoAfectado(TBIdEvsEIncs.Text.ToString(), TBIdProcesoA.Text);
                    GVProcesoA_reload();
                }
                else
                {
                    ShowMessage("Seleccione un proceso afectado", 1, "Atención");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error asociando/desasociando proceso afectado: {ex}", 1, "Atención");
            }
        }

        protected void BtnBuscarProcesoA_Click(object sender, ImageClickEventArgs e)
        {
            GVProcesoA_reload();
        }

        protected void BtnBuscarProcesoACancel_Click(object sender, ImageClickEventArgs e)
        {
            DDLBPAMacroproceso.Items.Clear();
            DDLBPAMacroproceso.Items.Insert(0, new ListItem("---", "0"));

            TBBPANombre.Text = "";

            loadInitialData();
            GVProcesoA_reload();
        }

        protected void BtnSubirArchivo_Click(object sender, EventArgs e)
        {
            if (FUEventoArchivo.HasFile)
            {
                CargarPdfEvento();
                GVArchivos_reload();
            }
            else
                ShowMessage($"Debe cargar un archivo", 1, "Atención");
        }

        #endregion Buttons

        #region Loads

        private void loadInitialData()
        {
            try
            {
                loadDDLCuentasPerdida();
                loadDDLFuenteReporte();
                loadDDLRiesgoGlobal();
                loadDDLEstadoReporte();
                loadDDLCodigoBanco();
                loadDDLCategoria();
                loadDDLModalidad();
                loadDescripcionLineas();
                loadDDLTipoRiesgo();
                loadDDLProductoAfectado();
                loadDDLsDescFrecuencia();
                loadDDLsDescSeveridad();
                loadDDLBCadenaValor();
                loadDDLBPMacroproceso();
                loadDDLEstatus();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar información inicial: {ex}", 1, "Atención");
            }
        }
        private void loadDDLCuentasPerdida()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLCuentasPerdida();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLCuentasPerdida.Items.Insert(i + 1, new ListItem(dtInfoRow["Descripcion"].ToString().Trim(), dtInfoRow["IdCuentas"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLCodigoBanco()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLCodigoBanco();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLCodigoBanco.Items.Insert(i + 1, new ListItem(dtInfoRow["Codigo"].ToString().Trim(), dtInfoRow["IdCodigoBanco"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLCategoria()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLCategoria();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLCategoria.Items.Insert(i + 1, new ListItem(dtInfoRow["Categoria"].ToString().Trim(), dtInfoRow["IdCategoria"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLModalidad()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                resetDDL(DDLModalidad);

                dtInfo = cEvsEIncs.LoadDDLModalidad();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLModalidad.Items.Insert(i + 1, new ListItem(dtInfoRow["Modalidad"].ToString().Trim(), dtInfoRow["IdModalidad"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void loadDDLFuenteReporte()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLFuenteReporte();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLFuenteReporte.Items.Insert(i + 1, new ListItem(dtInfoRow["Fuente"].ToString().Trim(), dtInfoRow["IdFuenteReporte"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLRiesgoGlobal()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLRiesgoGlobal();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLRiesgoGlobal.Items.Insert(i + 1, new ListItem(dtInfoRow["RiesgoGlobal"].ToString().Trim(), dtInfoRow["IdClasificacionRiesgo"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLEstadoReporte()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLEstadoReporte();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLEstadoReporte.Items.Insert(i + 1, new ListItem(dtInfoRow["EstadoReporte"].ToString().Trim(), dtInfoRow["IdEstadoReporte"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDescripcionLineas()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDescripcionLineas();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLFiltroLineaUno.Items.Insert(i + 1, new ListItem(dtInfoRow["Descripcion"].ToString().Trim(), dtInfoRow["IdDescLineaUno"].ToString()));
                    DDLFiltroLineaDos.Items.Insert(i + 1, new ListItem(dtInfoRow["Descripcion"].ToString().Trim(), dtInfoRow["IdDescLineaUno"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLTipoRiesgo()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;
                resetDDL(DDLTipoRiesgo);
                dtInfo = cEvsEIncs.LoadDDLTipoRiesgo();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLTipoRiesgo.Items.Insert(i + 1, new ListItem(dtInfoRow["TipoRiesgo"].ToString().Trim(), dtInfoRow["IdTipoRiesgo"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLProductoAfectado()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLProductoAfectado();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLProductoAfectado.Items.Insert(i + 1, new ListItem(dtInfoRow["Producto"].ToString().Trim(), dtInfoRow["IdProductoAfectado"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDescripcionLineas(DropDownList DDLLineaDos, string IdLineaUno)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                if (IdLineaUno != "---")
                {
                    resetDDL(DDLLineaDos);
                    dtInfo = cEvsEIncs.LoadDescripcionLineas(IdLineaUno);

                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        dtInfoRow = dtInfo.Rows[i];
                        DDLLineaDos.Items.Insert(i + 1, new ListItem(dtInfoRow["Descripcion"].ToString().Trim(), dtInfoRow["IdDescLineaDos"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLCausaRiesgoUno()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLCausaRiesgoUno(DDLTipoRiesgo.SelectedValue);
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLCausaRiesgoUno.Items.Insert(i + 1, new ListItem(dtInfoRow["Descripcion"].ToString().Trim(), dtInfoRow["IdDesCausaNUno"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLCausaRiesgoUno1(string idCausaNivel1)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLCausaRiesgoUno(idCausaNivel1);
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLCausaRiesgoUno.Items.Insert(i + 1, new ListItem(dtInfoRow["Descripcion"].ToString().Trim(), dtInfoRow["IdDesCausaNUno"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLCausaRiesgoDos()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;
                string IdCausaRiesgoUno = DDLCausaRiesgoUno.SelectedValue.ToString().Trim();

                if (IdCausaRiesgoUno != "---")
                {
                    dtInfo = cEvsEIncs.LoadDDLCausaRiesgoDos(IdCausaRiesgoUno);

                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        dtInfoRow = dtInfo.Rows[i];
                        DDLCausaRiesgoDos.Items.Insert(i + 1, new ListItem(dtInfoRow["Descripcion"].ToString().Trim(), dtInfoRow["IdDesCausaNDos"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLCausaRiesgoDos1(string idCausaNivel2)
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;
                string IdCausaRiesgoUno = DDLCausaRiesgoUno.SelectedValue.ToString().Trim();

                if (IdCausaRiesgoUno != "---")
                {
                    dtInfo = cEvsEIncs.LoadDDLCausaRiesgoDos(IdCausaRiesgoUno);

                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        dtInfoRow = dtInfo.Rows[i];
                        DDLCausaRiesgoDos.Items.Insert(i + 1, new ListItem(dtInfoRow["Descripcion"].ToString().Trim(), dtInfoRow["IdDesCausaNDos"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLFactorRO()
        {
            try
            {
                resetDDL(DDLFactorRO);
                if (DDLCausaRiesgoDos.SelectedValue != "0")
                {
                    DataTable dtInfo = new DataTable();
                    DataRow dtInfoRow = null;

                    dtInfo = cEvsEIncs.LoadDDLFactorRO(DDLCausaRiesgoDos.SelectedValue);
                    dtInfoRow = dtInfo.Rows[0];

                    DDLFactorRO.Items.Insert(1, new ListItem(dtInfoRow["Descripcion"].ToString().Trim(), dtInfoRow["IdDesFactorRO"].ToString()));
                    DDLFactorRO.SelectedValue = dtInfoRow["IdDesFactorRO"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLOrigen()
        {
            try
            {
                resetDDL(DDLOrigen);

                if (DDLFactorRO.SelectedValue != "0")
                {
                    DataTable dtInfo = new DataTable();
                    DataRow dtInfoRow = null;

                    dtInfo = cEvsEIncs.LoadDDLOrigen(DDLFactorRO.SelectedValue);

                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        dtInfoRow = dtInfo.Rows[i];
                        DDLOrigen.Items.Insert(i + 1, new ListItem(dtInfoRow["Origen"].ToString().Trim(), dtInfoRow["IdOrigen"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void loadDDLsDescFrecuencia()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;
                int AuxCont = 0;

                dtInfo = cEvsEIncs.LoadDDLsDescFrecuencia();

                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    AuxCont = i + 1;
                    DDLCriticidad.Items.Insert(AuxCont, new ListItem(dtInfoRow["DescripcionFicohsa"].ToString().Trim(), dtInfoRow["IdDescFrecuencia"].ToString()));
                    DDLCriticidadFrecuencia.Items.Insert(AuxCont, new ListItem(dtInfoRow["DescripcionFicohsa"].ToString().Trim(), dtInfoRow["IdDescFrecuencia"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLsDescSeveridad()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLsDescSeveridad();

                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLCriticidadSeveridadNota.Items.Insert(i + 1, new ListItem(dtInfoRow["DescripcionFicohsa"].ToString().Trim(), dtInfoRow["IdDescSeveridad"].ToString()));
                    DDLCriticidadSeveridad.Items.Insert(i + 1, new ListItem(dtInfoRow["DescripcionFicohsa"].ToString().Trim(), dtInfoRow["IdDescSeveridad"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLEstatus()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLEstatus();
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLEstatus.Items.Insert(i + 1, new ListItem(dtInfoRow["Estado"].ToString().Trim(), dtInfoRow["IdEstadoEvsEIncs"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLBCadenaValor()
        {
            try
            {
                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLBCadenaValor();

                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLBCadenaValor.Items.Insert(i + 1, new ListItem(dtInfoRow["NombreCadenaValor"].ToString().Trim(), dtInfoRow["IdCadenaValor"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLBPMacroproceso()
        {
            try
            {
                resetDDL(DDLBPOMacroproceso);
                resetDDL(DDLBPAMacroproceso);

                DataTable dtInfo = new DataTable();
                DataRow dtInfoRow = null;

                dtInfo = cEvsEIncs.LoadDDLBMacroproceso();

                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    dtInfoRow = dtInfo.Rows[i];
                    DDLBPOMacroproceso.Items.Insert(i + 1, new ListItem(dtInfoRow["Nombre"].ToString().Trim(), dtInfoRow["IdMacroproceso"].ToString()));
                    DDLBPAMacroproceso.Items.Insert(i + 1, new ListItem(dtInfoRow["Nombre"].ToString().Trim(), dtInfoRow["IdMacroproceso"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLBMacroproceso()
        {
            try
            {
                resetDDL(DDLBMacroproceso);
                if (DDLBCadenaValor.SelectedValue != "0")
                {
                    DataTable dtInfo = new DataTable();
                    DataRow dtInfoRow = null;

                    dtInfo = cEvsEIncs.LoadDDLBMacroproceso(DDLBCadenaValor.SelectedValue);

                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        dtInfoRow = dtInfo.Rows[i];
                        DDLBMacroproceso.Items.Insert(i + 1, new ListItem(dtInfoRow["Nombre"].ToString().Trim(), dtInfoRow["IdMacroproceso"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLBProceso()
        {
            try
            {
                resetDDL(DDLBProceso);
                if (DDLBMacroproceso.SelectedValue != "0")
                {
                    DataTable dtInfo = new DataTable();
                    DataRow dtInfoRow = null;

                    dtInfo = cEvsEIncs.LoadDDLBProceso(DDLBMacroproceso.SelectedValue);

                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        dtInfoRow = dtInfo.Rows[i];
                        DDLBProceso.Items.Insert(i + 1, new ListItem(dtInfoRow["Nombre"].ToString().Trim(), dtInfoRow["IdProceso"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLBSubproceso()
        {
            try
            {
                resetDDL(DDLBSubproceso);
                if (DDLBProceso.SelectedValue != "0")
                {
                    DataTable dtInfo = new DataTable();
                    DataRow dtInfoRow = null;

                    dtInfo = cEvsEIncs.LoadDDLBSubproceso(DDLBProceso.SelectedValue);

                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        dtInfoRow = dtInfo.Rows[i];
                        DDLBSubproceso.Items.Insert(i + 1, new ListItem(dtInfoRow["Nombre"].ToString().Trim(), dtInfoRow["IdSubproceso"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadDDLBActividad()
        {
            try
            {
                resetDDL(DDLBActividad);
                if (DDLBSubproceso.SelectedValue != "0")
                {
                    DataTable dtInfo = new DataTable();
                    DataRow dtInfoRow = null;

                    dtInfo = cEvsEIncs.LoadDDLBActividad(DDLBSubproceso.SelectedValue);

                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        dtInfoRow = dtInfo.Rows[i];
                        DDLBActividad.Items.Insert(i + 1, new ListItem(dtInfoRow["Nombre"].ToString().Trim(), dtInfoRow["IdActividad"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void loadGridEvsEIncs()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("IdEvsEIncs", typeof(string));
            grid.Columns.Add("CodigoEvsEIncs", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("DescripcionEvento", typeof(string));

            InfoGridEvsEIncs = grid;
            GVEvsEIncs.DataSource = InfoGridEvsEIncs;
            GVEvsEIncs.DataBind();
        }

        private void loadGridPlanes()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("Id", typeof(string));
            grid.Columns.Add("CodigoPlan", typeof(string));
            grid.Columns.Add("DescripcionPlan", typeof(string));
            grid.Columns.Add("NombrePlan", typeof(string));
            grid.Columns.Add("Responsable", typeof(string));
            grid.Columns.Add("Estado", typeof(string));
            grid.Columns.Add("FechaCompromiso", typeof(string));
            grid.Columns.Add("FechaExtension", typeof(string));
            grid.Columns.Add("FechaImplementacion", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));
            grid.Columns.Add("Relacion", typeof(string));

            GVPlanes.PageIndex = PagIndexInfoGridPlanes;
            InfoGridPlanes = grid;
            GVPlanes.DataSource = InfoGridPlanes;
            GVPlanes.DataBind();
        }

        private void loadGridRiesgos()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("IdRiesgo", typeof(string));
            grid.Columns.Add("Codigo", typeof(string));
            grid.Columns.Add("Nombre", typeof(string));
            grid.Columns.Add("Descripcion", typeof(string));
            grid.Columns.Add("NCadenaValor", typeof(string));
            grid.Columns.Add("NMacroproceso", typeof(string));
            grid.Columns.Add("NProceso", typeof(string));
            grid.Columns.Add("NSubproceso", typeof(string));
            grid.Columns.Add("NActividad", typeof(string));
            //grid.Columns.Add("Estado", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Relacion", typeof(string));

            GVRiesgos.PageIndex = PagIndexInfoGridRiesgos;
            InfoGridRiesgos = grid;
            GVRiesgos.DataSource = InfoGridRiesgos;
            GVRiesgos.DataBind();
        }

        private void loadGridProcesoO()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("IdProceso", typeof(string));
            grid.Columns.Add("IdMacroProceso", typeof(string));
            grid.Columns.Add("Nombre", typeof(string));
            grid.Columns.Add("Descripcion", typeof(string));
            grid.Columns.Add("NMacroproceso", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Relacion", typeof(string));

            GVProcesoO.PageIndex = PagIndexInfoGridProcesoO;
            InfoGridProcesoO = grid;
            GVProcesoO.DataSource = InfoGridProcesoO;
            GVProcesoO.DataBind();
        }

        private void loadGridProcesoA()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("IdProceso", typeof(string));
            grid.Columns.Add("IdMacroProceso", typeof(string));
            grid.Columns.Add("Nombre", typeof(string));
            grid.Columns.Add("Descripcion", typeof(string));
            grid.Columns.Add("NMacroproceso", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));
            grid.Columns.Add("Relacion", typeof(string));

            GVProcesoA.PageIndex = PagIndexInfoGridProcesoA;
            InfoGridProcesoA = grid;
            GVProcesoA.DataSource = InfoGridProcesoA;
            GVProcesoA.DataBind();
        }

        private void loadGridArchivos()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("IdArchivo", typeof(string));
            grid.Columns.Add("UrlArchivo", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));

            GVArchivos.PageIndex = PagIndexInfoGridArchivos;
            InfoGridArchivos = grid;
            GVArchivos.DataSource = InfoGridArchivos;
            GVArchivos.DataBind();
        }


        private void loadGridJustificacion()
        {
            DataTable grid = new DataTable();
            grid.Columns.Add("IdJustificacion_EvsEIncs", typeof(string));
            grid.Columns.Add("Justificacion", typeof(string));
            grid.Columns.Add("Usuario", typeof(string));
            grid.Columns.Add("FechaRegistro", typeof(string));

            GVJustificacion.PageIndex = PagIndexInfoGridJustificacion;
            InfoGridJustificacion = grid;
            GVJustificacion.DataSource = InfoGridJustificacion;
            GVJustificacion.DataBind();
        }

        private void loadInfoEvsEIncs()
        {
            DataTable dtInfo = new DataTable();

            dtInfo = cEvsEIncs.LoadInfoEvsEIncs(TBCodigo.Text.Trim(), TBDescripcion.Text.Trim(), TBFRegistro.Text.Trim());
            if (dtInfo.Rows.Count > 0)
            {
                for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                {
                    TbEvsEIncs.Visible = true;
                    string DescripcionEvento = dtInfo.Rows[rows]["DescripcionEvento"].ToString();
                    DescripcionEvento = DescripcionEvento.Length > 50 ? DescripcionEvento.Substring(0, 50) + "..." : DescripcionEvento;

                    InfoGridEvsEIncs.Rows.Add(new Object[] {
                                                            dtInfo.Rows[rows]["IdEvsEIncs"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["CodigoEvsEIncs"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                            DescripcionEvento
                                                          });
                }

                GVEvsEIncs.PageIndex = PagIndexInfoGridEvsEIncs;
                GVEvsEIncs.DataSource = InfoGridEvsEIncs;
                GVEvsEIncs.DataBind();
            }
            else
            {
                loadGridEvsEIncs();
                TbEvsEIncs.Visible = false;
                ShowMessage($"No se encontraron eventos", 1, "Atención");
            }
        }

        private void loadInfoPlanes()
        {
            try
            {
                DataTable dtInfo = new DataTable();

                dtInfo = cEvsEIncs.LoadInfoPlanes(TBIdEvsEIncs.Text, TBBCodigoPlan.Text, TBBNombrePlan.Text);

                if (dtInfo.Rows.Count > 0)
                {
                    for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                    {
                        TbPlanes.Visible = true;
                        string FechaImplementacion = dtInfo.Rows[rows]["FechaImplementacion"].ToString().Trim() == "9999-12-31" ? "" : dtInfo.Rows[rows]["FechaImplementacion"].ToString().Trim();
                        InfoGridPlanes.Rows.Add(new Object[] {
                                                            dtInfo.Rows[rows]["Id"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["CodigoPlan"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["DescripcionPlan"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["NombrePlan"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["Responsable"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["Estado"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["FechaCompromiso"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["FechaExtension"].ToString().Trim(),
                                                            FechaImplementacion,
                                                            dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["Usuario"].ToString().Trim(),
                                                            dtInfo.Rows[rows]["Relacion"].ToString().Trim(),

                                                          });
                    }

                    GVPlanes.PageIndex = PagIndexInfoGridPlanes;
                    GVPlanes.DataSource = InfoGridPlanes;
                    GVPlanes.DataBind();
                }
                else
                {
                    loadGridPlanes();
                    TbPlanes.Visible = false;
                    ShowMessage($"No se encontraron planes", 1, "Atención");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error cargando planes: {ex}", 1, "");
            }
        }

        private void loadInfoRiesgos()
        {
            try
            {
                DataTable dtInfo = new DataTable();

                dtInfo = cEvsEIncs.LoadInfoRiesgos(TBIdEvsEIncs.Text, TBBIdRiesgo.Text, TBBCodigoRiesgo.Text, TBBNombreRiesgo.Text, DDLBCadenaValor.Text, DDLBMacroproceso.Text, DDLBProceso.Text, DDLBSubproceso.Text, DDLBActividad.Text);

                if (dtInfo.Rows.Count > 0)
                {
                    for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                    {
                        TbRiesgos.Visible = true;
                        InfoGridRiesgos.Rows.Add(new Object[] {
                                                                dtInfo.Rows[rows]["IdRiesgo"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Codigo"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Nombre"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Descripcion"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["NCadenaValor"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["NMacroproceso"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["NProceso"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["NSubproceso"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["NActividad"].ToString().Trim(),
                                                                //dtInfo.Rows[rows]["Estado"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Relacion"].ToString().Trim(),

                                                              });
                    }

                    GVRiesgos.PageIndex = PagIndexInfoGridRiesgos;
                    GVRiesgos.DataSource = InfoGridRiesgos;
                    GVRiesgos.DataBind();
                }
                else
                {
                    loadGridRiesgos();
                    TbRiesgos.Visible = false;
                    ShowMessage($"No se encontraron riesgos", 1, "Atención");
                }

            }
            catch (Exception ex)
            {
                ShowMessage($"Error cargando riesgos: {ex}", 1, "");
            }
        }
        private void loadInfoProcesoO()
        {
            try
            {
                DataTable dtInfo = new DataTable();

                dtInfo = cEvsEIncs.LoadInfoProcesoO(TBIdEvsEIncs.Text, DDLBPOMacroproceso.Text, TBBPONombre.Text);

                if (dtInfo.Rows.Count > 0)
                {
                    for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                    {
                        TbProcesoO.Visible = true;
                        InfoGridProcesoO.Rows.Add(new Object[] {
                                                                dtInfo.Rows[rows]["IdProceso"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["IdMacroProceso"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Nombre"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Descripcion"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["NMacroproceso"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Relacion"].ToString().Trim(),
                                                              });
                    }

                    GVProcesoO.PageIndex = PagIndexInfoGridProcesoO;
                    GVProcesoO.DataSource = InfoGridProcesoO;
                    GVProcesoO.DataBind();
                }
                else
                {
                    loadGridProcesoO();
                    TbProcesoO.Visible = false;
                    ShowMessage($"No se encontraron procesos", 1, "Atención");
                }

            }
            catch (Exception ex)
            {
                ShowMessage($"Error cargando procesos: {ex}", 1, "");
            }
        }

        private void loadInfoProcesoA()
        {
            try
            {
                DataTable dtInfo = new DataTable();

                dtInfo = cEvsEIncs.LoadInfoProcesoA(TBIdEvsEIncs.Text, DDLBPAMacroproceso.Text, TBBPANombre.Text);

                if (dtInfo.Rows.Count > 0)
                {
                    for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                    {
                        TbProcesoA.Visible = true;
                        InfoGridProcesoA.Rows.Add(new Object[] {
                                                                dtInfo.Rows[rows]["IdProceso"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["IdMacroProceso"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Nombre"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Descripcion"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["NMacroproceso"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Relacion"].ToString().Trim(),
                                                              });
                    }

                    GVProcesoA.PageIndex = PagIndexInfoGridProcesoA;
                    GVProcesoA.DataSource = InfoGridProcesoA;
                    GVProcesoA.DataBind();
                }
                else
                {
                    loadGridProcesoA();
                    TbProcesoA.Visible = false;
                    ShowMessage($"No se encontraron procesos", 1, "Atención");
                }

            }
            catch (Exception ex)
            {
                ShowMessage($"Error cargando procesos: {ex}", 1, "");
            }
        }

        private void loadInfoArchivos()
        {
            try
            {
                DataTable dtInfo = new DataTable();

                dtInfo = cEvsEIncs.LoadInfoArchivos(TBIdEvsEIncs.Text);

                if (dtInfo.Rows.Count > 0)
                {
                    for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                    {
                        TbArchivos.Visible = true;
                        InfoGridArchivos.Rows.Add(new Object[] {
                                                                dtInfo.Rows[rows]["IdArchivo"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["UrlArchivo"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Usuario"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                              });
                    }

                    GVArchivos.PageIndex = PagIndexInfoGridArchivos;
                    GVArchivos.DataSource = InfoGridArchivos;
                    GVArchivos.DataBind();
                }
                else
                {
                    loadGridArchivos();
                    TbArchivos.Visible = false;
                    //ShowMessage($"No se encontraron procesos", 1, "Atención");
                }

            }
            catch (Exception ex)
            {
                ShowMessage($"Error cargando procesos: {ex}", 1, "");
            }
        }

        private void loadInfoJustificacion()
        {
            try
            {
                DataTable dtInfo = new DataTable();

                dtInfo = cEvsEIncs.LoadInfoJustificacion(TBIdEvsEIncs.Text);

                if (dtInfo.Rows.Count > 0)
                {
                    for (int rows = 0; rows < dtInfo.Rows.Count; rows++)
                    {
                        TblJustificacion.Visible = true;
                        InfoGridJustificacion.Rows.Add(new Object[] {
                                                                dtInfo.Rows[rows]["IdJustificacion_EvsEIncs"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Justificacion"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["Usuario"].ToString().Trim(),
                                                                dtInfo.Rows[rows]["FechaRegistro"].ToString().Trim(),
                                                              });
                    }

                    GVJustificacion.PageIndex = PagIndexInfoGridJustificacion;
                    GVJustificacion.DataSource = InfoGridJustificacion;
                    GVJustificacion.DataBind();
                }
                else
                {
                    loadGridJustificacion();
                    TblJustificacion.Visible = false;
                }

            }
            catch (Exception ex)
            {
                ShowMessage($"Error cargando procesos: {ex}", 1, "");
            }
        }

        private void loadDataEvsEInc()
        {
            DataTable dtInfo = new DataTable();

            try
            {
                dtInfo = cEvsEIncs.LoadDataEvsEInc(TBIdEvsEIncs.Text.ToString());
                DataRow dtInfoRow = dtInfo.Rows[0];
                DDLFuenteReporte.SelectedValue = dtInfoRow["IdFuenteReporte"].ToString().Trim();
                DDLRiesgoGlobal.SelectedValue = dtInfoRow["IdRiesgoGlobal"].ToString().Trim();
                DDLEstadoReporte.SelectedValue = dtInfoRow["IdEstadoReporte"].ToString().Trim();
                DDLCodigoBanco.SelectedValue = dtInfoRow["IdCodigoBanco"].ToString().Trim();
                TBFechaOcurrencia.Text = toDate(dtInfoRow["FechaOcurrencia"].ToString().Trim());
                TBFechaDescubrimiento.Text = toDate(dtInfoRow["FechaDescubrimiento"].ToString().Trim());
                TBDescripcionEvento.Text = dtInfoRow["DescripcionEvento"].ToString().Trim();
                TBTituloEvento.Text = dtInfoRow["TituloEvento"].ToString().Trim();
                DDLCategoria.SelectedValue = dtInfoRow["IdCategoria"].ToString().Trim();
                bloquearPorCategoria();

                DDLModalidad.SelectedValue = dtInfoRow["IdModalidadOcurrencia"].ToString().Trim();
                bloquearPorModalidad(false);

                DDLFiltroLineaUno.SelectedValue = dtInfoRow["IdFiltroLineaUno"].ToString().Trim();
                loadDescripcionLineas(DDLLineaNegocioUno, DDLFiltroLineaUno.SelectedValue);
                DDLLineaNegocioUno.SelectedValue = dtInfoRow["IdFiltroDosLineaUno"].ToString().Trim();

                DDLFiltroLineaDos.SelectedValue = dtInfoRow["IdFiltroLineaDos"].ToString().Trim();
                loadDescripcionLineas(DDLLineaNegocioDos, DDLFiltroLineaDos.SelectedValue);
                DDLLineaNegocioDos.SelectedValue = dtInfoRow["IdFiltroDosLineaDos"].ToString().Trim();

                DDLTipoRiesgo.SelectedValue = dtInfoRow["IdTipoRiesgo"].ToString().Trim();
                loadDDLCausaRiesgoUno();

                DDLCausaRiesgoUno.SelectedValue = dtInfoRow["IdCausaRiesgoN1"].ToString().Trim();
                loadDDLCausaRiesgoDos();
                DDLCausaRiesgoDos.SelectedValue = dtInfoRow["IdCausaRiesgoN2"].ToString().Trim();
                loadDDLFactorRO();
                DDLFactorRO.SelectedValue = dtInfoRow["IdFactorRO"].ToString().Trim();
                loadDDLOrigen();
                DDLOrigen.SelectedValue = dtInfoRow["IdOrigen"].ToString().Trim();

                DDLProductoAfectado.SelectedValue = dtInfoRow["IdProductoAfectado"].ToString().Trim();
                TBMontoBruto.Text = Convert.ToDouble(dtInfoRow["MontoBruto"].ToString().Trim()).ToString().Replace('.', ',');
                TBMontoExposicion.Text = Convert.ToDouble(dtInfoRow["MontoExposicion"].ToString().Trim()).ToString().Replace('.', ',');
                TBValorFrecuencia.Text = dtInfoRow["NEventos"].ToString().Trim();
                DDLCuentasPerdida.SelectedValue = dtInfoRow["IdCuentasPerdida"].ToString().Trim();
                TBFRegistroPerdida.Text = toDate(dtInfoRow["FechaRegistroPerdida"].ToString().Trim());
                TBRecuperacionSeguro.Text = Convert.ToDouble(dtInfoRow["RecuperacionSeguro"].ToString().Trim()).ToString().Replace('.', ',');
                TBRecuperaciones.Text = Convert.ToDouble(dtInfoRow["Recuperaciones"].ToString().Trim()).ToString().Replace('.', ',');
                TBCuentaRecuperacion.Text = dtInfoRow["CuentaRecuperacion"].ToString().Trim();
                TBFRegistroContable.Text = toDate(dtInfoRow["FechaRegistroContable"].ToString().Trim());
                DDLCriticidad.SelectedValue = dtInfoRow["IdCritFrecuenciaG"].ToString().Trim();
                DDLCriticidadSeveridadNota.SelectedValue = dtInfoRow["IdCritSeveridadG"].ToString().Trim();

                LoadMedicionRiesgo(DDLCriticidad.SelectedItem.ToString(), DDLCriticidadSeveridadNota.SelectedItem.ToString(), TBNRiesgo);

                DDLCriticidadFrecuencia.SelectedValue = dtInfoRow["IdCritFrecuenciaE"].ToString().Trim();
                DDLCriticidadSeveridad.SelectedValue = dtInfoRow["IdCritSeveridadE"].ToString().Trim();

                LoadMedicionRiesgo(DDLCriticidadFrecuencia.SelectedItem.ToString(), DDLCriticidadSeveridad.SelectedItem.ToString(), TBNRiesgoEspecifico);

                DDLEstatus.SelectedValue = dtInfoRow["IdEstatus"].ToString().Trim();
                TBFCierre.Text = toDate(dtInfoRow["FechaCierre"].ToString().Trim());
                ValEstatusProceso();

                TBNotas.Text = dtInfoRow["Notas"].ToString().Trim();
                TBBIdRiesgo.Text = dtInfoRow["IdRiesgo"].ToString().Trim();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar la información del evento / incidente. {ex}", 1, "Atención");
            }
        }

        #endregion Loads

        #region Métodos Usuario
        private void inicializarEvsEIncs()
        {
            PagIndexInfoGridEvsEIncs = 0;
        }

        private void inicializarPlanes()
        {
            PagIndexInfoGridPlanes = 0;
        }

        private void inicializarRiesgos()
        {
            PagIndexInfoGridRiesgos = 0;
        }

        private void inicializarProcesoO()
        {
            PagIndexInfoGridProcesoO = 0;
        }

        private void inicializarJustificacion()
        {
            PagIndexInfoGridJustificacion = 0;
        }

        private void inicializarProcesoA()
        {
            PagIndexInfoGridProcesoA = 0;
        }

        private void inicializarArchivos()
        {
            PagIndexInfoGridArchivos = 0;
        }

        protected void GVEvsEIncs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridEvsEIncs = e.NewPageIndex;
            GVEvsEIncs.PageIndex = PagIndexInfoGridEvsEIncs;
            GVEvsEIncs.DataSource = InfoGridEvsEIncs;
            GVEvsEIncs.DataBind();
        }

        protected void GVPlanes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridPlanes = e.NewPageIndex;
            GVPlanes.PageIndex = PagIndexInfoGridPlanes;
            GVPlanes.DataSource = InfoGridPlanes;
            GVPlanes.DataBind();
        }

        protected void GVJustificacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridJustificacion = e.NewPageIndex;
            GVJustificacion.PageIndex = PagIndexInfoGridJustificacion;
            GVJustificacion.DataSource = InfoGridJustificacion;
            GVJustificacion.DataBind();
        }

        protected void GVRiesgos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridRiesgos = e.NewPageIndex;
            GVRiesgos.PageIndex = PagIndexInfoGridRiesgos;
            GVRiesgos.DataSource = InfoGridRiesgos;
            GVRiesgos.DataBind();
        }

        protected void GVProcesoO_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridProcesoO = e.NewPageIndex;
            GVProcesoO.PageIndex = PagIndexInfoGridProcesoO;
            GVProcesoO.DataSource = InfoGridProcesoO;
            GVProcesoO.DataBind();
        }

        protected void GVProcesoA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridProcesoA = e.NewPageIndex;
            GVProcesoA.PageIndex = PagIndexInfoGridProcesoA;
            GVProcesoA.DataSource = InfoGridProcesoA;
            GVProcesoA.DataBind();
        }

        protected void GVArchivos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndexInfoGridArchivos = e.NewPageIndex;
            GVProcesoA.PageIndex = PagIndexInfoGridArchivos;
            GVProcesoA.DataSource = InfoGridArchivos;
            GVProcesoA.DataBind();
        }


        private void ShowMessage(string Message, int TipoImagen, string Caption)
        {

            switch (TipoImagen)
            {
                case 1: //Imagen de Error
                    imgInfo.ImageUrl = "~/Imagenes/Icons/icontexto-webdev-cancel.png";
                    break;
                case 2: //Imagen de Advertencia
                    imgInfo.ImageUrl = "~/Imagenes/Icons/icontexto-webdev-alert.png";
                    break;
                case 3: //Imagen de Ejecucion Satisfactoria
                    imgInfo.ImageUrl = "~/Imagenes/Icons/icontexto-webdev-ok.png";
                    break;
            }

            lblMsgBox.Text = Message;
            lblCaption.Text = Caption;
            tdCaption.Visible = true;
            mpeMsgBox.Show();
        }

        private void ShowInfoPlanes(System.Collections.Specialized.IOrderedDictionary colsNoVisible)
        {
            TBIdPlan.Text = colsNoVisible[0].ToString();
            TBCodigoPlan.Text = colsNoVisible[1].ToString();
            TBNombrePlan.Text = colsNoVisible[2].ToString();
            TBDescripcionPlan.Text = colsNoVisible[3].ToString();
            TBResponsable.Text = colsNoVisible[4].ToString();
            TBEstado.Text = colsNoVisible[5].ToString();
            TBFechaCompromiso.Text = colsNoVisible[6].ToString();
            TBFechaExtension.Text = colsNoVisible[7].ToString();
            TBFechaImplementacion.Text = colsNoVisible[8].ToString();
            TBFechaRegistro.Text = colsNoVisible[9].ToString();
            TBUsuario.Text = colsNoVisible[10].ToString();
        }

        private void ShowInfoRiesgos(System.Collections.Specialized.IOrderedDictionary colsNoVisible)
        {
            TBIdRiesgo.Text = colsNoVisible[0].ToString();
            TBCodigoRiesgo.Text = colsNoVisible[1].ToString();
            TBNombreRiesgo.Text = colsNoVisible[2].ToString();
            TBDescripcionRiesgo.Text = colsNoVisible[3].ToString();
            TBNCadenaValorRiesgo.Text = colsNoVisible[4].ToString();
            TBNMacroprocesoRiesgo.Text = colsNoVisible[5].ToString();
            TBNProcesoRiesgo.Text = colsNoVisible[6].ToString();
            TBNSubprocesoRiesgo.Text = colsNoVisible[7].ToString();
            TBNActividadRiesgo.Text = colsNoVisible[8].ToString();
            TBFechaRegistroRiesgo.Text = colsNoVisible[9].ToString();
        }

        private void ShowInfoProcesoO(System.Collections.Specialized.IOrderedDictionary colsNoVisible)
        {
            TBIdProcesoO.Text = colsNoVisible[0].ToString();
            TBNPOMacroproceso.Text = colsNoVisible[1].ToString();
            TBPONombre.Text = colsNoVisible[2].ToString();
            TBPODescripcion.Text = colsNoVisible[3].ToString();
            TBPOFechaRegistro.Text = colsNoVisible[4].ToString();
        }

        private void ShowInfoProcesoA(System.Collections.Specialized.IOrderedDictionary colsNoVisible)
        {
            TBIdProcesoA.Text = colsNoVisible[0].ToString();
            TBNPAMacroproceso.Text = colsNoVisible[1].ToString();
            TBPANombre.Text = colsNoVisible[2].ToString();
            TBPADescripcion.Text = colsNoVisible[3].ToString();
            TBPAFechaRegistro.Text = colsNoVisible[4].ToString();
        }
        private void ShowInfoJustificacion(System.Collections.Specialized.IOrderedDictionary colsNoVisible)
        {
            TBJustificacion.Text = colsNoVisible[1].ToString();
        }

        protected void RBLEvsEIncs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBLEventoIncident.SelectedIndex == 0)
            {
                TbConEventos.Visible = false;
                TbRelMultiple.Visible = false;
                resetDataBaseInfo();
                resetInputs();
                loadInitialData();
                TbEvsEIncs.Visible = false;
                TbConEventos.Visible = true;

                TBIdEvsEIncs.Text = "";
            }
            else if (RBLEventoIncident.SelectedIndex == 1)
            {
                TbConEventos.Visible = false;
                TbNohuboeventos.Visible = true;
                TextBox41.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                TextBox42.Text = Session["loginUsuario"].ToString().Trim();
                ddlEmpresa.SelectedIndex = 0;
            }
        }

        protected void BtnCancelaNoeventos_Click(object sender, ImageClickEventArgs e)
        {
            TbNohuboeventos.Visible = false;
            RBLEventoIncident.ClearSelection();
        }

        protected void BtnGuardaNoeventos_Click(object sender, ImageClickEventArgs e)
        {
            agregarNHEvento();
            TbNohuboeventos.Visible = false;
            RBLEventoIncident.ClearSelection();
            ddlEmpresa.SelectedIndex = 0;

            string NombreJerarquia = string.Empty;
            string NombreArea = string.Empty;
            string CodNHE = string.Empty;
            int IdEvento = 0;
            cEvento.mtdJerarquiaUsuario(Session["IdUsuario"].ToString(), ref NombreJerarquia, ref NombreArea);
            CodNHE = cEvento.mtdLastNoHuboEvento(ref IdEvento);

            //mtdGenerarNotificacionNoHuboEvento(CodNHE, NombreJerarquia, NombreArea, IdEvento, 30);

            ShowMessage("Evento (No Hubo Eventos) [" + strCodigoNHEvento + "] creado y almacenado correctamente ", 3, "Atención");
        }

        private void agregarNHEvento()
        {
            strCodigoNHEvento = string.Empty;
            cEvento.agregarNHEvento(ref strCodigoNHEvento, ddlEmpresa.SelectedItem.Value);
        }

        private void CargarPdfEvento()
        {
            Stream fs = FUEventoArchivo.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bPdfData = br.ReadBytes((Int32)fs.Length);

            cEvsEIncs.GuardarArchivo(TBIdEvsEIncs.Text.ToString(), FUEventoArchivo.PostedFile.FileName, bPdfData);
        }

        private string toDate(string Fecha) { return Fecha.Equals("") ? "" : Convert.ToDateTime(Fecha).ToString("yyyy-MM-dd"); }

        private void bloquearPorCategoria()
        {
            try
            {
                bool enabled = false;
                if (DDLCategoria.SelectedValue == "1")
                {
                    DDLCuentasPerdida.SelectedValue = "12";
                    TBFRegistroPerdida.Text = TBFRegistroContable.Text = string.Empty;
                    TBRecuperaciones.Text = TBRecuperacionSeguro.Text = "0,00";
                    TBCuentaRecuperacion.Text = "NA";
                }
                else
                    enabled = true;

                DDLCuentasPerdida.Enabled = TBFRegistroPerdida.Enabled = TBRecuperaciones.Enabled =
                    TBRecuperacionSeguro.Enabled = TBFRegistroContable.Enabled = TBCuentaRecuperacion.Enabled = enabled;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        private void bloquearPorModalidad(bool cargarLineas = true)
        {
            try
            {
                bool enabled = false;
                if (DDLModalidad.SelectedValue == "1")
                {
                    DDLFiltroLineaDos.SelectedValue = "9";

                    if(cargarLineas) loadDescripcionLineas(DDLLineaNegocioDos, DDLFiltroLineaDos.SelectedValue);

                    DDLLineaNegocioDos.SelectedValue = "21";
                }
                else
                {
                    DDLFiltroLineaDos.SelectedValue = DDLLineaNegocioDos.SelectedValue = "0";
                    enabled = true;
                }

                DDLFiltroLineaDos.Enabled = DDLLineaNegocioDos.Enabled = enabled;
            }
            catch(Exception ex)
            {

            }
        }

        #endregion Métodos Usuario

        #region Gridviews
        protected void GVEvsEIncs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Modificar":
                    System.Collections.Specialized.IOrderedDictionary colsNoVisible = GVEvsEIncs.DataKeys[Convert.ToInt16(e.CommandArgument)].Values;
                    TBIdEvsEIncs.Text = colsNoVisible[0].ToString();
                    TBHiddenCodigoEvsEIncs.Text = colsNoVisible[1].ToString();

                    loadDataEvsEInc();

                    TbConEventos.Visible = true;
                    TbRelMultiple.Visible = true;

                    ValidarObligatoriedadDatos();

                    GVJustificacion_reload();
                    GVPlanes_reload();
                    GVRiesgos_reload();
                    GVProcesoO_reload();
                    GVProcesoA_reload();
                    GVArchivos_reload();

                    break;
                default:
                    break;
            }
        }

        protected void GVPlanes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                System.Collections.Specialized.IOrderedDictionary colsNoVisible = GVPlanes.DataKeys[Convert.ToInt16(e.CommandArgument)].Values;

                switch (e.CommandName)
                {
                    case "DesEnlazar":

                        string IdPlan = colsNoVisible[0].ToString();
                        cEvsEIncs.RelacionarPlanes(TBIdEvsEIncs.Text.ToString(), IdPlan);
                        GVPlanes_reload();

                        break;

                    case "Ver":

                        ShowInfoPlanes(colsNoVisible);

                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al enlazar: {ex}", 1, "Atención");
            }
        }

        protected void GVRiesgos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                System.Collections.Specialized.IOrderedDictionary colsNoVisible = GVRiesgos.DataKeys[Convert.ToInt16(e.CommandArgument)].Values;

                switch (e.CommandName)
                {
                    case "DesEnlazar":

                        string IdRiesgo = colsNoVisible[0].ToString();
                        if(cEvsEIncs.RelacionarRiesgos(TBIdEvsEIncs.Text.ToString(), IdRiesgo).Equals("0"))
                        {
                            ShowMessage("No se puede asociar el riesgo. Supera el límite de eventos relacionados", 1, "Atención");
                        }
                        else
                        {
                            LoadCriticidadRiesgoByRiesgo(IdRiesgo);
                            GVRiesgos_reload(false);
                        }

                        break;

                    case "Ver":

                        ShowInfoRiesgos(colsNoVisible);

                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al enlazar: {ex}", 1, "Atención");
            }
        }

        protected void GVProcesoO_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                System.Collections.Specialized.IOrderedDictionary colsNoVisible = GVProcesoO.DataKeys[Convert.ToInt16(e.CommandArgument)].Values;

                switch (e.CommandName)
                {
                    case "DesEnlazar":

                        string IdProcesoOriginador = colsNoVisible[0].ToString();
                        cEvsEIncs.RelacionarProcesoOriginador(TBIdEvsEIncs.Text.ToString(), IdProcesoOriginador);
                        GVProcesoO_reload();

                        break;

                    case "Ver":

                        ShowInfoProcesoO(colsNoVisible);

                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al enlazar: {ex}", 1, "Atención");
            }
        }

        protected void GVProcesoA_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                System.Collections.Specialized.IOrderedDictionary colsNoVisible = GVProcesoA.DataKeys[Convert.ToInt16(e.CommandArgument)].Values; ;
                if (colsNoVisible != null)
                {

                    switch (e.CommandName)
                    {
                        case "DesEnlazar":

                            string IdProcesoAfectado = colsNoVisible[0].ToString();
                            cEvsEIncs.RelacionarProcesoAfectado(TBIdEvsEIncs.Text.ToString(), IdProcesoAfectado);
                            GVProcesoA_reload();

                            break;

                        case "Ver":

                            ShowInfoProcesoA(colsNoVisible);

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al enlazar: {ex}", 1, "Atención");
            }
        }

        protected void GVArchivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Descargar":

                        System.Collections.Specialized.IOrderedDictionary colsNoVisible = GVArchivos.DataKeys[Convert.ToInt16(e.CommandArgument)].Values;
                        string IdArchivo = colsNoVisible[0].ToString();
                        string strNombreArchivo = colsNoVisible[1].ToString();

                        byte[] DataPDF = cEvsEIncs.ConsultarDataPDF(IdArchivo);

                        if (DataPDF != null)
                        {
                            HttpResponse CResponse = HttpContext.Current.Response;

                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.ContentType = "Application/pdf";
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + "nombre.pdf");
                            HttpContext.Current.Response.Charset = "";
                            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            HttpContext.Current.Response.BinaryWrite(DataPDF);

                        }

                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception exc) { }
            finally
            {
                try
                {
                    //stop processing the script and return the current result
                    HttpContext.Current.Response.End();
                }
                catch (Exception ex) { }
                finally
                {
                    //Sends the response buffer
                    HttpContext.Current.Response.Flush();
                    // Prevents any other content from being sent to the browser
                    HttpContext.Current.Response.SuppressContent = true;
                    //Directs the thread to finish, bypassing additional processing
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    //Suspends the current thread
                    Thread.Sleep(1);
                }
            }
        }

        protected void GVJustificacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                System.Collections.Specialized.IOrderedDictionary colsNoVisible = GVJustificacion.DataKeys[Convert.ToInt16(e.CommandArgument)].Values;

                switch (e.CommandName)
                {
                    case "Ver":

                        ShowInfoJustificacion(colsNoVisible);

                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al enlazar: {ex}", 1, "Atención");
            }
        }

        #endregion Gridviews

        #region Validations

        private bool ValModalidad()
        {
            if (DDLModalidad.SelectedValue == "1") return DDLLineaNegocioDos.SelectedIndex == 21;

            return true;
        }
        private bool ValDDLLineas()
        {
            bool validate = false;

            if (DDLLineaNegocioUno.SelectedValue != DDLLineaNegocioDos.SelectedValue) validate = true;
            if (DDLLineaNegocioUno.SelectedValue == "" || DDLLineaNegocioDos.SelectedValue == "") validate = true;

            return validate;
        }

        private string ValMsgDDLLineas()
        {
            string valMessage = "";
            if (!ValDDLLineas())
            {
                DDLLineaNegocioDos.SelectedIndex = 0;
                valMessage = "Error: Las líneas de negocio no pueden ser iguales";
                ShowMessage(valMessage, 1, "Atención");
            }

            return valMessage;
        }

        private void ValDates(TextBox TBFecha, TextBox TBFechaAComparar, string TextFechaAComparar, bool MayorIgual = false)
        {
            try
            {
                bool validate = true;
                string mensaje = "";

                if (!TBFechaAComparar.Text.Equals(""))
                {
                    DateTime FechaBase = Convert.ToDateTime(TBFechaAComparar.Text);
                    DateTime FComparar = Convert.ToDateTime(TBFecha.Text);

                    if ((MayorIgual && FComparar < FechaBase) || (!MayorIgual && FComparar <= FechaBase))
                    {
                        TBFecha.Text = string.Empty;
                        validate = false;
                    }

                    if (!validate)
                    {
                        string compara = MayorIgual ? "mayor o igual" : "mayor";
                        mensaje = $"Esta fecha debe ser {compara} a la {TextFechaAComparar}";
                    }
                }
                else
                {
                    TBFecha.Text = string.Empty;
                    validate = false;
                    mensaje = $"Debe llenar la {TextFechaAComparar}";
                }

                if (!mensaje.Equals("")) ShowMessage(mensaje, 1, "Atención");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ValidarObligatoriedadDatos()
        {
            RequiredFieldValidator3.ValidationGroup = null;
            RequiredFieldValidator4.ValidationGroup = null;
            RequiredFieldValidator1.ValidationGroup = null;
            RequiredFieldValidator5.ValidationGroup = null;
            RequiredFieldValidator6.ValidationGroup = null;
            RequiredFieldValidator8.ValidationGroup = null;
            CompareValidator3.ValidationGroup = null;
            CompareValidator2.ValidationGroup = null;
            CompareValidator1.ValidationGroup = null;
            CompareValidator4.ValidationGroup = null;
            CompareValidator5.ValidationGroup = null;
            CompareValidator6.ValidationGroup = null;
            CompareValidator7.ValidationGroup = null;
            CompareValidator9.ValidationGroup = null;
            CompareValidator10.ValidationGroup = null;
            CompareValidator11.ValidationGroup = null;
            CompareValidator12.ValidationGroup = null;

            CompareValidator8.ValidationGroup = null;
            RequiredFieldValidator2.ValidationGroup = null;

            RequiredFieldValidator2.Visible = false;
            RequiredFieldValidator3.Visible = false;
            RequiredFieldValidator4.Visible = false;
            RequiredFieldValidator1.Visible = false;
            RequiredFieldValidator5.Visible = false;
            RequiredFieldValidator6.Visible = false;
            RequiredFieldValidator7.Visible = false;
            RequiredFieldValidator8.Visible = false;
            CompareValidator3.Visible = false;
            CompareValidator2.Visible = false;
            CompareValidator1.Visible = false;
            CompareValidator4.Visible = false;
            CompareValidator5.Visible = false;
            CompareValidator6.Visible = false;
            CompareValidator7.Visible = false;
            CompareValidator8.Visible = false;
            CompareValidator9.Visible = false;
            CompareValidator10.Visible = false;
            CompareValidator11.Visible = false;
            CompareValidator12.Visible = false;
        }

        private void ValEstatusProceso()
        {
            if (DDLEstatus.SelectedValue.Equals("2"))
            {
                TDCierre.Visible = true;
            }
            else
            {
                TBFCierre.Text = string.Empty;
                TDCierre.Visible = false;
            }
        }

        private void PageValidate_AddneCamposDecimal()
        {
            var AddneDecimal = new Dictionary<string, string>();

            AddneDecimal.Add("Monto Bruto de Exposición Inicial", TBMontoBruto.Text.Trim());
            AddneDecimal.Add("Monto Bruto de Exposición", TBMontoExposicion.Text.Trim());
            loopGroupDecimal(AddneDecimal, @"^\d+$|^\d+[,{1}]\d{2}$", "Entero/Decimal (Ej. 1,00)");

            var AddneEntero = new Dictionary<string, string>();
            AddneEntero.Add("Número de Eventos(Frecuencia)", TBValorFrecuencia.Text.Trim());
            loopGroupDecimal(AddneEntero, @"^\d+$", "Entero");

            //Montos mayores que 0.01
            if (Convert.ToDouble(TBMontoBruto.Text.Trim()) < 0.01 || Convert.ToDouble(TBMontoExposicion.Text.Trim()) < 0.01)
                throw new Exception($"Los campos de 'Monto Bruto de Exposición Inicial' y 'Monto Bruto de Exposición' deben ser mayores que 0.01");

            //Frecuencia mayor que 0
            if (Convert.ToDouble(TBValorFrecuencia.Text.Trim()) < 1)
                throw new Exception($"El campo de 'Número de Eventos(Frecuencia)' debe ser mayor/igual a 1");
        }

        private void PageValidate_AddneRCamposDecimal()
        {
            string regDecimal = @"^\d+$|^\d+[,{1}]\d{2}$";
            var AddneRDecimal = new Dictionary<string, string>();

            AddneRDecimal.Add("Monto Recuperado por Seguro", TBRecuperacionSeguro.Text.Trim());
            AddneRDecimal.Add("Monto de Otras Recuperaciones", TBRecuperaciones.Text.Trim());
            loopGroupDecimal(AddneRDecimal, regDecimal, "Entero/Decimal (Ej. 1,00)");
        }

        private void PageValidate_Addne()
        {
            try
            {
                #region AddneGroupTB
                var AddneGroupTB = new Dictionary<string, string>();

                AddneGroupTB.Add("Fecha de ocurrencia", TBFechaOcurrencia.Text.Trim());
                AddneGroupTB.Add("Fecha de descubrimiento", TBFechaDescubrimiento.Text.Trim());
                AddneGroupTB.Add("Descripción del evento", TBDescripcionEvento.Text.Trim());
                AddneGroupTB.Add("Título del evento", TBTituloEvento.Text.Trim());
                #endregion

                #region AddneGroupSelect
                var AddneGroupSelect = new Dictionary<string, string>();

                AddneGroupSelect.Add("Código del Banco", DDLCodigoBanco.SelectedValue.Trim());
                AddneGroupSelect.Add("Categoría", DDLCategoria.SelectedValue.Trim());
                AddneGroupSelect.Add("Modalidad de Ocurrencia", DDLModalidad.SelectedValue.Trim());
                AddneGroupSelect.Add("Tipo del Riesgo", DDLTipoRiesgo.SelectedValue.Trim());
                AddneGroupSelect.Add("Causa del Riesgo (Nivel 1)", DDLCausaRiesgoUno.SelectedValue.Trim());
                AddneGroupSelect.Add("Causa del Riesgo (Nivel 2)", DDLCausaRiesgoDos.SelectedValue.Trim());
                AddneGroupSelect.Add("Monto Bruto de Exposición Inicial", TBMontoBruto.Text.Trim());
                AddneGroupSelect.Add("Monto Bruto de Exposición", TBMontoExposicion.Text.Trim());
                AddneGroupSelect.Add("Línea 1", DDLFiltroLineaUno.SelectedValue.Trim());
                AddneGroupSelect.Add("Línea de Negocio 1 (Nivel 2)", DDLLineaNegocioUno.SelectedValue.Trim());
                AddneGroupSelect.Add("Línea 2", DDLFiltroLineaDos.SelectedValue.Trim());
                AddneGroupSelect.Add("Línea de Negocio 2 (Nivel 2)", DDLLineaNegocioDos.SelectedValue.Trim());
                AddneGroupSelect.Add("Origen", DDLOrigen.SelectedValue.Trim());
                AddneGroupSelect.Add("Producto Afectado", DDLProductoAfectado.SelectedValue.Trim());
                #endregion

                loopGroup(AddneGroupTB, "");
                loopGroup(AddneGroupSelect, "0");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void PageValidate_TabRiesgo()
        {
            try
            {
                #region AddneRGroupSelect
                var AddneRGroupSelect = new Dictionary<string, string>();

                AddneRGroupSelect.Add("Estatus del Proceso", DDLEstatus.SelectedValue.Trim());
                #endregion

                loopGroup(AddneRGroupSelect, "0");


                //Fecha de cierre depende del estado del evento
                if (TBFCierre.Text.Trim().Equals("") && DDLEstatus.SelectedValue.Equals("2")) throw new Exception($"El campo 'Fecha de Cierre' es obligatorio");

                //Justificación depende de si el evento se está creando o modificando
                string codigoEvsEIncs = TBHiddenCodigoEvsEIncs.Text.ToString().Trim();
                if (!codigoEvsEIncs.Equals("") && TBJustificacion.Text.Trim().Equals("")) throw new Exception($"El campo 'Justificación' es obligatorio");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void loopGroup(Dictionary<string, string> Grupo, string sValidate)
        {
            foreach (var campo in Grupo)
            {
                if (campo.Value.ToString().Equals(sValidate)) throw new Exception($"El campo '{campo.Key}' es obligatorio");
            }
        }

        private void loopGroupDecimal(Dictionary<string, string> Grupo, string regularValidate, string sTipoCampo)
        {
            Regex regex = new Regex(@regularValidate);
            Match match = null;

            foreach (var campo in Grupo)
            {
                match = regex.Match(campo.Value);
                if (!match.Success) throw new FormatException($"El campo '{campo.Key}' debe ser un {sTipoCampo}");
            }
        }

        private string ValOnSave()
        {
            if (!validarCriticidades())
                return "No se pudo evaluar criticidades de límite específico. Revise la información ingresada";
            if (TBTituloEvento.Text.Length > 100)
                return "El título del evento sólo puede contener 100 caracteres";
            if (!TBIdEvsEIncs.Text.ToString().Equals("") && TBJustificacion.Text.ToString().Equals(""))
                return "Debe agregar una justificación sobre el cambio realizado";
            if (DDLCategoria.SelectedValue.ToString().Equals("2") && (DDLCuentasPerdida.SelectedValue.ToString().Equals("") || TBFRegistroPerdida.Text.ToString().Equals("")))
                return "Los campos 'Cuentas Contables de Pérdida' y 'Fecha de Registro Contable de la Pérdida' son obligatorios cuando la categoría es 'Incidente'";
            if (!RelacionTabla("IdRiesgo") || !RelacionTabla("IdProcesoAfectado"))
                return "El evento debe tener relacionado un Riesgo y al menos un Proceso Afectado";

            return ValMsgDDLLineas();
        }

        private bool RelacionTabla(string IdTabla)
        {
            string Codigo = TBHiddenCodigoEvsEIncs.Text.Trim();
            if (!Codigo.Equals(""))
                return cEvsEIncs.ConsultarRelacionIdTabla(IdTabla, Codigo);

            return true;
        }
        #endregion Validations

        #region NotificacionModificacion
        private void Mensaje(String Mensaje)
        {
            lblMsgBox.Text = Mensaje;
            mpeMsgBox.Show();
        }
        private void mtdGenerarNotificacionModificacionEvento(string CodNHE, string ResponsableUsuario, string Area, int IdEvento, int IdMailEvento, string Justificacion)
        {
            try
            {
                string TextoAdicional = string.Empty;

                TextoAdicional = "MODIFICACION DE EVENTO" + "<br>";
                TextoAdicional = TextoAdicional + "<br>";
                TextoAdicional = TextoAdicional + " Código del Evento: " + CodNHE + "<br>";
                TextoAdicional = TextoAdicional + " Fecha de Modificacion : " + System.DateTime.Now.ToString() + "<br>";
                TextoAdicional = TextoAdicional + " Usuario de Registro : " + Session["loginUsuario"].ToString() + "<br>";
                TextoAdicional = TextoAdicional + " Nombre Usuario Registro : " + Session["nombreUsuario"].ToString() + "<br>";
                TextoAdicional = TextoAdicional + " Justificacion Modificacion : " + Justificacion + "<br>";

                boolEnviarNotificacion(37, IdEvento, Convert.ToInt16(Session["IdJerarquia"]), System.DateTime.Now.ToString().Trim(), TextoAdicional);
            }
            catch (Exception ex)
            {
                Mensaje("Error al generar la notificacion. " + ex.Message);
            }
        }

        private void mtdGenerarNotificacionCreaccionEvento(string CodNHE, string ResponsableUsuario, string Area, int IdEvento, int IdMailEvento)
        {
            try
            {
                string TextoAdicional = string.Empty;

                TextoAdicional = "CREACCION DE EVENTO" + "<br>";
                TextoAdicional = TextoAdicional + "<br>";
                TextoAdicional = TextoAdicional + " Código del Evento: " + CodNHE + "<br>";
                TextoAdicional = TextoAdicional + " Fecha de Creacción : " + System.DateTime.Now.ToString() + "<br>";
                TextoAdicional = TextoAdicional + " Usuario de Registro : " + Session["loginUsuario"].ToString() + "<br>";
                TextoAdicional = TextoAdicional + " Nombre Usuario Registro : " + Session["nombreUsuario"].ToString() + "<br>";

                boolEnviarNotificacion(17, IdEvento, Convert.ToInt16(Session["IdJerarquia"]), System.DateTime.Now.ToString().Trim(), TextoAdicional);
            }
            catch (Exception ex)
            {
                Mensaje("Error al generar la notificacion. " + ex.Message);
            }
        }

        private Boolean boolEnviarNotificacion(int idEvento, int idRegistro, int idNodoJerarquia, string FechaFinal, string textoAdicional)
        {
            #region Variables
            bool err = false;
            string Destinatario = string.Empty, Copia = string.Empty, Asunto = string.Empty, Otros = string.Empty, Cuerpo = string.Empty, NroDiasRecordatorio = string.Empty;
            string selectCommand = string.Empty, AJefeInmediato = string.Empty, AJefeMediato = string.Empty, RequiereFechaCierre = string.Empty;
            string idJefeInmediato = string.Empty, idJefeMediato = string.Empty;
            string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            #endregion Variables

            try
            {
                #region informacion basica
                SqlDataAdapter dad = null;
                DataTable dtblDiscuss = new DataTable();
                DataView view = null;

                if (!string.IsNullOrEmpty(idEvento.ToString().Trim()))
                {
                    //Consulta la informacion basica necesario para enviar el correo de la tabla correos destinatarios
                    selectCommand = "SELECT CD.Copia, CD.Otros, CD.Asunto, CD.Cuerpo, CD.NroDiasRecordatorio, CD.AJefeInmediato, CD.AJefeMediato, E.RequiereFechaCierre " +
                        "FROM [Notificaciones].[CorreosDestinatarios] AS CD INNER JOIN [Notificaciones].[Evento] AS E ON CD.IdEvento = E.IdEvento " +
                        "WHERE E. IdEvento = " + idEvento;

                    dad = new SqlDataAdapter(selectCommand, conString);
                    dad.Fill(dtblDiscuss);
                    view = new DataView(dtblDiscuss);

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
                }
                #endregion

                #region correo del Destinatario
                //Consulta el correo del Destinatario segun el nodo de la Jerarquia Organizacional
                if (!string.IsNullOrEmpty(idNodoJerarquia.ToString().Trim()))
                {
                    selectCommand = "SELECT DJ.CorreoResponsable, JO.idPadre " +
                        "FROM [Parametrizacion].[JerarquiaOrganizacional] AS JO INNER JOIN [Parametrizacion].[DetalleJerarquiaOrg] AS DJ ON DJ.idHijo = JO.idHijo " +
                        "WHERE JO.idHijo = " + idNodoJerarquia;

                    dad = new SqlDataAdapter(selectCommand, conString);
                    dtblDiscuss.Clear();
                    dad.Fill(dtblDiscuss);
                    view = new DataView(dtblDiscuss);

                    foreach (DataRowView row in view)
                    {
                        Destinatario = row["CorreoResponsable"].ToString().Trim();
                        idJefeInmediato = row["idPadre"].ToString().Trim();
                    }
                }
                #endregion

                #region correo del Jefe Inmediato
                //Consulta el correo del Jefe Inmediato
                if (AJefeInmediato == "SI")
                {
                    if (!string.IsNullOrEmpty(idJefeInmediato.Trim()))
                    {
                        selectCommand = "SELECT DJ.CorreoResponsable, JO.idPadre " +
                            "FROM [Parametrizacion].[JerarquiaOrganizacional] AS JO INNER JOIN [Parametrizacion].[DetalleJerarquiaOrg] AS DJ ON DJ.idHijo = JO.idHijo " +
                            "WHERE JO.idHijo = " + idJefeInmediato;

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
                }
                #endregion

                #region correo del Jefe Mediato
                //Consulta el correo del Jefe Mediato
                if (AJefeMediato == "SI")
                {
                    if (!string.IsNullOrEmpty(idJefeMediato.Trim()))
                    {
                        selectCommand = "SELECT DJ.CorreoResponsable, JO.idPadre " +
                            "FROM [Parametrizacion].[JerarquiaOrganizacional] AS JO INNER JOIN [Parametrizacion].[DetalleJerarquiaOrg] AS DJ ON DJ.idHijo = JO.idHijo " +
                            "WHERE JO.idHijo = " + idJefeMediato;

                        dad = new SqlDataAdapter(selectCommand, conString);
                        dtblDiscuss.Clear();
                        dad.Fill(dtblDiscuss);
                        view = new DataView(dtblDiscuss);

                        foreach (DataRowView row in view)
                        {
                            Destinatario = Destinatario + ";" + row["CorreoResponsable"].ToString().Trim();
                        }
                    }
                }
                #endregion

                #region Correos Enviados
                //Insertar el Registro en la tabla de Correos Enviados
                SqlDataSource200.InsertParameters["Destinatario"].DefaultValue = Destinatario.Trim();
                SqlDataSource200.InsertParameters["Copia"].DefaultValue = Copia;
                SqlDataSource200.InsertParameters["Otros"].DefaultValue = Otros;
                SqlDataSource200.InsertParameters["Asunto"].DefaultValue = Asunto;
                SqlDataSource200.InsertParameters["Cuerpo"].DefaultValue = Cuerpo;
                SqlDataSource200.InsertParameters["Estado"].DefaultValue = "POR ENVIAR";
                SqlDataSource200.InsertParameters["Tipo"].DefaultValue = "CREACION";
                SqlDataSource200.InsertParameters["FechaEnvio"].DefaultValue = System.DateTime.Now.ToString().Trim();
                SqlDataSource200.InsertParameters["IdEvento"].DefaultValue = idEvento.ToString().Trim();
                SqlDataSource200.InsertParameters["IdRegistro"].DefaultValue = idRegistro.ToString().Trim();
                SqlDataSource200.InsertParameters["IdUsuario"].DefaultValue = Session["idUsuario"].ToString().Trim(); //Aca va el id del Usuario de la BD
                SqlDataSource200.InsertParameters["FechaRegistro"].DefaultValue = System.DateTime.Now.ToString().Trim();
                SqlDataSource200.Insert();
                #endregion
            }
            catch (Exception except)
            {
                // Handle the Exception.
                omb.ShowMessage("Error en el envío de la notificación." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
                err = true;
            }

            if (!err)
            {
                #region Restro
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
                #endregion

                try
                {
                    #region Envio Correo
                    MailMessage message = new MailMessage();
                    SmtpClient smtpClient = new SmtpClient();
                    MailAddress fromAddress = new MailAddress(((System.Net.NetworkCredential)(smtpClient.Credentials)).UserName, "Software Sherlock");
                    message.From = fromAddress;//here you can set address

                    #region Destinatario
                    foreach (string substr in Destinatario.Split(';'))
                    {
                        if (!string.IsNullOrEmpty(substr.Trim()))
                        {
                            message.To.Add(substr);
                        }
                    }
                    #endregion

                    #region Copia
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

                    #region Otros
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
                    #endregion
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

        protected void SqlDataSource200_On_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            LastInsertIdCE = (int)e.Command.Parameters["@NewParameter2"].Value;
        }
        #endregion

    }
}