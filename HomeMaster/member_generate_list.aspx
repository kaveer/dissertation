<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation = "false"   Culture = "en-GB" MasterPageFile="~/member.Master" CodeBehind="member_generate_list.aspx.vb" Inherits="HomeMaster.member_generate_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Lbl_form_name" CssClass="title_all" runat="server" Text="Generate shopping list"></asp:Label>
                </td>
            </tr>
        </table>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GridView_generate" CssClass="grid"  runat="server">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkCtrl" runat="server" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_save" CssClass="btn" runat="server" Text="Save as" />
                    </td>
                    <td>
                        <asp:Button ID="btn_merge_list" CssClass="btn" runat="server" Text="Merge with list" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel_save_list"  Visible="false" runat="server">
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
                            <asp:TextBox ID="txtbx_finish_date1" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CompareValidator ID="validation_for_finishDate1" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_finish_date1" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                            <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_save_list" CssClass="btn" runat="server" Text="Save list" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
    <asp:Panel ID="panel_merge_list"  Visible="false" runat="server">   
                <table>
                    <tr>
                        <td>
                            
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_merge_list" CssClass="grid" AllowPaging="true" PageSize="10"  runat="server"></asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridView_merge_list" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_merge_prod" CssClass="btn" runat="server" Text="Add to list" />
                        </td>
                    </tr>
                </table>
            
    </asp:Panel>
            <asp:Label ID="lbl_validate_check" runat="server" ForeColor="Red" Text=""></asp:Label>
        </div>
</asp:Content>
