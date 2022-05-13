using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.ClassView;
using HProtest_BLL.Helper;
using System.Data;

public partial class UC_LibraryDetail : System.Web.UI.UserControl
{
    public Library lib = new Library();
    protected void Page_Load(object sender, EventArgs e)
    {
        string pid = Request["pid"].ToString();
        if (!Utility.IsNumeric(pid))
            Response.Redirect("~");
        if (Request["pid"] == null)
        {
            //peygham
            Response.Redirect("Library.aspx");
        }

        HProtest_BLL.Library.LibraryData.IncVisitCountLibrary(int.Parse(pid));

        DataRow dt = HProtest_BLL.Library.LibraryData.GetLibrary(int.Parse(pid));
        if (dt != null)
        {
            lib.ID = int.Parse(pid);
            lib.Title = dt["Title"].ToString();
            lib.Summary = dt["Summary"].ToString();
            lib.Link = dt["Link"].ToString();
            lib.Detail = dt["Detail"].ToString();
            lib.LibraryCategory = dt["LibraryCategory"].ToString();
            lib.Picture = dt["Picture"].ToString();
            lib.Visible = int.Parse(dt["Visible"].ToString());
            lib.DateInput = dt["DateInput"].ToString();
            lib.DateIn = Convert.ToDateTime(dt["DateIn"]);
            lib.VisitCount = int.Parse(dt["VisitCount"].ToString());
            //libraryry.IdLibraryType = int.Parse(dt["IdLibraryType"].ToString());
            lib.FirstName = dt["FirstName"].ToString();
            lib.LastName = dt["LastName"].ToString();
        }
        if (dt == null)
        {
            Response.Redirect("Library.aspx");
        }
    }

    protected void btnMethodTwo_Click(object sender, CommandEventArgs e)
    {
        string fileName = e.CommandArgument.ToString();
        string fileExtension = fileName.Substring(fileName.LastIndexOf('.')) ;
        
        // Set Response.ContentType
        Response.ContentType = GetContentType(fileExtension);

        // Append header
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);

        // Write the file to the Response
        Response.TransmitFile(Server.MapPath("~/Resource/LibraryFiles/" + fileName));
        Response.End();

    }

    private string GetContentType(string fileExtension)
    {
        if (string.IsNullOrEmpty(fileExtension))
            return string.Empty;

        string contentType = string.Empty;
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
                contentType = "text/HTML";
                break;

            case ".txt":
                contentType = "text/plain";
                break;

            case ".doc":
            case ".rtf":
            case ".docx":
                contentType = "Application/msword";
                break;

            case ".xls":
            case ".xlsx":
                contentType = "Application/x-msexcel";
                break;


            case ".pdf":
                contentType = "application/pdf";
                break;
        }

        return contentType;
    }

}