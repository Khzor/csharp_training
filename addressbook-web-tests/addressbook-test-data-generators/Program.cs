using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            if (type == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }

            else if (type == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Address = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10),
                        HomePhone = TestBase.GenerateRandomString(10),
                        MobilePhone = TestBase.GenerateRandomString(10),
                        WorkPhone = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }

            writer.Close();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1}),${2}",
                group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},",
                    contact.Firstname, contact.Lastname, contact.Address, contact.Email, 
                    contact.Email2, contact.Email3, contact.HomePhone, contact.MobilePhone, contact.WorkPhone));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
