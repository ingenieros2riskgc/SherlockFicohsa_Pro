﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LimGblFrecuencia.ascx.cs" Inherits="ListasSarlaft.UserControls.Eventos.LimGblFrecuencia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>
<style type="text/css">
    .gridViewHeader a:link
    {
        text-decoration: none;
    }

    .style1
    {
        width: 100%;
    }
</style>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"        
    SelectCommand="SELECT Gbl.IdMtGblFrecuencia, EDF.IdDescFrecuencia, EDF.DescripcionFicohsa, Minimo, Maximo, LU.Nombres AS Usuario,Gbl.FechaRegistro FROM [Eventos].[MtGblFrecuencia] Gbl INNER JOIN Eventos.DescFrecuencia  EDF ON Gbl.IdDescFrecuencia = EDF.IdDescFrecuencia INNER JOIN [Listas].[Usuarios] LU ON LU.IdUsuario = Gbl.IdUsuario ORDER BY Minimo"
    UpdateCommand="UPDATE [Eventos].[MtGblFrecuencia] SET [IdDescFrecuencia] = @IdDescFrecuencia, [Minimo] = @Minimo, [Maximo] = @Maximo WHERE IdMtGblFrecuencia = @IdMtGblFrecuencia">        
    <UpdateParameters>
        <asp:Parameter Name="IdMtGblFrecuencia" Type="Int32" />
        <asp:Parameter Name="Minimo" Type="String" />
        <asp:Parameter Name="Maximo" Type="String" />
        <asp:Parameter Name="IdDescFrecuencia" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"
    SelectCommand="SELECT [IdTipoRiesgo],[TipoRiesgo] FROM [Eventos].[TipoRiesgo]"></asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"
    SelectCommand="SELECT [IdDescFrecuencia],[DescripcionFicohsa] FROM [Eventos].[DescFrecuencia]"></asp:SqlDataSource>
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
                    <asp:Label ID="Label13" runat="server" ForeColor="White" Text="Límites Globales Frecuencia" Font-Bold="False"
                        Font-Names="Calibri" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr align="center" bgcolor="#EEEEEE" id="filaGrids" runat="server" visible="true">
                <td bgcolor="#f0eef0">
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="SqlDataSource1"
                                    ForeColor="#333333" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                    DataKeyNames="IdMtGblFrecuencia, IdDescFrecuencia, Minimo, Maximo" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                    ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand" HeaderStyle-HorizontalAlign="Center"
                                    HorizontalAlign="Center" Font-Names="Calibri" Font-Size="Small"
                                    HeaderStyle-CssClass="gridViewHeader" BorderStyle="Solid" GridLines="Vertical"
                                    CssClass="Apariencia" Font-Bold="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="IdMtGblFrecuencia" HeaderText="Código" InsertVisible="False"
                                            ReadOnly="True" SortExpression="IdMtGblFrecuencia" Visible="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescripcionFicohsa" HeaderText="Frecuencia"
                                            SortExpression="DescripcionFicohsa" HtmlEncode="False"
                                            HtmlEncodeFormatString="False">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Minimo" HeaderText="Minimo"
                                            SortExpression="Minimo" HtmlEncode="False"
                                            HtmlEncodeFormatString="False">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Maximo" HeaderText="Maximo"
                                            SortExpression="Maximo" HtmlEncode="False"
                                            HtmlEncodeFormatString="False">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario"
                                            SortExpression="Usuario">
                                            <HeaderStyle HorizontalAlign="Center" />
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
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr align="left" id="filaDetalles" runat="server" visible="false">
                <td bgcolor="#f0eef0">

                    <table width="50%" align="center">
                        <tr id="tra" runat="server" visible="false">
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label1" runat="server" Text="Id:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="70px"
                                    CssClass="Apariencia"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label5" runat="server" Text="Frecuencia:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFrecuencia" runat="server" Width="306px" CssClass="Apariencia" DataSourceID="SqlDataSource3"
                                    DataTextField="DescripcionFicohsa" DataValueField="IdDescFrecuencia" AppendDataBoundItems="true"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label6" runat="server" Text="Mínimo:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMinimo" runat="server" Width="300px" CssClass="Apariencia" MaxLength="50"></asp:TextBox>
                               
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label7" runat="server" Text="Máximo:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMaximo" runat="server" Width="300px" CssClass="Apariencia" MaxLength="50"></asp:TextBox>
                               
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#BBBBBB">
                                <asp:Label ID="Label3" runat="server" Text="Usuario:" CssClass="Apariencia" style="color:black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsuario" runat="server" Width="297px" CssClass="Apariencia"
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
                                                Visible="False" OnClick="btnImgInsertar_Click" ToolTip="Guardar" ValidationGroup="iEstadoEvsEIncs" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnImgActualizar" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                Style="text-align: right" OnClick="btnImgActualizar_Click" ToolTip="Guardar" ValidationGroup="iEstadoEvsEIncs" />
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
