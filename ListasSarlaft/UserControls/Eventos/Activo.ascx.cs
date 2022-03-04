using ListasSarlaft.Classes;
using Microsoft.Security.Application;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListasSarlaft.UserControls.Eventos
{
    public partial class Activo : System.Web.UI.UserControl
    {
        string IdFormulario = "5010";
        cCuenta cCuenta = new cCuenta();

        protected void Page_Load(object sender, EventArgs e)
        {
            int? IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
            if (IdUsuario == 0)
            {
                IdUsuario = null;
            }
            if (string.IsNullOrEmpty(IdUsuario.ToString().Trim()))
            {
                Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
            }
            else
            {
                if (cCuenta.permisosConsulta(IdFormulario) == "NOPERMISO")
                {
                    Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?NP=2");
                }
                if (!Page.IsPostBack)
                {
                    //Limpia el DropDownList Region y agrega el item vacio
                    ListItem item = new ListItem();
                    item.Text = "";
                    item.Value = "-1";

                    ddlTipoActivo.Items.Clear();
                    ddlTipoActivo.Items.Add(item);
                    ddlTipoActivo.DataBind();
                }
            }
        }

        #region GridView
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow.RowType == DataControlRowType.DataRow)
            {
                txtId.Enabled = false;

                // Carga los datos en la respectiva caja de texto
                txtId.Text = GridView1.SelectedRow.Cells[0].Text.Trim();


                txtActivo.Text = System.Web.HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[2].Text.ToString().Trim());
                txtUsuario.Text = GridView1.SelectedDataKey[0].ToString().Trim();
                txtFecha.Text = GridView1.SelectedRow.Cells[6].Text.Trim();
                ddlTipoActivo.SelectedValue = GridView1.SelectedDataKey[1].ToString().Trim();

                filaGrid.Visible = false;
                filaDetalle.Visible = true;
                ddlTipoActivo.Focus();
                btnImgInsertar.Visible = false;
                btnImgActualizar.Visible = true;
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
        #endregion

        #region Button
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
                txtId.Text = "";
                txtId.Enabled = false;
                ddlTipoActivo.SelectedValue = null;
                ddlTipoActivo.Focus();
                txtActivo.Text = "";
                txtUsuario.Text = Session["loginUsuario"].ToString().Trim(); //Aca va el codigo de usuario logueado
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
                SqlDataSource1.DeleteParameters["IdActivoAfectado"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());
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
                omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
            }
            else
            {
                try
                {
                    string activo = EncodeExcludeSomeCaracters(txtActivo.Text.Trim());
                    SqlDataSource1.UpdateParameters["IdActivoAfectado"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());
                    SqlDataSource1.UpdateParameters["IdTipoActivo"].DefaultValue = ddlTipoActivo.SelectedValue;
                    SqlDataSource1.UpdateParameters["Activo"].DefaultValue = activo;
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

        protected void btnImgInsertar_Click(object sender, ImageClickEventArgs e)
        {
            //Inserta el maestro del nodo hijo
            try
            {
                string activo = EncodeExcludeSomeCaracters(txtActivo.Text.Trim());
                SqlDataSource1.InsertParameters["Activo"].DefaultValue = activo;
                SqlDataSource1.InsertParameters["IdTipoActivo"].DefaultValue = ddlTipoActivo.SelectedValue;
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
        #endregion

        #region DDLs
        protected void ddlTipoActivo_DataBound(object sender, EventArgs e)
        {
            ddlTipoActivo.Items.Insert(0, new ListItem("", "0")); // Inserta el Item con texto Vacio        
        }
        #endregion

        protected Boolean VerificarCampos()
        {
            bool err = true;

            if (ddlTipoActivo.SelectedValue == "-1")
            {
                err = false;
                omb.ShowMessage("Debe seleccionar la Linea de Negocio.", 2, "Atención");
                ddlTipoActivo.Focus();
            }
            else if (ValidarCadenaVacia(Sanitizer.GetSafeHtmlFragment(txtActivo.Text.Trim())))
            {
                err = false;
                omb.ShowMessage("Debe ingresar la SubLínea.", 2, "Atención");
                txtActivo.Focus();
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

        protected string EncodeExcludeSomeCaracters(string cadena)
        {
            string cadenaCodificada = Sanitizer.GetSafeHtmlFragment(cadena);
            cadenaCodificada = cadenaCodificada.Replace(Sanitizer.GetSafeHtmlFragment("+"), "+");
            cadenaCodificada = cadenaCodificada.Replace(Sanitizer.GetSafeHtmlFragment("&"), "&");

            return cadenaCodificada;
        }
    }
}