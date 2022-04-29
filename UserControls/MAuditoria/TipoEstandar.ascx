<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TipoEstandar.ascx.cs" Inherits="ListasSarlaft.UserControls.MAuditoria.TipoEstandar" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>

<style type="text/css">
    .gridViewHeader a:link  
    {
     text-decoration:none;
    }      
    .style2
    {
        height: 25px;
    }
</style>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"
    DeleteCommand="DELETE FROM [Auditoria].[TipoEstandar] WHERE [IdTipoEstandar] = @IdTipoEstandar"
    InsertCommand="INSERT INTO [Auditoria].[TipoEstandar] ([Descripcion], [FechaRegistro], [IdUsuario], [Clase]) VALUES (@Descripcion, @FechaRegistro, @IdUsuario, @Clase)"
    SelectCommand="SELECT [IdTipoEstandar], [Descripcion], CONVERT(VARCHAR(10),[TipoEstandar].[FechaRegistro],120) AS FechaRegistro, [TipoEstandar].[IdUsuario], [Usuarios].Usuario, [Clase]
                    FROM [Auditoria].[TipoEstandar], [Listas].[Usuarios]
                    WHERE 
                          [Usuarios].IdUsuario = [TipoEstandar].IdUsuario"
    UpdateCommand="UPDATE [Auditoria].[TipoEstandar] SET [Descripcion] = @Descripcion, [Clase] = @Clase WHERE [IdTipoEstandar] = @IdTipoEstandar">
    <DeleteParameters>
        <asp:Parameter Name="IdTipoEstandar" Type="Int64" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Descripcion" Type="String" />
        <asp:Parameter Name="FechaRegistro" Type="DateTime" />
        <asp:Parameter Name="IdUsuario" Type="Int32" />
        <asp:Parameter Name="Clase" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Descripcion" Type="String" />
        <asp:Parameter Name="Clase" Type="String" />
        <asp:Parameter Name="IdTipoEstandar" Type="Int64" />
    </UpdateParameters>
</asp:SqlDataSource>

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
                    <td style="width: 60px" valign="middle" align="center" >
                        <asp:Image ID="imgInfo" runat="server" 
                            ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png"/>
                    </td>
                    <td valign="middle" align="left">
                        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="False" Font-Names="Tahoma" ForeColor="Black" 
                            Font-Size="11px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnImgokEliminar" runat="server" Text="Ok" OnClick="btnImgokEliminar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClientClick="$find('mypopup').hide(); return false;"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpeMsgBox" runat="server" PopupControlID="pnlMsgBox" BehaviorId="mypopup" 
            Enabled="True" TargetControlID="btndummy" BackgroundCssClass="modalBackground"  DropShadow="true" >
        </asp:ModalPopupExtender>
        <asp:Button ID="btndummy" runat="server" Text="Button" style="display:none"/>
        <asp:Label ID="lblOk" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="lblCancelar" runat="server" Text="Label" Visible="False"></asp:Label>

        <table align="center"  width="60%">
            <tr align="center" bgcolor="#002649">
                <td>
                    <%--<br />--%>
                    <asp:Label ID="Label13" runat="server" ForeColor="White" Text="Tipo de Estandar" Font-Bold="False"
                        Font-Names="Calibri" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr align="center" bgcolor="#EEEEEE"  id="filaGrid" runat="server" visible="true" >
                <td bgcolor="#f0eef0">
                    <br />
                    <table>
                        <tr >
                            <td>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="SqlDataSource1"
                                    ForeColor="#333333" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                    DataKeyNames="IdTipoEstandar,Usuario" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                    ShowHeaderWhenEmpty="True" onrowcommand="GridView1_RowCommand"
                                    HeaderStyle-CssClass="gridViewHeader" BorderStyle="Solid" GridLines="Vertical"
                                    CssClass="Apariencia" Font-Bold="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="IdTipoEstandar" HeaderText="Código" InsertVisible="False"
                                            ReadOnly="True" SortExpression="IdTipoEstandar" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Clase" HeaderText="Clase" 
                                            SortExpression="Clase" >
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" 
                                            SortExpression="Descripcion" HtmlEncode="False" >
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Creación" 
                                            SortExpression="FechaRegistro" ReadOnly="True" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" 
                                            SortExpression="IdUsuario" Visible="False" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" 
                                            SortExpression="Usuario" Visible="False" />
                                        <asp:TemplateField HeaderText="Acción" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Imagenes/Icons/edit.png" Text="Seleccionar" ToolTip="Editar"/>
                                                <asp:ImageButton ID="btnImgEliminar" runat="server" CausesValidation="False" OnClick="btnImgEliminar_Click" CommandArgument="<%# Container.DataItemIndex %>"
                                                    ImageUrl="~/Imagenes/Icons/delete.png" Text="Eliminar" CommandName="Eliminar" ToolTip="Eliminar"/>
                                            </ItemTemplate>
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
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:ImageButton ID="imgBtnInsertar" runat="server" CausesValidation="False" CommandName="Insert"
                                    ImageUrl="~/Imagenes/Icons/Add.png" Text="Insert" 
                                    OnClick="imgBtnInsertar_Click" ToolTip="Insertar" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr align="right" runat="server">
                <td>
                    <tr id="filaDetalle" runat="server" visible="false">
                        <td bgcolor="#f0eef0">
                            <table class="tabla" width="500px" aligh="right">
                                <tr>
                                    <td align="center" bgcolor="#BBBBBB">
                                        <asp:Label ID="Label1" runat="server" CssClass="Apariencia" Text="Código:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtId" runat="server" CssClass="Apariencia" Enabled="False" Width="70px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#BBBBBB">
                                        <asp:Label ID="Label5" runat="server" CssClass="Apariencia" Text="Clase:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="ddlClase" runat="server" CssClass="Apariencia" Rows="1" Width="100px">
                                            <asp:ListItem> </asp:ListItem>
                                            <asp:ListItem>Auditoria</asp:ListItem>
                                            <asp:ListItem>Riesgos</asp:ListItem>
                                        </asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#BBBBBB">
                                        <asp:Label ID="Label2" runat="server" CssClass="Apariencia" Text="Descripcion:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDescripicion" runat="server" CssClass="Apariencia" Width="600px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#BBBBBB" class="style2">
                                        <asp:Label ID="Label3" runat="server" CssClass="Apariencia" Text="Usuario:"></asp:Label>
                                    </td>
                                    <td class="style2">
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="Apariencia" Enabled="False" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#BBBBBB">
                                        <asp:Label ID="Label4" runat="server" CssClass="Apariencia" Text="Fecha de Creación:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFecha" runat="server" CssClass="Apariencia" Enabled="False" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td colspan="2">
                                        <table class="tablaSinBordes">
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="btnImgInsertar" runat="server" ImageUrl="~/Imagenes/Icons/guardar.png" onclick="btnImgInsertar_Click" ToolTip="Guardar" Visible="False" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnImgActualizar" runat="server" ImageUrl="~/Imagenes/Icons/guardar.png" onclick="btnImgActualizar_Click" Style="text-align: right" ToolTip="Guardar" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnImgCancelar" runat="server" ImageUrl="~/Imagenes/Icons/cancel.png" OnClick="btnImgCancelar_Click" ToolTip="Cancelar" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
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