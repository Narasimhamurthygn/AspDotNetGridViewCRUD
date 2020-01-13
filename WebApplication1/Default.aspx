<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <h3> Hello, Welcome to Team.! </h3> 
     <asp:TextBox ID="txtId"  runat="server" Placeholder="Enter EmployeeId" AutoPostBack="false"></asp:TextBox>
     <asp:Button ID="Button1" runat="server" Text="Get" OnClick="Button1_Click1" value="submit" />
     <asp:GridView ID="GridView1" AutoGenerateColumns="true" runat="server" >
     </asp:GridView>
<table>
<tr>
    <td>Id</td>
    <td>
        <asp:TextBox ID="id" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="id" ErrorMessage="Please Enter ID"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td>UserName</td>
    <td>
        <asp:TextBox ID="userName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="userName" ErrorMessage="Please Enter UserName"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td>Department</td>
    <td>
        <asp:TextBox ID="department" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="department" ErrorMessage="Please Enter Department"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
  <td>ManagerID</td>
    <td>
        <asp:TextBox ID="mngerId" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="mngerId" ErrorMessage="Please Enter ManagerID"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td></td>
    <td>
        <asp:Button ID="insert" runat="server" Text="InsertRecord" OnClick="insert_Click" />
    </td>
</tr>
</table>

<asp:GridView ID="employeesDisplay"  AutoGenerateColumns="true" runat="server" OnClick="Page_Load"></asp:GridView>
   
</asp:Content>


