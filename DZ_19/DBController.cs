using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace Testing
{
    static class DBController
    {
        static public void CreateDB()
        {
            //Создание файлов с их структурами
            CreateStatDB();
            CreateUserDB();
            CreateTestDB();
            CreateQuestionDB();
        }

        static private void CreateStatDB()
        {
            XDocument xdoc = new XDocument(new XElement("Statistics"));
            xdoc.Save("Statistics.xml");
        }

        static private void CreateUserDB()
        {
            XDocument xdoc = new XDocument(new XElement("Users"));
            xdoc.Save("Users.xml");
        }

        static private void CreateTestDB()
        {
            XDocument xdoc = new XDocument(new XElement("Tests"));
            xdoc.Save("Tests.xml");
        }

        static private void CreateQuestionDB()
        {
            XDocument xdoc = new XDocument(new XElement("Questions"));
            xdoc.Save("Questions.xml");
        }
    }
}
