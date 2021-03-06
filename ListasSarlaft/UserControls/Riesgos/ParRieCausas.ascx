<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParRieCausas.ascx.cs"
    Inherits="ListasSarlaft.UserControls.Riesgos.ParRieCausas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<style type="text/css">
    .gridViewHeader a:link
    {
        text-decoration: none;
    }

    .FondoAplicacion
    {
        background-color: Gray;
        filter: alpha(opacity=80);
        opacity: 0.8;
    }

    .autocomplete_completionListElement
    {
        margin: 0px !important;
        background-color: inherit;
        color: windowtext;
        border: buttonshadow;
        border-width: 1px;
        border-style: solid;
        cursor: 'default';
        overflow: auto;
        height: 200px;
        text-align: left;
        list-style-type: none;
    }
    /* AutoComplete highlighted item */
    .autocomplete_highlightedListItem
    {
        background-color: #ffff99;
        color: black;
        padding: 1px;
    }
    /* AutoComplete item */
    .autocomplete_listItem
    {
        background-color: window;
        color: windowtext;
        padding: 1px;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table align="center" bgcolor="#EEEEEE">
            <tr align="center" bgcolor="#002649">
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
                        ForeColor="White" Text="Causas"></asp:Label>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <table>
                        <tr align="center">
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    ForeColor="#333333" GridLines="Vertical" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader"
                                    BorderStyle="Solid" HorizontalAlign="Justify" Font-Names="Calibri" Font-Size="Small" HeaderStyle-HorizontalAlign="Center"
                                    AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Causa" DataField="NombreCausas" >
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Acción">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnImgModificar" runat="server" CausesValidation="False" CommandName="Modificar"
                                                    ImageUrl="~/Imagenes/Icons/editV5.png" Text="Editar" ToolTip="Editar"
                                                    CommandArgument="<%# Container.DataItemIndex %>" />
                                                <asp:ImageButton ID="btnImgEliminar" runat="server" CausesValidation="False" CommandName="Borrar"
                                                    ImageUrl="~/Imagenes/Icons/deleteV5.png" Text="Eliminar" ToolTip="Eliminar"
                                                    CommandArgument="<%# Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <%-- <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/Icons/edit.png" Text="Editar"
                                            CommandName="Modificar" />
                                        <asp:ButtonField ButtonType="Image" CommandName="Borrar" ImageUrl="~/Imagenes/Icons/delete.png"
                                            Text="Eliminar"></asp:ButtonField>--%>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#002649" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr align="right">
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/Icons/AddV5.png"
                                    ToolTip="Insertar" OnClick="ImageButton1_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr align="center" id="trCampos" runat="server" visible="false">
                <td>
                    <table>
                        <tr align="center">
                            <td bgcolor="#BBBBBB">
                                <asp:Label ID="Label2" runat="server" Text="Causa" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                            </td>
                            <td bgcolor="#f0eef0">
                                <asp:TextBox ID="TextBox1" runat="server" Width="450px" Font-Names="Calibri" Font-Size="Small"
                                    AutoComplete="off" MaxLength="200"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" BehaviorID="TextBox1_AutoCompleteExtender"
                                    DelimiterCharacters="" TargetControlID="TextBox1" ServicePath="~/Formularios/WebService/AutoCompletar.asmx"
                                    ServiceMethod="GetCausas" FirstRowSelected="false" CompletionInterval="1000"
                                    EnableCaching="false" CompletionSetCount="20" MinimumPrefixLength="2" CompletionListCssClass="autocomplete_completionListElement"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                    ShowOnlyCurrentWordInCompletionListItem="true">
                                    <Animations>
                                        <OnShow>
                                            <Sequence>                        
                                                <OpacityAction Opacity="0" />
                                                <HideAction Visible="true" />
                                                <ScriptAction Script="
                                                    // Cache the size and setup the initial size
                                                    var behavior = $find('AutoCompleteEx');
                                                    if (!behavior._height) {
                                                        var target = behavior.get_completionList();
                                                        behavior._height = target.offsetHeight - 2;
                                                        target.style.height = '0px';
                                                    }" />                            
                                                <%-- Expand from 0px to the appropriate size while fading in --%>
                                                <Parallel Duration=".4">
                                                    <FadeIn />
                                                    <%--<Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />--%>
                                                    <Length PropertyKey="height" StartValue="0"  />
                                                </Parallel>
                                            </Sequence>
                                        </OnShow>
                                        <OnHide>
                                            <%-- Collapse down to 0px and fade out --%>
                                            <Parallel Duration=".4">
                                                <FadeOut />
                                                 <%--<Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />--%>
                                                  <Length PropertyKey="height"  EndValue="0" />
                                            </Parallel>
                                        </OnHide>
                                    </Animations>
                                </ajax:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                    ForeColor="Red" ValidationGroup="validarCampos">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                ToolTip="Guardar" Visible="false" ValidationGroup="validarCampos" OnClick="ImageButton2_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/Icons/guardarV5.png"
                                                ToolTip="Guardar" Visible="false" ValidationGroup="validarCampos" OnClick="ImageButton3_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Imagenes/Icons/cancelV5.png"
                                                ToolTip="Cancelar" OnClick="ImageButton4_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <ajax:ModalPopupExtender ID="mpeMsgBox" runat="server" TargetControlID="btndummy"
            PopupControlID="pnlMsgBox" OkControlID="btnAceptar" BackgroundCssClass="FondoAplicacion"
            Enabled="True" DropShadow="true">
        </ajax:ModalPopupExtender>
        <asp:Button ID="btndummy" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlMsgBox" runat="server" Width="400px" Style="display: none;" BorderColor="#575757"
            BackColor="#FFFFFF" BorderStyle="Solid">
            <table width="100%">
                <tr class="topHandle" style="background-color: #5D7B9D">
                    <td colspan="2" align="center" runat="server" id="tdCaption">&nbsp;
                        <asp:Label ID="lblCaption" runat="server" Text="Atención" Font-Names="Calibri" Font-Size="Small"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 60px" valign="middle" align="center">
                        <asp:Image ID="imgInfo" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
                    </td>
                    <td valign="middle" align="left">
                        <asp:Label ID="lblMsgBox" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Black"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnAceptar" runat="server" Text="Ok" Font-Names="Calibri" Font-Size="Small" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <ajax:ModalPopupExtender ID="mpeMsgBoxOkNo" runat="server" TargetControlID="btndummyOkNo"
            PopupControlID="pnlMsgBoxOkNo" OkControlID="btnCancelarOkNo" BackgroundCssClass="FondoAplicacion"
            Enabled="True" DropShadow="true">
        </ajax:ModalPopupExtender>
        <asp:Button ID="btndummyOkNo" runat="server" Text="Button" Style="display: none" />
        <asp:Label ID="lbldummyOkNo" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Panel ID="pnlMsgBoxOkNo" runat="server" Width="400px" Style="display: none;"
            BorderColor="#575757" BackColor="#FFFFFF" BorderStyle="Solid">
            <table width="100%">
                <tr class="topHandle" style="background-color: #5D7B9D">
                    <td colspan="2" align="center" runat="server" id="tdCaptionOkNo">&nbsp;
                        <asp:Label ID="lblCaptionOkNo" runat="server" Text="Atención" Font-Names="Calibri"
                            Font-Size="Small"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 60px" valign="middle" align="center">
                        <asp:Image ID="imgInfoOkNo" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
                    </td>
                    <td valign="middle" align="left">
                        <asp:Label ID="lblMsgBoxOkNo" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnAceptarOkNo" runat="server" Text="Ok" Font-Names="Calibri" Font-Size="Small"
                            OnClick="btnAceptarOkNo_Click" />
                        <asp:Button ID="btnCancelarOkNo" runat="server" Text="Cancelar" Font-Names="Calibri"
                            Font-Size="Small" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
