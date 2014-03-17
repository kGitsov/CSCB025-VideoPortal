<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage_Manage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="manage_Users" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    
    
        
</asp:Content>

<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">
    <div>        
        <asp:GridView ID="VideoTable" runat="server" AutoGenerateColumns= "false" HtmlEncoding="False" OnRowDataBound="VideoTable_RowDataBound">
            <PagerSettings Visible="True" />
            <Columns>
                <asp:boundfield datafield="Id" headertext="ID"/>
                <asp:boundfield datafield="username" headertext="Username"/>
                <asp:boundfield DataField="isAdmin" HeaderText ="Is Admin" />
                <asp:boundfield DataField="isActive" HeaderText ="Is Active"/>
                <asp:BoundField DataField="activation" HeaderText="Activate/Deactivate" />
                <asp:BoundField DataField="view" HeaderText="Activate/Deactivate" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="NoTextMessage" runat="server" Text="Nothing to display!" Visible="False"></asp:Label>
    </div>
</asp:Content>

