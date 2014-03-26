<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>
<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">
    <asp:Image ID="profileImage" runat="server" Width="120" /><br />

    <asp:Label ID="Name" runat="server"  Text=""><%=firstName+' '+lastName %></asp:Label><br />
    <asp:Label ID="Sex" runat="server" Text=""><%=sex %></asp:Label><br />
    <asp:Label ID="Country" runat="server" Text=""><%=country %></asp:Label><br />
    <asp:Label ID="City" runat="server" Text=""><%=city %></asp:Label><br />
    <asp:Label ID="RegisterDate" runat="server" Text=""><%=registerDate %></asp:Label><br />

</asp:Content>

