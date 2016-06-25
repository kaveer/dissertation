<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="member_edit_immove_property.aspx.vb" Inherits="HomeMaster.member_edit_immove_property" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
     .hidden
     {
         display:none;
     }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="maindivChildHome">
         <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Edit property"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_active_immov" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_active_immov" EventName="SelectedIndexChanged" />
                <%--<asp:AsyncPostBackTrigger ControlID="GridView_room_detail" EventName="SelectedIndexChanged" />--%>
            </Triggers>
        </asp:UpdatePanel>
                <asp:Menu ID="Menu1" runat="server" CssClass="menu_control_css" Orientation="Horizontal">
                    <StaticHoverStyle BackColor="#9fa8a3" />
                    <StaticMenuItemStyle CssClass="menu_control_not_selec" />
                    <StaticSelectedStyle BackColor="#9fa8a3" />
                    <Items>
                        <asp:MenuItem Text=" Edit property detail" Value="0" Selected="true"></asp:MenuItem>
                        <asp:MenuItem Text="Edit property gallery" Value="1"></asp:MenuItem>
                        <asp:MenuItem Text="Edit Room detail" Value="2"></asp:MenuItem>
                    </Items>
                </asp:Menu>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="property_detail" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:DetailsView ID="DetailsView_property_detail" CssClass="grid" runat="server" Height="50px" Width="200px"></asp:DetailsView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView_active_immov" EventName="SelectedIndexChanged" />
                                <%--<asp:AsyncPostBackTrigger ControlID="GridView_room_detail" EventName="SelectedIndexChanged" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_item_name" runat="server" Text="Item name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_item_name" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_select_category" runat="server" Text="Select category"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_select_category" CssClass="ddlist" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_add_category" runat="server" Text="Add new category"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_add_category" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btn_add_category" CssClass="btn" runat="server" Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_location" runat="server" Text=" location"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_location" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_current_value" runat="server" Text="current value"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_current_value" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="validation_current_value" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_current_value" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_purchase_cost" runat="server" Text="Purchase cost"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_purchase_cost" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="validation_purchase_cost" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_purchase_cost" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_purchse_date" runat="server" Text="Purchase date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_purchase_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="validation_purchase_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_purchase_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_purchase_method" runat="server" Text="purchase method"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_select_purchase_mathod" CssClass="ddlist" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_add_purchase_method" runat="server" Text="Add purchase method"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_add_purchase_method" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btn_add_purchase_method" CssClass="btn" runat="server" Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_length" runat="server" Text="length"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_length" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="validation_length" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_length" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_width" runat="server" Text="width"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_width" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="validation_width" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_width" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_notes" runat="server" Text="notes"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_notes" CssClass="txtbxDescrip-css" Width="205px" Height="50px"  TextMode="MultiLine" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_no_room" runat="server" Text="No of room"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_no_room" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="validation_no_room" runat="server" ControlToValidate="txtbx_no_room" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_update_property" CssClass="btn" runat="server" Text="Update" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_validation_view1" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="property_gallery" runat="server">
                        <asp:Panel ID="Panel_open_gallery" ScrollBars="Vertical" Height="700px" Width="760px"  runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="title_all" Text="Property gallery"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:FileUpload ID="FileUpload_img" accept="image/*" CssClass="btn" AllowMultiple="false" runat="server" Width="315px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="validation_uload_img" runat="server" ControlToValidate="FileUpload_img" ForeColor="Red" ErrorMessage="Only .gif, .jpg, .png, .tiff and .jpeg" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Bb][Mm][Pp])|.*\.([pP][nN][gG])|.*\.([tT][iI][iI][fF])$)"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_upload_pic" CssClass="btn" runat="server" Text="Upload picture" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_delete_photo" CssClass="btn" runat="server" Text="delete" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_validation_photo_gallery" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_open_gallery" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkCtrl" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Title" ControlStyle-CssClass="hidden" DataField="i_photo_id">
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image runat="server" ID="imgrep" Width="700px" Height="700px" ImageUrl='<%# Eval("i_picUrl")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridView_active_immov" EventName="SelectedIndexChanged" />
                                    <%--<asp:AsyncPostBackTrigger ControlID="GridView_room_detail" EventName="SelectedIndexChanged" />--%>
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                    </asp:View>
                    <asp:View ID="room_detail" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView_room_detail"  CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView_active_immov" EventName="SelectedIndexChanged" />
                                <%--<asp:AsyncPostBackTrigger ControlID="GridView_room_detail" EventName="SelectedIndexChanged" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_room_name" runat="server" Text="name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_room_name" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_room_length" runat="server" Text="length"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_room_length" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="validation_room_length" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_room_length" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_room_width" runat="server" Text="width"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_room_width" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="validation_room_width" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ControlToValidate="txtbx_room_width" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_room_note" runat="server" Text="note"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbx_room_note" CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_update_room_detail" CssClass="btn" runat="server" Text="update" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_validation_room" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel_room_photo" ScrollBars="Vertical" Height="700px" Width="760px" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:FileUpload ID="FileUpload_room_photo" accept="image/*" CssClass="btn"  AllowMultiple="false" runat="server" Width="315px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="validation_room_photo" runat="server" ControlToValidate="FileUpload_room_photo" ForeColor="Red" ErrorMessage="Only .gif, .jpg, .png, .tiff and .jpeg" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Bb][Mm][Pp])|.*\.([pP][nN][gG])|.*\.([tT][iI][iI][fF])$)"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_upload_room_img" CssClass="btn" runat="server" Text="Upload picture" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_delete_room_img" CssClass="btn" runat="server" Text="delete" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_validation_room_img" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView_room_photo" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkCtrl" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Title" ControlStyle-CssClass="hidden" DataField="room_pic_id">
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image runat="server" ID="imgrep" Width="700px" Height="700px" ImageUrl='<%# Eval("room_picUrl")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridView_room_detail" EventName="SelectedIndexChanged" />
                                    <%--<asp:AsyncPostBackTrigger ControlID="GridView_room_detail" EventName="SelectedIndexChanged" />--%>
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:Label ID="Label3" runat="server" ForeColor ="Red" Text=""></asp:Label>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            
    </div>
</asp:Content>
