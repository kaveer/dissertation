<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/guest.Master" CodeBehind="guest_over_fixed_asset.aspx.vb" Inherits="HomeMaster.guest_over_fixed_asset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindiv">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Asset management"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="sidedivover_fix_mgt">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Fixed asset"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>Home management is not only about budgeting and expenses you must be able to track all your fixed assets and property as well, that why HomeMaster came up with the new features we you not just add an asset as record but keep track of it by its location and current price. Further more you can also add repayments for a specific asset </p>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="Immovable property"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>HomeMaster does not only care for your fixed assets but also tracks your immovable properties such as building , office and premises. With HomeMaster you can upload as many pictures as you want for a particular room, building or fixed asset</p>
                    </td>
                </tr>
            </table>
        </div>
         <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="subtitle1" runat="server" Text="Repayments"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>With HomeMaster it is easy to record repayments of both fixed assets and property as well. </p>
                    </td>
                </tr>
            </table>
        </div>
    <div class="sidebaroverviewfamily">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_sidebar1" CssClass="subtitle1" runat="server" Text="Screenshots"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <img class="overviewfamilyScreenshot" src="Images/overviewAsset/Screenshot%202016-03-17%2010.51.04.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewAsset/Screenshot%202016-03-07%2009.13.43.png" />
                        <%--<img class="overviewfamilyScreenshot" src="Images/overviewAsset/Screenshot%202016-03-17%2010.51.52.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewAsset/Screenshot%202016-03-17%2010.51.30.png" />--%>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
        </div>
</div>
</asp:Content>
