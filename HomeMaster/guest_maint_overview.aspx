<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/guest.Master" CodeBehind="guest_maint_overview.aspx.vb" Inherits="HomeMaster.guest_maint_overview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindiv">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Maintenance Management"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <img class="banner"  src="Images/maintenance_banner.png" alt="maintenance banner" />
    </div>
    <br />
    <div class="subdiv">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Overview"></asp:Label>
                </td>
            </tr>
        </table>
        <div >
            <p>
               we believe budgeting should be easy. Give HomeMaster a try and focus your money on what matters.Knock out those pesky debts and build wealth with this free tool. Its way easier than pen and paper. We provide a lots of facilities
Have you ever heard been about E-LOAN? HomeMaster is a great website to track loan paymeny. HomeMaster allow you to easily organise your shopping list. Designed to help you save time and money at home ,built with one goal in mind: to help you to be safe. 
            </p>
        </div>
    </div>
    <div class="sidebar">
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
    </div>
</div>
</asp:Content>
