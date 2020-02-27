using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;

namespace QuestionThree
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public int CorrectData()
        {
            var file = "\\InputDocument.xml";

            XDocument xml = XDocument.Load(file);            

            if (!CheckAttr(xml))
            {
                return -1;
            }
            else if(!CheckSiteId(xml))
            {
                return -2;
            }
            else
            {
                return 0;
            }
        }

        public bool CheckAttr(XDocument xml)
        {
            var result = (from q in xml.Descendants("Declaration")
                          select (string)q.Attribute("Command"))

            foreach (var res in result)
            {
                if (result.Contains("DEFAULT"))
                {
                    return true;

                }
                else
                {
                    return false;

                }                 
            }
            return false;
        }

        public bool CheckSiteId(XDocument xml)
        {
            var result = from q in xml.Descendants("DeclarationHeader")
                          select q.Element("SiteID").Value;

            foreach(var res in result)
            {
                System.Diagnostics.Debug.WriteLine(res.Contains("DUB"));
                if (res.Contains("DUB"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
