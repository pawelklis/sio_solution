
using siosolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sio_wnet
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            else
            {
                           

            }
bindshifts();
        }

        protected override void OnUnload(EventArgs e)
        {


          

        }
        void bindshifts()
        {
            List<ShiftType> l =ShiftType.LoadAll<ShiftType>();


            foreach(var t in l[0].Controls())
            {
                this.Panel1.Controls.Add(t);
            }

           

            ddlshifts.DataSource = l;
            ddlshifts.DataTextField = "Name";
            ddlshifts.DataValueField = "Id";
            ddlshifts.DataBind();

      


        }
    }
}