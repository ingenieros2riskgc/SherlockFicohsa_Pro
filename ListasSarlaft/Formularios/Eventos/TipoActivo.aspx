<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="TipoActivo.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.TipoActivo" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="TipoActivoo" Src="~/UserControls/Eventos/TipoActivo.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:TipoActivoo ID="TipoActivoo" runat="server" />
</asp:Content>
