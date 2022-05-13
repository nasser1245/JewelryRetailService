using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.ClassView;
using HProtest_BLL.Helper;
using System.Data;
using HProtest_BLL;

public partial class HomePage_UC_NewsDetail : System.Web.UI.UserControl
{
    public News news = new News();
    protected void Page_Load(object sender, EventArgs e)
    {
        string pid = Request["pid"].ToString();
        Utility.IsNumeric(pid);
        if (Request["pid"] == null)
        {
            //peygham
            Response.Redirect("News.aspx");
        }
        
        DataRow dt = HProtest_BLL.News.NewsData.GetNews(int.Parse(pid));
        Common.UpdateVisitedNews(int.Parse(pid));
        if (dt != null)
        {
            

            news.ID = int.Parse(pid);
            news.Title = dt["Title"].ToString();
            news.Summary = dt["Summary"].ToString();
            news.Detail = dt["Detail"].ToString();
            news.IdNewsCategory = int.Parse(dt["IdNewsCategory"].ToString());
            news.Picture = dt["Picture"].ToString();
            news.Visible = int.Parse(dt["Visible"].ToString());
            news.DateInput = dt["DateInput"].ToString();
            news.DateIn = Convert.ToDateTime(dt["DateIn"]);
            news.VisitCount = int.Parse(dt["VisitCount"].ToString());
            //news.IdNewsType = int.Parse(dt["IdNewsType"].ToString());
            news.FirstName = dt["FirstName"].ToString();
            news.LastName = dt["LastName"].ToString();

           
        }
        if (dt == null)
        {
            Response.Redirect("News.aspx");
        }

        
    }
}