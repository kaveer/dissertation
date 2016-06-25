<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" CodeBehind="member_display_set_form.aspx.vb" Inherits="HomeMaster.member_display_set_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="title_all" runat="server" Text="Theme setup"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                 <td>
                     <img style="border:solid; border-radius: 10px 10px 10px 10px; width:200px; height:200px;" src="Images/themePic/Screenshot%202016-02-18%2010.33.10.png" />
                </td>
                <td>
                    <asp:Button CssClass="btn" ID="btn_default_theme" runat="server" Text="Apply" />
                </td>             
            </tr>
            <tr>
                <td>
                    <img style="border:solid; border-radius: 10px 10px 10px 10px; width:200px; height:200px;" src="Images/themePic/Screenshot%202016-02-17%2021.58.54.png" />
                </td>
                <td>
                    <asp:Button CssClass="btn" ID="btn_second_theme" runat="server" Text="Apply" />
                </td>
            </tr>
            <tr>
                <td>
                    <img style="border:solid; border-radius: 10px 10px 10px 10px; width:200px; height:200px;" src="Images/themePic/Screenshot%202016-02-17%2022.05.35.png" />
                </td>
                <td>
                    <asp:Button CssClass="btn" ID="btn_third_theme" runat="server" Text="Apply" />
                </td>
            </tr>
            <tr>
                <td>
                    <img style="border:solid; border-radius: 10px 10px 10px 10px; width:200px; height:200px;"src="Images/themePic/Screenshot%202016-02-17%2022.04.02.png" />
                </td>
                <td>
                    <asp:Button CssClass="btn" ID="btn_forth_theme" runat="server" Text="Apply" />
                </td>
            </tr>
            <tr>
                <td>
                    <img style="border:solid; border-radius: 10px 10px 10px 10px; width:200px; height:200px;" src="Images/themePic/12752085_1571912479800189_1608432562_o.jpg" />
                </td>
                <td>
                    <asp:Button CssClass="btn" ID="btn_fifth_theme" runat="server" Text="Apply" />
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>
