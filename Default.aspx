<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>



<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>
<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">


    
</asp:Content>

