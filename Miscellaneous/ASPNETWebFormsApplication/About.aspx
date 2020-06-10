<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ASPNETWebFormsApplication.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Button to Open the Modal -->
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
      Open modal
    </button>
    <!-- The Modal -->
    <div class="modal" id="myModal">
      <div class="modal-dialog">
        <div class="modal-content">

          <!-- Modal Header -->
          <div class="modal-header">
            <h4 class="modal-title">Modal Heading</h4>
            <button type="button" class="close" data-dismiss="modal">&times;</button>
          </div>

          <!-- Modal body -->
          <div class="modal-body">
            Modal body..
          </div>

          <!-- Modal footer -->
          <div class="modal-footer">
            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
          </div>

        </div>
      </div>
    </div>

    <!--Different examples especially on Data-bound web server control to various data sources-->
    <!--(1) Basic/Standard implementation of ListView -->
    <div id="productListItemDiv" style="text-align: center">
        <table id="productTable" class="table table-striped table-hover table-bordered table-responsive">
            <thead>
                <tr>
                    <th>S/N</th>
                    <th>Product ID</th>
                    <th>Product Name</th>
                    <th>Description</th>
                    <th>Image Path</th>
                    <th>Unit Price</th>
                    <th>Category ID</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <asp:ListView ID="productListView" ItemType="ASPNETWebFormsApplication.Models.Product" runat="server" 
                    OnItemCommand="Menu_ItemCommand" OnItemDataBound="Menu_ItemDataBound" SelectedMethod="GetProducts"
                    DataKeyNames="ProductID">
                    <ItemTemplate>
                        <tr>
                            <td><span class=""></span><%#: Item.Index %></td>
                            <td><span class="text-primary"></span><%#: Item.ProductID %></td>
                            <td><span class="text-info"><%#: Item.ProductName %></span></td>
                            <td><span class="text-warning"><%#: Item.Description %></span></td>
                            <td><span class="text-danger"><%#: Item.ImagePath %></span></td>
                            <td><span class="text-success"><%#: Item.UnitPrice %></span></td>
                            <td><span class="text-mute"><%#: Item.CategoryID %></span></td>
                            <td>
                                <asp:LinkButton ID="someBtn" CommandName="category" CommandArgument="cat1" CssClass="btn btn-primary" ToolTip="some action button!" runat="server"><span>Press This!</span></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </tbody>
            <tfoot>
                <tr>
                    <th>S/N</th>
                    <th>Product ID</th>
                    <th>Product Name</th>
                    <th>Description</th>
                    <th>Image Path</th>
                    <th>Unit Price</th>
                    <th>Category ID</th>
                    <th>Action</th>
                </tr>
            </tfoot>
        </table>
    </div>

    <!--(2) implementation of ListView using a sql data source-->
    <table id="sqltable" class="table table-striped table-hover table-bordered table-responsive">
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="LabelAccountType" runat="server" Text='<%#Bind("name") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelCreatedBy" runat="server" Text='<%#Bind("isActive") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelCreatedDate" runat="server" Text='<%#Bind("DateCreated") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelIsPickedUp" runat="server" Text='<%#Bind("DateModified") %>'></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:libmot %>"
        SelectCommand="SELECT * FROM [Zone]">
    </asp:SqlDataSource>
    
    <!--(3) implementation of ListView using a sql data source & layout Template-->
    <asp:ListView ID="customer" runat="server" DataSourceID="SqlDataSource2">
        <LayoutTemplate>
            <table id="custTable" class="table table-striped table-hover table-bordered table-responsive">
                <tr>
                    <th>[firstName]</th>
                    <th>[lastName]</th>
                    <th>[phoneNumber]</th>
                </tr>
                <%--<tr id="ItemPlaceholder" runat="server"></tr>--%>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                <tr id="myPagerRow" runat="server"> 
                    <td id="myPager" runat="server" colspan="3"> 
                        <asp:DataPager ID="CustomerDataPager" runat="server" PageSize="5"> 
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" /> 
                                <asp:NumericPagerField /> 
                                <asp:NextPreviousPagerField ButtonType="Link" /> 
                            </Fields>
                        </asp:DataPager> 
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="LabelAccountType" runat="server" Text='<%#Eval("firstName") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelCreatedBy" runat="server" Text='<%#Bind("lastName") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelCreatedDate" runat="server" Text='<%#Bind("phoneNumber") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
        ConnectionString="<%$ ConnectionStrings:libmot %>"
        SelectCommand="SELECT * FROM [customer]">
    </asp:SqlDataSource>

    <!--(4)-->
    <h4><b>Details View</b></h4>
    <asp:DetailsView ID="DetailsView1" AllowPaging="true" AutoGenerateRows="false" CssClass="table table-bordered" runat="server"  DataSourceID="SqlDataSource2"> 
        <%--OnPageIndexChanging="DetailsView1_PageIndexChanging"--%>
        <Fields>  
            <asp:BoundField DataField="firstName" HeaderText="First Name" />  
            <asp:BoundField DataField="lastName" HeaderText="Last Name" />  
            <asp:BoundField DataField="phoneNumber" HeaderText="Phone Number" /> 
        </Fields>  
    </asp:DetailsView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottomscripts" runat="server">
    <script>
        function openModal() {
            $('#myModal').modal('show');
        }
        $('#myModal').on('shown.bs.modal', function () {
            $(document).off('focusin.modal');
        });
    </script>
</asp:Content>
