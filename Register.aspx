<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Main.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="wrapperContent" ContentPlaceHolderID="wrapper" Runat="Server">
    <script language="javascript">
        function ClientValidate(source, clientside_arguments) {
            //Test whether the length of the value is more than 6 characters
            if (clientside_arguments.Value.length >= 3) {
                clientside_arguments.IsValid = true;
            }
            else { clientside_arguments.IsValid = false };
        }
    </script>
    Username:<asp:TextBox ID="usrname" runat="server"></asp:TextBox><br />
        <asp:CustomValidator ID="ValidateUsername"
           ClientValidationFunction="ClientValidate"
           ControlToValidate="usrname" runat="server"
           ErrorMessage="The username must be more than 3 characters."
           Display="Dynamic">
        </asp:CustomValidator><br />
    Password:<asp:TextBox ID="pssword" TextMode="Password" runat="server"></asp:TextBox><br />
    Confirm password:<asp:TextBox ID="cpssword" TextMode="Password" runat="server"></asp:TextBox><br />

        <asp:CompareValidator ID="ComparePasswords" runat="server" 
            ErrorMessage="Passwords do not match."    ControlToCompare="cpssword"
            ControlToValidate="pssword">
        </asp:CompareValidator><br />

    E-mail:<asp:TextBox ID="mail" TextMode="Email" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredEmail" runat="server"
            ControlToValidate="mail" ErrorMessage="Email field cannot be left blank."
            Display="Dynamic">
        </asp:RequiredFieldValidator>
 
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEMail" runat="server"
            ErrorMessage="Invalid email address."    ControlToValidate="mail" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            Display="Dynamic">
        </asp:RegularExpressionValidator>
    <br />
    
    <asp:CheckBox ID="acceptTerms" runat="server" Text="Accept terms and conditions" /><br />
        

    <asp:Button ID="register" runat="server" Text="Register " OnClick="register_Click" />
</asp:Content>

