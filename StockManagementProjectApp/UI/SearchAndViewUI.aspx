<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAndViewUI.aspx.cs" Inherits="StockManagementProjectApp.UI.SearchAndViewUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search And View Item</title>
    <link rel="stylesheet" href="SidebarStylecopy.css" type="text/css" />
    <meta name="viewport" content="width = device-width initial-scale=1" />
    <style type="text/css">
        .mainContent {
            padding-top: 60px;
            float: left;
            padding-left: 180px;
            width: 60%;
        }

        .auto-style2 {
            width: 246px;
            text-align: right;
        }

        .auto-style3 {
            width: 263px;
        }
        .auto-style4 {
            width: 187px;
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
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <div id="header">
                <p id="para">Search and View Item Summery</p>
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
            <div>
            <table class="auto-style1" style="height: 152px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Company"></asp:Label>
                    </td>
            
                    <td class="auto-style3">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Width="293px" style="margin-left: 29px" Height="28px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Catagory"></asp:Label>
                    </td>
            
                    <td class="auto-style3">
                        <asp:DropDownList ID="catagoryDropDownList" runat="server" Width="293px" style="margin-left: 29px" Height="28px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                
                <tr>
                    <td class="auto-style2">&nbsp;</td>
           
                    <td class="auto-style3">
                        <asp:Button ID="searchButton" runat="server" BackColor="#006699" style="margin-left: 149px" Text="Search" Width="170px" Height="33px" Font-Bold="True" Font-Size="Medium" OnClick="searchButton_Click" />
                    </td>
                    <td class="auto-style4"></td>
                </tr>
            </table>
        </div>
            <asp:Label ID="outputLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Height="30px" Width="264px" style="margin-left: 0px; margin-top: 0px"></asp:Label>
        </div>
        
        <br/>

            <div class="mainContent">
                <asp:GridView ID="searchAndViewGridView" runat="server" AutoGenerateColumns="False" style="margin-left: 0px; text-align: center; margin-top: 25px;" Width="842px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Height="301px">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
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

                        <asp:TemplateField HeaderText="Reorder Lavel">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ReorderLavel") %>'></asp:Label> 
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
                <asp:Button ID="exportToPdf" ForeColor="gray" runat="server" Text="ExportToPDF" OnClick="exportToPdf_Click" />
            </div>
            
    </form>
</body>
</html>
