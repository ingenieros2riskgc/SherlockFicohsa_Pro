<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="DesFactorRO.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.DesFactorRO" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="DesFactorROO" Src="~/UserControls/Eventos/DesFactorRO.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:DesFactorROO ID="DesFactorROO" runat="server" />
</asp:Content>
