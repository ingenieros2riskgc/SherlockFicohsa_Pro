<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="TipoRiesgo.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.TipoRiesgo" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="TipoRiesgos" Src="~/UserControls/Eventos/TipoRiesgo.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:TipoRiesgos ID="TipoRiesgos" runat="server" />
</asp:Content>
