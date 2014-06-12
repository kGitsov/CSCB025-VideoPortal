<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage_Manage.master" AutoEventWireup="true" CodeFile="Comments.aspx.cs" Inherits="manage_Default" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">
    <div>        
        <asp:GridView ID="CommentTable" runat="server" AutoGenerateColumns= "false" HtmlEncoding="False" OnRowDataBound="CommentTable_RowDataBound">
            <PagerSettings Visible="True" />
            <Columns>
                <asp:boundfield datafield="username" headertext="Username"/>
                <asp:boundfield datafield="date" headertext="Date"/>
                <asp:boundfield DataField="view" HeaderText ="View comment" />
                <asp:boundfield DataField="deletion" HeaderText ="Delete"/>
            </Columns>
        </asp:GridView>
        <asp:Label ID="NoTextMessage" runat="server" Text="Nothing to display!" Visible="False"></asp:Label>
    </div>
</asp:Content>

