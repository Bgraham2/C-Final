<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="CheckedOutItemAdmin.aspx.cs" Inherits="FINAL.Admin.CheckedOutItemAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CheckedOutItemAdmin">

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Overdue Items"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvOverDue" runat="server">
            <HeaderStyle BackColor="#0099FF" />
        </asp:GridView>

    </div>
</asp:Content>
