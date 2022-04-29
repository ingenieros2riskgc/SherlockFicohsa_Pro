<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Activo.ascx.cs" Inherits="ListasSarlaft.UserControls.Eventos.Activo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }

    .gridViewHeader a:link
    {
        text-decoration: none;
    }
</style>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"
    DeleteCommand="DELETE FROM [Eventos].[ActivoAfectado] WHERE [IdActivoAfectado] = @IdActivoAfectado"
    InsertCommand="INSERT INTO [Eventos].[ActivoAfectado] ([IdTipoActivo], [IdUsuario], [Activo], [FechaRegistro]) VALUES (@IdTipoActivo, @IdUsuario, @Activo, @FechaRegistro)"
    SelectCommand="SELECT [IdActivoAfectado], [TipoActivo].[IdTipoActivo] AS IdTipoActivo, [ActivoAfectado].[Activo], [ActivoAfectado].[IdUsuario], [Usuario], [TipoActivo].[Tipo] as [TipoActivo], CONVERT(VARCHAR(10),[ActivoAfectado].[FechaRegistro],103) AS FechaRegistro FROM [Eventos].[ActivoAfectado], [Eventos].[TipoActivo], [Listas].[Usuarios] WHERE [TipoActivo].[IdTipoActivo] = [ActivoAfectado].[IdTipoActivo] AND [ActivoAfectado].[idUsuario] = [Usuarios].[idUsuario]"
    UpdateCommand="UPDATE [Eventos].[ActivoAfectado] SET [IdTipoActivo] = @IdTipoActivo, [Activo] = @Activo WHERE [IdActivoAfectado] = @IdActivoAfectado">
    <DeleteParameters>
        <asp:Parameter Name="IdActivoAfectado" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="IdTipoActivo" Type="Int32" />
        <asp:Parameter Name="IdUsuario" Type="Int32" />
        <asp:Parameter Name="Activo" Type="String" />
        <asp:Parameter Name="FechaRegistro" Type="DateTime" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="IdTipoActivo" Type="Int32" />
        <asp:Parameter Name="Activo" Type="String" />
        <asp:Parameter Name="IdActivoAfectado" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server"
    ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"
    SelectCommand="SELECT [IdTipoActivo], [Tipo] FROM [Eventos].[TipoActivo]"></asp:SqlDataSource>
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
                            ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
                    </td>
                    <td valign="middle" align="left">
                        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="False" Font-Names="Tahoma" ForeColor="Black"
                            Font-Size="11px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnImgokEliminar" runat="server" Text="Ok" OnClick="btnImgokEliminar_Click" />
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
        <table align="center">
            <tr align="center" bgcolor="#002649">
                <td>
                    <%--<br />--%>
                    <asp:Label ID="Label13" runat="server" ForeColor="White" Text="Activo" Font-Bold="False"
                        Font-Names="Calibri" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr align="center" bgcolor="#EEEEEE" id="filaGrid" runat="server" visible="true">
                <td bgcolor="#f0eef0">
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="SqlDataSource1"
                                    ForeColor="#333333" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                    ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader" DataKeyNames="Usuario,IdTipoActivo"
                                    BorderStyle="Solid" GridLines="Vertical" CssClass="Apariencia" HeaderStyle-HorizontalAlign="Center"
                                    HorizontalAlign="Center" Font-Names="Calibri" Font-Size="Small"
                                    Font-Bold="False" OnRowCommand="GridView1_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="IdActivoAfectado" HeaderText="Código" InsertVisible="False" ReadOnly="True"
                                            SortExpression="IdActivoAfectado" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdTipoActivo" HeaderText="IdTipoActivo"
                                            SortExpression="IdTipoActivo" InsertVisible="False" ReadOnly="True"
                                            Visible="False" />
                                        <asp:BoundField DataField="Activo" HeaderText="Activo"
                                            SortExpression="Activo">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario"
                                            SortExpression="IdUsuario" Visible="False" />
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario"
                                            SortExpression="Usuario" Visible="False" />
                                        <asp:BoundField DataField="TipoActivo" HeaderText="Tipo de Activo"
                                            SortExpression="TipoActivo" HtmlEncode="False"
                                            HtmlEncodeFormatString="False">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Creación"
                                            SortExpression="FechaRegistro">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Acción">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Imagenes/Icons/editV5.png" Text="Seleccionar" ToolTip="Editar" />
                                                <asp:ImageButton ID="btnImgEliminar" runat="server" CausesValidation="False" OnClick="btnImgEliminar_Click" CommandArgument="<%# Container.DataItemIndex %>"
                                                    ImageUrl="~/Imagenes/Icons/deleteV5.png" Text="Eliminar" CommandName="Eliminar" ToolTip="Eliminar" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
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
                                <tr>
                                    <td align="right">
                                        <asp:ImageButton ID="imgBtnInsertar" runat="server" CausesValidation="False" CommandName="Insert"
                                            ImageUrl="~/Imagenes/Icons/AddV5.png" Text="Insert" OnClick="imgBtnInsertar_Click" ToolTip="Insertar" />
                                    </td>
                                </tr>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr align="left" id="filaDetalle" runat="server" visible="false">
                <td bgcolor="#f0eef0">
                    <table width="100%">
                        <tr id="tra" runat="server" visible="false">
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
                                <asp:Label ID="Label3" runat="server" Text="Tipo de Activo:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoActivo" runat="server" Width="300px"
                                    CssClass="Apariencia" DataSourceID="SqlDataSource2" OnDataBound="ddlTipoActivo_DataBound"
                                    DataTextField="Tipo" DataValueField="IdTipoActivo" AppendDataBoundItems="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvTipoActivo" runat="server" ControlToValidate="ddlTipoActivo"
                                    ErrorMessage="Debe ingresar el tipo de activo." ToolTip="Debe ingresar el tipo de activo."
                                    ValidationGroup="iTipoActivo" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label2" runat="server" Text="Activo:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtActivo" runat="server" Width="300px" CssClass="Apariencia" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvActivo" runat="server" ControlToValidate="txtActivo"
                                    ErrorMessage="Debe ingresar la Activo." ToolTip="Debe ingresar la Activo."
                                    ValidationGroup="iTipoActivo" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label4" runat="server" Text="Usuario:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsuario" runat="server" Width="100px" CssClass="Apariencia"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label5" runat="server" Text="Fecha de Creación:" CssClass="Apariencia" style="color:black"></asp:Label>
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
                                                Visible="False" OnClick="btnImgInsertar_Click" ToolTip="Guardar" ValidationGroup="iTipoActivo"/>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnImgActualizar" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                Style="text-align: right" OnClick="btnImgActualizar_Click" ValidationGroup="iTipoActivo"
                                                ToolTip="Guardar" />
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
</script>
