<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Embed.aspx.cs" Inherits="Embed" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>
<%@ Register Src="~/controls/CategoriesListingVideosControl.ascx" TagName="CategoriesListing" TagPrefix="ulC" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>
<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">


    <asp:textbox ID="linkToEmbed" runat="server"></asp:textbox>
    <asp:DropDownList ID="categories" runat="server">
        <asp:ListItem>Choose category</asp:ListItem>
        <asp:ListItem>Funny</asp:ListItem>
        <asp:ListItem>Music</asp:ListItem>
        <asp:ListItem>Comedies</asp:ListItem>
        <asp:ListItem>Movies</asp:ListItem>
    </asp:DropDownList>
    <asp:button ID="embedButton" runat="server" text="Button" OnClick="embedButton_Click" />

</asp:Content>

