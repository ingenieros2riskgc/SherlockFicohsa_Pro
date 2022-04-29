<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="ListasSarlaft.UserControls.Home" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:ModalPopupExtender ID="mpeMsgBox" runat="server" TargetControlID="btndummy"
    PopupControlID="pnlMsgBox" OkControlID="btnAceptar" BackgroundCssClass="FondoAplicacion"
    Enabled="True" DropShadow="true">
</asp:ModalPopupExtender>
<div class="content">

            <!-- begin row -->
            <div class="row">
                <div class="col-lg-10">

                </div>
                <!-- begin col-2 -->
                <div class="col-lg-2">
                    <!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Dashboard</a></li>
			</ol>
			<!-- end breadcrumb -->
                </div>
                <!-- End col-12 -->
				<!-- begin col-6 -->
                <div class="col-lg-1">
                    </div>
				<div class="col-lg-9">
                    <!-- begin page-header -->
			
			<!-- end page-header -->
                </div>
                <!-- End col-6 -->
             </div>
    <!-- begin row -->
			<div class="row">
                <div class="col-lg-2"></div>
                <!-- begin col-12 -->
				<div class="col-lg-8">
                <%--<asp:Chart ID="Chart3" runat="server" Height="200px" Width="350px"  BorderlineDashStyle="Solid" 
            BorderlineColor="Black">
                    <Titles>
                        <asp:Title Alignment="TopCenter" Text="RIESGO RESIDUAL POR OBJETIVO ESTRATÉGICO" Font="Roboto-Regular"></asp:Title>
                    </Titles>
            <Series>             
            </Series>
                   <Legends>
                       <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="true" Name="Default" LegendStyle="Row"></asp:Legend>
                   </Legends>        
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>--%>

<asp:Chart ID="ChartInh" runat="server" Height="200px" Width="350px" BorderlineDashStyle="Solid" BorderlineColor="Black"
                    OnPrePaint="ChartInherente_PrePaint" >
    <Titles>
        <asp:Title ShadowOffset="3" Name="Items" Alignment="TopCenter"/>
    </Titles>
    <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="true" Name="Default" LegendStyle="Row" />
    </Legends>
    <Series>
        <asp:Series Name="Default" />
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartSaroInherente" BorderWidth="0" />
    </ChartAreas>
</asp:Chart> 




                <asp:Chart ID="ChartSaro" runat="server" Height="200px" Width="350px" BorderlineDashStyle="Solid" BorderlineColor="Black"
                    OnPrePaint="ChartSaro_PrePaint" >
    <Titles>
        <asp:Title ShadowOffset="3" Name="Items" Alignment="TopCenter"/>
    </Titles>
    <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="true" Name="Default" LegendStyle="Row" />
    </Legends>
    <Series>
        <asp:Series Name="Default" />
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartSaroArea" BorderWidth="0" />
    </ChartAreas>
</asp:Chart> 
                <br />
                 <asp:Chart ID="ChartRiesgoCadenaValor" runat="server" Height="200px" Width="703px"  BorderlineDashStyle="Solid"
            BorderlineColor="black">
                    <Titles>
                        <asp:Title Alignment="TopCenter" Text="RIESGOS POR CADENA DE VALOR"></asp:Title>
                    </Titles>
                   <Legends>
                       <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="true" Name="Default" LegendStyle="Row"></asp:Legend>
                   </Legends>        
            <ChartAreas>
                <asp:ChartArea Name="ChartAreaRiesgoCadenaValor">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                <%--<asp:Chart ID="crtGestionObjetivosvsPerspectiva" runat="server" Width="350px" BorderlineDashStyle="Solid"
            BorderlineColor="black">
                            <Legends>
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                LegendStyle="Row" />
        </Legends>
            <ChartAreas>
            <asp:ChartArea Name="crtAreaGOP">
            </asp:ChartArea>
            </ChartAreas>
            </asp:Chart>--%>
               
                <%--<table class="tabla" align="center">
                <tr>
                   
                    <td align="center">
                                            <asp:Label ID="lblRiesgoCon" Text="Gráfico Riesgos Consolidado" runat="server" ForeColor="Black"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="GVcriticidad" runat="server" CellPadding="4"
                                    ForeColor="#333333" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="true"
                                    ShowHeaderWhenEmpty="True" 
                                    HeaderStyle-CssClass="gridViewHeader" BorderStyle="Solid" GridLines="Vertical"
                                    CssClass="Apariencia" Font-Bold="False" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    
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
                    <td align="center">
                        <asp:GridView ID="GVriesgosSaro" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader"
                                    BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small"
                                     AllowPaging="True" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Riesgo Residual" DataField="Riesgo Inherente" />
                                        <asp:BoundField HeaderText="Valor" DataField="Valor" />
                                        
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
                        <asp:GridView ID="GVriesgoGlobal" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader"
                                    BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small"
                                     AllowPaging="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Riesgo" DataField="Riesgo" />
                                        <asp:BoundField HeaderText="Bajo" DataField="Bajo" />
                                        <asp:BoundField HeaderText="Moderado" DataField="Moderado" />
                                        <asp:BoundField HeaderText="Alto" DataField="Alto" />
                                        <asp:BoundField HeaderText="Extremo" DataField="Extremo" />
                                        
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
                    <td align="center">
                        
                        </td>
                    <td align="center">
                        <asp:Chart ID="Chart4" runat="server" Width="350px" BorderlineDashStyle="Solid"
            BorderlineColor="black">
                            <Legends>
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                LegendStyle="Row" />
        </Legends>
            <Series>
            <asp:series Name="Series1"></asp:series>
            </Series>
            <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
            </ChartAreas>
            </asp:Chart>
                    </td>
                    <td align="center">
                        <asp:Chart ID="ChartGeneral" runat="server" Width="350px" BorderlineDashStyle="Solid"
            BorderlineColor="black">
                            <Legends>
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                LegendStyle="Row" />
        </Legends>
            <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
            </ChartAreas>
            </asp:Chart>
                    </td>
                </tr>
            </table>--%>
               </div>
                <div class="col-lg-2"></div>
                <!-- End col-12 -->
                </div>
    <!-- End row -->
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
        
        <asp:Chart ID="ChartEstadoRoi" runat="server" Height="200px" Width="350px" 
                    BorderlineDashStyle="Solid" BorderlineColor="Black"
            OnPrePaint="ChartEstadoRoi_PrePaint"
                     >
    <Titles>
        <asp:Title ShadowOffset="3" Name="Items" Alignment="BottomCenter" />
    </Titles>
            <Legends>
        <asp:Legend Alignment="Far" Docking="Bottom"  IsTextAutoFit="true" Name="Default" LegendStyle="Row"
            TextWrapThreshold="4"/>
        
    </Legends>
    <Series>
        <asp:Series Name="Default" />
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartEstadoRoiArea" BorderWidth="0" />
    </ChartAreas>
</asp:Chart> 

            <asp:Chart ID="ChartNumeroRos" runat="server" Height="200px" Width="350px" 
                    BorderlineDashStyle="Solid" BorderlineColor="Black"
                     >
    <Titles>
        <asp:Title ShadowOffset="3" Name="Items" Alignment="TopCenter" />
    </Titles>
    <Series>
        <asp:Series Name="Default" />
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartNumeroRosArea" BorderWidth="0" />
    </ChartAreas>
</asp:Chart> 
            </div>
        <div class="col-lg-2"></div>
    </div>
    <!-- End row -->
    </div>
 
<%--<table align="center">
    <tr>
        <td align="center">
            <asp:Image ID="Fondo" runat="server" ImageUrl="~/Imagenes/Aplicacion/Sherlock Banner-2.jpg" Width="80%" />
        </td>
        </tr>
        </table>--%>
<asp:Button ID="btndummy" runat="server" Text="Button" Style="display: none" />
<asp:Panel ID="pnlMsgBox" runat="server" Width="400px" Style="display: none;" BorderColor="#575757"
    BackColor="#FFFFFF" BorderStyle="Solid">
    <table width="100%">
        <tr class="topHandle" style="background-color: #5D7B9D">
            <td colspan="2" align="center" runat="server" id="tdCaption">
                &nbsp;
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
