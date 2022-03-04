<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="PrmAdmJerarquiaOrg.aspx.cs" Inherits="ListasSarlaft.Formularios.Parametrizacion.Admin.PrmAdmJerarquiaOrg" %>
<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCJO" TagName="JerarquiaOrganizacional" Src="~/UserControls/Parametrizacion/JerarquiaOrganizacional.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCJO:JerarquiaOrganizacional ID="JerarquiaOrganizacional" runat="server" />
</asp:Content>
