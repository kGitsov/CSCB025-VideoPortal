<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Watch.aspx.cs" Inherits="Watch" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>
<%@ Register Src="~/controls/FindCommentsAndListControl.ascx" TagName="FindComments" TagPrefix="ulF" %>
<%@ Register Src="~/controls/CommentVideoControl.ascx" TagName="AddComments" TagPrefix="ulC" %>
<%@ Register Src="~/controls/VotesControl.ascx" TagName="Votes" TagPrefix="ulV" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>

<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">
    <ulV:Votes ID="VotesContainer" runat="server" />

    <%=player%>
    
    <ulF:FindComments ID="FindComments" runat="server" />
    <ulC:AddComments ID="AddComments" runat="server" />

</asp:Content>

