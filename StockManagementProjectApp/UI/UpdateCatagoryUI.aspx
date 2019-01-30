<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCatagoryUI.aspx.cs" Inherits="StockManagementProjectApp.UI.UpdateCatagoryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Catagory</title>
    <link rel="stylesheet" href="SidebarStylecopy.css" type="text/css" />
    <meta name="viewport" content="width = device-width initial-scale=1" />
    <style type="text/css">
        .mainContent {
            padding-top: 60px;
            float: left;
            padding-left: 200px;
        }
        .auto-style1 {
            width: 835px;
        }

        .auto-style2 {
            width: 207px;
            height: 59px;
            text-align: right;
        }

        .auto-style3 {
            width: 271px;
        }

        .auto-style4 {
            width: 173px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="header">
                <p id="para">Update Catagory</p>
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
            <table class="auto-style1" style="height: 152px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px; margin-left: 10px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Catagory Name" style="text-align: right"></asp:Label>
                    </td>
            
                    <td class="auto-style3">
                        <asp:TextBox ID="catagoryTextBox" runat="server" Width="293px" Height="28px" style="margin-bottom: 2px; margin-left: 21px;"></asp:TextBox>
                        <asp:HiddenField ID="idHiddenField" runat="server" />
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td class="auto-style2">&nbsp;</td>
            
                    <td class="auto-style3">
                        <asp:Button ID="updateButton" runat="server" Text="Update" BackColor="#006699" style="margin-left: 148px" Width="170px" Height="33px" Font-Bold="True" Font-Size="Medium" OnClick="updateButton_Click" />
                    </td>
                    <td class="auto-style4"></td>
                </tr>
            </table>
            <asp:Label ID="outputLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Height="30px" Width="322px" Style="margin-left: 251px; margin-top: 0px"></asp:Label>

        </div>
    </form>
</body>
</html>
