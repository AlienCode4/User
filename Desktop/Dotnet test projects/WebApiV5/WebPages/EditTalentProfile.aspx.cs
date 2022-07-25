using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApiV5.WebPages
{
    public partial class EditTalentProfile : System.Web.UI.Page
    {
        int Id2;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id2 = Convert.ToInt32(Request.QueryString["uid"]);


        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("stats.aspx");
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Addvideo.aspx?uid=" + Id2 + "");
        }

        protected void U3_Click(object sender, EventArgs e)
        {

        }
    }
}