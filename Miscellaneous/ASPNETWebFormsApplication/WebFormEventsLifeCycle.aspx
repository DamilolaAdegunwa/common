<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEventsLifeCycle.aspx.cs" Inherits="ASPNETWebFormsApplication.WebFormEventsLifeCycle" MasterPageFile="~/Site.Master" Title="ASP.NET WebForm Events Life Cycle" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="lblName" OnClick="btnSubmit_Click" Text="See this button" CssClass="btn btn-success" runat="server"/>
</asp:Content>