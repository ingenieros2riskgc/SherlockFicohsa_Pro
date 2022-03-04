<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="DesCausaNDos.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.DesCausaNDos" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="DesCausaNDoso" Src="~/UserControls/Eventos/DesCausaNDos.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:DesCausaNDoso ID="DesCausaNDoso" runat="server" />
</asp:Content>
