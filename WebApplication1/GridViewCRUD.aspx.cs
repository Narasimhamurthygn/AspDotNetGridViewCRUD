using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class GridViewCRUD : System.Web.UI.Page
    {
        string dbConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                //  this.BindGrid();
               // btnDelete.Enabled = true;
                FillGridView();
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
       public void Clear()
        {
            hfID.Value = "";
            txtUserName.Text = txtDepartment.Text = txtManagerID.Text = "";
            btnAdd.Text = "Save";
           // btnDelete.Enabled = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("TblEmployees");
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spEmployeeCreateOrUpdate";
          //  cmd.Parameters.AddWithValue("@Action", "SELECT");
            cmd.Parameters.AddWithValue("@ID",(hfID.Value==""?500 : Convert.ToInt32(hfID.Value)));
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text.Trim());
            cmd.Parameters.AddWithValue("@ManagerID", txtManagerID.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();
            Clear();
            FillGridView();
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }
        void FillGridView()
        {
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("TblEmployees");
            cmd.Connection = con;
            con.Open();
            SqlDataAdapter dt = new SqlDataAdapter("spEmployeeViewAlls", con);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            dt.Fill(dataTable);
            con.Close();
            TblGridView.DataSource = dataTable;
            TblGridView.DataBind();
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("TblEmployees");
            cmd.Connection = con;
            con.Open();
            SqlDataAdapter dt = new SqlDataAdapter("spEmployeeViewByID", con);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dataTable = new DataTable();
            dt.Fill(dataTable);
            con.Close();
            hfID.Value = ID.ToString();
            txtUserName.Text = dataTable.Rows[0]["UserName"].ToString();
            txtDepartment.Text = dataTable.Rows[0]["Department"].ToString();
            txtManagerID.Text = dataTable.Rows[0]["ManagerID"].ToString();
            btnAdd.Text = "Update";
           // btnDelete.Enabled = true;
        }
        protected void btnDeleteRecords_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("ID", typeof(int)), new DataColumn("UserName", typeof(string)), new DataColumn("Department", typeof(string)),
                new DataColumn("ManagerID", typeof(int))});
            foreach(GridViewRow row in TblGridView.Rows)
            {
                if((row.FindControl("checkDel") as CheckBox).Checked)
                {
                    int ID = Convert.ToInt32(TblGridView.DataKeys[row.RowIndex].Value);
                    using (SqlConnection con = new SqlConnection(dbConnectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM TblEmployees WHERE ID=" + ID, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            FillGridView();
        }
    }
}