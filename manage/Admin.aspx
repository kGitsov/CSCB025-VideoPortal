<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage_Manage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="manage_Admin" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    
    
        
</asp:Content>

<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">
    <div>        
        <asp:GridView ID="VideoTable" runat="server" AutoGenerateColumns= "false" HtmlEncoding="False" OnRowDataBound="VideoTable_RowDataBound">
            <PagerSettings Visible="True" />
            <Columns>
                <asp:boundfield Datafield="Id" Headertext="ID"/>
                <asp:boundfield Datafield="videoTitle" Headertext="Title"/>
                <asp:boundfield DataField="videDate" HeaderText ="Date" />
                <asp:boundfield DataField="videoViews" HeaderText ="Views"/>
                <asp:BoundField DataField="up" HeaderText="Rating" />
                <asp:BoundField DataField="isApproved" HeaderText="Is Approved" />
                <asp:BoundField DataField="approve" HeaderText="Approve/Disapprove" />
                <asp:BoundField DataField="view" HeaderText="View" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="NoTextMessage" runat="server" Text="Nothing to display!" Visible="False"></asp:Label>
    </div>
</asp:Content>

