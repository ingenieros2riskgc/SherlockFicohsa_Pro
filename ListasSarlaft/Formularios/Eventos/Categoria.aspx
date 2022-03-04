<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.Categoria" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="Categoriaa" Src="~/UserControls/Eventos/Categoria.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:Categoriaa ID="Categoriaa" runat="server" />
</asp:Content>
