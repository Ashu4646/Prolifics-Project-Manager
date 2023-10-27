using PPM.Model;
using System.Text.RegularExpressions;

namespace PPM.Domain
{
    public class EmployeeRepo
    {
        public static List<Employee> empObj = new List<Employee>();

        public void AddEmployee(int EmployeeId, string FirstName, string LastName, string Email, string MobileNumber, string Address, int RoleId)
        {
            Employee employeeObj = new Employee
            {
                employeeId = EmployeeId,
                firstName = FirstName,
                lastName = LastName,
                email = Email,
                mobileNumber = MobileNumber,
                address = Address,
                roleId = RoleId

            };
            empObj.Add(employeeObj);

        }
        public static bool IsValidEmployee(int employeeId)

        {

            bool result = empObj.Exists(e => e.employeeId == employeeId);

            return result;

        }


        

        public static List<Employee> ViewEmployees()
        {
            return empObj;
        }
        public static Employee GetEmployeeById(int employeeId)
        {

            return empObj.FirstOrDefault(e => e.employeeId == employeeId)!;
        }
    }
}



