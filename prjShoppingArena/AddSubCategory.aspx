<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddSubCategory.aspx.cs" Inherits="prjShoppingArena.AddSubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class ="container ">
            <div class ="form-horizontal">
                <br /><br /><br /><br />
                <h2>Add SubCategory</h2>
                <hr />
                 <div class ="form-group">
                    <asp:Label ID="Label2" CssClass ="col-md-2 control-label " runat="server" Text="Main Category Id"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="cboCatId" CssClass="form-control"  runat="server"></asp:DropDownList>   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass ="text-danger " ErrorMessage="*Please Enter Main Category " ControlToValidate="cboCatId" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="Sub Category Name"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="txtSubCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategory" runat="server" CssClass ="text-danger " ErrorMessage="*Please Enter SubCategory Name" ControlToValidate="txtSubCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>




              


                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btnAddSubCat" CssClass ="btn btn-success " runat="server" Text="Add SubCategory" OnClick="btnAddSubCat_Click1"   />
    
                    </div>
                </div>
                </div>

           <h1>Sub Category</h1>
        <hr />

 <div class="panel panel-default">

               <div class="panel-heading"> All Categories</div>


     <asp:repeater ID="rptrCategory" runat="server">

         <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        <th>#</th>
                        <th>SubCategory</th>
                        <th>Main Category</th>
                        <th>Edit</th>

                    </tr>

                </thead>



            <tbody>
         </HeaderTemplate>


         <ItemTemplate>
             <tr>
                    <th> <%# Eval("SubCatId") %> </th>
                    <td><%# Eval("SubCatName") %>   </td>
                 <td><%# Eval("CatName" ) %>   </td>
                    <td>Edit</td>
                </tr>
         </ItemTemplate>


         <FooterTemplate>
             </tbody>

              </table>
         </FooterTemplate>

     </asp:repeater>

              
                
            

   
</div>
        </div>
</asp:Content>
