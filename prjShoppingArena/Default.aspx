<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="prjShoppingArena.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Arena</title>
    <meta charset="utf-8" />
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous">


    </script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
      <meta http-equiv="X-UA-Compatible" content="IE-edge"/>
    <link href="css/custom.css" rel="stylesheet" />
   <%-- using bootstrap3--%>
       <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script>

        $(document).ready(function myfunction() {

            $("#btnCart").click(function myfunction() {
                window.location.href = "Cart.aspx";
            });
        });
    </script>
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
                        <li class="active" > <a href="Default.aspx">Home</a></li>
                        <li><a href="AboutUs.aspx">About</a></li>
                        <li><a href="#">Contact Us</a></li>
                        <li><a href="#">Blog</a></li>
                        <li class="dropdown">

                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b> </a>
                            <ul class="dropdown-menu">
                                 <li><a href="ViewAllProducts.aspx">All Products</a>  </li>
                                <li role="separator" class="divider"></li> 
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
                        <li>
                         <button id="btnCart" class="btn btn-primary navbar-btn " type="button">
                                Cart <span class="badge " id="pCount" runat="server"></span>

                            </button></li>
                        <li id="btnSignUP" runat="server" ><a href="SignUp.aspx">Sign Up</a> </li>
                        <li  id="btnSignIN" runat="server" ><a href="SignIn.aspx">Sign In</a> </li>
                        <li> <asp:Button ID="btnLogout" CssClass="btn btn-default navbar-btn" runat="server" Text="Sign Out" OnClick="btnLogout_Click" /></li>
                    </ul>

                </div>
            </div>

        </div>  <%--navigation finished--%>


<%--             image slider open--%>

             <div class="container ">
  <h2>Carousel Example</h2>  
  <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">
      <div class="item active">
        <img src="ImgSlider/slider1.jpg" alt="Los Angeles" style="width:100%; height:251px">
           <div class="carousel-caption">
        <h3 style="color:black;" >Women Shopping</h3>
        <p style="color:black;">Get 30% off</p>
               <p><a class="btn btn-lg btn-primary" href="#" role="button" >Buy Now</a> </p>

      </div>
      </div>

      <div class="item">
        <img src="ImgSlider/slider2.jpg" alt="Chicago" style="width:100%; height:251px">
              <div class="carousel-caption">
          <h3 style="color:black;" >Shop Online</h3>
        <p style="color:black;">Get Excited Offers</p>
      </div>
      </div>
    
      <div class="item">
        <img src="ImgSlider/slider3.jpg" alt="New york" style="width:100%; height:251px">
              <div class="carousel-caption">
      <h3>Shop </h3>
        <p>Get 20% off</p>
      </div>
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
</div>
             
<%--             image slider finished--%>


</div>
            <hr />         
<%-- Middle Container --%>
        <div class="container center">

            <div class="row">

                <div class="col-lg-4">
                    <img class="img-circle" src="Images/iphone11.jpeg" alt="img" width="140" height="140" />
                    <h2>Mobiles</h2>
                    <p>5G speed. A14 Bionic, the fastest chip in a smartphone.
An edge-to-edge OLED display. Ceramic Shield with four times better drop performance. And Night mode on every camera. iPhone 12 has it all — in two perfect sizes.</p>
                    <p> <a class="btn btn-default " href="#" role="button" >View More &raquo; </a>  </p>
                </div>

                   <div class="col-lg-4">
                    <img class="img-circle" src="Images/shoes.jpeg" alt="img" width="140" height="140" />
                    <h2>Footwear</h2>
                    <p>5G speed. A14 Bionic, the fastest chip in a smartphone.
An edge-to-edge OLED display. Ceramic Shield with four times better drop performance. And Night mode on every camera. iPhone 12 has it all — in two perfect sizes.</p>
                    <p> <a class="btn btn-default " href="#" role="button" >View More &raquo; </a>  </p>
                </div>


                   <div class="col-lg-4">
                    <img class="img-circle" src="Images/tshirt.jpeg" alt="img" width="140" height="140" />
                    <h2>Mobiles</h2>
                    <p>5G speed. A14 Bionic, the fastest chip in a smartphone.
An edge-to-edge OLED display. Ceramic Shield with four times better drop performance. And Night mode on every camera. iPhone 12 has it all — in two perfect sizes.</p>
                    <p> <a class="btn btn-default " href="#" role="button" >View More &raquo; </a>  </p>
                </div>

            </div>
        </div>


        <%-- Middle Container ends --%>


        <footer>
           

                 <div class ="container ">
                <p class ="pull-right "><a href ="#">Back to top</a></p>
                <p>&copy;2020 ShopArena &middot; <a href ="Default.aspx">Home</a>&middot;<a href ="#">About</a>&middot;<a href ="#">Contact</a>&middot;<a href ="#">Products</a> </p>
            </div>
            

        </footer>
    </form>
   

</body>
</html>
