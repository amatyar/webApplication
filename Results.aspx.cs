using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Results : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label2.Text = Session["First Name"].ToString();
        //Label3.Text = Session["Last Name"].ToString();
        //Label4.Text = Session["4 Digit Pin"].ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payments.aspx");
    }
}
