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
    public partial class Register : System.Web.UI.Page
    {
        PatronService patronService;

        protected void Page_Load(object sender, EventArgs e)
        {

            patronService = new PatronService();

            if (!Page.IsPostBack)
            {
                InitPage();
            }
            else
            {

            }
        }

        protected void InitPage()
        {

            lblErrors.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Patron patron = new Patron(0, 0, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim(), true);
                patronService.SavePatron(patron);

                InitPage();
            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }

        }
    }
}