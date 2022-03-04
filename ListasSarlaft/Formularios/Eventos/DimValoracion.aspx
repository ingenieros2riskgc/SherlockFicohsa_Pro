<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="DimValoracion.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.DimValoracion" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="DimValoraciono" Src="~/UserControls/Eventos/DimValoracion.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:DimValoraciono ID="DimValoraciono" runat="server" />
</asp:Content>
