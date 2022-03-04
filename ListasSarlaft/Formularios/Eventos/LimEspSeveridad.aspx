<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="LimEspSeveridad.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.LimEspSeveridad" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="LimEspSeveridads" Src="~/UserControls/Eventos/LimEspSeveridad.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:LimEspSeveridads ID="LimEspSeveridadss" runat="server" />
</asp:Content>  
