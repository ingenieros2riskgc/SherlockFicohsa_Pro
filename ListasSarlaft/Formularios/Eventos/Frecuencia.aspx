<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="Frecuencia.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.Frecuencia" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="Frecuenciaa" Src="~/UserControls/Eventos/Frecuencia.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:Frecuenciaa ID="Frecuenciaa" runat="server" />
</asp:Content>
