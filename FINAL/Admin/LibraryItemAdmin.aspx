<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="LibraryItemAdmin.aspx.cs" Inherits="FINAL.Admin.LibraryItemAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="LibraryItemAdmin">

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Library Items"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblErrors" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Existing Library Item: "></asp:Label>
        <asp:DropDownList ID="drpLibraryItems" runat="server" DataValueField="Id" DataTextField="Title">
        </asp:DropDownList>
&nbsp;<asp:Button ID="btnEditLibraryItems" runat="server" OnClick="btnEditLibraryItems_Click" Text="Edit" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Item Type: "></asp:Label>
        <asp:DropDownList ID="drpItemType" runat="server" DataValueField="Id" DataTextField="Description">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Publisher: "></asp:Label>
        <asp:DropDownList ID="drpPublisher" runat="server" DataValueField="Id" DataTextField="Name">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Author: "></asp:Label>
        <asp:DropDownList ID="drpAuthor" runat="server" DataValueField="Id" DataTextField="Name">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Title: "></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="ISBN: "></asp:Label>
        <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
        <br />
        <asp:HiddenField ID="hdnLibraryTypeId" runat="server" />
        <br />
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
&nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />

    </div>
</asp:Content>
