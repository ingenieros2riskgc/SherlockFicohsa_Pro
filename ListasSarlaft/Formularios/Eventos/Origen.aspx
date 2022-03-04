<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="Origen.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.Origen" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="Origenn" Src="~/UserControls/Eventos/Origen.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:Origenn ID="Origenn" runat="server" />
</asp:Content>
