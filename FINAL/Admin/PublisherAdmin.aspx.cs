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
    public partial class PublisherAdmin : System.Web.UI.Page
    {
        PublisherService publisherService;

        protected void Page_Load(object sender, EventArgs e)
        {
            publisherService = new PublisherService();

            if(!Page.IsPostBack)
            {
                InitPage();
            }
            else
            {

            }
        }

        protected void InitPage()
        {
            InitFormFields();

            Publisher publisher = new Publisher();
            IList<Publisher> publishers = publisherService.GetPublisher(publisher);

            drpExistingPublishers.DataSource = publishers;
            drpExistingPublishers.DataBind();
        }

        protected void InitFormFields()
        {

            hdnPublisherId.Value = string.Empty;
            lblErrors.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }
        protected void btnEditPublisher_Click(object sender, EventArgs e)
        {

            long id = Convert.ToInt64(drpExistingPublishers.SelectedValue);

            Publisher publisher = new Publisher(id, "", "", "", "");
            IList<Publisher> publishers = publisherService.GetPublisher(publisher);

            hdnPublisherId.Value = Convert.ToString(id);
            txtName.Text = publishers.ElementAt(0).Name.ToString();
            txtAddress.Text = publishers.ElementAt(0).Address.ToString();
            txtPhone.Text = publishers.ElementAt(0).Phone.ToString();
            txtEmail.Text = publishers.ElementAt(0).Email.ToString();

        }

        protected void btnCreatePublisher_Click(object sender, EventArgs e)
        {
            try
            {
                Publisher publisher = new Publisher(0, txtName.Text.Trim(), txtAddress.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim());
                publisherService.SavePublisher(publisher);

                InitPage();
            }

            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
        }

        protected void btnSavePublisher_Click(object sender, EventArgs e)
        {
            try
            {
                Publisher publisher = new Publisher(Convert.ToInt64(hdnPublisherId.Value), txtName.Text.Trim(), txtAddress.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim());
                publisherService.SavePublisher(publisher);

                InitPage();
            }

            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
        }
    }
}