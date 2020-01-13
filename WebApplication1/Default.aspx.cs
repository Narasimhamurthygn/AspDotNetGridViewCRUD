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
    
    public partial class _Default : Page
    {
           string dbConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
           SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
         protected void Page_Load(object sender, EventArgs e)
         {
            SqlConnection con = new SqlConnection(dbConnectionString);
             SqlCommand cmd = new SqlCommand();
           //   cmd.CommandType = CommandType.StoredProcedure;
          //    cmd.CommandText = "spEmployees";
            con.Open();
            var queryString = "SELECT * FROM Employees";
            var adapter = new SqlDataAdapter(queryString, con);
            var commandBuilder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            employeesDisplay.DataSource = ds.Tables[0];
            employeesDisplay.DataBind();

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            // Response.Redirect("LinkButtonRedirectPage.aspx");
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spEmployeesMngrId";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text.Trim();
            cmd.Connection = con;
            try
            {
                con.Open();
                GridView1.EmptyDataText = "No Records Found";
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            } 
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spInsertEmployee";
            cmd.Parameters.AddWithValue("@Id", id.Text);
            cmd.Parameters.AddWithValue("@User_name", userName.Text);
            cmd.Parameters.AddWithValue("@Department", department.Text);
            cmd.Parameters.AddWithValue("@MngerId", mngerId.Text);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            // cmd.ExecuteReader();
           
           
        }
    }
}