using ListasSarlaft.Classes;
using ListasSarlaft.Classes.DAL.Dashboard;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;

namespace ListasSarlaft.UserControls
{
    public partial class Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["Denegar"]) == 1)
                {
                    Mensaje("No tiene los permisos suficientes para llevar a cabo esta acción.");
                }
                bool booResult = false;
                string strErrMsg = string.Empty;
                //booResult = mtdLoadReportNLZ(ref strErrMsg);
                booResult = LoadInfoGraficoNumeroRos(ref strErrMsg);

                booResult = LoadInfoGraficoEstadosRoi(ref strErrMsg);
                booResult = LoadInfoGraficoRiesgosCadenaValor(ref strErrMsg);
                //--booResult = mtdLoadReporteRiesgos(ref strErrMsg);

                //--booResult = mtdLoadGraficoObjetivovsPerspectiva();
                LoadInfoReporteRiesgosPlanes(ref strErrMsg);
                LoadInfoReporteInhenrente(ref strErrMsg);
            }
        }

        private void Mensaje(String Mensaje)
        {
            lblMsgBox.Text = Mensaje;
            mpeMsgBox.Show();
        }
        public string mtdGetMoth(string numMonth)
        {
            string result = string.Empty;
            if (numMonth == "1")
                result = "Enero";
            if (numMonth == "2")
                result = "Febrero";
            if (numMonth == "3")
                result = "Marzo";
            if (numMonth == "4")
                result = "Abril";
            if (numMonth == "5")
                result = "Mayo";
            if (numMonth == "6")
                result = "Junio";
            if (numMonth == "7")
                result = "Julio";
            if (numMonth == "8")
                result = "Agosto";
            if (numMonth == "9")
                result = "Septiembre";
            if (numMonth == "10")
                result = "Octubre";
            if (numMonth == "11")
                result = "Noviembre";
            if (numMonth == "12")
                result = "Diciembre";
            return result;
        }

        public bool mtdLoadGraficoObjetivovsPerspectiva()
        {
            bool booResult = false;
            System.Data.DataTable dtInfo = new System.Data.DataTable();
            clsDALDashboard dbData = new clsDALDashboard();
            dtInfo = dbData.mtdGetGraficoObjetivovsPerspectiva();
            if (dtInfo.Rows.Count > 0)
            {
                System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();
                series.Name = "ObjetivovsPerspectiva";
                series.XValueMember = "Objetivo";
                series.YValueMembers = "Resultado";
                foreach (DataRow dr in dtInfo.Rows)
                {

                    //series.LabelBackColor = System.Drawing.Color.Green;
                    int iteracion = 0;
                    int y = Convert.ToInt32(dr[1].ToString());
                    string x = dr[0].ToString();
                    series.Points.AddXY(x, y);


                }
                //crtGestionObjetivosvsPerspectiva.Series.Add(series);
            }
            return booResult;
        }
        //public bool mtdLoadReportNLZ(ref string strErrMsg)
        //{
        //    bool booResult = false;
        //    //string strErrMgs = string.Empty;
        //    //string NombreRiesgoInherente = string.Empty;
        //    int valorBajo = 0;
        //    int valorModerado = 0;
        //    int valorAlto = 0;
        //    int valorExtremo = 0;
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    System.Data.DataTable dtPerfiles = new System.Data.DataTable();
        //    dt.Columns.Add("Data", Type.GetType("System.String"));
        //    dt.Columns.Add("Bajo", Type.GetType("System.Int32"));
        //    dt.Columns.Add("Moderado", Type.GetType("System.Int32"));
        //    dt.Columns.Add("Alto", Type.GetType("System.Int32"));
        //    dt.Columns.Add("Extremo", Type.GetType("System.Int32"));
        //    dtPerfiles.Columns.Add("Data", Type.GetType("System.String"));
        //    dtPerfiles.Columns.Add("Value1", Type.GetType("System.String"));
        //    System.Data.DataTable dtCriticidad = new System.Data.DataTable();
        //    dtCriticidad.Columns.Add("Titulo", Type.GetType("System.String"));
        //    dtCriticidad.Columns.Add("Serie1", Type.GetType("System.String"));
        //    dtCriticidad.Columns.Add("Serie2", Type.GetType("System.String"));
        //    dtCriticidad.Columns.Add("Serie3", Type.GetType("System.String"));
        //    dtCriticidad.Columns.Add("Serie4", Type.GetType("System.String"));
        //    DataRow RowCriticidad = dtCriticidad.NewRow();
        //    RowCriticidad["Titulo"] = "Criticidad de Riesgos";
        //    RowCriticidad["Serie1"] = "Bajo";
        //    RowCriticidad["Serie2"] = "Moderado";
        //    RowCriticidad["Serie3"] = "Alto";
        //    RowCriticidad["Serie4"] = "Extremo";
        //    dtCriticidad.Rows.Add(RowCriticidad);
        //    //GVcriticidad.DataSource = dtCriticidad;
        //    //GVcriticidad.DataBind();
        //    //GVcriticidad.Visible = true;
        //    List<clsDTOCuadroMandoConsolidado> lstReporte = new List<clsDTOCuadroMandoConsolidado>();
        //    List<clsDTOCuadroMandoConsolidado> lstReporteNLK = new List<clsDTOCuadroMandoConsolidado>();
        //    List<clsDTOCuadroMandoConsolidado> lstReporteNLKPerilRI = new List<clsDTOCuadroMandoConsolidado>();
        //    List<clsDTOCuadroMandoConsolidado> lstReporteNLKPerilRR = new List<clsDTOCuadroMandoConsolidado>();
        //    clsBLLCuadroMandoConsolidado cCuadroConsolidado = new clsBLLCuadroMandoConsolidado();
        //    clsDTOCuadroMandoConsolidado cuadroMando = new clsDTOCuadroMandoConsolidado();
        //    clsDTOCuadroMandoConsolidadoFiltros objFiltros = new clsDTOCuadroMandoConsolidadoFiltros();
        //    /**********************Filtros de Consulta****************************/
        //    objFiltros.intRiesgoGlobal = 0;
        //    objFiltros.intIdCadenaValor = 0;
        //    objFiltros.intIdMacroProceso = 0;
        //    objFiltros.intIdProceso = 0;
        //    objFiltros.intIdSubProceso = 0;
        //    objFiltros.intArea = 0;
        //    /**********************Filtros  de Consulta****************************/

        //    System.Data.DataTable dtInfo = new System.Data.DataTable();
        //    clsDALDashboard dbData = new clsDALDashboard();
        //    dtInfo = dbData.LoadInfoReporteRiesgosvsObjetivos();
        //    //booResult = cCuadroConsolidado.mtdConsultarReporteNLKDashBoard(ref strErrMsg, ref lstReporteNLK, objFiltros);
        //    //if (booResult == true)
        //    //{
        //    int total = valorBajo + valorModerado + valorAlto + valorExtremo;
        //    Session["Total Inherente"] = total;

        //    foreach (DataRow dr in dtInfo.Rows)
        //        {
        //        //if (dr["RiesgoResidual"].ToString().Trim() == "Bajo")
        //        //{
        //        //    valorBajo++;
        //        //}
        //        //if (dr["RiesgoResidual"].ToString().Trim() == "Moderado")
        //        //{
        //        //    valorModerado++;
        //        //}
        //        //if (dr["RiesgoResidual"].ToString().Trim() == "Alto")
        //        //{
        //        //    valorAlto++;
        //        //}
        //        //if (dr["RiesgoResidual"].ToString().Trim() == "Extremo")
        //        //{
        //        //    valorExtremo++;
        //        //}
        //        DataRow dr2 = dt.NewRow();
        //        dr2["Data"] = dr["CodigoObjetivo"].ToString();
        //        dr2["Bajo"] = Convert.ToInt32(dr["Bajo"].ToString());
        //        dr2["Moderado"] = Convert.ToInt32(dr["Moderado"].ToString());
        //        dr2["Alto"] = Convert.ToInt32(dr["Alto"].ToString());
        //        dr2["Extremo"] = Convert.ToInt32(dr["Extremo"].ToString());

        //        dt.Rows.Add(dr2);
        //    }



        //    //}
        //    valorBajo = 0;
        //    valorModerado = 0;
        //    valorAlto = 0;
        //    valorExtremo = 0;
        //    /*booResult = cCuadroConsolidado.mtdConsultarReporteXYZ(ref strErrMsg, ref lstReporte, objFiltros);
        //    System.Data.DataTable dtCuadroMandoNLK = new System.Data.DataTable();
        //    System.Data.DataTable dtCuadroMando = new System.Data.DataTable();
        //    if (booResult == true)
        //    {
        //        foreach (clsDTOCuadroMandoConsolidado objCuadro in lstReporte)
        //        {
        //            if (objCuadro.strNombreRiesgo == "Bajo")
        //            {
        //                valorBajo = valorBajo + objCuadro.intNumeroRegistros;
        //            }
        //            if (objCuadro.strNombreRiesgo == "Moderado")
        //            {
        //                valorModerado = valorModerado + objCuadro.intNumeroRegistros;
        //            }
        //            if (objCuadro.strNombreRiesgo == "Alto")
        //            {
        //                valorAlto = valorAlto + objCuadro.intNumeroRegistros;
        //            }
        //            if (objCuadro.strNombreRiesgo == "Extremo")
        //            {
        //                valorExtremo = valorExtremo + objCuadro.intNumeroRegistros;
        //            }
        //        }
        //        int total = valorBajo + valorModerado + valorAlto + valorExtremo;
        //        Session["Total Residual"] = total;
        //        DataRow dr1 = dt.NewRow();
        //        dr1["Data"] = "Riesgo Residual";
        //        dr1["Value1"] = valorBajo;
        //        dr1["Value2"] = valorModerado;
        //        dr1["Value3"] = valorAlto;
        //        dr1["Value4"] = valorExtremo;
        //        dt.Rows.Add(dr1);

        //    }*/

        //    /*booResult = cCuadroConsolidado.mtdConsultarReporteNLKPerfilRI(ref strErrMgs, ref lstReporteNLKPerilRI);
        //    if(booResult == true)
        //    {
        //        DataRow dr1 = dtPerfiles.NewRow();
        //        foreach (clsDTOCuadroMandoConsolidado objCuadro in lstReporteNLKPerilRI)
        //        {

        //            dr1["Data"] = "Perfil Riesgo Inherente";
        //            dr1["Value1"] = objCuadro.intNumeroRegistros;
        //        }
        //        dtPerfiles.Rows.Add(dr1);
        //    }
        //    booResult = cCuadroConsolidado.mtdConsultarReporteNLKPerfilRR(ref strErrMgs, ref lstReporteNLKPerilRR);
        //    if (booResult == true)
        //    {
        //        DataRow dr2 = dtPerfiles.NewRow();
        //        foreach (clsDTOCuadroMandoConsolidado objCuadro in lstReporteNLKPerilRR)
        //        {

        //            dr2["Data"] = "Perfil Riesgo Residual";
        //            dr2["Value1"] = objCuadro.intNumeroRegistros;
        //        }
        //        dtPerfiles.Rows.Add(dr2);
        //    }*/
        //    //mtdViewChartsReporteNLK(ds);
        //    LoadChartData(dt);
        //    //LoadChartDataPerfiles();
        //    return booResult;
        //}
        //private void LoadChartData(System.Data.DataTable initialDataSource)
        //{

        //    for (int i = 1; i < initialDataSource.Columns.Count; i++)
        //    {
        //        System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();
        //        series.ChartType = SeriesChartType.StackedColumn;

        //        foreach (DataRow dr in initialDataSource.Rows)
        //        {
        //            //series.Legend = dr[0].ToString();
        //            int y = (int)dr[i];
        //            series.Points.AddXY(dr["Data"].ToString(), y);

        //            if (i == 1)
        //            {
        //                series.Color = System.Drawing.Color.Green;
        //                series.BackGradientStyle = GradientStyle.TopBottom;
        //                series.BackSecondaryColor = System.Drawing.Color.Green;
        //                series.LegendText = "Bajo";
        //            }
        //            if (i == 2)
        //            {
        //                series.Color = System.Drawing.Color.Yellow;
        //                series.BackGradientStyle = GradientStyle.TopBottom;
        //                series.LegendText = "Moderado";
        //            }
        //            if (i == 3)
        //            {
        //                series.Color = System.Drawing.Color.Orange;
        //                series.BackGradientStyle = GradientStyle.TopBottom;
        //                series.BackSecondaryColor = System.Drawing.Color.Orange;
        //                series.LegendText = "Alto";
        //            }
        //            if (i == 4)
        //            {
        //                series.Color = System.Drawing.Color.Red;
        //                series.BackGradientStyle = GradientStyle.TopBottom;
        //                series.BackSecondaryColor = System.Drawing.Color.Red;
        //                series.LegendText = "Extremo";
        //            }
        //            /*Chart1.Series["Series1"].Points[Iteracion].Color = System.Drawing.Color.Green;
        //            Chart1.Series["Series1"].Points[Iteracion].BackGradientStyle = GradientStyle.TopBottom;
        //            Chart1.Series["Series1"].Points[Iteracion].BackSecondaryColor = System.Drawing.Color.DarkGreen;
        //            Chart1.Series["Series1"].Points[Iteracion].Label = dr["Valor"].ToString() + "%";
        //            Chart1.Series["Series1"].Points[Iteracion].LabelToolTip = dr["Valor"].ToString() + "%";*/
        //        }
        //        /**/
        //        //Chart3.Legends[0].Enabled = true;
        //        //Chart3.Titles[0].Text = "Riesgos por objetivo estratégico";
        //        Chart3.Series.Add(series);
        //        // Create a new legend called "Legend2".
        //        //Chart3.Legends.Add(new System.Web.UI.DataVisualization.Charting.Legend("Criticidad"));

        //        // Set Docking of the Legend chart to the Default Chart Area.
        //        //Chart3.Legends["Legend2"].DockedToChartArea = "Default";

        //        // Assign the legend to Series1.
        //        //Chart3.Series["Series1"].Legend = "Criticidad";
        //        Chart3.Series["Series1"].IsVisibleInLegend = true;
        //        Chart3.ChartAreas["ChartArea1"].AxisY.ScaleBreakStyle.Enabled = false;
        //        Chart3.ChartAreas["ChartArea1"].AxisY.Interval = 1;
        //    }

        //    //foreach (System.Web.UI.DataVisualization.Charting.Series charts in Chart3.Series)
        //    //{
        //    //    int iteracion = 0;
        //    //    foreach (DataPoint point in charts.Points)
        //    //    {
        //    //        if (iteracion == 0)
        //    //            point.Label = string.Format("{0}%", Math.Round((point.YValues[0] / Convert.ToInt32(Session["Total Inherente"].ToString())) * 100, 2));
        //    //        else
        //    //            point.Label = string.Format("{0}%", Math.Round((point.YValues[0] / Convert.ToInt32(Session["Total Residual"].ToString())) * 100, 2));
        //    //        iteracion++;
        //    //    }

        //    //}

        //}
        private void LoadChartDataPerfiles()
        {
            System.Data.DataTable initialDataSource = new System.Data.DataTable();
            initialDataSource.Columns.Add("Data", Type.GetType("System.String"));
            initialDataSource.Columns.Add("Value1", Type.GetType("System.String"));
            DataRow dr1 = initialDataSource.NewRow();
            dr1["Data"] = "Perfil Riesgo Inherente";
            dr1["Value1"] = 100;
            initialDataSource.Rows.Add(dr1);
            DataRow d2 = initialDataSource.NewRow();
            d2["Data"] = "Perfil Riesgo Residual";
            d2["Value1"] = 100;
            initialDataSource.Rows.Add(d2);
            for (int i = 1; i < initialDataSource.Columns.Count; i++)
            {
                System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();
                foreach (DataRow dr in initialDataSource.Rows)
                {
                    //series.Legend = dr[0].ToString();
                    int y = Convert.ToInt32(dr[i].ToString());
                    series.Points.AddXY(dr[0].ToString(), y);
                    series.Color = System.Drawing.Color.Blue;
                    series.BackGradientStyle = GradientStyle.TopBottom;
                    series.BackSecondaryColor = System.Drawing.Color.DarkBlue;

                }
                //Chart4.Legends[0].Enabled = true;
                //Chart4.Series.Add(series);
            }
        }
        private bool mtdLoadReporteRiesgos(ref string strErrMsg)
        {

            bool booResult = false;
            //string strErrMgs = string.Empty;
            //string NombreRiesgoInherente = string.Empty;

            List<clsDTOCuadroMandoConsolidado> lstReporte = new List<clsDTOCuadroMandoConsolidado>();
            clsBLLCuadroMandoRiesgos cCuadroRiesgos = new clsBLLCuadroMandoRiesgos();
            clsDTOCuadroMandoConsolidado cuadroMando = new clsDTOCuadroMandoConsolidado();
            clsDTOCuadroMandoConsolidadoFiltros objFiltros = new clsDTOCuadroMandoConsolidadoFiltros();
            /**********************Filtros de Consulta****************************/
            try
            {
                objFiltros.intRiesgoGlobal = 0;
                objFiltros.intIdCadenaValor = 0;
                objFiltros.intIdMacroProceso = 0;
                objFiltros.intIdProceso = 0;
                objFiltros.intIdSubProceso = 0;
                objFiltros.strAreaRiesgo = string.Empty;
                objFiltros.intArea = 0;
                objFiltros.intIdClasificacionGeneral = 0;
                objFiltros.intIdFactor = 0;
                objFiltros.intIdObjetivo = 0;

            }
            catch (Exception ex)
            {
                strErrMsg = "Error en los filtros: " + ex;
                Mensaje(strErrMsg);
            }
            //omb.ShowMessage("Riesgo: " + ddlRiesgoGlobal.SelectedValue, 2, "Atención");
            /**********************Filtros  de Consulta****************************/

            Session["Grafico"] = "General";
            System.Data.DataTable dtInfo = new System.Data.DataTable();
            cRiesgo cRiesgo = new cRiesgo();
            try
            {
                dtInfo = cRiesgo.loadDDLClasificacion();
            }
            catch (Exception ex)
            {
                strErrMsg = "Error en la consulta de calificación riesgo";
                //omb.ShowMessage(strErrMsg, 2, "Atención");
                Mensaje(strErrMsg);
            }
            try
            {
                System.Data.DataTable initialDataSource = new System.Data.DataTable();
                initialDataSource.Columns.Add("Riesgo", Type.GetType("System.String"));
                initialDataSource.Columns.Add("Bajo", Type.GetType("System.String"));
                initialDataSource.Columns.Add("Moderado", Type.GetType("System.String"));
                initialDataSource.Columns.Add("Alto", Type.GetType("System.String"));
                initialDataSource.Columns.Add("Extremo", Type.GetType("System.String"));
                //omb.ShowMessage("Cant loadDDLClasificacion: " + dtInfo.Rows.Count.ToString(), 3, "2");
                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    lstReporte = new List<clsDTOCuadroMandoConsolidado>();
                    objFiltros.intRiesgoGlobal = Convert.ToInt32(dtInfo.Rows[i]["IdClasificacionRiesgo"].ToString());
                    //omb.ShowMessage("Riesgo: "+ dtInfo.Rows[i]["IdClasificacionRiesgo"].ToString(), 3, "Exito");
                    booResult = cCuadroRiesgos.mtdConsultarReporteRiesgos(ref strErrMsg, ref lstReporte, objFiltros);
                    if (lstReporte != null)
                    {
                        int valorBajo = 0;
                        int valorModerado = 0;
                        int valorAlto = 0;
                        int valorExtremo = 0;
                        foreach (clsDTOCuadroMandoConsolidado objCuadro in lstReporte)
                        {
                            if (objCuadro.strNombreRiesgo == "Bajo")
                            {
                                valorBajo = valorBajo + objCuadro.intNumeroRegistros;
                            }
                            if (objCuadro.strNombreRiesgo == "Moderado")
                            {
                                valorModerado = valorModerado + objCuadro.intNumeroRegistros;
                            }
                            if (objCuadro.strNombreRiesgo == "Alto")
                            {
                                valorAlto = valorAlto + objCuadro.intNumeroRegistros;
                            }
                            if (objCuadro.strNombreRiesgo == "Extremo")
                            {
                                valorExtremo = valorExtremo + objCuadro.intNumeroRegistros;
                            }
                        }
                        DataRow dr1 = initialDataSource.NewRow();
                        dr1["Riesgo"] = dtInfo.Rows[i]["NombreClasificacionRiesgo"].ToString();
                        dr1["Bajo"] = valorBajo;
                        dr1["Moderado"] = valorModerado;
                        dr1["Alto"] = valorAlto;
                        dr1["Extremo"] = valorExtremo;
                        initialDataSource.Rows.Add(dr1);

                    }
                    //omb.ShowMessage(strErrMgs, 1, "Consulta");
                }
                booResult = true;
                LoadChartGeneral(initialDataSource);
            }
            catch (Exception ex)
            {

                // omb.ShowMessage("Error en la generación de reporte: " + ex, 2, "Atención");
                Mensaje("Error en la generación de reporte: " + ex);
            }
            //if (ddlRiesgoGlobal.SelectedValue == "---")
            //{
            //}
            //else
            //{
            //    //omb.ShowMessage("En el Else", 3, "3");
            //    Session["Grafico"] = "Particular";
            //    string strQuery = string.Empty;
            //    booResult = cCuadroRiesgos.mtdConsultarReporteRiesgosSaro(ref strErrMsg, ref lstReporte, objFiltros, ref strQuery);
            //    //omb.ShowMessage(strQuery, 3, "6");
            //    if (lstReporte != null)
            //    {
            //        int valorBajo = 0;
            //        int valorModerado = 0;
            //        int valorAlto = 0;
            //        int valorExtremo = 0;
            //        foreach (clsDTOCuadroMandoConsolidado objCuadro in lstReporte)
            //        {
            //            if (objCuadro.strNombreRiesgo == "Bajo")
            //            {
            //                valorBajo = valorBajo + objCuadro.intNumeroRegistros;
            //            }
            //            if (objCuadro.strNombreRiesgo == "Moderado")
            //            {
            //                valorModerado = valorModerado + objCuadro.intNumeroRegistros;
            //            }
            //            if (objCuadro.strNombreRiesgo == "Alto")
            //            {
            //                valorAlto = valorAlto + objCuadro.intNumeroRegistros;
            //            }
            //            if (objCuadro.strNombreRiesgo == "Extremo")
            //            {
            //                valorExtremo = valorExtremo + objCuadro.intNumeroRegistros;
            //            }
            //        }
            //        System.Data.DataTable dtCuadroMando = new System.Data.DataTable();
            //        DataColumn dcColumn;

            //        dcColumn = new DataColumn();
            //        dcColumn.ColumnName = "Riesgo Inherente";
            //        dtCuadroMando.Columns.Add(dcColumn);
            //        dcColumn = new DataColumn();
            //        dcColumn.ColumnName = "Valor";
            //        dtCuadroMando.Columns.Add(dcColumn);

            //        DataRow dr;
            //        dr = dtCuadroMando.NewRow();
            //        dr["Riesgo Inherente"] = "Bajo";
            //        dr["Valor"] = valorBajo;
            //        dtCuadroMando.Rows.Add(dr);
            //        dr = dtCuadroMando.NewRow();
            //        dr["Riesgo Inherente"] = "Moderado";
            //        dr["Valor"] = valorModerado;
            //        dtCuadroMando.Rows.Add(dr);
            //        dr = dtCuadroMando.NewRow();
            //        dr["Riesgo Inherente"] = "Alto";
            //        dr["Valor"] = valorAlto;
            //        dtCuadroMando.Rows.Add(dr);
            //        dr = dtCuadroMando.NewRow();
            //        dr["Riesgo Inherente"] = "Extremo";
            //        dr["Valor"] = valorExtremo;
            //        dtCuadroMando.Rows.Add(dr);

            //        //mtdViewChartSaro(dtCuadroMando);
            //        //omb.ShowMessage("Entro mtdConsultarReporteRiesgosSaro Si", 3, "Exito");
            //        booResult = true;
            //    }
            //}

            return booResult;
        }
        private void LoadChartGeneral(System.Data.DataTable initialDataSource)
        {

            //GVriesgoGlobal.DataSource = initialDataSource;
            //GVriesgoGlobal.DataBind();
            int Identity = 1;
            //System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();
            //omb.ShowMessage("Rows: "+ initialDataSource.Rows.Count, 3, "4");
            foreach (DataRow dr in initialDataSource.Rows)
            {

                System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();
                series.Name = dr[0].ToString();
                series.XValueMember = "Riesgo Inherente";
                series.YValueMembers = "Cantidad";
                series.LabelBackColor = System.Drawing.Color.Green;
                int iteracion = 0;
                for (int i = 1; i < initialDataSource.Columns.Count; i++)
                {

                    //series.Legend = dr[0].ToString();
                    int y = Convert.ToInt32(dr[i].ToString());
                    //series.Points.AddXY(dr[0].ToString(), y);
                    //series.Points.AddY(y);
                    if (i == 1)
                    {
                        series.Points.AddXY("Bajo", y);

                    }
                    if (i == 2)
                    {
                        series.Points.AddXY("Moderado", y);

                    }
                    if (i == 3)
                    {
                        series.Points.AddXY("Alto", y);

                    }
                    if (i == 4)
                    {
                        series.Points.AddXY("Extremo", y);

                    }
                }
                //Chart4.Legends[0].Enabled = true;
                //ChartGeneral.Series.Add(series);
            }
            //Chart4.Legends[0].Enabled = true;

        }
        private bool LoadInfoGraficoNumeroRos(ref string strErrMgs)
        {
            bool booResult = false;
            System.Data.DataTable dtInfo = new System.Data.DataTable();
            clsDALDashboard dbData = new clsDALDashboard();
            dtInfo = dbData.LoadInfoReporteNumerosRos();
            mtdViewChartNumeroRos(dtInfo);
            return booResult;
        }
        public void mtdViewChartNumeroRos(System.Data.DataTable dtInfo)
        {
            //GVriesgosSaro.DataSource = dtInfo;
            //GVriesgosSaro.DataBind();
            string[] x = new string[dtInfo.Rows.Count];
            int[] y = new int[dtInfo.Rows.Count];
            int Total = 0;
            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                x[i] = mtdGetMoth(dtInfo.Rows[i][0].ToString());
                y[i] = Convert.ToInt32(dtInfo.Rows[i][2]);
                //Total = Total + Convert.ToInt32(dtInfo.Rows[i][1]);
            }
            ChartNumeroRos.Series[0].Points.DataBindXY(x, y);
            ChartNumeroRos.Series[0].ChartType = SeriesChartType.StackedBar;
            ChartNumeroRos.ChartAreas["ChartNumeroRosArea"].Area3DStyle.Enable3D = false;
            //ChartNumeroRos.Legends[0].Enabled = true;
            ChartNumeroRos.Titles.Add("NewTitle");
            ChartNumeroRos.Titles[1].Text = "NÚMERO DE ROS " + DateTime.Now.Year.ToString();

        }
        private bool LoadInfoGraficoEstadosRoi(ref string strErrMgs)
        {
            bool booResult = false;
            System.Data.DataTable dtInfo = new System.Data.DataTable();
            clsDALDashboard dbData = new clsDALDashboard();
            dtInfo = dbData.LoadInfoReporteEstadosRoi();
            mtdViewChartEstadosRoi(dtInfo);
            return booResult;
        }
        public void mtdViewChartEstadosRoi(System.Data.DataTable dtInfo)
        {
            //GVriesgosSaro.DataSource = dtInfo;
            //GVriesgosSaro.DataBind();
            string[] x = new string[dtInfo.Rows.Count];
            int[] y = new int[dtInfo.Rows.Count];
            int Total = 0;
            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                x[i] = dtInfo.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dtInfo.Rows[i][1]);
                Total = Total + Convert.ToInt32(dtInfo.Rows[i][1]);
            }
            Session["TotalEstadosRoi"] = Total;
            ChartEstadoRoi.Series[0].Points.DataBindXY(x, y);
            ChartEstadoRoi.Series[0].ChartType = SeriesChartType.Doughnut;
            ChartEstadoRoi.ChartAreas["ChartEstadoRoiArea"].Area3DStyle.Enable3D = false;
            //ChartNumeroRos.Legends[0].Enabled = true;
            ChartEstadoRoi.Titles.Add("NewTitle");
            ChartEstadoRoi.Titles[1].Text = "ESTADOS DE LOS ROI";
            ChartEstadoRoi.Series[0]["PieLabelStyle"] = "Disabled";
            foreach (System.Web.UI.DataVisualization.Charting.Series charts in ChartEstadoRoi.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    //switch (point.AxisLabel)
                    //{
                    //    case "Bajo": point.Color = System.Drawing.Color.Green; break;
                    //    case "Moderado": point.Color = System.Drawing.Color.Yellow; break;
                    //    case "Alto": point.Color = System.Drawing.Color.Orange; break;
                    //    case "Extremo": point.Color = System.Drawing.Color.Red; break;
                    //}
                    point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);

                }
            }
        }
        private bool LoadInfoGraficoRiesgosCadenaValor(ref string strErrMgs)
        {
            bool booResult = false;
            System.Data.DataTable dtInfo = new System.Data.DataTable();
            clsDALDashboard dbData = new clsDALDashboard();
            dtInfo = dbData.LoadInfoRiesgosCadenaValor();
            //System.Data.DataTable dtInfoComp = new System.Data.DataTable();
            //define the columns
            //dtInfoComp.Columns.Add(new DataColumn("CadenaValor", typeof(string)));
            //dtInfoComp.Columns.Add(new DataColumn("NombreRiesgo", typeof(string)));
            //dtInfoComp.Columns.Add(new DataColumn("Valor", typeof(string)));
            System.Data.DataTable initialDataSource = new System.Data.DataTable();
            initialDataSource.Columns.Add("CadenaValor", Type.GetType("System.String"));
            initialDataSource.Columns.Add("Bajo", Type.GetType("System.String"));
            initialDataSource.Columns.Add("Moderado", Type.GetType("System.String"));
            initialDataSource.Columns.Add("Alto", Type.GetType("System.String"));
            initialDataSource.Columns.Add("Extremo", Type.GetType("System.String"));
            DataRow drComp = null;
            clsBLLCuadroMandoRiesgos cProcess = new clsBLLCuadroMandoRiesgos();
            string strErrMsg = string.Empty;
            string CadenaValor = string.Empty;
            int Bajo = 0;
            int Moderado = 0;
            int Alto = 0;
            int Extremo = 0;
            if (dtInfo.Rows.Count > 0)
            {
                foreach (DataRow dr in dtInfo.Rows)
                {
                    string CV_actual = dbData.mtdGetNombreCadenaValor(Convert.ToInt32(dr["IdCadenaValor"].ToString()));
                    if (CadenaValor != CV_actual && CadenaValor != string.Empty)
                    {
                        //create new row
                        //drComp = dtInfoComp.NewRow();
                        drComp = initialDataSource.NewRow();
                        //add values to each rows
                        drComp["CadenaValor"] = CadenaValor;
                        drComp["Bajo"] = Bajo;
                        drComp["Moderado"] = Moderado;
                        drComp["Alto"] = Alto;
                        drComp["Extremo"] = Extremo;

                        initialDataSource.Rows.Add(drComp);
                        CadenaValor = CV_actual;
                        string riesgo = cProcess.LoadInfoDetalleRiesgo(ref strErrMsg, Convert.ToInt32(dr["IdProbabilidadResidual"].ToString().Trim()), Convert.ToInt32(dr["IdImpactoResidual"].ToString().Trim()));
                        Bajo = 0;
                        Moderado = 0;
                        Alto = 0;
                        Extremo = 0;
                        if (riesgo == "Bajo")
                            Bajo = Convert.ToInt32(dr["NumeroRegistros"].ToString());
                        if (riesgo == "Moderado")
                            Moderado = Convert.ToInt32(dr["NumeroRegistros"].ToString());
                        if (riesgo == "Alto")
                            Alto = Convert.ToInt32(dr["NumeroRegistros"].ToString());
                        if (riesgo == "Extremo")
                            Extremo = Convert.ToInt32(dr["NumeroRegistros"].ToString());
                    }
                    else
                    {
                        CadenaValor = dbData.mtdGetNombreCadenaValor(Convert.ToInt32(dr["IdCadenaValor"].ToString()));
                        string riesgo = cProcess.LoadInfoDetalleRiesgo(ref strErrMsg, Convert.ToInt32(dr["IdProbabilidadResidual"].ToString().Trim()), Convert.ToInt32(dr["IdImpactoResidual"].ToString().Trim()));
                        if (riesgo == "Bajo")
                            Bajo = Bajo + Convert.ToInt32(dr["NumeroRegistros"].ToString());
                        if (riesgo == "Moderado")
                            Moderado = Moderado + Convert.ToInt32(dr["NumeroRegistros"].ToString());
                        if (riesgo == "Alto")
                            Alto = Alto + Convert.ToInt32(dr["NumeroRegistros"].ToString());
                        if (riesgo == "Extremo")
                            Extremo = Extremo + Convert.ToInt32(dr["NumeroRegistros"].ToString());
                    }

                    //add values to each rows
                    //drComp["CadenaValor"] = dbData.mtdGetNombreCadenaValor(Convert.ToInt32(dr["IdCadenaValor"].ToString()));
                    //drComp["NombreRiesgo"] = cProcess.LoadInfoDetalleRiesgo(ref strErrMsg, Convert.ToInt32(dr["IdProbabilidadResidual"].ToString().Trim()), Convert.ToInt32(dr["IdImpactoResidual"].ToString().Trim()));
                    //drComp["Valor"] = Convert.ToInt32(dr["NumeroRegistros"].ToString());

                    //add the row to DataTable
                    //dtInfoComp.Rows.Add(drComp);

                    //objPreporte.intNumeroRegistros = Convert.ToInt32(dr["NumeroRegistros"].ToString().Trim());
                    //objPreporte.intIdProbabilidadResidual = Convert.ToInt32(dr["IdProbabilidadResidual"].ToString().Trim());
                    //objPreporte.intIdImpactoResidual = Convert.ToInt32(dr["IdImpactoResidual"].ToString().Trim());
                    //if (objFiltros.dtFechaHistoricoInicial != default(DateTime))
                    //    objPreporte.strNombreRiesgo = LoadInfoDetalleRiesgoHistorico(ref strErrMsg, Convert.ToInt32(dr["IdProbabilidadResidual"].ToString().Trim()), Convert.ToInt32(dr["IdImpactoResidual"].ToString().Trim()));
                    //else
                    //    objPreporte.strNombreRiesgo = LoadInfoDetalleRiesgo(ref strErrMsg, Convert.ToInt32(dr["IdProbabilidadResidual"].ToString().Trim()), Convert.ToInt32(dr["IdImpactoResidual"].ToString().Trim()));
                    //lstInfo.Add(objPreporte);
                }
                //create new row
                //drComp = dtInfoComp.NewRow();
                drComp = initialDataSource.NewRow();
                //add values to each rows
                drComp["CadenaValor"] = CadenaValor;
                drComp["Bajo"] = Bajo;
                drComp["Moderado"] = Moderado;
                drComp["Alto"] = Alto;
                drComp["Extremo"] = Extremo;

                initialDataSource.Rows.Add(drComp);
                booResult = true;
            }
            mtdViewChartRiesgosCadenaValor(initialDataSource);
            return booResult;
        }
        public void mtdViewChartRiesgosCadenaValor(System.Data.DataTable dtInfo)
        {
            //GVriesgosSaro.DataSource = dtInfo;
            //GVriesgosSaro.DataBind();
            //string[] x = new string[dtInfo.Rows.Count];
            //int[] y = new int[dtInfo.Rows.Count];
            //for (int i = 0; i < dtInfo.Rows.Count; i++)
            //{
            //    x[i] = dtInfo.Rows[i][0].ToString();
            //    y[i] = Convert.ToInt32(dtInfo.Rows[i][1]);
            //    //Total = Total + Convert.ToInt32(dtInfo.Rows[i][1]);
            //}

            int iteracion = 0;
            foreach (DataRow dr in dtInfo.Rows)
            {
                System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();
                series.Name = dr[0].ToString();
                series.XValueMember = "Riesgo Inherente";
                series.YValueMembers = "Cantidad";
                series.LabelBackColor = System.Drawing.Color.Green;
                //int iteracion = 0;
                //for (int i = 2; i < dtInfo.Columns.Count; i++)
                for (int i = 1; i < dtInfo.Columns.Count; i++)
                {

                    //series.Legend = dr[0].ToString();
                    int y = Convert.ToInt32(dr[i].ToString());
                    //series.Points.AddXY(dr[1].ToString(), y);
                    if (i == 1)
                    {
                        series.Points.AddXY("Bajo", y);

                    }
                    if (i == 2)
                    {
                        series.Points.AddXY("Moderado", y);

                    }
                    if (i == 3)
                    {
                        series.Points.AddXY("Alto", y);

                    }
                    if (i == 4)
                    {
                        series.Points.AddXY("Extremo", y);

                    }
                }

                //Chart4.Legends[0].Enabled = true;
                iteracion++;
                ChartRiesgoCadenaValor.Series.Add(series);
                ChartRiesgoCadenaValor.ChartAreas["ChartAreaRiesgoCadenaValor"].AxisY.Interval = 10;
            }

        }
        private bool LoadInfoReporteRiesgosPlanes(ref string strErrMgs)
        {
            bool booResult = false;
            //string strErrMgs = string.Empty;
            //string NombreRiesgoInherente = string.Empty;
            int valorBajo = 0;
            int valorModerado = 0;
            int valorAlto = 0;
            int valorExtremo = 0;
            List<clsDTOCuadroMandoRiesgosDetalle> lstReporte = new List<clsDTOCuadroMandoRiesgosDetalle>();
            clsBLLCuadroMandoRiesgosDetalle cCuadroRiesgos = new clsBLLCuadroMandoRiesgosDetalle();
            //clsDTOCuadroMandoConsolidado cuadroMando = new clsDTOCuadroMandoConsolidado();
            clsDTOCuadroMandoConsolidadoFiltros objFiltros = new clsDTOCuadroMandoConsolidadoFiltros();
            /**********************Filtros de Consulta****************************/
            objFiltros.intRiesgoGlobal = 0;
            objFiltros.intIdCadenaValor = 0;
            objFiltros.intIdMacroProceso = 0;
            objFiltros.intIdProceso = 0;
            objFiltros.intIdSubProceso = 0;
            //objFiltros.intArea = Convert.ToInt32(ddlAreas.SelectedValue);
            objFiltros.intIdClasificacionGeneral = 0;
            objFiltros.intIdFactor = 0;
            objFiltros.intIdObjetivo = 0;

            /**********************Filtros  de Consulta****************************/
            booResult = cCuadroRiesgos.LoadInfoReporteRiesgosPlanes(ref strErrMgs, ref lstReporte, objFiltros);
            if (lstReporte != null)
            {
                foreach (clsDTOCuadroMandoRiesgosDetalle objCuadro in lstReporte)
                {
                    if (objCuadro.strRiesgoInherente == "Bajo")
                    {
                        valorBajo = valorBajo + 1;
                    }
                    if (objCuadro.strRiesgoInherente == "Moderado")
                    {
                        valorModerado = valorModerado + 1;
                    }
                    if (objCuadro.strRiesgoInherente == "Alto")
                    {
                        valorAlto = valorAlto + 1;
                    }
                    if (objCuadro.strRiesgoInherente == "Extremo")
                    {
                        valorExtremo = valorExtremo + 1;
                    }
                }
                System.Data.DataTable dtCuadroMando = new System.Data.DataTable();
                DataColumn dcColumn;

                dcColumn = new DataColumn();
                dcColumn.ColumnName = "Riesgo Inherente";
                dtCuadroMando.Columns.Add(dcColumn);
                dcColumn = new DataColumn();
                dcColumn.ColumnName = "Valor";
                dtCuadroMando.Columns.Add(dcColumn);

                DataRow dr;
                dr = dtCuadroMando.NewRow();
                dr["Riesgo Inherente"] = "Bajo";
                dr["Valor"] = valorBajo;
                dtCuadroMando.Rows.Add(dr);
                dr = dtCuadroMando.NewRow();
                dr["Riesgo Inherente"] = "Moderado";
                dr["Valor"] = valorModerado;
                dtCuadroMando.Rows.Add(dr);
                dr = dtCuadroMando.NewRow();
                dr["Riesgo Inherente"] = "Alto";
                dr["Valor"] = valorAlto;
                dtCuadroMando.Rows.Add(dr);
                dr = dtCuadroMando.NewRow();
                dr["Riesgo Inherente"] = "Extremo";
                dr["Valor"] = valorExtremo;
                dtCuadroMando.Rows.Add(dr);

                mtdViewChartSaro(dtCuadroMando);
            }

            return booResult;
        }
        public void mtdViewChartSaro(System.Data.DataTable dtInfo)
        {
            //GVriesgosSaro.DataSource = dtInfo;
            //GVriesgosSaro.DataBind();
            string[] x = new string[dtInfo.Rows.Count];
            int[] y = new int[dtInfo.Rows.Count];
            int Total = 0;
            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                x[i] = dtInfo.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dtInfo.Rows[i][1]);
                Total = Total + Convert.ToInt32(dtInfo.Rows[i][1]);
            }
            Session["TotalSaro"] = Total;
            ChartSaro.Series[0].Points.DataBindXY(x, y);
            ChartSaro.Series[0].ChartType = SeriesChartType.Doughnut;
            ChartSaro.ChartAreas["ChartSaroArea"].Area3DStyle.Enable3D = false;
            ChartSaro.Legends[0].Enabled = true;
            ChartSaro.Series[0]["PieLabelStyle"] = "Disabled";
            ChartSaro.Titles.Add("NewTitle");
            ChartSaro.Titles[1].Text = "TOTAL DE RIESGO RESIDUAL POR NIVEL";
            ChartSaro.Titles[1].Alignment = System.Drawing.ContentAlignment.TopCenter;
            foreach (System.Web.UI.DataVisualization.Charting.Series charts in ChartSaro.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "Bajo": point.Color = System.Drawing.Color.Green; break;
                        case "Moderado": point.Color = System.Drawing.Color.Yellow; break;
                        case "Alto": point.Color = System.Drawing.Color.Orange; break;
                        case "Extremo": point.Color = System.Drawing.Color.Red; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);

                }
            }
        }
        protected void ChartSaro_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is System.Web.UI.DataVisualization.Charting.ChartArea)
            {
                var ta = new TextAnnotation();
                ta.Text = Session["TotalSaro"].ToString();
                ta.Width = e.Position.Width;
                ta.Height = e.Position.Height;
                ta.X = e.Position.X;
                ta.Y = e.Position.Y;
                ta.Font = new System.Drawing.Font("Ms Sans Serif", 16, System.Drawing.FontStyle.Bold);

                ChartSaro.Annotations.Add(ta);
            }
        }

        private bool LoadInfoReporteInhenrente(ref string strErrMgs)
        {
            bool booResult = false;
            //string strErrMgs = string.Empty;
            //string NombreRiesgoInherente = string.Empty;
            int valorBajo = 0;
            int valorModerado = 0;
            int valorAlto = 0;
            int valorExtremo = 0;
            List<clsDTOCuadroMandoRiesgosDetalle> lstReporte = new List<clsDTOCuadroMandoRiesgosDetalle>();
            clsBLLCuadroMandoRiesgosDetalle cCuadroRiesgos = new clsBLLCuadroMandoRiesgosDetalle();
            //clsDTOCuadroMandoConsolidado cuadroMando = new clsDTOCuadroMandoConsolidado();
            clsDTOCuadroMandoConsolidadoFiltros objFiltros = new clsDTOCuadroMandoConsolidadoFiltros();
            /**********************Filtros de Consulta****************************/
            objFiltros.intRiesgoGlobal = 0;
            objFiltros.intIdCadenaValor = 0;
            objFiltros.intIdMacroProceso = 0;
            objFiltros.intIdProceso = 0;
            objFiltros.intIdSubProceso = 0;
            //objFiltros.intArea = Convert.ToInt32(ddlAreas.SelectedValue);
            objFiltros.intIdClasificacionGeneral = 0;
            objFiltros.intIdFactor = 0;
            objFiltros.intIdObjetivo = 0;

            /**********************Filtros  de Consulta****************************/
            booResult = cCuadroRiesgos.LoadInfoReporteRiesgosInherentes(ref strErrMgs, ref lstReporte, objFiltros);
            if (lstReporte != null)
            {
                foreach (clsDTOCuadroMandoRiesgosDetalle objCuadro in lstReporte)
                {
                    if (objCuadro.strRiesgoInherente == "Bajo")
                    {
                        valorBajo = valorBajo + 1;
                    }
                    if (objCuadro.strRiesgoInherente == "Moderado")
                    {
                        valorModerado = valorModerado + 1;
                    }
                    if (objCuadro.strRiesgoInherente == "Alto")
                    {
                        valorAlto = valorAlto + 1;
                    }
                    if (objCuadro.strRiesgoInherente == "Extremo")
                    {
                        valorExtremo = valorExtremo + 1;
                    }
                }
                System.Data.DataTable dtCuadroMando = new System.Data.DataTable();
                DataColumn dcColumn;

                dcColumn = new DataColumn();
                dcColumn.ColumnName = "Riesgo Inherente";
                dtCuadroMando.Columns.Add(dcColumn);
                dcColumn = new DataColumn();
                dcColumn.ColumnName = "Valor";
                dtCuadroMando.Columns.Add(dcColumn);

                DataRow dr;
                dr = dtCuadroMando.NewRow();
                dr["Riesgo Inherente"] = "Bajo";
                dr["Valor"] = valorBajo;
                dtCuadroMando.Rows.Add(dr);
                dr = dtCuadroMando.NewRow();
                dr["Riesgo Inherente"] = "Moderado";
                dr["Valor"] = valorModerado;
                dtCuadroMando.Rows.Add(dr);
                dr = dtCuadroMando.NewRow();
                dr["Riesgo Inherente"] = "Alto";
                dr["Valor"] = valorAlto;
                dtCuadroMando.Rows.Add(dr);
                dr = dtCuadroMando.NewRow();
                dr["Riesgo Inherente"] = "Extremo";
                dr["Valor"] = valorExtremo;
                dtCuadroMando.Rows.Add(dr);

                mtdViewChartInherente(dtCuadroMando);
            }

            return booResult;
        }

        public void mtdViewChartInherente(System.Data.DataTable dtInfo)
        {
            //GVriesgosSaro.DataSource = dtInfo;
            //GVriesgosSaro.DataBind();
            string[] x = new string[dtInfo.Rows.Count];
            int[] y = new int[dtInfo.Rows.Count];
            int Total = 0;
            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                x[i] = dtInfo.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dtInfo.Rows[i][1]);
                Total = Total + Convert.ToInt32(dtInfo.Rows[i][1]);
            }
            Session["TotalInherente"] = Total;
            ChartInh.Series[0].Points.DataBindXY(x, y);
            ChartInh.Series[0].ChartType = SeriesChartType.Doughnut;
            ChartInh.ChartAreas["ChartSaroInherente"].Area3DStyle.Enable3D = false;
            ChartInh.Legends[0].Enabled = true;
            ChartInh.Series[0]["PieLabelStyle"] = "Disabled";
            ChartInh.Titles.Add("NewTitle");
            ChartInh.Titles[1].Text = "TOTAL DE RIESGO INHERENTE POR NIVEL";
            ChartInh.Titles[1].Alignment = System.Drawing.ContentAlignment.TopCenter;
            foreach (System.Web.UI.DataVisualization.Charting.Series charts in ChartInh.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "Bajo": point.Color = System.Drawing.Color.Green; break;
                        case "Moderado": point.Color = System.Drawing.Color.Yellow; break;
                        case "Alto": point.Color = System.Drawing.Color.Orange; break;
                        case "Extremo": point.Color = System.Drawing.Color.Red; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);

                }
            }
        }

        protected void ChartInherente_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is System.Web.UI.DataVisualization.Charting.ChartArea)
            {
                var ta = new TextAnnotation();
                ta.Text = Session["TotalInherente"].ToString();
                ta.Width = e.Position.Width;
                ta.Height = e.Position.Height;
                ta.X = e.Position.X;
                ta.Y = e.Position.Y;
                ta.Font = new System.Drawing.Font("Ms Sans Serif", 16, System.Drawing.FontStyle.Bold);

                ChartInh.Annotations.Add(ta);
            }
        }

        protected void ChartEstadoRoi_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is System.Web.UI.DataVisualization.Charting.ChartArea)
            {
                var ta = new TextAnnotation();
                ta.Text = Session["TotalEstadosRoi"].ToString();
                ta.Width = e.Position.Width;
                ta.Height = e.Position.Height;
                ta.X = e.Position.X;
                ta.Y = e.Position.Y;
                ta.Font = new System.Drawing.Font("Ms Sans Serif", 16, System.Drawing.FontStyle.Bold);

                ChartEstadoRoi.Annotations.Add(ta);
            }
        }
    }
}