using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PVService;
using PVDomain;
using PVData;
using PVUtil;

namespace FINAL
{
    public partial class Login : System.Web.UI.Page
    {
        LogInService logInService;

        string loggedIn;
        long id;

        protected void Page_Load(object sender, EventArgs e)
        {
            logInService = new LogInService();

            if (!Page.IsPostBack)
            {
                
            }
            else
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LogIn logIn = new LogIn(0, 0, "", "", txtUsername.Text.Trim(), txtPassword.Text.Trim());
                IList<LogIn> logIns = logInService.GetLogIn(logIn);

                if (logIns.Count <= 0)
                {
                    lblErrors.Text = "Invalid username or password, please try again.";
                }
                else
                {
                    loggedIn = logIns.ElementAt(0).FullName.ToString();
                    id = Convert.ToInt64(logIns.ElementAt(0).Id.ToString());

                    Session["LoggedIn"] = ("Welcome " + loggedIn + "!");
                    Session["PatronId"] = id;

                    Response.Redirect("Catalog.aspx");
                }
            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
    
        }
    }
}