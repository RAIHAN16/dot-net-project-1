<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatagorySetupUI.aspx.cs" Inherits="StockManagementProjectApp.UI.CatagorySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Setup Catagory</title>
    <link rel="stylesheet" href="SidebarStylecopy.css" type="text/css" />
    <meta name="viewport" content="width = device-width initial-scale=1" />
    <style type="text/css">
        .mainContent {
            padding-top: 60px;
            float: left;
            padding-left: 180px;
        }

        .auto-style1 {
            width: 810px;
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
    <form id="form2" runat="server">
        <div>
            <div id="header">
                <p id="para">Setup Catagory</p>
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
            <table class="auto-style1" style="height: 152px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px; margin-left: 0px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600" Text="Catagory Name" Style="text-align: right"></asp:Label>
                    </td>

                    <td class="auto-style3">
                        <asp:TextBox ID="catagoryTextBox" runat="server" Width="293px" Height="28px" Style="margin-bottom: 2px; margin-left: 21px;"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">&nbsp;</td>

                    <td class="auto-style3">
                        <asp:Button ID="saveButton" runat="server" Text="Save" BackColor="#006699" Style="margin-left: 146px" Width="170px" Height="33px" Font-Bold="True" Font-Size="Medium" OnClick="saveButton_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="outputLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Height="30px" Width="322px" Style="margin-left: 2px; margin-top: 0px"></asp:Label>

        </div>

        <br />
        <br />
        <br />

        <div class="mainContent"  style="text-align: center;">
              <div style="overflow-y: scroll; overflow-x: hidden; width: 850px; height: 500px;">
                <asp:GridView ID="catagoryListGridView" runat="server" AutoGenerateColumns="False" style="text-align: center;" Width="843px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Height="301px">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="CatagoryName">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CatagoryName") %>'></asp:Label>
                        <asp:HiddenField ID="catagoryIdHiddenField" runat="server" Value='<%#Eval("Id") %>'/>    <%--Hidden CatagoryId--%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="catagoryUpdateLinkButton" runat="server" OnClick="catagoryUpdateLinkButton_OnClick">Update</asp:LinkButton>
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
