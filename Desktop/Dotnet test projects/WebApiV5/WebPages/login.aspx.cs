using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApiV5.DatabaseLinks;
using WebApiV5.Models;

namespace WebApiV5.WebPages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserClass users = new UserClass();


            if(Email.Text !=null && password.Value != null)
            {
                bool login = users.Login(Email.Text, password.Value);


                if (login == true)
                {
                    string usertype=users.getUserType(Email.Text);

                    if(usertype.Equals("admin"))
                    {
                        Response.Redirect("AdminStartPage.aspx");
                    }

                    if (usertype.Equals("talent"))
                    {
                        Response.Redirect("TalentStartPage.aspx");
                    }
                }

            }
           
        }
    }
}