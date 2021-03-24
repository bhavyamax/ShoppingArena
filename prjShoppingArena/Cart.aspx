<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="prjShoppingArena.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <div style="padding-top:50px">

        <div class="col-md-9" >
            <h3 class="proNameViewCart" runat="server" id="numItems" ></h3>
            <asp:Repeater ID="rptrCartProducts" runat="server">
                <ItemTemplate>


          <%--      cart details--%>
            <div class="media" style="border:1px solid black">
                <div class="media-left">
                    <a href="ProductDetails.aspx?Pid=<%#Eval("PId")%>" target="_blank" >

                        <img class="media-object" width="100px" src="Images/ProductImages/<%#Eval("PId")%>/<%#Eval("Name")%><%#Eval("Extension")%>" alt="img" />
                    </a>
                </div>
                <div class="media-body">

                    <h4 class="media-heading proNameViewCart"><%# Eval("PName") %></h4>
                    <p class="proPriceDiscountView" >Size : <%# Eval("SizeNamee") %></p>
                    <span class="proPriceView" ><%# Eval("PSelPrice") %></span>
                    <span class="proOgPriceView" ><%# Eval("PPrice") %></span>
                    <p>
                    <asp:Button CommandArgument='<%#Eval("PID")+"-"+ Eval("SizeIDD")%>' ID="btnRemoveCart"  CssClass="RemoveButton1" runat="server" Text="Remove" OnClick="btnRemoveCart_Click" />
                </p>
                        </div>

            </div>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
        <div class="col-md-3" runat="server" id="divpricedetails" >

            <div>
                <h5>PRICE DETAILS</h5>

            <div>   
                <label>Cart Total</label>
            <span class="pull-right priceGray" runat="server"  id="spanCartTotal" ></span>
                </div>

              <div>
            <label>Cart Discount</label>
            <span class="pull-right priceGreen" runat="server" id="spanDiscount"  > </span>
        </div>


        </div>

            <div class="proPriceView" > 
                <label>Cart Total</label>
            <span class="pull-right priceGreen" runat="server" id="spanTotal" > </span>

            </div>
            <div>
                   <asp:Button ID="btnBuy"  CssClass="buyNowbtn" runat="server" Text="Buy Now" OnClick="btnBuy_Click" />

            </div>
      </div>

    </div>
</asp:Content>
