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

public partial class Payments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        string amount = txtAmount.Text;
        Session["Fees"] = amount;
        //Label2.Text = Session["First Name"].ToString();
        //Label3.Text = Session["Last Name"].ToString();
        //Label4.Text = Session["4 Digit Pin"].ToString(); 
        
        if (Check1.Checked)
        {
            Panel1.Visible = true;
        }
        else
        {
            Panel1.Visible = false;
        }
    }
    protected void Payment(object sender, EventArgs e)
    {

        string Amount = txtAmount.Text;
        Session["Fees"] = Amount;
        string connString = ConfigurationManager.AppSettings["Conn"].ToString();

        SqlConnection myCon = new SqlConnection(connString);
        string mySql1 = "insert into Payment values('" + txtFirstName.Text + "','" + txtLastName.Text + "','" +
            "','" + DropDownList1.SelectedValue.ToString() + "','" + txtExpDate.Text + "','" + txtCode.Text + "','" + txtAmount.Text + "','"+txtUserID.Text+"')";
        //string mySq12 = "insert into Address (StreetAddress,City,Country,ZipCode,Type,UserID) values('" + txtStreet.Text + "','" + txtCity.Text +
        //    "','" + txtCountry.Text + "','" + txtZipCode.Text + "',0,'" + txtUserID.Text + "')";
        SqlCommand cmd1 = new SqlCommand(mySql1, myCon);
        //SqlCommand cmd2 = new SqlCommand(mySq12, myCon);
        myCon.Open();

        cmd1.ExecuteNonQuery();
        //cmd2.ExecuteNonQuery();

        myCon.Close();


        Response.Redirect("SummaryPage.aspx");

    }
    public string Infomation
    {
        get
        {
            return  txtAmount.Text + " Is charged on you credit card account";
        }



    }
}
