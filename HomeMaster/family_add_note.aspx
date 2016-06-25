<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master"  Culture = "en-GB" EnableEventValidation = "false" CodeBehind="family_add_note.aspx.vb" Inherits="HomeMaster.family_add_note" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="maindivChildHome">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Add new note"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="subdiv">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Enter new note"></asp:Label>
                </td>
            </tr>
        </table>
       <table>
           <tr>
               <td>
                   <asp:Label ID="lbl_note_name" runat="server" Text="Note name"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtbx_note_name" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   <asp:Label ID="lbl_note_date" runat="server" Text="Note date"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtbx_note_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
               </td>
               <td>
                   <asp:CompareValidator ID="validation_date" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_note_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                   <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
               </td>
           </tr>
            <tr>
               <td>
                   <asp:Label ID="lbl_note_description" runat="server" Text="Note description"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtbx_note_description" CssClass="txtbxDescrip-css" Width="205px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
               </td>
           </tr>
       </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_add_note" CssClass="btn" runat="server" Text="Add note" />
                </td>
                <td>
                    <asp:Button ID="btn_view_note" CssClass="btn" runat="server" Text="View note" />
                </td>
                <td>
                    <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
</div>
        </div>
</asp:Content>
