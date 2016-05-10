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

namespace FINAL.Admin
{
    public partial class PatronAdmin : System.Web.UI.Page
    {
        PatronService patronService;
        DropdownService dropdownService;
        protected void Page_Load(object sender, EventArgs e)
        {
            patronService = new PatronService();
            dropdownService = new DropdownService();

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
            InitFormField();

            Patron patron = new Patron();
            IList<Patron> patrons = patronService.GetPatrons(patron);
            drpExistingPatrons.DataSource = patrons;
            drpExistingPatrons.DataBind();

            IList<DropDownEntry> lstEntries = dropdownService.GetAllDropDownEntries("patron_type");
            drpPatronType.DataSource = lstEntries;
            drpPatronType.DataBind();

        }

        protected void InitFormField()
        {
            lblErrors.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            hdnPartonId.Value = string.Empty;
        }

        protected void btnEditPatron_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(drpExistingPatrons.SelectedValue);

            Patron patron = new Patron(id, 0, "", "", "", "");
            IList<Patron> patrons = patronService.GetPatrons(patron);

            hdnPartonId.Value = Convert.ToString(id);
            drpPatronType.SelectedValue = patrons.ElementAt(0).PatronTypeId.ToString();
            txtFirstName.Text = patrons.ElementAt(0).FirstName.ToString();
            txtLastName.Text = patrons.ElementAt(0).LastName.ToString();
            txtUsername.Text = patrons.ElementAt(0).Username.ToString();
            txtPassword.Text = patrons.ElementAt(0).Password.ToString();
            txtPhone.Text = patrons.ElementAt(0).Phone.ToString();
            txtEmail.Text = patrons.ElementAt(0).Email.ToString();

            if (Convert.ToBoolean(patrons.ElementAt(0).Active.ToString()) == true)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }

        }
        protected void btnCreatePatron_Click(object sender, EventArgs e)
        {
            try
            {
                bool active;

                if (chkActive.Checked == true)
                {
                    active = true;
                }
                else
                {
                    active = false;
                }

                Patron patron = new Patron(0, Convert.ToInt64(drpPatronType.SelectedValue),txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim(), active);
                patronService.SavePatron(patron);

                InitPage();
            }

            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
        }

        protected void btnSavePatron_Click(object sender, EventArgs e)
        {
            try
            {
                bool active;

                if (chkActive.Checked == true)
                {
                    active = true;
                }
                else
                {
                    active = false;
                }

                Patron patron = new Patron(Convert.ToInt64(drpExistingPatrons.SelectedValue), Convert.ToInt64(drpPatronType.SelectedValue), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim(), active);
                patronService.EditPatron(patron);

                InitPage();
            }

            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
        }
    }
}