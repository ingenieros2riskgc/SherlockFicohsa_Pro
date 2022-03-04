﻿using ListasSarlaft.Classes;
using ListasSarlaft.Classes.BLL.Auditoria;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListasSarlaft.UserControls.MAuditoria
{
    public partial class Recomendaciones : System.Web.UI.UserControl
    {
        string IdFormulario = "3006";
        cCuenta cCuenta = new cCuenta();
        cAuditoria cAu = new cAuditoria();
        private int rowGridAuditoria;
        private int RowGridAuditoria
        {
            get
            {
                rowGridAuditoria = (int)ViewState["rowGridAuditoria"];
                return rowGridAuditoria;
            }
            set
            {
                rowGridAuditoria = value;
                ViewState["rowGridAuditoria"] = rowGridAuditoria;
            }
        }
        private DataTable infoGridAuditorias;
        private DataTable InfoGridAuditorias
        {
            get
            {
                infoGridAuditorias = (DataTable)ViewState["infoGridAuditorias"];
                return infoGridAuditorias;
            }
            set
            {
                infoGridAuditorias = value;
                ViewState["infoGridAuditorias"] = infoGridAuditorias;
            }
        }
        private int pagIndexInfoGridAuditoria;
        private int PagIndexInfoGridAuditoria
        {
            get
            {
                pagIndexInfoGridAuditoria = (int)ViewState["pagIndexInfoGridAuditoria"];
                return pagIndexInfoGridAuditoria;
            }
            set
            {
                pagIndexInfoGridAuditoria = value;
                ViewState["pagIndexInfoGridAuditoria"] = pagIndexInfoGridAuditoria;
            }
        }
        private static int LastInsertIdCE;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cCuenta.permisosConsulta(IdFormulario) == "False")
                Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            ScriptManager scripManager = ScriptManager.GetCurrent(this.Page);
            SqlDataSource8.SelectParameters["IdArea"].DefaultValue = Session["IdAreaUser"].ToString();
            //scripManager.RegisterPostBackControl(GridView8);
        }

        #region Buttons
        protected void imgBtnAuditoria_Click(object sender, ImageClickEventArgs e) { }

        protected void btnImgCancelarRec_Click(object sender, ImageClickEventArgs e)
        {
            filaDetalleRecomendacion.Visible = false;
            filaGridRec.Visible = true;
            filaCierreRec.Visible = true;
        }

        protected void btnImgInsertarRec_Click(object sender, ImageClickEventArgs e)
        {
            bool err = false;

            if (cCuenta.permisosAgregar(IdFormulario) == "False")
            {
                //omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
                lblMsgBox.Text = "No tiene los permisos suficientes para llevar a cabo esta acción.";
                mpeMsgBox.Show();
            }
            else
            {
                if (VerificarCampos())
                {
                    //Inserta el maestro del nodo hijo
                    try
                    {
                        SqlDataSource25.InsertParameters["IdRecomendacion"].DefaultValue = txtCodRec.Text;
                        SqlDataSource25.InsertParameters["Estado"].DefaultValue = ddlEstado.SelectedValue;
                        SqlDataSource25.InsertParameters["Observacion"].DefaultValue = txtDescAct.Text;
                        SqlDataSource25.InsertParameters["FechaRegistro"].DefaultValue = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        SqlDataSource25.InsertParameters["IdUsuario"].DefaultValue = Session["idUsuario"].ToString().Trim(); //Aca va el id del Usuario de la BD
                        SqlDataSource25.Insert();
                    }
                    catch (Exception except)
                    {
                        //Handle the Exception.
                        omb.ShowMessage("Error en la inserción de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
                        err = true;
                    }

                    if (!err)
                    {
                        try
                        {
                            SqlDataSource24.UpdateParameters["IdRecomendacion"].DefaultValue = txtCodRec.Text;
                            SqlDataSource24.UpdateParameters["Estado"].DefaultValue = ddlEstado.SelectedValue;
                            SqlDataSource24.Update();
                        }
                        catch (Exception except)
                        {
                            //Handle the Exception.
                            omb.ShowMessage("Error en la Actualización de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
                            err = true;
                        }

                        if (!err)
                        {
                            omb.ShowMessage("La información se insertó con éxito en la Base de Datos.", 3, "Atención");
                            filaDetalleRecomendacion.Visible = false;
                            filaGridRec.Visible = true;
                        }
                    }
                }
            }
        }

        protected void btnImgCancelarLog_Click(object sender, ImageClickEventArgs e)
        {
            filaLogEstados.Visible = false;
            filaGridRec.Visible = true;
            filaCierreRec.Visible = true;
        }

        protected void btnCierreRec_Click(object sender, EventArgs e)
        {
            if (cCuenta.permisosActualizar(IdFormulario) == "False")
            {
                //omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
                lblMsgBox.Text = "No tiene los permisos suficientes para llevar a cabo esta acción.";
                mpeMsgBox.Show();
            }
            else
            {
                lblAccion.Text = "CERRAR";
                lblMsgBox.Text = "Desea cerrar todas las recomendaciones de la auditoría?";
                mpeMsgBox.Show();
            }

        }

        protected void btnRevertirEstado_Click(object sender, EventArgs e)
        {
            if (cCuenta.permisosActualizar(IdFormulario) == "False")
            {
                //omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
                lblMsgBox.Text = "No tiene los permisos suficientes para llevar a cabo esta acción.";
                mpeMsgBox.Show();
            }
            else
            {
                lblAccion.Text = "REVERTIR";
                lblMsgBox.Text = "Desea devolver la Auditoria a estado de Verificación?";
                mpeMsgBox.Show();
            }
        }

        protected void btnImgok_Click(object sender, EventArgs e)
        {
            bool err = false;
            string TextoAdicional = "", selectCommand;
            int nodoAuditoria = 0;

            mpeMsgBox.Hide();

            if (lblAccion.Text == "REVERTIR")
            {
                try
                {
                    SqlDataSource2.UpdateParameters["IdAuditoria"].DefaultValue = txtCodAuditoriaSel.Text;
                    SqlDataSource2.Update();
                    cAu.ActualizarLogHistoricoAudutoria(txtCodAuditoriaSel.Text, "NULL", "GETDATE()", "NULL", "SI");
                }
                catch (Exception except)
                {
                    omb.ShowMessage("Error en la actualización del estado." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
                    err = true;
                }

                if (!err)
                {
                    omb.ShowMessage("La información se actualizó con éxito en la Base de Datos.", 3, "Atención");

                    //Trae el nodo del grupo de Auditoria
                    string conString = WebConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
                    selectCommand = "SELECT JO.idHijo FROM [Parametrizacion].[JerarquiaOrganizacional] AS JO WHERE JO.TipoArea = 'A'";
                    SqlDataAdapter dad = new SqlDataAdapter(selectCommand, conString);
                    DataTable dtblDiscuss = new DataTable();
                    dad.Fill(dtblDiscuss);

                    DataView view = new DataView(dtblDiscuss);

                    foreach (DataRowView row in view)
                    {
                        nodoAuditoria = Convert.ToInt32(row["idHijo"].ToString().Trim());
                    }

                    TextoAdicional = "Planeación Código: " + txtCodPlaneacion.Text + ", Nombre: " + txtNomPlaneacion.Text + "<br>";
                    TextoAdicional = TextoAdicional + "Auditoría Código: " + txtCodAuditoriaSel.Text + ", Nombre: " + txtNomAuditoriaSel.Text + "<div><br></div>";

                    boolEnviarNotificacion(1, Convert.ToInt32(txtCodAuditoriaSel.Text.Trim()), nodoAuditoria, "", TextoAdicional);
                }
            }
            else if (lblAccion.Text == "CERRAR")
            {
                try
                {
                    SqlDataSource26.UpdateParameters["IdAuditoria"].DefaultValue = txtCodAuditoriaSel.Text;
                    SqlDataSource26.UpdateParameters["Estado"].DefaultValue = "CUMPLIDA";
                    SqlDataSource26.Update();
                    cAu.CerrarLogHistoricoAudutoria(txtCodAuditoriaSel.Text, "NULL", "NULL", "NULL", "NO", "GETDATE()");

                    omb.ShowMessage("La información se actualizó con éxito en la Base de Datos.", 3, "Atención");
                }
                catch (Exception except)
                {
                    omb.ShowMessage("Error en la actualización del estado de la auditoría." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
                    err = true;
                }

            }

            if (!err)
            {
                txtNomPlaneacion.Text = "";
                txtCodPlaneacion.Text = "";
                txtCodAuditoriaSel.Text = "";
                txtCodObjetivoSel.Text = "";
                txtCodEnfoqueSel.Text = "";
                txtCodLiteralSel.Text = "";
                txtCodHallazgoSel.Text = "";
                txtNomAuditoriaSel.Text = "";
                txtNomObjetivoSel.Text = "";
                txtNomEnfoqueSel.Text = "";
                txtNomLiteralSel.Text = "";
                txtNomHallazgoSel.Text = "";
                txtNomEnfoqueSel.Height = 18;
                txtNomEnfoqueSel.Width = 402;
                txtNomLiteralSel.Height = 18;
                txtNomLiteralSel.Width = 402;
                txtNomHallazgoSel.Height = 18;
                txtNomHallazgoSel.Width = 402;
                filaGridRec.Visible = false;
                filaCierreRec.Visible = false;
                GridView8.DataBind();
                imgBtnAuditoria.Focus();
            }
        }

        protected void bntInformeRec_Click(object sender, EventArgs e)
        {
            string str = "window.open('AudAdmReporteSeguimiento.aspx?Ca=" + txtCodAuditoriaSel.Text + "','Reporte','width=800,height=600,scrollbars=yes,resizable=yes')";
            Response.Write("<script languaje=javascript>" + str + "</script>");
        }
        #endregion

        protected void ddlEstado_DataBound(object sender, EventArgs e)
        {
            ddlEstado.Items.Insert(0, new ListItem("", "0")); // Inserta el Item con texto Vacio
        }

        #region Gridview
        protected void GridView8_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNomPlaneacion.Text = GridView8.SelectedRow.Cells[1].Text.Trim();
            txtCodPlaneacion.Text = GridView8.SelectedRow.Cells[0].Text.Trim();
            GridView4.DataBind();
            txtCodAuditoriaSel.Text = "";
            txtNomAuditoriaSel.Text = "";
            if (filaGridRec.Visible == true)
                filaGridRec.Visible = false;
            trAuditorias.Visible = true;
            filaCierreRec.Visible = false;
            filaLogEstados.Visible = false;
            filaDetalleRecomendacion.Visible = false;
            txtCodObjetivoSel.Text = "";
            txtNomObjetivoSel.Text = "";
            txtCodEnfoqueSel.Text = "";
            txtCodLiteralSel.Text = "";
            txtNomEnfoqueSel.Text = "";
            txtNomLiteralSel.Text = "";
            txtNomHallazgoSel.Text = "";
            txtCodHallazgoSel.Text = "";
            txtNomEnfoqueSel.Height = 18;
            txtNomEnfoqueSel.Width = 402;
            txtNomLiteralSel.Height = 18;
            txtNomLiteralSel.Width = 402;
            txtNomHallazgoSel.Height = 18;
            txtNomHallazgoSel.Width = 402;

            SqlDSregistrosAud.SelectParameters["IdArea"].DefaultValue = Session["IdAreaUser"].ToString();

            popupPlanea.Cancel();
        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodAuditoriaSel.Text = GridView6.SelectedRow.Cells[0].Text.Trim();
            txtNomAuditoriaSel.Text = GridView6.SelectedRow.Cells[1].Text.Trim();
            if (filaGridRec.Visible == true)
                filaGridRec.Visible = false;

            filaCierreRec.Visible = true;
            filaLogEstados.Visible = false;
            filaDetalleRecomendacion.Visible = false;
            txtCodObjetivoSel.Text = "";
            txtNomObjetivoSel.Text = "";
            txtCodEnfoqueSel.Text = "";
            txtCodLiteralSel.Text = "";
            txtNomEnfoqueSel.Text = "";
            txtNomLiteralSel.Text = "";
            txtNomHallazgoSel.Text = "";
            txtCodHallazgoSel.Text = "";
            txtNomEnfoqueSel.Height = 18;
            txtNomEnfoqueSel.Width = 402;
            txtNomLiteralSel.Height = 18;
            txtNomLiteralSel.Width = 402;
            txtNomHallazgoSel.Height = 18;
            txtNomHallazgoSel.Width = 402;
            popupAuditoria.Cancel();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GridView1.SelectedRow.RowType == DataControlRowType.DataRow)
            {
                ddlEstado.Focus();
                txtCodRec.Text = GridView1.SelectedRow.Cells[0].Text.Trim();
                txtObjetivo.Text = GridView1.SelectedRow.Cells[3].Text.Trim();
                txtTipoPoD.Text = GridView1.SelectedRow.Cells[4].Text.Trim();
                if (txtTipoPoD.Text == "Procesos")
                    lblPoD.Text = "Proceso";
                else
                    lblPoD.Text = "Dependencia Auditada";
                txtNombrePoD.Text = GridView1.SelectedDataKey[1].ToString().Trim();
                txtRecomendacion.Text = GridView1.SelectedRow.Cells[1].Text.Trim();
                txtCodRecGen.Text = GridView1.SelectedRow.Cells[0].Text.Trim();
                ddlEstado.SelectedValue = null;
                txtDescAct.Text = "";
                txtUsuarioRec.Text = Session["loginUsuario"].ToString().Trim(); //Aca va el codigo de usuario logueado
                txtFecCreacionRec.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                GridView2.DataBind();

                int rows = 0, longMax = 0, rowsAdd = 0;
                double temp = 0;

                txtRecomendacion.Height = 18;
                txtRecomendacion.Width = 402;

                //Revisa la longitud max del texto y el número de líneas
                foreach (string strItem in Regex.Split(GridView1.SelectedRow.Cells[1].Text, "</div>"))
                {
                    rows = rows + 1;
                    if (strItem.Length > longMax) longMax = strItem.Length;
                    if (strItem.Length > 126)
                    {
                        temp = strItem.Length / 126;
                        rowsAdd = rowsAdd + (int)Math.Truncate(temp);
                    }
                }

                if (rows + rowsAdd > 1) txtRecomendacion.Height = (rows + rowsAdd) * 18;

                if (longMax > 72)
                    txtRecomendacion.Width = 700;

                else
                    txtRecomendacion.Width = 402;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandArgument.ToString() == "ActualizarEstado")
            {
                filaGridRec.Visible = false;
                filaCierreRec.Visible = false;
                filaDetalleRecomendacion.Visible = true;
            }
            else if (e.CommandArgument.ToString() == "LogEstados")
            {
                filaGridRec.Visible = false;
                filaCierreRec.Visible = false;
                filaLogEstados.Visible = true;
            }
        }

        protected void GridView7_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodObjetivoSel.Text = GridView7.SelectedRow.Cells[0].Text.Trim();
            txtNomObjetivoSel.Text = GridView7.SelectedRow.Cells[1].Text.Trim();
            txtCodEnfoqueSel.Text = "";
            txtCodLiteralSel.Text = "";
            txtNomEnfoqueSel.Text = "";
            txtNomLiteralSel.Text = "";
            txtCodHallazgoSel.Text = "";
            txtNomHallazgoSel.Text = "";
            txtNomEnfoqueSel.Height = 18;
            txtNomEnfoqueSel.Width = 402;
            txtNomLiteralSel.Height = 18;
            txtNomLiteralSel.Width = 402;
            txtNomHallazgoSel.Height = 18;
            txtNomHallazgoSel.Width = 402;

            if (filaGridRec.Visible == true) filaGridRec.Visible = false;
            filaLogEstados.Visible = false;
            filaDetalleRecomendacion.Visible = false;

            popupObjetivo.Cancel();

        }

        protected void GridView9_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodEnfoqueSel.Text = GridView9.SelectedRow.Cells[0].Text.Trim();
            txtNomEnfoqueSel.Text = GridView9.SelectedRow.Cells[1].Text.Trim();
            txtCodLiteralSel.Text = "";
            txtNomLiteralSel.Text = "";
            txtNomEnfoqueSel.Height = 18;
            txtNomEnfoqueSel.Width = 402;
            txtNomLiteralSel.Height = 18;
            txtNomLiteralSel.Width = 402;
            txtNomHallazgoSel.Height = 18;
            txtNomHallazgoSel.Width = 402;
            txtCodHallazgoSel.Text = "";
            txtNomHallazgoSel.Text = "";
            if (filaGridRec.Visible == true) filaGridRec.Visible = false;
            filaLogEstados.Visible = false;
            filaDetalleRecomendacion.Visible = false;
            popupEnfoque.Cancel();

            int rows = 0, longMax = 0, rowsAdd = 0;
            double temp = 0;

            //Cambia la altura y el ancho del labol de Enfoque
            //Revisa la longitud max del texto y el número de líneas
            foreach (string strItem in Regex.Split(GridView9.SelectedRow.Cells[1].Text, "</div>"))
            {
                rows = rows + 1;
                if (strItem.Length > longMax) longMax = strItem.Length;
                if (strItem.Length > 126)
                {
                    temp = strItem.Length / 126;
                    rowsAdd = rowsAdd + (int)Math.Truncate(temp);
                }
            }

            if (rows + rowsAdd > 1) txtNomEnfoqueSel.Height = (rows + rowsAdd) * 18;

            if (longMax > 72)
                txtNomEnfoqueSel.Width = 700;
            else
                txtNomEnfoqueSel.Width = 402;

        }

        protected void GridView10_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rows = 0, longMax = 0, rowsAdd = 0;
            double temp = 0;

            txtCodHallazgoSel.Text = "";
            txtNomHallazgoSel.Text = "";
            txtNomHallazgoSel.Height = 18;
            txtNomHallazgoSel.Width = 402;
            txtNomLiteralSel.Height = 18;
            txtNomLiteralSel.Width = 402;

            //Revisa la longitud max del texto y el número de líneas
            foreach (string strItem in Regex.Split(GridView10.SelectedRow.Cells[1].Text, "</div>"))
            {
                rows = rows + 1;
                if (strItem.Length > longMax) longMax = strItem.Length;
                if (strItem.Length > 126)
                {
                    temp = strItem.Length / 126;
                    rowsAdd = rowsAdd + (int)Math.Truncate(temp);
                }
            }

            txtNomLiteralSel.Text = GridView10.SelectedRow.Cells[1].Text.Trim();
            txtCodLiteralSel.Text = GridView10.SelectedRow.Cells[0].Text.Trim();

            if (rows + rowsAdd > 1) txtNomLiteralSel.Height = (rows + rowsAdd) * 18;

            if (longMax > 72)
                txtNomLiteralSel.Width = 700;
            else
                txtNomLiteralSel.Width = 402;


            if (filaGridRec.Visible == true) filaGridRec.Visible = false;
            filaLogEstados.Visible = false;
            filaDetalleRecomendacion.Visible = false;

            popupLiteral.Cancel();

            GridView1.DataBind();
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodHallazgoSel.Text = GridView3.SelectedRow.Cells[0].Text.Trim();
            txtNomHallazgoSel.Text = GridView3.SelectedRow.Cells[1].Text.Trim();

            int rows = 0, longMax = 0, rowsAdd = 0;
            double temp = 0;
            clsRecomendacionBLL objProcess = new clsRecomendacionBLL();
            string strErrMsg = string.Empty;
            string IdHallazgo = GridView3.SelectedRow.Cells[0].Text.Trim();
            Boolean flag = objProcess.mtdCalculaEdadRecomendacion(ref strErrMsg, IdHallazgo);
            //Cambia la altura y el ancho del labol de Enfoque
            //Revisa la longitud max del texto y el número de líneas
            foreach (string strItem in Regex.Split(GridView3.SelectedRow.Cells[1].Text, "</div>"))
            {
                rows = rows + 1;
                if (strItem.Length > longMax) longMax = strItem.Length;
                if (strItem.Length > 126)
                {
                    temp = strItem.Length / 126;
                    rowsAdd = rowsAdd + (int)Math.Truncate(temp);
                }
            }

            if (rows + rowsAdd > 1) txtNomHallazgoSel.Height = (rows + rowsAdd) * 18;

            if (longMax > 72)
                txtNomHallazgoSel.Width = 700;
            else
                txtNomHallazgoSel.Width = 402;

            if (filaGridRec.Visible == false) filaGridRec.Visible = true;
            filaLogEstados.Visible = false;
            filaDetalleRecomendacion.Visible = false;

            popupHallazgo.Cancel();
        }
        #endregion

        protected Boolean VerificarCampos()
        {
            bool err = true;

            if (ddlEstado.SelectedValue == "0")
            {
                err = false;
                omb.ShowMessage("Debe seleccionar el Tipo de Estado.", 2, "Atención");
                ddlEstado.Focus();
            }
            else if (ValidarCadenaVacia(txtDescAct.Text))
            {
                err = false;
                omb.ShowMessage("Debe ingresar la Observación del Cambio de Estado.", 2, "Atención");
                txtDescAct.Focus();
            }

            return err;
        }

        protected Boolean ValidarCadenaVacia(string cadena)
        {
            Regex rx = new Regex(@"^-?\d+(\.\d{2})?$");
            string Espacio = "<br>";
            string Div = "<div>";
            string Div2 = "</div>";
            string b = "<b>";
            string b2 = "</b>";
            string cadena2 = "";

            cadena2 = Regex.Replace(cadena, Espacio, " ");
            cadena2 = Regex.Replace(cadena2, Div, " ");
            cadena2 = Regex.Replace(cadena2, Div2, " ");
            cadena2 = Regex.Replace(cadena2, b, " ");
            cadena2 = Regex.Replace(cadena2, b2, " ");

            if (cadena2.Trim() == "")
                return (true);
            else
                return (false);
        }

        private Boolean boolEnviarNotificacion(int idEvento, int idRegistro, int idNodoJerarquia, string FechaFinal, string textoAdicional)
        {
            #region Variables
            bool err = false;
            string Destinatario = "", Copia = "", Asunto = "", Otros = "", Cuerpo = "", NroDiasRecordatorio = "";
            string selectCommand = "", AJefeInmediato = "", AJefeMediato = "", RequiereFechaCierre = "";
            string idJefeInmediato = "", idJefeMediato = "";
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
                        Cuerpo = textoAdicional + row["Cuerpo"].ToString().Trim();
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

                //Insertar el Registro en la tabla de Correos Enviados
                SqlDataSource200.InsertParameters["Destinatario"].DefaultValue = Destinatario.Trim();
                SqlDataSource200.InsertParameters["Copia"].DefaultValue = Copia;
                SqlDataSource200.InsertParameters["Otros"].DefaultValue = Otros;
                SqlDataSource200.InsertParameters["Asunto"].DefaultValue = Asunto;
                SqlDataSource200.InsertParameters["Cuerpo"].DefaultValue = Cuerpo;
                SqlDataSource200.InsertParameters["Estado"].DefaultValue = "POR ENVIAR";
                SqlDataSource200.InsertParameters["Tipo"].DefaultValue = "CREACION";
                SqlDataSource200.InsertParameters["FechaEnvio"].DefaultValue = "";
                SqlDataSource200.InsertParameters["IdEvento"].DefaultValue = idEvento.ToString().Trim();
                SqlDataSource200.InsertParameters["IdRegistro"].DefaultValue = idRegistro.ToString().Trim();
                SqlDataSource200.InsertParameters["IdUsuario"].DefaultValue = "1"; //Session["idUsuario"].ToString().Trim(); //Aca va el id del Usuario de la BD
                SqlDataSource200.InsertParameters["FechaRegistro"].DefaultValue = System.DateTime.Now.ToString("yyyy-MM-dd");
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
                if (RequiereFechaCierre == "SI")
                {
                    //Si los NroDiasRecordatorio es diferente de vacio se inserta el registro correspondiente en la tabla CorreosRecordatorio
                    SqlDataSource201.InsertParameters["IdCorreosEnviados"].DefaultValue = LastInsertIdCE.ToString().Trim();
                    SqlDataSource201.InsertParameters["NroDiasRecordatorio"].DefaultValue = NroDiasRecordatorio;
                    SqlDataSource201.InsertParameters["Estado"].DefaultValue = "POR ENVIAR";
                    SqlDataSource201.InsertParameters["FechaFinal"].DefaultValue = FechaFinal;
                    SqlDataSource201.InsertParameters["IdUsuario"].DefaultValue = "1";//Session["idUsuario"].ToString().Trim(); //Aca va el id del Usuario de la BD
                    SqlDataSource201.InsertParameters["FechaRegistro"].DefaultValue = System.DateTime.Now.ToString("yyyy-MM-dd");
                    SqlDataSource201.Insert();
                }

                try
                {
                    #region Envio Correo
                    MailMessage message = new MailMessage();
                    SmtpClient smtpClient = new SmtpClient();
                    //MailAddress fromAddress = new MailAddress("risksherlock@hotmail.com", "Software Sherlock");
                    MailAddress fromAddress = new MailAddress(((System.Net.NetworkCredential)(smtpClient.Credentials)).UserName, "Software Sherlock");

                    message.From = fromAddress;//here you can set address

                    #region Destinatario
                    foreach (string substr in Destinatario.Split(';'))
                    {
                        if (!string.IsNullOrEmpty(substr.Trim()))
                            message.To.Add(substr);
                    }
                    #endregion

                    #region Copia
                    if (Copia.Trim() != "")
                        foreach (string substr in Copia.Split(';'))
                        {
                            if (!string.IsNullOrEmpty(substr.Trim()))
                                message.CC.Add(substr);
                        }
                    #endregion

                    #region Otros
                    if (Otros.Trim() != "")
                        foreach (string substr in Otros.Split(';'))
                        {
                            if (!string.IsNullOrEmpty(substr.Trim()))
                                message.CC.Add(substr);
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
                    omb.ShowMessage("Error en el envio de la notificacion." + "<br/>" + "Descripción: " + ex.Message.ToString().Trim(), 1, "Atención");
                    err = true;
                }

                if (!err)
                {
                    //Actualiza el Estado del Correo Enviado
                    SqlDataSource200.UpdateParameters["IdCorreosEnviados"].DefaultValue = LastInsertIdCE.ToString().Trim();
                    SqlDataSource200.UpdateParameters["Estado"].DefaultValue = "ENVIADO";
                    SqlDataSource200.UpdateParameters["FechaEnvio"].DefaultValue = System.DateTime.Now.ToString("yyyy-MM-dd");
                    SqlDataSource200.Update();
                }
            }

            return (err);
        }

        protected void SqlDataSource200_On_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            LastInsertIdCE = (int)e.Command.Parameters["@NewParameter2"].Value;
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string customerId = GridView4.DataKeys[e.Row.RowIndex].Value.ToString();
                //int IdEvento = Convert.ToInt32(Session["IdEvento"].ToString());
                //int IdRiesgo = Convert.ToInt32(Session["IdRiesgo"].ToString());
                GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;
                string strCondicion = "AND ([Auditoria].[Auditoria].[Estado] = 'INFORME')";
                //                string strConsulta = string.Format("SELECT [Tema], [Estandar].[IdEstandar], [Estandar].[Nombre], [IdPlaneacion], [Tipo],ISNULL([IdDependencia],0) AS IdDependencia, ISNULL([IdProceso], 0) as IdProceso, [NombreHijo] as NombreDP, [Auditoria].[IdUsuario], [Usuarios].[Usuario], CONVERT(VARCHAR(10),[Auditoria].[FechaRegistro],120) AS FechaRegistro, [Auditoria].[IdEmpresa],  CONVERT(VARCHAR(MAX), [Recursos]) AS Recursos, CONVERT(VARCHAR(MAX), [Auditoria].[Objetivo]) AS Objetivo , CONVERT(VARCHAR(MAX), [Alcance]) AS Alcance, IsNull([NivelImportancia],0) AS NivelImportancia, IsNull([IdDetalleTipo_TipoNaturaleza],0) AS IdDetalleTipo_TipoNaturaleza, CONVERT(VARCHAR(10),[FechaInicio],120) AS FechaInicio,  CONVERT(VARCHAR(10),[FechaCierre],120) AS FechaCierre,ISNULL([IdMesEjecucion],0) as IdMesEjecucion,[SemanaEjecucion] " +
                //         " [Encabezado], [Metodologia], [Conclusion], [Observaciones], [TituloInforme],[ReferenciaInforme],[Auditoria].[Auditoria].[IdAuditoria] " +
                //                    "FROM [Auditoria].[Auditoria], [Auditoria].[Estandar], [Listas].[Usuarios], [Parametrizacion].[JerarquiaOrganizacional] " +
                //         "WHERE[Auditoria].IdEstandar = [Estandar].IdEstandar AND " +
                //                "[Auditoria].IdUsuario = [Usuarios].IdUsuario AND " +
                //                "[Auditoria].IdDependencia = [JerarquiaOrganizacional].IdHijo AND " +
                //                "[Auditoria].IdPlaneacion = {0} and IdDependencia <> 0 and IdProceso = 0 and [Auditoria].[IdArea] = {2} {1}" +
                //         " UNION " +
                //         "SELECT [Tema], [Estandar].[IdEstandar], [Estandar].[Nombre], [IdPlaneacion], [Tipo], ISNULL([IdDependencia],0) AS IdDependencia, ISNULL([Auditoria].[IdProceso], 0) as IdProceso, [Proceso].[Nombre] as NombreDP, [Auditoria].[IdUsuario], [Usuarios].[Usuario], CONVERT(VARCHAR(10),[Auditoria].[FechaRegistro], 120) AS FechaRegistro, [Auditoria].[IdEmpresa], CONVERT(VARCHAR(MAX), [Recursos]) AS Recursos, CONVERT(VARCHAR(MAX), [Auditoria].[Objetivo]) AS Objetivo, CONVERT(VARCHAR(MAX), [Alcance]) AS Alcance, IsNull([NivelImportancia], 0) AS NivelImportancia, IsNull([IdDetalleTipo_TipoNaturaleza], 0) AS IdDetalleTipo_TipoNaturaleza, CONVERT(VARCHAR(10), [FechaInicio], 120) AS FechaInicio, CONVERT(VARCHAR(10),[FechaCierre], 120) AS FechaCierre,ISNULL([IdMesEjecucion],0) as IdMesEjecucion,[SemanaEjecucion] " +
                //         " [Encabezado], [Metodologia], [Conclusion], [Observaciones], [TituloInforme],[ReferenciaInforme],[Auditoria].[Auditoria].[IdAuditoria] " +
                //         "FROM [Auditoria].[Auditoria], [Auditoria].[Estandar], [Listas].[Usuarios], [Procesos].[Proceso], [Parametrizacion].[JerarquiaOrganizacional], Auditoria.AuditoriaProceso " +
                //"WHERE [Auditoria].IdEstandar = [Estandar].IdEstandar AND " +
                //"[Auditoria].IdUsuario = [Usuarios].IdUsuario AND " +
                //"[Auditoria].IdProceso = [Proceso].IdProceso AND " +
                //"[Auditoria].[IdAuditoria] = AuditoriaProceso.IdAuditoria and " +
                //"[Auditoria].IdPlaneacion = {0} " +
                //"and AuditoriaProceso.IdTipoProceso = 2 and [Auditoria].[IdArea] = {2} {1}" +
                //         " UNION " +
                //         "SELECT [Tema], [Estandar].[IdEstandar], [Estandar].[Nombre], [IdPlaneacion], [Tipo], ISNULL([IdDependencia],0) AS IdDependencia, ISNULL([Auditoria].[IdProceso], 0) as IdProceso, [MacroProceso].[Nombre] as NombreDP, [Auditoria].[IdUsuario], [Usuarios].[Usuario], CONVERT(VARCHAR(10),[Auditoria].[FechaRegistro],120) AS FechaRegistro, [Auditoria].[IdEmpresa], CONVERT(VARCHAR(MAX), [Recursos]) AS Recursos, CONVERT(VARCHAR(MAX), [Auditoria].[Objetivo]) AS Objetivo, CONVERT(VARCHAR(MAX), [Alcance]) AS Alcance, IsNull([NivelImportancia], 0) AS NivelImportancia, IsNull([IdDetalleTipo_TipoNaturaleza], 0) AS IdDetalleTipo_TipoNaturaleza, CONVERT(VARCHAR(10), [FechaInicio], 120) AS FechaInicio, CONVERT(VARCHAR(10),[FechaCierre], 120) AS FechaCierre,ISNULL([IdMesEjecucion],0) as IdMesEjecucion,[SemanaEjecucion] " +
                //         " [Encabezado], [Metodologia], [Conclusion], [Observaciones], [TituloInforme],[ReferenciaInforme],[Auditoria].[Auditoria].[IdAuditoria] " +
                //         "FROM [Auditoria].[Auditoria], [Auditoria].[Estandar], [Listas].[Usuarios], [Procesos].[MacroProceso], [Parametrizacion].[JerarquiaOrganizacional], Auditoria.AuditoriaProceso " +
                //"WHERE [Auditoria].IdEstandar = [Estandar].IdEstandar AND" +
                //"[Auditoria].IdUsuario = [Usuarios].IdUsuario AND " +
                //"[Auditoria].IdProceso = [MacroProceso].IdMacroProceso AND " +
                //"[Auditoria].[IdAuditoria] = AuditoriaProceso.IdAuditoria and" +
                //"[Auditoria].IdPlaneacion = {0}" +
                //" and AuditoriaProceso.IdTipoProceso = 1 and [Auditoria].[IdArea] = {2} {1}", customerId, strCondicion, Session["IdAreaUser"].ToString());
                string strConsulta = string.Format("SELECT [Estandar].[IdEstandar],[Tema], [Estandar].[Nombre], [IdPlaneacion], [Tipo],ISNULL([IdDependencia],0) AS IdDependencia, " + "\n" +
                "ISNULL([Auditoria].[IdProceso], 0) as IdProceso, [NombreHijo] as NombreDP , [Auditoria].[IdUsuario], [Usuarios].[Usuario], " + "\n" +
                "CONVERT(VARCHAR(10),[Auditoria].[FechaRegistro],120) AS FechaRegistro, [Auditoria].[IdEmpresa],  " + "\n" +
                "CONVERT(VARCHAR(MAX), [Recursos]) AS Recursos, CONVERT(VARCHAR(MAX), [Auditoria].[Objetivo]) AS Objetivo," + "\n" +
                "CONVERT(VARCHAR(MAX), [Alcance]) AS Alcance, IsNull([NivelImportancia],0) AS NivelImportancia," + "\n" +
                "IsNull([IdDetalleTipo_TipoNaturaleza],0) AS IdDetalleTipo_TipoNaturaleza, CONVERT(VARCHAR(10),[FechaInicio], 120) AS FechaInicio," + "\n" +
                "CONVERT(VARCHAR(10),[FechaCierre], 120) AS FechaCierre, ISNULL([IdMesEjecucion],0) as IdMesEjecucion,[SemanaEjecucion]," + "\n" +
                "CONVERT(VARCHAR(MAX), [Encabezado]) as Encabezado,CONVERT(VARCHAR(MAX), [Metodologia]) as [Metodologia], " + "\n" +
                "CONVERT(VARCHAR(MAX), [Conclusion]) as Conclusion, CONVERT(VARCHAR(MAX), [Observaciones]) as Observaciones, " + "\n" +
                "CONVERT(VARCHAR(MAX), [TituloInforme]) as TituloInforme,CONVERT(VARCHAR(MAX), [ReferenciaInforme]) as ReferenciaInforme," + "\n" +
                "[Auditoria].[Auditoria].[IdAuditoria]" + "\n" +
                 "       FROM[Auditoria].[Auditoria]" + "\n" +
                 "       INNER JOIN[Auditoria].[Estandar] on[Auditoria].[Estandar].IdEstandar = [Auditoria].[Auditoria].IdEstandar" + "\n" +
                "INNER JOIN[Listas].[Usuarios] ON[Auditoria].IdUsuario = [Usuarios].IdUsuario" + "\n" +
                "INNER JOIN[Parametrizacion].[JerarquiaOrganizacional] ON[Auditoria].IdDependencia = [JerarquiaOrganizacional].IdHijo" + "\n" +
                "INNER JOIN Auditoria.AuditoriaProceso ON[Auditoria].[IdAuditoria] = AuditoriaProceso.IdAuditoria" + "\n" +
                " WHERE " + "\n" +
                "[Auditoria].IdPlaneacion = {0} and[Auditoria].IdProceso = 0 and IdDependencia <> 0 {1} and[Auditoria].[IdArea] = {2}" + "\n" +
                 "UNION" + "\n" +
                 "SELECT[Estandar].[IdEstandar],[Tema], [Estandar].[Nombre], [IdPlaneacion], [Tipo],ISNULL([IdDependencia],0) AS IdDependencia," + "\n" +
                "ISNULL([Auditoria].[IdProceso], 0) as IdProceso, [NombreHijo] as NombreDP , [Auditoria].[IdUsuario], [Usuarios].[Usuario], " + "\n" +
                "CONVERT(VARCHAR(10),[Auditoria].[FechaRegistro],120) AS FechaRegistro, [Auditoria].[IdEmpresa],  " + "\n" +
                "CONVERT(VARCHAR(MAX), [Recursos]) AS Recursos, CONVERT(VARCHAR(MAX), [Auditoria].[Objetivo]) AS Objetivo," + "\n" +
                "CONVERT(VARCHAR(MAX), [Alcance]) AS Alcance, IsNull([NivelImportancia],0) AS NivelImportancia," + "\n" +
                "IsNull([IdDetalleTipo_TipoNaturaleza],0) AS IdDetalleTipo_TipoNaturaleza, CONVERT(VARCHAR(10),[FechaInicio], 120) AS FechaInicio," + "\n" +
                "CONVERT(VARCHAR(10),[FechaCierre], 120) AS FechaCierre, ISNULL([IdMesEjecucion],0) as IdMesEjecucion,[SemanaEjecucion]," + "\n" +
                "CONVERT(VARCHAR(MAX), [Encabezado]) as Encabezado,CONVERT(VARCHAR(MAX), [Metodologia]) as [Metodologia], " + "\n" +
                "CONVERT(VARCHAR(MAX), [Conclusion]) as Conclusion, CONVERT(VARCHAR(MAX), [Observaciones]) as Observaciones, " + "\n" +
                "CONVERT(VARCHAR(MAX), [TituloInforme]) as TituloInforme,CONVERT(VARCHAR(MAX), [ReferenciaInforme]) as ReferenciaInforme," + "\n" +
                "[Auditoria].[Auditoria].[IdAuditoria]" + "\n" +
                 "       FROM[Auditoria].[Auditoria]" + "\n" +
                 "       INNER JOIN[Auditoria].[Estandar] on[Auditoria].[Estandar].IdEstandar = [Auditoria].[Auditoria].IdEstandar" + "\n" +
                "INNER JOIN[Listas].[Usuarios] ON[Auditoria].IdUsuario = [Usuarios].IdUsuario" + "\n" +
                "INNER JOIN[Parametrizacion].[JerarquiaOrganizacional] ON[Auditoria].IdDependencia = [JerarquiaOrganizacional].IdHijo" + "\n" +
                "INNER JOIN Auditoria.AuditoriaProceso ON[Auditoria].[IdAuditoria] = AuditoriaProceso.IdAuditoria" + "\n" +
                "INNER JOIN Procesos.Proceso on Procesos.Proceso.IdProceso = Auditoria.IdProceso" + "\n" +
                " WHERE [Auditoria].IdPlaneacion = {0} and AuditoriaProceso.IdTipoProceso = 2 and [Auditoria].[IdArea] = {2} {1}" + "\n" +
                " UNION " + "\n" +
                " SELECT[Estandar].[IdEstandar],[Tema], [Estandar].[Nombre], [IdPlaneacion], [Tipo],ISNULL([IdDependencia],0) AS IdDependencia," + "\n" +
                "ISNULL([Auditoria].[IdProceso], 0) as IdProceso, [NombreHijo] as NombreDP , [Auditoria].[IdUsuario], [Usuarios].[Usuario], " + "\n" +
                "CONVERT(VARCHAR(10),[Auditoria].[FechaRegistro],120) AS FechaRegistro, [Auditoria].[IdEmpresa],  " + "\n" +
                "CONVERT(VARCHAR(MAX), [Recursos]) AS Recursos, CONVERT(VARCHAR(MAX), [Auditoria].[Objetivo]) AS Objetivo," + "\n" +
                "CONVERT(VARCHAR(MAX), [Alcance]) AS Alcance, IsNull([NivelImportancia],0) AS NivelImportancia," + "\n" +
                "IsNull([IdDetalleTipo_TipoNaturaleza],0) AS IdDetalleTipo_TipoNaturaleza, CONVERT(VARCHAR(10),[FechaInicio], 120) AS FechaInicio," + "\n" +
                "CONVERT(VARCHAR(10),[FechaCierre], 120) AS FechaCierre, ISNULL([IdMesEjecucion],0) as IdMesEjecucion,[SemanaEjecucion]," + "\n" +
                "CONVERT(VARCHAR(MAX), [Encabezado]) as Encabezado,CONVERT(VARCHAR(MAX), [Metodologia]) as [Metodologia], " + "\n" +
                "CONVERT(VARCHAR(MAX), [Conclusion]) as Conclusion, CONVERT(VARCHAR(MAX), [Observaciones]) as Observaciones, " + "\n" +
                "CONVERT(VARCHAR(MAX), [TituloInforme]) as TituloInforme,CONVERT(VARCHAR(MAX), [ReferenciaInforme]) as ReferenciaInforme," + "\n" +
                "[Auditoria].[Auditoria].[IdAuditoria]" + "\n" +
                 "       FROM[Auditoria].[Auditoria]" + "\n" +
                 "       INNER JOIN[Auditoria].[Estandar] on[Auditoria].[Estandar].IdEstandar = [Auditoria].[Auditoria].IdEstandar" + "\n" +
                "INNER JOIN[Listas].[Usuarios] ON[Auditoria].IdUsuario = [Usuarios].IdUsuario" + "\n" +
                "INNER JOIN[Parametrizacion].[JerarquiaOrganizacional] ON[Auditoria].IdDependencia = [JerarquiaOrganizacional].IdHijo" + "\n" +
                "INNER JOIN Auditoria.AuditoriaProceso ON[Auditoria].[IdAuditoria] = AuditoriaProceso.IdAuditoria" + "\n" +
                "INNER JOIN Procesos.Macroproceso on Procesos.Macroproceso.IdMacroProceso = Auditoria.IdProceso" + "\n" +
                " WHERE " + "\n" +
                "[Auditoria].IdPlaneacion = {0}" + "\n" +
                "and AuditoriaProceso.IdTipoProceso = 1 and[Auditoria].[IdArea] = {2} {1}"
                , customerId, strCondicion, Session["IdAreaUser"].ToString());
                gvOrders.DataSource = GetData(strConsulta);
                /*gvOrders.DataSource = GetData(string.Format("SELECT [IdAuditoria], [Tema], [Encabezado], [Metodologia], [Conclusion], [Observaciones],IdPlaneacion " +
                " FROM [Auditoria].[Auditoria] " +
                " WHERE ([IdPlaneacion] = {0} AND ([Estado] = 'EJECUCIÓN'))", customerId));*/

                gvOrders.DataBind();
            }
        }
        private static DataTable GetData(string query)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["SarlaftConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataSet ds = new System.Data.DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

            int index = gvr.RowIndex;
            //int index = row.RowIndex;
            int IdPlaneacion = Convert.ToInt32(e.CommandArgument);
            InfoGridAuditorias = GetData(string.Format("SELECT [IdAuditoria], [Tema], [Encabezado], [Metodologia], [Conclusion], [Observaciones] " +
                " FROM [Auditoria].[Auditoria] " +
                " WHERE ([IdPlaneacion] = {0} AND ([Estado] = 'INFORME'))", IdPlaneacion));
            txtCodAuditoriaSel.Text = InfoGridAuditorias.Rows[index]["IdAuditoria"].ToString().Trim();
            txtNomAuditoriaSel.Text = InfoGridAuditorias.Rows[index]["Tema"].ToString().Trim();
            //txtMetodologiaGen.Text = InfoGridAuditorias.Rows[index]["Metodologia"].ToString().Trim();
            /*txtConclusionGen.Text = gvOrders.SelectedDataKey[1].ToString().Trim();
            tbxObsGen.Text = gvOrders.SelectedDataKey[2].ToString().Trim();*/
            //txtEncabezado.Text = InfoGridAuditorias.Rows[index]["Encabezado"].ToString().Trim();

            if (filaGridRec.Visible == true)
                filaGridRec.Visible = false;

            filaCierreRec.Visible = true;
            filaLogEstados.Visible = false;
            filaDetalleRecomendacion.Visible = false;
            txtCodObjetivoSel.Text = "";
            txtNomObjetivoSel.Text = "";
            txtCodEnfoqueSel.Text = "";
            txtCodLiteralSel.Text = "";
            txtNomEnfoqueSel.Text = "";
            txtNomLiteralSel.Text = "";
            txtNomHallazgoSel.Text = "";
            txtCodHallazgoSel.Text = "";
            txtNomEnfoqueSel.Height = 18;
            txtNomEnfoqueSel.Width = 402;
            txtNomLiteralSel.Height = 18;
            txtNomLiteralSel.Width = 402;
            txtNomHallazgoSel.Height = 18;
            txtNomHallazgoSel.Width = 402;

            /*filaMetodologia.Visible = false;
            filaConclusion.Visible = false;
            filaObs.Visible = false;*/
            popupAuditoria.Cancel();
            /*TabContainer1.ActiveTabIndex = 0;
            TabContainer1.Tabs[1].Enabled = false;
            TabContainer1.Tabs[2].Enabled = false;
            filaGridTareasP.Visible = false;
            filaDetalleTareasP.Visible = false;
            filaAcciones.Visible = true;
            btnTareasPEndientes.Visible = false;*/
            trAuditorias.Visible = false;

            //if (filaTabGestion.Visible == true) filaTabGestion.Visible = false;
        }
    }
}