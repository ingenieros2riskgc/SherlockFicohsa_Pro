<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="Severidad.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.Severidad" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="Severidadd" Src="~/UserControls/Eventos/Severidad.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:Severidadd ID="Severidadd" runat="server" />
</asp:Content>
