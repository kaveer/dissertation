<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master" Culture = "en-GB" CodeBehind="family_edit_loan_form.aspx.vb" Inherits="HomeMaster.family_edit_loan_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div  class="maindiv_edit_loan">
         <table>
             <tr>
                 <td>
                     <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Edit loan"></asp:Label>
                 </td>
             </tr>
         </table>
         <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel18" runat="server">
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
                             <asp:Label ID="lbl_subtitle_1" CssClass="subtitle1" runat="server" Text="Edit loan"></asp:Label>
                         </td>
                     </tr>
                 </table>
                 <asp:Menu ID="Menu1" CssClass="menu_vertical" Orientation="Vertical" runat="server">
                     <StaticHoverStyle BackColor="#9fa8a3" />
                     <StaticMenuItemStyle CssClass="menu_control_not_selec" />
                     <StaticSelectedStyle BackColor="#9fa8a3" />
                     <Items>
                         <asp:MenuItem Text="lender edit" Value="0" Selected="true"></asp:MenuItem>
                         <asp:MenuItem Text="loan edit" Value="1"></asp:MenuItem>
                         <asp:MenuItem Text="repayment edit" Value="2"></asp:MenuItem>
                     </Items>
                 </asp:Menu>
                 <asp:Panel ID="Panel1" CssClass="panel_edit_loan" runat="server">
                     <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                         <asp:View ID="lennder_view" runat="server">
                             <table>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_subtitle_2" CssClass="subtitle1" runat="server" Text="Edit lender information"></asp:Label>
                                     </td>
                                 </tr>
                             </table>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_lendername" runat="server">lender name</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_lender_name_edit" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_name_edit" runat="server" Text="Enter name :"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_name_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_lender_name_edit" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_lenderDescription" runat="server">lender description</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_lender_descrip_edit" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_decsrip_edit" runat="server" Text="Enter description"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_descrip_edit" CssClass="txtbxDescrip-css" Width="205px" Height="50px"  TextMode="MultiLine" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_lender_descrip_edit" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_lendermail" runat="server">lender mail</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_lendermail" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_mail_edit" runat="server" Text="enter mail address"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_mail_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_lender_mail" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_lender_email" ControlToValidate="txtbx_lender_mail_edit" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ForeColor="Red" ErrorMessage="Invalid email address"></asp:RegularExpressionValidator>
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_lendertype" runat="server">lender type</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_lender_type" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_type_edit" runat="server" Text="Select type"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:DropDownList ID="ddl_lender_type_edit" CssClass="ddlist" runat="server"></asp:DropDownList>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_lender_type_edit" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_add_new_type" runat="server" Text="Add new type"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_add_new_type" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_add_new_type" CssClass="btn" runat="server" Text="Add" />
                                         </td>
                                     </tr>

                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_lenderlocation" runat="server">location</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_lender_location" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_street_edit" runat="server" Text="Enter street"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_street_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_town_edit" runat="server" Text="Enter town"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_town_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_lender_town" runat="server" ControlToValidate="txtbx_lender_town_edit" ValidationExpression="[a-zA-Z ]*$" ForeColor="Red" ErrorMessage="not a valid name try again " />
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_country_edit" runat="server" Text="Enter country"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_country_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_lender_country" runat="server" ControlToValidate="txtbx_lender_country_edit" ValidationExpression="[a-zA-Z ]*$" ForeColor="Red" ErrorMessage="not a valid name try again " />
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_postal_edit" runat="server" Text="Enter postal code"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_postal_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_postal_code" runat="server" ControlToValidate="txtbx_lender_postal_edit" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Button ID="btn_save_lender_location" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_lender_contact" runat="server">lender Contact information</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_lender_contact" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_phn_fix_edit" runat="server" Text="Enter Phone number fix"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_phn_fix_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_phn_fix" runat="server" ControlToValidate="txtbx_lender_phn_fix_edit" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_phn_ptb_edit" runat="server" Text="Enter mobile number"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_phn_ptb_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_phn_ptb" runat="server" ControlToValidate="txtbx_lender_phn_ptb_edit" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_fax_edit" runat="server" Text="Enter fax"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_fax_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_fax" runat="server" ControlToValidate="txtbx_lender_fax_edit" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_lender_website_edit" runat="server" Text="website "></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_lender_website_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Button ID="btn_save_lender_contact" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_validation_view1" runat="server" ForeColor=" red" Text=""></asp:Label>
                                     </td>
                                 </tr>
                             </table>
                         </asp:View>
                         <asp:View ID="loan_view" runat="server">
                             <table>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_subtitle_3" CssClass="subtitle1" runat="server" Text="Edit loan information"></asp:Label>
                                     </td>
                                 </tr>
                             </table>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_loan_name" runat="server">loan name</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_loan_name" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_loan_name_edit" runat="server" Text="Loan name"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_loan_name_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_loan_name_edit" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_loantype" runat="server">loan type</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_loan_type" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_loan_type_edit" runat="server" Text="Select type"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:DropDownList ID="ddl_loan_type" CssClass="ddlist" runat="server"></asp:DropDownList>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_loan_type" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_add_loan_type" runat="server" Text="Add new type"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_add_loan_type" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_add_loan_type" CssClass="btn" runat="server" Text="Add new type" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_loandetail" runat="server">Loan description</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_loandetail" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_loan_detail_edit" runat="server" Text="Loan detail"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_loan_detail_edit"  CssClass="txtbxDescrip-css" Width="205px" Height="50px"  TextMode="MultiLine"  runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_loan_detail_edit" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_amount" runat="server">amount</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_loan_amount" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_loan_amount_edit" runat="server" Text="Enter amount"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_loan_amount_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_loan_amount" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_loan_amount" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_loan_amount_edit" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_interest_rate" runat="server">Interest rate</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_interest_rate" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_loan_inrst_rate_edit" runat="server" Text="interest rate"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_interest_rate" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_loan_inrst_rate_edit" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_intrest_rate" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_interest_rate" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_date_taken" runat="server">date taken</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_date_taken" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_loan_date_edit" runat="server" Text="Enter date"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_loan_date_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_loan_date_edit" CssClass="btn" runat="server" Text="Save" />
                                         </td>
                                         <td>
                                             <asp:CompareValidator ID="validation_date_taken" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_loan_date_edit" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                                             <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_loan_term" runat="server">loan term</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_loan_term" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_loan_term_edit" runat="server" Text="Loan term"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_loan_term_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_loan_term_edit" CssClass="btn" runat="server" Text="save" />
                                         </td>
                                         <td>
                                             <asp:RegularExpressionValidator ID="validation_loan_term" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_loan_term_edit" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_guarantor" runat="server">Guarantor</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_guarantor" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_guarantor_edit" runat="server" Text="enter guarantor name"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_guarantor_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_guarantor_edit" CssClass="btn" runat="server" Text="save" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="link_mortgage" runat="server">mortgage</asp:LinkButton>
                                     </td>
                                 </tr>
                             </table>
                             <asp:Panel ID="panel_mortgage" Visible="false" runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lbl_mortgage_edit" runat="server" Text="mortgage"></asp:Label>
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtbx_mortgage_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                         </td>
                                         <td>
                                             <asp:Button ID="btn_save_mortgage" CssClass="btn" runat="server" Text="save" />
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_validation_view2" runat="server" ForeColor=" red" Text=""></asp:Label>
                                     </td>
                                 </tr>
                             </table>
                         </asp:View>
                         <asp:View ID="repayment_view" runat="server">
                             <table>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_subtitle_4" CssClass="subtitle1" runat="server" Text="Edit loan repayment"></asp:Label>
                                     </td>
                                 </tr>
                             </table>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:GridView ID="GridView_loan_repayment" CssClass="grid" AllowPaging="true" PageSize ="3" runat="server"></asp:GridView>
                                     </td>
                                 </tr>
                             </table>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_repay_capital_edit" runat="server" Text="Capital"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="txtbx_repy_capital_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                     </td>
                                     <td>
                                         <asp:RegularExpressionValidator ID="validation_repay_capital" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_repy_capital_edit" />
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_repay_interst_paid_edit" runat="server" Text="Interest paid"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="txtbx_repay_interest_paid_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                     </td>
                                     <td>
                                         <asp:RegularExpressionValidator ID="validation_repay_intrst_paid" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_repay_interest_paid_edit" />
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_repay_intrst_rate_edit" runat="server" Text="interest rate(%)"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="txtbx_repay_intrst_rate_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                     </td>
                                     <td>
                                         <asp:RegularExpressionValidator ID="validation_repay_intrst_rate" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_repay_intrst_rate_edit" />
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_repay_date_edit" runat="server" Text="Date"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="txtbx_repay_date_edit" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                     </td>
                                     <td>
                                         <asp:CompareValidator ID="validation_repay_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_repay_date_edit" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                                         <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_repay_remark_edit" runat="server" Text="Remark :"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="txtbx_repay_remark_edit"  CssClass="txtbxDescrip-css" Width="205px" Height="50px"  TextMode="MultiLine" runat="server"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:Button ID="btn_save_repay" CssClass="btn" runat="server" Text="save" />
                                     </td>
                                 </tr>
                             </table>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lbl_validation_view3" runat="server" ForeColor="Red" Text=""></asp:Label>
                                     </td>
                                 </tr>
                             </table>

                         </asp:View>
                     </asp:MultiView>
                 </asp:Panel>
             </ContentTemplate>
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="GridView_select_loan" EventName="SelectedIndexChanged" />
                 <asp:AsyncPostBackTrigger ControlID="GridView_loan_repayment" EventName="SelectedIndexChanged" />

                 <asp:AsyncPostBackTrigger ControlID ="link_lendername" EventName ="Click" />
                 <asp:AsyncPostBackTrigger ControlID="link_lenderDescription" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="link_lendermail" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="link_lendertype" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="link_lenderlocation" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="link_lender_contact" EventName="Click" />

                 <asp:AsyncPostBackTrigger ControlID ="link_loan_name" EventName ="Click" />
                 <asp:AsyncPostBackTrigger ControlID ="link_loantype" EventName ="Click" />
                 <asp:AsyncPostBackTrigger ControlID ="link_loandetail" EventName ="Click" />
                  <asp:AsyncPostBackTrigger ControlID ="link_amount" EventName ="Click" />
                  <asp:AsyncPostBackTrigger ControlID ="link_interest_rate" EventName ="Click" />
                 <asp:AsyncPostBackTrigger ControlID ="link_date_taken" EventName ="Click" />
                 <asp:AsyncPostBackTrigger ControlID ="link_loan_term" EventName ="Click" />
                  <asp:AsyncPostBackTrigger ControlID ="link_guarantor" EventName ="Click" />
                 <asp:AsyncPostBackTrigger ControlID ="link_mortgage" EventName ="Click" />

                  <asp:AsyncPostBackTrigger ControlID ="btn_save_lender_name_edit" EventName ="Click" />

             </Triggers>
         </asp:UpdatePanel>
    </div>
</asp:Content>
