using ListasSarlaft.Classes;
using Microsoft.Security.Application;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListasSarlaft.UserControls.Eventos
{
    public partial class Severidad : System.Web.UI.UserControl
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

                    ddlAnio.Items.Clear();
                    ddlAnio.Items.Add(item);
                    ddlAnio.DataBind();

                    ddlDescSeveridad.Items.Clear();
                    ddlDescSeveridad.Items.Add(item);
                    ddlDescSeveridad.DataBind();
                }
            }
        }

        #region GridView

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.SelectedRow.RowType == DataControlRowType.DataRow)
                {
                    txtId.Enabled = false;

                    // Carga los datos en la respectiva caja de texto
                    txtId.Text = GridView1.SelectedRow.Cells[0].Text.Trim();
                    txtSvDesdeRO01_25.Text = GridView1.SelectedRow.Cells[5].Text.Trim();
                    txtSvHastaRO01_26.Text = GridView1.SelectedRow.Cells[6].Text.Trim();
                    txtUsuario.Text = GridView1.SelectedDataKey[0].ToString().Trim();
                    txtFecha.Text = GridView1.SelectedRow.Cells[7].Text.Trim();
                    ddlAnio.SelectedValue = GridView1.SelectedDataKey[1].ToString().Trim();
                    ddlDescSeveridad.SelectedValue = GridView1.SelectedDataKey[2].ToString().Trim();

                    filaGrid.Visible = false;
                    filaDetalle.Visible = true;
                    btnImgInsertar.Visible = false;
                    btnImgActualizar.Visible = true;

                }
            }
            catch (Exception except)
            {
                omb.ShowMessage("Error en la eliminación de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Eliminar":
                    int nroPag, tamPag;
                    // Convierte el indice de la fila del GridView almacenado en la propiedad CommandArgument a un tipo entero
                    int index = Convert.ToInt32((e.CommandArgument).ToString());

                    nroPag = GridView1.PageIndex;  // Obtiene el Numero de Pagina en la que se encuentra el GridView
                    tamPag = GridView1.PageSize; // Obtiene el Tamano de cada Pagina del GridView

                    index = (index - tamPag * nroPag); // Calcula el Numero de Fila del GridView dentro de la pagina actual

                    // Recupera la fila que contiene el boton al que se le hizo click por el usuario de la coleccion Rows
                    GridViewRow row = GridView1.Rows[index];

                    // Obtiene el Id del registro a Eliminar
                    txtId.Text = row.Cells[0].Text.Trim();
                    break;
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
                txtSvDesdeRO01_25.Text = "";
                txtSvHastaRO01_26.Text = "";
                ddlAnio.SelectedIndex = 0;
                ddlDescSeveridad.SelectedIndex = 0;
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
                SqlDataSource1.DeleteParameters["IdSeveridad"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());
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
                    string text = txtSvHastaRO01_26.Text.Trim().Equals("") ? "" : Sanitizer.GetSafeHtmlFragment(txtSvHastaRO01_26.Text.Trim());
                    SqlDataSource1.UpdateParameters["IdAnio"].DefaultValue = ddlAnio.SelectedValue;
                    SqlDataSource1.UpdateParameters["IdDescSeveridad"].DefaultValue = ddlDescSeveridad.SelectedValue;
                    SqlDataSource1.UpdateParameters["SvDesdeRO01_25"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtSvDesdeRO01_25.Text.Trim());
                    SqlDataSource1.UpdateParameters["SvHastaRO01_26"].DefaultValue = text;
                    SqlDataSource1.UpdateParameters["IdSeveridad"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());

                    var result = SqlDataSource1.Update();
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
                SqlDataSource1.InsertParameters["IdAnio"].DefaultValue = ddlAnio.SelectedValue;
                SqlDataSource1.InsertParameters["IdDescSeveridad"].DefaultValue = ddlDescSeveridad.SelectedValue;
                SqlDataSource1.InsertParameters["SvDesdeRO01_25"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtSvDesdeRO01_25.Text.Trim());
                SqlDataSource1.InsertParameters["SvDesdeRO01_26"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtSvHastaRO01_26.Text.Trim());

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
        protected void ddlAnio_DataBound(object sender, EventArgs e)
        {
            ddlAnio.Items.Insert(0, new ListItem("", "0"));
        }

        protected void ddlDescSeveridad_DataBound(object sender, EventArgs e)
        {
            ddlDescSeveridad.Items.Insert(0, new ListItem("", "0"));
        }
        #endregion

        protected Boolean VerificarCampos()
        {
            bool err = true;

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