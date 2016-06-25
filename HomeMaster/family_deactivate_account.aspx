<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master" CodeBehind="family_deactivate_account.aspx.vb" Inherits="HomeMaster.family_deactivate_account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Deactivate account"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="subdiv">
          <%-- <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle2" CssClass="subtitle1" runat="server" Text="Question verification"></asp:Label>
                    </td>
                </tr>
            </table>--%>
            <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                <asp:View ID="View_deactivate_acct" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btn_confirm_deactivation" CssClass="btn" runat="server" Text="Click to deactivate" />
                            </td>
                            <td>
                                <asp:Label ID="lbl_display_username" runat="server" Text="Are you sure you want to deactivate user"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_display_user" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_enter_password" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_enter_passwrd" runat="server" Text="Enter password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbx_enter_password" CssClass="txtbxNoSize-css" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_deactivate" CssClass="btn"  runat="server" Text="Deactivate" />
                            </td>
                            <td>
                                <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
           
        </div>
    </div>
</asp:Content>
