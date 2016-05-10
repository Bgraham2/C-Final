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
    public partial class AuthorAdmin : System.Web.UI.Page
    {

        AuthorService authorService;

        protected void Page_Load(object sender, EventArgs e)
        {
            authorService = new AuthorService();

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
            InitFormFields();

            Author author = new Author();
            IList<Author> authors = authorService.GetAuthor(author);

            drpExistingAuthors.DataSource = authors;
            drpExistingAuthors.DataBind();

        }

        protected void InitFormFields()
        {

            hdnAuthorId.Value = string.Empty;
            lblErrors.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(drpExistingAuthors.SelectedValue);

            Author author = new Author(id, "", "", "", "");
            IList<Author> authors = authorService.GetAuthor(author);

            hdnAuthorId.Value = Convert.ToString(id);
            txtName.Text = authors.ElementAt(0).Name.ToString();
            txtAddress.Text = authors.ElementAt(0).Address.ToString();
            txtPhone.Text = authors.ElementAt(0).Phone.ToString();
            txtEmail.Text = authors.ElementAt(0).Email.ToString();

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Author author = new Author(0, txtName.Text.Trim(), txtAddress.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim());
                authorService.SaveAuthor(author);

                InitPage();
            }

            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Author author = new Author(Convert.ToInt64(hdnAuthorId.Value), txtName.Text.Trim(), txtAddress.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim());
                authorService.SaveAuthor(author);

                InitPage();
            }

            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
        }
    }
}