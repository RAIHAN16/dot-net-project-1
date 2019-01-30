<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockIn.aspx.cs" Inherits="StockManagementProjectApp.UI.StockIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock In</title>
    <link rel="stylesheet" href="SidebarStylecopy.css" type="text/css" />
    <meta name="viewport" content="width = device-width initial-scale=1" />
    <style type="text/css">
        
        .mainContent {
            padding-top: 60px;
            float: left;
            padding-left: 200px;
        }
         .auto-style1 {
             width: 111%;
             margin-left: 1px;
         }

        .auto-style2 {
            width: 246px;
            text-align: right;
        }

        .auto-style3 {
            width: 263px;
        }

        .auto-style5 {
            width: 246px;
            text-align: right;
            height: 36px;
        }

        .auto-style6 {
            width: 263px;
            height: 36px;
        }

        .auto-style7 {
            width: 246px;
            text-align: right;
            height: 38px;
        }
        .auto-style8 {
            width: 263px;
            height: 38px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="header">
                <p id="para">Stock In</p>
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
        </div>
        <div class="mainContent">
            <table class="auto-style1" style="height: 303px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px;">
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Company"></asp:Label>
                        <asp:HiddenField ID="availableQuantityHiddenField" runat="server" />
                    </td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Width="293px" Height="29px" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" AutoPostBack="True" style="margin-left: 23px">
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Item"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="itemDropDownList" runat="server" Height="28px" Width="293px" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged" AutoPostBack="True" style="margin-left: 22px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Reorder Lavel"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="reorderLavelTextBox" runat="server" Text="view" Enabled="False" Width="293px" Height="28px" style="margin-bottom: 2px; margin-left: 21px;"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Available Quantity"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="availableQuantityTextBox" runat="server" Text="view" Enabled="False" Width="293px" Height="28px" style="margin-bottom: 2px; margin-left: 21px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Stock In Quantity"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="stockInTextbox" runat="server" Width="292px" Height="28px" style="margin-bottom: 2px; margin-left: 21px;" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6">
                        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" BackColor="#006699" style="margin-left: 146px" Width="172px" Height="33px" Font-Bold="True" Font-Size="Medium"/>
                    </td>
                </tr>
            </table>

        </div>

        <p>

            <asp:Label ID="outputLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Height="30px" Width="264px" Style="margin-left: 292px; margin-top: 0px"></asp:Label>

        </p>
    </form>
</body>
</html>
