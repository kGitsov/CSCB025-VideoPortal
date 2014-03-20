<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopNavigationButtonsControl.ascx.cs" Inherits="controls_TopNavigationButtonsControl" %>


<script type="text/javascript">
    function EnableCategories() {
        if (document.getElementById('<%= CategoriesPan.ClientID %>').style.visibility == "visible") {
            document.getElementById('<%= CategoriesPan.ClientID %>').style.visibility = "hidden";
        }
        else {
            document.getElementById('<%= CategoriesPan.ClientID %>').style.visibility = "visible";
        }
    }

</script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<div id="top">
    <a href ="../top.aspx"><div id="list">Top 100 videos</div></a>
    <a href ="../recent.aspx"><div id="list">Recent videos</div></a>
    <div id="list" onclick="EnableCategories()">Categories</div>
    <a href ="../details.aspx"><div id="list">Profile</div></a>
    <div ID="CategoriesPanel" style="visibility:hidden;">

    <asp:Panel ID="CategoriesPan" runat="server" style="visibility:hidden;">
        <a href="../categories.aspx?id=1"><div id="innerList">Funny</div></a><br />
        <a href="../categories.aspx?id=2"><div id="innerList">Music</div></a><br />
        <a href="../categories.aspx?id=3"><div id="innerList">Comedy</div></a><br />
        <a href="../categories.aspx?id=4"><div id="innerList">Movies</div></a><br />
    </asp:Panel>
    </div>
    
</div>