<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="LimGblFrecuencia.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.LimGblFrecuencia" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="LimGblFrecuencias" Src="~/UserControls/Eventos/LimGblFrecuencia.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:LimGblFrecuencias ID="LimGblFrecuencias" runat="server" />
</asp:Content>
