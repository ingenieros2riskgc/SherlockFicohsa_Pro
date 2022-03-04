using ListasSarlaft.Classes;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.UI;

namespace ListasSarlaft.UserControls
{
    public partial class FormClienteWillisFCC : System.Web.UI.UserControl
    {
        string IdFormulario = "6007";
        private cKnowClient cKnowClient = new cKnowClient();
        cCuenta cCuenta = new cCuenta();
        public string URL_FCC = System.Configuration.ConfigurationManager.AppSettings["URL_FCC"].ToString().Trim();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["IdUsuario"].ToString().Trim()))
            {
                Response.Redirect("~/Formularios/Sitio/Login.aspx", false);
            }
            else
            {
                if (cCuenta.permisosConsulta(IdFormulario) == "False")
                    Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
            }
        }

        private void Mensaje(String Mensaje)
        {
            lblMsgBox.Text = Mensaje;
            mpeMsgBox.Show();
        }

        protected void ImgBtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                IframeFCC.Visible = true;
                URL_FCC += "Home/Find?TypeDocument=" + DDLTipoIden.SelectedValue.ToString() + "&Document=" + TxtNumeroIden.Text.Trim() + "&TypePerson=" + DDLTipoPersona.SelectedValue.ToString() + "&UserWP=" + ConfigurationManager.AppSettings["UsuarioWillis"].ToString();
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(URL_FCC));
                webReq.Method = "GET";
                StreamReader reader = new StreamReader(webReq.GetResponse().GetResponseStream());
                IFrame_1.Attributes.Add("src", URL_FCC);
            }
            catch (Exception ex)
            {
                Mensaje("Error al cargar información.\nDescripción:" + ex.Message);
                //ShowMessage("Error al consultar. " + ex.Message +"", 2, "Atención");
            }
        }
        //public void ShowMessage(string Message, int TipoImagen, string Caption)
        //{

        //    switch (TipoImagen)
        //    {
        //        case 1: //Imagen de Error
        //            imgInfo.ImageUrl = "~/Imagenes/Icons/icontexto-webdev-cancel.png";
        //            break;
        //        case 2: //Imagen de Advertencia
        //            imgInfo.ImageUrl = "~/Imagenes/Icons/icontexto-webdev-alert.png";
        //            break;
        //        case 3: //Imagen de Ejecucion Satisfactoria
        //            imgInfo.ImageUrl = "~/Imagenes/Icons/icontexto-webdev-ok.png";
        //            break;
        //    }

        //    lblMsgBox.Text = Message;
        //    lblCaption.Text = Caption;
        //    tdCaption.Visible = true;
        //    mpeMsgBox.Show();
        //}
    }
}
