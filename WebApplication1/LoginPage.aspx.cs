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
    public partial class LoginPage : System.Web.UI.Page
    {
        string dbConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }
        void func()
        {
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("UserLogin");
            cmd.Connection = con;
            con.Open();
            SqlDataAdapter dt = new SqlDataAdapter("spUserlg", con);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", "user1");
            cmd.Parameters.AddWithValue("@Password", "12345");
            cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 250);
            cmd.Parameters["@UserType"].Direction = ParameterDirection.Output;
            DataTable dataTable = new DataTable();
            dt.Fill(dataTable);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string UserType = null;
            SqlConnection con = new SqlConnection(dbConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spUserlg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 250);
            cmd.Parameters["@UserType"].Direction = ParameterDirection.Output;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
           UserType=Convert.ToString(cmd.ExecuteScalar());
           // UserType = cmd.Parameters["@UserType"].Value.ToString();
            if (UserType == "Admin_User")
            {
                Response.Redirect("GridViewCRUD.aspx");
             
            }
            else
            {
                Response.Redirect("Contact.aspx");
            }
          
        }
    }
}







/* // cmd.Parameters.Add("@User", SqlDbType.NVarChar, 250);
// cmd.Parameters["@User"].Direction = ParameterDirection.Output;
// var UserType =cmd.Parameters["@UserType"].Value.ToString();
cmd.ExecuteNonQuery();
            // string username = dt.Tables[0].Rows[0]["UsernName"].ToString();
            // string password = dt.Tables[0].Rows[0]["Password"].ToString();
            SqlDataAdapter adp = new SqlDataAdapter();
adp.SelectCommand.Parameters.Add("@UserType", SqlDbType.NVarChar, 250);
            adp.SelectCommand.Parameters["@UserType"].Direction = ParameterDirection.Output;
            DataSet dt = new DataSet();
              string UserType = dt.Tables[0].Rows[0]["UserType"].ToString();
adp.Fill(dt);
*/

/*  if(dt.Rows[0]["UserType"]=="Admin_User")
            {
               // Session["UserName"] = txtUserName.Text.Trim();
                Response.Redirect("GridViewCRUD.aspx");
            }
            else
            {
               // Session["UserName"] = txtUserName.Text.Trim();
                Response.Redirect("Contact.aspx");
            } */





/* if (UserType == "Normal_User")
               {

               }*/

/*  if (username == txtUserName.Text && password == txtPassword.Text)
               {

               } */


/* SqlDataAdapter adp = new SqlDataAdapter("UserDB", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.CommandText = "spUserlg";
            adp.SelectCommand.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value=txtUserName.Text.Trim();
            adp.SelectCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 250).Value = txtPassword.Text.Trim();
            adp.SelectCommand.Parameters.Add("@User", SqlDbType.NVarChar, 250);
            adp.Parameters["@User"].Direction = ParameterDirection.Output;
              DataTable dt1 = new DataTable();
            DataSet dt = new DataSet();
            adp.Fill(dt);
 * 
 *   using (SqlConnection con = new SqlConnection(dbConnectionString))
            {
                con.Open();
              //  string query = "SELECT COUNT(1) FROM tblUsers WHERE username=@username AND password=@password";
                SqlCommand cmd = new SqlCommand("TblLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUserLogin";
                cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                cmd.Parameters.Add("@Admin", SqlDbType.Bit);
                cmd.Parameters["@Admin"].Direction = ParameterDirection.Output;
               var message = (string)cmd.Parameters["@Admin"].Value;
              //  int count = Convert.ToInt32(cmd.ExecuteScalar());
                if(message == "Admin User")
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("GridViewCRUD.aspx");
                }
                else
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Contact.aspx");
                    lblErrorMessage.Visible = true;
                }
            }
 * 
 * 
 * 
 * if(message == "Admin User")
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("GridViewCRUD.aspx");
                }
                else
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Contact.aspx");
                    lblErrorMessage.Visible = true;
                }  */
