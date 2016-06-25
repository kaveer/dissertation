<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master" CodeBehind="family_online_activation.aspx.vb" Inherits="HomeMaster.family_online_activation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
         <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Activation"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
             <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                 <asp:View ID="view_check_secret_code" runat="server">
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Activation code"></asp:Label>
                             </td>
                         </tr>
                     </table>
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_activation_code" runat="server" Text="Enter activation code "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="txtbx_activation_code"  CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                             </td>
                             <td>
                                 <asp:Button ID="btn_activation_code" CssClass="btn" runat="server" Text="Activate" />
                             </td>
                            
                         </tr>
                     </table>
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_subtitle1" CssClass="subtitle1" runat="server" Text="Resent activation code"></asp:Label>
                             </td>
                         </tr>
                     </table>
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_resent_code" runat="server" Text="Enter mail"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="txtbx_resent_code"  CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                             </td>                                                
                         </tr>
                     </table>
                     <table>
                          <tr>
                             <td>
                                 <asp:Button ID="btn_resent_code" CssClass="btn" runat="server" Text="Sent" />
                             </td>
                             <td>
                                 <asp:Button ID="btn_offline_activation" CssClass="btn" runat="server" Text="Offline activation" />
                             </td>
                         </tr>           
                     </table>
                     <table>
                         <tr>
                              <td>
                                 <asp:Label ID="lbl_validation_view1" runat="server" ForeColor="Red" Text=""></asp:Label>
                             </td>
                             <td>
                                <asp:RegularExpressionValidator ID="validation_mail" ControlToValidate="txtbx_resent_code" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ForeColor="Red" ErrorMessage="Invalid email address"></asp:RegularExpressionValidator>
                             </td>     
                         </tr>
                     </table>
                 </asp:View>
                 <asp:View ID="view_offline_activation" runat="server">
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_subtitle2" CssClass="subtitle1" runat="server" Text="Offline activation"></asp:Label>
                             </td>
                         </tr>
                     </table>
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_offline_username" runat="server" Text="Enter username"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="txtbx_offline_username"  CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                             </td>                                                
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_offline_email" runat="server" Text="Enter mail"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="txtbx_offline_email"  CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                             </td>  
                             <td>
                                 <asp:RegularExpressionValidator ID="validation_offline_mail" ControlToValidate="txtbx_offline_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ForeColor="Red" ErrorMessage="Invalid email address"></asp:RegularExpressionValidator>
                             </td>                                              
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_offline_password" runat="server" Text="Enter password"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="txtbx_offline_password"  CssClass="txtbxNoSize-css"  TextMode="Password" runat="server"></asp:TextBox>
                             </td>                                                
                         </tr>
                         <tr>
                             <td>
                                 <asp:Button ID="btn_view_offfline_activation" CssClass="btn" runat="server" Text="Activate" />
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
                 </asp:View>
                 <asp:View ID="view_change_password" runat="server">
                      <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_subtitle4" CssClass="subtitle1" runat="server" Text="Change your password"></asp:Label>
                             </td>
                         </tr>
                     </table>
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_new_passwrod" runat="server" Text="Enter new password"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="txtbx_new_password"  CssClass="txtbxNoSize-css"  TextMode="Password" runat="server"></asp:TextBox>
                             </td>                                                
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_confrm_password" runat="server" Text="Confirm password"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="txtbx_confirm_passwrd"  CssClass="txtbxNoSize-css"  TextMode="Password" runat="server"></asp:TextBox>
                             </td>
                             <td>
                                 <asp:CompareValidator runat="server" ID="validation_compare_passwrod" ControlToValidate="txtbx_confirm_passwrd" ControlToCompare="txtbx_new_password" Operator="Equal" Type="String" ForeColor="Red" ErrorMessage="Password not match try again." />
                             </td>
                         </tr>
                     </table>
                     <table>
                         <tr>
                             <td>
                                 <asp:Button ID="btn_change_password" CssClass="btn" runat="server" Text="Change password" />
                             </td>
                             <td>
                                 <asp:Label ID="lbl_validation_view3" runat="server" ForeColor="Red" Text=""></asp:Label>
                             </td>
                         </tr>
                     </table>
                 </asp:View>
                 <asp:View ID="View_answer_question" runat="server">
                      <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_subtitle5" CssClass="subtitle1" runat="server" Text="Answer question"></asp:Label>
                             </td>
                         </tr>
                     </table>
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_question" runat="server" Text="Select question"></asp:Label>
                             </td>
                             <td>
                                 <asp:DropDownList ID="ddl_question" CssClass="ddlist" runat="server">
                                     <asp:ListItem Selected="True">What was the name of your elementary / primary school</asp:ListItem>
                                     <asp:ListItem>In what city or town does your nearest sibling live</asp:ListItem>
                                     <asp:ListItem>What is your pet’s name</asp:ListItem>
                                     <asp:ListItem>What is your favorite music</asp:ListItem>
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="lbl_answer" runat="server" Text="Your answer"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="txtbx_answer"  CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                             </td>
                         </tr>
                     </table>
                     <table>
                         <tr>
                             <td>
                                 <asp:Button ID="btn_activate_acct" CssClass="btn" runat="server" Text="Activate account" />
                             </td>
                             <td>
                                 <asp:Label ID="lbl_validation_view4" runat="server" ForeColor="Red" Text=""></asp:Label>
                             </td>
                         </tr>
                     </table>
                 </asp:View>
             </asp:MultiView>

            
        </div>
    </div>
</asp:Content>
