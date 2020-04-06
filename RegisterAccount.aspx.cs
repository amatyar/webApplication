using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class RegisterAnAccount : System.Web.UI.Page
{
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string Username = txtUserName.Text;
        string pwd = txtpwd.Text;
        string Email = txtEmail.Text;
        string FullName = txtFullName.Text;
        string Country = txtCountry.Text;

        string con = "server=DESKTOP-9B3BV7M\\SQLEXPRESS01;database=Clifford;integrated security=true;";// old method to connect 
        SqlConnection constr = new SqlConnection(con);
        string sql = " insert into Registration values('" + FullName + "','" + Username + "','" + pwd + "','" + Email + "','" + Country + "')";
        //string sql = " insert into Registration values('" + Username + "','" + pwd + "','" + FullName + "','" + Country + "','" + Email + "')";
        SqlCommand cmd = new SqlCommand(sql, constr);
        constr.Open();
        cmd.ExecuteNonQuery();
        constr.Close();

        Response.Redirect("AccountActiveNotice.aspx");
    }
}
