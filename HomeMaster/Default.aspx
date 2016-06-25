<%@ Page Title="" Language="vb" AutoEventWireup="false"  MasterPageFile="~/guest.Master"  EnableTheming="true" CodeBehind="Default.aspx.vb" Inherits="HomeMaster._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maindiv">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" CssClass="title_all" runat="server" Text="Welcome to HomeMaster"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <img class="banner" src="Images/home_banner.jpg" alt="Home banner" />
    </div>
    <br />
    <div class="subdiv">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="Why HomeMaster"></asp:Label>
                </td>
            </tr>
        </table>
        <div >
            <p>
               Send and receive private messages from members. Get notified of any product that is almost finished. Change your theme as often as you like. Two methods to recover or reset a forgotten password. do it easily while being offline or by use of usename & password. Use password protection by encryption. Create your shopping list and share it keep track of maintenance and add photos. Customize your incomes and expenses, along with a analytics monthly chart that helps you better understand your spending habits.
            </p>
        </div>
        <div class="privacyDiv">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle1" CssClass="subtitle1" runat="server" Text="Privacy"></asp:Label>
                    </td>
                </tr>
            </table>
            <img class="privacypic"  src="Images/defaultPagePic/online-privacy.jpg" />
            <p> HomeMaster offers a great privacy feature where all your personal data are kept private ans secure in our system. We also ensure that your personal data are not being accessed by unauthorised person and advertisment company</p>
        </div>
        <div class="securityDiv">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle2" CssClass="subtitle1" runat="server" Text="Security"></asp:Label>
                    </td>
                </tr>
            </table>
            <img class="securitypic" src="Images/defaultPagePic/password-security.jpg" />
            <p>Our system provides the best security to encsure privacy and protection for our user. HomeMaster used complex algorithm to encrypt user data such as password and other sensitive data. </p>
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
                <li>Manage shopping list</li>
                <li>Control members</li>
                <li>Create members</li>
                <li>Maintenance control</li>

            </ul>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_sidebar2" CssClass="subtitle1" runat="server" Text="Things you'll like"></asp:Label>
                    </td>
                </tr>
            </table>
            <ul>
                <li>Visualization of expense through chart</li>
                <li>ensure security of sensitve data</li>
                <li>link account with personal mail</li>
                <li>Notification system</li>
                <li>Sent mail to user</li>
                <li>Built in messaging services</li>
            </ul>
        </div>
    </div>
</div>
</asp:Content>
