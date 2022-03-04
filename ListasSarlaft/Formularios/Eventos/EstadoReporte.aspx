<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="EstadoReporte.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.EstadoReporte" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="EstadoReportes" Src="~/UserControls/Eventos/EstadoReporte.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:EstadoReportes ID="EstadoReportes" runat="server" />
</asp:Content>
