<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/guest.Master" CodeBehind="guest_over_family.aspx.vb" Inherits="HomeMaster.guest_over_family" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindiv">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Family Control"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="sidedivContactus">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Family members"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>With HomeMaster you can add any member of your family and control each and every member. You are able to view a member status whether it is active or deactive. Moreover you can also view members within our system that you have created but not yet activated online</p>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="Add members"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>Need to create a new account for a particular member, HomeMaster makes your life easy and save your time with our quick registration system. Just enter a minimum details such as username , email and password for a new member then we will take care of the rest. We will ensure activation process of the new member with maximum security and privacy. As an adminitrator you can select the type of relationship that you share with a particular member </p>
                    </td>
                </tr>
            </table>
        </div>
         <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="subtitle1" runat="server" Text="Messaging and Notification"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <p>Contact your family member for free or leave them a message so that they an view it later in their inbox with our new messaging service. You won't miss any new message with HomeMaster notification, as we will notify you for any new message received</p>
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
                        <img class="overviewfamilyScreenshot"  src="Images/overviewFamily/Screenshot%202016-03-07%2007.03.04.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewFamily/Screenshot%202016-03-07%2007.03.20.png" />
                        <img class="overviewfamilyScreenshot" src="Images/overviewFamily/Screenshot%202016-03-07%2007.03.27.png" />
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
        </div>
</div>
</asp:Content>
