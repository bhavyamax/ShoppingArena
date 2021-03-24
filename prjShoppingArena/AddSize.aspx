<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddSize.aspx.cs" Inherits="prjShoppingArena.AddSize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class ="container ">
            <div class ="form-horizontal">
                <br /><br /><br /><br />
                <h2>Add Size</h2>
                <hr />

                     <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="Size Name"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="txtSize" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtSize" runat="server" CssClass ="text-danger " ErrorMessage="*Please Enter Size" ControlToValidate="txtSize" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                
                 <div class ="form-group">
                    <asp:Label ID="Label3" CssClass ="col-md-2 control-label " runat="server" Text="Brand"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="cboBrand" CssClass="form-control"  runat="server"></asp:DropDownList>   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" runat="server" CssClass ="text-danger " ErrorMessage="*Please Enter Brand" ControlToValidate="cboBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class ="form-group">
                    <asp:Label ID="Label2" CssClass ="col-md-2 control-label " runat="server" Text="Category"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="cboCategory" CssClass="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboCategory_SelectedIndexChanged"></asp:DropDownList>   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass ="text-danger " ErrorMessage="*Please Enter Category " ControlToValidate="cboCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

           

                        <div class ="form-group">
                    <asp:Label ID="Label4" CssClass ="col-md-2 control-label " runat="server" Text="Sub Category"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="cboSubCategory" CssClass="form-control"  runat="server" OnSelectedIndexChanged="cboSubCategory_SelectedIndexChanged"></asp:DropDownList>   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcboSubCategory" runat="server" CssClass ="text-danger " ErrorMessage="*Please Enter Sub Category " ControlToValidate="cboSubCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class ="form-group">
                    <asp:Label ID="Label5" CssClass ="col-md-2 control-label " runat="server" Text="Gender"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="cboGender" CssClass="form-control"  runat="server"></asp:DropDownList>   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" CssClass ="text-danger " ErrorMessage="*Please Enter Gender " ControlToValidate="cboGender" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>



                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btnSize" CssClass ="btn btn-success " runat="server" Text="Add Size" OnClick="btnAddSubCat_Click"  />
    
                    </div>
                </div>
                </div>
                     <h1>All Sizes</h1>
        <hr />

  <div class="panel panel-default">

               <div class="panel-heading"> All Sizes</div>


     <asp:repeater ID="rptrSize" runat="server">

         <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        <th>#</th>
                        <th>Size</th>
                        <th>Brand</th>
                        <th>Category</th>
                         <th>Sub Category</th>
                         <th>Gender</th>
                        <th>Edit</th>

                    </tr>

                </thead>



            <tbody>
         </HeaderTemplate>


         <ItemTemplate>
             <tr>
                    <th> <%# Eval("SizeID") %> </th>
                    <td><%# Eval("SizeName") %>   </td>
                  <td><%# Eval("Name") %>   </td>
                  <td><%# Eval("CatName") %>   </td>
                   <td><%# Eval("SubCatName") %>   </td>
                   <td><%# Eval("GenderName") %>   </td>
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
