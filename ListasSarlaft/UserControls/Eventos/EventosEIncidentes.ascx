<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventosEIncidentes.ascx.cs" Inherits="ListasSarlaft.UserControls.Eventos.EvsEIncs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>
<script src="/JS/jquery.min.js"></script>
<script src="/JS/jsFunciones.js"></script>
<script type="text/javascript">
    function fnClick(sender, e) {
        __doPostBack(sender, e);
    }

    var docScrollTop;
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    function BeginRequestHandler(sender, args) {
        docScrollTop = $(document).scrollTop();
    }

    function EndRequestHandler(sender, args) {
        $(document).scrollTop(docScrollTop);
    }

    prm.add_beginRequest(BeginRequestHandler);
    prm.add_endRequest(EndRequestHandler);

</script>
<style type="text/css">
   .gridViewHeader a:link {
   text-decoration: none;
   }
   .FondoAplicacion {
   background-color: Gray;
   filter: alpha(opacity=80);
   opacity: 0.8;
   }
   .scrollingControlContainer {
   overflow-x: hidden;
   overflow-y: scroll;
   }
   .scrollingCheckBoxList {
   border: 1px #808080 solid;
   margin: 10px 10px 10px 10px;
   height: 200px;
   }
   .popup {
   border: Silver 1px solid;
   color: #060F40;
   background: #ffffff;
   }
   .style1 {
   height: 74px;
   }
   .EAsociados {
   border-radius: 0px 55px 57px 0px;
   -moz-border-radius: 0px 55px 57px 0px;
   -webkit-border-radius: 0px 55px 57px 0px;
   border: 0px solid #000000;
   background: rgba(227,227,227,1);
   background: -moz-linear-gradient(left, rgba(227,227,227,1) 0%, rgba(166,166,166,1) 0%, rgba(178,178,178,0.58) 43%, rgba(186,186,186,0.58) 73%, rgba(201,201,201,0.58) 100%);
   background: -webkit-gradient(left top, right top, color-stop(0%, rgba(227,227,227,1)), color-stop(0%, rgba(166,166,166,1)), color-stop(43%, rgba(178,178,178,0.58)), color-stop(73%, rgba(186,186,186,0.58)), color-stop(100%, rgba(201,201,201,0.58)));
   background: -webkit-linear-gradient(left, rgba(227,227,227,1) 0%, rgba(166,166,166,1) 0%, rgba(178,178,178,0.58) 43%, rgba(186,186,186,0.58) 73%, rgba(201,201,201,0.58) 100%);
   background: -o-linear-gradient(left, rgba(227,227,227,1) 0%, rgba(166,166,166,1) 0%, rgba(178,178,178,0.58) 43%, rgba(186,186,186,0.58) 73%, rgba(201,201,201,0.58) 100%);
   background: -ms-linear-gradient(left, rgba(227,227,227,1) 0%, rgba(166,166,166,1) 0%, rgba(178,178,178,0.58) 43%, rgba(186,186,186,0.58) 73%, rgba(201,201,201,0.58) 100%);
   background: linear-gradient(to right, rgba(227,227,227,1) 0%, rgba(166,166,166,1) 0%, rgba(178,178,178,0.58) 43%, rgba(186,186,186,0.58) 73%, rgba(255, 255, 255, 0.45) 100%);
   filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#e3e3e3', endColorstr='#c9c9c9', GradientType=1 );
   }
   .auto-style1 {
   font-family: Calibri;
   font-size: small;
   }
   table { 
   border-spacing: 3px;
   border-collapse: separate;
   }
   .auto-style2 {
   height: 9px;
   }
   .auto-style3 {
   height: 23px;
   }
   .text-red{
   color:red;
   }
   .auto-style4 {
   height: 56px;
   }
   .auto-style6 {
   font-family: Calibri;
   font-size: small;
   height: 18px;
   }
   .auto-style8 {
   height: 18px;
   }
   .auto-style9 {
   height: 43px;
   }
    .auto-style10 {
        height: 25px;
    }
    .auto-style11 {
        height: 30px;
    }
</style>
<uc:OkMessageBox ID="omb" runat="server" />

<asp:SqlDataSource ID="SqlDataSource200" runat="server" ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"
    DeleteCommand="DELETE FROM [Notificaciones].[CorreosEnviados] WHERE [IdCorreosEnviados] = @IdCorreosEnviados"
    InsertCommand="INSERT INTO [Notificaciones].[CorreosEnviados] ([IdEvento], [Destinatario], [Copia], [Otros], [Asunto], [Cuerpo], [Estado], [IdRegistro], [FechaEnvio], [FechaRegistro], [IdUsuario], [Tipo]) VALUES (@IdEvento, @Destinatario, @Copia, @Otros, @Asunto, @Cuerpo, @Estado, @IdRegistro, @FechaEnvio, @FechaRegistro, @IdUsuario, @Tipo) SET @NewParameter2=SCOPE_IDENTITY();"
    SelectCommand="SELECT [IdCorreosEnviados], [IdEvento], [Destinatario], [Copia], [Otros], [Asunto], [Cuerpo], [Estado], [IdRegistro], [FechaEnvio], [FechaRegistro], [IdUsuario] FROM [Notificaciones].[CorreosEnviados]"
    UpdateCommand="UPDATE [Notificaciones].[CorreosEnviados] SET [FechaEnvio] = @FechaEnvio, [Estado] = @Estado WHERE [IdCorreosEnviados] = @IdCorreosEnviados"
    OnInserted="SqlDataSource200_On_Inserted">
    <DeleteParameters>
        <asp:Parameter Name="IdCorreosEnviados" Type="Decimal" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="IdEvento" Type="Decimal" />
        <asp:Parameter Name="Destinatario" Type="String" />
        <asp:Parameter Name="Copia" Type="String" />
        <asp:Parameter Name="Otros" Type="String" />
        <asp:Parameter Name="Asunto" Type="String" />
        <asp:Parameter Name="Cuerpo" Type="String" />
        <asp:Parameter Name="Estado" Type="String" />
        <asp:Parameter Name="Tipo" Type="String" />
        <asp:Parameter Name="IdRegistro" Type="Decimal" />
        <asp:Parameter Name="FechaEnvio" Type="DateTime" />
        <asp:Parameter Name="FechaRegistro" Type="DateTime" />
        <asp:Parameter Name="IdUsuario" Type="Decimal" />
        <asp:Parameter Direction="Output" Name="NewParameter2" Type="Int32" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Estado" Type="String" />
        <asp:Parameter Name="FechaEnvio" Type="DateTime" />
        <asp:Parameter Name="IdCorreosEnviados" Type="Decimal" />
    </UpdateParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource201" runat="server" ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"
    DeleteCommand="DELETE FROM [Notificaciones].[CorreosRecordatorio] WHERE [IdCorreosRecordatorio] = @IdCorreosRecordatorio"
    InsertCommand="INSERT INTO [Notificaciones].[CorreosRecordatorio] ([IdCorreosEnviados], [NroDiasRecordatorio], [FechaFinal], [Estado], [FechaRegistro], [IdUsuario]) VALUES (@IdCorreosEnviados, @NroDiasRecordatorio, CONVERT(datetime, @FechaFinal, 120), @Estado, @FechaRegistro, @IdUsuario)"
    SelectCommand="SELECT [IdCorreosRecordatorio], [IdCorreosEnviados], [NroDiasRecordatorio], [FechaFinal], [Estado], [FechaRegistro], [IdUsuario] FROM [Notificaciones].[CorreosRecordatorio]"
    UpdateCommand="UPDATE [Estado] = @Estado WHERE [IdCorreosRecordatorio] = @IdCorreosRecordatorio">
    <DeleteParameters>
        <asp:Parameter Name="IdCorreosRecordatorio" Type="Decimal" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="IdCorreosEnviados" Type="Decimal" />
        <asp:Parameter Name="NroDiasRecordatorio" Type="Int32" />
        <asp:Parameter Name="FechaFinal" Type="String" />
        <asp:Parameter Name="Estado" Type="String" />
        <asp:Parameter Name="FechaRegistro" Type="DateTime" />
        <asp:Parameter Name="IdUsuario" Type="Decimal" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Estado" Type="String" />
        <asp:Parameter Name="IdCorreosRecordatorio" Type="Decimal" />
    </UpdateParameters>
</asp:SqlDataSource>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
      <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
         <ProgressTemplate>
            <div id="Background"></div>
            <div id="Progress" align="center">
               <asp:Label ID="Lbl11" runat="server" Text="Procesando, por favor espere..." Font-Names="Calibri" Font-Size="Small"></asp:Label>
               <br />
               <asp:Image ID="Img11" runat="server" ImageUrl="~/Imagenes/Icons/loading.gif" />
            </div>
         </ProgressTemplate>
      </asp:UpdateProgress>
      <table align="center" bgcolor="#EEEEEE">
         <tr align="center" bgcolor="#002649">
            <td>
               <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large" ForeColor="White" Text="Eventos e Incidentes"></asp:Label>
            </td>
         </tr>
         <tr align="center">
            <td>
               <table id="tbGridEventos" runat="server">
                  <tr align="center">
                     <td class="auto-style9">
                        <table>
                           <tr align="left">
                              <td bgcolor="#BBBBBB" align="center" class="auto-style1">
                                 Código:
                              </td>
                              <td bgcolor="#f0eef0">
                                 <asp:TextBox ID="TBCodigo" runat="server" Width="150px" Font-Names="Calibri" Font-Size="Small"></asp:TextBox>
                              </td>
                              <td bgcolor="#BBBBBB" align="center" class="auto-style1">
                                 Descripción
                              </td>
                              <td bgcolor="#f0eef0">
                                 <asp:TextBox ID="TBDescripcion" runat="server" Width="150px" Font-Names="Calibri" Font-Size="Small"></asp:TextBox>
                              </td>
                           </tr>
                           <tr align="left">
                              <td bgcolor="#BBBBBB" align="center" class="auto-style6">
                                 Fecha de registro
                              </td>
                              <td bgcolor="#f0eef0" align="center" class="auto-style8">
                                 <asp:TextBox ID="TBFRegistro" runat="server" Width="150px" Font-Names="Calibri" TextMode="Date" Font-Size="Small"></asp:TextBox>
                              </td>
                              <td class="auto-style8" align="center" colspan="2">
                                 <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png" ToolTip="Consultar" OnClick="BtnBuscarEvento_Click" />
                                 <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png" ToolTip="Cancelar" OnClick="BtnBuscarEventoCancel_Click" />
                              </td>
                           </tr>
                           </tr>
                        </table>
                     </td>
                  </tr>
                  <tr>
                     <td>
                        <table id="TbEvsEIncs" runat="server" visible="false">
                           <tr>
                              <td>
                                 <asp:GridView
                                    ID="GVEvsEIncs"
                                    runat="server"
                                    AutoGenerateColumns="False"
                                    CellPadding="4"
                                    ForeColor="#333333"
                                    GridLines="Vertical"
                                    ShowHeaderWhenEmpty="True"
                                    HeaderStyle-CssClass="gridViewHeader"
                                    BorderStyle="Solid"
                                    HorizontalAlign="Center"
                                    Font-Names="Calibri"
                                    Font-Size="Small"
                                    DataKeyNames="IdEvsEIncs, CodigoEvsEIncs"
                                    HeaderStyle-HorizontalAlign="Center"
                                    OnRowCommand="GVEvsEIncs_RowCommand"
                                    OnPageIndexChanging="GVEvsEIncs_PageIndexChanging"
                                    AllowPaging="True"
                                    >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                       <asp:BoundField HeaderText="Código" DataField="CodigoEvsEIncs">
                                          <ItemStyle HorizontalAlign="Center" />
                                       </asp:BoundField>
                                       <asp:BoundField HeaderText="Descripción" DataField="DescripcionEvento">
                                          <ItemStyle HorizontalAlign="Center" />
                                       </asp:BoundField>
                                       <asp:BoundField HeaderText="Fecha Registro" DataField="FechaRegistro">
                                          <ItemStyle HorizontalAlign="Center" />
                                       </asp:BoundField>
                                       <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/editV5.png" Text="Editar" CommandName="Modificar" />
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
                        </table>
                     </td>
                  </tr>
               </table>
               <table>
                  <tr>
                     <td>
                        <br />
                        <asp:RadioButtonList ID="RBLEventoIncident" runat="server" Style="font-family: Calibri; font-size: medium"
                           OnSelectedIndexChanged="RBLEvsEIncs_SelectedIndexChanged" AutoPostBack="True" TextAlign="Left" RepeatDirection="Horizontal">
                           <asp:ListItem Value="0">Nuevo Evento/Incidente </asp:ListItem>
                           <asp:ListItem Value="1">No hubo eventos </asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                     </td>
                  </tr>
               </table>
               <table id="TbNohuboeventos" runat="server" visible="false" align="center">
                  <tr align="center" bgcolor="#BBBBBB">
                     <td colspan="2">
                        <asp:Label ID="Label118" runat="server" Text="Registro no hubo eventos" Font-Bold="False"
                           Font-Names="Calibri" Font-Size="medium"></asp:Label>
                     </td>
                  </tr>
                  <tr align="left" visible="false">
                     <td bgcolor="#BBBBBB" align="center">
                        <asp:Label ID="Label120" runat="server" Text="Código:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                     </td>
                     <td>
                        <asp:Label ID="Label121" runat="server" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                     </td>
                  </tr>
                  <tr>
                     <td align="center" bgcolor="#BBBBBB">
                        <asp:Label ID="Label122" runat="server" Text="Empresa:" CssClass="Apariencia"></asp:Label>
                     </td>
                     <td align="left">
                        <asp:DropDownList ID="ddlEmpresa" Width="150px" runat="server" CssClass="Apariencia"
                           AutoPostBack="false">
                           <%-- <asp:ListItem Value="---">---</asp:ListItem>
                              <asp:ListItem Value="1">Vida</asp:ListItem>
                              <asp:ListItem Value="2">Generales</asp:ListItem>
                              <asp:ListItem Value="3">Ambas</asp:ListItem>--%>
                        </asp:DropDownList>
                     </td>
                  </tr>
                  <tr runat="server" visible="false">
                     <td align="center" bgcolor="#BBBBBB">
                        <asp:Label ID="LMailEvento" runat="server" Text="Tipo Correo:" CssClass="Apariencia" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                     </td>
                     <td align="left">
                        <asp:DropDownList ID="DDLmailEvent" Width="150px" runat="server" CssClass="Apariencia"
                           AutoPostBack="false">
                           <asp:ListItem Value="---">---</asp:ListItem>
                        </asp:DropDownList>
                     </td>
                  </tr>
                  <tr align="left">
                     <td bgcolor="#BBBBBB" align="center">
                        <asp:Label ID="Label123" runat="server" Text="Fecha Registro:" Font-Names="Calibri"
                           Font-Size="Small"></asp:Label>
                     </td>
                     <td>
                        <asp:TextBox ID="TextBox41" runat="server" Width="150px" Font-Names="Calibri" Font-Size="Small"
                           Enabled="false"></asp:TextBox>
                     </td>
                  </tr>
                  <tr align="left">
                     <td bgcolor="#BBBBBB" align="center">
                        <asp:Label ID="Label124" runat="server" Text="Usuario:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                     </td>
                     <td>
                        <asp:TextBox ID="TextBox42" runat="server" Width="150px" Font-Names="Calibri" Font-Size="Small"
                           Enabled="false"></asp:TextBox>
                     </td>
                  </tr>
                  <tr align="center">
                     <td colspan="2">
                        <table>
                           <tr>
                              <td>
                                 <asp:ImageButton ID="BtnGuardaNoeventos" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                    ValidationGroup="Addne" ToolTip="Guardar" Style="height: 20px" OnClick="BtnGuardaNoeventos_Click" />
                              </td>
                              <td>
                                 <asp:ImageButton ID="BtnCancelaNoeventos" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png"
                                    ToolTip="Cancelar" OnClick="BtnCancelaNoeventos_Click" />
                              </td>
                           </tr>
                        </table>
                     </td>
                  </tr>
               </table>
               <table>
                  <tr>
                     <td>
                        <table id="TbConEventos" runat="server" visible="false" align="center">
                           <tr>
                              <td align="center">
                                 <asp:TabContainer ID="TabContainerEventos" runat="server" ActiveTabIndex="0" Font-Names="Calibri" Font-Size="Small" Width="800px" aling="left" AutoPostBack="true" style="margin-bottom: 0px;">
                                    <asp:TabPanel ID="TabPanelCreaEvento"  runat="server" HeaderText="Creación Evento" Font-Names="Calibri" Font-Size="Small">
                                       <HeaderTemplate>
                                          Creación Evento
                                       </HeaderTemplate>
                                       <ContentTemplate>
                                          <table id="TbTab1" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label36" runat="server" Text="Código del evento:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBHiddenCodigoEvsEIncs" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="23px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label2" runat="server" Text="Fuente del reporte:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBIdEvsEIncs" Enabled="False" Visible="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="16px"></asp:TextBox>
                                                   <asp:DropDownList ID="DDLFuenteReporte" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label3" runat="server" Text="Riesgo global:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLRiesgoGlobal" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small">
                                                   </asp:DropDownList>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label4" runat="server" Text="Estado del reporte:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLEstadoReporte" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label5" runat="server" Text="Código del Banco:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLCodigoBanco" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small"> </asp:DropDownList>
                                                   <asp:Label ID="Label37" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator15" runat="server" ForeColor="Red" ControlToValidate="DDLCodigoBanco" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label6" runat="server" Text="Fecha de Ocurrencia:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFechaOcurrencia" AutoPostBack="True" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="Date" Width="194px"></asp:TextBox>
                                                   <asp:Label ID="Label7" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TBFechaOcurrencia" ForeColor="Red" ValidationGroup="Addne">
                                                      Campo obligatorio
                                                   </asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label8" runat="server" Text="Fecha de Descubrimiento:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFechaDescubrimiento" runat="server" Font-Names="Calibri" AutoPostBack="True" Font-Size="Small" TextMode="Date" Width="194px" OnTextChanged="TBFechaDescubrimiento_TextChanged"></asp:TextBox>
                                                   <asp:Label ID="Label9" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TBFechaDescubrimiento" ForeColor="Red" ValidationGroup="Addne">
                                                      Campo obligatorio
                                                   </asp:RequiredFieldValidator>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label
                                                      ID="Label10"
                                                      runat="server"
                                                      Text="Descripción detallada del evento:"
                                                      Font-Names="Calibri"
                                                      Font-Size="Small"
                                                      ></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBDescripcionEvento" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px"></asp:TextBox>
                                                   <asp:Label ID="Label11" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBDescripcionEvento" ForeColor="Red" ValidationGroup="Addne">
                                                      Campo obligatorio
                                                   </asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label
                                                      ID="Label12"
                                                      runat="server"
                                                      Text="Título del evento:"
                                                      Font-Names="Calibri"
                                                      Font-Size="Small"
                                                      ></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBTituloEvento" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" MaxLength="100"></asp:TextBox>
                                                   <asp:Label ID="Label13" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TBTituloEvento" ForeColor="Red" ValidationGroup="Addne">
                                                      Campo obligatorio
                                                   </asp:RequiredFieldValidator>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label14" runat="server" Text="Categoría:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLCategoria" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="DDLCategoria_SelectedIndexChanged">
                                                   </asp:DropDownList>
                                                   <asp:Label ID="Label15" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator3" runat="server" ForeColor="Red" ControlToValidate="DDLCategoria" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="4" runat="server">
                                                   <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Líneas de Negocio"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label17" runat="server" Text="Modalidad de Ocurrencia:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLModalidad" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small"
                                                      AutoPostBack="True" OnSelectedIndexChanged="DDLModalidad_SelectedIndexChanged">
                                                   </asp:DropDownList>
                                                   <asp:Label ID="Label18" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToValidate="DDLModalidad" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label19" runat="server" Text="Línea de negocio 1 (Nivel 1):" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLFiltroLineaUno" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small"
                                                      AutoPostBack="True" OnSelectedIndexChanged="DDLFiltroLineaUno_SelectedIndexChanged">
                                                   </asp:DropDownList>
                                                   <asp:Label ID="Label20" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator4" runat="server" ForeColor="Red" ControlToValidate="DDLFiltroLineaUno" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label21" runat="server" Text="Línea de negocio 1 (Nivel 2):" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLLineaNegocioUno" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="DDLLineaNegocioUno_SelectedIndexChanged"> </asp:DropDownList>
                                                   <asp:Label ID="Label22" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator5" runat="server" ForeColor="Red" ControlToValidate="DDLLineaNegocioUno" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label23" runat="server" Text="Línea de negocio 2 (Nivel 1):" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLFiltroLineaDos" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small"
                                                      AutoPostBack="True" OnSelectedIndexChanged="DDLFiltroLineaDos_SelectedIndexChanged">
                                                   </asp:DropDownList>
                                                   <asp:Label ID="Label38" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator2" runat="server" ForeColor="Red" ControlToValidate="DDLFiltroLineaDos" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label24" runat="server" Text="Línea de Negocio 2 (Nivel 2):" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLLineaNegocioDos" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="DDLLineaNegocioDos_SelectedIndexChanged"> </asp:DropDownList>
                                                   <asp:Label ID="Label125" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator9" runat="server" ForeColor="Red" ControlToValidate="DDLLineaNegocioDos" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="4" runat="server" class="auto-style2">
                                                   <asp:Label ID="Label25" runat="server" Text="Tipo de Riesgo" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label26" runat="server" Text="Tipo de Riesgo:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList
                                                      ID="DDLTipoRiesgo"
                                                      Width="200px"
                                                      runat="server"
                                                      Font-Names="Calibri"
                                                      Font-Size="Small"
                                                      AutoPostBack="True"
                                                      OnSelectedIndexChanged="DDLTipoRiesgo_SelectedIndexChanged"
                                                      >
                                                   </asp:DropDownList>
                                                   <asp:Label ID="Label126" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator10" runat="server" ForeColor="Red" ControlToValidate="DDLTipoRiesgo" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label27" runat="server" Text="Causa del Riesgo (Nivel 1):" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList
                                                      ID="DDLCausaRiesgoUno"
                                                      Width="200px"
                                                      runat="server"
                                                      Font-Names="Calibri"
                                                      Font-Size="Small"
                                                      AutoPostBack="True"
                                                      OnSelectedIndexChanged="DDLCausaRiesgoUno_SelectedIndexChanged"
                                                      >
                                                   </asp:DropDownList>
                                                   <asp:Label ID="Label127" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator11" runat="server" ForeColor="Red" ControlToValidate="DDLCausaRiesgoUno" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label28" runat="server" Text="Causa del Riesgo (Nivel 2):" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLCausaRiesgoDos" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="DDLCausaRiesgoDos_SelectedIndexChanged"> </asp:DropDownList>
                                                   <asp:Label ID="Label128" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator12" runat="server" ForeColor="Red" ControlToValidate="DDLCausaRiesgoDos" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                             </tr>
                                             <tr  align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="4" runat="server" class="auto-style2">
                                                   <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr  align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label30" runat="server" Text="Factor de Riesgo" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList Enabled="False" ID="DDLFactorRO" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label31" runat="server" Text="Origen:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLOrigen" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small">
                                                   </asp:DropDownList>
                                                   <asp:Label ID="Label32" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator6" runat="server" ForeColor="Red" ControlToValidate="DDLOrigen" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                             </tr>
                                             <tr  align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label33" runat="server" Text="Producto Afectado:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLProductoAfectado" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small">
                                                   </asp:DropDownList>
                                                   <asp:Label ID="Label34" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator7" runat="server" ForeColor="Red" ControlToValidate="DDLProductoAfectado" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label39" runat="server" Text="Monto Bruto de Exposición Inicial:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBMontoBruto" AutoPostBack="True" OnTextChanged="TBMontoBruto_TextChanged" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px"></asp:TextBox>
                                                   <asp:Label ID="Label129" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TBMontoBruto" ForeColor="Red" ValidationGroup="Addne">
                                                      Campo obligatorio
                                                   </asp:RequiredFieldValidator>
                                                   <br>
                                                </td>
                                             </tr>
                                             <tr  align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label40" runat="server" Text="Monto Bruto de Exposición:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox OnTextChanged="TBMontoExposicion_TextChanged" AutoPostBack="true" ID="TBMontoExposicion" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px"></asp:TextBox>
                                                   <asp:Label ID="Label130" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TBMontoExposicion" ForeColor="Red" ValidationGroup="Addne">
                                                      Campo obligatorio
                                                   </asp:RequiredFieldValidator>
                                                   <br>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label41" runat="server" Text="Número de Eventos (Frecuencia)" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox AutoPostBack="True" OnTextChanged="TBValorFrecuencia_TextChanged" ID="TBValorFrecuencia" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px"></asp:TextBox>
                                                   <asp:Label ID="Label35" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TBValorFrecuencia" ForeColor="Red" ValidationGroup="Addne">
                                                      Campo obligatorio
                                                   </asp:RequiredFieldValidator>
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td colspan="4" runat="server">
                                                   <table>
                                                      <tr>
                                                         <td>
                                                            <asp:ImageButton
                                                               ID="BtnGuardar"
                                                               runat="server"
                                                               ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                               ValidationGroup="Addne"
                                                               ToolTip="Guardar"
                                                               Style="height: 20px"
                                                               OnClick="BtnGuardar_Click"
                                                               />
                                                         </td>
                                                         <td>
                                                            <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png" onclientclick="return confirm('¿Desea reiniciar el formulario?');" ToolTip="Cancelar" OnClick="BtnGuardarCancel_Click" />
                                                         </td>
                                                      </tr>
                                                   </table>
                                                </td>
                                             </tr>
                                          </table>
                                       </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="PDA" Font-Names="Calibri" Font-Size="Small">
                                       <HeaderTemplate>
                                          Uso exclusivo de Riesgo
                                       </HeaderTemplate>
                                       <ContentTemplate>
                                          <table id="Table2" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr  align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label42" runat="server" Text="Cuentas Contables de Pérdida:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLCuentasPerdida" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label43" runat="server" Text="Fecha de Registro Contable de la Pérdida:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFRegistroPerdida" runat="server" AutoPostBack="True" Font-Names="Calibri" Font-Size="Small" TextMode="Date" Width="194px" OnTextChanged="TBFRegistroPerdida_TextChanged"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr   runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style4">
                                                   <asp:Label ID="Label44" runat="server" Text="Monto Recuperado por Seguro:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style4">
                                                   <asp:TextBox ID="TBRecuperacionSeguro" AutoPostBack="True" OnTextChanged="TBRecuperacionSeguro_TextChanged" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="196px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style4">
                                                   <asp:Label ID="Label45" runat="server" Text="Monto de Otras Recuperaciones:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style4">
                                                   <asp:TextBox ID="TBRecuperaciones" AutoPostBack="True" OnTextChanged="TBRecuperaciones_TextChanged" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr  align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label46" runat="server" Text="Cuenta donde se registró la recuperación:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBCuentaRecuperacion" AutoPostBack="True" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label47" runat="server" Text="Fecha de Registro Contable de la Recuperación:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFRegistroContable" AutoPostBack="True" OnTextChanged="TBFRegistroContable_TextChanged" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="Date" Width="194px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="4" runat="server">
                                                   <asp:Label ID="Label48" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Con respecto al límite global"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label49" runat="server" Text="Frecuencia Previa" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFrecuenciaPrevia" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="20px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label50" runat="server" Text="Criticidad de la Frecuencia:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList Enabled="False" ID="DDLCriticidad" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small"> </asp:DropDownList>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style11">
                                                   <asp:Label ID="Label51" runat="server" Text="Severidad Previa" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style11">
                                                   <asp:TextBox ID="TBSeveridadPrevia" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="20px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style11">
                                                   <asp:Label
                                                      ID="Label52"
                                                      runat="server"
                                                      Text="Criticidad de la Severidad:"
                                                      Font-Names="Calibri"
                                                      Font-Size="Small"
                                                      ></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style11">
                                                   <asp:DropDownList  ID="DDLCriticidadSeveridadNota" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small" Enabled="False"> </asp:DropDownList>
                                                </td>
                                             </tr>
                                              <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label134" runat="server" Text="Nivel de Riesgo Previo" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNRiesgoPrevio" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="20px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label
                                                      ID="Label135"
                                                      runat="server"
                                                      Text="Nivel de Riesgo (Límite Global):"
                                                      Font-Names="Calibri"
                                                      Font-Size="Small"
                                                      ></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="20px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="4" runat="server">
                                                   <asp:Label ID="Label53" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Límite Específico"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label54" runat="server" Text="Criticidad de la Frecuencia:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLCriticidadFrecuencia" Width="200px" runat="server" Enabled="False" Font-Names="Calibri" Font-Size="Small"> </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label55" runat="server" Text="Criticidad de la Severidad:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList Enabled="false" ID="DDLCriticidadSeveridad" Width="200px" runat="server" Font-Names="Calibri" Font-Size="Small"> </asp:DropDownList>
                                                </td>
                                             </tr>
                                              <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label136" runat="server" Text="Nivel de Riesgo (Límite Específico)" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNRiesgoEspecifico" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="20px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="4" runat="server" height="8px">
                                                   <asp:Label ID="Label56" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label57" runat="server" Text="Estatus del Proceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:DropDownList ID="DDLEstatus" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DDLEstatus_SelectedIndexChanged" runat="server" Font-Names="Calibri" Font-Size="Small">
                                                   </asp:DropDownList>
                                                   <asp:Label ID="Label58" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:CompareValidator ID="CompareValidator8" runat="server" ForeColor="Red" ControlToValidate="DDLEstatus" ValidationGroup="Addne" ValueToCompare="0" Operator="NotEqual">
                                                      Campo obligatorio
                                                   </asp:CompareValidator>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label59" runat="server" Text="Fecha de Cierre:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" ID="TDCierre" visible="False">
                                                   <asp:TextBox ID="TBFCierre" OnTextChanged="TBFCierre_TextChanged" AutoPostBack="True" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="Date" Width="200px"></asp:TextBox>
                                                   <asp:Label ID="Label60" runat="server" Text="*" CssClass="text-red" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TBFCierre" ForeColor="Red" ValidationGroup="Addne">
                                                      Campo obligatorio
                                                   </asp:RequiredFieldValidator>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label61" runat="server" Text="NOTAS" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNotas" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td colspan="4" runat="server">
                                                   <table>
                                                      <tr>
                                                         <td>
                                                            <asp:ImageButton
                                                               ID="BtnGuardarTodo"
                                                               runat="server"
                                                               ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                               ValidationGroup="AddneR"
                                                               ToolTip="Guardar"
                                                               Style="height: 20px"
                                                               OnClick="BtnGuardarTodo_Click"
                                                               />
                                                         </td>
                                                         <td>
                                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png" ToolTip="Cancelar" />
                                                         </td>
                                                      </tr>
                                                   </table>
                                                </td>
                                             </tr>
                                          </table>
                                       </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="PDA" Font-Names="Calibri" Font-Size="Small">
                                       <HeaderTemplate>
                                          Justificación de cambios
                                       </HeaderTemplate>
                                       <ContentTemplate>
                                          <table id="Table8" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label119" runat="server" Text="Descripción de cambios:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr  align="center" runat="server">
                                                <td runat="server">
                                                   <asp:TextBox ID="TBJustificacion" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="272px" Height="91px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <table id="TblJustificacion" runat="server">
                                                      <tr align="center" bgcolor="#002649" runat="server">
                                                         <td runat="server">
                                                            <asp:Label ID="Label117" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                                                               ForeColor="White" Text="Trazabilidad de cambios"></asp:Label>
                                                         </td>
                                                      </tr>
                                                      <tr runat="server">
                                                         <td runat="server">
                                                            <asp:GridView ID="GVJustificacion" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                               ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True"
                                                               BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small"
                                                               DataKeyNames="IdJustificacion_EvsEIncs,Justificacion,Usuario,FechaRegistro" 
                                                               OnPageIndexChanging="GVJustificacion_PageIndexChanging"
                                                               OnRowCommand="GVJustificacion_RowCommand"
                                                               AllowPaging="True" AllowSorting="True">
                                                               <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                               <Columns>
                                                                  <asp:BoundField HeaderText="Código" DataField="IdJustificacion_EvsEIncs">
                                                                     <ItemStyle HorizontalAlign="Center" />
                                                                  </asp:BoundField>
                                                                  <asp:BoundField HeaderText="Descripción" DataField="Justificacion">
                                                                     <ItemStyle HorizontalAlign="Center" />
                                                                  </asp:BoundField>
                                                                  <asp:BoundField HeaderText="Usuario" DataField="Usuario">
                                                                     <ItemStyle HorizontalAlign="Center" />
                                                                  </asp:BoundField>
                                                                  <asp:BoundField HeaderText="Fecha" DataField="FechaRegistro">
                                                                     <ItemStyle HorizontalAlign="Center" />
                                                                  </asp:BoundField>
                                                                  <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/Literal.png" Text="Ver"
                                                                     CommandName="Ver" />
                                                               </Columns>
                                                               <EditRowStyle BackColor="#999999" />
                                                               <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                               <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" CssClass="gridViewHeader" HorizontalAlign="Center" />
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
                                                   </table>
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td runat="server">
                                                   <table>
                                                      <tr>
                                                         <td>
                                                            <asp:ImageButton
                                                               ID="GuardarTodo1"
                                                               runat="server"
                                                               ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                               ValidationGroup="AddneR"
                                                               ToolTip="Guardar"
                                                               Style="height: 20px; width: 20px;"
                                                               OnClick="BtnGuardarTodo_Click"
                                                               />
                                                         </td>
                                                         <td>
                                                            <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png" ToolTip="Cancelar" style="width: 28px" />
                                                         </td>
                                                      </tr>
                                                   </table>
                                                </td>
                                             </tr>
                                          </table>
                                       </ContentTemplate>
                                    </asp:TabPanel>
                                 </asp:TabContainer>
                              </td>
                           </tr>
                        </table>
                     </td>
                  </tr>
                  <tr>
                     <td>
                        <table id="TbRelMultiple" runat="server" visible="false" align="center">
                           <tr align="center" runat="server">
                              <td bgcolor="#BBBBBB" runat="server">
                                 <asp:Label ID="Label63" runat="server" Font-Names="Calibri" Font-Size="Small" Text="RELACIONES MÚLTIPLES"></asp:Label>
                              </td>
                           </tr>
                           <tr>
                              <td align="center">
                                 <asp:TabContainer ID="TabContainer16" runat="server" ActiveTabIndex="0" Font-Names="Calibri" Font-Size="Small" Width="888px" aling="left" AutoPostBack="true" style="margin-bottom: 0px;">
                                     <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="PDA" Font-Names="Calibri" Font-Size="Small">
                                       <HeaderTemplate>
                                          Documentos Adjuntos
                                       </HeaderTemplate>
                                       <ContentTemplate>
                                          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                             <ContentTemplate>
                                                <asp:FileUpload ID="FUEventoArchivo" runat="server" />
                                                 <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Extensión permitida: PDF" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.pdf)$" ControlToValidate="FUEventoArchivo">
                                                </asp:RegularExpressionValidator>
                                                <asp:Button ID="BtnSubirArchivo" runat="server" Text="Subir Archivo" OnClick="BtnSubirArchivo_Click" />
                                             </ContentTemplate>
                                             <Triggers>
                                                <asp:PostBackTrigger ControlID="BtnSubirArchivo" />
                                             </Triggers>
                                          </asp:UpdatePanel>
                                          <table id="TbArchivos" runat="server">
                                              <tr align="center" runat="server">
                                                <td runat="server" class="auto-style10" >
                                                </td>
                                             </tr>
                                             <tr align="center" bgcolor="#002649" runat="server">
                                                <td runat="server">
                                                   <asp:Label ID="Label133" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                                                      ForeColor="White" Text="Archivos del Evento"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <asp:GridView ID="GVArchivos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                      ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True"
                                                      BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small"
                                                      DataKeyNames="IdArchivo,UrlArchivo,Usuario,FechaRegistro" 
                                                      OnPageIndexChanging="GVArchivos_PageIndexChanging"
                                                      OnRowCommand="GVArchivos_RowCommand"
                                                      AllowPaging="True" AllowSorting="True">
                                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                      <Columns>
                                                         <asp:BoundField HeaderText="Código" DataField="IdArchivo">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Nombre" DataField="UrlArchivo">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Usuario" DataField="Usuario">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Fecha" DataField="FechaRegistro">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/downloads.png" Text="Descargar"
                                                            CommandName="Descargar" />
                                                      </Columns>
                                                      <EditRowStyle BackColor="#999999" />
                                                      <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                      <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" CssClass="gridViewHeader" HorizontalAlign="Center" />
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
                                          </table>
                                       </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Planes" Font-Names="Calibri" Font-Size="Small">
                                       <HeaderTemplate>
                                          Planes
                                       </HeaderTemplate>
                                       <ContentTemplate>
                                          <table id="Table4" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="6" runat="server">
                                                   <asp:Label ID="Label106" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Buscar Planes"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label64" runat="server" Text="Código:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:TextBox ID="TBBCodigoPlan" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label65" runat="server" Text="Nombre:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:TextBox ID="TBBNombrePlan" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:ImageButton ID="BtnBuscarPlan" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png" ToolTip="Consultar" OnClick="BtnBuscarPlan_Click" />
                                                </td>
                                                <td class="auto-style3" runat="server">
                                                   <asp:ImageButton ID="BtnBuscarPlanCancel" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png" ToolTip="Cancelar" OnClick="BtnBuscarPlanCancel_Click" />
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                          </table>
                                          <table id="TbPlanes" runat="server" visible="False">
                                             <tr align="center" bgcolor="#002649" runat="server">
                                                <td runat="server">
                                                   <asp:Label id="Label66" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                                                      ForeColor="White" Text="Planes de Acción"></asp:Label>
                                                   <asp:Label id="LCodEvsEIncs" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                                                      ForeColor="White"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <asp:GridView ID="GVPlanes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                      ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True"
                                                      BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small"
                                                      DataKeyNames="Id,CodigoPlan,NombrePlan,DescripcionPlan,Responsable,Estado,FechaCompromiso,FechaExtension,FechaImplementacion,FechaRegistro,Usuario" 
                                                      OnPageIndexChanging="GVPlanes_PageIndexChanging"
                                                      OnRowCommand="GVPlanes_RowCommand"
                                                      AllowPaging="True" AllowSorting="True">
                                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                      <Columns>
                                                         <asp:BoundField HeaderText="Código Plan" DataField="CodigoPlan" >
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Nombre Plan" DataField="NombrePlan" >
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="FechaImplementacion" DataField="FechaImplementacion" >
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Estado" DataField="Estado" >
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Relación" DataField="Relacion" >
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/Literal.png" Text="Ver"
                                                            CommandName="Ver" />
                                                         <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/enlace.png" Text="Enlazar"
                                                            CommandName="DesEnlazar" />
                                                      </Columns>
                                                      <EditRowStyle BackColor="#999999" />
                                                      <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                      <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" CssClass="gridViewHeader" HorizontalAlign="Center" />
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
                                          </table>
                                          <table id="Table3" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="6" runat="server">
                                                   <asp:Label ID="Label67" runat="server" Font-Names="Calibri" Font-Size="Small" Text="PLAN DE ACCIÓN"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label68" runat="server" Text="Código:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBIdPlan" Enabled="False" Visible="False" runat="server"></asp:TextBox>
                                                   <asp:TextBox ID="TBCodigoPlan" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label69" runat="server" Text="Nombre:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNombrePlan" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label70" runat="server" Text="Descripción:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBDescripcionPlan" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label71" runat="server" Text="Responsable:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBResponsable" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label72" runat="server" Text="Estado:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBEstado" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label73" runat="server" Text="Fecha Compromiso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFechaCompromiso" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label131" runat="server" Text="Fecha Extensión:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFechaExtension" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label132" runat="server" Text="Fecha Implementación:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFechaImplementacion" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label74" runat="server" Text="Fecha Registro:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFechaRegistro" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label75" runat="server" Text="Usuario:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBUsuario" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label76" runat="server" Text="Asociar/Desasociar" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" align="center">
                                                   <asp:ImageButton
                                                      ID="BtnDesEnlazarPlan"
                                                      runat="server"
                                                      ImageUrl="~/Imagenes/Icons/enlace.png"
                                                      ToolTip="DesEnlazar"
                                                      OnClick="BtnDesEnlazarPlan_Click" Height="20px" Width="26px"
                                                      />
                                                </td>
                                             </tr>
                                          </table>
                                       </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Riesgos" Font-Names="Calibri" Font-Size="Small" OnActiveTabChanged="GVRiesgos_reload">
                                       <HeaderTemplate>
                                          Riesgos
                                       </HeaderTemplate>
                                       <ContentTemplate>
                                          <table id="Table5" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="6" runat="server">
                                                   <asp:Label ID="Label77" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Buscar Riesgos"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label78" runat="server" Text="Cadena Valor:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:DropDownList ID="DDLBCadenaValor" AutoPostBack="True" OnSelectedIndexChanged="DDLBCadenaValor_SelectedIndexChanged" runat="server" Font-Names="Calibri" Font-Size="Small" Width="194px" Height="22px">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label79" runat="server" Text="Macroproceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:DropDownList ID="DDLBMacroproceso" AutoPostBack="True" OnSelectedIndexChanged="DDLBMacroproceso_SelectedIndexChanged" runat="server" Font-Names="Calibri" Font-Size="Small" Width="194px" Height="22px">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label80" runat="server" Text="Proceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:DropDownList ID="DDLBProceso" AutoPostBack="True" OnSelectedIndexChanged="DDLBProceso_SelectedIndexChanged" runat="server" Font-Names="Calibri" Font-Size="Small" Width="194px" Height="22px">
                                                   </asp:DropDownList>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label81" runat="server" Text="Subproceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:DropDownList ID="DDLBSubproceso" AutoPostBack="True" OnSelectedIndexChanged="DDLBSubproceso_SelectedIndexChanged" runat="server" Font-Names="Calibri" Font-Size="Small" Width="194px" Height="22px">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label82" runat="server" Text="Actividad:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:DropDownList ID="DDLBActividad" runat="server" Font-Names="Calibri" Font-Size="Small" Width="194px" Height="22px">
                                                   </asp:DropDownList>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label83" runat="server" Text="Código:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:TextBox ID="TBBIdRiesgo" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px" ReadOnly="True" Visible="False"></asp:TextBox>
                                                   <asp:TextBox ID="TBBCodigoRiesgo" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label84" runat="server" Text="Nombre:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:TextBox ID="TBBNombreRiesgo" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:ImageButton ID="BtnBuscarRiesgo" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png" ToolTip="Consultar" OnClick="BtnBuscarRiesgo_Click" />
                                                </td>
                                                <td class="auto-style3" runat="server">
                                                   <asp:ImageButton ID="BtnBuscarRiesgoCancel" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png" ToolTip="Cancelar" OnClick="BtnBuscarRiesgoCancel_Click" />
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                          </table>
                                          <table id="TbRiesgos" runat="server" visible="False">
                                             <tr align="center" bgcolor="#002649" runat="server">
                                                <td runat="server">
                                                   <asp:Label ID="Label85" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                                                      ForeColor="White" Text="Riesgos"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <asp:GridView ID="GVRiesgos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                      ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True"
                                                      BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small"
                                                      DataKeyNames="IdRiesgo,Codigo,Nombre,Descripcion,NCadenaValor,NMacroproceso,NProceso,NSubproceso,NActividad,FechaRegistro" 
                                                      OnPageIndexChanging="GVRiesgos_PageIndexChanging"
                                                      OnRowCommand="GVRiesgos_RowCommand"
                                                      AllowPaging="True" AllowSorting="True">
                                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                      <Columns>
                                                         <asp:BoundField HeaderText="Código" DataField="Codigo">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Nombre" DataField="Nombre">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Relación" DataField="Relacion">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/Literal.png" Text="Ver"
                                                            CommandName="Ver" />
                                                         <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/enlace.png" Text="Enlazar"
                                                            CommandName="DesEnlazar" />
                                                      </Columns>
                                                      <EditRowStyle BackColor="#999999" />
                                                      <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                      <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" CssClass="gridViewHeader" HorizontalAlign="Center" />
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
                                          </table>
                                          <table id="Table6" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="6" runat="server" class="auto-style4">
                                                   <asp:Label ID="Label86" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Riesgo"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label87" runat="server" Text="Código:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBIdRiesgo" Enabled="False" Visible="False" runat="server"></asp:TextBox>
                                                   <asp:TextBox ID="TBCodigoRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label88" runat="server" Text="Nombre:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNombreRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label89" runat="server" Text="Descripcion:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBDescripcionRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label90" runat="server" Text="Cadena Valor:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNCadenaValorRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label91" runat="server" Text="Macroproceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNMacroprocesoRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label92" runat="server" Text="Proceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNProcesoRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label93" runat="server" Text="Subproceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNSubprocesoRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label94" runat="server" Text="Actividad:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBNActividadRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label95" runat="server" Text="FechaRegistro:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBFechaRegistroRiesgo" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td align="center" runat="server">
                                                </td>
                                                <td runat="server" align="center">
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label96" runat="server" Text="Asociar/Desasociar" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" align="center">
                                                   <asp:ImageButton
                                                      ID="BtnDesEnlazarRiesgo"
                                                      runat="server"
                                                      ImageUrl="~/Imagenes/Icons/enlace.png"
                                                      ToolTip="DesEnlazar"
                                                      OnClick="BtnDesEnlazarRiesgo_Click" Height="20px" Width="26px" />
                                                </td>
                                             </tr>
                                          </table>
                                       </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="PDA" Font-Names="Calibri" Font-Size="Small">
                                       <HeaderTemplate>
                                          Proceso Originador
                                       </HeaderTemplate>
                                       <ContentTemplate>
                                          <table id="Table7" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="6" runat="server">
                                                   <asp:Label ID="Label97" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Buscar Procesos"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label98" runat="server" Text="Macroproceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:DropDownList ID="DDLBPOMacroproceso" runat="server" Font-Names="Calibri" Font-Size="Small" Width="194px" Height="22px">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label99" runat="server" Text="Nombre:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:TextBox ID="TBBPONombre" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png" ToolTip="Consultar" OnClick="BtnBuscarProcesoO_Click" />
                                                </td>
                                                <td class="auto-style3" runat="server">
                                                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png" ToolTip="Cancelar" OnClick="BtnBuscarProcesoOCancel_Click"/>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                          </table>
                                          <table id="TbProcesoO" runat="server" visible="False">
                                             <tr align="center" bgcolor="#002649" runat="server">
                                                <td runat="server">
                                                   <asp:Label ID="Label100" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                                                      ForeColor="White" Text="Proceso Originador"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <asp:GridView ID="GVProcesoO" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                      ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True"
                                                      BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small"
                                                      DataKeyNames="IdProceso, NMacroProceso, Nombre, Descripcion, FechaRegistro, Relacion" 
                                                      OnPageIndexChanging="GVProcesoO_PageIndexChanging"
                                                      OnRowCommand="GVProcesoO_RowCommand"
                                                      AllowPaging="True" AllowSorting="True">
                                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                      <Columns>
                                                         <asp:BoundField HeaderText="Código" DataField="IdProceso">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Nombre" DataField="Nombre">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Relación" DataField="Relacion">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/Literal.png" Text="Ver"
                                                            CommandName="Ver" />
                                                         <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/enlace.png" Text="Enlazar"
                                                            CommandName="DesEnlazar" />
                                                      </Columns>
                                                      <EditRowStyle BackColor="#999999" />
                                                      <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                      <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" CssClass="gridViewHeader" HorizontalAlign="Center" />
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
                                          </table>
                                          <table id="Table9" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="6" runat="server" class="auto-style4">
                                                   <asp:Label ID="Label101" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Proceso Originador"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label102" runat="server" Text="Macroproceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBIdProcesoO" Enabled="False" Visible="False" runat="server"></asp:TextBox>
                                                   <asp:TextBox ID="TBNPOMacroproceso" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label103" runat="server" Text="Nombre:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBPONombre" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label104" runat="server" Text="Descripción:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBPODescripcion" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label115" runat="server" Text="FechaRegistro:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBPOFechaRegistro" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label105" runat="server" Text="Asociar/Desasociar" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" align="center">
                                                   <asp:ImageButton
                                                      ID="ImageButton5"
                                                      runat="server"
                                                      ImageUrl="~/Imagenes/Icons/enlace.png"
                                                      ToolTip="Enlazar/DesEnlazar"
                                                      OnClick="BtnDesEnlazarProcesoO_Click" Height="20px" Width="26px" />
                                                </td>
                                             </tr>
                                          </table>
                                       </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="PDA" Font-Names="Calibri" Font-Size="Small">
                                       <HeaderTemplate>
                                          Proceso Afectado
                                       </HeaderTemplate>
                                       <ContentTemplate>
                                          <table id="Table1" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="6" runat="server">
                                                   <asp:Label ID="Label62" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Buscar Procesos"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label107" runat="server" Text="Macroproceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:DropDownList ID="DDLBPAMacroproceso" runat="server" Font-Names="Calibri" Font-Size="Small" Width="194px" Height="22px">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server" class="auto-style3">
                                                   <asp:Label ID="Label108" runat="server" Text="Nombre:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:TextBox ID="TBBPANombre" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td runat="server" class="auto-style3">
                                                   <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png" ToolTip="Consultar" OnClick="BtnBuscarProcesoA_Click"/>
                                                </td>
                                                <td class="auto-style3" runat="server">
                                                   <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png" ToolTip="Cancelar" OnClick="BtnBuscarProcesoACancel_Click"/>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                          </table>
                                          <table id="TbProcesoA" runat="server" visible="False">
                                             <tr align="center" bgcolor="#002649" runat="server">
                                                <td runat="server">
                                                   <asp:Label ID="Label109" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                                                      ForeColor="White" Text="Proceso Afectado"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td runat="server">
                                                   <asp:GridView ID="GVProcesoA" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                      ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True"
                                                      BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small"
                                                      DataKeyNames="IdProceso, NMacroProceso, Nombre, Descripcion, FechaRegistro, Relacion" 
                                                      OnPageIndexChanging="GVProcesoA_PageIndexChanging"
                                                      OnRowCommand="GVProcesoA_RowCommand"
                                                      AllowPaging="True" AllowSorting="True">
                                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                      <Columns>
                                                         <asp:BoundField HeaderText="Código" DataField="IdProceso">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Nombre" DataField="Nombre">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField HeaderText="Relación" DataField="Relacion">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/Literal.png" Text="Ver"
                                                            CommandName="Ver" />
                                                         <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/enlace.png" Text="Enlazar"
                                                            CommandName="DesEnlazar" />
                                                      </Columns>
                                                      <EditRowStyle BackColor="#999999" />
                                                      <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                      <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" CssClass="gridViewHeader" HorizontalAlign="Center" />
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
                                          </table>
                                          <table id="Table10" runat="server" align="center">
                                             <tr runat="server">
                                                <td runat="server">
                                                   <br />
                                                </td>
                                             </tr>
                                             <tr align="center" runat="server">
                                                <td bgcolor="#BBBBBB" colspan="6" runat="server" class="auto-style4">
                                                   <asp:Label ID="Label110" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Proceso Afectado"></asp:Label>
                                                </td>
                                             </tr>
                                             <tr align="left" runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label111" runat="server" Text="Macroproceso:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBIdProcesoA" Enabled="False" Visible="False" runat="server"></asp:TextBox>
                                                   <asp:TextBox ID="TBNPAMacroproceso" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label112" runat="server" Text="Nombre:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBPANombre" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label113" runat="server" Text="Descripción:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBPADescripcion" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                             </tr>
                                             <tr runat="server">
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label116" runat="server" Text="FechaRegistro:" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server">
                                                   <asp:TextBox ID="TBPAFechaRegistro" Enabled="False" runat="server" Font-Names="Calibri" Font-Size="Small" TextMode="MultiLine" Width="194px" Height="22px"></asp:TextBox>
                                                </td>
                                                <td align="center" bgcolor="#BBBBBB" runat="server">
                                                   <asp:Label ID="Label114" runat="server" Text="Asociar/Desasociar" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                </td>
                                                <td runat="server" align="center">
                                                   <asp:ImageButton
                                                      ID="ImageButton8"
                                                      runat="server"
                                                      ImageUrl="~/Imagenes/Icons/enlace.png"
                                                      ToolTip="DesEnlazar"
                                                      Height="20px" Width="26px" OnClick="BtnDesEnlazarProcesoA_Click"/>
                                                </td>
                                             </tr>
                                          </table>
                                       </ContentTemplate>
                                    </asp:TabPanel>
                                 </asp:TabContainer>
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
               <td colspan="2" align="center" runat="server" id="tdCaption">
                  &nbsp;
                  <asp:Label ID="lblCaption" runat="server" Text="Atención" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                  <br />
               </td>
            </tr>
            <tr>
               <td style="width: 60px" valign="middle" align="center">
                  <asp:Image ID="imgInfo" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-ok.png" />
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
   </ContentTemplate>
</asp:UpdatePanel>