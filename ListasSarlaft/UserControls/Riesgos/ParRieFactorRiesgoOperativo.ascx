<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParRieFactorRiesgoOperativo.ascx.cs"
    Inherits="ListasSarlaft.UserControls.Riesgos.ParRieFactorRiesgoOperativo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .gridViewHeader a:link
    {
        text-decoration: none;
    }

    .FondoAplicacion
    {
        background-color: Gray;
        filter: alpha(opacity=80);
        opacity: 0.8;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table align="center" bgcolor="#EEEEEE">
            <tr align="center" bgcolor="#002649">
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                        ForeColor="White" Text="Factor de riesgo operativo"></asp:Label>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <table>
                        <tr align="center">
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader"
                                    BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small" HeaderStyle-HorizontalAlign="Center"
                                    AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Factor de riesgo operativo" DataField="NombreFactorRiesgoOperativo" >
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Acción">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnImgModificar" runat="server" CausesValidation="False" CommandName="Modificar"
                                                    ImageUrl="~/Imagenes/Icons/editV5.png" Text="Editar" ToolTip="Editar"
                                                    CommandArgument="<%# Container.DataItemIndex %>" />
                                                <asp:ImageButton ID="btnImgEliminar" runat="server" CausesValidation="False" CommandName="Borrar"
                                                    ImageUrl="~/Imagenes/Icons/deleteV5.png" Text="Eliminar" ToolTip="Eliminar"
                                                    CommandArgument="<%# Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <%-- <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/edit.png" Text="Editar"
                                            CommandName="Modificar" />
                                        <asp:ButtonField ButtonType="Image" CommandName="Borrar" ImageUrl="~/Imagenes/Icons/delete.png"
                                            Text="Eliminar"></asp:ButtonField>--%>
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
                        <tr align="right">
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/Icons/AddV5.png"
                                    ToolTip="Insertar" OnClick="ImageButton1_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr align="center" id="trCampos" runat="server" visible="false">
                <td>
                    <table>
                        <tr align="center">
                            <td bgcolor="#BBBBBB">
                                <asp:Label ID="Label2" runat="server" Text="Factor de riesgo operativo" Font-Names="Calibri"
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td bgcolor="#f0eef0">
                                <asp:TextBox ID="TextBox1" runat="server" Width="450px" Font-Names="Calibri" Font-Size="Small" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                    InitialValue="" ForeColor="Red" ValidationGroup="validarCampos">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                ToolTip="Guardar" Visible="false" ValidationGroup="validarCampos" OnClick="ImageButton2_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                ToolTip="Guardar" Visible="false" ValidationGroup="validarCampos" OnClick="ImageButton3_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png"
                                                ToolTip="Cancelar" OnClick="ImageButton4_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:ModalPopupExtender ID="mpeMsgBox" runat="server" TargetControlID="btndummy"
            PopupControlID="pnlMsgBox" OkControlID="btnAceptar" BackgroundCssClass="FondoAplicacion"
            Enabled="True" DropShadow="true">
        </asp:ModalPopupExtender>
        <asp:Button ID="btndummy" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlMsgBox" runat="server" Width="400px" Style="display: none;" BorderColor="#575757"
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
        <asp:ModalPopupExtender ID="mpeMsgBoxOkNo" runat="server" TargetControlID="btndummyOkNo"
            PopupControlID="pnlMsgBoxOkNo" OkControlID="btnCancelarOkNo" BackgroundCssClass="FondoAplicacion"
            Enabled="True" DropShadow="true">
        </asp:ModalPopupExtender>
        <asp:Button ID="btndummyOkNo" runat="server" Text="Button" Style="display: none" />
        <asp:Label ID="lbldummyOkNo" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Panel ID="pnlMsgBoxOkNo" runat="server" Width="400px" Style="display: none;"
            BorderColor="#575757" BackColor="#FFFFFF" BorderStyle="Solid">
            <table width="100%">
                <tr class="topHandle" style="background-color: #5D7B9D">
                    <td colspan="2" align="center" runat="server" id="tdCaptionOkNo">&nbsp;
                        <asp:Label ID="lblCaptionOkNo" runat="server" Text="Atención" Font-Names="Calibri"
                            Font-Size="Small"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 60px" valign="middle" align="center">
                        <asp:Image ID="imgInfoOkNo" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
                    </td>
                    <td valign="middle" align="left">
                        <asp:Label ID="lblMsgBoxOkNo" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnAceptarOkNo" runat="server" Text="Ok" Font-Names="Calibri" Font-Size="Small"
                            OnClick="btnAceptarOkNo_Click" />
                        <asp:Button ID="btnCancelarOkNo" runat="server" Text="Cancelar" Font-Names="Calibri"
                            Font-Size="Small" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
