using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siosolution
{
    public class DataBaseStorageHelper
    {
        public void Save()
        {
            string tb = this.ToString().Replace("siosolution.", "").Replace("Type", "s");
            MysqlCore.DB_Main().NewInsertOrUpdate(this, tb);
        }
        public static void CreateTable(object ExampleObject)
        {
            string tb = ExampleObject.ToString().Replace("siosolution.", "").Replace("Type", "s");
            MysqlCore.DB_Main().CreateTable(ExampleObject, "sio_solution", "id", tb);
        }
      
        public static T Load<T>(int objectID) where T : new()
        {
            string tb = typeof(T).ToString().Replace("siosolution.", "").Replace("Type", "s");
            return MysqlCore.DB_Main().NewGetSingleObject<T>("Select * from `" + tb + "` where id=" + objectID);
        }

        public static List<T> LoadAll<T>() where T : new()
        {
          
            string tb = typeof(T).ToString().Replace("siosolution.", "").Replace("Type", "s");
            return MysqlCore.DB_Main().NewGetObjects<T>("Select * from `" + tb + "`;");
        }
        public static List<T> LoadWhere<T>(string where) where T : new()
        {

            string tb = typeof(T).ToString().Replace("siosolution.", "").Replace("Type", "s");
            return MysqlCore.DB_Main().NewGetObjects<T>("Select * from `" + tb + "` WHERE " + where + ";");
        }






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

            foreach (var p in pi)
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
                
                if(p.PropertyType.Name.ToLower().StartsWith("int"))
                    p.SetValue(this, int.Parse(a));
                if (p.PropertyType.Name.ToLower().StartsWith("string"))
                    p.SetValue(this, a);
                if (p.PropertyType.Name.ToLower().StartsWith("date"))
                    p.SetValue(this, DateTime.Parse(a));
                if (p.PropertyType.Name.ToLower().StartsWith("double"))
                    p.SetValue(this, double.Parse(a));

                this.Save();

            }



        }
    }
}
