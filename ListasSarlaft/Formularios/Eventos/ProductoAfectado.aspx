<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="ProductoAfectado.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.ProductoAfectado" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="ProductoAfectado" Src="~/UserControls/Eventos/Producto.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:ProductoAfectado ID="ProductoAfectado" runat="server" />
</asp:Content>
