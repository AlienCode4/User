using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApiV5.Models;

namespace WebApiV5.WebPages
{
    public partial class LandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserClass us = new UserClass();

            int dd = us.getID("k@gmail.com");
            newtextbox.Text = Convert.ToString(dd);

        }
    }
}