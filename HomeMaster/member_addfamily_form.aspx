<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB" CodeBehind="member_addfamily_form.aspx.vb" Inherits="HomeMaster.member_addfamily_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="maindivChildHome">
           <table>
               <tr>
                   <td>
                       <asp:Label ID="Label2" CssClass="title_all" runat="server" Text="Add new family member"></asp:Label>
                   </td>
               </tr>
           </table>
           <table>
               <tr>
                   <td>
                        <asp:Label ID="username_lbl" runat="server" Text="Username" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                               <asp:TextBox ID="username_txtbx"  runat="server" CssClass="txtbxNoSize-css"></asp:TextBox>
                               <br />
                               <asp:Panel ID="suggestion_pnl" CssClass="popup_check_username" Visible="false"  runat="server">
                                   <asp:Label ID="check_user_lbl" runat="server" Text="" CssClass="popup_check_username_detail"></asp:Label>
                                   <br />
                                   <br />
                                   <asp:Label ID="suggest_username_lbl" runat="server" Text=""></asp:Label>
                               </asp:Panel>
                           </ContentTemplate>
                           <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="checkuser_btn"  EventName="Click" />
                           </Triggers>
                       </asp:UpdatePanel>
                   </td>
                   <td>
                       <asp:Button ID="checkuser_btn" runat="server" Text="check" CssClass="btn" />
                       <asp:RequiredFieldValidator ID="req_username_val" ControlToValidate="username_txtbx" runat="server" ForeColor="Red" ErrorMessage="Enter username" CssClass="valmsg"></asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr >
                   <td>
                        <asp:Label ID="email_lbl" runat="server" Text="Email" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                        <asp:TextBox ID="email_txtbx" runat="server"  CssClass="txtbxNoSize-css"></asp:TextBox>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="email_txtbx" CssClass="valmsg" ID="req_mail_val" runat="server" ErrorMessage="Enter mail"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator 
                           ID="requ_exp_email" 
                           ControlToValidate="email_txtbx" 
                           ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                           runat="server" ForeColor="Red" 
                           ErrorMessage="Invalid email address">
                       </asp:RegularExpressionValidator>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="password_lbl" runat="server" Text="Password" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="password_txtbx" runat="server" TextMode="Password" CssClass="txtbxNoSize-css"></asp:TextBox>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator 
                           ID="req_password_val" 
                           ControlToValidate="password_txtbx" 
                           CssClass="valmsg" ForeColor="Red" 
                           runat="server" 
                           ErrorMessage="Enter a password">
                       </asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="lbl_comfirm_pwd" runat="server" Text="Confirm password :" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtbx_confirm_pwd" runat="server" TextMode="Password" CssClass="txtbxNoSize-css"></asp:TextBox>
                   </td>
                   <td>
                       <asp:CompareValidator 
                           runat="server" 
                           id="cmpPwd" 
                           controltovalidate="password_txtbx" 
                           controltocompare="txtbx_confirm_pwd" 
                           operator="Equal" type="String" 
                           ForeColor="Red" 
                           errormessage="Password not match try again." />
                   </td>
               </tr>
               <tr>
                   <td>
                        <asp:Label ID="relationship_lbl" runat="server" Text="Relationship" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                       <asp:DropDownList ID="relationship_ddl" CssClass="ddlist" runat="server">
                           <asp:ListItem Selected="True">Children</asp:ListItem>
                           <asp:ListItem>Wife</asp:ListItem>
                           <asp:ListItem>Husband</asp:ListItem>
                           <asp:ListItem>Mother</asp:ListItem>
                           <asp:ListItem>Father</asp:ListItem>
                           <asp:ListItem>Sister</asp:ListItem>
                           <asp:ListItem>Brother</asp:ListItem>
                           <asp:ListItem>Aunt</asp:ListItem>
                           <asp:ListItem>Uncle</asp:ListItem>
                           <asp:ListItem>Niece</asp:ListItem>
                           <asp:ListItem>Nephew</asp:ListItem>
                           <asp:ListItem>Cousin(male)</asp:ListItem>
                           <asp:ListItem>Cousin(female)</asp:ListItem>
                           <asp:ListItem>Grandmother</asp:ListItem>
                           <asp:ListItem>Grandfather</asp:ListItem>
                           <asp:ListItem>Granddaughter</asp:ListItem>
                           <asp:ListItem>Grandson</asp:ListItem>
                           <asp:ListItem>Stepmother</asp:ListItem>
                           <asp:ListItem>Stepfather</asp:ListItem>
                           <asp:ListItem>Stepson</asp:ListItem>
                           <asp:ListItem>Stepdaughter</asp:ListItem>
                           <asp:ListItem>Stepbrother</asp:ListItem>
                           <asp:ListItem>Stepsister</asp:ListItem>
                           <asp:ListItem>brother-in-law</asp:ListItem>
                           <asp:ListItem>sister-in-law</asp:ListItem>
                           <asp:ListItem>mother-in-law</asp:ListItem>
                           <asp:ListItem>father-in-law</asp:ListItem>
                           <asp:ListItem>daughter-in-law</asp:ListItem>
                           <asp:ListItem>son-in-law</asp:ListItem>
                           <asp:ListItem>pet</asp:ListItem>
                           <asp:ListItem>Other</asp:ListItem>
                       </asp:DropDownList>
                   </td>
                   <td>
                      
                   </td>
               </tr>
               <tr>
                   <td>
                        <asp:Label ID="name_lbl" runat="server" Text="Name" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="name_txtbx" runat="server" CssClass="txtbxNoSize-css"></asp:TextBox>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator ForeColor="Red" ID="req_name_val" ControlToValidate="name_txtbx" CssClass="valmsg" runat="server" ErrorMessage="Enter name"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator 
                           ID="RegularExpressionValidator_name" 
                           runat="server" 
                           ControlToValidate="name_txtbx" 
                           ValidationExpression="[a-zA-Z ]*$"
                            ForeColor="Red" ErrorMessage="not a valid name try again " />
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="surname_lbl" runat="server" Text="Surname" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                        <asp:TextBox ID="surname_txtbx" runat="server" CssClass="txtbxNoSize-css"></asp:TextBox>
                   </td>
                   <td>
                       <asp:RegularExpressionValidator  ID="RegularExpressionValidator_surname" runat="server" ControlToValidate="surname_txtbx" ValidationExpression="[a-zA-Z ]*$" ForeColor="Red" ErrorMessage="not a valid name try again " />
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="gender_lbl" runat="server" Text="Select gender" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                       <asp:DropDownList ID="gender_ddl" CssClass="ddlist" runat="server">
                           <asp:ListItem Selected="True">Male</asp:ListItem>
                           <asp:ListItem>Female</asp:ListItem>
                       </asp:DropDownList>
                   </td>
                   <td>
                       
                   </td>
               </tr>
               <tr>
                   <td>
                        <asp:Label ID="dob_lbl" runat="server" Text="Date of birth" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="dob_txtbx" runat="server" CssClass="txtbxNoSize-css"></asp:TextBox>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator ForeColor="Red" ID="req_dob_val" ControlToValidate="dob_txtbx" CssClass="valmsg" runat="server" ErrorMessage="Enter date of birth"></asp:RequiredFieldValidator>
                       <asp:CompareValidator id="validation_for_dob" 
                           runat="server" 
                           Type="Date" 
                           Operator="DataTypeCheck" 
                           ControlToValidate="dob_txtbx" 
                           ForeColor="Red" 
                           ErrorMessage="Enter a valid date like DD/MM/YYYY.">
                       </asp:CompareValidator>




                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="mobilenum_lbl" runat="server" Text="Mobile number" CssClass="fontchange"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="mobilenum_txtbx" runat="server" CssClass="txtbxNoSize-css"></asp:TextBox>
                   </td>
                   <td>
                    <asp:RegularExpressionValidator 
                        ID="RegularExpressionValidator_phoneNum" 
                        runat="server" 
                        ControlToValidate="mobilenum_txtbx" 
                        ErrorMessage="Only numeric allowed." 
                        ForeColor="Red" ValidationExpression="^[0-9]*$"> 
                    </asp:RegularExpressionValidator>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Button ID="register_btn" runat="server" Text="Register"   CssClass="btn"/>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="lbl_check" runat="server" ForeColor="Red" Text=""></asp:Label>
                   </td>
                   
               </tr>
           </table>
    </div>
</asp:Content>
