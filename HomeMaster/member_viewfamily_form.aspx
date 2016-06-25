<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" EnableEventValidation = "false" CodeBehind="member_viewfamily_form.aspx.vb" Inherits="HomeMaster.member_viewfamily_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="maindivChildHome">
       <table>
           <tr>
               <td>
                   <asp:Label ID="Label1" CssClass="title_all" runat="server" Text="View members"></asp:Label>
               </td>
           </tr>
       </table>
       <table>
           <tr>
               <td>
                   <asp:Label ID="lbl_title" CssClass="subtitle1" runat="server" Text="All active members"></asp:Label>
               </td>
           </tr>
       </table>
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
               <table>
                   <tr>
                       <td>
                           <asp:GridView ID="GridView_active_member" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                       </td>
                   </tr>
               </table>
           </ContentTemplate>
           <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_active_member" EventName="SelectedIndexChanged" />
           </Triggers>
       </asp:UpdatePanel>
      <table>
          <tr>
              <td>
                  <asp:Button ID="btn_deactivate" CssClass="btn" runat="server" Text="Deactivate" />
              </td>
              <td>
                  <asp:Label ID="lbl_search_mem" runat="server" Text="Search member"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtbx_search_mem"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
              </td>
              <td>
                  <asp:Button ID="btn_search" CssClass="btn" runat="server" Text="Search" />
              </td>
          </tr>
      </table>
       <table>
           <tr>
               <td>
                   <asp:Label ID="lbl_validation_active_mem" runat="server" ForeColor="Red" Text=""></asp:Label>
               </td>
           </tr>
       </table>
       <table>
           <tr>
               <td>
                   <asp:Label ID="lbl_title_2" CssClass="subtitle1" runat="server" Text="All deactivted members"></asp:Label>
               </td>
           </tr>
       </table>
       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
           <ContentTemplate>
               <table>
                   <tr>
                       <td>
                           <asp:GridView ID="GridView_deactivat_member" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                       </td>
                   </tr>
               </table>
           </ContentTemplate>
           <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_deactivat_member" EventName="SelectedIndexChanged" />
           </Triggers>
       </asp:UpdatePanel>
       <table>
          <tr>
              <td>
                  <asp:Button ID="btn_active_mem" CssClass="btn" runat="server" Text="activate" />
              </td>
              <td>
                  <asp:Label ID="lbl_search_deactive" runat="server" Text="Search member"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtbx_search_deactive"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
              </td>
              <td>
                  <asp:Button ID="btn_search_deactive" CssClass="btn" runat="server" Text="Search" />
              </td>
          </tr>
      </table>
       <table>
           <tr>
               <td>
                   <asp:Label ID="lbl_validate_deactive" runat="server" ForeColor="Red" Text=""></asp:Label>
               </td>
           </tr>
       </table>
        <table>
           <tr>
               <td>
                   <asp:Label ID="lbl_title_3" CssClass="subtitle1" runat="server" Text="Not activated"></asp:Label>
               </td>
           </tr>
       </table>
       <table>
           <tr>
               <td>
                   <asp:GridView ID="GridView_is_online_active" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
               </td>
           </tr>
       </table>
       <table>
          <tr>
              <td>
                  <asp:Label ID="lbl_search_isactive" runat="server" Text="Search member"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtbx_search_isactive"  CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
              </td>
              <td>
                  <asp:Button ID="btn_search_isactive" CssClass="btn" runat="server" Text="Search" />
              </td>
          </tr>
      </table>
       <table>
           <tr>
               <td>
                   <asp:Label ID="lbl_validate_isactive" runat="server" ForeColor="Red" Text=""></asp:Label>
               </td>
           </tr>
       </table>
   </div>
</asp:Content>
