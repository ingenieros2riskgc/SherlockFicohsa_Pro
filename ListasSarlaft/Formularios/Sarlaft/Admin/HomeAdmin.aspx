<%@ Page Title="Sherlock" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true"
    CodeBehind="HomeAdmin.aspx.cs" Inherits="ListasSarlaft.Formularios.Admin.HomeAdmin" %>
<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCH" TagName="Home" Src="~/UserControls/Sitio/Home.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <CCH:Home ID="Home" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>