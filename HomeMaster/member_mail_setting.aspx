<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" EnableEventValidation = "false" CodeBehind="member_mail_setting.aspx.vb" Inherits="HomeMaster.member_mail_setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Email Setting"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="subdiv">
           <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle2" CssClass="subtitle1" runat="server" Text="Add email"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_addmail" runat="server" Text="Add new mail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_add_mail" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btn_add_mail" CssClass="btn" runat="server" Text="Add mail" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation_mail" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="validation_email" ControlToValidate="txtbx_add_mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ForeColor="Red" ErrorMessage="Invalid email address"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="subtitle1" runat="server" Text="All email address"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView_email" CssClass="grid" AllowPaging="true" PageSize="7" runat="server"></asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                 <asp:AsyncPostBackTrigger ControlID="GridView_email" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_remove_mail" CssClass="btn" runat="server" Text="Remove" />
                    </td>
                    <td>
                        <asp:Button ID="btn_set_as_primary" CssClass="btn" runat="server" Text="Set as primary" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
