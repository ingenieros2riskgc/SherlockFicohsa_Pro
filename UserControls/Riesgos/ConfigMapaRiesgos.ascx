<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigMapaRiesgos.ascx.cs" Inherits="ListasSarlaft.UserControls.Riesgos.ConfigMapaRiesgos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>
<style type="text/css">
    .style1
    {
        font-family: Arial;
        font-size: X-small;
        margin-left: 40px;
    }

    .FondoAplicacion
    {
        background-color: Gray;
        filter: alpha(opacity=80);
        opacity: 0.8;
    }
</style>
<uc:OkMessageBox ID="omb" runat="server" />
<asp:Panel ID="PanelModalPopup" runat="server" Width="400px" Style="display: none;" BorderColor="#575757"
    BackColor="#FFFFFF" BorderStyle="Solid">
    <table width="100%">
        <tr class="topHandle" style="background-color: #5D7B9D">
            <td colspan="2" align="center" runat="server" id="tdCaption">&nbsp;
                <asp:Label ID="lblCaption" runat="server" Text="Atención" Font-Names="Calibri" Font-Size="Small"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px" valign="middle" align="center">
                <asp:Image ID="imgInfo" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
            </td>
            <td valign="middle" align="left">
                <asp:Label ID="lblMsgBox" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Black">Actualización Exitosa</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Button ID="btnAceptar" runat="server" Text="Ok" Font-Names="Calibri" Font-Size="Small" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="btndummy" runat="server" Text="Button" Style="display: none" />
<asp:ModalPopupExtender ID="mpeMsgBox" runat="server" OkControlID="btnAceptar"
    PopupControlID="PanelModalPopup" TargetControlID="btndummy" DropShadow="true" BackgroundCssClass="FondoAplicacion">
</asp:ModalPopupExtender>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table align="center" bgcolor="#EEEEEE" style="width: 50%;">
            <tr align="center" bgcolor="#FF9900">
                <td bgcolor="#002649">
                    <asp:Label ID="Label1" runat="server" ForeColor="White"
                        Text="Configuración Mapa de Riesgos" Font-Bold="False" Font-Names="Calibri"
                        Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="GViewConfigMR" runat="server" BackColor="White"
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4"
                        GridLines="Horizontal" ForeColor="#333333"
                        Font-Names="Franklin Gothic Medium" Font-Size="Small" AllowPaging="True"
                        AllowSorting="True" OnPageIndexChanging="GViewConfigMR_PageIndexChanging"
                        OnRowCommand="GViewConfigMR_RowCommand" OnSorting="GViewConfigMR_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="Acción">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgBtnActualizar" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Actualizar"
                                        ImageUrl="~/Imagenes/Icons/selectV5.png" ToolTip="Actualizar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td bgcolor="#BBBBBB" align="center">
                    <asp:Label ID="LblInformacion" runat="server" Font-Names="Calibri" Font-Size="Small" Visible="false" Text="Información Mapa Riesgos"
                        style="color:black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Panel ID="PanelConfigMapa" runat="server">
                        <table style="width: 100%;">
                            <tr align="left">
                                <td bgcolor="#BBBBBB" align="center">
                                    <asp:Label ID="LblNombreRiesgo" runat="server" Text="Nombre del Riesgo:" Font-Names="Calibri" Font-Size="Small" style="color:black"></asp:Label>
                                </td>
                                <td bgcolor="#f0eef0">
                                    <asp:TextBox ID="TxtNombreRiesgo" runat="server" Width="150px" Enabled="False" Font-Names="Calibri" MaxLength="50"
                                        Font-Size="Small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#BBBBBB" align="center">
                                    <asp:Label ID="LblFrecuencia" runat="server" Text="Frecuencia:" Font-Names="Calibri" Font-Size="Small" style="color:black"></asp:Label>
                                </td>

                                <td bgcolor="#EEEEEE" align="left">
                                    <asp:TextBox ID="txtFrecuencia" runat="server" Width="150px" Enabled="False" Font-Names="Calibri" MaxLength="50"
                                        Font-Size="Small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#BBBBBB" align="center">
                                    <asp:Label ID="LblImpacto" runat="server" Text="Impacto:" Font-Names="Calibri" Font-Size="Small" style="color:black"></asp:Label>
                                </td>

                                <td bgcolor="#EEEEEE" align="left">
                                    <asp:TextBox ID="TxtImpacto" runat="server" Width="150px" Enabled="False" Font-Names="Calibri" MaxLength="50"
                                        Font-Size="Small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#BBBBBB" align="center">
                                    <asp:Label ID="LblColor" runat="server" Text="Color:" Font-Names="Calibri" Font-Size="Small" style="color:black"></asp:Label>
                                </td>

                                <td bgcolor="#EEEEEE" align="left">
                                    <asp:DropDownList ID="DpColor" runat="server" Width="160px" Font-Names="Calibri"
                                        Font-Size="Small">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:ImageButton ID="ImgBtnGuardar" runat="server"
                                        ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                        ToolTip="Guardar" ValidationGroup="Obligatorios"
                                        OnClick="ImgBtnGuardar_Click" />
                                    <asp:ImageButton ID="ImgBtnCancelar" runat="server"
                                        ImageUrl="~/Imagenes/Icons/cancelV5.png"
                                        ToolTip="Cancelar" OnClick="ImgBtnCancelar_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>



