<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/children.Master" CodeBehind="children_security_setting.aspx.vb" Inherits="HomeMaster.children_security_setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Security Setting"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="subdiv">
           <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle2" CssClass="subtitle1" runat="server" Text="Question verification"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_change_question" runat="server" Text="change question"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_question" CssClass="ddlist" runat="server">
                            <asp:ListItem Selected="True">What was the name of your elementary / primary school</asp:ListItem>
                            <asp:ListItem>In what city or town does your nearest sibling live</asp:ListItem>
                            <asp:ListItem>What is your pet’s name</asp:ListItem>
                            <asp:ListItem>What is your favorite music</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_answer" runat="server" Text="Answer"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_answer" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_update_answer" CssClass="btn" runat="server" Text="Update" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
