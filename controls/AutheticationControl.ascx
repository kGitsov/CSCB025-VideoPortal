<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AutheticationControl.ascx.cs" Inherits="controls_AutheticationControl" %>
<div id="user">
    <div id="topLeft">
    <asp:Panel ID="adminpanel" runat="server" Direction="LeftToRight">
        <a href="../manage/admin.aspx">Administration panel</a>
        
    </asp:Panel>
    </div>

    <div id="topRight">
    <asp:Panel ID="WelcomePanel" runat="server" Direction="LeftToRight">
        Welcome,&nbsp;<asp:Label ID="Nickname" runat="server" ></asp:Label>&nbsp;     
        <asp:LinkButton ID="LinkBtnLogout" runat="server" OnClick="LinkBtnLogout_Click">Logout</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="LoginPanel" runat="server" Direction="LeftToRight">
        [<a href="../login.aspx">Login</a>][<a href="../register.aspx">Register</a>]
    </asp:Panel>
        </div>
</div>
