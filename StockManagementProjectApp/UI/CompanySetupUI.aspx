<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="StockManagementProjectApp.UI.CompanySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company Setup</title>
    <link rel="stylesheet" href="SidebarStylecopy.css" type="text/css" />
    <meta name="viewport" content="width = device-width initial-scale=1" />
    <style type="text/css">
        
        .mainContent {
            padding-top: 60px;
            float: left;
            padding-left: 200px;
            height: 187px;
        }

        .auto-style2 {
            height: 13px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div id="header">
                <p id="para">Setup Company</p>
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
             <table class="auto-style1" style="height: 152px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px; margin-left: 56px; width: 590px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Company Name" Style="text-align: right"></asp:Label>
                    </td>

                    <td class="auto-style3">
                        <asp:TextBox ID="companyTextBox" runat="server" Width="293px" Height="28px" Style="margin-bottom: 2px; margin-left: 21px;"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">&nbsp;</td>

                    <td class="auto-style3">
                        <asp:Button ID="saveButton" runat="server" Text="Save" BackColor="#006699" Style="margin-left: 146px" Width="170px" Height="33px" Font-Bold="True" Font-Size="Medium" OnClick="saveButton_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="outputLabel" runat="server" ForeColor="red" Font-Size="Medium" Font-Bold="True"></asp:Label>
         </div>

            
        <br />
        <br />
        <br />
        <div class="mainContent"  style="text-align: center;">
              <div style="overflow-y: scroll; overflow-x: hidden;  width: 852px; height: 500px;">
                                <asp:GridView ID="companyListGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Height="900px" style="text-align: center; margin-top: 16px;" Width="843px">
                                    <AlternatingRowStyle BackColor="#DCDCDC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CompanyName">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                                <asp:HiddenField ID="catagoryIdHiddenField" runat="server" Value='<%#Eval("Id") %>' />
                                                <%--Hidden CatagoryId--%>
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
            <br />
        </div>

    </form>
</body>
</html>
