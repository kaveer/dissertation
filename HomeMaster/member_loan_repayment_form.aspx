<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="member_loan_repayment_form.aspx.vb" Inherits="HomeMaster.member_loan_repayment_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="New repayment"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                    <asp:Label ID="lbl_subtitlw" CssClass="subtitle1" runat="server" Text="Add new repayment"></asp:Label>
                </td>
            </tr>
        </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_capital_pay" runat="server" Text="Capital Paid"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_capital_paid"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                    <td>
                         <asp:RegularExpressionValidator ID="validation_capital_paid" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_capital_paid" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_interst_paid" runat="server" Text="Interest paid"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_interest_paid"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                    <td>
                         <asp:RegularExpressionValidator ID="validation_interest_paid" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_interest_paid" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_interest_rate" runat="server" Text="interest rate(%)"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_interest_rate"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                    <td>
                         <asp:RegularExpressionValidator ID="validation_interest_rate" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_interest_rate" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_repayment_date" runat="server" Text="repayment date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_repayment_date"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                    <td>
                         <asp:CompareValidator id="validation_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_repayment_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_remark" runat="server" Text="remark"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_remark"  CssClass="txtbxDescrip-css" Width="205px" Height="50px"  TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>
             </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_validation_all" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_add_repayment" CssClass="btn" runat="server" Text="Add repayment" />
                </td>
            </tr>
        </table>
                 </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_select_loan" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
