<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="family_add_repay_insur.aspx.vb" Inherits="HomeMaster.family_add_repay_insur" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Add new payment"></asp:Label>
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
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_select_insurance" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Add repayment"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_due_date" runat="server" Text="Due date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_due_date"  CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:CompareValidator id="validation_due_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_due_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_total_amount" runat="server" Text="Total Amount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_total_amount"   CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:RegularExpressionValidator ID="validation_total_amount" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_total_amount" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_amount_paid" runat="server" Text="Amount paid"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_amount_paid"  CssClass="txtbxNoSize-css"  AutoPostBack="true" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="validation_amount_paid" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_amount_paid" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_amount_remain" runat="server" Text="Total amount remaining"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_amount_remain"  CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="validation_amount_remain" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_amount_remain" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_save_repayment" CssClass="btn" runat="server" Text="Save" />
                </td>
                <td>
                    <asp:Button ID="btn_view_repayment"  CssClass="btn" runat="server" Text="View repayment" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
