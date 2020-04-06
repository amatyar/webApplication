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

public partial class Exams : System.Web.UI.Page
{
    protected void page_load(object sender, EventArgs e)
    {
        
        //Label2.Text = Session["First Name"].ToString()+"  "+Session["Last Name"].ToString();
        
        //Label4.Text = Session["4 Digit Pin"].ToString();
    }
   
   
    protected void btnStart_click(object sender, EventArgs e)
    {
        Response.Redirect("Question.aspx");

    }
}
