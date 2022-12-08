<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CreateBarcodeQueryStringValue._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtBarcode" runat="server"></asp:TextBox>
    <%--<asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="GenerateBarcode" />--%>
    <hr />
    <asp:Image ID="imgBarcode" runat="server" Visible="false" />
</asp:Content>
