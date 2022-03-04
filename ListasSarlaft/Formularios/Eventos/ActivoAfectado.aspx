<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="ActivoAfectado.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.ActivoAfectado" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="ActivoAfectado" Src="~/UserControls/Eventos/Activo.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:ActivoAfectado ID="ActivoAfectado" runat="server" />
</asp:Content>
