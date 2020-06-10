using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using ASPNETWebFormsApplication.Models;
using ASPNETWebFormsApplication.Services;

namespace ASPNETWebFormsApplication
{
    public partial class DataBoundCodeSnippets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //VirtualPathUtility.ToAbsolute("~/ProductsList.aspx?CategoryId=" + Eval("CategoryID"));

            int? Id = Convert.ToInt32(Request.QueryString["id"]);
            DataBoundCodeSnippetsId.DataSource = GetProducts(Id);
            DataBoundCodeSnippetsId.DataBind();
        }
        public List<Product> GetProducts([QueryString("id")] int? Id)
        {
            List<Product> response = null; 
            if (Id != null && Id > 0)
            {
                response = new DefaultServices().GetProducts().Where(p=>p.ProductID == Id).ToList();
            }
            else
            {
                response = new DefaultServices().GetProducts();
            }
            return response;
        }
    }
}