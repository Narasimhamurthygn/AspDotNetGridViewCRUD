<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        table, td, th 
        {
            border: 2px solid black;
            border-collapse: collapse;
         /* background-color: darkgrey; */
            color: green;
            
        }
        table, td, th:hover
        {
            color: red;
        }
        th, td 
        {
           text-align: center;

        }
        tr:nth-child(even) {
            background: #CCC;
        }
        tr:nth-child(odd) {
            background: #FFF;
        }
        h3 {
           text-shadow: 3px 1px grey;
           font-style: italic;
        }
    </style>
    <h3>Employees Table View!</h3>
    <asp:GridView ID="GridViews" runat="server" Autogeneratecolumns="false" DataKeyNames="Id"
      OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
       OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added.">
        <Columns>
            <asp:TemplateField HeaderText="Id" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtId1" runat="server" Text='<%# Eval("Id") %>'></asp:TextBox>
                </EditItemTemplate>
             </asp:TemplateField>
            <asp:TemplateField HeaderText="User_name" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("User_name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUsername1" runat="server" Text='<%# Eval("User_name") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDepartment1" runat="server" Text='<%# Eval("Department") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MngerId" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblMngerId" runat="server" Text='<%# Eval("MngerId") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtMngerId1" runat="server" Text='<%# Eval("MngerId") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" />
        </Columns>
    </asp:GridView>
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
        <tr>
            <td style="width: 150px">
                ID: <br />
                 <asp:TextBox ID="txtId1" runat="server" Width="140" />
            </td>
            <td style="width:150px">
                UserName: <br />
                <asp:TextBox ID="txtUsername1" runat="server"></asp:TextBox>
            </td>
            <td style="width:150px">
                Department: <br />
                <asp:TextBox ID="txtDepartment1" runat="server"></asp:TextBox>
            </td>
            <td style="width:150px">
              ManagerID: <br />
                <asp:TextBox ID="txtMngerId1" runat="server"></asp:TextBox>
            </td>
            <td style="width: 100px">
                <asp:Button style="width:50px; height:30px;color:darkmagenta;Background:gold; position:center" ID="btnAdd" runat="server" Text="Add" OnClick="Insert" Height="32px" Width="98px" />
            </td>
        </tr>
    </table>
</asp:Content>
