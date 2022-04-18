using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Petr", "Petrov");

            app.Contacts.CreateContactIfItDoesntExist(newData);

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(toBeModified, newData);

            List<ContactData> newContacts = ContactData.GetAll();
            toBeModified.Firstname = newData.Firstname;
            toBeModified.Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
