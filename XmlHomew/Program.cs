using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlHomew
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            XmlDocument document = new XmlDocument();
            document.Load("https://habr.com/ru/rss/interesting/");

            foreach (XmlElement rootElement in document.GetElementsByTagName("item"))
            {
                Item item = new Item();
                foreach (XmlElement element in rootElement.ChildNodes)
                {
                    //if (element.Name == "title")
                    //{
                    //    item.Title = element.InnerText;
                    //}
                    //else if (element.Name == "link")
                    //{
                    //    item.Link = element.InnerText;
                    //}
                    //else if (element.Name == "description")
                    //{
                    //    item.Description = element.InnerText;
                    //}
                    //else if (element.Name == "pubDate")
                    //{
                    //    item.PubDate = DateTime.Parse(element.InnerText);
                    //}
                    XmlElement titleElement = element.GetElementsByTagName("title")[0] as XmlElement;
                    XmlElement linkElement = element.GetElementsByTagName("link")[0] as XmlElement;
                    XmlElement descriptionElement = element.GetElementsByTagName("description")[0] as XmlElement;
                    XmlElement pubDateElement = element.GetElementsByTagName("pubDate")[0] as XmlElement;
                    item.Title = titleElement.InnerText;
                    item.Link = linkElement.InnerText;
                    item.Description = descriptionElement.InnerText;
                    item.PubDate = DateTime.Parse(pubDateElement.InnerText);
                    items.Add(item);
                }
            }
            int i = 0;
            foreach (Item item in items)
            {
                Console.WriteLine(items[i].Title);
                Console.WriteLine(items[i].Link);
                Console.WriteLine(items[i].Description);
                Console.WriteLine(items[i].PubDate);
                Console.WriteLine("-------------------------------------------------------");
                i++;
            }
            Console.ReadKey();
        }
    }
}
