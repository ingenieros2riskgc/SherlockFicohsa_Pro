<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="Modalidad.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.Modalidad" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="Modalidadd" Src="~/UserControls/Eventos/Modalidad.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:Modalidadd ID="Modalidadd" runat="server" />
</asp:Content>
