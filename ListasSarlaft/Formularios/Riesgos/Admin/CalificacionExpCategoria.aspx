<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalificacionExpCategoria.aspx.cs" MasterPageFile="~/MastersPages/Dashboard.Master" Inherits="ListasSarlaft.Formularios.Riesgos.Admin.CalificacionExpCategoria" %>

<%@ OutputCache Location="None" %>


<%@ Register TagPrefix="T"  TagName="CalificacionExpCategorias" Src="~/UserControls/Riesgos/CalificacionExpCategoria.ascx"%>

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
    <T:CalificacionExpCategorias ID="CalificacionExpCategorias" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>