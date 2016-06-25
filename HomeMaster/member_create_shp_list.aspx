<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB" CodeBehind="member_create_shp_list.aspx.vb" Inherits="HomeMaster.member_create_shp_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Create New Shopping List"></asp:Label>
                </td>
            </tr>
        </table>
        
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_list_name" runat="server" Text="list Name:"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtbx_listName" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_estimated_budget" runat="server" Text="Enter budget :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_estimated_butget" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="validation_for_budget" runat="server" Operator="DataTypeCheck" Type="Currency" ControlToValidate="txtbx_estimated_butget" ForeColor="Red" ErrorMessage="Enter correct amount" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_date_created" runat="server" Text="Date Created :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_date_created" CssClass="txtbxNoSize-css" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_finish_date" runat="server" Text="Finish date :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_finish_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator id="validation_for_finishDate" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_finish_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_save" CssClass="btn" runat="server" Text="Save" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation_for_all" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
