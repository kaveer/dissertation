<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/guest.Master" CodeBehind="guest_over_shopping.aspx.vb" Inherits="HomeMaster.guest_over_shopping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="maindiv">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Shopping management"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="sidedivContactus">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Shopping list"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>You can create and add products in a shopping list on the spot. and view all shopping list and take some action such as delete a shopping list, add new product in a particular list or try our new feature share a shopping list and search a list that you have created. </p>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="Products category"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>Confuse with a list with all the products in it well that's not a problem. You can view all your products in your lists whether it is already purchased or will be purchased soon. HomeMaster also offers you the facility to sort products in a selected category or simply search for a product in the selected category </p>
                    </td>
                </tr>
            </table>
        </div>
         <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="subtitle1" runat="server" Text="Sharing list"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>HomeMaster offers you its unique feature to share list created amount your family member. children can create a shopping list with their needs and sent it to you right on the spot and not need to check who sent you a list as HomeMaster will notify you of any income list</p>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label3" CssClass="subtitle1" runat="server" Text="Generate list"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>Tired of creating shopping list every month? well then HomeMaster have the solution for your problem, HomeMaster allows you to generate your shopping list based on previous records and complex analysis. Further more you can either create a list or merge the generated products with an existing list</p>
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
                        <img class="overviewfamilyScreenshot" src="Images/overviewShop/Screenshot%202016-03-07%2007.54.50.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewShop/Screenshot%202016-03-07%2007.55.02.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewShop/Screenshot%202016-03-07%2007.55.16.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewShop/Screenshot%202016-03-07%2007.55.58.png" />

                        
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
        </div>
</div>
</asp:Content>
