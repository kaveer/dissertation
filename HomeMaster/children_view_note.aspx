<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/children.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="children_view_note.aspx.vb" Inherits="HomeMaster.children_view_note" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="mainViewNote">
    
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="View note"></asp:Label>
                </td>
            </tr>
        </table>
   
    <div>
        <table>
            <tr>
                <td>
                    <asp:DetailsView ID="DetailView_view_note" CssClass="grid" AllowPaging="true" runat="server" Height="50px" Width="500px">
                        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="<<" LastPageText=">>" PageButtonCount="1" Position="Bottom" />
                    </asp:DetailsView>
                </td>
            </tr>
        </table>
       <table>
           <tr>
               <td>
                   <asp:Button ID="btn_add_notes" runat="server" CssClass="btn" Text="Add note" />
               </td>
               <td>
                   <asp:Button ID="btn_remove_note_panel" CssClass="btn" runat="server" Text="Remove note" />
               </td>
           </tr>
        </table>
        <asp:Panel ID="Panel_remove_note" CssClass="childHomeRemoveNote" Visible ="false" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label3" CssClass="title_all" runat="server" Text="Remove note"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                 <asp:GridView ID="GridView_remove_note" CssClass="grid" AllowPaging="true" PageSize="7" runat="server"></asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView_remove_note" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_remove_note" CssClass="btn" runat="server" Text="Remove" />
                    </td>
                    <td>
                        <asp:Button ID="btn_cancel_remove" CssClass="btn" runat="server" Text="Cancel" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation_remove" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
     </div>
</asp:Content>
