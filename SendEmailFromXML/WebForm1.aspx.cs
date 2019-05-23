using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace SendEmailFromXML
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<student> li = new List<student>();
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("~/student.xml"));
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Students/student");
            
            foreach(XmlNode node in nodeList)
            {
                student s = new student();

                s.id = Convert.ToInt32(node.SelectSingleNode("id").InnerText);
                s.name = node.SelectSingleNode("name").InnerText;
                s.age = Convert.ToInt32(node.SelectSingleNode("age").InnerText);
                li.Add(s);
            }

            GridView1.DataSource = li;
            GridView1.DataBind();
        }
    }
}