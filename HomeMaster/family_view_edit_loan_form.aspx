<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/family.Master"  EnableEventValidation = "false" CodeBehind="family_view_edit_loan_form.aspx.vb" Inherits="HomeMaster.family_view_edit_loan_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="View loan "></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_view_loan" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Menu ID="Menu1" runat="server"  CssClass="menu_control_css"  Orientation="Horizontal">
                    <StaticHoverStyle BackColor="#9fa8a3" />
                    <StaticMenuItemStyle CssClass="menu_control_not_selec" />
                    <StaticSelectedStyle BackColor="#9fa8a3" />
                    <Items>
                        <asp:MenuItem Text="lender details" Value="0" Selected="true"></asp:MenuItem>
                        <asp:MenuItem Text="loan details" Value="1"></asp:MenuItem>
                        <asp:MenuItem Text="repayment history" Value="2"></asp:MenuItem>
                    </Items>
                </asp:Menu>
                <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                    <asp:View ID="lennder_detail_view" runat="server">
                        <table>
                            <tr>
                                <td>
                                                                
                                    <asp:DetailsView ID="DetailsView_lender_detail" CssClass="grid" runat="server" Height="50px" Width="400px"></asp:DetailsView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="loan_detail_view" runat="server">
                        <table>
                            <tr>
                                <td>
                                   
                                    <asp:DetailsView ID="DetailsView_loan_detail" CssClass="grid" runat="server" Height="50px" Width="400px"></asp:DetailsView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="repayment_view" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gridview_repay_history" CssClass="grid" AllowPaging="true" PageSize="5" runat="server"></asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
            <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="GridView_view_loan" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
          
        <table>
            <tr>
                <td>
                     <asp:Button ID="editloan_btn" CssClass="btn" runat="server" Text="Edit" />
                </td>
                <td>
                    <asp:Button ID="btn_addloan" CssClass="btn" runat="server" Text="Add loan" />
                </td>
                <td>
                    <asp:Button ID="btn_add_repayment" CssClass="btn" runat="server" Text="Add repayment" />
                </td>
                <td>
                    <asp:Button ID="btn_remove_loan" CssClass="btn" runat="server" Text="Remove loan" />
                </td>
            </tr>
        </table>      
    </div>
</asp:Content>
