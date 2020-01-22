<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewCRUD.aspx.cs" Inherits="WebApplication1.GridViewCRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <style type="text/css">
        .TblGridView
        {
            width: 40%;
            border: solid 2px black;
            min-width: 40%;

        }
        .header
        {
           background-color: #646464;
           font-family: Arial;
           color: White;
           border: none 0px transparent;
           height: 25px;
           text-align: center;
           font-size: 16px;
        }   
        .rows
        {
           background-color: #ffd800;
           font-family: Arial;
           font-size: 14px;
           color: #000;
           min-height: 25px;
           text-align: center;
           border: none 0px transparent;
        }
        .TblGridView td
        {
           padding: 5px;
        }
        .TblGridView th
        {
           padding: 5px;
        }
        .pager
        {
           background-color: #646464;
           font-family: Arial;
           color: White;
           height: 30px;
           text-align: left;
        }
        .rows:hover
        {
           background-color: #ff8000;
           font-family: Arial;
           color: #fff;
           text-align: center;
        }
        .selectedrow
        {
           background-color: #ff8000;
           font-family: Arial;
           color: #fff;
           font-weight: bold;
           text-align: left;
        }
        .TblGridView a 
        {
           background-color: Transparent;
           padding: 5px 5px 5px 5px;
           color: #fff;
           text-decoration: none;
           font-weight: bold;
        }
 
        .TblGridView a:hover 
        {
           background-color: #000;
           color: #fff;
        }
       
        .tblclass
        {
            background-color: crimson;
            max-width: 40%;
        }
        .tblclass #btnAdd
        {
            background-color: limegreen;
        }
        .tblclass #btnDelete
        {
            background-color: orangered;
        }
        .tblclass #btnClear
        {
            background-color: darkorange;
        }
        h2 {
          /*text-shadow: 3px 1px grey; */
           font-style: italic;
           padding-left: 15%;
           color: darkorange;
        }
         #grid {
            padding-bottom: 50px;

        }
        </style>
    <h2>Employees Table View!</h2>
    <form id="forms" runat="server">
        <div id="grid">
        <asp:GridView ID="TblGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" CssClass="TblGridView" PagerStyle-CssClass="gridviewpage"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="checkDel" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField  DataField="ID" HeaderText="ID" />
                <asp:BoundField  DataField="UserName"  HeaderText="UserName"  />
                <asp:BoundField  DataField="Department"  HeaderText="Department"  />
                <asp:BoundField  DataField="ManagerID"  HeaderText="ManagerID"  />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="lnkEdit_Click">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
       </div>
        <div id="tbl" class="tblclass">
           <asp:HiddenField ID="hfID" runat="server" /> 
        <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
            </td>
            <td colspan="2">
              <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
              <td>
                <asp:Label ID="Label2" runat="server" Text="Department"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
            </td>
           </tr>
          <tr>
              <td>
                <asp:Label ID="Label3" runat="server" Text="ManagerID"></asp:Label>
              </td>
            <td colspan="2">
                <asp:TextBox ID="txtManagerID" runat="server" Height="16px"></asp:TextBox>
                <br />
            </td>
           </tr>
          <tr>
            <td>
                
            </td>
              <td>
                  <asp:Button ID="btnAdd" runat="server" Text="Save" OnClick="btnSave_Click" Height="32px" Width="98px" />
                  <asp:Button ID="btnDelete" runat="server" Text="DeleteRecords" OnClick="btnDeleteRecords_Click" Height="32px" Width="98px" />
                  <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" Height="32px" Width="98px" />
              </td>
         </tr>
    </table>
   </div>
      </form>
    </body>
</html>