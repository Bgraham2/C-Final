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
    public partial class CheckedOutItemAdmin : System.Web.UI.Page
    {

        OverDueService overDueService;

        protected void Page_Load(object sender, EventArgs e)
        {

            overDueService = new OverDueService();

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
            OverDue overDue = new OverDue();
            IList<OverDue> overDues = overDueService.GetOverDue(overDue);

            gvOverDue.DataSource = overDues;
            gvOverDue.DataBind();
            
        }
    }
}