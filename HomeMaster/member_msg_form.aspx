<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" EnableEventValidation = "false" CodeBehind="member_msg_form.aspx.vb" Inherits="HomeMaster.member_msg_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Messaging service"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_recipient" CssClass="grid" AllowPaging ="true" PageSize="5" runat="server"></asp:GridView>

                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_create_msg" CssClass="btn" runat="server" Text="new message" />
                        </td>
                        <td>
                            <asp:Button ID="btn_inbox" CssClass="btn" runat="server" Text="View indox" />
                        </td>
                        <td>
                            <asp:Button ID="btn_view_sent_msg" CssClass="btn" runat="server" Text="view sent message" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            

                <asp:Panel ID="Panel_sent_msg" Visible="false" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_sent_to" runat="server" Text="Sent to :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbx_recipient" CssClass="txtbxNoSize-css" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_msg_body" runat="server" Text="content :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbx_msg_body" CssClass="txtbxDescrip-css" Width="205px" Height="50px"  TextMode="MultiLine" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btn_sent_msg" CssClass="btn" runat="server" Text="Sent message" />
                            </td>
                            <td>
                                <asp:Button ID="btn_cancel_msg" CssClass="btn" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel_view_inbox_sent_msg" Visible="false" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:DetailsView ID="DetailView_inbox_msgs" CssClass="grid" Visible="false" AllowPaging="true" runat="server" Height="50px" Width="500px">
                                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="<<" LastPageText=">>" PageButtonCount="1" Position="Bottom" />
                                </asp:DetailsView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DetailsView ID="Detailview_sent_msgs" CssClass="grid" Visible="false" AllowPaging="true" runat="server" Height="50px" Width="500px">
                                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="<<" LastPageText=">>" PageButtonCount="1" Position="Bottom" />
                                </asp:DetailsView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView_recipient" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btn_view_sent_msg" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        
    </div>
</asp:Content>
