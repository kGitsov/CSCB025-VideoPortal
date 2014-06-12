<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentVideoControl.ascx.cs" Inherits="controls_CommentVideoControl" %>


<asp:TextBox ID="CommentContent" runat="server" TextMode="MultiLine"></asp:TextBox>
<asp:Button ID="SubmitContent" runat="server" Text="Comment" OnClick="SubmitContent_Click" />