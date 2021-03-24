<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="prjShoppingArena.Add_Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="form-horizontal">
            <br /><br /><br />
            <h2>Add Product</h2>
            <hr />

            
           <div class ="form-group">
               <asp:Label ID="Label1" runat="server" CssClass ="col-md-2 control-label" Text="Proudct Name"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtProductName" CssClass ="form-control" runat="server"></asp:TextBox>


               </div>
           </div>
                       <div class ="form-group">
               <asp:Label ID="Label2" runat="server" CssClass ="col-md-2 control-label" Text="Price"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtPrice" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="Label3" runat="server" CssClass ="col-md-2 control-label" Text="SellingPrice"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtsellPrice" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="Label4" runat="server" CssClass ="col-md-2 control-label" Text="Brand"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="cboBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
               </div>
           </div>



           <div class ="form-group">
               <asp:Label ID="Label5" runat="server" CssClass ="col-md-2 control-label" Text="Category"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="cboCategory" CssClass ="form-control"   runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboCategory_SelectedIndexChanged" ></asp:DropDownList>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="Label6" runat="server" CssClass ="col-md-2 control-label" Text="SubCategory"></asp:Label>
               <div class ="col-md-3">

                        <asp:DropDownList ID="cboSubCategory" CssClass="form-control"  runat="server" OnSelectedIndexChanged="cboSubCategory_SelectedIndexChanged" AutoPostBack="True" CausesValidation="True"></asp:DropDownList>   
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label19" runat="server" CssClass ="col-md-2 control-label" Text="Gender"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="cboGender" CssClass ="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboGender_SelectedIndexChanged" ></asp:DropDownList>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label7" runat="server" CssClass ="col-md-2 control-label" Text="Size"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBoxList ID="lstSize" CssClass ="form-control" RepeatDirection="Horizontal"  runat="server"></asp:CheckBoxList>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label20" runat="server" CssClass ="col-md-2 col-md-2 control-label" Text="Quantity"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtQuantity" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label8" runat="server" CssClass ="col-md-2 control-label" Text="Description"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtDescription" TextMode ="MultiLine"  CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label9" runat="server" CssClass ="col-md-2 control-label" Text="Product Details"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtPDetail" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

           
            <div class ="form-group">
               <asp:Label ID="Label10" runat="server" CssClass ="col-md-2 control-label" Text="Materials and Care"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtMatCare" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label11" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="uploadImg01" CssClass ="form-control" runat="server" />
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label12" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="uploadImg02" CssClass ="form-control" runat="server" />
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label13" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="uploadImg03" CssClass ="form-control" runat="server" />
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label14" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="uploadImg04" CssClass ="form-control" runat="server" />
               </div>
           </div>



            <div class ="form-group">
               <asp:Label ID="Label15" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="uploadImg05" CssClass ="form-control" runat="server" />
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label16" runat="server" CssClass ="col-md-2 control-label" Text="Free Delivery"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="chkFDelivery" runat="server" />
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label17" runat="server" CssClass ="col-md-2 control-label" Text="30 Days Return"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="chkReturn" runat="server" />
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label18" runat="server" CssClass ="col-md-2 control-label" Text="COD"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="chkCod" runat="server" />
               </div>
           </div>


           <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btnAdd" CssClass ="btn btn-success " runat="server" Text="ADD Product" OnClick="btnAdd_Click"   />
                        
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                        
                    </div>
                </div>
            <br />

        </div>

    </div>
</asp:Content>
