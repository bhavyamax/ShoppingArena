<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="prjShoppingArena.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />

    <div style="padding-top:50px">
        <div class="col-md-5" >
            <div style="max-width:480px" class="thumbnail" >
               <%-- for slider--%>


              <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
        <li data-target="#carousel-example-generic" data-slide-to="3"></li>
        <li data-target="#carousel-example-generic" data-slide-to="4"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
      <asp:Repeater ID="rptrImage" runat="server">
          <ItemTemplate >
    <div class="item <%# GetActiveImgClass(Container.ItemIndex) %>">
      <img src="Images/ProductImages/<%#Eval("PId")%>/<%#Eval("Name")%><%#Eval("Extension")%>" alt="img">
    
    </div>
              </ItemTemplate>
          </asp:Repeater>
<%--    <div class="item">
      <img src="Images/ae-2.jpeg" alt="...">
      <div class="carousel-caption">
        02
      </div>
    </div>

        <div class="item">
      <img src="Images/ae-3.jpeg" alt="...">
      <div class="carousel-caption">
        03
      </div>
    </div>

        <div class="item">
      <img src="Images/ae-4.jpeg" alt="...">
      <div class="carousel-caption">
        04
      </div>
    </div>

        <div class="item">
      <img src="Images/ae-5.jpeg" alt="...">
      <div class="carousel-caption">
        05
      </div>
    </div>--%>
    ...
  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
            </div>

        </div>
        <div class="col-md-5">
            <asp:Repeater ID="rptrDetails" runat="server" OnItemCommand="rptrDetails_ItemCommand" OnItemDataBound="rptrDetails_ItemDataBound">
                <ItemTemplate >
            <div class="divDet1">
            <h1 class="proNameView" ><%# Eval("PName") %></h1>
            <span class="proOgPrice"><%# Eval("PPrice") %></span><span class="proPriceDiscount" >Off $ <%# string.Format("{0}",Convert.ToInt64(Eval("PPrice"))-Convert.ToInt64(Eval("PSelPrice"))) %></span>
            <p class="proPriceView"><%# Eval("PSelPrice") %></p>
                </div>
             <div >

                 <h5 class="h5size" >SIZE</h5>
                 <div>
                     <asp:RadioButtonList  ID="radSizes" runat="server" RepeatDirection="Horizontal" >
                             
                     </asp:RadioButtonList>

                 </div>
             </div>
              <div class="divDet1">

                  <asp:Button ID="btnAddtoCart" OnClick="btnAddtoCart_Click" CssClass="mainButton" runat="server" Text="Add To Cart" />
                   <asp:Label ID="lblError" CssClass ="text-danger " runat="server" ></asp:Label>
             </div>
              <div class="divDet1">

                 <h5 class="h5size" >Description</h5>
                  <p><%# Eval("PDescription") %></p>
             <h5 class="h5size">Product Details</h5>
                  <p><%# Eval("PDetails") %></p>
              
              <h5 class="h5size" >Material & Care</h5>
                  <p><%# Eval("PMaterial") %></p>
              </div>

            <div >
               <p><%# ((int)Eval("FreeDelivery")==1)? "Free Delivery":""  %>    </p>
                <p><%# ((int)Eval("Return30Days")==1)? "30 Days Returns":""  %></p>
                <p><%# ((int)Eval("COD")==1)? "Cash on Delivery":"" %></p>
            </div>
                    <asp:HiddenField ID="hfCatID" Value='<%# Eval("PCategoryId") %>' runat="server" />
                      <asp:HiddenField ID="hfSubCatID" Value='<%# Eval("PSubCatId") %>' runat="server" />
                      <asp:HiddenField ID="hfGenderID" Value='<%# Eval("PGender") %>' runat="server" />
                      <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandId") %>' runat="server" />

                    </ItemTemplate>
                </asp:Repeater>
        </div>
        </div>
</asp:Content>
