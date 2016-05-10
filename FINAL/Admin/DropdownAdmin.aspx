<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="DropdownAdmin.aspx.cs" Inherits="FINAL.Admin.DropdownAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="DropdownAdmin">

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Library Item Types"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblLibraryErrors" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Library Item List: "></asp:Label>
        <asp:DropDownList ID="drpLibraryType" runat="server" DataValueField="Id" DataTextField="Description">
        </asp:DropDownList>
        &nbsp;<asp:Button ID="btnEditLibraryItem" runat="server" OnClick="btnEditLibraryItem_Click" Text="Edit" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Library Item Type: "></asp:Label>
        <asp:TextBox ID="txtLibraryItemType" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="btnSaveLibraryItemType" runat="server" Text="Save" OnClick="btnSaveLibraryItemType_Click" />
        <br />
        <br />
        <asp:HiddenField ID="hdnItemTypeId" runat="server" />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" Text="Patron Types"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblPatronErrors" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Patron Type List: "></asp:Label>
        <asp:DropDownList ID="drpPatronType" runat="server" DataValueField="Id" DataTextField="Description">
        </asp:DropDownList>
        &nbsp;<asp:Button ID="btnEditPatronType" runat="server" OnClick="btnEditPatronType_Click" Text="Edit" />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Patron Type: "></asp:Label>
        <asp:TextBox ID="txtPatronType" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="btnSavePatronType" runat="server" Text="Save" OnClick="btnSavePatronType_Click" />
        <br />
        <asp:HiddenField ID="hdnPatronTypeId" runat="server" />
        <br />
    </div>
</asp:Content>
