<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="Anios.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.Anios" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="Anioss" Src="~/UserControls/Eventos/Anios.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:Anioss ID="Anioss" runat="server" />
</asp:Content>
