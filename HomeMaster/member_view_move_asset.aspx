<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" EnableEventValidation = "false" CodeBehind="member_view_move_asset.aspx.vb" Inherits="HomeMaster.member_view_move_asset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="View fixed asset"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="All fixed asset"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                     <tr>
                        <td>
                            <asp:GridView ID="GridView_view_active_preview_assets" CssClass ="grid" AllowPaging ="true" pagesize="5"  runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:DetailsView ID="DetailsView_active_asset" CssClass ="grid" runat="server" Height="50px" Width="400px"></asp:DetailsView>
                        </td>
                        <td>
                            <asp:Panel ID="Panel_view_img" Visible="false" Height="335px" Width="550px" ScrollBars="vertical" runat="server">
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <asp:Image runat="server" ID="imgrep" Width="100px" Height="100px" ImageUrl='<%# Eval("picUrl")%>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <br />
                                        <asp:Button ID="btn_open_gallery" CssClass="btn" CommandName="open_gallery" runat="server" Text="Open gallery" />
                                    </FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_view_active_preview_assets" EventName="SelectedIndexChanged" />
                <asp:PostBackTrigger ControlID="Repeater1" />
            </Triggers>
        </asp:UpdatePanel>

        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_added_by" runat="server" Text="added by"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_member_added" CssClass="ddlist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_location" runat="server" Text="location"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_location" CssClass="ddlist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_category" runat="server" Text="category"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_category" CssClass="ddlist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_search" CssClass="btn" runat="server" Text="Search" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_add_mve_asset" CssClass="btn" runat="server" Text="Add new asset" />
                </td>
                <td>
                    <asp:Button ID="btn_remove_asset" CssClass="btn" runat="server" Text="Remove asset" />
                </td>
                <td>
                    <asp:Button ID="btn_add_repayment" CssClass="btn" runat="server" Text="Add repayment" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation_remove" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Deactivated asset"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_deactivated_asset" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_deactivated_asset" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        
         <table>
            <tr>
                <td>
                    <asp:Button ID="btn_reactivate" CssClass="btn" runat="server" Text="Reactivate" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation_reactivate" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel_open_gallery" CssClass="popViewAsset_pic" ScrollBars="Vertical" Height="700px" Visible="false"  runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="title_all" runat="server" Text="Gallery"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_close_gallery" runat="server" CssClass="btn" Text="Close gallery" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView_open_gallery" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--<asp:CheckBox ID="chkCtrl" runat="server" />--%>
                            <asp:Image runat="server" ID="imgrep" Width="700px" Height="600px" ImageUrl='<%# Eval("picUrl")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
