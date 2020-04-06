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

public partial class Image : System.Web.UI.Page
{
    protected void btnLoadImg_Click(object sender, EventArgs e)
    {
        SqlConnection connection = null;
        try
        {
            FileUpload img = (FileUpload)imgUpload;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = imgUpload.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            // Insert the employee name and image into db
            string connString = ConfigurationManager.AppSettings["Conn"].ToString();
            connection = new SqlConnection(connString);


            string sql = "INSERT INTO Applicant1(firstname,appimg) VALUES(@firstname, @appimg) SELECT @@IDENTITY";
            SqlCommand cmd = new SqlCommand(sql, connection);

            connection.Open();

            cmd.Parameters.AddWithValue("@firstname", txtAName.Text.Trim());
            cmd.Parameters.AddWithValue("@appimg", imgByte);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            lblResult.Text = String.Format("Applicant ID is {0}", id);

            #region Show Image here
            // Get the image from the Database and display.
            #endregion
            Image1.ImageUrl = "~/ShowImage.ashx?id=" + id;
        }
        catch
        {
            lblResult.Text = "There was an error";
        }
        finally
        {
            connection.Close();
        }
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Certificate.aspx");
    }
}
