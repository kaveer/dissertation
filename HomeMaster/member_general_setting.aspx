<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master"  Culture = "en-GB" CodeBehind="member_general_setting.aspx.vb" Inherits="HomeMaster.member_general_setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="User general setting"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="subdiv">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_name" runat="server" Text="name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_name" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_surname" runat="server" Text="Surname"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_surname" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_gender" runat="server" Text="Select gender"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_dob" CssClass="ddlist" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_dob" runat="server" Text="Date of birth"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_dob" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                     <td>
                         <asp:CompareValidator ID="validation_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_dob" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                         <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                     </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_update" CssClass="btn" runat="server" Text="Update" />
                    </td>
                     <td>
                        <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
