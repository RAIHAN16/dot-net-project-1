<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUI.aspx.cs" Inherits="StockManagementProjectApp.UI.ShowUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WelCome To Our Site</title>
    <link href="login.css" runat="server" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 15px;
        }
        .auto-style1 {
            height: 86px;
        }
        .auto-style2 {
            height: 193px;
        }
    </style>
</head>
<body background="images/bg-login.jpg">
  <form id="form1" runat="server">
  
    <div class="banner"
         style="background-image: url('C:\Users\Al Sabit\Desktop/pattern.png')">

   
        <img src="images/HEAD.png" width="100%" height="100%" />
    </div>

 <center style="height: 138px">
    <table style="width: 100%;" >
        <tr>
                <td align="center" class="auto-style1">
                <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl="LoginUI.aspx" Font-Bold="True" Font-Size="25px">ENTER</asp:HyperLink>
                </td>
            
        </tr>
        <tr>
            
            <td align="center" class="auto-style2">
              <div class="login" 
                     style=" border: thin dotted #FFFFFF; background-position: center; line-height: normal; color: #FF0000; background-image: none; background-repeat: no-repeat; height: 173px;">
                    <asp:Label ID="Label2" runat="server" Text=" DEVELOPED "></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="BY"></asp:Label>
                    <br />
                     <br />
                    <asp:Label ID="Label3" runat="server" Text="Al Sabit"  ForeColor="Blue" Font Font-Size="Large"></asp:Label>
                   <br />
                    <asp:Label ID="Label4" runat="server" Text="Jahedul Hoque"  ForeColor="Blue" Font Font-Size="Large"></asp:Label>
                   <br />
                    <asp:Label ID="Label5" runat="server" Text="Riya Pal"  ForeColor="Blue" Font Font-Size="Large"></asp:Label>
                   <br />
                    <asp:Label ID="Label6" runat="server" Text="Raihan Bin Yusuf"  ForeColor="Blue" Font Font-Size="Large"></asp:Label>
                    
                  </div>
            </td>
        </tr>
        <tr>
           
            <td align="center">
                 
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                 <asp:Label ID="Label1" runat="server" Text="Developed By Al Sabit , Jahedul Hoque , Riya Pal , Raihan Bin Yusuf" ForeColor="Blue" Font Font-Size="Large"
                     fornt Font-Names ="Agency FB">
                    
                 </asp:Label>
                <br />
                 
            </td>
        </tr>
    </table>
 
    </center>
    
    
   
 </form>
    </body>
</html>
