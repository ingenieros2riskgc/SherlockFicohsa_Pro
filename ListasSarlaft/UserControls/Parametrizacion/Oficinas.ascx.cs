using ListasSarlaft.Classes;
using Microsoft.Security.Application;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListasSarlaft.UserControls.Parametrizacion
{
    public partial class Oficinas : System.Web.UI.UserControl
    {
        cCuenta cCuenta = new cCuenta();
        String IdFormulario = "2005";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cCuenta.permisosConsulta(IdFormulario) == "False")
            {
                Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    ddlRegion.Items.Clear();
                    ddlRegion.DataBind();
                }
            }
        }


        protected void ddlRegion_DataBound(object sender, EventArgs e)
        {
            ddlRegion.Items.Insert(0, new ListItem("", "0")); // Inserta el Item con texto Vacio
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GridView1.SelectedRow.RowType == DataControlRowType.DataRow)
            {

                // Carga los datos en la respectiva caja de texto
                txtId.Text = GridView1.SelectedRow.Cells[0].Text.Trim();


                txtCiudad.Text = GridView1.SelectedRow.Cells[5].Text.Trim();
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#225;", "á")));
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#233;", "é")));
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#237;", "í")));
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#243;", "ó")));
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#250;", "ú")));

                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#193;", "Á")));
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#201;", "É")));
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#205;", "Í")));
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#211;", "Ó")));
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#218;", "Ú")));

                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#241;", "ñ")));
                txtCiudad.Text = Convert.ToString(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text.Trim().Replace("&#209;", "Ñ")));

                txtUsuario.Text = GridView1.SelectedDataKey[0].ToString().Trim();

                txtFecha.Text = GridView1.SelectedRow.Cells[11].Text.Trim();
                ddlRegion.SelectedValue = GridView1.SelectedDataKey[1].ToString().Trim();

                ddlPais.Items.Clear();
                ddlPais.DataBind();
                ddlPais.SelectedValue = GridView1.SelectedDataKey[2].ToString().Trim();

                ddlDepartamento.Items.Clear();
                ddlDepartamento.DataBind();
                ddlDepartamento.SelectedValue = GridView1.SelectedDataKey[3].ToString().Trim();

                ddlCiudad.Items.Clear();
                ddlCiudad.DataBind();
                ddlCiudad.SelectedValue = GridView1.SelectedDataKey[4].ToString().Trim();

                ddlRegion.Focus();
                btnImgInsertar.Visible = false;
                btnImgActualizar.Visible = true;
                filaGrid.Visible = false;
                filaDetalle.Visible = true;

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
                omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
            }
            else
            {
                ddlRegion.Focus();
                ddlRegion.SelectedValue = "0";
                ddlPais.Items.Clear();
                ddlDepartamento.Items.Clear();
                ddlCiudad.Items.Clear();
                txtCiudad.Text = "";
                txtUsuario.Text = Session["loginUsuario"].ToString().Trim();
                txtFecha.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
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
                omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
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
                SqlDataSource1.DeleteParameters["IdOficinaSucursal"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());
                SqlDataSource1.Delete();
                omb.ShowMessage("La información se eliminó con éxito en la Base de Datos.", 3, "Atención");
            }
            catch (Exception except)
            {
                omb.ShowMessage("Error en la eliminación de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
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

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPais.Items.Clear();
            ddlDepartamento.Items.Clear();
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDepartamento.Items.Clear();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCiudad.Items.Clear();
        }

        protected void ddlPais_DataBound(object sender, EventArgs e)
        {
            ddlPais.Items.Insert(0, new ListItem("", "0"));
        }

        protected void ddlDepartamento_DataBound(object sender, EventArgs e)
        {
            ddlDepartamento.Items.Insert(0, new ListItem("", "0"));
        }

        protected void ddlCiudad_DataBound(object sender, EventArgs e)
        {
            ddlCiudad.Items.Insert(0, new ListItem("", "0"));
        }

        protected void btnImgActualizar_Click(object sender, ImageClickEventArgs e)
        {
            if (cCuenta.permisosActualizar(IdFormulario) == "False")
            {
                omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
            }
            else
            {
                if (VerificarCampos())
                {
                    try
                    {
                        SqlDataSource1.UpdateParameters["IdCiudad"].DefaultValue = ddlCiudad.SelectedValue;
                        SqlDataSource1.UpdateParameters["IdOficinaSucursal"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());
                        SqlDataSource1.UpdateParameters["NombreOficinaSucursal"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtCiudad.Text);
                        SqlDataSource1.Update();
                        omb.ShowMessage("La información se actualizó con éxito en la Base de Datos.", 3, "Atención");
                        filaDetalle.Visible = false;
                        filaGrid.Visible = true;
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
                    SqlDataSource1.InsertParameters["IdCiudad"].DefaultValue = ddlCiudad.SelectedValue; ;
                    SqlDataSource1.InsertParameters["NombreOficinaSucursal"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtCiudad.Text);
                    SqlDataSource1.InsertParameters["IdUsuario"].DefaultValue = Session["idUsuario"].ToString().Trim(); //Aca va el id del Usuario de la BD
                    SqlDataSource1.InsertParameters["FechaRegistro"].DefaultValue = System.DateTime.Now.ToString().Trim();
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

        protected Boolean VerificarCampos()
        {
            bool err = true;

            if (ddlRegion.SelectedValue == "0")
            {
                err = false;
                omb.ShowMessage("Debe seleccionar la Región.", 2, "Atención");
                ddlRegion.Focus();
            }
            else if (ddlPais.SelectedValue == "0")
            {
                err = false;
                omb.ShowMessage("Debe seleccionar el País.", 2, "Atención");
                ddlPais.Focus();
            }
            else if (ddlDepartamento.SelectedValue == "0")
            {
                err = false;
                omb.ShowMessage("Debe seleccionar el Departamento.", 2, "Atención");
                ddlDepartamento.Focus();
            }
            else if (ValidarCadenaVacia(Sanitizer.GetSafeHtmlFragment(txtCiudad.Text)))
            {
                err = false;
                omb.ShowMessage("Debe ingresar la Ciudad.", 2, "Atención");
                txtCiudad.Focus();
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