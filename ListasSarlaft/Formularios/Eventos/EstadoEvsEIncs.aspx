<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="EstadoEvsEIncs.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.EstadoEvsEIncs" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="EstadoEvsEIncss" Src="~/UserControls/Eventos/EstadoEvsEIncs.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:EstadoEvsEIncss ID="EstadoEvsEIncss" runat="server" />
</asp:Content>
