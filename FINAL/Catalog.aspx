<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="FINAL.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Catalog">

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Library Catalog Items"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Item Types: "></asp:Label>
        <asp:DropDownList ID="drpItemTypes" runat="server" DataValueField="Id" DataTextField="Description" >
        </asp:DropDownList>
        &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Authors: "></asp:Label>
        <asp:DropDownList ID="drpAuthors" runat="server" DataValueField="Id" DataTextField="Name">
        </asp:DropDownList>
&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Publishers: "></asp:Label>
        <asp:DropDownList ID="drpPublishers" runat="server" DataValueField="Id" DataTextField="Name">
        </asp:DropDownList>
&nbsp;
        <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Filter" />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Existing Items: "></asp:Label>
        <asp:DropDownList ID="drpExistingItems" runat="server" DataValueField="Id" DataTextField="Title">
        </asp:DropDownList>
&nbsp;
        <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" OnClick="btnCheckOut_Click" />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" Text="Your Checked Out Items"></asp:Label>
        <br />
        <asp:GridView ID="gvCheckedOut" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" OnRowCommand="gvCheckedOut_RowCommand">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
            <Columns>
                <asp:BoundField DataField="CheckedOutId" HeaderText="CID" />
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Isbn" HeaderText="ISBN" />
                <asp:BoundField DataField="DateCheckedOut" HeaderText="Date Checked OUt" />
                <asp:BoundField DataField="DueDate" HeaderText="Date Due" />
                <asp:ButtonField ButtonType="Button" CommandName="CheckIn" Text="Check In" />
            </Columns>
        </asp:GridView>
        <br />

    </div>
</asp:Content>
