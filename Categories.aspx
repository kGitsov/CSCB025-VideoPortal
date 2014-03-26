<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Categories" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>
<%@ Register Src="~/controls/CategoriesListingVideosControl.ascx" TagName="CategoriesListing" TagPrefix="ulC" %>


<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>
<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">
    
    <ulC:CategoriesListing ID="CategoriesListing" runat="server" />
</asp:Content>

