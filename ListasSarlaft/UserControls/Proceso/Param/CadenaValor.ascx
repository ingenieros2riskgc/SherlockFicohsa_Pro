<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CadenaValor.ascx.cs" Inherits="ListasSarlaft.UserControls.Proceso.CadenaValor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>
<style type="text/css">
    .ajax__html_editor_extender_texteditor
    {
        background-color: White;
        font-size: small;
        font-weight: lighter;
        font-family: Calibri;
        font-style: normal;
    }

    .gridViewHeader a:link
    {
        text-decoration: none;
    }

    .style1
    {
        width: 100%;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <uc:OkMessageBox ID="omb" runat="server" />
        <asp:Panel ID="pnlMsgBox" runat="server" Width="400px" CssClass="modalPopup" Style="display: none;">
            <table width="100%">
                <tr class="topHandle">
                    <td colspan="2" align="center" runat="server" id="tdCaption">
                        <asp:Label ID="lblCaption" runat="server" Text="Atención"
                            Font-Bold="False" Font-Names="Tahoma" Font-Size="11px"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 60px" valign="middle" align="center">
                        <asp:Image ID="imgInfo" runat="server"
                            ImageUrl="~/Imagenes/Icons/icontexto-webdev-alert.png" />
                    </td>
                    <td valign="middle" align="left">
                        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="False" Font-Names="Tahoma" ForeColor="Black"
                            Font-Size="11px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnModificarEstado" runat="server" Text="Ok" OnClick="btnModificarEstado_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClientClick="$find('mypopup').hide(); return false;" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpeMsgBox" runat="server" PopupControlID="pnlMsgBox" BehaviorID="mypopup"
            Enabled="True" TargetControlID="btndummy" BackgroundCssClass="modalBackground" DropShadow="true">
        </asp:ModalPopupExtender>
        <asp:Button ID="btndummy" runat="server" Text="Button" Style="display: none" />
        <asp:Label ID="lblOk" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="lblCancelar" runat="server" Text="Label" Visible="False"></asp:Label>
        <div class="content">
            <!-- begin row -->
			<div class="row">
                <!-- begin col-12 -->
				<div class="col-lg-12">
        <table align="center" width="80%">
            <tr align="center" bgcolor="#002649">
                <td>
                    <%--<br />--%>
                    <asp:Label ID="Label13" runat="server" ForeColor="White" Text="Cadena de Valor" Font-Bold="False"
                        Font-Names="Calibri" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr align="center" bgcolor="#EEEEEE" id="filaGrid" runat="server" visible="true">
                <td bgcolor="#f0eef0">
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4"
                                    ForeColor="#333333" AllowSorting="True" AutoGenerateColumns="False"
                                    DataKeyNames="intId" ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand"
                                    HeaderStyle-CssClass="gridViewHeader" BorderStyle="Solid" GridLines="Vertical" HeaderStyle-HorizontalAlign="Center"
                                    CssClass="Apariencia" Font-Bold="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="intId" HeaderText="Código" ReadOnly="True" SortExpression="intId" 
                                            ItemStyle-CssClass="no-visible" HeaderStyle-CssClass="no-visible" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strNombreCadenaValor" HeaderText="Nombre" SortExpression="strNombreCadenaValor"
                                            HtmlEncode="False" HtmlEncodeFormatString="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Estado" ControlStyle-CssClass="estado">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chbActivo" runat="server" Checked='<% # Bind("booEstado")%>' Enabled="false" />
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intIdUsuario" HeaderText="Región" SortExpression="intIdUsuario"
                                            Visible="False" />
                                        <asp:BoundField DataField="strNombreUsuario" HeaderText="Usuario Creación" SortExpression="strNombreUsuario"
                                            Visible="False" />
                                        <asp:BoundField DataField="dtFechaRegistro" HeaderText="Fecha de Creación" SortExpression="dtFechaRegistro">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/editV5.png" Text="Modificar"
                                            HeaderText="Modificar" CommandName="Modificar" ItemStyle-HorizontalAlign="Center" />
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/switch-on-icon.png" Text="(In)Activar" ControlStyle-CssClass="activar"
                                            HeaderText="(In)Activar" CommandName="Activar" ItemStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:ImageButton ID="btnNuevaCadenaValor" runat="server" CausesValidation="False" CommandName="Insert"
                                    ImageUrl="~/Imagenes/Icons/AddV5.png" Text="Insert"
                                    OnClick="btnNuevaCadenaValor_Click" ToolTip="Insertar" />
                            </td>
                        </tr>
                        
                    </table>
                    <br />
                </td>
            </tr>
            <tr align="left" id="filaDetalle" runat="server" visible="false">
                <td bgcolor="#f0eef0">
                    <table class="tabla" width="100%">
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label1" runat="server" Text="Código:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="70px"
                                    CssClass="Apariencia"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label6" runat="server" Text="Nombre:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server" Width="300px" CssClass="Apariencia" MaxLength="60"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                    ErrorMessage="Debe ingresar el Nombre." ToolTip="Debe ingresar el Nombre."
                                    ValidationGroup="iCadenaValor" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label2" runat="server" Text="Estado:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="ChBEstado" runat="server" Checked="true" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label3" runat="server" Text="Usuario Creación:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbxUsuarioCreacion" runat="server" Width="100px" CssClass="Apariencia"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label4" runat="server" Text="Fecha de Creación:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" Width="100px" CssClass="Apariencia"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <table class="tablaSinBordes">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnImgInsertar" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                Visible="False" OnClick="btnImgInsertar_Click" ToolTip="Guardar" ValidationGroup="iCadenaValor" />

                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnImgActualizar" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                Style="text-align: right" OnClick="btnImgActualizar_Click"
                                                ToolTip="Guardar" ValidationGroup="iCadenaValor" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnImgCancelar" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png"
                                                OnClick="btnImgCancelar_Click" ToolTip="Cancelar" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
                    </div>
                <!-- End col-12 -->
                </div>
            <!-- End row -->
            </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
<%--The fnClick javascript function will force the btnOk button to post back. 
(to actually achieve this we need to add a little piece of code in 
the Page_Load method of the user control.--%>
<script type="text/javascript">
    function fnClick(sender, e) {
        __doPostBack(sender, e);
    }
    fnChangeImage();

    function fnChangeImage() {
        var gridView = document.getElementsByClassName("Apariencia")[0];
        var column_activar = column_estado = check_estado = "";
        for (var i = 0, row; row = gridView.rows[i]; i++) {
            column_activar = row.getElementsByClassName("activar")[0];
            column_estado = row.getElementsByClassName("estado")[0];
            if (column_activar != undefined) {
                check_estado = column_estado.getElementsByTagName("input")[0];
                if (check_estado.getAttribute("checked") == "checked")
                    column_activar.setAttribute("src", "../../../Imagenes/Icons/switch-on-icon.png");
                else
                    column_activar.setAttribute("src", "../../../Imagenes/Icons/switch-off-icon.png");
            } 
        }
    }
</script>
