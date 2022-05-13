using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL;
using System.Data;
using System.IO;
using System.Xml;
using HProtest_BLL.Opinion;
using System.Web.UI.HtmlControls;

public partial class Main_MasterPage : System.Web.UI.MasterPage
{
    public DataSet ds;
    public DataTable dtAds=null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.IsInRole("4"))
        {
            string Count = HProtest_BLL.Basket.BasketData.GetBasketCount(Page.User.Identity.Name).ToString();
            if (int.Parse(Count) == 0)
                lblBasketCount.Text = "خالی";
            else
                lblBasketCount.Text = Count;
        }
        if (!Page.IsPostBack)
        {
            if (Request.Browser.Crawler == false)
            {
                int AllCurrentCount = 0;
                dtAds = HProtest_BLL.Advertise.AdvertiseData.GetAdvertiseList("", "", DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), 1, -1, 1, "tbAdvertise.Id", "desc", 0, 20, out AllCurrentCount);
                hfHasAdv.Value = "0";
                if (dtAds != null)
                    if (dtAds.Rows != null)
                        if (dtAds.Rows.Count > 0)
                        {
                            hfHasAdv.Value = "1";
                        }
                rptAdsLeftTop.DataSource = dtAds;
                rptAdsLeftTop.DataBind();
                String clientIP =
           (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null) ?
           HttpContext.Current.Request.UserHostAddress :
           HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                int intIP = BitConverter.ToInt32(System.Net.IPAddress.Parse(clientIP).GetAddressBytes(), 0);
                hfHasOpinion.Value = "0";
                ds = OpinionData.getActiveOpinion(intIP);
                if (ds != null)
                    if (ds.Tables[0] != null)
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            rptQuestion.DataSource = ds.Tables[0];
                            rptQuestion.DataBind();
                            hfHasOpinion.Value = "1";
                        }

                ///////////////////////// S I T E   C O U N T E R /////////////////////////////////////////
                int AllViewersCount = 0;
                int IsInRoleCount = 0;
                int CurrentCount = 0;
                System.Data.DataSet tmpDs = new System.Data.DataSet();
                try
                {
                    if (File.Exists(Server.MapPath("~/Resource/counter.xml")))
                    {
                        tmpDs.ReadXml(Server.MapPath("~/Resource/counter.xml"));
                        AllViewersCount = Int32.Parse(tmpDs.Tables[0].Rows[0]["AllViewersCount"].ToString());
                    }
                    else
                    {
                        File.WriteAllText(Server.MapPath("~/Resource/counter.xml"), "<xml></xml>");
                        DataTable dtStatics = new DataTable();
                        dtStatics.Columns.Add("AllViewersCount");
                        tmpDs.Tables.Add(dtStatics);
                        tmpDs.Tables[0].Rows.Add();
                        DataTable dtList = new DataTable();
                        dtList.Columns.Add("IP");
                        dtList.Columns.Add("LastActivity");
                        dtList.Columns.Add("IsInRole");
                        tmpDs.Tables.Add(dtList);
                    }
                    System.Data.DataRow Row = null;
                    for (int i = 0; i < tmpDs.Tables[1].Rows.Count; i++)
                    {
                        DataRow R = tmpDs.Tables[1].Rows[i];
                            if (R["IP"].ToString() == clientIP)
                            {
                                Row = R;
                                if (DateTime.Parse(Row[1].ToString()) < DateTime.Now.AddMinutes(-10))
                                {
                                    AllViewersCount++;
                                }
                                Row["LastActivity"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                if (Page.User.IsInRole("4") == true && Row["IsInRole"].ToString().ToLower() == "false")
                                    Row["IsInRole"] = "true";
                                else if (Page.User.IsInRole("4") == false && Row["IsInRole"].ToString().ToLower() == "true")
                                    Row["IsInRole"] = "false";
                            }
                            else if (DateTime.Parse(R[1].ToString()) < DateTime.Now.AddMinutes(-10))
                            {
                                tmpDs.Tables[1].Rows.Remove(R);
                                i--;
                            }
                            if ((R != null) && (Page.User.IsInRole("4") == true))
                                IsInRoleCount++;

                    }
                    if (Row == null)
                    {
                        tmpDs.Tables[1].Rows.Add(clientIP, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Page.User.IsInRole("4"));
                        if (Page.User.IsInRole("4") == true)
                            IsInRoleCount++;
                        AllViewersCount++;
                    }
                    tmpDs.Tables[0].Rows[0]["AllViewersCount"] = AllViewersCount;
                    CurrentCount = tmpDs.Tables[1].Rows.Count;
                    tmpDs.WriteXml(Server.MapPath("~/Resource/counter.xml"));
                    lblViewersCount.Text = "بازدید تاکنون " + AllViewersCount;
                    lblIsInRoleCount.Text = "اعضا " + IsInRoleCount;
                    lblCurrentCount.Text = "کل افراد حاضر در سایت " + CurrentCount;
                    lblGuestCount.Text = "میهمان " + (CurrentCount - IsInRoleCount);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }

    protected void GetPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/" + (((LinkButton)sender).ID) + ".aspx");

    }
    protected void btnSearchProduct_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Search.aspx?SqFt=" + txtSeachMaster.Text);
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Register.aspx");
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string role = "";
        if ((!string.IsNullOrEmpty(txtUserName.Text) &&
            !string.IsNullOrEmpty(txtPassword.Text)))
        {
            if (MemberChecking.CheckUserPass(Server.HtmlEncode(txtUserName.Text.Trim()), Server.HtmlEncode(txtPassword.Text.Trim())))
            {
                if (MemberChecking.GetMemberStatusID(Server.HtmlEncode(txtUserName.Text.Trim()), out role))
                {
                    if (role == "4")
                    {
                        bool Locked = MemberChecking.IsLocked(txtUserName.Text.Trim());
                        if (Locked)
                        {
                            lblLoginAlert.Text = "حساب کاربری شما مسدود شده است. جهت رفع مشکل با مدیریت سایت تماس بگیرید";
                            return;
                        }
                        else
                        {
                            Response.Cookies.Add(MemberChecking.GetTicket(Server.HtmlEncode(txtUserName.Text.ToLower().Trim()), role));
                            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
                        }
                    }
                }
                else
                {
                    lblLoginAlert.Text = "نام کاربری یا رمز عبور اشتباه می باشد";
                }
            }
            else
            {
                lblLoginAlert.Text = "نام کاربری یا رمز عبور اشتباه می باشد";
            }
        }
        else
        {
            lblLoginAlert.Text = "پر کردن فیلد های نام کاربری و رمز عبور الزامی است";
        }

    }

    protected void lbExit_Click(object sender, EventArgs e)
    {
        System.Web.Security.FormsAuthentication.SignOut();
        Session.Abandon();
        HttpCookie cookie1 = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, "");
        cookie1.Expires = DateTime.Now.AddYears(-1);
        Response.Cookies.Add(cookie1);

        HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
        cookie2.Expires = DateTime.Now.AddYears(-1);
        Response.Cookies.Add(cookie2);
        Response.Redirect("~/Default.aspx");
    }
    public void setBasketCount(string Count)
    {
        if (int.Parse(Count) == 0)
            lblBasketCount.Text = "خالی";
        else
            lblBasketCount.Text = Count;
    }
    protected void rptQuestion_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView row = (DataRowView)e.Item.DataItem;

            Repeater nestedRepeaterRB = e.Item.FindControl("rptPollrb") as Repeater;
            Repeater nestedRepeaterCHK = e.Item.FindControl("rptPollchk") as Repeater;
            Repeater nestedRepeaterAnswer = e.Item.FindControl("rptAnswer") as Repeater;
            HiddenField hfRowNumber = e.Item.FindControl("hfRowNumber") as HiddenField;
            HiddenField hfOpinionID = e.Item.FindControl("hfOpinionID") as HiddenField;
            HiddenField hfIP = e.Item.FindControl("hfIP") as HiddenField;
            if (ds.Tables[int.Parse(hfRowNumber.Value)] != null)
            {
                    if ((Request.Cookies["VoteList"] != null && (Request.Cookies["VoteList"].Value.ToString().IndexOf(hfOpinionID.Value) > 0))
                        || !string.IsNullOrEmpty(hfIP.Value))
                    {
                        Panel pn = (Panel)e.Item.FindControl("pn0");
                        pn.Visible = true;
                        pn = (Panel)e.Item.FindControl("pn1");
                        pn.Visible = false;
                        pn = (Panel)e.Item.FindControl("pn2");
                        pn.Visible = false;
                        Button btn = (Button)e.Item.FindControl("btnSubmit");
                        btn.Visible = false;
                        btn = (Button)e.Item.FindControl("btnShowResult");
                        btn.Visible= false;
                    }
                nestedRepeaterRB.DataSource = ds.Tables[int.Parse(hfRowNumber.Value)];
                nestedRepeaterRB.DataBind();
                nestedRepeaterCHK.DataSource = ds.Tables[int.Parse(hfRowNumber.Value)];
                nestedRepeaterCHK.DataBind();
                nestedRepeaterAnswer.DataSource = ds.Tables[int.Parse(hfRowNumber.Value)];
                nestedRepeaterAnswer.DataBind();
            }
        }
    }

    protected void rptQuestion_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button Clicked = ((Button)e.CommandSource);

        foreach (RepeaterItem ri in rptQuestion.Items)
        {
            Button Butt = (Button)ri.FindControl("btnShowResult");
            if (Butt == Clicked) 
            {
                if (Butt.Text == "نمایش نتایج")
                {
                    Panel pn = (Panel)ri.FindControl("pn0");
                    pn.Visible = true;
                    pn = (Panel)ri.FindControl("pn1");
                    pn.Visible = false;
                    pn = (Panel)ri.FindControl("pn2");
                    pn.Visible = false;
                    Button btn = (Button)ri.FindControl("btnSubmit");
                    btn.Visible = false;
                    btn = (Button)ri.FindControl("btnShowResult");
                    btn.Text = "ثبت رای";
                }else if(Butt.Text == "ثبت رای")
                {
                    Panel pn = (Panel)ri.FindControl("pn0");
                    pn.Visible = false;
                    HiddenField hfShowType = (HiddenField)ri.FindControl("hfShowType");
                    pn = (Panel)ri.FindControl("pn1");
                    pn.Visible = hfShowType.Value.ToLower() == "true" ? true : false;
                    pn = (Panel)ri.FindControl("pn2");
                    pn.Visible = hfShowType.Value.ToLower() == "false" ? true : false;
                    Button btn = (Button)ri.FindControl("btnSubmit");
                    btn.Visible = true;
                    btn = (Button)ri.FindControl("btnShowResult");
                    btn.Text = "نمایش نتایج";
                }
                break;
            }

            Butt = (Button)ri.FindControl("btnSubmit");
            if (Butt == Clicked)
            {
                    HiddenField hfShowType = (HiddenField)ri.FindControl("hfShowType");
                    HiddenField hfOpinionID = (HiddenField)ri.FindControl("hfOpinionID");
                    Repeater rpt;
                    String clientIP =
                        (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null) ?
                        HttpContext.Current.Request.UserHostAddress :
                        HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    int intIP = BitConverter.ToInt32(System.Net.IPAddress.Parse(clientIP).GetAddressBytes(), 0);
                    if (hfShowType.Value.ToLower() == "false")
                    {
                        rpt = (Repeater)ri.FindControl("rptPollrb");
                        RadioButton rbSelected;
                        String VoteList = "";
                        foreach (RepeaterItem rbItem in rpt.Items)
                        {
                            rbSelected = (RadioButton)rbItem.FindControl("rbAnswer");
                            if (rbSelected.Checked == true)
                            {
                                VoteList = ((HiddenField)rbItem.FindControl("hfOptionID")).Value + "|";
                                break;
                            }
                        }
                        if (OpinionTransfer.InsertVoterIP(intIP, VoteList))
                        {
                            if (Request.Cookies["VoteList"] == null)
                            {
                                HttpCookie hc = new HttpCookie("VoteList", ",");
                                hc.Expires = DateTime.Now.AddMonths(1);
                                Response.Cookies.Add(hc);
                            }
                            Request.Cookies["VoteList"].Value = Request.Cookies["VoteList"].Value.ToString() + hfOpinionID.Value + ",";
                            Response.Redirect(Request.RawUrl);
                        }
                        else
                        {
                            //not success
                        }
                    }
                    else
                    {
                        rpt = (Repeater)ri.FindControl("rptPollchk");
                        CheckBox chkSelected;
                        String VoteList = "";
                        foreach (RepeaterItem rbItem in rpt.Items)
                        {
                            chkSelected = (CheckBox)rbItem.FindControl("chkAnswer");
                            if (chkSelected.Checked == true)
                            {
                                VoteList += ((HiddenField)rbItem.FindControl("hfOptionID")).Value + "|";
                            }
                        }
                        if (OpinionTransfer.InsertVoterIP(intIP, VoteList))
                        {
                            if (Request.Cookies["VoteList"] == null)
                            {
                                HttpCookie hc = new HttpCookie("VoteList", ",");
                                hc.Expires = DateTime.Now.AddMonths(1);
                                Response.Cookies.Add(hc);
                            }
                            Response.Cookies["VoteList"].Value = Request.Cookies["VoteList"].Value.ToString() + hfOpinionID.Value + ",";
                            Response.Redirect(Request.RawUrl);
                        }
                        else
                        {
                            //not success
                        }
                    }
                    return;
            }
        }
    }

    protected void rptPollrb_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
        RadioButton rb = (RadioButton)e.Item.FindControl("rbAnswer");
        string script = "SetUniqueRadioButton('rptPollrb.*rbAns',this)";
        rb.Attributes.Add("onclick", script);
    }

    protected void rptAnswer_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
        HtmlGenericControl HA = (HtmlGenericControl)e.Item.FindControl("Progress");
        HiddenField hfPercent = (HiddenField)e.Item.FindControl("hfPercent");
        string style="font-size: 2px; background: #3478E3; text-align:right; height: 18px; width:"+ Math.Round(Convert.ToDouble(hfPercent.Value),2).ToString()+"%;";
        HA.Style.Add("width", Math.Round(Convert.ToDouble(hfPercent.Value), 2).ToString()+ "%");
    }
}
