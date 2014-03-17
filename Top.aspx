<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Top" %>
<%@ Register Src="~/controls/TopRecentVideosControl.ascx" TagName="TopRecent" TagPrefix="ulTr" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="wrapper" Runat="Server">
    <ulTr:TopRecent ID="TopRecent" runat="server" />
</asp:Content>

