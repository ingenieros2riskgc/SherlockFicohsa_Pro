<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="DescFrecuencia.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.DescFrecuencia" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="DescFrecuenciaa" Src="~/UserControls/Eventos/DescFrecuencia.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:DescFrecuenciaa ID="DescFrecuenciaa" runat="server" />
</asp:Content>
