<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkButtonRedirectPage.aspx.cs" Inherits="WebApplication1.LinkButtonRedirectPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--<asp:LinkButton ID="LinkButton1"  runat="server" OnClick="LinkButton1_Click" PostBackUrl="LinkButtonRedirectPage.aspx">LinkButton</asp:LinkButton>-->
               <h3> Helo, Welcome to Team.! </h3> 
            <asp:Button ID="Button1" runat="server" Text="Get" OnClick="Button1_Click(TextBox1)" value="submit" />
                <asp:GridView ID="GridView1" AutoGenerateColumns="true" runat="server" >

                </asp:GridView>
        </div>
    </form>
</body>
</html>
