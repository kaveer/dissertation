<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB"  EnableEventValidation = "false" CodeBehind="member_family_album_folder.aspx.vb" Inherits="HomeMaster.member_family_album_folder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="title_all" runat="server" Text="Family album"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="subtitle1" runat="server" Text="Select folder"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView_select_folder" AutoGenerateColumns="false" CssClass="grid" AllowPaging="true" PageSize="10" runat="server">
                        <Columns>
                            <asp:BoundField HeaderText="ref no" DataField="album_id"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image runat="server" ID="imgrep" Width="50px" Height="50px" ImageUrl='<%# Eval("album_pic")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField HeaderText="Album name" DataField="album_name"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtbx_new_folder" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_new_folder" CssClass="btn" runat="server" Text="New folder" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtbx_edit_folder" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_edit_folder" CssClass="btn" runat="server" Text="Rename folder" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_delete_folder" CssClass="btn" runat="server" Text="Delete folder" />
                    <asp:Button ID="btn_open_folder" CssClass="btn" runat="server" Text="Open folder" />
                </td>
               
            </tr>
        </table>       
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_validation" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
      
    </div>
</asp:Content>
