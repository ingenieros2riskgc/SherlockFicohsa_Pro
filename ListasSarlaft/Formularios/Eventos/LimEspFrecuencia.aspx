<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="LimEspFrecuencia.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.LimEspFrecuencia" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="LimEspFrecuencias" Src="~/UserControls/Eventos/LimEspFrecuencia.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:LimEspFrecuencias ID="LimEspFrecuenciass" runat="server" />
</asp:Content>
