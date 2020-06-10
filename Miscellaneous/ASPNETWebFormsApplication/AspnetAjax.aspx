<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AspnetAjax.aspx.cs" Inherits="ASPNETWebFormsApplication.AspnetAjax" Title="Ajax calls" MasterPageFile="~/Site.Master"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <asp:Button ID="Button1" runat="server" Text="load text" OnClick="Button1_Click" />||||||||
    <asp:Button ID="Button2" runat="server" Text="clear" OnClick="Button2_Click" /><br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

</ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>