<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="RiesgoGlobal.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.RiesgoGlobal" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="RiesgoGlobals" Src="~/UserControls/Eventos/RiesgoGlobal.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:RiesgoGlobals ID="RiesgoGlobals" runat="server" />
</asp:Content>
