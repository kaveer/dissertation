<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" EnableEventValidation = "false" CodeBehind="member_view_immov_property.aspx.vb" Inherits="HomeMaster.member_view_immov_property" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="maindivChildHome">
         <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="View property"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="All property"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_active_immov" CssClass ="grid" AllowPaging ="true" pagesize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        
                        <td>
                            <asp:Label ID="lbl_category" runat="server" Text="category"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_category" CssClass="ddlist" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lbl_purchase_method" runat="server" Text="Purchase method"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_purchase_method"  CssClass="ddlist" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_search" CssClass="btn" runat="server" Text="Search" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>

                <asp:Menu ID="Menu1" runat="server" CssClass="menu_control_css" Orientation="Horizontal">
                    <StaticHoverStyle BackColor="#9fa8a3" />
                    <StaticMenuItemStyle CssClass="menu_control_not_selec" />
                    <StaticSelectedStyle BackColor="#9fa8a3" />
                    <Items>
                        <asp:MenuItem Text="Property detail" Value="0" Selected="true"></asp:MenuItem>
                        <asp:MenuItem Text="property gallery" Value="1"></asp:MenuItem>
                        <asp:MenuItem Text="Room detail" Value="2"></asp:MenuItem>
                    </Items>
                </asp:Menu>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="property_detail" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:DetailsView ID="DetailsView_property_detail" CssClass="grid" runat="server" Height="50px" Width="200px"></asp:DetailsView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="property_gallery" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel_property_gallery" ScrollBars="Vertical" Height="500px" runat="server">
                                        <asp:Repeater ID="Repeater_property_gallery" runat="server">
                                        <ItemTemplate>
                                            <asp:Image runat="server" ID="imgrep" Width="700px" Height="700px" ImageUrl='<%# Eval("i_picUrl")%>' />
                                        </ItemTemplate>
                                        <%--<FooterTemplate>
                                            <br />
                                            <asp:Button ID="btn_open_gallery" CommandName="open_gallery" runat="server" Text="Open gallery" />
                                        </FooterTemplate>--%>
                                    </asp:Repeater>
                                    </asp:Panel>
                                    
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="room_detail" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView_room_detail" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel_room_img" ScrollBars="Vertical" Height="500px" Width="750px" runat="server">
                                        <asp:Repeater ID="Repeater_room_img" runat="server">
                                            <ItemTemplate>
                                                <asp:Image runat="server" ID="imgrep" Width="700px" Height="700px" ImageUrl='<%# Eval("room_picUrl")%>' />
                                            </ItemTemplate>
                                            <%-- <FooterTemplate>
                                            <br />
                                            <asp:Button ID="btn_open_gallery" CommandName="open_gallery" runat="server" Text="Open gallery" />
                                        </FooterTemplate>--%>
                                        </asp:Repeater>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_active_immov" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="GridView_room_detail" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_add_immov_property" CssClass="btn"  runat="server" Text="Add new property" />
                </td>
                <td>
                    <asp:Button ID="btn_remove_property" CssClass="btn" runat="server" Text="Remove property" />
                </td>
                <td>
                    <asp:Button ID="btn_add_repayment" CssClass="btn" runat="server" Text="Add repayment" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation_remove" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
         <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Deactivated property"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_deactivated_property" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_deactivated_property" EventName="SelectedIndexChanged" />
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
    </div>
</asp:Content>
