<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/guest.Master" CodeBehind="guest_over_stock_control.aspx.vb" Inherits="HomeMaster.guest_over_stock_control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="maindiv">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Stock Control"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="sidedivoverviewStock">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="View your stock"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>View your entire stock of consumable products and the quantity that you have in stock. HomeMaster will automatically generates and displays all products that are about to finsh. Products which are about to finish can be saved in a new list or merge them with an existing of your choice</p>
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
                        <img class="overviewfamilyScreenshot" src="Images/overviewStock/Screenshot%202016-03-07%2007.36.24.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewStock/Screenshot%202016-03-07%2007.36.26.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewStock/Screenshot%202016-03-07%2007.36.28.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewStock/Screenshot%202016-03-07%2007.36.47.png" />
                        
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
        </div>
</div>
</asp:Content>
