using System;
using System.Web.UI;

namespace ListasSarlaft.UserControls
{
    public partial class Imagen : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Image1.ImageUrl = "../Archivos/ImagenesROI/" + Request.QueryString["url"].ToString().Trim();
            }
        }
    }
}