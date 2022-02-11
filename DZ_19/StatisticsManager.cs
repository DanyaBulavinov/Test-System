using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//====================================
using System.Xml.Linq;
using System.Linq;

namespace Testing
{
    class StatisticsManager
    {
        public void AddUsersTestResult(int sId, int uId, int tId, int score, DateTime date)
        {
            XDocument xdoc = XDocument.Load("Statistics.xml");
            XElement root = xdoc.Element("Statistics");
            var statistics = from ex in root.Elements("Statistic")
                        where ex.Attribute("Id").Value == sId.ToString()
                        select ex;
            if (statistics.Count() == 0)
            {
                root.Add(new XElement("StatisticsItem",
                            new XAttribute("UserId", uId),
                            new XElement("Result",
                                new XAttribute("TestId", tId),
                                new XElement("Score", score),
                                new XElement("Date", date.ToShortDateString()))));
                xdoc.Save("Statistics.xml");
                Console.WriteLine("Statistics created");
            }
            else
            {
                Console.WriteLine("Test exists");
            }
        }
    }
}
