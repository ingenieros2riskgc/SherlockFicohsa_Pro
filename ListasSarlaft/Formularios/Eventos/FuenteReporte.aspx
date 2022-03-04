<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="FuenteReporte.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.FuenteReporte" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="FuenteReportes" Src="~/UserControls/Eventos/FuenteReporte.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:FuenteReportes ID="FuenteReportes" runat="server" />
</asp:Content>
