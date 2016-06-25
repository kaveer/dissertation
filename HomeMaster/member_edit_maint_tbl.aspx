<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="member_edit_maint_tbl.aspx.vb" Inherits="HomeMaster.member_edit_maint_tbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div  class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Update maintenance"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
             <tr>
                <td>
                    <asp:Label ID="lbl_select_obj" runat="server" Text="Select "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_select_obj" CssClass="ddlist" runat="server" AutoPostBack="True">
                        <asp:ListItem >--select type--</asp:ListItem>
                        <asp:ListItem>immovable property</asp:ListItem>
                        <asp:ListItem>movable asset</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>

                </td>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView_select_propty_asset" CssClass="grid" AllowPaging="true" PageSize="1" runat="server"></asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView_select_propty_asset"  EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            </table>
         <table>
             <tr>
                 <td>
                     <asp:Label ID="lbl_maint_desc" runat="server" Text="Description"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtbx_maint_desc" CssClass="txtbxDescrip-css" Width="205px" Height="50px"   TextMode="MultiLine" runat="server"></asp:TextBox>
                 </td>
             </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_maint_type" runat="server" Text="maintenace type"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_maint_type" CssClass="ddlist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_add_maint_type" runat="server" Text="Add type"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_add_maint_type" CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_add_maint_type" CssClass="btn" runat="server" Text="Add" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_start_date" runat="server" Text="Start date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_start_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                 <td>
                     <asp:CompareValidator id="validation_start_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_start_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_completed_date" runat="server" Text="completed date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_completed_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                 <td>
                     <asp:CompareValidator id="validation_completed_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_completed_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_maint_cost" runat="server" Text="maintenance cost"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_maint_cost" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                 <td>
                    <asp:RegularExpressionValidator ID="validation_maint_cost" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_maint_cost" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_maint_worker" runat="server" Text="contactor/worker"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_maint_worker" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_material_used" runat="server" Text="material used"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_material_used" CssClass="txtbxDescrip-css" Width="205px" Height="50px"  TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_update_maint" CssClass="btn" runat="server" Text="update maintenance" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation" runat="server" ForeColor ="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
