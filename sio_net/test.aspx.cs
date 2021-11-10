using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sio_net
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindshifts();
            }
        }


        void bindshifts()
        {
           // ddlshifts.DataSource = CrewType.Load();
        }

    }
}