<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/children.Master" CodeBehind="children_password_setting.aspx.vb" Inherits="HomeMaster.children_password_setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Password Setting"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="subdiv">
           <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle2" CssClass="subtitle1" runat="server" Text="Change password"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_current_passwrd" runat="server" Text="Current password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_current_passwrd" CssClass="txtbxNoSize-css" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_new_password" runat="server" Text="New password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_new_password" CssClass="txtbxNoSize-css" TextMode="Password"  runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_confirm_passwrd" runat="server" Text="Confirm password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_confirm_passwrd" CssClass="txtbxNoSize-css" TextMode="Password"  runat="server"></asp:TextBox>
                    </td>
                     <td>
                       <asp:CompareValidator runat="server" id="validation_confirm_password" controltovalidate="txtbx_confirm_passwrd" controltocompare="txtbx_new_password" operator="Equal" type="String" ForeColor="Red" errormessage="Password not match try again." />
                   </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_update_passrd" CssClass="btn" runat="server" Text="Update" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
