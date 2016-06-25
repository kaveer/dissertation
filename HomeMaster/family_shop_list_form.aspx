<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master" EnableEventValidation = "false" CodeBehind="family_shop_list_form.aspx.vb" Inherits="HomeMaster.family_shop_list_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Shopping list"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    <asp:Menu ID="Menu1" runat="server" CssClass="menu_control_css" Orientation="Horizontal">
       
        <StaticHoverStyle BackColor="#9fa8a3"  />
        <StaticMenuItemStyle CssClass="menu_control_not_selec"   />
        <StaticSelectedStyle BackColor="#9fa8a3"  />
        <Items>
            <asp:MenuItem Text="Private shopping list" Value="0" Selected="true"></asp:MenuItem>
            <asp:MenuItem Text="Shared list" Value="1"></asp:MenuItem>
            <asp:MenuItem Text="Old list" Value="2"></asp:MenuItem>
            <asp:MenuItem Text="Manage products" Value="3"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View_private_list" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView_private_list" AllowPaging="true" PageSize = "9" CssClass="grid" runat="server"></asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Btn_delete_list" CssClass="btn" runat="server" Text="Delete" />

                            </td>
                            <td>
                                <asp:Button ID="btn_share_list" CssClass="btn" runat="server" Text="Share" />
                            </td>
                            <td>
                                <asp:Button ID="btn_view_by_cat" CssClass="btn" runat="server" Text="View By category" />
                            </td>
                            <td>
                                <asp:Label ID="lbl_search" runat="server" Text="Enter text :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbx_search" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_search_private_list" CssClass="btn" runat="server" Text="Search" />
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="panel_share_to" Visible="false" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_share_to" runat="server" Text="Share to:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_share_to" CssClass="ddlist" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btn_share_to" CssClass="btn" runat="server" Text="Share" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_validation_share_to" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <table>
                        <tr>
                            <td>
                                
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>

                    <br />



                    <asp:Panel ID="panel_list_detail" Visible="false" CssClass="panel_detail_list" runat="server">
                        <asp:LinkButton ID="link_add_new_product" runat="server">Add new product</asp:LinkButton>

                        <asp:Panel ID="panel_add_new_product" Visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Select_product" runat="server" Text="Select product :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_select_product" CssClass="ddlist" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_new_prod" runat="server" Text="Enter product :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_new_prob" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_add_new_pro" CssClass="btn" runat="server" Text="Add product" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_validation_add_new_prd" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_add_unit_price" runat="server" Text="Unit price :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_unit_price" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CompareValidator 
                                            ID="validation_for_unitP" 
                                            runat="server" 
                                            Operator="DataTypeCheck" 
                                            Type="Currency" 
                                            ControlToValidate="txtbx_unit_price" 
                                            ForeColor="Red" 
                                            ErrorMessage="Enter correct amount" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_add_quantity" runat="server" Text="Quantity :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_quantity" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CompareValidator ID="validation_for_quan" runat="server" Operator="DataTypeCheck" Type="Currency" ControlToValidate="txtbx_quantity" ForeColor="Red" ErrorMessage="Enter correct quantity" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_category_select" runat="server" Text="Select Category :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_category_select" CssClass="ddlist" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_new_category" runat="server" Text="Add new Category :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbx_new_category" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_new_category" CssClass="btn" runat="server" Text="Add new category" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_check_category" runat="server" Visible="false" Text="already category list"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_add_new_product" CssClass="btn" runat="server" Text="Add product in list" />
                                    </td>
                                   
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:GridView ID="GridView_list_detail" CssClass="grid" AllowPaging="true" PageSize ="10" runat="server"></asp:GridView>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_delete_product" CssClass="btn" runat="server" Text="Delete Product" />
                                </td>
                                <td>
                                   <asp:Button ID="btn_mark_purchased" CssClass="btn" runat="server" Text="Mark as purchased" />
                               </td>
                                <td>
                                    <asp:Button ID="Btn_check_total" CssClass="btn" runat="server" Text=" Check Total Cost" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cost_msg" runat="server" Visible="false" Text="Your total cost is :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_total_cost" runat="server" Visible="false" Text=""></asp:Label>
                                </td>
                                
                            </tr>

                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_sort" runat="server" Text="Sort by:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_sort_detail_list" CssClass="ddlist" runat="server">
                                        <asp:ListItem>-- select --</asp:ListItem>
                                        <asp:ListItem>Product Name</asp:ListItem>
                                        <asp:ListItem>Category</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btn_sort" CssClass="btn" runat="server" Text="Sort" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_search_detail_list" runat="server" Text="Search :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_search_detail_list" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btn_search_detail_ist" CssClass="btn" runat="server" Text="Search" />
                                </td>
                                 <td>
                                    <asp:Button ID="btn_download_excel" CssClass="btn" runat="server" Text="Download" />
                                </td>
                            </tr>
                        </table>
                        
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_validation_sorting" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    <asp:Label ID="lbl_validation_detail_lst" runat="server" Visible="false" ForeColor="Red" Text="Label"></asp:Label>
                                    <asp:Label ID="lbl_validation_all" runat="server" ForeColor="Red" Text=""></asp:Label>

                                </td>
                            </tr>
                        </table>
                    </asp:Panel>



                    <%--in ajax to make the gridview selectable--%>
                </asp:View>
                <asp:View ID="View_shared_list" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_shared_by" CssClass="subtitle1" runat="server" Text="List receive from"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView_shared_by" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btn_save_shared_by" CssClass="btn" runat="server" Text="Save list" />
                            </td>                        
                            <td>
                                <asp:Label ID="lbl_validation_share_by" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>

                    
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_shared_to" CssClass="subtitle1" runat="server" Text="list sent to"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView_shared_to" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="panel_shared_to_product" Visible ="false" runat="server">
                        <table>
                            <tr>
                                <asp:GridView ID="grid_view_share_to_pro" AllowPaging="true" PageSize="7" CssClass="grid" Width="500px" runat="server"></asp:GridView>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="View_old_list" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView_old_main_list" CssClass="grid" AllowPaging="true" PageSize="15" runat="server"></asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btn_restore" CssClass="btn" runat="server" Text="Restore list" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView_sub_old_list" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_manage_product" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Manage not purchase products"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView_mgt_all_not_pur_prods" CssClass="grid" AllowPaging="true" PageSize="10" runat="server"></asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table>
                         <tr>
                            <td>
                                <asp:Button ID="btn_mark_pur_mgt_all_prd" CssClass="btn" runat="server" Text="Mark as purchase" />
                            </td>
                            <td>
                                <asp:Button ID="btn_delete_pur_mgt_all_prd" CssClass="btn" runat="server" Text="Delete" />
                            </td>
                        </tr>
                    </table>
                    <table>
                       
                        <tr>
                            <td>
                                <asp:TextBox ID="txtbx_update_quantity" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_update_quantity" CssClass="btn" runat="server" Text="update quantity" />
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="validation_update_quantity" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_update_quantity" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtbx_update_price" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_update_price" CssClass="btn" runat="server" Text="price" />
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="validation_update_price" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_update_price" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtbx_search_mgt_all_prd" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_search_mgt_all_prd" CssClass="btn" runat="server" Text="Search" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_validation_view4" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td>
                                 <asp:Label ID="lbl_subtitle3" CssClass="subtitle1" runat="server" Text="Manage purchased products"></asp:Label>
                            </td>
                        </tr>
                    </table>
                     <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView_purchased_product" CssClass="grid" AllowPaging="true" PageSize ="10" runat="server"></asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btn_mark_as_not_purchase" CssClass="btn" runat="server" Text="Mark not purchase" />
                            </td>
                            <td>
                                <asp:Button ID="btn_delete_purchased_prod" CssClass="btn" runat="server" Text="Delete" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        
                        <tr>
                            <td>
                                <asp:TextBox ID="txtbx_update_quantity_purchased_prd" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_update_quantity_purchased_prd" CssClass="btn" runat="server" Text="update quantity" />
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="validation_update_quan_purchased_prd" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_update_quantity_purchased_prd" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtbx_update_price_purchased_prod" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_update_price_purchased_prod" CssClass="btn"  runat="server" Text="update price" />
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="validation_update_price_purchased_prod" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_update_price_purchased_prod" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtbx_search_purchased_prod" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_search_purchased_prod" CssClass="btn" runat="server" Text="Search" />
                            </td>
                        </tr>
                    </table>
                     <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_validation_view4_1" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView_private_list" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="GridView_list_detail" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="GridView_shared_by" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="GridView_shared_to" EventName="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger ControlID="GridView_mgt_all_not_pur_prods" EventName="SelectedIndexChanged" />

            <asp:AsyncPostBackTrigger ControlID="Btn_delete_list" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="link_add_new_product" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_new_category" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_add_new_product" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_add_new_pro" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_mark_purchased" EventName="Click" />
           <asp:AsyncPostBackTrigger ControlID="btn_sort" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="GridView_old_main_list" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btn_restore" EventName="Click" />
            <asp:PostBackTrigger ControlID="btn_download_excel" />
        </Triggers>
    </asp:UpdatePanel>
        </div>
</asp:Content>
