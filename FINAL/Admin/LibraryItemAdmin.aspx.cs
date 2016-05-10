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
    public partial class LibraryItemAdmin : System.Web.UI.Page
    {
        AuthorService authorService;
        PublisherService publisherService;
        DropdownService dropdownService;
        LibraryItemService libraryItemService;
        protected void Page_Load(object sender, EventArgs e)
        {
            authorService = new AuthorService();
            publisherService = new PublisherService();
            dropdownService = new DropdownService();
            libraryItemService = new LibraryItemService();

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
            drpAuthor.DataSource = authors;
            drpAuthor.DataBind();

            Publisher publisher = new Publisher();
            IList<Publisher> publishers = publisherService.GetPublisher(publisher);
            drpPublisher.DataSource = publishers;
            drpPublisher.DataBind();

            LibraryItem libraryItem = new LibraryItem();
            IList<LibraryItem> libraryItems = libraryItemService.GetLibraryItem(libraryItem);
            drpLibraryItems.DataSource = libraryItems;
            drpLibraryItems.DataBind();

            IList<DropDownEntry> lstEntries = dropdownService.GetAllDropDownEntries("item_type");
            drpItemType.DataSource = lstEntries;
            drpItemType.DataBind();
        }

        protected void InitFormFields()
        {
            hdnLibraryTypeId.Value = string.Empty;
            lblErrors.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtISBN.Text = string.Empty;
        }
        protected void btnEditLibraryItems_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(drpLibraryItems.SelectedValue);

            LibraryItem libraryItem = new LibraryItem(id, 0, 0, 0, "", "");
            IList<LibraryItem> libraryItems = libraryItemService.GetLibraryItem(libraryItem);

            hdnLibraryTypeId.Value = Convert.ToString(id);
            drpItemType.SelectedValue = libraryItems.ElementAt(0).ItemTypeId.ToString();
            drpPublisher.SelectedValue = libraryItems.ElementAt(0).PublisherId.ToString();
            drpAuthor.SelectedValue = libraryItems.ElementAt(0).AuthorId.ToString();
            txtTitle.Text = libraryItems.ElementAt(0).Title.ToString();
            txtISBN.Text = libraryItems.ElementAt(0).Isbn.ToString();

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
          try
            {
                LibraryItem libraryItem = new LibraryItem( 0, Convert.ToInt64(drpItemType.SelectedValue), Convert.ToInt64(drpPublisher.SelectedValue), Convert.ToInt64(drpAuthor.SelectedValue), txtTitle.Text.Trim(), txtISBN.Text.Trim());
                libraryItemService.SaveLibraryItem(libraryItem);

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
                LibraryItem libraryItem = new LibraryItem(Convert.ToInt64(hdnLibraryTypeId.Value), Convert.ToInt64(drpItemType.SelectedValue), Convert.ToInt64(drpPublisher.SelectedValue), Convert.ToInt64(drpAuthor.SelectedValue), txtTitle.Text.Trim(), txtISBN.Text.Trim());
                libraryItemService.SaveLibraryItem(libraryItem);

                InitPage();
            }

            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
        }
    }
}