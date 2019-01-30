<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesBetweenTwoDatesUI.aspx.cs" Inherits="StockManagementProjectApp.UI.ViewSalesBetweenTwoDatesUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Sales between two dates</title>
    <link rel="stylesheet" href="SidebarStylecopy.css" type="text/css" />
    <meta name="viewport" content="width = device-width initial-scale=1" />
    <link rel="stylesheet" href="jquery-ui-1.12.1.custom/jquery-ui.min.css"/>
    <script src="jquery-ui-1.12.1.custom/external/jquery/jquery.js"></script>
    <script src="jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#toDateTextBox').datepicker({
                showOn: 'both',
                buttonText: 'Calendar',
                dateFormat: 'yy/mm/dd',
                changeYear: true,
                changeMonth: true,
                minDate: new Date(2000, 0, 1)

            });
        });

        $(document).ready(function () {
            $('#fromDateTextBox').datepicker({
                showOn: 'both',
                buttonText: 'Calendar',
                dateFormat: 'yy/mm/dd',
                changeYear: true,
                changeMonth: true,
                minDate: new Date(2000, 0, 1)

            });
        });
    </script>

    <style type="text/css">

        .mainContent {
            padding-top: 60px;
            float: left;
            padding-left: 180px;
        }

        .auto-style2 {
            width: 131px;
            text-align: right;
        }

        .auto-style3 {
            width: 317px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <div id="header">
                <p id="para">View Sales Between Two Dates</p>
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
            <table style="height: 182px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px; width: 682px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="From Date"></asp:Label>
                    </td>
            
                    <td class="auto-style3">
                        <asp:TextBox ID="fromDateTextBox" runat="server" style="margin-left: 28px" Width="293px" Height="28px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#06600" Text="To Date"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="toDateTextBox" runat="server" style="margin-left: 28px" Width="293px" Height="28px"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="searchButton" runat="server" BackColor="#006699" style="margin-left: 156px" Text="Search" Width="170px" Height="30px" Font-Bold="True" Font-Size="Medium" OnClick="searchButton_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="outputLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Height="30px" Width="264px" style="margin-left: 0px; margin-top: 0px"></asp:Label>

        
        
        <br/>

            <div style="text-align: center">
                <asp:GridView ID="searchAndViewGridView" runat="server" AutoGenerateColumns="False" style="text-align: center; margin-top: 25px;" Width="842px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Height="300px">
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
                                <asp:Label runat="server" Text='<%#Eval("TotalSaleAmount") %>'></asp:Label> 
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
            </div>
            <br/>
            <asp:Button ID="exportToPdf_Click" runat="server" Text="ExportToPDF" OnClick="exportToPdf_Click_Click" />
        </div>
            
    </form>
</body>
</html>
