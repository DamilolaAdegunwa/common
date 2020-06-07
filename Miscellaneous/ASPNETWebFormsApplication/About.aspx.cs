using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPNETWebFormsApplication.Services;
using ASPNETWebFormsApplication.Models;
namespace ASPNETWebFormsApplication
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            productListView.DataSource = GetProducts();
            productListView.DataBinding += Item_DataBinding;
            productListView.DataBind();

        }
        public void Menu_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "category")
            {
                var item = (Product)e.Item.DataItem;//null because it is in the command (or I just don't know!)
                var row = GetProducts()[e.Item.DataItemIndex];
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
        public List<string> GetNames()
        {
            return _ = new DefaultServices().GetNames();
        }
        public List<Category> GetCategories()
        {
            return _ = new DefaultServices().GetCategories();
        }
        public List<Product> GetProducts()
        {
            return _ = new DefaultServices().GetProducts();
        }
        #endregion
    }
}