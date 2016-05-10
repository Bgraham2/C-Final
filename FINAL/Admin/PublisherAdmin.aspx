<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="PublisherAdmin.aspx.cs" Inherits="FINAL.Admin.PublisherAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="PublisherAdmin">

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" Text="Publishers"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblErrors" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Existing Publishers: "></asp:Label>
        <asp:DropDownList ID="drpExistingPublishers" runat="server" DataValueField="Id" DataTextField="Name">
        </asp:DropDownList>
&nbsp;<asp:Button ID="btnEditPublisher" runat="server" OnClick="btnEditPublisher_Click" Text="Edit" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Create/Save Publisher"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Address: "></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Phone: "></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:HiddenField ID="hdnPublisherId" runat="server" />
        <br />
        <asp:Button ID="btnCreatePublisher" runat="server" OnClick="btnCreatePublisher_Click" Text="Create" />
&nbsp;<asp:Button ID="btnSavePublisher" runat="server" OnClick="btnSavePublisher_Click" Text="Save" />

    </div>
</asp:Content>
