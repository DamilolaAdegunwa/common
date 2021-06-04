using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext httpContext;
        }
        public string htmlstr()
        {
            return "<span><b>Some HTML here</b></span>";
        }
    }
}