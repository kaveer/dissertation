<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" EnableEventValidation = "false" CodeBehind="member_remove_loan_form.aspx.vb" Inherits="HomeMaster.member_remove_loanaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title"  CssClass="title_all"  runat="server" Text="Remove loan"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subtitle_1" CssClass="subtitle1"  runat="server" Text="All active loan"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_select_loan" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_validation_active" runat="server" ForeColor ="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_deactive_loan" CssClass="btn" runat="server" Text="Deactivate" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                         <td>
                             <asp:Label ID="lbl_subtitle_2" CssClass="subtitle1"  runat="server" Text="All deactivated loan"></asp:Label>
                         </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_deactivated_loan" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_validation_deactive" runat="server" ForeColor ="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_reactivate_loan" CssClass="btn" runat="server" Text="Activate" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_select_loan" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="GridView_deactivated_loan" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel> 
    </div>
</asp:Content>
