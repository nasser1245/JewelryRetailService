using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Basket;
using System.Web.Services;
using System.Data;

public partial class BuyBasket : System.Web.UI.Page
{

    public bool NullBasket;
    public bool NullGift = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.IsInRole("4"))
        {
            Response.Redirect("~/default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                int BasketID;
                string GiftName= "";
                string UserName = Page.User.Identity.Name;
                DataSet ds = BasketData.GetBasketProduct(UserName, out BasketID);
                RepeaterBuyBasket.DataSource = ds.Tables[1];
                RepeaterBuyBasket.DataBind();

                hfBasketID.Value = BasketID.ToString();

                if (RepeaterBuyBasket.Items.Count < 1)
                {
                    NullBasket = true;
                    BasketTransfer.SelectGift(hfBasketID.Value.ToString());
                }
                else
                {
                    NullBasket = false;
                    lblGetCountTotal.Text = ds.Tables[0].Rows[0]["TotalCount"].ToString();
                    lblGetPiceTotal.Text = ds.Tables[0].Rows[0]["TotalSum"].ToString();
                    GiftName = (ds.Tables[2].Rows.Count == 0) ? "" : ds.Tables[2].Rows[0]["GiftName"].ToString();
                    txtDescription.Text = (ds.Tables[3].Rows.Count == 0) ? "" : ds.Tables[3].Rows[0]["Description"].ToString();
                    RepeaterDisplayGift.DataSource = BasketData.GetGiftList(int.Parse(lblGetPiceTotal.Text));
                    RepeaterDisplayGift.DataBind();
                    if (RepeaterDisplayGift.Items.Count < 1)
                    {
                        NullGift = true;
                        BasketTransfer.SelectGift(hfBasketID.Value.ToString());
                        lblGiftName.Text = "";
                    }
                    if(!string.IsNullOrEmpty(GiftName))
                        lblGiftName.Text = GiftName + " به عنوان اشانتیون شما انتخاب شده است";
                }
            }
            else
            {
            }
        }
    }

    protected void RepeaterBuyBasket_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropDownList ddl = (DropDownList)(e.Item.FindControl("dd"));
        int t = int.Parse(((HiddenField)(e.Item.FindControl("hfRemain"))).Value);
        int Selected = int.Parse(((HiddenField)(e.Item.FindControl("hfCount"))).Value);
        ListItem l = new ListItem("1", "1");
        ddl.Items.Add(l);
        for (int i = 2; i <= t && i < 11; i++)
        {
            l = new ListItem(i.ToString(), i.ToString());
            ddl.Items.Add(l);
            if (Selected == i)
                ddl.SelectedIndex = i - 1;
        }
    }

    public void DeleteProductFromList_Command(object sender, CommandEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
        {
            string Count = BasketTransfer.DeleteBasketProduct(int.Parse(e.CommandArgument.ToString()));
            if (int.Parse(Count) >= 0)
                ((Main_MasterPage)this.Page.Master).setBasketCount(Count);
        }
        UpdateBasketGrid();

    }

    public void SelectGift_Command(object sender, CommandEventArgs e)
    {

        string[] fields = e.CommandArgument.ToString().Split(',');
        string ID = fields[0];
        string Name = fields[1];
        if (!string.IsNullOrEmpty(ID))
        {
            if(BasketTransfer.SelectGift(hfBasketID.Value.ToString(), int.Parse(ID)))
                lblGiftName.Text = Name + " به عنوان اشانتیون شما انتخاب شد";

        }
        

    }

    protected void btnPishFactor_Click(object sender, EventArgs e)
    {
        string UpdateString = "";
        foreach (var eachItem in RepeaterBuyBasket.Items)
        {
            UpdateString += ((HiddenField)((eachItem as RepeaterItem).FindControl("hfID"))).Value.ToString() + ',';
            UpdateString += ((DropDownList)((eachItem as RepeaterItem).FindControl("dd"))).SelectedValue.ToString() + '|';
        }
        BasketTransfer.UpdateBasketProductCount(UpdateString, txtDescription.Text);
        Response.Redirect("~/FactorDisplay.aspx");
    }

    protected void btnMoreBuy_Click(object sender, EventArgs e)
    {
        string UpdateString = "";
        foreach (var eachItem in RepeaterBuyBasket.Items)
        {
            UpdateString += ((HiddenField)((eachItem as RepeaterItem).FindControl("hfID"))).Value.ToString() + ',';
            UpdateString += ((DropDownList)((eachItem as RepeaterItem).FindControl("dd"))).SelectedValue.ToString() + '|';
        }
        BasketTransfer.UpdateBasketProductCount(UpdateString, txtDescription.Text);
        Response.Redirect("~/Default.aspx");
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UpdateBasketGrid();
    }

    protected void UpdateBasketGrid()
    {
        string UpdateString = "";
        foreach (var eachItem in RepeaterBuyBasket.Items)
        {
            UpdateString += ((HiddenField)((eachItem as RepeaterItem).FindControl("hfID"))).Value.ToString() + ',';
            UpdateString += ((DropDownList)((eachItem as RepeaterItem).FindControl("dd"))).SelectedValue.ToString() + '|';
        }
        int BasketID;
        string GiftName = "";
        DataSet ds = BasketData.GetBasketProduct(Page.User.Identity.Name, out BasketID, UpdateString,txtDescription.Text);
        RepeaterBuyBasket.DataSource = ds.Tables[1];
        RepeaterBuyBasket.DataBind();
        if (RepeaterBuyBasket.Items.Count > 0)
        {
            lblGetCountTotal.Text = ds.Tables[0].Rows[0]["TotalCount"].ToString();
            lblGetPiceTotal.Text = ds.Tables[0].Rows[0]["TotalSum"].ToString();
            GiftName = (ds.Tables[2].Rows.Count == 0) ? "" : ds.Tables[2].Rows[0]["GiftName"].ToString();
            txtDescription.Text = (ds.Tables[3].Rows.Count == 0) ? "" : ds.Tables[3].Rows[0]["Description"].ToString(); 
            RepeaterDisplayGift.DataSource = BasketData.GetGiftList(int.Parse(lblGetPiceTotal.Text));
            RepeaterDisplayGift.DataBind();
            if (RepeaterDisplayGift.Items.Count < 1)
            {
                NullGift = true;
                BasketTransfer.SelectGift(hfBasketID.Value.ToString());
                lblGiftName.Text = "";
            }
            if (!string.IsNullOrEmpty(GiftName))
                lblGiftName.Text = GiftName + " به عنوان اشانتیون شما انتخاب شده است";
            else
                lblGiftName.Text = GiftName + "";


        }
        else
        {
            NullBasket = true;
            BasketTransfer.SelectGift(hfBasketID.Value.ToString());
        }
    }
    protected void btnPayOffline_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RegFiche.aspx");
    }
}