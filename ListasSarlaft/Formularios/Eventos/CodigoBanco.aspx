<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="CodigoBanco.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.CodigoBanco" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="CodigoBancoo" Src="~/UserControls/Eventos/CodigoBanco.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:CodigoBancoo ID="CodigoBancoo" runat="server" />
</asp:Content>
