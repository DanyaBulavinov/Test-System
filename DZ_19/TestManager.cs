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
    class TestManager
    {
        public void CreateTest(int id, string name, string auth, Difficult dif, double passingScore, string category, string desc)
        {
            XDocument xdoc = XDocument.Load("Tests.xml");
            XElement root = xdoc.Element("Tests");
            var tests = from ex in root.Elements("Test")
                        where ex.Attribute("Id").Value == id.ToString() && ex.Element("Name").Value == name
                        select ex;
            if(tests.Count() == 0)
            {
                root.Add(new XElement("Test",
                    new XAttribute("Id", id),
                        new XElement("Name", name),
                        new XElement("Author", auth),
                        new XElement("Difficult", dif),
                        new XElement("PassingScore", passingScore),
                        new XElement("Category", category),
                        new XElement("Description", desc)));
                xdoc.Save("Tests.xml");
                Console.WriteLine("Test created");
            }
            else
            {
                Console.WriteLine("Test exists");
            }
        }

        public void RenameTest(int testId, string newName)
        {
            XDocument xdoc = XDocument.Load("Tests.xml");
            XElement root = xdoc.Element("Tests");
            var test = from ex in root.Elements("Test")
                       where ex.Attribute("Id").Value == testId.ToString()
                       select ex;
            if (test.Count() > 0)
            {
                test.ToList().First().Element("Name").Value = newName;
                xdoc.Save("Tests.xml");
                Console.WriteLine("Name updated");
            }
            else
            {
                Console.WriteLine("Test not found");
            }
        }

        public void EditTest(int id)
        {
            int menu = -1;
            XDocument xdoc = XDocument.Load("Tests.xml");
            XElement root = xdoc.Element("Tests");
            var test = from ex in root.Elements("Test")
                       where ex.Attribute("Id").Value == id.ToString()
                       select ex;
            if (test.Count() > 0)
            {
                while (menu != 0)
                {
                    Console.WriteLine("1 - Change name");
                    Console.WriteLine("2 - Change author");
                    Console.WriteLine("3 - Change difficulty");
                    Console.WriteLine("4 - Change passing score");
                    Console.WriteLine("5 - Change category");
                    Console.WriteLine("6 - Change description");
                    Console.WriteLine(">>>");
                    menu = Convert.ToInt32(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            Console.Write("New name: ");
                            string name = Console.ReadLine();
                            test.First().Element("Name").Value = name;
                            Console.WriteLine("Name changed");
                            Console.WriteLine("--------------------------");

                            break;
                        case 2:
                            Console.Write("New author: ");
                            string author = Console.ReadLine();
                            test.First().Element("Author").Value = author;
                            Console.WriteLine("Author changed");
                            Console.WriteLine("--------------------------");
                            break;
                        case 3:
                            Console.WriteLine("New difficulty: ");
                            int menu2 = -1;
                            Console.WriteLine("1 - Easy");
                            Console.WriteLine("2 - Medium");
                            Console.WriteLine("3 - Hard");
                            Console.WriteLine(">>>");
                            menu2 = Convert.ToInt32(Console.ReadLine());
                            switch (menu2)
                            {
                                case 1:
                                    test.First().Element("Difficult").Value = Difficult.Easy.ToString();
                                    break;
                                case 2:
                                    test.First().Element("Difficult").Value = Difficult.Medium.ToString();
                                    break;
                                case 3:
                                    test.First().Element("Difficult").Value = Difficult.Hard.ToString();
                                    break;
                            }
                            Console.WriteLine("Difficulty changed");
                            Console.WriteLine("--------------------------");
                            break;
                        case 4:
                            Console.Write("New passing score: ");
                            string ps = Console.ReadLine();
                            test.First().Element("PassingScore").Value = ps;
                            Console.WriteLine("Passing Score changed");
                            Console.WriteLine("--------------------------");
                            break;
                        case 5:
                            Console.Write("New category: ");
                            string category = Console.ReadLine();
                            test.First().Element("Category").Value = category;
                            Console.WriteLine("Category changed");
                            Console.WriteLine("--------------------------");
                            break;
                        case 6:
                            Console.Write("New description: ");
                            string description = Console.ReadLine();
                            test.First().Element("Description").Value = description;
                            Console.WriteLine("Description changed");
                            Console.WriteLine("--------------------------");
                            break;
                    }
                }

                xdoc.Save("Tests.xml");
            }
            else
            {
                Console.WriteLine("Test not found");
            }
        }

        public void AddQuestion(int idTest, int idQ, string text, Difficult dif)
        {
            XDocument xdoc = XDocument.Load("Questions.xml");
            XElement root = xdoc.Element("Questions");
            var questions = from ex in root.Elements("Question")
                            where ex.Attribute("Id").Value == idQ.ToString()
                            select ex;
            if (questions.Count() == 0)
            {
                root.Add(new XElement("Question",
                        new XAttribute("Id", idQ),
                            new XElement("IdTest", idTest),
                            new XElement("Text", text),
                            new XElement("Answers"),
                            new XElement("Diffculty", dif)));
                xdoc.Save("Questions.xml");
                Console.WriteLine("Test added!");
            }
            else
                Console.WriteLine("Question allready exists!!!");
        }

        public void AddAnswer(int idQ, string text, bool isRight)
        {
            XDocument xdoc = XDocument.Load("Questions.xml");
            XElement root = xdoc.Element("Questions");
            var questions = from ex in root.Elements("Question")
                            where ex.Attribute("Id").Value == idQ.ToString()
                            select ex;
            if(questions.Count() > 0)
            {
                questions.ToList().First().Element("Answers").Add(new XElement("Answer",
                                                                        new XElement("Text", text),
                                                                        new XElement("IsRight", isRight)));
                xdoc.Save("Questions.xml");
                Console.WriteLine("Answer added");
            }
            else
            {
                Console.WriteLine("Question not found");
            }
        }

        public void DeleteAnswer(int qId, int aId)
        {
            XDocument xdoc = XDocument.Load("Questions.xml");
            XElement root = xdoc.Element("Questions");
            var answers = from ex in root.Elements("Question")
                           where ex.Attribute("Id").Value == qId.ToString()
                           select ex.Element("Answers").Element("Answer");
            if (answers.Count() > 0)
            {
                answers.ToList().ElementAt(aId - 1).Remove();
                xdoc.Save("Questions.xml");
                Console.WriteLine("Answer deleted");
            }
            else
            {
                Console.WriteLine("Question or answers not found");
            }
        }

        public void DeleteQuestion(int qId)
        {
            XDocument xdoc = XDocument.Load("Questions.xml");
            XElement root = xdoc.Element("Questions");
            var question = from ex in root.Elements("Question")
                           where ex.Attribute("Id").Value == qId.ToString()
                           select ex;
            if(question.Count() > 0)
            {
                question.Remove();
                xdoc.Save("Questions.xml");
                Console.WriteLine("Question deleted");
            }
            else
            {
                Console.WriteLine("Question not found");
            }
        }

        public void DeleteTest(int tId)
        {
            XDocument xdoc = XDocument.Load("Tests.xml");
            XElement root = xdoc.Element("Tests");
            var test = from ex in root.Elements("Test")
                       where ex.Attribute("Id").Value == tId.ToString()
                       select ex;
            if(test.Count() > 0)
            {
                test.Remove();
                xdoc.Save("Tests.xml");
                Console.WriteLine("Test deleted");
            }
            else
            {
                Console.WriteLine("Test not found");
            }
        }

        public void PrintAllTestNames()
        {
            XDocument xdoc = XDocument.Load("Tests.xml");
            XElement root = xdoc.Element("Tests");
            var tests = from ex in root.Elements("Test")
                        select ex;
            foreach(var item in tests)
            {
                Console.WriteLine(item.Element("Name").Value);
            }
            Console.WriteLine("==================================");
        }

        public void GetAllTestsByCategory(string category)
        {
            XDocument xdoc = XDocument.Load("Tests.xml");
            XElement root = xdoc.Element("Tests");
            var tests = from ex in root.Elements("Test")
                        where ex.Element("Category").Value == category
                        select ex;
            foreach(var item in tests)
            {
                Console.WriteLine("Id: " + item.Attribute("Id").Value);
                Console.WriteLine("Name: " + item.Element("Name").Value);
                Console.WriteLine("Author: " + item.Element("Author").Value);
                Console.WriteLine("Difficulty: " + item.Element("Difficult").Value);
                Console.WriteLine("Passing score: " + item.Element("PassingScore").Value);
                Console.WriteLine("Description: " + item.Element("Description").Value);
                Console.WriteLine("--------------------------");
            }
            Console.WriteLine("==================================");
        }

        public void PrintTestInfo(int id)
        {
            XDocument xdoc = XDocument.Load("Tests.xml");
            XElement root = xdoc.Element("Tests");
            var test = from ex in root.Elements("Test")
                        where ex.Attribute("Id").Value == id.ToString()
                        select ex;
            if(test.Count() > 0)
            {
                Console.WriteLine("Id: " + test.ToList().First().Attribute("Id").Value);
                Console.WriteLine("Name: " + test.ToList().First().Element("Name").Value);
                Console.WriteLine("Author: " + test.ToList().First().Element("Author").Value);
                Console.WriteLine("Difficulty: " + test.ToList().First().Element("Difficult").Value);
                Console.WriteLine("Passing score: " + test.ToList().First().Element("PassingScore").Value);
                Console.WriteLine("Description: " + test.ToList().First().Element("Description").Value);
                Console.WriteLine("==================================");
            }
            else
            {
                Console.WriteLine("Test not found");
            }
        }

        /*public Test UploadTest(int id)
        {
            XDocument xdoc = XDocument.Load("Tests.xml");
            XElement root = xdoc.Element("Tests");

            var tests = from ex in root.Elements("Test")
                        where ex.Attribute("Id").Value == id.ToString()
                        select ex;

            XDocument xdoc1 = XDocument.Load("Questions.xml");
            XElement root1 = xdoc.Element("Questions");

            var quests = from ex in root1.Elements("Question")
                         where ex.Element("IdTest").Value == id.ToString()
                         select ex;

            if (tests.Count() > 0 && quests.Count() > 0)
            {
                List<Questions> listQuests = new List<Questions>();

                foreach (var q in quests.ToList())
                {
                    Questions oneQuest = new Questions();

                    oneQuest.id = Convert.ToInt32(q.Attribute("Id").Value);
                    oneQuest.text = q.Element("Text").Value;

                    foreach (var ans in q.Element("Answers").Elements("Answer"))
                    {
                        Answer answer = new Answer();

                        answer.Text = ans.Element("Text").Value;
                        answer.Is_correct = Convert.ToBoolean(ans.Element("IsRight").Value);

                        oneQuest.Add_answer(answer);
                    }
                    listQuests.Add(oneQuest);
                }

                Test test = new Test();
                test.id = Convert.ToInt32(tests.ToList().First().Attribute("Id").Value);
                test.Title = tests.ToList().First().Element("Name").Value;
                test.Author_id = Convert.ToInt32(tests.ToList().First().Element("AuthorId").Value);
                test.Description = tests.ToList().First().Element("Description").Value;
                test.Category = tests.ToList().First().Element("Category").Value;
                test.PassingScore = Convert.ToDouble(tests.ToList().First().Element("PassingScore").Value);
                test.Diff_level = (Difficulty_level)Convert.ToInt32(tests.ToList().First().Element("Difficult").Value);
                test.Questions = listQuests;

                Console.WriteLine("test uploded");
                return test;
            }

            return null;
        }*/
    }
}
