<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="AuthorAdmin.aspx.cs" Inherits="FINAL.Admin.AuthorAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="AuthorAdmin">

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Author Admin"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblErrors" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Existing Authors: "></asp:Label>
        <asp:DropDownList ID="drpExistingAuthors" runat="server" DataValueField="Id" DataTextField="Name">
        </asp:DropDownList>
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Create/Save Author"></asp:Label>
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
        <asp:HiddenField ID="hdnAuthorId" runat="server" />
        <br />
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
&nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />

    </div>
</asp:Content>
