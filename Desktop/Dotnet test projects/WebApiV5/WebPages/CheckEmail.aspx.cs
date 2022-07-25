using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApiV5.Models;

namespace WebApiV5.WebPages
{
    public partial class CheckEmail : System.Web.UI.Page
    {
        UserClass SC= new UserClass();

        string usertype;

        protected void Page_Load(object sender, EventArgs e)
        {
            usertype = Request.QueryString["type"];
            string strId2 = Request.QueryString["err"];
            string strId = Request.QueryString["cemail"];


            if (strId != "" && strId2 != "")
            {
                ErrorLAbel.Text = strId + "\n" + strId2;

            }
            else if (strId2 != "")
            {
                ErrorLAbel.Text = strId;

            }

        }

        protected void btnCheckoutEmail_Click(object sender, EventArgs e)
        {

            if (emailC.Value != "" && password.Value != "" && password2.Value != "")
            {
                if (SC.CheckForEmail(emailC.Value) == true)
                {
                    Response.Redirect("CheckEmail.aspx?err= Email   :  " + emailC.Value + " already registered" + "&&type=" + usertype + "");
                }
                else
                {
                    if (password.Value == password2.Value)
                    {

                        if (usertype.Equals("talent"))

                            Response.Redirect("RegisterUser.aspx?pass=" + password2.Value + "&&cemail=" + emailC.Value + "" + "&&type=" + usertype + "");
                        else if (usertype.Equals("admin"))
                        {
                           

                        }

                    }
                    else
                    {
                        Response.Redirect("CheckEmail.aspx?err=Passwords don't match&&cemail=" + emailC.Value + "" + "&&type=" + usertype + "");
                    }

                }

            }

        }
    }
}