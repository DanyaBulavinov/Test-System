using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //DBController.CreateDB();

            UserManager um = new UserManager();
            //um.CreateUser(1, "Petya", "qwerty");
            //um.CreateUser(2, "Vasya", "qwerty123");

            //um.ChangePassword(1, "qwerty", "zxcv");

            TestManager tm = new TestManager();
            //tm.CreateTest(3, "Test3", "Grisha", Difficult.Hard, 80, "Sport", "Test about sport");
            //tm.AddQuestion(1, 1, "2 + 2 = ?", Difficult.Easy);
            //tm.AddAnswer(1, "4", false);

            //tm.RenameTest(1, "Renamed");

            tm.DeleteAnswer(1, 1);

            //tm.DeleteQuestion(1);

            //tm.DeleteTest(1);

            //tm.PrintAllTestNames();

            //tm.GetAllTestsByCategory("Sport");

            //tm.PrintTestInfo(2);

            //tm.EditTest(1);

            StatisticsManager sm = new StatisticsManager();

            //sm.AddUsersTestResult(1, 1, 1, 79, DateTime.Now);

            Console.ReadKey();
        }
    }
}
