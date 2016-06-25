<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master"  EnableEventValidation = "false"  CodeBehind="family_view_insurance.aspx.vb" Inherits="HomeMaster.family_view_insurance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="View insurance"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="All insurance"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_select_insurance" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                <asp:Menu ID="Menu1" runat="server"  CssClass="menu_control_css"  Orientation="Horizontal">
                    <StaticHoverStyle BackColor="#9fa8a3" />
                    <StaticMenuItemStyle CssClass="menu_control_not_selec" />
                    <StaticSelectedStyle BackColor="#9fa8a3" />
                    <Items>
                        <asp:MenuItem Text="Company details" Value="0" Selected="true"></asp:MenuItem>
                        <asp:MenuItem Text="Insurance policy" Value="1"></asp:MenuItem>
                        <asp:MenuItem Text="Cover details" Value="2"></asp:MenuItem>
                    </Items>
                </asp:Menu>

                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="company_view" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:DetailsView ID="DetailsView_company_detail" CssClass="grid" runat="server" Height="50px" Width="400px"></asp:DetailsView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="policy_view" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:DetailsView ID="DetailsView_policy" CssClass="grid" runat="server" Height="50px" Width="400px"></asp:DetailsView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="cover_view" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:DetailsView ID="DetailsView_cover" CssClass="grid" runat="server" Height="50px" Width="400px"></asp:DetailsView>
                                </td>
                                <td>
                                    <asp:Repeater ID="Repeater_image" runat="server">
                                        <ItemTemplate>
                                            <asp:Image runat="server" ID="imgrep" Width="200px" Height="200px" ImageUrl='<%# Eval("picUrl")%>' />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_edit_insurance" CssClass="btn" runat="server" Text="Edit" />
                        </td>
                        <td>
                            <asp:Button ID="btn_remove_insurance" CssClass="btn" runat="server" Text="Remove" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validaiton" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <asp:Label ID="lbl_subtitle1" runat="server" CssClass="subtitle1" Text="All deactivated insurance"></asp:Label>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_deactive_insurance" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_reactive" CssClass="btn" runat="server" Text="reactive insurance" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation2" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_select_insurance" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="GridView_deactive_insurance" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        
    </div>

</asp:Content>
