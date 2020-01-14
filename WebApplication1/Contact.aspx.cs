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
    public partial class Contact : Page
    {
        string dbConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
          protected void Page_Load(object sender, EventArgs e)
          {
             if (!this.IsPostBack)
             {
                 this.BindGrid();
             }


          }
        private void BindGrid()
        {
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Employees");
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spEmployeesProcedure";
            cmd.Parameters.AddWithValue("@Action", "SELECT");
            cmd.Parameters.AddWithValue("@Id", 509);
            cmd.Parameters.AddWithValue("@User_name", "Nara");
            cmd.Parameters.AddWithValue("@Department", "Hr");
            cmd.Parameters.AddWithValue("@MngerId", 500);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            cmd.Connection = con;
            dataAdapter.SelectCommand = cmd;
            DataSet dt = new DataSet();
            dataAdapter.Fill(dt);
            GridViews.DataSource = dt.Tables[0];
            GridViews.DataBind();
        }
        protected void Insert(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId1.Text);
            string Username = txtUsername1.Text;
            string Department = txtDepartment1.Text;
            int MngerId = Convert.ToInt32(txtMngerId1.Text);
            using (SqlConnection con = new SqlConnection(dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Employees"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spEmployeesProcedure";
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@Id", txtId1.Text);
                    cmd.Parameters.AddWithValue("@User_name", txtUsername1.Text);
                    cmd.Parameters.AddWithValue("@Department", txtDepartment1.Text);
                    cmd.Parameters.AddWithValue("@MngerId", txtMngerId1.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();        
                }
            }
            this.BindGrid();

        }
       
        protected void OnRowEditing(Object sender, GridViewEditEventArgs e)
        {
            GridViews.EditIndex = e.NewEditIndex;
            this.BindGrid();
        } 
        protected void OnRowCancelingEdit(Object sender, EventArgs e)
        {
            GridViews.EditIndex = -1;
            this.BindGrid();
        }
      /*  protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViews.EditIndex)
            {
               (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?')";
            }
        } */
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
             int Id = Convert.ToInt32(GridViews.DataKeys[e.RowIndex].Values[0]);
            string Username = Convert.ToString(GridViews.DataKeys[e.RowIndex].Values[0]);
            string Department = Convert.ToString(GridViews.DataKeys[e.RowIndex].Values[0]);
             int MngerId = Convert.ToInt32(GridViews.DataKeys[e.RowIndex].Values[0]);
            using (SqlConnection con = new SqlConnection(dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Employees"))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spEmployeesProcedure";
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@User_name", Username);
                    cmd.Parameters.AddWithValue("@Department", Department);
                    cmd.Parameters.AddWithValue("@MngerId", MngerId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
           this.BindGrid();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViews.Rows[e.RowIndex];
            //  int Id = Convert.ToInt32(GridViews.DataKeys[e.RowIndex].Values[0]);
            //  string User_name = (row.FindControl("txtUsername1") as TextBox).Text;
            //   string Department = (row.FindControl("txtDepartment1") as TextBox).Text;
            //   int MngerId = Convert.ToInt32(row.FindControl("txtMngerId1") as TextBox);
            TextBox txtId = (TextBox)GridViews.Rows[e.RowIndex].FindControl("txtId1");
            int Id = Convert.ToInt32(txtId.Text);
           TextBox User_name = (TextBox)GridViews.Rows[e.RowIndex].FindControl("txtUsername1");
            string Username = Convert.ToString(User_name.Text);
            TextBox txtDepartment = (TextBox)GridViews.Rows[e.RowIndex].FindControl("txtDepartment1");
            string Department = Convert.ToString(txtDepartment.Text);
            TextBox txtMngerId = (TextBox)GridViews.Rows[e.RowIndex].FindControl("txtMngerId1");
            int MngerId = Convert.ToInt32(txtMngerId.Text);

            using (SqlConnection con = new SqlConnection(dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Employees"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spEmployeesProcedure";
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@User_name", Username);
                    cmd.Parameters.AddWithValue("@Department", Department);
                    cmd.Parameters.AddWithValue("@MngerId", MngerId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViews.EditIndex = -1;
            this.BindGrid();
        }

        protected void btnDeleteRecords_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("Id", typeof(int)),
               new DataColumn("User_name", typeof(string)), new DataColumn("Department", typeof(string)),
                new DataColumn("MngerId", typeof(int)) });
            foreach(GridViewRow row in GridViews.Rows)
            {
                if((row.FindControl("ChkDel") as CheckBox).Checked)
                {
                    int Id = Convert.ToInt32(GridViews.DataKeys[row.RowIndex].Value);
                    using (SqlConnection con = new SqlConnection(dbConnectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE Id=" + Id, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            this.BindGrid();
        }
    }
}