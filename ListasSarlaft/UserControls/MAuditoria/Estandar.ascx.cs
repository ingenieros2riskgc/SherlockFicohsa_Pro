﻿using ListasSarlaft.Classes;
using Microsoft.Security.Application;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListasSarlaft.UserControls.MAuditoria
{
    public partial class Estandar : System.Web.UI.UserControl
    {
        string IdFormulario = "3001";
        cCuenta cCuenta = new cCuenta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cCuenta.permisosConsulta(IdFormulario) == "False")
                Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
            else
            {
                if (!Page.IsPostBack)
                {
                    //Limpia el DropDownList Region y agrega el item vacio
                    ListItem item = new ListItem();
                    item.Text = "";
                    item.Value = "0";

                    ddlTipoEstandar.Items.Clear();
                    ddlTipoEstandar.Items.Add(item);
                    ddlTipoEstandar.DataBind();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow.RowType == DataControlRowType.DataRow)
            {
                txtId.Enabled = false;

                // Carga los datos en la respectiva caja de texto
                txtId.Text = GridView1.SelectedRow.Cells[0].Text.Trim();
                txtNombre.Text = GridView1.SelectedRow.Cells[5].Text.Trim();
                txtDescripcion.Text = GridView1.SelectedDataKey[2].ToString().Trim();
                txtUsuario.Text = GridView1.SelectedDataKey[0].ToString().Trim();
                txtFecha.Text = GridView1.SelectedRow.Cells[7].Text.Trim();
                ddlTipoEstandar.SelectedValue = GridView1.SelectedDataKey[1].ToString().Trim();

                filaGrid.Visible = false;
                filaDetalle.Visible = true;
                ddlTipoEstandar.Focus();
                btnImgInsertar.Visible = false;
                btnImgActualizar.Visible = true;
            }
        }

        protected void btnImgCancelar_Click(object sender, ImageClickEventArgs e)
        {
            filaGrid.Visible = true;
            filaDetalle.Visible = false;
        }

        protected void imgBtnInsertar_Click(object sender, ImageClickEventArgs e)
        {
            if (cCuenta.permisosAgregar(IdFormulario) == "False")
            {
                //omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
                lblMsgBox.Text = "No tiene los permisos suficientes para llevar a cabo esta acción.";
                mpeMsgBox.Show();
            }
            else
            {
                txtId.Text = "";
                txtId.Enabled = false;
                ddlTipoEstandar.SelectedValue = null;
                ddlTipoEstandar.Focus();
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtUsuario.Text = Session["loginUsuario"].ToString().Trim(); //Aca va el codigo de usuario logueado
                txtFecha.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                btnImgInsertar.Visible = true;
                btnImgActualizar.Visible = false;
                filaDetalle.Visible = true;
                filaGrid.Visible = false;
            }
        }

        protected void btnImgEliminar_Click(object sender, ImageClickEventArgs e)
        {
            if (cCuenta.permisosBorrar(IdFormulario) == "False")
            {
                //omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
                lblMsgBox.Text = "No tiene los permisos suficientes para llevar a cabo esta acción.";
                mpeMsgBox.Show();
            }
            else
            {
                lblMsgBox.Text = "Desea eliminar la información de la Base de Datos?";
                mpeMsgBox.Show();
            }
        }

        protected void btnImgokEliminar_Click(object sender, EventArgs e)
        {
            mpeMsgBox.Hide();

            try
            {
                SqlDataSource1.DeleteParameters["IdEstandar"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());
                SqlDataSource1.Delete();
                omb.ShowMessage("La información se eliminó con éxito en la Base de Datos.", 3, "Atención");
            }
            catch (Exception except)
            {
                omb.ShowMessage("Error en la eliminación de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
            }
        }

        protected void btnImgActualizar_Click(object sender, ImageClickEventArgs e)
        {
            if (cCuenta.permisosActualizar(IdFormulario) == "False")
            {
                //omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
                lblMsgBox.Text = "No tiene los permisos suficientes para llevar a cabo esta acción.";
                mpeMsgBox.Show();
            }
            else
            {
                if (VerificarCampos())
                {
                    try
                    {
                        SqlDataSource1.UpdateParameters["IdEstandar"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());
                        SqlDataSource1.UpdateParameters["IdTipoEstandar"].DefaultValue = ddlTipoEstandar.SelectedValue;
                        SqlDataSource1.UpdateParameters["Nombre"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtNombre.Text.Trim());
                        SqlDataSource1.UpdateParameters["Descripcion"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtDescripcion.Text);
                        SqlDataSource1.Update();
                        filaDetalle.Visible = false;
                        filaGrid.Visible = true;
                        omb.ShowMessage("La información se actualizó con éxito en la Base de Datos.", 3, "Atención");
                    }
                    catch (Exception except)
                    {
                        omb.ShowMessage("Error en la actualización de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
                    }
                }
            }
        }

        protected void btnImgInsertar_Click(object sender, ImageClickEventArgs e)
        {
            if (VerificarCampos())
            {
                //Inserta el maestro del nodo hijo
                try
                {
                    SqlDataSource1.InsertParameters["Nombre"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtNombre.Text.Trim());
                    SqlDataSource1.InsertParameters["Descripcion"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtDescripcion.Text);
                    SqlDataSource1.InsertParameters["IdTipoEstandar"].DefaultValue = ddlTipoEstandar.SelectedValue;
                    SqlDataSource1.InsertParameters["IdUsuario"].DefaultValue = Session["idUsuario"].ToString().Trim(); //Aca va el id del Usuario de la BD
                    SqlDataSource1.InsertParameters["FechaRegistro"].DefaultValue = System.DateTime.Now.ToString("yyyy-MM-dd");
                    SqlDataSource1.Insert();
                    omb.ShowMessage("La información se insertó con éxito en la Base de Datos.", 3, "Atención");
                    filaDetalle.Visible = false;
                    filaGrid.Visible = true;
                }
                catch (Exception except)
                {
                    // Handle the Exception.
                    omb.ShowMessage("Error en la inserción de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int nroPag, tamPag;

            if (e.CommandName == "Eliminar")
            {
                // Convierte el indice de la fila del GridView almacenado en la propiedad CommandArgument a un tipo entero
                int index = Convert.ToInt32((e.CommandArgument).ToString());
                nroPag = GridView1.PageIndex;  // Obtiene el Numero de Pagina en la que se encuentra el GridView
                tamPag = GridView1.PageSize; // Obtiene el Tamano de cada Pagina del GridView

                index = (index - tamPag * nroPag); // Calcula el Numero de Fila del GridView dentro de la pagina actual

                // Recupera la fila que contiene el boton al que se le hizo click por el usuario de la coleccion Rows
                GridViewRow row = GridView1.Rows[index];

                // Obtiene el Id del registro a Eliminar
                txtId.Text = row.Cells[0].Text.Trim();
            }
        }

        protected Boolean VerificarCampos()
        {
            bool err = true;

            if (ddlTipoEstandar.SelectedValue == "0")
            {
                err = false;
                omb.ShowMessage("Debe seleccionar el Tipo de Estándar.", 2, "Atención");
                ddlTipoEstandar.Focus();
            }
            else if (ValidarCadenaVacia(Sanitizer.GetSafeHtmlFragment(txtNombre.Text.Trim())))
            {
                err = false;
                omb.ShowMessage("Debe ingresar el Nombre.", 2, "Atención");
                txtNombre.Focus();
            }
            else if (ValidarCadenaVacia(Sanitizer.GetSafeHtmlFragment(txtDescripcion.Text)))
            {
                err = false;
                omb.ShowMessage("Debe ingresar la Descripción.", 2, "Atención");
                txtDescripcion.Focus();
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
    }
}