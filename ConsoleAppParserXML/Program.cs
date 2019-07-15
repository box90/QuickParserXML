using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleAppParserXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"";

            ////v1 - http://www.doublecloud.org/2013/08/parsing-xml-in-c-a-quick-working-sample/
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filepath);
            XmlNodeList xmlNodeList = xmlDocument.DocumentElement.SelectNodes("/catalog/book");
            List<Book> books = new List<Book>();

            foreach (XmlNode node in xmlNodeList)
            {
                books.Add(
                    new Book
                    {
                        author = node.SelectSingleNode("author").InnerText,
                        title = node.SelectSingleNode("title").InnerText,
                        id = node.Attributes["id"].Value
                    }
                    );
            }

            foreach (var item in books)
            {
                Console.WriteLine($"{item.author} - {item.title} - {item.id}");
            }




            Console.ReadLine();
        }
    }
}
