<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportePerfiles.ascx.cs"
    Inherits="ListasSarlaft.UserControls.Perfilamiento.ReportePerfiles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
        width: 1200px;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="content">
            <!-- begin row -->
            <div class="row">
                <!-- begin col-12 -->
                <div class="col-lg-12">
                    <table align="center" bgcolor="#EEEEEE">
                        <tr align="center" bgcolor="#002649">
                            <td class="style1">
                                <asp:Label ID="Label61" runat="server" ForeColor="White" Text="Reporte Perfiles"
                                    Font-Bold="False" Font-Names="Calibri" Font-Size="Large"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td class="style1">
                                <table>
                                    <tr align="left">
                                        <td bgcolor="#BBBBBB" align="center">
                                            <asp:Label ID="Label4" runat="server" Text="Nro. Identificación:" Font-Names="Calibri"
                                                Font-Size="Small" style="color:black"></asp:Label>
                                        </td>
                                        <td bgcolor="#f0eef0">
                                            <asp:TextBox ID="tbNroIdentificacion" runat="server" Width="100px" Font-Names="Calibri"
                                                Font-Size="Small"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td bgcolor="#BBBBBB" align="center">
                                            <asp:Label ID="Label1" runat="server" Text="Fecha inicial:" Font-Names="Calibri"
                                                Font-Size="Small" style="color:black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbFechaIni" runat="server" Width="100px" Font-Names="Calibri" Font-Size="Small"></asp:TextBox>
                                            <asp:CalendarExtender ID="tbFechaIni_CalendarExtender" runat="server" Format="yyyy-MM-dd"
                                                Enabled="True" TargetControlID="tbFechaIni"></asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td bgcolor="#BBBBBB" align="center">
                                            <asp:Label ID="Label2" runat="server" Text="Fecha final:" Font-Names="Calibri" Font-Size="Small"
                                                style="color:black"></asp:Label>
                                        </td>
                                        <td bgcolor="#f0eef0">
                                            <asp:TextBox ID="tbFechaFin" runat="server" Width="100px" Font-Names="Calibri" Font-Size="Small"></asp:TextBox>
                                            <asp:CalendarExtender ID="tbFechaFin_CalendarExtender" runat="server" Format="yyyy-MM-dd"
                                                Enabled="True" TargetControlID="tbFechaFin"></asp:CalendarExtender>
                                        </td>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" OnServerValidate="CustomValidator_ServerValidate"></asp:CustomValidator>
                                    </tr>
                                    <tr align="left">
                                        <td bgcolor="#BBBBBB" align="center">
                                            <asp:Label ID="Label3" runat="server" Text="Perfil:" Font-Names="Calibri" Font-Size="Small"
                                                style="color:black"></asp:Label>
                                        </td>
                                        <td bgcolor="#f0eef0">
                                            <asp:DropDownList ID="ddlPerfil" runat="server" Width="200px" Font-Names="Calibri"
                                                Font-Size="Small" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="center">
                            <td class="style1">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnConsultar" runat="server" ImageUrl="~/Imagenes/Icons/lupa.png"
                                                ToolTip="Consultar" OnClick="btnConsultar_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes/Icons/cancel.png"
                                                ToolTip="Cancelar" OnClick="btnCancelar_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbPerfilTemp" runat="server" Visible="false" Width="63px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr  runat="server" id="trButton" visible="false">
                            <td align="center" style="width:50%">
                                <asp:Button ID="btnExcel" runat="server" Text="Exportar" ToolTip="Exportar" Font-Names="Calibri"
                                    Font-Size="Small" OnClick="btnExcel_Click" />
                            </td>
                        </tr>
            <tr align="center" id="trGridPerfiles" runat="server" >
                <td>
                    <asp:GridView ID="gvPerfiles" runat="server" CellPadding="4" EnableModelValidation="True"
                                        ForeColor="#333333" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
                                        PageSize="100" OnPageIndexChanging="gvPerfiles_PageIndexChanging" HeaderStyle-HorizontalAlign="Center"
                                        ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader" BorderStyle="Solid"
                                        HorizontalAlign="Center" Font-Names="Calibri" Font-Size="Small">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="IdHistorico" HeaderText="IdHistorico" Visible="False" />
                                            <asp:BoundField DataField="IdPerfil" HeaderText="IdPerfil" Visible="False" />
                                            <asp:BoundField DataField="NombrePerfil" HeaderText="Nombre Perfil" >
                                                <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                            <asp:BoundField DataField="TipoDocumento" HeaderText="Tipo Documento" >
                                                <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                            <asp:BoundField DataField="NumeroDocumento" HeaderText="Número Documento" >
                                                <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                            <asp:BoundField DataField="NombreCliente" HeaderText="Nombre Cliente" >
                                                <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                            <asp:BoundField DataField="Calificacion" HeaderText="Calificación" >
                                                <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                            <asp:BoundField DataField="SenalesAlerta" HeaderText="Señales Alerta" >
                                                <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                            <asp:BoundField DataField="InfoInspektor" HeaderText="Info Inspektor" >
                                                <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
                        <%--<tr align="center" id="trRptPerfiles" runat="server">
                            <td class="style1">
                                <table>
                                    <tr align="left">
                                        <td>
                                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="1300px" Width="750px"
                                                InteractiveDeviceInfos="(Colección)" ShowParameterPrompts="False" ShowPrintButton="False"
                                                ShowRefreshButton="False" ShowZoomControl="false" OnReportError="TheReport_ReportError">
                                                <LocalReport ReportPath="Reportes\RptPerfiles.rdlc">
                                                    <DataSources>
                                                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1_DataTable1" />
                                                    </DataSources>
                                                </LocalReport>
                                            </rsweb:ReportViewer>
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
                                                TypeName="DataSet1TableAdapters."></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                    </table>
                </div>
                <!-- End col-12 -->
            </div>
            <!-- End row -->
        </div>
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
    </ContentTemplate>
</asp:UpdatePanel>
