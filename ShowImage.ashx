<%@ WebHandler Language="C#" Class="ShowImage" %>

using System;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public class ShowImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        Int32 Appno;
        if (context.Request.QueryString["id"] != null)
            Appno = Convert.ToInt32(context.Request.QueryString["id"]);
        else
            throw new ArgumentException("no parameter specified");
        context.Response.ContentType = "image/jpeg";
        Stream strm = ShowAppImage(Appno);
        byte[] buffer = new byte[4096];
        int byteSeq = strm.Read(buffer, 0, 4096);

        while (byteSeq > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, byteSeq);
            byteSeq = strm.Read(buffer, 0, 4096);
        }
        
        
    }
 
    public Stream ShowAppImage(int Appno)
    {
        string connString = ConfigurationManager.AppSettings["Conn"].ToString();
        //string con = "server=localhost; database=License; integrated security=true";
        SqlConnection connec = new SqlConnection(connString);
        string sql = "select appimg from Applicant1 where Appid= @ID";
        SqlCommand cmd = new SqlCommand(sql, connec);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID", Appno);
        connec.Open();
        object img = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])img);

        }
        catch
        {
            return null;
        }
        finally
        {
            connec.Close();
        }
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}