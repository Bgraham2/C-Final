<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="PatronAdmin.aspx.cs" Inherits="FINAL.Admin.PatronAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="PatronAdmin">

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Patrons"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblErrors" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Existing Patrons: "></asp:Label>
        <asp:DropDownList ID="drpExistingPatrons" runat="server" DataValueField="Id" DataTextField="FullName">
        </asp:DropDownList>
&nbsp;<asp:Button ID="btnEditPatron" runat="server" Text="Edit" OnClick="btnEditPatron_Click" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Create/Save Patron"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="First Name: "></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Phone: "></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Type: "></asp:Label>
        <asp:DropDownList ID="drpPatronType" runat="server" DataValueField="Id" DataTextField="Description">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Active: "></asp:Label>
        <asp:CheckBox ID="chkActive" runat="server" Checked="True" />
        <br />
        <br />
        <asp:HiddenField ID="hdnPartonId" runat="server" />
        <br />
        <asp:Button ID="btnCreatePatron" runat="server" OnClick="btnCreatePatron_Click" Text="Create" />
&nbsp;<asp:Button ID="btnSavePatron" runat="server" OnClick="btnSavePatron_Click" Text="Save" />
        </div>
</asp:Content>
