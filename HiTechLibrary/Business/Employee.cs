using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.DataAccess;

namespace HiTechLibrary.Business
{
    public class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;
        private int jobId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public int JobId { get => jobId; set => jobId = value; }


        // default constructor (constructor has to be the class name)
        public Employee()
        {
            employeeId = 0;
            firstName = "";
            lastName = "";
            phoneNumber = "";
            email = "";
        }

        //overloaded constructor ( parameterized constructor)
        public Employee(int employeeId, string firstName, string lastName, string phoneNumber, string email, int jobId)
        { //this is the CLASS variable
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.jobId = jobId;
        }

        public void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp); 
        }
        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }
        public void DeleteEmployee(int empId)
        {
            EmployeeDB.DeleteRecord(empId);
        }
        public Employee SearchEmployee(int empId)
        {
            return EmployeeDB.GetRecord(empId);
        }
        public List<Employee> SearchEmployeeByName(string name, string select)
        {
            return EmployeeDB.GetRecordListbyName(name, select);
        }
        public List<Employee> SearchAllEmployee()
        {
            return EmployeeDB.GetRecordList();
        }
    }
}
