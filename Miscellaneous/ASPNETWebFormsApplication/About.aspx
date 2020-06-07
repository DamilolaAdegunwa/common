<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ASPNETWebFormsApplication.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div id="CategoryMenu" style="text-align: center">
        <asp:ListView ID="categoryList"
        ItemType="System.String"
        runat="server"
        OnItemCommand="Menu_ItemCommand" OnItemDataBound="Menu_ItemDataBound"
        SelectMethod="GetNames" >
        <ItemTemplate>
            <b style="font-size: large; font-style: normal">
            <%#: Item %>
            </b>
            <%if(true){ %>
            <% ViewState["ActionHeader"] = "hello, my people"; %>
            <span><%=ViewState["ActionHeader"] %></span>
            <%} %>
            <%else{ %>
                <span>never mind</span>
            <%} %>
            <asp:LinkButton ID="someBtn" CommandName="category" CommandArgument="cat1" CssClass="btn btn-primary" ToolTip="some action button!" runat="server">
                <span>Press This!</span>
            </asp:LinkButton>
        </ItemTemplate>
        <ItemSeparatorTemplate> | </ItemSeparatorTemplate>
        </asp:ListView>
    </div>--%>
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
                    OnItemCommand="Menu_ItemCommand" OnItemDataBound="Menu_ItemDataBound" SelectedMethod="GetProducts">
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
                    <ItemSeparatorTemplate></ItemSeparatorTemplate>
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
