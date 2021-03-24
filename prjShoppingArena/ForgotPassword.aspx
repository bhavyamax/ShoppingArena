<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="prjShoppingArena.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>

     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
      <meta http-equiv="X-UA-Compatible" content="IE-edge"/>
    <link href="css/custom.css" rel="stylesheet" />
        <%-- using bootstrap3--%>
       <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                     <%-- 3 dots come when screen size reduce --%>
     <div class ="navbar navbar-default navbar-fixed-top" role ="navigation">
            <div class ="container ">
                <div class ="navbar-header">
                    <button type="button" class ="navbar-toggle " data-toggle="collapse" data-target=".navbar-collapse">
                        <span class ="sr-only">Toggle navigation</span>
                        <span class ="icon-bar"></span>
                        <span class ="icon-bar"></span>
                        <span class ="icon-bar"></span>

                    </button>
                    <a class="navbar-brand" href="Default.aspx"> <span> <img src="icons/shoplogo.png" alt="img" height="30" /></span> Shopping Arena </a> 
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li  > <a href="Default.aspx">Home</a></li>
                        <li><a href="#">About</a></li>
                        <li><a href="#">Contact Us</a></li>
                        <li><a href="#">Blog</a></li>
                        <li class="dropdown">

                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b> </a>
                            <ul class="dropdown-menu">

                                <li class="dropdown-header" > <a href="#"></a>Men</li>
                                <li role="separator" class="divider"></li>
                                <li><a href="#">Shirts</a>  </li>
                                  <li><a href="#">Pants</a>  </li>
                                  <li><a href="#">Denims</a>  </li>
                                 <li role="separator" class="divider"></li>
                                 <li class="dropdown-header" > <a href="#"></a>Women</li>
                                  <li role="separator" class="divider"></li>
                                <li><a href="#">Shirts</a>  </li>
                                  <li><a href="#">Pants</a>  </li>
                                  <li><a href="#">Denims</a>  </li>
                            </ul>

                        </li>

                      
                        <li ><a href="SignIn.aspx">Sign In</a> </li>
                    </ul>

                </div>
            </div>

        </div>  <%--navigation finished--%>

            <div class="container">

               <div class="form-horizontal" >
                   <h2>Recover Password</h2>
                   <hr />

                    <h3>Please Enter Your Email Address, we will send you the recovery link for your password!</h3>

                    <div class ="form-group">
                    <asp:Label ID="lblEmail" CssClass ="col-md-2 control-label" runat="server" Text="Email Address"></asp:Label>
                    <div class ="col-md-3">
                        <asp:TextBox ID="txtEmailID" CssClass =" form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" CssClass ="Text-danger" runat="server" ErrorMessage="Enter Your Email" ControlToValidate="txtEmailID" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
               </div>

                    <div class ="form-group">
                    <div class ="col-md-2">   </div>

                    <div class ="col-md-6">
                        <asp:Button ID="btnResetPass" CssClass ="btn btn-default" runat="server" Text="Send" OnClick="btnResetPass_Click" />
                   <asp:Label ID="lblResetPassMsg" CssClass ="text-success " runat="server" ></asp:Label>
                         </div>
                </div>
            </div>
            </div>
            </div>
    </form>


    
           <footer class="foot">
           

                 <div class ="container ">
                <p class ="pull-right "><a href ="#">Back to top</a></p>
                <p>&copy;2021 ShopArena &middot; <a href ="Default.aspx">Home</a>&middot;<a href ="#">About</a>&middot;<a href ="#">Contact</a>&middot;<a href ="#">Products</a> </p>
            </div>
            

        </footer>
</body>
</html>
