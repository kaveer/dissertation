<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="family_add_expense.aspx.vb" Inherits="HomeMaster.family_add_expense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div  class="maindivChildHome">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View_select_expense" runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_title" runat="server" CssClass="title_all" Text="Select Expense"></asp:Label>
                        </td>
                    </tr>
                </table> 
                <table>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList_select_expense" runat="server">
                                <asp:ListItem>Movable assets</asp:ListItem>
                                <asp:ListItem>Immovable property</asp:ListItem>
                                <asp:ListItem>Repayments</asp:ListItem>
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
            <asp:Panel ID="Panel_movable_asset" Visible ="false" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_select_subtitle1"  CssClass="subtitle1" runat="server" Text="Select movable asset"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_movable_asset" AllowPaging="true" PageSize="5" CssClass="grid" runat="server"></asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="GridView_movable_asset" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_panel_movable_asset" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_next_panel_movable_asset" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_panel_movable_asset" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel_immovable_asset" runat="server">
                 <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle2"  CssClass="subtitle1" runat="server" Text="Select immovable asset"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_immovable_property" AllowPaging="true" PageSize="5" CssClass="grid" runat="server"></asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="GridView_immovable_property" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_panel_immovable_property" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_next_panel_immovable_property" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_panel_immovable_property" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel_repayments" Visible ="false" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle_3"  CssClass="subtitle1" runat="server" Text="Select Repayment"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList_repayment" runat="server">
                                <asp:ListItem>Insurance repayment</asp:ListItem>
                                <asp:ListItem>Loan repayment</asp:ListItem>
                                <asp:ListItem>Asset repayment</asp:ListItem>
                                <asp:ListItem>Immovable property repayment</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_panel_repayment" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_next_panel_repayment" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_panel_repayment" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel_shopping" Visible="false" runat="server">
                 <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle4"  CssClass="subtitle1" runat="server" Text="Select shopping list"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_private_list" AllowPaging="true" PageSize="5" CssClass="grid" runat="server"></asp:GridView>
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
                            <asp:Button ID="Btn_check_total" CssClass="btn" runat="server" Text=" Check Total Cost" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_panel_shopping" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:View>
        <asp:View ID="View_repayment" runat="server">
            <asp:Panel ID="Panel_insurance_repay" Visible="false" runat="server">
                 <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle5"  CssClass="subtitle1" runat="server" Text="Select insurance repayment"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_insurance_repayment" AllowPaging="true" PageSize="5" CssClass="grid" runat="server"></asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="GridView_insurance_repayment" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_panel_insurance_repayment" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_next_panel_insurance_repayment" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_panel_insurance_repayment" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel_loan_repayment" Visible="false" runat="server">
                 <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle6"  CssClass="subtitle1" runat="server" Text="Select loan repayment"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_loan_repayment" AllowPaging="true" PageSize="5" CssClass="grid" runat="server"></asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="GridView_loan_repayment" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_panel_loan_repayment" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_next_panel_loan_repayment" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_panel_loan_repayment" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel_movable_asset_repayment" Visible="false" runat="server">
                 <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle7"  CssClass="subtitle1" runat="server" Text="Select asset repayment"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_movable_asset_repayment" AllowPaging="true" PageSize="5" CssClass="grid" runat="server"></asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="GridView_movable_asset_repayment" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_movable_asset_repayment" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_next_movable_asset_repayment" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_movable_asset_repayment" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
             <asp:Panel ID="Panel_immov_property_repayment" Visible="false" runat="server">
                 <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle8"  CssClass="subtitle1" runat="server" Text="Select property repayment"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_immov_property_repayment" AllowPaging="true" PageSize="5" CssClass="grid" runat="server"></asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="GridView_immov_property_repayment" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_panel_immov_property_repayment" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_next_panel_immov_property_repayment" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_immov_property_repayment" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:View>
        <asp:View ID="View_save_expense" runat="server">
             <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1"  CssClass="subtitle1" runat="server" Text="Save expense"></asp:Label>
                        </td>
                    </tr>
                </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_expense_name" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_expense_name" CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtbx_add_finance_type" CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtbx_date" CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtbx_amount" CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtbx_add_category" CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtbx_add_mean_payment" CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
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
