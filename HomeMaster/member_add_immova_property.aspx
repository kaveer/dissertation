<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB" EnableEventValidation = "false"  CodeBehind="member_add_immova_property.aspx.vb" Inherits="HomeMaster.member_add_immova_property" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Add new property"></asp:Label>
                </td>
            </tr>
        </table>
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
                    <asp:DropDownList ID="ddl_select_category"  CssClass="ddlist"  runat="server"></asp:DropDownList>
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
                     <asp:CompareValidator id="validation_purchase_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_purchase_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                    <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="lbl_purchase_method" runat="server" Text="purchase method"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_select_purchase_mathod"  CssClass="ddlist"  runat="server"></asp:DropDownList>
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
                    <asp:TextBox ID="txtbx_notes" CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_no_room" runat="server" Text="No of room"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_no_room" CssClass="txtbxNoSize-css"  runat="server"></asp:TextBox>
                </td>
                 <td>
                    <asp:RegularExpressionValidator ID="validation_no_room" runat="server" ControlToValidate="txtbx_no_room" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_add_room" runat="server" Text="add room"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btn_open_panel_room" CssClass="btn" runat="server" Text="Add room" />
                    <asp:Button ID="btn_open_uploader" CssClass="btn" runat="server" Text="Open uploader" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_all_room" runat="server" Text="rooms"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_all_room" CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine" Enabled="false"  runat="server"></asp:TextBox>
                </td>
            </tr>    
        </table>
        <table>
             <tr>
                <td>
                    <asp:FileUpload ID="FileUpload_prperty_img" accept="image/*" CssClass="btn" AllowMultiple="false" runat="server" Width="315px" />
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="validation_property_img" runat="server" ControlToValidate="FileUpload_prperty_img" ForeColor="Red" ErrorMessage="Only .gif, .jpg, .png, .tiff and .jpeg" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Bb][Mm][Pp])|.*\.([pP][nN][gG])|.*\.([tT][iI][iI][fF])$)"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_upload_property_img" CssClass="btn" runat="server" Text="Upload picture" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation_property_img" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Repeater ID="Repeater_property_img" runat="server">
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgrepter" Width="100px" Height="100px" ImageUrl='<%# Eval("i_picUrl")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_add_property" CssClass="btn" runat="server" Text="Save" />
                </td>
                <td>
                    <asp:Button ID="btn_cancel_save_property" CssClass="btn" runat="server" Text="Cancel" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation" runat="server"  ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel_room" CssClass="childHomeRemoveNote" Visible ="false" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" CssClass="title_all" runat="server" Text="Room detail"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel1" BackColor="White"  runat="server">
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
                        <asp:TextBox ID="txtbx_room_note" CssClass="txtbxDescrip-css" Width="205px" Height="50px"  TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            </asp:Panel>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_add_room" CssClass="btn" runat="server" Text="save" />
                         <asp:Button ID="btn_close_panel_room" CssClass="btn" runat="server" Text="close" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation_room" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel_uploader" CssClass="childHomeRemoveNote" Visible="false" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="title_all" runat="server" Text="Upload room image"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView_select_room" CssClass="grid" AllowPaging="true"  pagesize="5" runat="server"></asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView_select_room" EventName="SelectedIndexChanged" />
                                
                            </Triggers>
                        </asp:UpdatePanel>
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
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_upload_pic" CssClass="btn" runat="server" Text="Upload picture" />
                        <asp:Button ID="btn_close_uploader" CssClass="btn" runat="server" Text="close" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation_uploader" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Repeater ID="Repeater_preview_img" runat="server">
                            <ItemTemplate>
                                <asp:Image runat="server" ID="imgrep" Width="100px" Height="100px" ImageUrl='<%# Eval("room_picUrl")%>' />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
