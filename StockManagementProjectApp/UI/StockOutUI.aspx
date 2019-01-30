<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementProjectApp.UI.StockOutUI" %>
<%@ Import Namespace="System.ComponentModel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Out</title>
    <link rel="stylesheet" href="SidebarStylecopy.css" type="text/css" />
    <meta name="viewport" content="width = device-width initial-scale=1" />
    <style type="text/css">
        
        .mainContent {
            padding-top: 60px;
            float: left;
            padding-left: 200px;
        }

        .auto-style2 {
            width: 246px;
            text-align: right;
        }

        .auto-style3 {
            width: 263px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            height: 31px;
            width: 128px;
        }
        .auto-style7 {
            height: 31px;
            width: 121px;
        }
        .auto-style8 {
            height: 31px;
            width: 468px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div id="header">
                <p id="para">Stock Out</p>
            </div>
            <div id="sideBar">
                <ul id="sideBarContents">
                     <li><a href="IndexUI.aspx">Home</a></li>
                    <li><a href="CatagorySetupUI.aspx">Setup Catagory</a></li>
                    <li><a href="CompanySetupUI.aspx">Setup Company</a></li>
                    <li><a href="ItemSetupUI.aspx">Setup Item</a></li>
                    <li><a href="StockIn.aspx">Stock In</a></li>
                    <li><a href="StockOutUI.aspx">Stock Out</a></li>
                    <li><a href="SearchAndViewUI.aspx">Search and view Item Summery</a></li>
                    <li><a href="ViewSalesBetweenTwoDatesUI.aspx">View Sales Between Two Dates</a></li>
                </ul>
            </div>
        <div class="mainContent">
            <table style="height: 303px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Company"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Width="293px" style="margin-left: 29px" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" AutoPostBack="True" Height="28px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Item"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="itemDropDownList" runat="server" Width="293px" style="margin-left: 29px" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged" AutoPostBack="True" Height="28px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Reorder Lavel"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="reorderLavelTextBox" runat="server" Enabled="False" style="text-align: left; margin-left: 29px" Width="293px" Height="28px">view</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Available Quantity"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="availableQuantityTextBox" runat="server" Enabled="False" style="text-align: left; margin-left: 29px" Width="293px" Height="28px">view</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Stock Out Quantity"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="stockOutTextBox" runat="server" style="text-align: left; margin-left: 29px" Width="293px" Height="28px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="addButton" runat="server" BackColor="#006699" style="margin-left: 157px" Text="Add" Width="170px" Height="33px" Font-Bold="True" Font-Size="Medium" OnClick="addButton_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="outputLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Height="30px" Width="322px" Style="margin-left: 2px; margin-top: 0px"></asp:Label>

        </div>
        
        <br/>

        <div style="text-align: center">
            <center>
            <asp:GridView ID="stockOutGridView" runat="server" AutoGenerateColumns="False" style="margin-left: 0px; margin-top: 25px;" Width="839px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Height="300px">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("ItemName") %>'></asp:Label>                             
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("AvailableQuantity") %>'></asp:Label> 
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
            </center>
            <br/>
            <center>
            <table style="height: 54px; width: 865px; margin-right: 4px; margin-left: 0px;">
                <tr>
                    <td align="left" class="auto-style8">
                        </td>
                    <td class="auto-style6">
                        <asp:Button ID="sellButton" runat="server" Text="Sell" Height="30px" Width="94px" Font-Bold="True" Font-Size="Medium" ForeColor="#CC00FF" style="margin-left: 7px" OnClick="sellButton_Click" /></td>
                    <td class="auto-style5"><asp:Button ID="damageButton" runat="server" Text="Damage" Height="30px" Width="104px" Font-Bold="True" Font-Size="Medium" ForeColor="#CC00FF" style="margin-left: 3px" OnClick="damageButton_Click" /></td>
                    <td class="auto-style7">&nbsp;&nbsp;&nbsp; <asp:Button ID="lostButton" runat="server" Text="Lost" Height="30px" Width="94px" style="margin-left: 0px" Font-Bold="True" Font-Size="Medium" ForeColor="#CC00FF" OnClick="lostButton_Click" /></td>
                </tr>
            </table>
            </center>
        </div>
    </form>
</body>
</html>
