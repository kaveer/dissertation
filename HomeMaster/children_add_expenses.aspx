<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/children.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="children_add_expenses.aspx.vb" Inherits="HomeMaster.children_add_expenses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="title_all" runat="server" Text="Add expense"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View_select_expense" runat="server">
            <div >
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_title" CssClass="subtitle1" runat="server" Text="Select Expense"></asp:Label>
                        </td>
                    </tr>
                </table> 
                <table>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList_select_expense" runat="server">
                                <asp:ListItem>Shopping </asp:ListItem>
                                <asp:ListItem>New expense</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_next_to_view2" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_view1" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:View>
        <asp:View ID="View_confirm_expenses" runat="server">
            <asp:Panel ID="Panel_shopping" Visible="false" runat="server">
                 <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle4" CssClass="subtitle1" runat="server" Text="Select shopping list"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_private_list" AllowPaging="true" PageSize="10" CssClass="grid" runat="server"></asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="GridView_private_list" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_panel_shopping" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_next_panel_shopping" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Button ID="Btn_check_total" runat="server" CssClass="btn" Text=" Check Total Cost" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_panel_shopping" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:View>
        <asp:View ID="View_save_expense" runat="server">
             <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="Save expense"></asp:Label>
                        </td>
                    </tr>
                </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_expense_name" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_expense_name" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_finance_type" runat="server" Text="Select type"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_finance_type" CssClass="ddlist" runat="server"></asp:DropDownList>
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
                        <asp:Label ID="lbl_category" runat="server" Text="Select category"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_category" CssClass="ddlist" runat="server"></asp:DropDownList>
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
                        <asp:Label ID="lbl_mean_payment" runat="server" Text="Select payment method"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_mean_payment" CssClass="ddlist" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_prev_view_save" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_save" CssClass="btn" runat="server" Text="Save" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_save" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
        </asp:View>
    </asp:MultiView>
        </div>
</asp:Content>
