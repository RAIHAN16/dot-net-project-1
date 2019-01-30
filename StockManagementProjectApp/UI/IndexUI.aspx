<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="StockManagementProjectApp.UI.IndexUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Management System</title>
    <meta name="viewport" content="width = device-width initial-scale = 1"/>
    <link rel="stylesheet" href="IndexStylecopy.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <div id = "header">
			<ul id = "navbar">
				<li><a href="IndexUI.aspx">Home</a></li>
				<li><a href="#">About us</a></li>
				<li><a href="#">Contuct</a></li>
				<li><a href="LoginUI.aspx">Log Out</a></li>
			</ul>
		</div>
		<div>
			<ul id="contents">
				<li><a href="CatagorySetupUI.aspx">Setup Catagory</a></li>
				<li><a href="CompanySetupUI.aspx">Setup Company</a></li>
				<li><a href="ItemSetupUI.aspx">Setup Item</a></li>
				<li><a href="StockIn.aspx">Stock In</a></li>
				<li><a href="StockOutUI.aspx">Stock Out<</a></li>
				<li><a href="SearchAndViewUI.aspx">Search and view Item Summery</a></li>
				<li><a href="ViewSalesBetweenTwoDatesUI.aspx">View Sales Between Two Dates</a></li>
			</ul>
        </div>
    </form>
</body>
</html>
