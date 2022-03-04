using ListasSarlaft.Classes;
using Microsoft.Security.Application;
using System;
using System.Data;
using System.Web.UI;

namespace ListasSarlaft.UserControls.Sitio
{
    public partial class NuevoLogin : System.Web.UI.UserControl
    {
        private cCuenta cCuenta = new cCuenta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserName.Focus();
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            #region Variables
            string strMensaje = string.Empty;
            inicializarValores();
            DataTable dtInformacion = new DataTable();
            int intDiasCaducaContrasena = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DiasCaducaContrasena"].ToString().Trim());
            #endregion

            try
            {
                dtInformacion = cCuenta.autenticarUsuario(Sanitizer.GetSafeHtmlFragment(UserName.Text.ToLower().Trim()), Password.Text.Trim());

                if (dtInformacion.Rows.Count > 0)
                {
                    #region Hay informacion
                    if (!cCuenta.mtdValidarCaducaContrasena(dtInformacion.Rows[0]["FechaUltActualPassword"], intDiasCaducaContrasena))
                    {
                        #region Cambio Contraseña
                        Session["Usuario"] = dtInformacion.Rows[0]["Usuario"].ToString().Trim();
                        Session["NombreUsuario"] = dtInformacion.Rows[0]["NombreUsuario"].ToString().Trim();
                        Session["IdMacroProcesoUsuario"] = dtInformacion.Rows[0]["IdMacroProcesoU"].ToString().Trim();
                        Session["IdProcesoUsuario"] = dtInformacion.Rows[0]["IdProcesoU"].ToString().Trim();
                        Session["VerTodosProcesos"] = dtInformacion.Rows[0]["VerTodosProcesos"].ToString().Trim();
                        Session["IdUsuario"] = dtInformacion.Rows[0]["IdUsuario"].ToString().Trim();

                        cCuenta.mtdAuthCambioContrasena(dtInformacion.Rows[0]["NombreRol"].ToString().Trim(),
                            Convert.ToInt32(dtInformacion.Rows[0]["IdUsuario"]), dtInformacion.Rows[0]["NombreUsuario"].ToString().Trim(),
                            dtInformacion.Rows[0]["Usuario"].ToString().Trim(), dtInformacion.Rows[0]["IdRol"].ToString().Trim(),
                            dtInformacion.Rows[0]["IdJerarquia"].ToString().Trim());

                        Response.Redirect("~/Formularios/AdminUsers/CambioContrasena.aspx", false);
                        #endregion Cambio Contraseña
                    }
                    else
                    {
                        if (dtInformacion.Columns.Contains("Usuario") && dtInformacion.Columns.Contains("NombreUsuario"))
                        {
                            Session["Usuario"] = dtInformacion.Rows[0]["Usuario"].ToString().Trim();
                            Session["NombreUsuario"] = dtInformacion.Rows[0]["NombreUsuario"].ToString().Trim();
                            Session["IdMacroProcesoUsuario"] = dtInformacion.Rows[0]["IdMacroProcesoU"].ToString().Trim();
                            Session["IdProcesoUsuario"] = dtInformacion.Rows[0]["IdProcesoU"].ToString().Trim();
                            Session["VerTodosProcesos"] = dtInformacion.Rows[0]["VerTodosProcesos"].ToString().Trim();
                            Session["IdJerarquia"] = dtInformacion.Rows[0]["IdJerarquia"].ToString().Trim();
                            Session["AreaUser"] = dtInformacion.Rows[0]["NombreArea"].ToString().Trim();
                            Session["IdAreaUser"] = dtInformacion.Rows[0]["IdArea"].ToString().Trim();
                        }
                        Session["IdUsuario"] = dtInformacion.Rows[0]["IdUsuario"].ToString().Trim();

                        cCuenta.isAuthenticated(dtInformacion.Rows[0]["NombreRol"].ToString().Trim(), Convert.ToInt64(dtInformacion.Rows[0]["IdUsuario"]),
                            dtInformacion.Rows[0]["NombreUsuario"].ToString().Trim(), dtInformacion.Rows[0]["Usuario"].ToString().Trim(),
                            dtInformacion.Rows[0]["IdRol"].ToString().Trim(), dtInformacion.Rows[0]["IdJerarquia"].ToString().Trim());

                        if (Password.Text.Trim() == "Sherlock+") //Vieja contraseña sherlock2012
                        {
                            Response.Redirect("~/Formularios/AdminUsers/CambioContrasena.aspx", false);
                        }
                        else
                        {
                            cCuenta.Login_SN(dtInformacion.Rows[0]["IdUsuario"].ToString().Trim(), 1);
                            Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx", false);
                        }
                    }
                    #endregion Hay informacion
                }
                else
                {
                    dtInformacion = cCuenta.mtdUsuarioBloqueado(Sanitizer.GetSafeHtmlFragment(UserName.Text.ToLower().Trim()), Sanitizer.GetSafeHtmlFragment(Password.Text.Trim()));
                    if (dtInformacion.Rows.Count > 0)
                    {
                        if (dtInformacion.Rows[0]["Bloqueado"].ToString() == "True")
                        {
                            lblMensaje.Visible = true;
                            lblMensaje.Text = string.Empty;
                            lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| está bloqueado";
                        }
                        else
                        {
                            #region NO Hay informacion
                            lblMensaje.Visible = true;
                            lblMensaje.Text = string.Empty;
                            dtInformacion = cCuenta.MensajeLogin(Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()));
                            if (dtInformacion.Rows.Count == 0)
                            {
                                lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| no está registrado en la aplicación Sherlock";
                            }
                            else
                            {
                                if (dtInformacion.Rows[0]["FechaUltActualPassword"] == DBNull.Value)
                                {
                                    Session["Usuario"] = dtInformacion.Rows[0]["Usuario"].ToString().Trim();
                                    Session["NombreUsuario"] = dtInformacion.Rows[0]["NombreUsuario"].ToString().Trim();
                                    Session["IdMacroProcesoUsuario"] = dtInformacion.Rows[0]["IdMacroProcesoU"].ToString().Trim();
                                    Session["IdProcesoUsuario"] = dtInformacion.Rows[0]["IdProcesoU"].ToString().Trim();
                                    Session["VerTodosProcesos"] = dtInformacion.Rows[0]["VerTodosProcesos"].ToString().Trim();
                                    Session["IdUsuario"] = dtInformacion.Rows[0]["IdUsuario"].ToString().Trim();

                                    cCuenta.isAuthenticated(dtInformacion.Rows[0]["NombreRol"].ToString().Trim(), Convert.ToInt64(dtInformacion.Rows[0]["IdUsuario"]),
                                        dtInformacion.Rows[0]["NombreUsuario"].ToString().Trim(), dtInformacion.Rows[0]["Usuario"].ToString().Trim(),
                                        dtInformacion.Rows[0]["IdRol"].ToString().Trim(), dtInformacion.Rows[0]["IdJerarquia"].ToString().Trim());

                                    Response.Redirect("~/Formularios/AdminUsers/CambioContrasena.aspx", false);
                                }
                                else if (!cCuenta.mtdCompararContrasenasEncriptadas(Password.Text.Trim(), dtInformacion.Rows[0]["Contrasena"].ToString().Trim()))
                                {
                                    lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| no tiene acceso a Sherlock";
                                }
                                else if (dtInformacion.Rows[0]["Bloqueado"].ToString().Trim() == "True")
                                {
                                    lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| está bloqueado";
                                }
                                else if (dtInformacion.Rows[0]["login"].ToString().Trim() == "True")
                                {
                                    lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| ya tiene una sesión abierta";
                                }
                                else if (!cCuenta.mtdValidarContrasena(Sanitizer.GetSafeHtmlFragment(Password.Text.Trim()), ref strMensaje))
                                {
                                    lblMensaje.Text = strMensaje;
                                }
                                else if (dtInformacion.Rows[0]["IdArea"].ToString() == "0" || dtInformacion.Rows[0]["IdArea"].ToString() == "-1")
                                {
                                    lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| no cuenta con un area asignada";
                                }
                            }
                            #endregion Hay informacion
                        }
                    }
                    else
                    {
                        #region NO Hay informacion
                        lblMensaje.Visible = true;
                        lblMensaje.Text = string.Empty;
                        dtInformacion = cCuenta.MensajeLogin(Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()));
                        if (dtInformacion.Rows.Count == 0)
                        {
                            lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| no está registrado en la aplicación Sherlock";
                        }
                        else
                        {
                            if (dtInformacion.Rows[0]["FechaUltActualPassword"] == DBNull.Value)
                            {
                                Session["Usuario"] = dtInformacion.Rows[0]["Usuario"].ToString().Trim();
                                Session["NombreUsuario"] = dtInformacion.Rows[0]["NombreUsuario"].ToString().Trim();
                                Session["IdMacroProcesoUsuario"] = dtInformacion.Rows[0]["IdMacroProcesoU"].ToString().Trim();
                                Session["IdProcesoUsuario"] = dtInformacion.Rows[0]["IdProcesoU"].ToString().Trim();
                                Session["VerTodosProcesos"] = dtInformacion.Rows[0]["VerTodosProcesos"].ToString().Trim();
                                Session["IdUsuario"] = dtInformacion.Rows[0]["IdUsuario"].ToString().Trim();

                                cCuenta.isAuthenticated(dtInformacion.Rows[0]["NombreRol"].ToString().Trim(), Convert.ToInt64(dtInformacion.Rows[0]["IdUsuario"]),
                                    dtInformacion.Rows[0]["NombreUsuario"].ToString().Trim(), dtInformacion.Rows[0]["Usuario"].ToString().Trim(),
                                    dtInformacion.Rows[0]["IdRol"].ToString().Trim(), dtInformacion.Rows[0]["IdJerarquia"].ToString().Trim());

                                Response.Redirect("~/Formularios/AdminUsers/CambioContrasena.aspx", false);
                            }
                            else if (!cCuenta.mtdCompararContrasenasEncriptadas(Password.Text.Trim(), dtInformacion.Rows[0]["Contrasena"].ToString().Trim()))
                            {
                                string a = dtInformacion.Rows[0]["Contrasena"].ToString().Trim();
                                //lblMensaje.Text = "El usuario |" + Login1.UserName + "| no tiene acceso a Sherlock";
                                lblMensaje.Text = "La contraseña no corresponde";
                            }
                            else if (dtInformacion.Rows[0]["Bloqueado"].ToString().Trim() == "True")
                            {
                                lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| está bloqueado";
                            }
                            else if (dtInformacion.Rows[0]["login"].ToString().Trim() == "True")
                            {
                                lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| ya tiene una sesión abierta";
                            }
                            else if (!cCuenta.mtdValidarContrasena(Sanitizer.GetSafeHtmlFragment(Password.Text.Trim()), ref strMensaje))
                            {
                                lblMensaje.Text = strMensaje;
                            }
                            else if (dtInformacion.Rows[0]["IdArea"].ToString() == "0")
                            {
                                lblMensaje.Text = "El usuario |" + Sanitizer.GetSafeHtmlFragment(UserName.Text.Trim()) + "| no cuenta con un area asignada";
                            }
                        }
                        #endregion Hay informacion
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error de conexión. Revise el tag connectionStrings o contacte al administrador." + ex.Message;
            }
        }

        private void inicializarValores()
        {
            cCuenta.notAuthenticated();
        }

        private void Mensaje(String Mensaje)
        {
            lblMsgBox.Text = Mensaje;
            mpeMsgBox.Show();
        }

    }
}