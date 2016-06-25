<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/children.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="children_add_income.aspx.vb" Inherits="HomeMaster.children_add_income" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div  class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="title_all" runat="server" Text="Add Income"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_expense_name" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_expense_name"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_finance_type" runat="server" Text="Select"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_finance_type"  CssClass="ddlist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_add_finance_type" runat="server" Text="Add type"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_add_finance_type" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_add_finance_type" CssClass="btn" runat="server" Text="Add" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_date" runat="server" Text="Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="validation_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_amount" runat="server" Text="Amount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_amount" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="validation_amount" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_amount" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_category" runat="server" Text="Select"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_category"  CssClass="ddlist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_add_category" runat="server" Text="Add category"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_add_category" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_add_category" CssClass="btn" runat="server" Text="Add" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_mean_payment" runat="server" Text="Select"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_mean_payment"  CssClass="ddlist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_add_mean_payment" runat="server" Text="Add mean of payment"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_add_mean_payment" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_add_mean_payment" CssClass="btn" runat="server" Text="Add" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_note" runat="server" Text="Note"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_note" CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_save" CssClass="btn" runat="server" Text="Save" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation_save" ForeColor="Red" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
