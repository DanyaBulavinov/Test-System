using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//====================================
using System.Xml.Linq;
using System.Linq;


namespace Testing
{
    class UserManager
    {
        public void CreateUser(int id, string name, string password)
        {
            XDocument xdoc = XDocument.Load("Users.xml");
            XElement root = xdoc.Element("Users");
            var users = from ex in root.Elements("User")
                        where ex.Attribute("Id").Value == id.ToString()
                        select ex;
            if(users.Count() == 0)
            {
                root.Add(new XElement("User",
                            new XAttribute("Id", id),
                            new XElement("Name", name),
                            new XElement("Password", password)
                            )
                        );
                xdoc.Save("Users.xml");

                Console.WriteLine("User added");
            }
            else
            {
                Console.WriteLine("User exists");
            }
        }

        public void ChangePassword(int id, string OldPassword, string NewPassword)
        {
            XDocument xdoc = XDocument.Load("Users.xml");
            XElement root = xdoc.Element("Users");
            var users = from ex in root.Elements("User")
                        where ex.Attribute("Id").Value == id.ToString() && ex.Element("Password").Value == OldPassword
                        select ex;
            if (users.Count() > 0)
            {
                users.ToList().First().Element("Password").Value = NewPassword;
                Console.WriteLine("Password changed");
                xdoc.Save("Users.xml");
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        public bool Auth(string name, string password)
        {
            XDocument xdoc = XDocument.Load("User.xml");
            XElement root = xdoc.Element("Users");

            var user = from ex in root.Elements("User")
                       where ex.Element("Name").Value == name && ex.Element("Password").Value == password
                       select ex;

            if (user.Count() > 0)
            {
                Console.WriteLine("user login");
                return true;
            }
            Console.WriteLine("user not found");
            return false;
        }


    }
}
