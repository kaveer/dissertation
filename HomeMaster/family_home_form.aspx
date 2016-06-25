<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="family_home_form.aspx.vb" Inherits="HomeMaster.family_home_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="maindivChildHome">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Main page"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="sidedivContactus">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="View note"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:DetailsView ID="DetailView_view_note"  CssClass="grid"  AllowPaging="true" runat="server" Height="50px" Width="500px">
                            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="<<" LastPageText=">>" PageButtonCount="1" Position="Bottom" />
                        </asp:DetailsView>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_add_notes" CssClass="btn" runat="server" Text="Add note" />
                    </td>
                    <td>
                        <asp:Button ID="btn_remove_note_panel" CssClass="btn" runat="server" Text="Remove note" />
                    </td>
                </tr>
            </table>
            <br />
             <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="View Expense"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Chart ID="Chart_view_expense" Height="500px" Width="500px" runat="server">
                            <Series>
                                <asp:Series Name="Series2" ChartType="Column" Palette="SeaGreen" IsValueShownAsLabel="true" ChartArea="ChartArea1"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                </tr>
            </table>
             <table>
                <tr>
                    <td>
                        <asp:Label ID="Label4" CssClass="subtitle1" runat="server" Text="Family album"></asp:Label>
                    </td>
                </tr>
            </table>
            <img src="Images/familyAlbumPrev/make-a-family-photo-album-banner.jpg" width="700" height="250" />
            <asp:Button ID="btn_open_family_album" runat="server" CssClass="btn" Text="Open family album" />
        </div>
       
    <div class="sidebarChildhome">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_sidebar1" CssClass="subtitle1" runat="server" Text="Dashboard"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                         <asp:Label ID="Label2" ForeColor="Red" runat="server" Text="Products about to finish"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GridView_decrease_product" AllowPaging="true" PageSize="5" CssClass="grid" Width="300px" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
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
