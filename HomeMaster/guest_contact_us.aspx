<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/guest.Master" CodeBehind="guest_contact_us.aspx.vb" Inherits="HomeMaster.guest_contact_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindiv">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Contact us"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="sidedivContactus">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Fill in your detail"></asp:Label>
                </td>
            </tr>
        </table>
        <div >
           <table>
               <tr>
                   <td>
                       <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                   </td>
                   </tr>
               <tr>
                   <td>
                       <asp:TextBox ID="txtbx_name"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                  <td>
                       <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                   </td>
                   </tr>
               <tr>
                   <td>
                       <asp:TextBox ID="txtbx_email"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       <asp:RegularExpressionValidator ID="validation_email" ControlToValidate="txtbx_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ForeColor="Red" ErrorMessage="Invalid email address"></asp:RegularExpressionValidator>
                   </td>
               </tr>
               <tr>
                  <td>
                       <asp:Label ID="Label3" runat="server" Text="Message"></asp:Label>
                   </td>
                   </tr>
               <tr>
                   <td>
                       <asp:TextBox ID="txtbx_message" CssClass="txtbxDescrip-css" TextMode="MultiLine" Height="300px" Width="300px" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Button ID="btn_save" CssClass="btn" runat="server" Text="Save" />
                       <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                   </td>
               </tr>
           </table>
        </div>
    <div class="sidebarContactus">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_sidebar1" CssClass="subtitle1" runat="server" Text="Institution"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>University of technology , Mauritius</p>
                        <p>Avenue De la Concorde , Port Louis</p>
                        <p>Tel : 2075250</p>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_sidebar2" CssClass="subtitle1" runat="server" Text="Contact developer"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>Mr. Kaveersing Rajcoomar</p>
                        <p>Hollyroad no 1</p>
                        <p>vacoas</p>
                        <p>Email: kaveer.rajcoomar@gmail.com</p>
                        <p>Email: kaveer.rajcoomar@hotmail.com</p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
        </div>
</div>
</asp:Content>
