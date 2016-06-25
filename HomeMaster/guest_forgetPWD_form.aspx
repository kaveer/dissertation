<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/guest.Master" CodeBehind="guest_forgetPWD_form.aspx.vb" Inherits="HomeMaster.guest_forgetPWD_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div   class="maindivChildHome">
       <table>
           <tr>
               <td>
                   <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Recovery"></asp:Label>
               </td>
           </tr>
       </table>
       <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
           <asp:View ID="View_select_method" runat="server">
               <table>
                   <tr>
                       <td>
                           <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Select method"></asp:Label>
                       </td>
                   </tr>
               </table>
               <table>
                   <tr>
                       <td>
                           <asp:Label ID="lbl_select_type" runat="server" Text="Select"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="ddl_select_type" CssClass="ddlist" runat="server">
                               <asp:ListItem>Password recovery</asp:ListItem>
                               <asp:ListItem>Username recovery</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lbl_select_method" runat="server" Text="Select method"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="ddl_select_method" CssClass="ddlist" runat="server">
                               <asp:ListItem>Online recovery</asp:ListItem>
                               <asp:ListItem>Offline recovery</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                   </tr>
               </table>
               <table>
                   <tr>
                       <td>
                           <asp:Label ID="lbl_subtitle1" CssClass="subtitle1" runat="server" Text="Enter data"></asp:Label>
                       </td>
                   </tr>
               </table>
               <table>
                   <tr>
                       <td>
                           <asp:Label ID="lbl_enter_mail" runat="server" Text="Enter mail"></asp:Label>
                       </td>
                       <td>
                           <asp:TextBox ID="txtbx_enter_mail"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                       </td>
                       <td>
                           <asp:RegularExpressionValidator ID="validation_mail" ControlToValidate="txtbx_enter_mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ForeColor="Red" ErrorMessage="Invalid email address"></asp:RegularExpressionValidator>
                       </td>
                   </tr>
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
                           <asp:TextBox ID="txtbx_answer"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                       </td>
                   </tr>
               </table>
               <table>
                   <tr>
                       <td>
                           <asp:Label ID="lbl_offline_username_msg" CssClass="subtitle1" Visible="false" ForeColor="Red" runat="server" Text="Your username is :"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="lbl_offline_username" CssClass="subtitle1" Visible ="false" ForeColor ="Red" runat="server" Text=""></asp:Label>
                       </td>
                   </tr>
               </table>
               <table>
                   <tr>
                       <td>
                           <asp:Button ID="btn_next_view_select_method" CssClass="btn" runat="server" Text="Recover" />
                       </td>
                       <td>
                           <asp:Label ID="lbl_validation_view1" runat="server" ForeColor="Red" Text=""></asp:Label>
                       </td>
                   </tr>
               </table>
           </asp:View>
           <asp:View ID="View_change_password" runat="server">
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
                           <asp:TextBox ID="txtbx_new_password"  CssClass="txtbxNoSize-css" TextMode="Password" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lbl_confrm_password" runat="server" Text="Confirm password"></asp:Label>
                       </td>
                       <td>
                           <asp:TextBox ID="txtbx_confirm_passwrd"   CssClass="txtbxNoSize-css" TextMode="Password" runat="server"></asp:TextBox>
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
                           <asp:Label ID="lbl_validation_view2" runat="server" ForeColor="Red" Text=""></asp:Label>
                       </td>
                   </tr>
               </table>
           </asp:View>
           <asp:View ID="View_online_activation_code" runat="server">
               <table>
                   <tr>
                       <td>
                           <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="Activation code"></asp:Label>
                       </td>
                   </tr>
               </table>
               <table>
                   <tr>
                       <td>
                           <asp:Label ID="lbl_activation_code" runat="server" Text="Enter activation code "></asp:Label>
                       </td>
                       <td>
                           <asp:TextBox ID="txtbx_activation_code"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                       </td>
                       <td>
                           <asp:Button ID="btn_activation_code" CssClass="btn" runat="server" Text="recover" />
                       </td>
                       <td>
                           <asp:Button ID="btn_resent_code" CssClass="btn" runat="server" Text="Resent" />
                       </td>
                       <td>
                           <asp:Label ID="lbl_validation_view33" runat="server" ForeColor="Red" Text=""></asp:Label>
                       </td>
                   </tr>
               </table>
           </asp:View>
       </asp:MultiView>
   </div>
</asp:Content>
