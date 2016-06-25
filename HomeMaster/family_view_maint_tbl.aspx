<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="family_view_maint_tbl.aspx.vb" Inherits="HomeMaster.family_view_maint_tbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="view maintenance"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
             <tr>
                <td>
                    <asp:Label ID="lbl_select_obj" runat="server" Text="Select "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_select_obj" CssClass="ddlist" runat="server" AutoPostBack="True">
                        <asp:ListItem >--select type--</asp:ListItem>
                        <asp:ListItem>immovable property</asp:ListItem>
                        <asp:ListItem>movable asset</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        
                        <td>

                            <asp:GridView ID="GridView_select_propty_asset" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_movable_asset" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_select_propty_asset" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="GridView_movable_asset" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_delete_maint" CssClass="btn" runat="server" Text="delete maintenance" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation" runat="server" ForeColor ="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
