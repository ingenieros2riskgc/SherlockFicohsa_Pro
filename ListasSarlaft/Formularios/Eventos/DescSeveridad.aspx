<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="DescSeveridad.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.DescSeveridad" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="DescSeveridadd" Src="~/UserControls/Eventos/DescSeveridad.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:DescSeveridadd ID="DescSeveridadd" runat="server" />
</asp:Content>
