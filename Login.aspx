<%@ Page Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="manage_Login" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="wrapper" Runat="Server">    
    <div>
    Username:<br />
    <asp:TextBox ID="txtName" runat="server" Width="89px"></asp:TextBox><br />
    Password:<br />
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="89px"></asp:TextBox><br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </div>
</asp:Content>