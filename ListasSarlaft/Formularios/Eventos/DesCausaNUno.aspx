<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="DesCausaNUno.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.DesCausaNUno" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="DesCausaNUnoo" Src="~/UserControls/Eventos/DesCausaNUno.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:DesCausaNUnoo ID="DesCausaNUnoo" runat="server" />
</asp:Content>
