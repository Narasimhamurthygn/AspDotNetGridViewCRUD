using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class LinkButtonRedirectPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      /*  protected void Button1_Click(object sender, EventArgs e)
        {
            // Response.Redirect("LinkButtonRedirectPage.aspx");
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            // con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetEmployeeDetailsById";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = TextBox1.Text.Trim();
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
        }*/
    }
}