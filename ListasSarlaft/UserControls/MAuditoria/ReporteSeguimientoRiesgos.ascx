<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReporteSeguimientoRiesgos.ascx.cs" Inherits="ListasSarlaft.UserControls.MAuditoria.ReporteSeguimientoRiesgos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<table class="style1" width="100%">
    <tr align="center">
        <td>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                Width="21.59cm" InteractiveDeviceInfos="(Colección)" WaitMessageFont-Names="Verdana"
                
                WaitMessageFont-Size="14pt" Height="27.94cm" SizeToReportContent="True">
                <LocalReport ReportPath="Reportes\ReporteSeguimientoSAR.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsHallazgos" Name="DSHallazgos" />
                    </DataSources>
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsRecomendaciones" Name="DSRecomendacionesHallazgo" />
                    </DataSources>
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsRiesgos" Name="DSRiesgosHallazgo" />
                    </DataSources>
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsDSImagenes1" Name="DSImagenes1" />
                    </DataSources>
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsDSImagenes2" Name="DSImagenes2" />
                    </DataSources>
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsDSImagenes3" Name="DSImagenes3" />
                    </DataSources>
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsImagenes" Name="DSimagenes" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="odsHallazgos" runat="server" SelectMethod="GetData"
                TypeName="ListasSarlaft.DataSet.DSHallazgosTableAdapters.SP_HallazgosAuditoriaTableAdapter"
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtCodAuditoria" Name="IdAuditoria" PropertyName="Text"
                        Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsImagenes" runat="server" SelectMethod="GetData"
                TypeName=" ListasSarlaft.DataSet.DSImagenesAuditoriaTableAdapters.SP_ImagenesAuditoriav2TableAdapter"
                OldValuesParameterFormatString="{0}">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsRecomendaciones" runat="server" SelectMethod="GetData"
                TypeName="ListasSarlaft.DataSet.DSRecomendacionesHallazgoTableAdapters.SP_RecomendacionesHallazgoTableAdapter"
                OldValuesParameterFormatString="{0}"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsRiesgos" runat="server" SelectMethod="GetData"
                TypeName="ListasSarlaft.DataSet.DSRiesgosHallazgoTableAdapters.SP_RiesgosHallazgoTableAdapter"
                OldValuesParameterFormatString="{0}"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsDSImagenes2" runat="server" SelectMethod="GetData"
                TypeName="ListasSarlaft.DataSet.DSImagenesTableAdapters.SP_ImagenesAuditoriaTableAdapter"
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtCodAuditoria" Name="IdAuditoria" PropertyName="Text"
                        Type="Int32" />
                    <asp:Parameter DefaultValue="2" Name="Secuencia" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="odsDSImagenes1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="ListasSarlaft.DataSet.DSImagenesTableAdapters.SP_ImagenesAuditoriaTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtCodAuditoria" Name="IdAuditoria" PropertyName="Text" Type="Int32" />
                    <asp:Parameter  DefaultValue="1" Name="Secuencia"  />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsDSImagenes3" runat="server" SelectMethod="GetData"
                TypeName="ListasSarlaft.DataSet.DSImagenesTableAdapters.SP_ImagenesAuditoriaTableAdapter"
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtCodAuditoria" Name="IdAuditoria" PropertyName="Text"
                        Type="Int32" />
                    <asp:Parameter DefaultValue="3" Name="Secuencia" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
        <td>&nbsp;
        </td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;
        </td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtCodAuditoria" runat="server" Visible="False"></asp:TextBox>
        </td>
        <td>&nbsp;
        </td>
        <td>&nbsp;
        </td>
    </tr>
</table>