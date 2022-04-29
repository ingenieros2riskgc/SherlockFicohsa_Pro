<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NuevoLogin.ascx.cs" Inherits="ListasSarlaft.UserControls.Sitio.NuevoLogin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .gridViewHeader a:link
    {
        text-decoration: none;
    }
    .FondoAplicacion
    {
        background-color: white;
        filter: alpha(opacity=80);
        opacity: 0.8;
    }
    .wrap-login100 {
        width: 400px;
        background: #f0eef0;
        border-radius: 10px;
        overflow: hidden;
        box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
        -moz-box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
        -webkit-box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
        -o-box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
        -ms-box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
    }
	::-webkit-input-placeholder { /* Safari, Chrome and Opera */
  color: black;
}
</style>

	<!-- begin #page-loader -->
	<div id="page-loader" class="fade show"><span class="spinner"></span></div>
	<!-- end #page-loader -->
	<!-- begin #page-container -->
	<div id="page-container" class="fade">
		<!-- begin login -->
		<div class="login login-with-news-feed">
			<!-- begin news-feed -->
			<div class="news-feed">
				<div class="news-image" style="background-image: url(../../Imagenes/Aplicacion/SherlockBanner-1.jpg)"></div>
				<div class="news-caption">
					<%--<h4 class="caption-title"><b>Sherlock</b></h4>--%>
					<p>
						<label style="font-family: Calibri; font-size: small; color: white">Copyright © <%=DateTime.Now.Year.ToString() %> Risk Consulting Colombia | Sherlock Versión 5 | Se recomienda utilizar versiones iguales o superiores a: Internet Explorer 7.0, Firefox 3.0, Chrome 12.0, Safari 5.0 en una resolución de 1024 x 768 o superior</label>
                                .
                                <asp:Label ID="lblPiepagina" runat="server" Text=""
                                    Font-Names="Calibri" Font-Size="Small" ForeColor="DarkBlue"></asp:Label>
					</p>
				</div>
			</div>
			<!-- end news-feed -->
			<!-- begin right-content -->
			<div class="right-content">
				
                    <!-- begin login-header -->
				<div class="login-header">
					<div align="center">
						<div class="row">
							<div class="col-lg-2"></div>
							<div class="col-lg-10">
								<asp:Image ID="Image1" runat="server" ImageUrl="../../Imagenes/Logos/LogoFicohsa.png" Width="150px" />
							</div>
							
						</div>
						
					</div>
					
				</div>
				<!-- end login-header -->
				<!-- begin login-content -->
				<div class="login-content">
					<div class="wrap-login100">
					<form action="index.html" method="GET" class="margin-bottom-0">
						<div class="row">
							<div class="col-md-12">
						<div class="col-md-11">
							<div class="col-md-1"></div>
							<%--<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" ForeColor="#606060"
                                                    Font-Names="Roboto Ligth" Font-Size="16pt">Usuario: </asp:Label>--%>
						</div>
                        <div class="col-md-11">
							<div class="col-md-1"></div>
							<br />
                            <asp:TextBox ID="UserName" runat="server" MaxLength="20" required
                                placeholder="USUARIO"
								BackColor="#888888" ForeColor="Black" BorderColor="Gray"
                                                    Font-Names="Roboto-Regular" Font-Size="Medium" CssClass="form-control form-control-lg"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio."
                                                    ValidationGroup="ctl00$Login1"  ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="UserNameExpVal" runat="server" ControlToValidate="UserName"
                                                    ValidationGroup="ctl00$Login1"  ValidationExpression="^[0-9A-Za.-zÑñ]*$" ForeColor="Red">*</asp:RegularExpressionValidator>
                                --%>
                            </div>
								</div>
							<br />
							<div class="col-md-12">
								<div class="col-md-1"></div>
						<div class="col-md-11">
							<%--<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" ForeColor="#606060"
                                                    Font-Names="Roboto Ligth" Font-Size="16pt">Contraseña: </asp:Label>--%>
						</div>
                        <div class="col-md-11">
							<div class="col-md-1"></div>
							<br />
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"  MaxLength="40" required
								placeholder="CONTRASEÑA"
								BackColor="#888888" ForeColor="Black" BorderColor="Gray"
                                                     Font-Names="Roboto-Regular" Font-Size="Medium" CssClass="form-control form-control-lg"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                                                    ValidationGroup="ctl00$Login1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                --%>
                            </div>
						</div>
							
							<div class="col-md-12">
								<br />
							<br />
								<div class="col-md-1"></div>
						<div class="col-md-11">
							<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Ingresar" ForeColor="White" ValidationGroup="ctl00$Login1"
                                                    OnClick="LoginButton_Click" Font-Names="Roboto" Font-Size="Small" CssClass="btn btn-primary btn-block btn-lg" BackColor="#002649" />
						</div>
								</div>
							
							<div class="col-md-12">
								<br />
							<br />
								<%--<div class="col-md-2"></div>--%>
						<div class="col-md-12" align="center">
							<asp:Label ID="lblTextRC" runat="server" Text="Reestablecer Contraseña" ForeColor="Black"></asp:Label>
							<a href="../../Formularios/Sitio/ReestablecerContrasena.aspx" style="color:orange">Aqui</a>
							<asp:Label ID="lblMensaje" runat="server" Text="Label" ForeColor="Red" Font-Size="Small"
                                        Font-Names="Calibri" Visible="false"></asp:Label>
						</div>
								<%--<div class="col-md-2"></div>--%>
								</div>
							</div>
						<hr />
							
					</form>
				</div>
				<!-- end login-content -->
			</div>
				</div>
			<!-- end right-container -->
		</div>
		<!-- end login -->
<asp:ModalPopupExtender ID="mpeMsgBox" runat="server" TargetControlID="btndummy"
    PopupControlID="pnlMsgBox" OkControlID="btnAceptar" BackgroundCssClass="FondoAplicacion"
    Enabled="True" DropShadow="true">
</asp:ModalPopupExtender>
<asp:Button ID="btndummy" runat="server" Text="Button" Style="display: none" />
<asp:Panel ID="pnlMsgBox" runat="server" Width="400px" Style="display: none;" BorderColor="#575757"
    BackColor="#D2D3D5" BorderStyle="Solid">
    <table width="100%">
        <tr class="topHandle" style="background-color: #D2D3D5">
            <td colspan="2" align="center" runat="server" id="tdCaption">
                &nbsp;
                <asp:Label ID="lblCaption" runat="server" Text="Atención" Font-Names="Calibri" Font-Size="Small"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px" valign="middle" align="center">
                <asp:Image ID="imgInfo" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
            </td>
            <td valign="middle" align="left">
                <asp:Label ID="lblMsgBox" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Button ID="btnAceptar" runat="server" Text="Ok" Font-Names="Calibri" Font-Size="Small" />
            </td>
        </tr>
    </table>
</asp:Panel>