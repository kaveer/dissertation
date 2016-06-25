<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/member.Master" Culture = "en-GB" EnableEventValidation = "false" CodeBehind="member_view_expense.aspx.vb" Inherits="HomeMaster.member_view_expense" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="maindivChildHome">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_title" runat="server" CssClass="title_all" Text="View expenses"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_subtitle" CssClass="subtitle1" runat="server" Text="View by list"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView_all_expense" CssClass="grid" AllowPaging="true" PageSize="10" runat="server"></asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView_all_expense" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_remove_expense" CssClass="btn" runat="server" Text="Remove" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_validation_remove" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" CssClass="subtitle1" runat="server" Text="View by chart"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Chart ID="Chart_view_expense" Height="500px" Width="500px" runat="server">
                <Series>
                    <asp:Series Name="Series2" ChartType="Column" Palette="SeaGreen"  IsValueShownAsLabel="true" ChartArea="ChartArea1"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_select_type" runat="server" Text="Select"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_select_type" CssClass="ddlist" AutoPostBack="true" runat="server">
                            <asp:ListItem>View by category</asp:ListItem>
                            <asp:ListItem>view by date</asp:ListItem>
                            <asp:ListItem>View by means of payment</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                   
                </tr>
            </table>
            <table>
                <tr>
                     <td>
                        <asp:Label ID="lbl_from_date" runat="server" Text="select date from "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_from_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_to_date" runat="server" Text="to"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbx_to_date" CssClass="txtbxNoSize-css" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btn_display_chart" CssClass="btn" runat="server" Text="search" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                         <asp:CompareValidator ID="validation_fromdate" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_from_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                         <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                         <asp:CompareValidator ID="validation_todate" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtbx_to_date" ForeColor="Red" ErrorMessage="Enter a valid date like DD/MM/YYYY."></asp:CompareValidator>
                         <%--NOTE : TO ALLOW THIS VALIDATOR TO VALIDATE THE FORMAT "dd/MM/yyy" ADD Culture = "en-GB" IN <%@ PAGE Title..... %>--%>
                        <asp:Label ID="lbl_validation" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            
        </div>
    </div>
   
</asp:Content>
