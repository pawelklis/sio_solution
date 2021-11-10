using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siosolution
{
    public class ControlHelper:DataBaseStorageHelper
    {
        List<System.Web.UI.Control> l { get; set; }
        public TextBox test()
        {
            TextBox tx = new TextBox();
            tx.ID = "tx1";
            tx.Text = "kontrolka";
            return tx;
        }

        public List<System.Web.UI.Control> Controls()
        {
            l = new List<System.Web.UI.Control>();

            PropertyInfo[] pi = this.GetType().GetProperties();
                Panel pn = new Panel();
                pn.ID = this.GetType().ToString();
            pn.CssClass = "editpanel";

            foreach(var p in pi)
            {
                Label lb = new Label();
                lb.ID = "l" + p.Name;
                lb.Text = GetPropertyDisplayName(p);
                lb.CssClass = "editpanellabel";
                pn.Controls.Add(lb);

                TextBox tx = new TextBox();
                tx.ID = p.Name;
                tx.Text = p.GetValue(this).ToString();
                tx.TextChanged += valchange;
                tx.AutoPostBack = true;
                tx.CssClass = "editpaneltx";

                if (p.PropertyType.Name.ToLower() == "DateTime")
                    tx.TextMode = TextBoxMode.DateTime;

                if (p.PropertyType.Name.ToLower().StartsWith("int"))
                    tx.TextMode = TextBoxMode.Number;

                pn.Controls.Add(tx);



                pn.Controls.Add(new LiteralControl("</br>"));
            }
                Button bt = new Button();
                bt.Text = "zapisz";
                bt.Click += valchange;
                pn.Controls.Add(bt);


            l.Add(pn);

            return l;
        }

        private string GetPropertyDisplayName(PropertyInfo pi)
        {
            var dp = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
            return dp != null ? dp.DisplayName : pi.Name;
        }

        void valchange(object sender, EventArgs e)
        {

            if (sender.GetType() == typeof(TextBox))
            {
                TextBox o = (TextBox)sender;
                string a = o.Text;

                PropertyInfo p = this.GetType().GetProperties().ToList().Find(x => x.Name == o.ID);
                p.SetValue(this, a);
                this.Save();

            }



        }

    }
}
