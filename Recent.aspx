<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Recent.aspx.cs" Inherits="Recent" %>
<%@ Register Src="~/controls/RecentAddedVideosControl.ascx" TagName="RecentAdded" TagPrefix="ulR" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="wrapper" Runat="Server">
    <ulR:RecentAdded ID="RecentAdded" runat="server" />
</asp:Content>

