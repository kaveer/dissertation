<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" EnableEventValidation = "false" Culture = "en-GB"  CodeBehind="member_add_mv_asset_repay.aspx.vb" Inherits="HomeMaster.member_add_mv_asset_repay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
         <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Add asset repayment"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_view_active_preview_assets" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
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
                                   
                                </asp:Repeater>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="Repayments"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_repayment" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_view_active_preview_assets" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_repay_date" runat="server" Text="Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_repay_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator id="validation_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_repay_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_repay_amount" runat="server" Text="Amount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_repay_amount" CssClass="txtbxNoSize-css" CausesValidation="true" AutoPostBack="true" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="validation_amount" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_repay_amount" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_repay_remain" runat="server" Text="Amount remain"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_repay_remain" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:RegularExpressionValidator ID="validation_remain" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_repay_remain" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_save" CssClass="btn" runat="server" Text="Save" />
                </td>
                <td>
                    <asp:Button ID="btn_remove_repayment" CssClass="btn" runat="server" Text="Remove repayment" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
