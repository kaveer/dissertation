<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB" CodeBehind="member_add_move_asset.aspx.vb" Inherits="HomeMaster.member_add_move_asset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Add new asset"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_select_location" runat="server" Text="Select location"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_select_location" CssClass="ddlist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_add_location" runat="server" Text="Add new location"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_add_location" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_add_location" CssClass="btn" runat="server" Text="Add" />
                </td>
            </tr>
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
                    <asp:Label ID="lbl_retailer" runat="server" Text="retailer"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_retailer" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
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
                    <asp:Label ID="lbl_quantity" runat="server" Text="Quantity"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_quantity" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="validation_quantity" runat="server" ControlToValidate="txtbx_quantity" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_make" runat="server" Text="make"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_make" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_model" runat="server" Text="Model"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_model" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_serial_num" runat="server" Text="Serial number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_serial_num" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_warranty_period" runat="server" Text="Warranty period(month)"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbx_warranty_period" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:RegularExpressionValidator ID="validation_warranty" runat="server" ControlToValidate="txtbx_warranty_period" ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"> </asp:RegularExpressionValidator>
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
            
        </table>
        <table>
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload_img" accept="image/*" CssClass="btn"  AllowMultiple="false"   runat="server" Width="385px" />
                </td>
                <td>
                     <asp:RegularExpressionValidator ID="validation_uload_img" runat="server" ControlToValidate="FileUpload_img" ForeColor="Red" ErrorMessage="Only .gif, .jpg, .png, .tiff and .jpeg" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Bb][Mm][Pp])|.*\.([pP][nN][gG])|.*\.([tT][iI][iI][fF])$)"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:Button ID="btn_upload_pic" CssClass="btn" runat="server" Text="Upload picture" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Repeater ID="Repeater_preview_img" runat="server">
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgrep" Width="100px" Height="100px" ImageUrl='<%# Eval("picUrl")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_save_move_asset" CssClass="btn" runat="server" Text="Save" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>
