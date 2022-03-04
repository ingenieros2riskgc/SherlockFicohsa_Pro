<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="DescLineaDos.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.DescLineaDos" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="DescLineaDoss" Src="~/UserControls/Eventos/DescLineaDos.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:DescLineaDoss ID="DescLineaDoss" runat="server" />
</asp:Content>
