using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPNETWebFormsApplication.Services;
using ASPNETWebFormsApplication.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.ModelBinding;
namespace ASPNETWebFormsApplication
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            productListView.DataSource = GetProducts();
            //productListView.DataBinding += Item_DataBinding;
            productListView.DataBind();
            //DataSet ds = new DataSet();
            /*
             SqlConnection con = new SqlConnection("data source=(local);database=BlogEngine;Integrated Security=true;");
            SqlDataAdapter da = new SqlDataAdapter("select * from Comments", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "FillComent");
            ListView1.DataSource = ds.Tables["FillComent "];
            ListView1.DataBind();
             */
        }
        public void Menu_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "category")
            {
                var item = (Product)e.Item.DataItem;//null because it is in the command (or I just don't know!)
                var row = GetProducts().ToList()[e.Item.DataItemIndex];
                var id = row.ProductName;
                var k = "done!";

                //e.Item.DataBinding += Item_DataBinding;
            }
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        private void Item_DataBinding(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Menu_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var item = (Product)e.Item.DataItem;
            var id = item.ProductID;
            var k = "done!";

            item.Index = e.Item.DataItemIndex + 1;
            e.Item.DataBind();
        }

        #region data
        public IQueryable<string>/*List<string>*/ GetNames()
        {
            return _ = new DefaultServices().GetNames().AsQueryable(); ;
        }
        public IQueryable<Category>/*List<Category>*/ GetCategories()
        {
            return _ = new DefaultServices().GetCategories().AsQueryable();
        }
        public IQueryable<Product>/*List<Product>*/ GetProducts()
        {
            return _ = new DefaultServices().GetProducts().AsQueryable();
        }
        #endregion

        private void BindListView()//I'd name it Bind and modify 2 b dynamic
        {
            //string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS))
            //{
            //    SqlCommand cmd = new SqlCommand("spGetAllCustomers", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    con.Open();
            //    ListView1.DataSource = cmd.ExecuteReader();
            //    ListView1.DataBind();
            //}
        }
    }
}