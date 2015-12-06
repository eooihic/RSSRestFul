using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace WebApplication1.Models
{
    public class ItemManager
    {
        public List<Item> getListUrl()
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("http://rss.cnn.com/rss/edition_world.rss");
            //XmlNodeList itemNodes = xmlDoc.SelectNodes("//rss/channel/item");
            //foreach (XmlNode itemNode in itemNodes)
            //{
            //    XmlNode titleNode = itemNode.SelectSingleNode("title");
            //    XmlNode dateNode = itemNode.SelectSingleNode("pubDate");
            //    if ((titleNode != null) && (dateNode != null))
            //        Console.WriteLine(dateNode.InnerText + ": " + titleNode.InnerText);
            //}
            //Console.ReadKey(); 
 

            //string strContent = "";
            //try
            //{
                
            //    WebRequest objWebRequest = WebRequest.Create("http://www.fit.hcmus.edu.vn/vn/");
            //    objWebRequest.Credentials = CredentialCache.DefaultCredentials;
            //    WebResponse objWebResponse = objWebRequest.GetResponse();
            //    Stream receiveStream = objWebResponse.GetResponseStream();
            //    StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
            //    strContent = readStream.ReadToEnd();
            //    objWebResponse.Close();
            //    readStream.Close();
            //}
            //catch (Exception ex)
            //{
            //}

            List<Item> ListItem = new List<Item>();

            HtmlAgilityPack.HtmlDocument hd;
            try
            {
                
                HtmlAgilityPack.HtmlWeb hw = new HtmlAgilityPack.HtmlWeb();
                hd = hw.Load("http://www.fit.hcmus.edu.vn/vn/");
            }
            catch(System.ArgumentException)
            {
                hd = new HtmlAgilityPack.HtmlDocument();
            }
            HtmlNode hn = hd.DocumentNode;
            var articleNodes = hn.SelectNodes("//table[@id='dnn_ctr989_ModuleContent']/tr/td/table");
            foreach(var item in articleNodes)
            {
                Item it = new Item();
                var day = int.Parse(item.SelectSingleNode(".//td[@class='day_month']").InnerHtml);
                var post_year = int.Parse(item.SelectSingleNode(".//td[@class='post_year']").InnerHtml);
                var month = int.Parse(item.SelectSingleNode(".//tr[2]/td[@class='day_month']").InnerHtml);
                it.CreatedAt = new DateTime(post_year, month, day);

                var title = item.SelectSingleNode(".//td[@class='post_title']/a").Attributes["title"].ToString();
                it.Title = title;

                var address = item.SelectSingleNode(".//td[@class='post_title']/a").Attributes["href"].Value.ToString();
                it.Address = address;

                ListItem.Add(it);
            }
            return ListItem;
        }
    }
}