<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/guest.Master" CodeBehind="guest_register_form.aspx.vb" Inherits="HomeMaster.guest_register_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div  class="maindivChildHome">
         <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Admin registration"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="subdiv" >
            <table>
                <tr>
                    <td>
                        <asp:Label ID="username_lbl" runat="server" Text="Username :" CssClass="fontchange"></asp:Label>
                    </td>
                    <td >
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="username_txtbx" runat="server"  CssClass="txtbxNoSize-css"></asp:TextBox>
                                <asp:Panel ID="suggestion_pnl" CssClass="popup_check_username" Visible="false" runat="server">
                                    <asp:Label ID="check_user_lbl" runat="server" Text="" CssClass="popup_check_username_detail"></asp:Label>
                                    <br />
                                    <asp:Label ID="suggest_username_lbl" runat="server" Text=""></asp:Label>
                                </asp:Panel>
                                <asp:CustomValidator ID="check_user_val" ControlToValidate="username_txtbx" Enabled="true" SetFocusOnError="true" OnServerValidate="check_user_val_ServerValidate" ValidateEmptyText="true" runat="server" CssClass="valmsg"></asp:CustomValidator>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="checkuser_btn" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                         <asp:Button ID="checkuser_btn" runat="server" Text="check" CssClass="btn" />
                        <asp:RequiredFieldValidator ID="req_username_val" ControlToValidate="username_txtbx" runat="server" ForeColor="Red" ErrorMessage="Enter username" CssClass="valmsg"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="email_lbl" runat="server" Text="Email :" CssClass="fontchange"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="email_txtbx" runat="server"  CssClass="txtbxNoSize-css"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="req_email_val" ControlToValidate="email_txtbx" runat="server" ForeColor="Red" ErrorMessage="Enter your email address" CssClass="valmsg"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regEx_email_val" ControlToValidate="email_txtbx" runat="server" ForeColor="Red" ErrorMessage="Incorrect email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="valmsg"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="password_lbl" runat="server" Text="Password :" CssClass="fontchange"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="password_txtbx" runat="server" TextMode="Password"  CssClass="txtbxNoSize-css"></asp:TextBox>
                    </td>
                    <td>
                         <asp:RequiredFieldValidator ID="req_password_val" ControlToValidate="password_txtbx" runat="server" ForeColor="Red" ErrorMessage="Enter a password" CssClass="valmsg"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="confirm_password_lbl" runat="server" Text="Confirm password :" CssClass="fontchange"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="confirm_password_txtbx" runat="server" TextMode="Password"  CssClass="txtbxNoSize-css"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="confirm_req_pass_val" runat="server" ControlToValidate="confirm_password_txtbx" ForeColor="Red" ErrorMessage="Re-enter your password" CssClass="valmsg"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="comp_password_val" ControlToValidate="confirm_password_txtbx" ControlToCompare="password_txtbx" ForeColor="Red" runat="server" ErrorMessage="Password not matched" CssClass="valmsg"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="question_lbl" runat="server" Text="Select a question" CssClass="fontchange"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="question_ddl" CssClass="ddlist" runat="server">
                            <asp:ListItem Selected="True">What was the name of your elementary / primary school</asp:ListItem>
                            <asp:ListItem>In what city or town does your nearest sibling live</asp:ListItem>
                            <asp:ListItem>What is your pet’s name</asp:ListItem>
                            <asp:ListItem>What is your favorite music</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                  
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="answer_lbl" runat="server" Text="Answer" CssClass="fontchange"></asp:Label>
                    </td>
                    <td>
                         <asp:TextBox ID="answer_txtbx" runat="server"  CssClass="txtbxNoSize-css"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="Req_answer_val" ControlToValidate="answer_txtbx" CssClass="valmsg" ForeColor="Red" runat="server" ErrorMessage="Write your answer"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                </table>
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="term_condition_ckbx" runat="server" Text="I confirm that i have read and understood the" />
                        <asp:HyperLink ID="termNcond_hlink" NavigateUrl="~/guest_termNcondi_form.aspx" runat="server">term and condition</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="register_btn" runat="server" Text="Register" CssClass="btn" />
                        <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            
          
            
            

            <div>   
                
                
               
                
            
            </div>
        </div>
    </div>
</asp:Content>
