<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB" CodeBehind="member_add_insurance.aspx.vb" Inherits="HomeMaster.member_add_insurance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Lbl_title" CssClass="title_all" runat="server" Text="Add new insurance"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
            <asp:View ID="company_view"  runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle" CssClass="subtitle1"  runat="server" Text="Company details"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_company_name" runat="server" Text="Company name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_company_name" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_company_descrip" runat="server" Text="Description"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_compnay_description" CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_branch_of" runat="server" Text="Is a branch of"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_branch_of" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_company_email" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_company_email" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="validation_email" ControlToValidate="txtbx_company_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ForeColor="Red" ErrorMessage="Invalid email address"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_company_street" runat="server" Text="Street"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_comapny_street" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_company_town" runat="server" Text="Town"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_company_town" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="validation_town" runat="server" ControlToValidate="txtbx_company_town" ValidationExpression="[a-zA-Z ]*$" ForeColor="Red" ErrorMessage="not a valid name try again " />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_company_country" runat="server" Text="Country"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_company_country" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="validation_country" runat="server" ControlToValidate="txtbx_company_country" ValidationExpression="[a-zA-Z ]*$" ForeColor="Red" ErrorMessage="not a valid name try again " />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_compnay_phne_fix" runat="server" Text="Phone number"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_company_phn_fix" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="validation_phn_fix" runat="server" ControlToValidate="txtbx_company_phn_fix" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_company_phne_ptb" runat="server" Text="Mobile number"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_company_phne_ptb" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="validation_phn_ptb" runat="server" ControlToValidate="txtbx_company_phne_ptb" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_fax"  runat="server" Text="Fax :"></asp:Label>
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
                            <asp:Label ID="lbl_company_website" runat="server" Text="Website "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_website" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_next_to_policy" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_view1" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="policiy_view" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle1" CssClass="subtitle1"  runat="server" Text="Insurance Policy"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_insurance_type" runat="server" Text="Select insurance type"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_insurance_type" CssClass="ddlist" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_add_insurance_type" runat="server" Text="Add new type"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_add_insurance_type" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_add_insurance_type" CssClass="btn" runat="server" Text="Add" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_policy_num" runat="server" Text="Policy number"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_policy_number" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_policy_name"  runat="server" Text="Policy name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_policy_name" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_policy_description" runat="server" Text="Description"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtxbx_policy_description" CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_policy_effec_date" runat="server" Text="Effective date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_policy_effec_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <asp:CompareValidator id="validation_effec_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_policy_effec_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_policy_expiry_date" runat="server" Text="Expiry date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_policy_expiry_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <asp:CompareValidator id="validation_expiry_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_policy_expiry_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_to_company" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_next_to_cover" CssClass="btn" runat="server" Text="Next" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_view2" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="cover_view" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_subtitle2" CssClass="subtitle1" runat="server" Text="Cover details"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_cover_type" runat="server" Text="Select cover type"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_cover_type" CssClass="ddlist" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_add_cover_type" runat="server" Text="Add new type"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_add_cover_type" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_add_cover_type" CssClass="btn" runat="server" Text="Add" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_cover_descrip" runat="server" Text="description"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_cover_descri" CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_insured_obj_person" runat="server" Text="insured object/person"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_insured_obj_person" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_beneficiary" runat="server" Text="beneficiary"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_beneficiary" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_amount_beneficiary" runat="server" Text="beneficiary amount"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_amount_beneficiary" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="validation_amount_beneficiary" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_amount_beneficiary" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_cover_fees" runat="server" Text="Cover fees"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_cover_fees" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="validation_cover_fees" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_cover_fees" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_doc_fees" runat="server" Text="Document fees"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_doc_fees" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="validation_doc_fees" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_doc_fees" />
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="lbl_agent_commision" runat="server" Text="Agent commission"></asp:Label>
                        </td>
                         <td>
                             <asp:TextBox ID="txtbx_agent_commission" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                         </td>
                         <td>
                             <asp:RegularExpressionValidator ID="validation_agent_com" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_agent_commission" />
                         </td>
                     </tr>
                </table>
                   <asp:Panel ID="Panel_vehicle_cover" Visible="false" runat="server">
                    <table>
                        <tr>
                        <td>
                            <asp:Label ID="lbl_reg_num" runat="server" Text="registration number"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_reg_num" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="lbl_manufacturer" runat="server" Text="Manufacturer"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_manufacturer" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_serial_num" runat="server" Text="serial number"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbx_serial_num" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                    </table>
                </asp:Panel>
                <table>
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUpload_picture" accept="image/*" CssClass="btn" AllowMultiple="false" runat="server" Width="315px" />
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="validation_upload_pic" runat="server" ControlToValidate="FileUpload_picture" ForeColor="Red" ErrorMessage="Only .gif, .jpg, .png, .tiff and .jpeg" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Bb][Mm][Pp])|.*\.([pP][nN][gG])|.*\.([tT][iI][iI][fF])$)"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Repeater ID="Repeater_diaplay_pic" runat="server">
                                <ItemTemplate>
                                    <asp:Image runat="server" ID="imgrep" Width="300px" Height="300px" ImageUrl='<%# Eval("picUrl")%>' />
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_prev_policy" CssClass="btn" runat="server" Text="Previous" />
                        </td>
                        <td>
                            <asp:Button ID="btn_save_insurance" CssClass="btn" runat="server" Text="Save" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_view3" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                
            </asp:View>
        </asp:MultiView>
        
    </div>
</asp:Content>
