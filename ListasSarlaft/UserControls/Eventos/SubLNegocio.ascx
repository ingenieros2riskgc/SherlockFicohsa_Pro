<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubLNegocio.ascx.cs" Inherits="ListasSarlaft.UserControls.Eventos.SubLNegocio" %>
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
    DeleteCommand="DELETE FROM [Eventos].[SubLineaNegocio] WHERE [IdSubLineaNegocio] = @IdSubLineaNegocio"
    InsertCommand="INSERT INTO [Eventos].[SubLineaNegocio] ([IdLineaNegocio], [IdUsuario], [SubDescripcion], [FechaRegistro]) VALUES (@IdLineaNegocio, @IdUsuario, @SubDescripcion, @FechaRegistro)"
    SelectCommand="SELECT [IdSubLineaNegocio], [LineaNegocio].[IdLineaNegocio] AS IdLineaNegocio, [SubDescripcion], [LineaNegocio].[IdUsuario], [Usuario], [Descripcion], CONVERT(VARCHAR(10),[SubLineaNegocio].[FechaRegistro],103) AS FechaRegistro FROM [Eventos].[SubLineaNegocio], [Eventos].[LineaNegocio], [Listas].[Usuarios] WHERE [LineaNegocio].[IdLineaNegocio] = [SubLineaNegocio].[IdLineaNegocio] AND [LineaNegocio].[idUsuario] = [Usuarios].[idUsuario]"
    UpdateCommand="UPDATE [Eventos].[SubLineaNegocio] SET [IdLineaNegocio] = @IdLineaNegocio, [SubDescripcion] = @SubDescripcion WHERE [IdSubLineaNegocio] = @IdSubLineaNegocio">
    <DeleteParameters>
        <asp:Parameter Name="IdSubLineaNegocio" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="IdLineaNegocio" Type="Int32" />
        <asp:Parameter Name="IdUsuario" Type="Int32" />
        <asp:Parameter Name="SubDescripcion" Type="String" />
        <asp:Parameter Name="FechaRegistro" Type="DateTime" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="IdLineaNegocio" Type="Int32" />
        <asp:Parameter Name="SubDescripcion" Type="String" />
        <asp:Parameter Name="IdSubLineaNegocio" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server"
    ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"
    SelectCommand="SELECT [IdLineaNegocio], [Descripcion] FROM [Eventos].[LineaNegocio]"></asp:SqlDataSource>
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
                    <asp:Label ID="Label13" runat="server" ForeColor="White" Text="SubLínea Operativa" Font-Bold="False"
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
                                    ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader" DataKeyNames="Usuario,IdLineaNegocio"
                                    BorderStyle="Solid" GridLines="Vertical" CssClass="Apariencia" HeaderStyle-HorizontalAlign="Center"
                                    Font-Bold="False" OnRowCommand="GridView1_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="IdSubLineaNegocio" HeaderText="Código" InsertVisible="False" ReadOnly="True"
                                            SortExpression="IdSubLineaNegocio" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdLineaNegocio" HeaderText="IdLineaNegocio"
                                            SortExpression="IdLineaNegocio" InsertVisible="False" ReadOnly="True"
                                            Visible="False" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Línea Operativa"
                                            SortExpression="Descripcion">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario"
                                            SortExpression="IdUsuario" Visible="False" />
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario"
                                            SortExpression="Usuario" Visible="False" />
                                        <asp:BoundField DataField="SubDescripcion" HeaderText="SubLínea Operativa"
                                            SortExpression="Descripcion" HtmlEncode="False"
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
                            <td align="left" bgcolor="#BBBBBB">
                                <asp:Label ID="Label1" runat="server" Text="Id:" CssClass="Apariencia"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="70px"
                                    CssClass="Apariencia"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label3" runat="server" Text="Línea Operativa:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNegocio" runat="server" Width="300px"
                                    CssClass="Apariencia" DataSourceID="SqlDataSource2" OnDataBound="ddlNegocio_DataBound"
                                    DataTextField="Descripcion" DataValueField="IdLineaNegocio" AppendDataBoundItems="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvNegocio" runat="server" ControlToValidate="ddlNegocio"
                                    ErrorMessage="Debe ingresar la línea de negocio." ToolTip="Debe ingresar la línea de negocio."
                                    ValidationGroup="iSubNegocio" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label2" runat="server" Text="Nombre:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server" Width="300px" CssClass="Apariencia" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                    ErrorMessage="Debe ingresar el Nombre." ToolTip="Debe ingresar el Nombre."
                                    ValidationGroup="iSubNegocio" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                                Visible="False" OnClick="btnImgInsertar_Click" ToolTip="Guardar" ValidationGroup="iSubNegocio" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnImgActualizar" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                Style="text-align: right" OnClick="btnImgActualizar_Click" ValidationGroup="iSubNegocio"
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
