using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class SummaryPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label2.Text = Session["First Name"].ToString() + "  " + Session["Last Name"].ToString();
        //Label4.Text = Session["4 Digit Pin"].ToString();
        Label5.Text = Session["Fees"].ToString();
        if (PreviousPage != null)
        {
            Label5.Text = " Your card charged following fees" + PreviousPage.Title + "<br/>";
            Payments prevPage = PreviousPage as Payments;
            if (prevPage != null)
            {
                Label5.Text += "your card fees:" + prevPage.Infomation;
            }
        }
    }
}
