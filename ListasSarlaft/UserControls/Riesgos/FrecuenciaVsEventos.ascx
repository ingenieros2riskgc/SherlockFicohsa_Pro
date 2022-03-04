<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FrecuenciaVsEventos.ascx.cs" Inherits="ListasSarlaft.UserControls.Riesgos.FrecuenciaVsEventos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>
<link href="../../../Styles/AdminSitio.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="FVEbody" runat="server">
    <ContentTemplate>
        <uc:OkMessageBox ID="omb" runat="server" />
        <div class="content">
            <!-- begin row -->
			<div class="row">
                <!-- begin col-12 -->
				<div class="col-lg-12">
                     <table align="center" width="100%">
            <tr align="center" bgcolor="#002649">
                <td>
        <%--<div class="TituloLabel" id="HeadFVE" runat="server">--%>
                    <asp:Label ID="Ltitulo" runat="server" ForeColor="White" Text="Frecuencia vs Eventos" Font-Bold="False"
                        Font-Names="Calibri" Font-Size="Large"></asp:Label>
            <%--</div>--%>
                    </td>
            </tr>
        <div id="BodyGridFVE" class="ColumnStyle" runat="server">
            <Table class="tabla" align="center" width="100%">
                        <tr align="center">
                            <td>
                                <asp:GridView ID="GVfrecuenciavsEventos" runat="server" CellPadding="4"
                                    ForeColor="#333333" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                    ShowHeaderWhenEmpty="True" DataKeyNames="intCodigoFrecuencia,dtFechaRegistro,strUsuario"
                                    HeaderStyle-CssClass="gridViewHeader" BorderStyle="Solid" GridLines="Vertical" HeaderStyle-HorizontalAlign="Center"
                                    CssClass="Apariencia" Font-Bold="False" OnPageIndexChanging="GVfrecuenciavsEventos_PageIndexChanging" OnRowCommand="GVfrecuenciavsEventos_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="intIdFrecuenciaEventos" HeaderText="Código" SortExpression="intIdFrecuenciaEventos" ItemStyle-HorizontalAlign="Center"  Visible="false"/>
                                        <asp:BoundField DataField="intEventosMaximos" HeaderText="Eventos Maximos" SortExpression="intEventosMaximos" HtmlEncodeFormatString="True" HtmlEncode="False" >
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="intCodigoFrecuencia" HeaderText="intCodigoFrecuencia" SortExpression="intCodigoFrecuencia" HtmlEncodeFormatString="True" HtmlEncode="False" Visible="false" />
                                        <asp:TemplateField HeaderText="Nombre Frecuencia" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 150px">
                                                    <asp:Label ID="strNombreFrecuencia" runat="server" Text='<% # Bind("strNombreFrecuencia")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                            <ItemStyle Wrap="false"  />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="dtFechaRegistro" HeaderText="fechaRegistro" ReadOnly="True" Visible="false" SortExpression="dtFechaRegistro" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="intIdUsuario" HeaderText="IdUsuario" ReadOnly="True" Visible="false" SortExpression="intIdUsuario" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="strUsuario" HeaderText="Usuario" ReadOnly="True" Visible="false" SortExpression="strUsuario" ItemStyle-HorizontalAlign="Center" />
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/selectV5.png" Text="Seleccionar" HeaderText="Seleccionar" CommandName="Seleccionar" ItemStyle-HorizontalAlign="Center" />
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
                    <td align="center">
                        <asp:ImageButton ID="btnInsertarNuevo" runat="server" CausesValidation="False" CommandName="Insert"
                                    ImageUrl="~/Imagenes/Icons/AddV5.png" Text="Insert" OnClick="btnInsertarNuevo_Click" ToolTip="Insertar" />
                    </td>
                </tr>
            </Table>
        </div>
        <div id="BodyFormFVE" class="ColumnStyle" runat="server" visible="false">
            <div id="form" class="TableContains">
                <Table class="tabla" align="center" width="80%">
                        <tr>
                            <td class="RowsText" align="center">
                                <asp:Label ID="Lcodigo" runat="server" Text="Código:" CssClass="Apariencia"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtId" runat="server" Enabled="False"
                                    CssClass="Apariencia" Width="300px"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                    
                    <tr>
                        <td class="RowsText" align="center">
                            <asp:Label ID="LMaxEvent" runat="server" Text="Eventos Máximos:" CssClass="Apariencia" Width="300px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TXmaxEvent" runat="server" Font-Names="Calibri" Font-Size="Small" ValidationGroup="FVE" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RFVmaxEvent" runat="server" ControlToValidate="TXmaxEvent"
                                    ErrorMessage="Debe ingresar la cantidad Máxima de eventos." ToolTip="Debe ingresar la cantidad Máxima de eventos."
                                    ValidationGroup="FVE" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="REVmaxEvent" Display="Dynamic" ForeColor="Red"
                                    ControlToValidate="TXmaxEvent" ValidationExpression="^[0-9]*$" ValidationGroup="FVE"
                                    ErrorMessage="Ingresar solamente números enteros" ToolTip="Ingresar solamente números enteros">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                        <tr>
                            <td class="RowsText" align="center">
                                <asp:Label ID="LCodigoFrecuencia" runat="server" Text="Código Frecuencia:" CssClass="Apariencia"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLfrecuencia" runat="server" Width="300px" Font-Names="Calibri"
                                                                            Font-Size="Small">
                                                                            <asp:ListItem Value="---">---</asp:ListItem>
                                                                        </asp:DropDownList>
                                
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RVcodigoFrecuencia" runat="server" ControlToValidate="DDLfrecuencia"
                                    ErrorMessage="Debe seleccionar la frecuencia." ToolTip="Debe seleccionar la frecuencia."
                                    ValidationGroup="FVE" ForeColor="Red" InitialValue="---">*</asp:RequiredFieldValidator>

                            </td>
                        </tr>
                         
                    <tr>
                            <td class="RowsText" align="center">
                                <asp:Label ID="Lusuario" runat="server" Text="Usuario Creación:" CssClass="Apariencia" Width="300px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbxUsuarioCreacion" runat="server" Width="300px" CssClass="Apariencia"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        <td></td>
                        </tr>
                        <tr>
                            <td class="RowsText" align="center">
                                <asp:Label ID="LfechaCreacion" runat="server" Text="Fecha de Creación:" CssClass="Apariencia"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" Width="300px" CssClass="Apariencia"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:ImageButton ID="IBinsertGVC" runat="server" CausesValidation="true" CommandName="Insert"
                                    ImageUrl="~/Imagenes/Icons/guardarV5.png" Text="Insert" ValidationGroup="FVE" ToolTip="Insertar" Visible="false" OnClick="IBinsertGVC_Click"/>
            <asp:ImageButton ID="IBupdateGVC" runat="server" CausesValidation="true" CommandName="Update"
                                    ImageUrl="~/Imagenes/Icons/guardarV5.png" Text="Update" ValidationGroup="FVE" ToolTip="Actualizar" Visible="false" OnClick="IBupdateGVC_Click"/>
            <asp:ImageButton ID="btnImgCancelar" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png"
                                    OnClick="btnImgCancelar_Click" ToolTip="Cancelar" />
                        </td>
                    </tr>
                    </table>
            </div>
        </div>
                         </table>
                     </div>
                <!-- End col-12 -->
                </div>
            <!-- End row -->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>