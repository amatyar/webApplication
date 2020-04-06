using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string con = "server=localhost;database=CommerceLicense;integrated security=true";
        SqlConnection conn = new SqlConnection(con);

        string insert = "insert into Certificate(TrainingName,CertificateNumber,InsuranceName,InsuranceNumber,EdLevel)values(@TrainingName,@CertificateNumber,@InsuranceName,@InsuranceNumber,@EdLevel)";
        //SqlCommand com = new SqlCommand(insert, conn);
        //conn.Open();
        //SqlParameter par = new SqlParameter("@TrainingName", TextBox1.Text);
        //com.Parameters.Add(par);
        //SqlParameter par1 = new SqlParameter("@CertificateNumber", TextBox2.Text);
        //com.Parameters.Add(par1);
        //SqlParameter par2 = new SqlParameter("@InsuranceName", TextBox3.Text);
        //com.Parameters.Add(par2);
        //SqlParameter par3 = new SqlParameter("@InsuranceNumber", TextBox4.Text);
        //com.Parameters.Add(par3);
        //SqlParameter par4 = new SqlParameter("@EdLevel", TextBox5.Text);
        //com.Parameters.Add(par4);

        //com.ExecuteNonQuery();
        //conn.Close();

        Response.Redirect("Exams.aspx");
    }
}
