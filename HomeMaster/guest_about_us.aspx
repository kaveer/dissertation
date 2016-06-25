<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/guest.Master" CodeBehind="guest_about_us.aspx.vb" Inherits="HomeMaster.guest_about_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindiv">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="About Us"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <%--<div>
        <img class="banner" src="Images/home_banner.jpg" alt="Home banner" />
    </div>--%>
    <br />
    <div class="subdiv">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Our company"></asp:Label>
                </td>
            </tr>
        </table>
        <div >
            <p>
               HomeMaster is a free tool help user to control their house an interact with any member registered. This system is developed using skills and knowlegde acquired at the Universiy Of Technology, Mauritis under the supervision of senior lecturer Mr J.Narsoo.  
            </p>
        </div>
    </div>
 <%--   <div class="sidebar">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_sidebar1" CssClass="subtitle1" runat="server" Text="Features"></asp:Label>
                    </td>
                </tr>
            </table>
            <ul>
                <li>track incomes and expenses</li>
                <li>loan payment history</li>
                <li>Your personal stock control</li>
                <li><asp:LinkButton ID="lbl_link_overview" runat="server">More...</asp:LinkButton></li>
            </ul>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_sidebar2" CssClass="subtitle1" runat="server" Text="Thinks you'll like"></asp:Label>
                    </td>
                </tr>
            </table>
            <ul>
                <li>Coffee</li>
                <li>Tea</li>
                <li>Milk</li>
                <li><asp:LinkButton ID="LinkButton1" runat="server">More...</asp:LinkButton></li>
            </ul>
        </div>
    </div>--%>
</div>
</asp:Content>
