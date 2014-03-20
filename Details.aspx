<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>
<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">
    <asp:Image ID="profileImage" runat="server" ImageUrl="<%=img %>" /><br />
    <asp:Button ID="ChangeImage" runat="server" Text="Change Photo" OnClick="ChangeImage_Click" />
    
    <asp:FileUpload ID="FileUpload" runat="server" Visible="false" />
    <asp:Button ID="UploadImage" runat="server" Text="Upload Photo" visible="false" OnClick="UploadImage_Click"/>

    <asp:Label ID="Name" runat="server"  Text=""><%=firstName+' '+lastName %></asp:Label><br />
    <asp:Label ID="Sex" runat="server" Text=""><%=sex %></asp:Label><br />
    <asp:Label ID="Country" runat="server" Text=""><%=country %></asp:Label><br />
    <asp:Label ID="RegisterDate" runat="server" Text=""><%=registerDate %></asp:Label><br />
    
</asp:Content>

