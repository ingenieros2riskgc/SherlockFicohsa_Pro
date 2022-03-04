<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="DescLineaUno.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.DescLineaUno" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="DescLineaUnoo" Src="~/UserControls/Eventos/DescLineaUno.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:DescLineaUnoo ID="DescLineaUnoo" runat="server" />
</asp:Content>
