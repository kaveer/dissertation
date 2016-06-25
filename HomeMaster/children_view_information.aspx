<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/children.Master" CodeBehind="children_view_information.aspx.vb" Inherits="HomeMaster.children_view_information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="User general setting"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="subdiv">
           <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle2" CssClass="subtitle1" runat="server" Text="Username detail"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:DetailsView ID="DetailsView_username" CssClass="grid" runat="server" Height="50px" Width="125px"></asp:DetailsView>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="subtitle1" runat="server" Text="General information"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                       <asp:DetailsView ID="DetailsView_general_info" CssClass="grid" runat="server" Height="50px" Width="200px"></asp:DetailsView>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label4" CssClass="subtitle1" runat="server" Text="Email detail"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GridView_email" CssClass="grid" AllowPaging="true" PageSize="3" runat="server"></asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
