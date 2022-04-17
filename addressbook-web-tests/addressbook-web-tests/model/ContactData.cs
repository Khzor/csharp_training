using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string contactInformation;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname && Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Lastname + " " + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            } else
            {
                return Lastname.CompareTo(other.Lastname);
            }
            
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                } 
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[- ()]", "") + "\r\n";
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        private string CleanUpAddress(string address)
        {
            if (address == null || address == "")
            {
                return "";
            }
            return address.Replace(" ", "") + "\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return CleanUpEmail(Email) + CleanUpEmail(Email2) + Email3;
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string ContactInformation
        {
            get
            {
                if (contactInformation != null)
                {
                    return contactInformation;
                }
                else
                {
                    if (Lastname != "")
                    {
                        Lastname = " " + Lastname;
                    }
                    return (Firstname + Lastname + "\r\n" + CleanUpAddress(Address) + PhonesFromForm(HomePhone, MobilePhone, WorkPhone) 
                        + "\r\n" + AllEmails).Trim();
                }
            }
            set
            {
                contactInformation = value;
            }
        }

        public string PhonesFromForm(string homePhone, string mobilePhone, string workPhone)
        {
            if (homePhone == "" & mobilePhone == "" & workPhone == "")
            {
                return "";
            }

            if (homePhone != "")
            {
                homePhone = "H: " + homePhone + "\r\n";
            }

            if (mobilePhone != "")
            {
                mobilePhone = "M: " + mobilePhone + "\r\n";
            }

            if (workPhone != "")
            {
                workPhone = "W: " + workPhone + "\r\n";
            }

            return "\r\n" + homePhone + mobilePhone + workPhone;
        }
    }
}
