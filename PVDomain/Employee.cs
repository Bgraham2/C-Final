using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDomain
{
    public class Employee
    {

        private long id;
        private long employeeTypeId;
        private long departmentId;
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private string email;
        private string phone;

        public Employee()
        {
            id = 0;
            employeeTypeId = 0;
            departmentId = 0;
            firstName = string.Empty;
            lastName = string.Empty;
            password = string.Empty;
            username = string.Empty;
            email = string.Empty;
            phone = string.Empty;
        }

        public Employee(long id, long employeeTypeId, long departmentId,  string firstName, string lastName, string username, string password, string email, string phone)
        {
            Id = id;
            EmployeeTypeId = employeeTypeId;
            DepartmentId = departmentId;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Username = username;
            Email = email;
            Phone = phone;

        }


        public long Id
        {

            get { return id; }
            set { id = value; }

        }
        public long EmployeeTypeId
        {

            get { return employeeTypeId; }
            set { employeeTypeId = value; }

        }
        public long DepartmentId
        {

            get { return departmentId; }
            set { departmentId = value; }

        }
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }

        }
        public string FirstName
        {

            get { return firstName; }
            set 
            { 



                firstName = value; 

            }

        }

        public string LastName
        {

            get { return lastName; }
            set 
            {



                lastName = value;

            }

        }

        public string Username
        {

            get { return username; }
            set 
            {



                username = value; 
            }

        }

        public string Password
        {

            get { return password; }
            set 
            {

 

                password = value;
            }

        }

        public string Phone
        {

            get { return phone; }
            set
            {


                phone = value;
            }

        }

        public string Email
        {

            get { return email; }
            set 
            {


              email = value;
           }

        }

    }
}
