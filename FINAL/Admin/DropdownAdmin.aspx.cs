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
    public partial class DropdownAdmin : System.Web.UI.Page
    {
        DropdownService dropdownService;
        protected void Page_Load(object sender, EventArgs e)
        {
            dropdownService = new DropdownService();

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

            IList<DropDownEntry> lstEntries = dropdownService.GetAllDropDownEntries("item_type");
            drpLibraryType.DataSource = lstEntries;
            drpLibraryType.DataBind();

            lstEntries = dropdownService.GetAllDropDownEntries("patron_type");
            drpPatronType.DataSource = lstEntries;
            drpPatronType.DataBind();

        }

        protected void InitFormFields()
        {

            hdnPatronTypeId.Value = string.Empty;
            hdnItemTypeId.Value = string.Empty;
            lblLibraryErrors.Text = string.Empty;
            lblPatronErrors.Text = string.Empty;
            txtLibraryItemType.Text = string.Empty;
            txtPatronType.Text = string.Empty;

        }
        protected void btnEditLibraryItem_Click(object sender, EventArgs e)
        {
            hdnItemTypeId.Value = drpLibraryType.SelectedValue;
            txtLibraryItemType.Text = drpLibraryType.SelectedItem.Text;
        }

        protected void btnEditPatronType_Click(object sender, EventArgs e)
        {
            hdnPatronTypeId.Value = drpPatronType.SelectedValue;
            txtPatronType.Text = drpPatronType.SelectedItem.Text;
        }

        protected void btnSaveLibraryItemType_Click(object sender, EventArgs e)
        {
            long id = 0;

            if (hdnItemTypeId.Value.Trim().Length > 0)
            {
                id = Convert.ToInt64(hdnItemTypeId.Value);
            }

            try
            {
                DropDownEntry dropdownEntry = new DropDownEntry(id, txtLibraryItemType.Text.Trim());
                dropdownEntry = dropdownService.SaveDropDownEntry("item_type", dropdownEntry);

                InitPage();
            }
            catch(ApplicationException)
            {
                lblLibraryErrors.Text = "You must enter a description!";
            }


        }

        protected void btnSavePatronType_Click(object sender, EventArgs e)
        {
            long id = 0;

            if (hdnPatronTypeId.Value.Trim().Length > 0)
            {
                id = Convert.ToInt64(hdnPatronTypeId.Value);
            }

            try
            {
                DropDownEntry dropdownEntry = new DropDownEntry(id, txtPatronType.Text.Trim());
                dropdownEntry = dropdownService.SaveDropDownEntry("patron_type", dropdownEntry);

                InitPage();
            }
            catch(ApplicationException)
            {
                lblPatronErrors.Text = "You must enter a description!";
            }
        }
    }
}