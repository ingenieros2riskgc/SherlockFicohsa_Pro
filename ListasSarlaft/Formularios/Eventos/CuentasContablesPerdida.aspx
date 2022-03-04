<%@ Page Title="Sherlock" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="CuentasContablesPerdida.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.CuentasContablesPerdida" %>

<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCR" TagName="CuentasContablesPerdidao" Src="~/UserControls/Eventos/CuentasContablesPerdida.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCR:CuentasContablesPerdidao ID="CuentasContablesPerdidao" runat="server" />
</asp:Content>
