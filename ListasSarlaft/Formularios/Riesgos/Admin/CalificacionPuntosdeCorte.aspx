﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalificacionPuntosdeCorte.aspx.cs" MasterPageFile="~/MastersPages/Dashboard.Master" Inherits="ListasSarlaft.Formularios.Riesgos.Admin.CalificacionPuntosdeCorte" %>

<%@ OutputCache Location="None" %>


<%@ Register TagPrefix="T"  TagName="CalificacionExpPuntosDeCorte" Src="~/UserControls/Riesgos/CalificacionExpPuntosDeCorte.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <T:CalificacionExpPuntosDeCorte ID="CalificacionExpPuntosDeCorte" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
