<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/children.Master" CodeBehind="children_view_by_category.aspx.vb" Inherits="HomeMaster.children_view_by_category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindivChildHome">
    
    <table>
        <tr>
            <td>
                <asp:Label ID="Lbl_form_name" CssClass="title_all" runat="server" Text="View By Category"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_select_category" runat="server" Text="Select category :"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_select_category" CssClass="ddlist" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btn_select_by_category" CssClass="btn" runat="server" Text="Search" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation_select_category" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="Panel1" Visible ="false" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="Products in selected  category"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gridview_by_category" CssClass="grid" AllowPaging="true" PageSize="4" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_sort" runat="server" Text="Sort by:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_sort_category_list" CssClass="ddlist" runat="server">
                                <asp:ListItem>-- select --</asp:ListItem>
                                <asp:ListItem Value="product_name">Product Name</asp:ListItem>
                                <asp:ListItem Value="date_created">Date created</asp:ListItem>
                                <asp:ListItem Value="list_name">List name</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_sort" CssClass="btn" runat="server" Text="Sort" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_validation_for_sort" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_search" runat="server" Text="Search for :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbx_search" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_search" CssClass="btn" runat="server" Text="Search" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_valitation_for_search" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_select_by_category"  EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
        </div>
</asp:Content>
