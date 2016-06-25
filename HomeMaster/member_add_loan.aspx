<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB"  CodeBehind="member_add_loan.aspx.vb" Inherits="HomeMaster.member_add_loan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <div >
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_title"  CssClass="title_all" runat="server" Text="Add loan"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

                        <asp:View ID="lender_view" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_lendername"   runat="server" Text="Lender name :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_lendername" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_description"   runat="server" Text="Description :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_description"  CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine"  runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_lender_type"   runat="server" Text="Type :"></asp:Label>
                                    </td>
                                    <td>

                                        <asp:DropDownList ID="ddl_lender_type" CssClass="ddlist" runat="server"></asp:DropDownList>

                                    </td>
                                    <td>
                                        <asp:Button ID="btn_addlendertype_popup" CssClass="btn" runat="server" Text="Add type" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_email"   runat="server" Text="Email : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_email" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                         <asp:RegularExpressionValidator ID="validation_email" ControlToValidate="txtbx_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ForeColor="Red" ErrorMessage="Invalid email address"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_phone_fix"   runat="server" Text="Phone number fix :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_phone_fix" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="validation_phn_fix" runat="server" ControlToValidate="txtbx_phone_fix" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_phone_ptb"   runat="server" Text="Phone number mobile :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_phone_ptb" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="validation_phn_ptb" runat="server" ControlToValidate="txtbx_phone_ptb" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_fax"   runat="server" Text="Fax :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_fax" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                         <asp:RegularExpressionValidator ID="validation_fax" runat="server" ControlToValidate="txtbx_fax" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_website"   runat="server" Text="Website :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_website" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_validation_view1" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="nextinV0_btn" CssClass="btn" runat="server" Text="Next" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="lender_View2" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_lender_street" runat="server"   Text="Street :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_street" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_lender_town" runat="server"   Text="Town :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_town" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="validation_town" runat="server" ControlToValidate="txtbx_town" ValidationExpression="[a-zA-Z ]*$" ForeColor="Red" ErrorMessage="not a valid name try again " />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_lender_country" runat="server"   Text="Country :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_country" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="validation_country" runat="server" ControlToValidate="txtbx_country" ValidationExpression="[a-zA-Z ]*$" ForeColor="Red" ErrorMessage="not a valid name try again " />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_postal_code" runat="server"   Text="Postal Code :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_postal_code" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                         <asp:RegularExpressionValidator ID="validation_postal_code" runat="server" ControlToValidate="txtbx_postal_code" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_validation_view2" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="previousv2_btn" CssClass="btn" runat="server" Text="Previous" />
                                    </td>
                                    <td>
                                        <asp:Button ID="nextv2_btn" CssClass="btn" runat="server" Text="Next" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_loan_name" runat="server"   Text="loan name :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_loan_name" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_loan_type" runat="server"   Text="Loan type :"></asp:Label>
                                    </td>
                                    <td>

                                        <asp:DropDownList ID="ddl_loan_type" CssClass="ddlist" runat="server"></asp:DropDownList>

                                    </td>
                                    <td>
                                        <asp:Button ID="btn_addloan_type_popup" runat="server" CssClass="btn" Text="add type" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_loan_detail" runat="server"   Text="Load detail :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_loan_detail"  CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_amount" runat="server"   Text="Amount :"></asp:Label>
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
                                        <asp:Label ID="lbl_interest_rate" runat="server"   Text="Interest rate(%) :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_interest_rate" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="validation_interest_rate" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_interest_rate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_date_taken" runat="server"   Text="date taken :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_date_taken" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CompareValidator id="validation_date_taken" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_date_taken" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_loan_term" runat="server"   Text="loan term(month) :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_loan_term" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="validation_loan_term" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_loan_term" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_guarantor"   runat="server" Text="Guarantor :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_guarantor" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_mortgage"   runat="server" Text="Mortgage :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_mortgage" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
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
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="previnV1_btn" CssClass="btn" runat="server" Text="Previous" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_save" CssClass="btn" runat="server" Text="Save" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>

                    </asp:MultiView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btn_add_loan_type" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btn_add_lender_type" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="panel_popup" Visible="false" CssClass="childHomeRemoveNote" runat="server">
                <asp:Panel ID="panel_add_lender_type" Visible="false" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Add lender type"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                           
                            <td>
                                <asp:Panel ID="Panel1" BackColor="White" CssClass="centerTxtbx" Height ="50px" Width="255px" runat="server">
                                <asp:TextBox ID="txtbx_add_lender_type" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Button ID="btn_add_lender_type" CssClass="btn" runat="server" Text="Add" />
                            </td>
                            <td>
                                <asp:Button ID="btn_cancel_lender_type" CssClass="btn" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="panel_add_loan_type" Visible="false" runat="server">
                     <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="Add loan type"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel2" BackColor="White" CssClass="centerTxtbx" Height ="50px" Width="255px"  runat="server">
                                <asp:TextBox ID="txtbx_add_loan_type" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </asp:Panel>
                            </td>
                            <td>
                                <asp:Button ID="btn_add_loan_type" CssClass="btn" runat="server" Text="Add" />
                            </td>
                            <td>
                                <asp:Button ID="btn_cancel_loan_type" CssClass="btn" runat="server" Text="cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
             
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btn_addlendertype_popup" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btn_addloan_type_popup" EventName="Click" />
            </Triggers>
       </asp:UpdatePanel>

     </div>
</asp:Content>
