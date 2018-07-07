using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContactsApp
{
    class Contacts
    {
        public string ContactName { get; set; }
        public int ContactNumber { get; set; }

        /// <summary>
        /// Get the list of Contacts
        /// </summary>
        /// <returns></returns>
        public static Contacts GetPhoneContacts()
        {
            var phoneContact = new Contacts
            {
                ContactName = "Joe Doe",
                ContactNumber = 1234567890
            };
            return phoneContact;
        }

        //public async static Task<ICollection<Employee>> GetEmployees()
        //{
        //    var employees = new List<Employee>();

        //    var folder = ApplicationData.Current.LocalFolder;
        //    var employeeFile = await folder.GetFileAsync(TEXT_FILE_NAME);
        //    var lines = await FileIO.ReadLinesAsync(employeeFile);

        //    foreach (var line in lines)
        //    {
        //        var employeeData = line.Split(',');
        //        var employee = new Employee
        //        {
        //            Name = employeeData[0],
        //            Title = employeeData[1]
        //        };
        //        employees.Add(employee);
        //    }
        //    return employees;
        //}

        //public async static void WriteEmployee(Employee employee)
        //{
        //    var employeeData = $"{employee.Name},{employee.Title}";
        //    await FileHelper.WriteTextFile(TEXT_FILE_NAME, employeeData);
        //}

    }
}
