using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            if (GroupData.GetAll().Count() == 0)
            {
                app.Groups.Create(new GroupData("newGroup"));
            }
            if (ContactData.GetAll().Count == 0)
            {
                app.Contacts.Create(new ContactData("qwe", "ewq"));
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).FirstOrDefault();

            if (contact == null)
            {
                app.Contacts.Create(new ContactData("zxc", "zxv"));
                contact = ContactData.GetAll().Except(group.GetContacts()).First();
            }

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
