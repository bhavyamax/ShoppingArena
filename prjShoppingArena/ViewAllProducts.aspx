<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewAllProducts.aspx.cs" Inherits="prjShoppingArena.ViewAllProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
     <br />
     <br /><h2>Welcome to view all products</h2>

    <div class="row" style="padding-top:50px" >
        <asp:Repeater ID="rptrProducts" runat="server">
            <ItemTemplate>
        <div class="col-sm-3 col-md-3">
            <a href="ProductDetails.aspx?Pid=<%#Eval("PId")%>" style="text-decoration:none" >
            <div class="thumbnail">

                <%--<img src="Images/ProductImages/<%#Eval("PId")%>"/<%#Eval("Name")%><%#Eval("Extension")%> alt="img" />--%>

                <img src="Images/ProductImages/<%#Eval("PId")%>/<%#Eval("Name")%><%#Eval("Extension")%>" alt="img" />
                <div class="caption">

                    <div class="probrand"><%#Eval("BrandName") %></div>
                    <div class="proName"><%#Eval("PName") %></div>
                    <div class="proPrice" >
                        <span class="proOgPrice"><%#Eval("PPrice") %> </span> <%#Eval("PSelPrice") %> <span class="proPriceDiscount"><%#Eval ("DiscountAmount")  %></span>

                    </div>
                </div>

            </div>
           </div>
                </a>
</ItemTemplate>
     </asp:Repeater>
   
    </div>
</asp:Content>
