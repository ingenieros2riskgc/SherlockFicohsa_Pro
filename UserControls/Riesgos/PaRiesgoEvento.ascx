<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaRiesgoEvento.ascx.cs" Inherits="ListasSarlaft.UserControls.Riesgos.PaRiesgoEvento" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>

<script type="text/javascript">
    function fnClick(sender, e) {
        __doPostBack(sender, e);
    }
</script>
<script src="/JS/jquery.min.js"></script>
<script src="/JS/jsFunciones.js"></script>
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

    .autocomplete_completionListElement {
        margin: 0px !important;
        background-color: inherit;
        color: windowtext;
        border: buttonshadow;
        border-width: 1px;
        cursor: 'default';
        overflow: auto;
        height: 200px;
        text-align: left;
        list-style-type: none;
    }
    /* AutoComplete highlighted item */
    .autocomplete_highlightedListItem {
        background-color: #ffff99;
        color: black;
        padding: 1px;
    }
    /* AutoComplete item */
    .autocomplete_listItem {
        background-color: window;
        color: windowtext;
        padding: 1px;
    }
    .FiltroPlanes{
        text-align: center;
        width: 29%;
        margin-left: 36%;
        border: solid 1px #999999;
        margin-top: 22px;
        margin-bottom: 10px;
    }

    .EtiquetaCarga, .ArchivosCargados, .Justificacion, .jCambios, .pRiesgosAsociados, .sAsociados, .pkJustificacion{
        margin: 18px 0 7px 0;
        font-family: Calibri;
        font-size: Small;color: #4d4d4d;
    }
    .EtiquetaCarga,  .RAsociados, .EAsociados{
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
    .pJustificacion{
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
        background: linear-gradient(to right, rgba(227,227,227,1) 0%, rgba(166,166,166,1) 0%, rgba(178,178,178,0.58) 43%, rgba(186,186,186,0.58) 73%, rgba(201,201,201,0.31) 100%);
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#e3e3e3', endColorstr='#c9c9c9', GradientType=1 );

    }
    .pRiesgosAsociados, .sAsociados{
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
        background: linear-gradient(to right, rgba(227,227,227,1) 0%, rgba(166,166,166,1) 0%, rgba(178,178,178,0) 43%, rgba(186,186,186,0.21) 73%, rgba(201,201,201,0.31) 100%);
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#e3e3e3', endColorstr='#c9c9c9', GradientType=1 );

    }
    .auto-style1 {
        height: 34px;
    }
</style>

<asp:SqlDataSource ID="SqlDataSource200" runat="server" ConnectionString="<%$ ConnectionStrings:Sherlock_TestConnectionString %>"
    DeleteCommand="DELETE FROM [Notificaciones].[CorreosEnviados] WHERE [IdCorreosEnviados] = @IdCorreosEnviados"
    InsertCommand="INSERT INTO [Notificaciones].[CorreosEnviados] ([IdEvento], [Destinatario], [Copia], [Otros], [Asunto], [Cuerpo], [Estado], [IdRegistro], [FechaEnvio], [FechaRegistro], [IdUsuario], [Tipo]) VALUES (@IdEvento, @Destinatario, @Copia, @Otros, @Asunto, @Cuerpo, @Estado, @IdRegistro, @FechaEnvio, @FechaRegistro, @IdUsuario, @Tipo) SET @NewParameter2=SCOPE_IDENTITY();"
    SelectCommand="SELECT [IdCorreosEnviados], [IdEvento], [Destinatario], [Copia], [Otros], [Asunto], [Cuerpo], [Estado], [IdRegistro], [FechaEnvio], [FechaRegistro], [IdUsuario] FROM [Notificaciones].[CorreosEnviados]"
    UpdateCommand="UPDATE [Notificaciones].[CorreosEnviados] SET [FechaEnvio] = @FechaEnvio, [Estado] = @Estado WHERE [IdCorreosEnviados] = @IdCorreosEnviados"
    OnInserted="SqlDataSource200_On_Inserted" ProviderName="<%$ ConnectionStrings:Sherlock_TestConnectionString.ProviderName %>">
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
    UpdateCommand="UPDATE [Estado] = @Estado WHERE [IdCorreosRecordatorio] = @IdCorreosRecordatorio" OnSelecting="SqlDataSource201_Selecting">
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

<%--Modal confirmacion para desasociar riesgo - Yoendy--%>
<asp:ModalPopupExtender ID="MPRiesgo" runat="server" TargetControlID="btndummy1"
    PopupControlID="pnlMsgBox1" OkControlID="btnCancelar" BackgroundCssClass="FondoAplicacion"
    Enabled="True" DropShadow="true">
</asp:ModalPopupExtender>
<asp:Button ID="btndummy1" runat="server" Text="Button1" Style="display: none" />
<asp:Panel ID="pnlMsgBox1" runat="server" Width="400px" Style="display: none;" BorderColor="#575757"
    BackColor="#FFFFFF" BorderStyle="Solid">
    <table width="100%">
        <tr class="topHandle" style="background-color: #5D7B9D">
            <td colspan="2" align="center" runat="server" id="td1">&nbsp;
                        <asp:Label ID="lblMsgBoxOkNoAI" runat="server" Text="Atención" Font-Names="Calibri" Font-Size="Small"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px" valign="middle" align="center">
                <asp:Image ID="imgInfo1" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
            </td>
            <td valign="middle" align="left">
                <asp:Label ID="MensajeModalRiesgo" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr align="right">
            <td align="right" colspan="2">
                <asp:Button ID="EliminarRiesgo" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Ok" OnClick="EliminarRiesgo_Click" />
                <asp:Button ID="btnCancelar" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Cancelar" />
            </td>
        </tr>       
    </table>
</asp:Panel>

<%--Modal confirmacion para desasociar evento - Yoendy--%>
<asp:ModalPopupExtender ID="MPEvento" runat="server" TargetControlID="btndummy2"
    PopupControlID="PCEvento" OkControlID="CancelarDE" BackgroundCssClass="FondoAplicacion"
    Enabled="True" DropShadow="true">
</asp:ModalPopupExtender>
<asp:Button ID="btndummy2" runat="server" Text="Button1" Style="display: none" />
<asp:Panel ID="PCEvento" runat="server" Width="400px" Style="display: none;" BorderColor="#575757"
    BackColor="#FFFFFF" BorderStyle="Solid">
    <table width="100%">
        <tr class="topHandle" style="background-color: #5D7B9D">
            <td colspan="2" align="center" runat="server" id="td2">&nbsp;
                        <asp:Label ID="Label13" runat="server" Text="Atención" Font-Names="Calibri" Font-Size="Small"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px" valign="middle" align="center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
            </td>
            <td valign="middle" align="left">
                <asp:Label ID="MensajeModalEvento" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr align="right">
            <td align="right" colspan="2">
                <asp:Button ID="EliminarEvento" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Ok" OnClick="EliminarEvento_Click" />
                <asp:Button ID="CancelarDE" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Cancelar" />
            </td>
        </tr>
    </table>
</asp:Panel>

<%--Modal agregar cumplimiento - Yoendy--%>
<asp:ModalPopupExtender ID="MPCumplimiento" runat="server" TargetControlID="btndummy4"
    PopupControlID="PCCumplimiento" OkControlID="CancelarC" BackgroundCssClass="FondoAplicacion"
    Enabled="True" DropShadow="true">
</asp:ModalPopupExtender>
<asp:Button ID="btndummy4" runat="server" Text="Button1" Style="display: none" />
<asp:Panel ID="PCCumplimiento" runat="server" Width="400px" Style="display: none;" BorderColor="#575757"
    BackColor="#FFFFFF" BorderStyle="Solid">
    <table width="100%">
        <tr class="topHandle" style="background-color: #5D7B9D">
            <td colspan="2" align="center" runat="server" id="td3">&nbsp;
                        <asp:Label ID="Label9" runat="server" Text="Atención" Font-Names="Calibri" Font-Size="Small"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px" valign="middle" align="center">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
            </td>
            <td valign="middle" align="left">
                <div>
                    <table align="Left">
                                                                <tr>
                                                                    <td align="center" bgcolor="#BBBBBB" style="width: 173px;">
                                                                        <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Fecha Revisión"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="Periodo2" runat="server" autocomplete="off" Font-Names="Calibri" Font-Size="Small" MaxLength="10" placeholder="AAAA/MM/dd" Width="150px"></asp:TextBox>
                                                                        <asp:CalendarExtender ID="FehaPeriodoM" runat="server" BehaviorID="_content_FechaPeriodoM_CalendarExtender" Format="yyyy-MM-dd" TargetControlID="Periodo2" />
                                                                    </td>
                                                                </tr>
                                                                <tr align="left">
                                                                    <td align="center" bgcolor="#BBBBBB">
                                                                        <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Meta"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="Meta2" runat="server" autocomplete="off" Font-Names="Calibri" Font-Size="Small" MaxLength="3" onchange="SoloNumerosMaxCien(this);" onkeyup="SoloNumerosMaxCien(this);" placeholder="Meta" Width="150px"></asp:TextBox>
                                                                    </td>
                                                                </tr>                                                                
                                                            </table>

                </div>

                <div style="text-align: center; margin-top: 2%; margin-right: 25%;>
                    <asp:Label ID="Label18" runat="server" Text="Meta:" Font-Names="Calibri" Font-Size="Small" Visible="false"></asp:Label>
                    <asp:Label ID="ModalMeta" runat="server" Text="Meta" Font-Names="Calibri" Font-Size="Small" Font-Bold="true" Visible="false"></asp:Label>
                </div>
                <div style="text-align: center; margin-top: 2%; margin-right: 25%;">
                    <asp:Label ID="MensajeModalCumplimiento" runat="server" Text="Gestión" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                    <asp:TextBox ID="ModalGestion" runat="server" Autofocus="true" MaxLength="3" Width="20%"
                        Style="text-align: center;" ToolTip="% Gestión"
                        onkeyup="SoloNumerosMaxCien(this);" onchange="SoloNumerosMaxCien(this);"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr align="right">
            <td align="right" colspan="2">
                <asp:Button ID="GuardarCumplimiento" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Ok" OnClick="GuardarCumplimiento_Click"/>
                <asp:Button ID="CancelarC" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Cancelar" OnClick="CancelarC_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:UpdatePanel ID="Tbody" runat="server">
    <ContentTemplate>
        <uc:OkMessageBox ID="omb" runat="server" />
        <%--Parte I - Grilla Principal - Planes--%>
        <div style="text-align: -webkit-center;">
            <table>
                <tr align="center" bgcolor="#002649">
                    <td>
                        <asp:Label ID="Label140" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                            ForeColor="White" Text="Planes de Acción"></asp:Label>
                        <asp:Label ID="LCodRiesgo" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                            ForeColor="White" Text=""></asp:Label>
                    </td>
                </tr>


                <tr align="left">
                    <td align="center" >
                        <asp:Label ID="LblEstadoFiltro" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Estado: "></asp:Label>
                        <asp:DropDownList ID="ddlEstadoFiltro" runat="server" AutoPostBack="True" Font-Names="Calibri" Font-Size="Small" OnSelectedIndexChanged="EstadoPlan_SelectedIndexChanged" Width="200px">
                            <asp:ListItem Value="0">---</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr align="left">
                                        <td align="center">
                                            <asp:Label ID="Label42" runat="server" Text="Área: " Font-Size="Small" Font-Names="Calibri"></asp:Label>
                                            <asp:DropDownList ID="DDLArea" runat="server" Font-Names="Calibri" Font-Size="Small" Width="155px">
                                                <asp:ListItem Value="---">---</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                <tr >
                        <td class="RowsText" align="center">
                            <asp:Label ID="Lresponsable" runat="server" Text="Responsable:" CssClass="Apariencia" Width="300px"></asp:Label>
                            <asp:TextBox ID="tbxResponsable" runat="server" Enabled="false" CssClass="Apariencia" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblIdDependencia4" runat="server" Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>
                            <asp:ImageButton ID="imgDependencia4" runat="server" ImageUrl="~/Imagenes/Icons/Organization-Chart.png" OnClientClick="return false;" />
                            <asp:PopupControlExtender ID="popupDependencia4" runat="server" BehaviorID="popup4" OffsetY="-200" PopupControlID="pnlDependencia4" TargetControlID="imgDependencia4">
                            </asp:PopupControlExtender>
                        </td>
                        <td>
                            <asp:Panel ID="pnlDependencia4" runat="server" CssClass="popup" Width="400px" Style="display: none">
                                <table width="100%" border="1" cellspacing="0" cellpadding="2" bordercolor="White">
                                    <tr align="right" bgcolor="#5D7B9D">
                                        <td>
                                            <asp:ImageButton ID="btnClosepp4" runat="server" ImageUrl="~/Imagenes/Icons/dialog-close3.png"
                                                OnClientClick="$find('popup4').hidePopup(); return false;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TreeView ID="TreeView4" ExpandDepth="3" runat="server" Font-Names="Calibri"
                                                Font-Size="Small" LineImagesFolder="~/TreeLineImages" ForeColor="Black" ShowLines="True"
                                                AutoGenerateDataBindings="False" OnSelectedNodeChanged="TreeView4_SelectedNodeChanged">
                                                <SelectedNodeStyle BackColor="Silver" BorderColor="#66CCFF" BorderStyle="Inset" />
                                            </asp:TreeView>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:Button ID="BtnOk4" runat="server" Text="Aceptar" CssClass="Apariencia" OnClientClick="$find('popup4').hidePopup(); return false;" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                

                <tr>
                    <td colspan="3" align="center">
                        <asp:ImageButton ID="IBconsultar" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png"
                            ToolTip="Consultar" OnClick="IBconsultar_Click" ></asp:ImageButton>
                                                    
                        <asp:ImageButton ID="IBcancel" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png"
                            ToolTip="Cancelar" OnClick="IBcancel_Click" ></asp:ImageButton>
                    </td>
                </tr>


                <tr>
                    <td>
                        <asp:GridView ID="GvPlanes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader"
                            BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small" HeaderStyle-HorizontalAlign="Center"
                            DataKeyNames="Codigo, Estado" OnRowCommand="GvPlanes_RowCommand" OnPageIndexChanging="GvPlanes_PageIndexChanging"
                            AllowPaging="True">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField HeaderText="Código Plan" DataField="Codigo" >
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:BoundField HeaderText="Nombre Plan" DataField="NombrePlan" >
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:BoundField HeaderText="Usuario" DataField="Usuario" >
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha Registro" DataField="FechaRegistro" >
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:BoundField HeaderText="Estado" DataField="Estado" Visible="false" >
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/editV5.png" Text="Editar"
                                    CommandName="Editar" />
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
                    <td>
                        <asp:GridView ID="GvPlanesFiltro" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader"
                            BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small" HeaderStyle-HorizontalAlign="Center"
                            DataKeyNames="Codigo, Estado" OnRowCommand="GvPlanesFiltro_RowCommand" OnPageIndexChanging="GvPlanesfiltro_PageIndexChanging"
                            AllowPaging="True" Visible="false">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField HeaderText="Código Plan" DataField="Codigo" >
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:BoundField HeaderText="Nombre Plan" DataField="NombrePlan" >
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:BoundField HeaderText="Usuario" DataField="Usuario" visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha Registro" DataField="FechaRegistro" visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:BoundField HeaderText="Nombre Responsable" DataField="Responsable" >
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:BoundField HeaderText="Estado" DataField="Estado" >
                                    <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/editV5.png" Text="Editar"
                                    CommandName="Editar" />
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
                     <td style="text-align: left;">
                        <asp:ImageButton ID="Exportar" runat="server" ImageUrl="../../Imagenes/Icons/excel.png"
                            ToolTip="Exportar" OnClick="Exportar_Click" Width="28px" />
                    </td>
                    <td>
                        <asp:ImageButton ID="AgregarNuevo" runat="server" CommandName="Insert" ImageUrl="~/Imagenes/Icons/AddV5.png"
                            ToolTip="Insertar" style="border-width:0px;margin-left: -31px;" OnClick="AgregarNuevo_Click" />                                                                                
                    </td>                   
                </tr>
                <tr>
                    <td bgcolor="#BBBBBB" align="center">
                        <asp:Button ID="ReporteVencido" runat="server" Text="Notificar planes vencidos" Font-Names="Calibri"
                            Font-Size="Small" OnClick="GenerarReporte_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </div>   
        
        <div class="FiltroPlanes">
             <div class="EtiquetaCarga" style="margin-top: 0; width: 69%; text-align: -webkit-center; height: 23px;">
            <asp:Label ID="Label23" runat="server" Text="Búsqueda Planes"></asp:Label>
        </div>
            <div style="text-align: -webkit-center;">
                <table bgcolor="#EEEEEE" style="border: solid 1px #999999;">
                    <tr align="center">
                        <td bgcolor="#BBBBBB">
                            <asp:Label ID="Label21" runat="server" Text="Código Plan" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td bgcolor="#f0eef0">
                            <asp:TextBox ID="FiltroCodigoPlan" runat="server" MaxLength="10" placeholder="Código" style="text-transform: uppercase;" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr align="center">
                        <td bgcolor="#BBBBBB">
                            <asp:Label ID="Label22" runat="server" Text="Nombre Plan" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td bgcolor="#f0eef0">
                            <asp:TextBox ID="FiltroNombrePlan" runat="server" MaxLength="100" placeholder="NOMBRE"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr style="text-align: -webkit-center; display: -webkit-box;">
                        <td>
                            <asp:ImageButton ID="FiltroBusquedaPlan" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png"
                                ToolTip="Buscar" OnClick="FiltroBusquedaPlan_Click" />
                        </td>
                        <td>
                            <asp:ImageButton ID="CancelarFiltro" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png"
                                ToolTip="Cancelar"  OnClick="CancelarFiltro_Click" />
                        </td>
                        <td>
                            <asp:Panel ID="PanelFiltroPlanes" runat="server" Visible =" false">
                                <asp:Label ID="Label24" runat="server" Text="Encontrados:"></asp:Label>
                                <asp:Label ID="CuantosPlanes" runat="server" Text="0"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>                
            </div>
        </div>
        <%--Parte II - Registros--%>
        <div style="text-align: -webkit-center;">
            <table>
                <tr align="center">
                    <td>
                        <table id="TbRegistrarPlan" style="margin-left: 13%;" runat="server" visible="false">
                            <tr>
                                <td>
                                    <asp:TabContainer ID="TcPrincipal" runat="server" ActiveTabIndex="3" Font-Names="Calibri"
                                        Font-Size="Small" Width="900px">
                                        <asp:TabPanel ID="tpPlanes" runat="server" HeaderText="Planes" Font-Names="Calibri" Font-Size="Small">
                                            <HeaderTemplate>
                                                Plan de Acción
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table bgcolor="#EEEEEE" style="border: solid 1px #999999;">
                                                    <tr align="left">
                                                        <td align="center" bgcolor="#BBBBBB">
                                                            <asp:Label ID="Label141" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Código Plan"></asp:Label>
                                                        </td>
                                                        <td bgcolor="#f0eef0">
                                                            <asp:TextBox ID="CodigoPlan" runat="server" Enabled="False" MaxLength="100" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td align="center" bgcolor="#BBBBBB">
                                                            <asp:Label ID="Label142" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Nombre Plan"></asp:Label>
                                                        </td>
                                                        <td bgcolor="#f0eef0">
                                                            <asp:TextBox ID="NombrePlan" runat="server" placeholder="Nombre del Plan" Height="23px" MaxLength="1000" TextMode="MultiLine" Width="447px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rv2" runat="server" ControlToValidate="NombrePlan" ForeColor="Red" ValidationGroup="agregarRiesgo">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td align="center" bgcolor="#BBBBBB">
                                                            <asp:Label ID="Label164" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Descripción del plan"></asp:Label>
                                                        </td>
                                                        <td bgcolor="#f0eef0">
                                                            <asp:TextBox ID="Descripcion" runat="server" Font-Names="Calibri" Font-Size="Small" Height="50px" MaxLength="1000" Placeholder="Escriba aquí una descripción para el plan..." TextMode="MultiLine" Width="450px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rv3" runat="server" ControlToValidate="Descripcion" ForeColor="Red" ValidationGroup="agregarRiesgo">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td align="center" bgcolor="#BBBBBB">
                                                            <asp:Label ID="Label96" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Responsable decisión:"></asp:Label>
                                                        </td>
                                                        <td bgcolor="#f0eef0">
                                                            <asp:TextBox ID="Responsable" runat="server" Enabled="False" Font-Names="Calibri" Font-Size="Small" Width="300px" OnTextChanged="Responsable_TextChanged"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="Responsable" ForeColor="Red" ValidationGroup="modificarRiesgo">*</asp:RequiredFieldValidator>
                                                            <asp:Label ID="lblIdDependencia" runat="server" Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>
                                                            <asp:ImageButton ID="ImagenJerarquia" runat="server" ImageUrl="~/Imagenes/Icons/Organization-Chart.png" OnClientClick="return false;" OnClick="ImagenJerarquia_Click" />
                                                            <div class="TvPruebas" style="display: -webkit-inline-box;">
                                                                <asp:PopupControlExtender ID="PopupControlExtender2" runat="server" BehaviorID="popup5" ExtenderControlID="" OffsetY="-200" PopupControlID="PanelPP" TargetControlID="ImagenJerarquia" DynamicServicePath="">
                                                                </asp:PopupControlExtender>
                                                                <asp:Panel ID="PanelPP" runat="server" CssClass="popup" Style="display: none;">
                                                                    <table border="1" bordercolor="White" cellpadding="2" cellspacing="0">
                                                                        <tr align="right" bgcolor="#5D7B9D">
                                                                            <td>
                                                                                <asp:Label ID="Label99" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Seleccione el Responsable"></asp:Label>
                                                                                <asp:ImageButton ID="ImageButton23" runat="server" ImageUrl="~/Imagenes/Icons/dialog-close2.png" OnClientClick="$find('popup5').hidePopup(); return false;" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TreeView ID="TvResponsable" runat="server" ExpandDepth="3" Font-Names="Calibri" Font-Size="Small" ForeColor="Black" LineImagesFolder="~/TreeLineImages" OnSelectedNodeChanged="TvResponsable_SelectedNodeChanged" ShowLines="True">
                                                                                    <SelectedNodeStyle BackColor="Silver" BorderColor="#66CCFF" BorderStyle="Inset" />
                                                                                </asp:TreeView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="center">
                                                                            <td>
                                                                                <asp:Button ID="Button3" runat="server" CssClass="Apariencia" OnClientClick="$find('popup5').hidePopup(); return false;" Text="Aceptar" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       <td bgcolor="#BBBBBB" align="center">
                                                            <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Riesgo global:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="PDARiesgoGLobal" runat="server" AutoPostBack="True" Width="200px" Font-Names="Calibri" Font-Size="Small">
                                                                <asp:ListItem Value="0">---</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td align="center" bgcolor="#BBBBBB">
                                                            <asp:Label ID="Label144" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Estado"></asp:Label>
                                                        </td>
                                                        <td bgcolor="#f0eef0">
                                                            <asp:DropDownList ID="EstadoPlan" runat="server" AutoPostBack="True" Font-Names="Calibri" Font-Size="Small" OnSelectedIndexChanged="EstadoPlan_SelectedIndexChanged" Width="200px">
                                                                <asp:ListItem Value="0">---</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rv5" runat="server" ControlToValidate="EstadoPlan" ForeColor="Red" ValidationGroup="agregarRiesgo">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#BBBBBB">
                                                            <asp:Label ID="Label60" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Fecha compromiso"></asp:Label>
                                                        </td>
                                                        <td bgcolor="#f0eef0">
                                                            <asp:TextBox ID="FechaCompromiso" runat="server" autocomplete="off" Font-Names="Calibri" Font-Size="Small" MaxLength="10" placeholder="AAAA/MM/dd" Width="150px"></asp:TextBox>
                                                            <asp:CalendarExtender ID="TextBox15_CalendarExtender" runat="server" BehaviorID="_content_TextBox15_CalendarExtender" Format="yyyy-MM-dd" TargetControlID="FechaCompromiso" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="FechaCompromiso" ForeColor="Red" ValidationGroup="agregarRiesgo">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#BBBBBB">
                                                            <asp:Label ID="Label26" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Fecha de Extensión"></asp:Label>
                                                        </td>
                                                        <td bgcolor="#f0eef0">
                                                            <asp:TextBox ID="FechaExtension" runat="server" autocomplete="off" Font-Names="Calibri" Font-Size="Small" MaxLength="10" placeholder="AAAA/MM/dd" Width="150px"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" BehaviorID="_content_FechaExtension_CalendarExtender" Format="yyyy-MM-dd" TargetControlID="FechaExtension" />
                                                            <asp:CompareValidator ID="CompareValidator" runat="server" ControlToCompare="FechaCompromiso" ControlToValidate="FechaExtension" Display="Dynamic" ErrorMessage="Fecha Inválida. La fecha de extensión del evento no puede ser anterior a la fecha de extensión" Font-Names="Calibri" Font-Size="Small" ForeColor="Red" Operator="GreaterThanEqual" Type="Date" ValidationGroup="Addne"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#BBBBBB">
                                                            <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Fecha de Implementación"></asp:Label>
                                                        </td>
                                                        <td bgcolor="#f0eef0">
                                                            <asp:TextBox ID="FechaImplementacion" runat="server" autocomplete="off" Font-Names="Calibri" Font-Size="Small" MaxLength="10" placeholder="AAAA/MM/dd" Width="150px"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" BehaviorID="_content_FechaImplementacion_CalendarExtender" Format="yyyy-MM-dd" TargetControlID="FechaImplementacion" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="EtiquetaCarga" style="margin-top: 2%; width: 69%; text-align: -webkit-center;">
                                                    <asp:Label ID="EtiquetaCargas" runat="server" Text="Asociar Archivo"></asp:Label>
                                                </div>
                                                <asp:UpdatePanel ID="PanelCargarArchivo" runat="server">
                                                    <ContentTemplate>
                                                        <table id="TbCarga" runat="server" style="border: solid 1px #999999; width: 82%" visible="false">
                                                            <tr>
                                                                <td>
                                                                    <asp:FileUpload ID="FUCarga" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton ID="CargarArchivo" runat="server" ImageUrl="~/Imagenes/Icons/Arriba.png" OnClick="CargarArchivo_Click" ToolTip="Adjuntar" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="UploadDetails" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="ArchivosCargados" style="background: #BBBB; text-align: center;">
                                                                    <asp:Label ID="Label14" runat="server" Text="Archivos Cargados "></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <asp:GridView ID="GvFiltroCarga" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" CellPadding="4" Font-Names="Calibri" Font-Size="Small" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" OnRowCommand="GvFiltroCarga_RowCommand" ShowHeaderWhenEmpty="True">
                                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="IdArchivo" HeaderText="CodPlan" Visible="False" />
                                                                            <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre Usuario" />
                                                                            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" />
                                                                            <asp:BoundField DataField="UrlArchivo" HeaderText="Nombre Archivo" />
                                                                            <asp:ButtonField ButtonType="Image" CommandName="Descargar" ImageUrl="~/Imagenes/Icons/downloads.png" Text="Descargar" />
                                                                        </Columns>
                                                                        <EditRowStyle BackColor="#999999" />
                                                                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                                                        <HeaderStyle BackColor="#5D7B9D" CssClass="gridViewHeader" Font-Bold="True" ForeColor="White" />
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
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="CargarArchivo" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <div class="pJustificacion" style="margin-top: 2%; width: 69%; text-align: -webkit-center; margin-bottom: 8px;">
                                                    <asp:Label ID="EtiquetaJustificacion" runat="server" class="pkJustificacion" Text="Justificación de los cambios" Visible="False"></asp:Label>
                                                </div>
                                                <asp:Panel ID="PanelJustificacion" runat="server" Style="border: solid 1px #999999; width: 82%;" Visible="False">
                                                    <table id="JustificacionCambios" runat="server" visible="False">
                                                        <tr runat="server">
                                                            <td runat="server"><a href="#Justifica">
                                                                <asp:TextBox ID="Justificacion" runat="server" Font-Names="Calibri" Font-Size="Small" Height="50px" MaxLength="1000" placeholder="Escriba aquí una justificación antes de guardar los cambios..." Style="margin-left: 20%;" TextMode="MultiLine" Width="432px"></asp:TextBox>
                                                                </a>
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                    <table id="TablaJustificacion" runat="server" style="margin-top: 21px; margin-left: 16%">
                                                        <tr runat="server">
                                                            <td class="jCambios" style="background: #BBBB; text-align: center" runat="server">
                                                                <asp:Label ID="Label19" runat="server" Text="Cambios realizados para este plan"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr align="center" runat="server">
                                                            <td runat="server">
                                                                <asp:GridView ID="GvJustificacionCambios" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" CellPadding="4" Font-Names="Calibri" Font-Size="Small" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" ShowHeaderWhenEmpty="True">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="CodPlan" HeaderText="Código Plan">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Justificacion" HeaderText="Justificación">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre Usuario">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <EditRowStyle BackColor="#999999" />
                                                                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                                                    <HeaderStyle BackColor="#5D7B9D" CssClass="gridViewHeader" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tpRiesgosAsociados" runat="server" HeaderText="Riesgos Asociados">
                                            <HeaderTemplate>
                                                Riesgos Asociados
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table bgcolor="#EEEEEE" style="border: solid 1px #999999;">
                                                    <tr align="center">
                                                        <td>
                                                            <table>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" style="width: 124px;" align="center">
                                                                        <asp:Label ID="Label69" runat="server" Text="Código Riesgo:" Font-Size="Small" Font-Names="Calibri"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="CodigoRiesgo" runat="server" Width="150px" Font-Names="Calibri" Font-Size="Small" MaxLength="20" placeholder="Código Riesgo"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <%--Nombre Riesgo--%>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" align="center">
                                                                        <asp:Label ID="Label70" runat="server" Text="Nombre Riesgo:" Font-Size="Small" Font-Names="Calibri"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="NombreRiesgo" runat="server" Width="300px" Font-Names="Calibri" Font-Size="Small" MaxLength="50" placeholder="Nombre Riesgo"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" align="center">
                                                                        <asp:Label ID="Label71" runat="server" Text="Cadena de valor" Font-Names="Calibri"
                                                                            Font-Size="Small"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:DropDownList ID="CadenaValorRiesgo" runat="server" Width="400px" Font-Names="Calibri"
                                                                            Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="CadenaValorRiesgo_SelectedIndexChanged">
                                                                            <asp:ListItem Value="---">---</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <%--Macroproceso Riesgo--%>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" align="center">
                                                                        <asp:Label ID="Label72" runat="server" Text="Macroproceso" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:DropDownList ID="MacroprocesoRiesgo" runat="server" Width="400px" Font-Names="Calibri"
                                                                            Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="MacroprocesoRiesgo_SelectedIndexChanged">
                                                                            <asp:ListItem Value="---">---</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" align="center">
                                                                        <asp:Label ID="Label73" runat="server" Text="Proceso" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:DropDownList ID="ProcesoRiesgo" runat="server" Width="400px" Font-Names="Calibri"
                                                                            Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="ProcesoRiesgo_SelectedIndexChanged">
                                                                            <asp:ListItem Value="---">---</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <%--Subproceso Riesgo--%>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" align="center">
                                                                        <asp:Label ID="Label74" runat="server" Text="Subproceso" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:DropDownList ID="SubprocesoRiesgo" runat="server" Width="400px" Font-Names="Calibri"
                                                                            Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="SubprocesoRiesgo_SelectedIndexChanged">
                                                                            <asp:ListItem Value="---">---</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" align="center">
                                                                        <asp:Label ID="Label80" runat="server" Text="Riesgos globales" Font-Names="Calibri"
                                                                            Font-Size="Small"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:DropDownList ID="RiesgosGlobales" runat="server" Width="400px" Font-Names="Calibri"
                                                                            Font-Size="Small">
                                                                            <asp:ListItem Value="---">---</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr hidden>
                                                                    <td bgcolor="#BBBBBB" align="center">
                                                                        <asp:Label ID="Label94" runat="server" Text="Recalificar Riesgos" Font-Names="Calibri"
                                                                            Font-Size="Small"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="BtnCalificacionMasiva" runat="server" Text="Recalificación Masiva de Riesgos" Width="100%" Height="30px" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table>
                                                                <tr align="center">
                                                                    <td>
                                                                        <table>
                                                                            <tr align="center">
                                                                                <td>
                                                                                    <asp:ImageButton ID="BuscarRiesgo" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png"
                                                                                        ToolTip="Consultar" OnClick="BuscarRiesgo_Click" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:ImageButton ID="LimpiarFiltroRiesgo" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png"
                                                                                        OnClick="LimpiarFiltroRiesgo_Click" ToolTip="Cancelar" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div>
                                                                <asp:Label ID="lblRiesgoAsociar" runat="server" Text="Riesgo a Asociar: " Enabled="false" ReadOnly="true" Visible=" false"></asp:Label>
                                                                <asp:TextBox ID="RiesgoAsociar" runat="server" Enabled="false" ReadOnly="true" Visible=" false" Style="width: 25%; font-size: 20px; margin-top: 12px; text-align: center; margin-bottom: 12px; border: solid 2px;"></asp:TextBox>
                                                            </div>
                                                            <div id="EtiquetaEncontrados" style="background: #BBBBBB; margin: 18px 0 7px 0;">
                                                                <asp:Label ID="lblRiesgosEncontrados" runat="server" Text="Riesgos Encontrados: "></asp:Label>
                                                            </div>
                                                            <table id="TbRiesgos" runat="server" visible="false">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="GvFiltroRiesgos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                            ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader"
                                                                            BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small" HeaderStyle-HorizontalAlign="Center"
                                                                            DataKeyNames="IdRiesgo, Codigo,ListaCausas" OnRowCommand="GvFiltroRiesgos_RowCommand" OnPageIndexChanging="GvFiltroRiesgos_PageIndexChanging"
                                                                            AllowPaging="True">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Id" DataField="IdRiesgo" Visible="false" />
                                                                                <asp:BoundField HeaderText="Código" DataField="Codigo" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="Riesgo global" DataField="NombreClasificacionRiesgo" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="Fecha Registro" DataField="FechaRegistro" Visible="false" />
                                                                                <asp:ButtonField HeaderText="Asociar" ButtonType="Image" ImageUrl="~/Imagenes/Icons/selectV5.png" Text="Asociar"
                                                                                    CommandName="Asociar" />
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
                                                            <div class="RAsociados" style="margin: 18px 0 7px 0;font-family: Calibri;font-size: Small;color: #4d4d4d;">
                                                                <asp:Label ID="Label15" runat="server" Text="Riesgos Asociados: "></asp:Label>
                                                            </div>
                                                            <%--GridView Riesgos Asociados--%>
                                                            <table id="TbGvRiesgoAsociado" runat="server">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="GvRiesgosAsociados" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                            ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader"
                                                                            BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small"
                                                                            DataKeyNames="id,CodigoPlan,CodigoRiesgo" OnRowCommand="GvRiesgosAsociados_RowCommand" OnPageIndexChanging="GvRiesgosAsociados_PageIndexChanging"
                                                                            AllowPaging="True">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="Código Plan" DataField="CodigoPlan" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="Código Riesgo" DataField="CodigoRiesgo" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="Fecha Registro" DataField="FechaRegistro" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="Usuario" DataField="Usuario" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:ButtonField HeaderText="Desasociar" ButtonType="Image" ImageUrl="~/Imagenes/Icons/deleteV5.png" Text="Desasociar"
                                                                                    CommandName="Desasociar" />                                                                               
                                                                            </Columns>
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
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
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tpEventosAsociados" runat="server" HeaderText="Eventos Asociados">
                                            <ContentTemplate>
                                                <table bgcolor="#EEEEEE" style="border: solid 1px #999999;">
                                                    <tr align="center">
                                                        <td>
                                                            <table>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" align="center">
                                                                        <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Código Evento:"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="CodigoEvento" runat="server" Font-Names="Calibri" Font-Size="Small"
                                                                            Width="150px" MaxLength="20" placeholder="Código Evento"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <%--Meta--%>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" align="center">
                                                                        <asp:Label ID="Label2" runat="server" Text="Descripción del evento:" Font-Size="Small" Font-Names="Calibri"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="DescripcionEvento" runat="server" Width="300px" Font-Names="Calibri" MaxLength="50" Font-Size="Small" placeholder="Descipción Evento"></asp:TextBox>                                                                       
                                                                    </td>
                                                                </tr>                                                               
                                                                </table>
                                                                <table>
                                                                    <tr align="center">
                                                                        <td>
                                                                            <tr align="center">
                                                                                <td>
                                                                                    <asp:ImageButton ID="BuscarEvento" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png" OnClick="BuscarEvento_Click" ToolTip="Consultar" />
                                                                                    <asp:ImageButton ID="LimpiarFiltroEvento" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png" OnClick="LimpiarFiltroEvento_Click" ToolTip="Cancelar" />
                                                                                </td>
                                                                                <td></td>
                                                                            </tr>
                                                                        </td>
                                                                    </tr>
                                                            </table>
                                                            <div>
                                                                <asp:Label ID="lblAsociarEvento" runat="server" Enabled="false" ReadOnly="true" Text="Evento a Asociar: " Visible=" false"></asp:Label>
                                                                <asp:TextBox ID="AsociarEvento" runat="server" Enabled="false" ReadOnly="true" Style="width: 25%; font-size: 20px; margin-top: 12px; text-align: center; margin-bottom: 12px; border: solid 2px;" Visible=" false"></asp:TextBox>
                                                            </div>
                                                            <div style="background: #BBBBBB; margin: 18px 0 7px 0;">
                                                                <asp:Label ID="lblEventosEncontrados" runat="server" Text="Eventos Encontrados: "></asp:Label>
                                                            </div>
                                                            <%--Grilla Filtro Eventos--%>
                                                            <table id="TbEventos" runat="server" visible="false">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="GvFiltroEventos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="Solid" CellPadding="4" DataKeyNames="CodigoEvento" Font-Names="Calibri" Font-Size="Small" ForeColor="#333333" GridLines="Vertical" HeaderStyle-CssClass="gridViewHeader" HeaderStyle-HorizontalAlign="Center" HorizontalAlign="Center" OnPageIndexChanging="GvFiltroEventos_PageIndexChanging" OnRowCommand="GvFiltroEventos_RowCommand" ShowHeaderWhenEmpty="True">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="CodigoEvento" HeaderText="Código">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="DescripcionEvento" HeaderText="Descripción">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:ButtonField ButtonType="Image" CommandName="Asociar" HeaderText="Asociar" ImageUrl="~/Imagenes/Icons/selectV5.png" Text="Editar" />
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
                                                            <div class="EAsociados" style="margin: 18px 0 7px 0;font-family: Calibri;font-size: Small;color: #4d4d4d;">
                                                                <asp:Label ID="lblEventosAsociados" runat="server" Text="Eventos Asociados: "></asp:Label>
                                                            </div>
                                                            <table id="TbGrillaEventosRelacionados" runat="server">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="GvEventosAsociados" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="Solid" CellPadding="4" DataKeyNames="id,CodigoEvento, CodigoPlan" Font-Names="Calibri" Font-Size="Small" ForeColor="#333333" GridLines="Vertical" HeaderStyle-CssClass="gridViewHeader" HeaderStyle-HorizontalAlign="Center" HorizontalAlign="Center" OnPageIndexChanging="GvEventosAsociados_PageIndexChanging" OnRowCommand="GvEventosAsociados_RowCommand" ShowHeaderWhenEmpty="True">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                                                                <asp:BoundField DataField="CodigoPlan" HeaderText="Código Plan">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="CodigoEvento" HeaderText="Código Evento">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Usuario" HeaderText="Usuario">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:ButtonField ButtonType="Image" CommandName="Desasociar" HeaderText="Desasociar" ImageUrl="~/Imagenes/Icons/deleteV5.png" Text="Desasociar" />
                                                                            </Columns>
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle BackColor="#5D7B9D" CssClass="gridViewHeader" Font-Bold="True" ForeColor="White" />
                                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
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
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tpCumplimiento" runat="server" HeaderText="Indicador de Cumplimientos">
                                            <HeaderTemplate>
                                                Indicador de Cumplimientos
                                            </HeaderTemplate>
                                            
                                            <ContentTemplate>
                                                <table bgcolor="#EEEEEE" style="border: solid 1px #919b9c;">
                                                    <tr align="Left">
                                                        <td>
                                                            <table align="Left">
                                                                <tr>
                                                                    <td align="center" bgcolor="#BBBBBB" style="width: 173px;">
                                                                        <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Fecha Revisión"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="Periodo" runat="server" autocomplete="off" Font-Names="Calibri" Font-Size="Small" MaxLength="10" placeholder="AAAA/MM/dd" Width="150px"></asp:TextBox>
                                                                        <asp:CalendarExtender ID="FehaPeriodo" runat="server" BehaviorID="_content_FechaPeriodo_CalendarExtender" Format="yyyy-MM-dd" TargetControlID="Periodo" />
                                                                    </td>
                                                                </tr>
                                                                <tr align="left">
                                                                    <td align="center" bgcolor="#BBBBBB" class="auto-style1">
                                                                        <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Meta"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0" class="auto-style1">
                                                                        <asp:TextBox ID="Meta" runat="server" autocomplete="off" Font-Names="Calibri" Font-Size="Small" MaxLength="3" onchange="SoloNumerosMaxCien(this);" onkeyup="SoloNumerosMaxCien(this);" placeholder="Meta" Width="150px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="pRiesgosAsociados" style="margin: 18px 0 7px 0;">
                                                                    <td>
                                                                        <asp:Label ID="Label16" runat="server" style="font-family:Calibri;font-size:Small;" Text="Indicadores Asociados "></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="GvCumplimiento" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="Solid" CellPadding="4" DataKeyNames="Id,Meta,Periodo" Font-Names="Calibri" Font-Size="Small" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="GvCumplimiento_PageIndexChanging" OnRowCommand="GvCumplimiento_RowCommand" ShowHeaderWhenEmpty="True">
                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Id" HeaderText="id" Visible="False" />
                                                                    <asp:BoundField DataField="Periodo" HeaderText="Fecha Revisión">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Meta" HeaderText="% Meta">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Cumplimiento" HeaderText="% Cumplimiento">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="Editar" ImageUrl="~/Imagenes/Icons/selectV5.png" Text="Editar" />
                                                                    <asp:ButtonField ButtonType="Image" CommandName="Gestionar" HeaderText="Gestionar" ImageUrl="~/Imagenes/Icons/selectV5.png" Text="Editar" />
                                                                </Columns>
                                                                <EditRowStyle BackColor="#999999" />
                                                                <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#002649" CssClass="gridViewHeader" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    </tr>
                                                    </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Seguimiento">
                                            <ContentTemplate>
                                                <table bgcolor="#EEEEEE" align="Left" style="border: solid 1px #999999;">
                                                    <tr align="Center">
                                                        <td>
                                                            <table>
                                                                <tr align="left">
                                                                    <td bgcolor="#BBBBBB" style="width: 20%" align="center">
                                                                        <asp:Label ID="Label10" runat="server" Text="Seguimiento" Font-Size="Small" Font-Names="Calibri"></asp:Label>
                                                                    </td>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="Seguimiento" runat="server" Width="260px" TextMode="MultiLine" placeholder="Seguimiento"
                                                                            Font-Names="Calibri" Font-Size="Small" MaxLength="1000"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td bgcolor="#BBBBBB">
                                                                        <asp:Label ID="Label11" runat="server" Text="Usuario" Font-Names="Calibri"
                                                                            Font-Size="Small"></asp:Label>
                                                                    </td>
                                                                    <tb>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="Usuario" runat="server" Enabled ="False" Width="150px" Font-Names="Calibri" Font-Size="Small"></asp:TextBox>
                                                                    </td>
                                                                    </tb>
                                                                </tr>
                                                                <tr>
                                                                    <td bgcolor="#BBBBBB">
                                                                        <asp:Label ID="Label12" runat="server" Text="Fecha" Font-Names="Calibri"
                                                                            Font-Size="Small"></asp:Label>
                                                                    </td>
                                                                    <tb>
                                                                    <td bgcolor="#f0eef0">
                                                                        <asp:TextBox ID="FechaSeguimiento" runat="server" Enabled ="False" Width="150px" Font-Names="Calibri" Font-Size="Small"></asp:TextBox>
                                                                    </td>
                                                                    </tb>
                                                                </tr>
                                                                <tr class="sAsociados" style="margin: 18px 0 7px 0;">
                                                                    <td>
                                                                        <asp:Label ID="Label17" runat="server" Text="Seguimientos Asociados:" style="font-family:Calibri;font-size:Small;"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="GvSeguimiento" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="Solid" CellPadding="4" Font-Names="Calibri" Font-Size="Small" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="GvSeguimiento_PageIndexChanging" OnRowCommand="GvSeguimiento_RowCommand" ShowHeaderWhenEmpty="True" Width="200%">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="CodigoPlan" HeaderText="CodigoPlan">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Seguimiento" HeaderText="Seguimiento">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Usuario" HeaderText="Usuario">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle BackColor="#002649" CssClass="gridViewHeader" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
                                                </td>
                                                </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer>
                                </td>
                            </tr>
                            <%--botones aceptar- cancelar--%>
                            <tr align="center">
                                        <td>
                                            <table class="tablaSinBordes">
                                                <tr>
                                                    <td>
                                                         <asp:ImageButton ID="Aceptar" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                        ToolTip="Guardar" ValidationGroup="agregarRiesgo"  OnClick="Aceptar_Click"/>
                                                    </td>
                                                    <td>
                                                          <asp:ImageButton ID="Limpiar" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png"
                                        ToolTip="Cancelar" OnClick="Limpiar_Click" />
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
    </ContentTemplate>
    <Triggers >
        <asp:PostBackTrigger ControlID="Exportar"></asp:PostBackTrigger>        
    </Triggers>
</asp:UpdatePanel>


