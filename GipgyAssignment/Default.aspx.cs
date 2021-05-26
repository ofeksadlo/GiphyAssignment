using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GipgyAssignment
{
    public partial class Default : System.Web.UI.Page
    {
        private GiphyController giphyController;
        protected void Page_Load(object sender, EventArgs e)
        {
            giphyController = new GiphyController();
            getTrendGiphyList();
        }
        
        public async void getTrendGiphyList()
        {
            DataTable table = new DataTable();

            table.Columns.Add("כותרת", Type.GetType("System.String"));
            table.Columns.Add("לינק", Type.GetType("System.String"));

            if (Session["trendTable"] == null)
            {

                await giphyController.FetchGiphy();
                GiphyItem[] giphyItems = giphyController.GiphyItems;

                foreach(GiphyItem giphyItem in giphyItems)
                {
                    DataRow dataRow = table.NewRow();
                    string title = giphyItem.Title;
                    string url = giphyItem.Url;

                    dataRow[0] = title;
                    dataRow[1] = url;

                    table.Rows.Add(dataRow);
                }
                Session["trendTable"] = table;
            }
            else
            {
                table = (DataTable)Session["trendTable"];
            }
            giphyGridView.DataSource = table;
            giphyGridView.DataBind();
        }
        public async void getGiphyListByQuery(string query)
        {
            DataTable table = new DataTable();
            query = query.ToLower();

            table.Columns.Add("כותרת", Type.GetType("System.String"));
            table.Columns.Add("לינק", Type.GetType("System.String"));

            if (Session[query] == null)
            {
                await giphyController.FetchGiphyByQuery(query);
                GiphyItem[] giphyItems = giphyController.GiphyItems;
                if (giphyItems != null)
                {
                    foreach (GiphyItem giphyItem in giphyItems)
                    {
                        DataRow dataRow = table.NewRow();
                        string title = giphyItem.Title;
                        string url = giphyItem.Url;

                        dataRow[0] = title;
                        dataRow[1] = url;

                        table.Rows.Add(dataRow);
                    }
                    Session[query] = table;
                }
            }
            else
            {
                table = (DataTable)Session[query];
            }
            giphyGridView.DataSource = table;
            giphyGridView.DataBind();
        }
        protected void giphyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = string.Format("<a href=\"{0}\"> <img src=\"{0}\" /></a>",  e.Row.Cells[1].Text);
            }
        }

        protected void pickRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickRadioButtonList.SelectedValue == "1")
            {
                queryTextBox.Visible = true;
                if (queryTextBox.Text != "")
                    getGiphyListByQuery(queryTextBox.Text);
            }
            else
                queryTextBox.Visible = false;
        }

        protected void queryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (queryTextBox.Text != "")
                getGiphyListByQuery(queryTextBox.Text);
        }
    }
}