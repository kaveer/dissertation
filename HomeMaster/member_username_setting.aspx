<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" CodeBehind="member_username_setting.aspx.vb" Inherits="HomeMaster.member_username_setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Username Setting"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="subdiv">
           <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle2" CssClass="subtitle1" runat="server" Text="Change Username"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_current_username" runat="server" Text="Current username"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_current_username" CssClass="txtbxNoSize-css" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_new_username" runat="server" Text="New username"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_new_username" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_update_user" CssClass="btn" runat="server" Text="Update" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
