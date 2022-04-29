<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="ListasSarlaft.UserControls.Login" %>
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
	background: #fff;
	border-radius: 10px;
	overflow: hidden;
	box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
	-moz-box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
	-webkit-box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
	-o-box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
	-ms-box-shadow: 0 3px 20px 0px rgba(0, 0, 0, 0.1);
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
					<h4 class="caption-title"><b>Sherlock</b></h4>
					<p>
						<label style="font-family:Calibri; font-size:small; color:white">Copyright © <%=DateTime.Now.Year.ToString() %> Risk Consulting Colombia | Sherlock Versión 5 | Se recomienda utilizar versiones iguales o superiores a: Internet Explorer 7.0, Firefox 3.0, Chrome 12.0, Safari 5.0 en una resolución de 1024 x 768 o superior</label>
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
					<div class="brand">
						
						<asp:Image ID="Image1" runat="server" ImageUrl="../../Imagenes/Logos/LogoSherlock.jpg" Width="250px" />
					</div>
					<div class="icon">
						<i class="fa fa-sign-in"></i>
					</div>
				</div>
				<!-- end login-header -->
				<!-- begin login-content -->
				<div class="login-content">
					<div class="wrap-login100">
					<form action="index.html" method="GET" class="margin-bottom-0">
						<div>
						<div class="form-group m-b-15">
							<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" ForeColor="#606060"
                                                    Font-Names="Roboto Ligth" Font-Size="16pt">Usuario: </asp:Label>
						</div>
                        <div class="form-group m-b-15">
                            <asp:TextBox ID="UserName" runat="server" MaxLength="20" required 
								BackColor="#606060" ForeColor="White"
                                                    Font-Names="Calibri" Font-Size="Medium" CssClass="form-control form-control-lg"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio."
                                                    ValidationGroup="ctl00$Login1"  ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="UserNameExpVal" runat="server" ControlToValidate="UserName"
                                                    ValidationGroup="ctl00$Login1"  ValidationExpression="^[0-9A-Za.-zÑñ]*$" ForeColor="Red">*</asp:RegularExpressionValidator>
                                --%>
                            </div>
						<div class="form-group m-b-15">
							<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" ForeColor="#606060"
                                                    Font-Names="Roboto Ligth" Font-Size="16pt">Contraseña: </asp:Label>
						</div>
                        <div class="form-group m-b-15">
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"  MaxLength="40" required
								BackColor="#606060" ForeColor="White"
                                                     Font-Names="Calibri" Font-Size="Medium" CssClass="form-control form-control-lg"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                                                    ValidationGroup="ctl00$Login1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                --%>
                            </div>
						
						<div class="login-buttons">
							<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Ingresar" ForeColor="White" ValidationGroup="ctl00$Login1"
                                                    OnClick="LoginButton_Click" Font-Names="Calibri" Font-Size="Small" CssClass="btn btn-primary btn-block btn-lg" BackColor="#00416f" />
						</div>
						<div class="m-t-20 m-b-40 p-b-40">
							<a href="../../Formularios/Sitio/ReestablecerContrasena.aspx">Reestablecer Contraseña</a>
							<asp:Label ID="lblMensaje" runat="server" Text="Label" ForeColor="Red" Font-Size="Small"
                                        Font-Names="Calibri" Visible="false"></asp:Label>
						</div>
							</div>
						<hr />
						<div class="form-group m-b-15"
                            
						</div>
							
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
                <asp:Label ID="lblMsgBox" runat="server" Font-Names="Calibri" ForeColor="Black" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Button ID="btnAceptar" runat="server" Text="Ok" Font-Names="Calibri" Font-Size="Small" />
            </td>
        </tr>
    </table>
</asp:Panel>