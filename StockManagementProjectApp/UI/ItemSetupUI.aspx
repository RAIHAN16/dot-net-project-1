<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetupUI.aspx.cs" Inherits="StockManagementProjectApp.UI.ItemSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Setup Item</title>
   <link rel="stylesheet" href="SidebarStylecopy.css" type="text/css" />
    <meta name="viewport" content="width = device-width initial-scale=1" />
    <style type="text/css">
        .mainContent {
            padding-top: 60px;
            float: left;
            padding-left: 160PX;
            width: 70%;
        }
         .auto-style1 {
             width: 830px;
         }

        .auto-style7 {
            width: 195px;
            text-align: right;
            height: 38px;
        }

        .auto-style8 {
            width: 263px;
            height: 38px;
        }

        .auto-style2 {
            width: 195px;
            text-align: right;
        }

        .auto-style3 {
            width: 263px;
        }

        .auto-style5 {
            width: 195px;
            text-align: right;
            height: 36px;
        }

        .auto-style6 {
            width: 263px;
            height: 36px;
        }
        .auto-style9 {
            width: 195px;
            text-align: right;
            height: 60px;
        }
        .auto-style10 {
            width: 263px;
            height: 60px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <div id="header">
                <p id="para">Item Setup</p>
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
            <table class="auto-style1" style="height: 234px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px; margin-left: 0px;">
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Catagory"></asp:Label>
                    </td>

            <center>

                    <td class="auto-style8">
                        <asp:DropDownList ID="catagoryDropDownList" runat="server" Width="292px" Height="28px" Style="margin-left: 41px">
                        </asp:DropDownList>

                    </td>
                </tr>
           </center>             
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Company"></asp:Label>
                    </td>

            <center>

                    <td class="auto-style3">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Height="28px" Width="293px" Style="margin-left: 42px">
                        </asp:DropDownList>
                    </td>
                </tr>
           </center>             
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Item Name"></asp:Label>
                    </td>
            <center>
            <center>
                    <td class="auto-style10">
                        <asp:TextBox ID="itemNameTextBox" runat="server"  Width="290px" Height="25px" Style="margin-bottom: 2px; margin-left: 40px;"></asp:TextBox>
                    </td>
                </tr>
           </center>             
           </center>             
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Reorder Lavel"></asp:Label>
                    </td>

            <center>
            <center>
            <center>
            <center>

                    <td class="auto-style3">
                        <asp:TextBox ID="reorderLavelTextBox" runat="server"  Width="290px" Height="25px" Style="margin-bottom: 2px; margin-left: 40px;"></asp:TextBox>
                    </td>
                </tr>

           </center>             
           </center>             
           </center>             
           </center>             

                <tr>
                    <td class="auto-style5"></td>
            <center>
            <center>
            <center>
                    <td class="auto-style6">
                        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" BackColor="#006699" style="margin-left: 164px" Width="170px" Height="33px" Font-Bold="True" Font-Size="Medium"/>
                    </td>
                </tr>
            </table> 
           </center>             
           </center>             
           </center>             
        </div>
        

        <asp:Label ID="outputLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Height="30px" Width="264px" Style="margin-left: 176px; margin-top: 0px"></asp:Label>
    </form>
</body>
</html>
