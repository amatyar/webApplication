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

public partial class LogInAcc : System.Web.UI.Page
{
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string username = Login1.UserName;
        string pwd = Login1.Password;
        string message = "";
        string con = "server=DESKTOP-9B3BV7M\\SQLEXPRESS01;database=Clifford;integrated security=true;";
        SqlConnection constr = new SqlConnection(con);
        string mySql = "select * from Registration where username='" + username + "' and password='" + pwd + "' ";

        SqlCommand cmd = new SqlCommand(mySql, constr);
        constr.Open();
        SqlDataReader i = cmd.ExecuteReader();
        i.Read();
        if (i.HasRows)
        {
            message = "valid";
        }
        else
        {
            message = "invalid";
        }
        constr.Close();
        if (message == "valid")
        {
            Response.Redirect("welcome.aspx");
        }
        else
        {
            Response.Redirect("invalids.aspx");
        }
    }
}
