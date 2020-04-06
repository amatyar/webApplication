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


public partial class Valid_Welcome : System.Web.UI.Page
{
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertIntoApplicantAndAddress();

        Response.Redirect("Image.aspx");
        
    }
        
      

    #region Insert into tbl Applicant and Address
    public void InsertIntoApplicantAndAddress()
    {
        string myUserID = "";

        #region tbl_Applicant
        string firstName = txtFirstName.Text; 
        string lastName = txtLastName.Text; 
        string phone = txtPhone.Text;
        string dob = txtBirthDate.Text; 
        string empName = txtEmployer.Text;
        string empPhone = txtEPhone.Text; 
        string pin = txtPin.Text;
        //Session["First Name"] = firstName;
        //Session["Last Name"] = lastName;
        //Session["4 Digit Pin"] = pin;


        string mySqlApplicant = "Insert Into Applicant (FirstName,LastName,Phone,BirthDate,EmployName,EmployPhone,DigitPin) values ('"+firstName+"','"+lastName+"','"+phone+"','"+dob+"','"+empName+"','"+empPhone+"','"+pin+"')";

        string connString = ConfigurationManager.AppSettings["Conn"].ToString(); // This is a standard way of using connection string in Companies.

        SqlConnection myConn = new SqlConnection(connString);

        SqlCommand myCmd = new SqlCommand(mySqlApplicant, myConn);

        try
        {
            myConn.Open();
            myCmd.ExecuteNonQuery();
            lblMessage.Text = "The insert was successful.";
        }
        catch (Exception)
        {            
            lblMessage.Text = "Insert Failed.";
            throw;
        }
        
        myConn.Close();
        #endregion

        #region Get the userID of the Inserted Applicant
        string mySqlGetUserId = "Select UserID from Applicant where FirstName='"+firstName+"' and LastName='"+lastName+"' and BirthDate='"+dob+"'";

        SqlCommand myCmd1 = new SqlCommand(mySqlGetUserId, myConn);

        try
        {
            myConn.Open();
            SqlDataReader reader = myCmd1.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                myUserID = reader["UserID"].ToString();
                lblMessage1.Text= "The User ID is: " + myUserID;
            }
        }
        catch (Exception)
        {
            lblMessage1.Text = "Not able to get the User ID. Check ur Query.";
            throw;
        }
        myConn.Close();
        #endregion

        #region tbl_Address
        string streetAddress = txtStreet.Text; //"Commonwealth Ave";
        string city = txtCity.Text; //"Allston";
        string county = txtCountry.Text; //"Something";
        string state = txtState.Text; //"MA";
        string zip = txtZipCode.Text; //"02134";

        // Employer Details
        string streetAddressEmp = txtEstreet.Text; //"Commonwealth Ave Emp";
        string cityEmp = txtECity.Text; //"Allston Emp";
        string countyEmp = txtECountry.Text; //"Something Emp";
        string stateEmp = txtEState.Text; //"MA";
        string zipEmp = txtEZipCode.Text; //"02134";
        
       
        string mySqlAddress = "";
        string mySqlAddressApplicant = "Insert into Address (StreetAddress,City,Country,ZipCode,Type,UserID) values ('"+streetAddress+"','"+city+"','"+county+"','"+zip+"','Applicant','"+myUserID+"')";
        string mySqlAddressEmp = "Insert into Address (StreetAddress,City,Country,ZipCode,Type,UserID) values ('" + streetAddressEmp + "','" + cityEmp + "','" + countyEmp + "','" + zipEmp + "','Employer','" + myUserID + "')";

        for (int i = 1; i <= 2; i++)  // i=1 -- Applicant, i=2 -- Employer
        {
            if (i == 1)
            {
                mySqlAddress = mySqlAddressApplicant;
            }
            else
            {
                mySqlAddress = mySqlAddressEmp;
            }
            SqlCommand myCmd2 = new SqlCommand(mySqlAddress,myConn);
            
            try
            {
                myConn.Open();
                myCmd2.ExecuteNonQuery();
            }
            catch (Exception)
            {
                lblMessage2.Text = "Insert to Address Failed.";
                throw;
            }
            myConn.Close();
            clear();
           
        }
        
        #endregion
    }
    #endregion

    #region Update Applicant and Address
    public void update()
    {

        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        string phone = txtPhone.Text;
        string dob = txtBirthDate.Text;
        string empName = txtEmployer.Text;
        string empPhone = txtEPhone.Text;
        string pin = txtPin.Text; 

    string connStr = ConfigurationManager.AppSettings["Conn"].ToString();
    string update1 = "update Applicant set FirstName='"+firstName+"', LastName='"+lastName+"',Phone='"+phone+"',BirthDate='"+dob+"',EmployName='"+empName+"',EmployPhone='"+empPhone+"',DigitPin='"+pin+"' where UserId=@UserID";
    
    SqlConnection myConn = new SqlConnection(connStr);

    SqlCommand myCmd = new SqlCommand(update1, myConn);
  
    myCmd.Parameters.AddWithValue("@UserID", txtUserID.Text);

    try
    {

        myConn.Open();
        myCmd.ExecuteNonQuery();
        lblMessage.Text = "The Update is successful.";
    }
    catch (Exception)
    {
        lblMessage.Text = "the Update is fail";
        throw;

    }

    myConn.Close();

    
    
    #endregion


    #region for address
    string streetAddress = txtStreet.Text; //"Commonwealth Ave";
    string city = txtCity.Text; //"Allston";
    string county = txtCountry.Text; //"Something";
    string state = txtState.Text; //"MA";
    string zip = txtZipCode.Text; //"02134";
    string ur = txtUserID.Text;
    // Employer Details
    string streetAddressEmp = txtEstreet.Text; //"Commonwealth Ave Emp";
    string cityEmp = txtECity.Text; //"Allston Emp";
    string countyEmp = txtECountry.Text; //"Something Emp";
    string stateEmp = txtEState.Text; //"MA";
    string zipEmp = txtEZipCode.Text; //"02134";

    string mySqlAddress = "";
    string mySqlAApp = "update Address set StreetAddress='" + streetAddress + "',City='" + city + "',Country='" + county + "',ZipCode='" + zip + "',State='" + state + "' where Type='Applicant' and UserID='" + ur + "' ";

    string mySqlAEmp = "update Address set StreetAddress='" + streetAddressEmp + "',City='" + cityEmp + "',Country='" + countyEmp + "',ZipCode='" + zipEmp + "',State='" + stateEmp + "' where Type='Employer' and UserID='"+ur+"' ";

    for (int i = 1; i <= 2; i++)
    {
        if (i == 1)
        {
            mySqlAddress = mySqlAEmp;

        }
        else
        {
            mySqlAddress = mySqlAApp;
        }

        SqlCommand Cmd = new SqlCommand(mySqlAddress, myConn);
        
   // Cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);
    

    try
    {
        myConn.Open();
        Cmd.ExecuteNonQuery();

        lblMessage2.Text = "Update to address is Succesful";
    }
    catch (Exception)
    {
        lblMessage2.Text = "Update to Address Failed.";
        throw;
    }
    myConn.Close();
    clear();
    #endregion
    } 
}
    
   
    public void clear()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtPhone.Text = "";
        txtPin.Text = "";
        txtState.Text = "";
        txtStreet.Text = "";
        txtUserID.Text = "";
        txtZipCode.Text = "";
        txtBirthDate.Text = "";
        txtCity.Text = "";
        txtCountry.Text = "";
        txtECity.Text = "";
        txtECountry.Text = "";
        txtEmployer.Text = "";
        txtEPhone.Text = "";
        txtEState.Text = "";
        txtEstreet.Text = "";
        txtEZipCode.Text = "";
           
    }
}

