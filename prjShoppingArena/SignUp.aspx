<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="prjShoppingArena.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
      <meta http-equiv="X-UA-Compatible" content="IE-edge"/>
    <link href="css/custom.css" rel="stylesheet" />
    <%-- using bootstrap3--%>
       <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
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

                       
                        <li class="active" ><a href="SignUp.aspx">Sign Up</a> </li>
                        <li><a href="SignIn.aspx">Sign In</a> </li>
                    </ul>

                </div>
            </div>

        </div> <!--navigation finished-->

        </div>

        <!-- signup page -->
        <div class="center-page">
            <label class="col-xs-11 col-md-11 " >UserName : </label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtUname" CssClass="form-control" placeholder="Enter Your Name"  runat="server"></asp:TextBox>
                </div>

              <label class="col-xs-11">Password:</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your password"></asp:TextBox>
            </div>


                <label class="col-xs-11">Confirm Password:</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtCPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Confirm password"></asp:TextBox>
            </div>


             <label class="col-xs-11">Your Full Name:</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtName" runat="server" Class="form-control" placeholder="Enter Your Name"></asp:TextBox>
            </div>

              <label class="col-xs-11">Email:</label>
            <div class="col-xs-11">
            <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Enter Your Email"></asp:TextBox>
            </div>
            <br />

                <label class="col-xs-11"></label>
             <div class="col-xs-11">
                 <asp:Button ID="BtnSignup" Class="btn btn-success" runat="server" Text="SignUP" OnClick="BtnSignup_Click"  />
     
                 <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
     
            </div>
      

        </div>

        <!-- Signup page -->

          <footer class="foot">
           

                 <div class ="container ">
                <p class ="pull-right "><a href ="#">Back to top</a></p>
                <p>&copy;2021 ShopArena &middot; <a href ="Default.aspx">Home</a>&middot;<a href ="#">About</a>&middot;<a href ="#">Contact</a>&middot;<a href ="#">Products</a> </p>
            </div>
            

        </footer>
    </form>
</body>
</html>
