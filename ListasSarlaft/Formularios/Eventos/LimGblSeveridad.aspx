<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="LimGblSeveridad.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.LimGblSeveridad" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="LimGblSeveridads" Src="~/UserControls/Eventos/LimGblSeveridad.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:LimGblSeveridads ID="LimGblSeveridads" runat="server" />
</asp:Content>  
