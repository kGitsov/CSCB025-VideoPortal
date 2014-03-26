<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>
<%@ Register Src="~/controls/TopnavigationButtonsControl.ascx" TagName="TopNavigation" TagPrefix="ulT" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    <ulT:TopNavigation ID="TopNavigation" runat="server" />
</asp:Content>
<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">

    <asp:Image ID="profileImage" runat="server" Width="120" /><br />
    <asp:Button ID="ChangeImage" runat="server" Text="Change Photo" OnClick="ChangeImage_Click" />
    
    <asp:FileUpload ID="FileUpload" runat="server" Visible="false" />
    <asp:Button ID="UploadImage" runat="server" Text="Upload Photo" visible="false" OnClick="UploadImage_Click"/>

    <asp:Label ID="Name" runat="server"  Text=""><%=firstName+' '+lastName %></asp:Label><br />
    <asp:Label ID="Sex" runat="server" Text=""><%=sex %></asp:Label><br />
    <asp:Label ID="Country" runat="server" Text=""><%=country %></asp:Label><br />
    <asp:Label ID="City" runat="server" Text=""><%=city %></asp:Label><br />
    <asp:Label ID="RegisterDate" runat="server" Text=""><%=registerDate %></asp:Label><br />

    <asp:Button ID="EditProfile" runat="server" Text="Edit" OnClick="EditProfile_Click" /><br />

    <asp:Panel ID="EditPanel" runat="server" Visible="False">
        Име: <asp:TextBox ID="EditFirstName" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server"
            ControlToValidate="EditFirstName" ErrorMessage="First name field cannot be left blank."
            Display="Dynamic">
        </asp:RequiredFieldValidator>
        Фамилия: <asp:TextBox ID="EditLastName" runat="server"></asp:TextBox><br />
        Държава: <asp:TextBox ID="EditCountry" runat="server"></asp:TextBox><br />
        Град: <asp:TextBox ID="EditCity" runat="server"></asp:TextBox><br />
        Пол: <asp:RadioButton ID="MaleRadio" runat="server" text="мъж" GroupName="sexGroupRadio" Checked="True" />
        <asp:RadioButton ID="FemaleRadio" runat="server"  text="жена" GroupName="sexGroupRadio" /><br />

        <asp:Button ID="SaveProfile" runat="server" Text="Save" OnClick="SaveProfile_Click" />

    </asp:Panel>
</asp:Content>

