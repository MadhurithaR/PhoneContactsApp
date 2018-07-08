using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PhoneContactsApp
{
    class Contacts
    {
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }

        /// <summary>
        /// Get the list of Contacts
        /// </summary>
        /// <returns></returns>
        public static Contacts GetPhoneContacts()
        {
            var phoneContact = new Contacts
            {
                ContactName = "Joe Doe",
                ContactNumber = "1234567890"
            };
            return phoneContact;
        }

        public async static Task<ICollection<Contacts>> GetPhContacts()
        {
            var contacts = new List<Contacts>();

            var folder = ApplicationData.Current.LocalFolder;
            var contactFile = await folder.GetFileAsync(MainPage.TEXT_FILE_NAME);
            var lines = await FileIO.ReadLinesAsync(contactFile);

            foreach (var line in lines)
            {
                var contactData = line.Split(',');
                var contact = new Contacts
                {
                    ContactName = contactData[0],
                   ContactNumber = contactData[1]
                };
                contacts.Add(contact);

            }
            return contacts;
            
            //public async static void WriteEmployee(Employee employee)
            //{
            //    var employeeData = $"{employee.Name},{employee.Title}";
            //    await FileHelper.WriteTextFile(TEXT_FILE_NAME, employeeData);
            //}
                      
        }

        /// <summary>
        /// find phone number
        /// </summary>
        /// <param name="name"></param>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public static string findNumber(string name, ICollection<Contacts> contacts)
        {
            string number = "0";

            foreach (var contact in contacts)
            {
                if (contact.ContactName.Contains(name))
                      return contact.ContactNumber;
            }
           return number;
        }

    }
}
