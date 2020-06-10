<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBoundCodeSnippets.aspx.cs" Inherits="ASPNETWebFormsApplication.DataBoundCodeSnippets" MasterPageFile="~/Site.Master" Title="Looking into DataBounding" %>
<%--<%@ Register Namespace="ASPNETWebFormsApplication" Assembly="ASPNETWebFormsApplication" tagPrefix="ajax" %>--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--(1)-->
    <div class="container py-4">
        <div style="text-align: center">
            <table id="productTable" class="table table-striped table-hover table-bordered table-responsive">
                <thead>
                    <tr>
                        <th>Product ID</th>
                        <th>Product Name</th>
                        <th>Description</th>
                        <th>Image Path</th>
                        <th>Unit Price</th>
                        <th>Category ID</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="DataBoundCodeSnippetsId" ItemType="ASPNETWebFormsApplication.Models.Product" runat="server"
                        SelectedMethod="GetProducts" DataKeyNames="ProductID">
                        <ItemTemplate>
                            <tr>
                                <td><span class="text-primary"></span><%#: Item.ProductID %></td>
                                <td><span class="text-info"><%#: Item.ProductName %></span></td>
                                <td><span class="text-warning"><%#: Item.Description %></span></td>
                                <td><span class="text-danger"><%#: Item.ImagePath %></span></td>
                                <td><span class="text-success"><%#: Item.UnitPrice %></span></td>
                                <td><span class="text-mute"><%#: Item.CategoryID %></span></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </tbody>
                <tfoot>
                    <tr>
                        <th>Product ID</th>
                        <th>Product Name</th>
                        <th>Description</th>
                        <th>Image Path</th>
                        <th>Unit Price</th>
                        <th>Category ID</th>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>

    <!--(2)-->
    <asp:EntityDataSource ID="EDS_ProductsByCategory" runat="server" EnableFlattening="False" AutoGenerateWhereClause="True" ConnectionString="Data Source=.;Initial Catalog=liblogistics;Integrated Security=True" DefaultContainerName="customer" EntitySetName="customer">
        <WhereParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

    <!--(3)-->

</asp:Content>