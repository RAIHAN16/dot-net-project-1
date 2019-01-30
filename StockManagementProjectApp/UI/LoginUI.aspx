<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="StockManagementProjectApp.UI.LoginUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Here</title>
     <link href="login.css" runat="server" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 15px;
        }
        </style>
</head>
<body  background="images/bg-login.jpg">
  
 <form id="form1" runat="server">
      <div class="banner">
        
        <img src="images/HEAD.png" width="100%" height="100%" />
      </div>
    <center>
    <div  >
          </br>  </br>  </br>  </br>
        <asp:Label ID="Label1" runat="server" Text="User Name  : "  ForeColor="Blue" Font-Size="Large"></asp:Label>
        
        <asp:TextBox ID="userNameTextBox" runat="server" Height="20px" Width="175px"></asp:TextBox>
        
         </br>  </br>
         <asp:Label ID="Label2" runat="server" Text="Password  :  "   ForeColor="Blue" Font-Size="Large"></asp:Label>

          &nbsp;&nbsp;

          <asp:TextBox ID="passwordTextBox" runat="server" Height="20px" Width="175px"></asp:TextBox>
           </br>  </br>
         <asp:Label ID="LoginOutputLabel" runat="server" ForeColor="#0033cc"></asp:Label>
         
       
        </br>  </br>
        <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />
    </div>


          </br>  </br>  </br>  </br>  </br>  </br>  </br>  </br>  </br>  </br>  </br>  </br>  </br>  </br>

          <asp:Label ID="Label3" runat="server" Text="Developed By Al Sabit , Jahedul Islam , Riya Pal , Raihan Bin Yusuf" ForeColor="Blue" Font Font-Size="Large"
                     fornt Font-Names ="Agency FB">
                    
                 </asp:Label>
        </center>

    </form>
</body>
</html>
