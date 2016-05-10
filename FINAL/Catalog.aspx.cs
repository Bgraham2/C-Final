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
    public partial class Catalog : System.Web.UI.Page
    {
        DropdownService dropdownService;
        PublisherService publisherService;
        LibraryItemService libraryItemService;
        AuthorService authorService;
        CheckOutService checkOutService;
        CheckedOutService checkedOutService;
        protected void Page_Load(object sender, EventArgs e)
        {

            authorService = new AuthorService();
            publisherService = new PublisherService();
            dropdownService = new DropdownService();
            libraryItemService = new LibraryItemService();
            checkOutService = new CheckOutService();
            checkedOutService = new CheckedOutService();

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

            FilterDropDowns();

            if (Session["patronID"] == null)
            {

                btnCheckOut.Visible = false;

            }

            CheckedOut checkedOut = new CheckedOut(Convert.ToInt64(Session["PatronId"]));
            IList<CheckedOut> checkedOuts = checkedOutService.GetCheckedOut(checkedOut);
            gvCheckedOut.DataSource = checkedOuts;
            gvCheckedOut.DataBind();

        }

        protected void FilterDropDowns()
        {

            Author author = new Author();
            IList<Author> authors = authorService.GetAuthor(author);
            drpAuthors.DataSource = authors;
            drpAuthors.DataBind();
            drpAuthors.Items.Insert(0, "--All Authors");
            //drpAuthors.SelectedValue = Convert.ToString(0); 

            Publisher publisher = new Publisher();
            IList<Publisher> publishers = publisherService.GetPublisher(publisher);
            drpPublishers.DataSource = publishers;
            drpPublishers.DataBind();
            drpPublishers.Items.Insert(0, "--All Publishers--");
            //drpPublishers.SelectedValue = Convert.ToString(0); 

            LibraryItem libraryItem = new LibraryItem();
            IList<LibraryItem> libraryItems = libraryItemService.GetLibraryItem(libraryItem);
            drpExistingItems.DataSource = libraryItems;
            drpExistingItems.DataBind();

            IList<DropDownEntry> lstEntries = dropdownService.GetAllDropDownEntries("item_type");
            drpItemTypes.DataSource = lstEntries;
            drpItemTypes.DataBind();
            drpItemTypes.Items.Insert(0, "--All Types--");
            

        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LibraryItem libraryItem = new LibraryItem(0, Convert.ToInt64(drpItemTypes.SelectedIndex), Convert.ToInt64(drpPublishers.SelectedIndex), Convert.ToInt64(drpAuthors.SelectedIndex), "", "");
            IList<LibraryItem> libraryItems = libraryItemService.GetLibraryItem(libraryItem);

            if (libraryItems.Count <= 0)
            {
                drpExistingItems.Items.Clear();
                drpExistingItems.Items.Insert(0, "No items found");
            }
            else
            {
                drpExistingItems.DataSource = libraryItems;
                drpExistingItems.DataBind();
            }

          
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {

            CheckOut checkOut = new CheckOut(0, Convert.ToInt64(drpExistingItems.SelectedValue), Convert.ToInt64(Session["PatronId"]));
            checkOutService.SaveCheckOut(checkOut);

            InitPage();

        }

        protected void gvCheckedOut_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CheckIn")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                long id = Convert.ToInt64(gvCheckedOut.Rows[row].Cells[0].Text);

                CheckOut checkOut = new CheckOut(id);
                checkOutService.SaveCheckOut(checkOut);

                InitPage();
            }
        }


    }
}