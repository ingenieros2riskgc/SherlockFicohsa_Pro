﻿<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="ParRieClasificacionRiesgo.aspx.cs" Inherits="ListasSarlaft.Formularios.Riesgos.Admin.ParRieClasificacionRiesgo" %>
<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCPRCR"  TagName="ClasificacionRiesgo" Src="~/UserControls/Riesgos/ParRieClasificacionRiesgo.ascx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <CCPRCR:ClasificacionRiesgo ID="ClasificacionRiesgo" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>