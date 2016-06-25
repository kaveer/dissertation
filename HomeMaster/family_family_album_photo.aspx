<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master" CodeBehind="family_family_album_photo.aspx.vb" Inherits="HomeMaster.family_family_album_photo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
     .hidden
     {
         display:none;
     }
</style>
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
                    <asp:Label ID="lbl_folder_name" CssClass="subtitle1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Panel ID="Panel_view_img"  Height="500px" Width="930px" ScrollBars="vertical" runat="server">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <asp:Image runat="server" ID="imgrep" Width="300px" Height="300px" ImageUrl='<%# Eval("pic_url")%>' />
                            </ItemTemplate>
                           
                        </asp:Repeater>
                    </asp:Panel>
                </td>
            </tr>
        </table>
         <table>
             <tr>
                 <td>
                     <asp:FileUpload ID="FileUpload_img" accept="image/*" CssClass="btn" AllowMultiple="false" runat="server" Width="315px" />
                 </td>               
             </tr>
             <tr>
                 <td>
                     <asp:Button ID="btn_upload_pic" CssClass="btn" runat="server" Text="Upload picture" />
                     <asp:Button ID="btn_back_album_folder" CssClass="btn" runat="server" Text="Back to folder" />
                      <asp:Button ID="btn_remove_photo" CssClass="btn"  runat="server" Text="remove photo" />
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lbl_validation_photo_gallery" runat="server" ForeColor="Red" Text=""></asp:Label>
                 </td>
                 <td>
                     <asp:RegularExpressionValidator ID="validation_uload_img" runat="server" ControlToValidate="FileUpload_img" ForeColor="Red" ErrorMessage="Only .gif, .jpg, .png, .tiff and .jpeg" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Bb][Mm][Pp])|.*\.([pP][nN][gG])|.*\.([tT][iI][iI][fF])$)"></asp:RegularExpressionValidator>
                 </td>
             </tr>
         </table>

          <asp:Panel ID="Panel_open_gallery" CssClass="popViewAsset_pic" ScrollBars="Vertical" Height="620px" Visible="false" runat="server">
             <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" CssClass="title_all" runat="server" Text="Remove photo"></asp:Label>
                    </td>
                </tr>
            </table>
             <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_close_gallery" runat="server" CssClass="btn" Text="Close gallery" />
                    </td>
                    <td>
                        <asp:Button ID="btn_delete_photo" CssClass="btn" runat="server" Text="delete" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView_open_gallery" AutoGenerateColumns="false" runat="server">
                <Columns>
                    
                    <asp:TemplateField>
                        <ItemTemplate>

                            <asp:CheckBox ID="chkCtrl" runat="server" />
                            
                            
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Title" ControlStyle-CssClass="hidden"  DataField="photo_id" >
                        <ItemStyle CssClass="hidden" />

                    </asp:BoundField>
                    <asp:TemplateField>
                         <ItemTemplate>

                            
                            
                            <asp:Image runat="server" ID="imgrep" Width="500px" Height="400px" ImageUrl='<%# Eval("pic_url")%>' />
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
        </asp:Panel>
    </div>
</asp:Content>
