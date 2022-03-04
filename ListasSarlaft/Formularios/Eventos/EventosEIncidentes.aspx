<%@ Page Title="Sherlock" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/MastersPages/Dashboard.Master" AutoEventWireup="true" CodeBehind="EventosEIncidentes.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.EvsEIncs" %>
<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCE" TagName="EvsEIncss" Src="~/UserControls/Eventos/EventosEIncidentes.ascx" %>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <CCE:EvsEIncss ID="EvsEIncss" runat="server" />
</asp:Content>

