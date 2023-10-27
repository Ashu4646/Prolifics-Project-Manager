using System;
using System.Collections.Generic;
using PPM.Domain;
using PPM.Model;
using System.Text.RegularExpressions;

namespace PPM.UIConsole

{
    public class EmployeeUI
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber != null)
            {
                string phoneExpression = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
                return Regex.IsMatch(phoneNumber, phoneExpression);
            }
            else
            {
                return false;
            }

        }
        public static bool IsValidEmail(string email)
        {
            if (email != null)
            {
                string emailExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                return Regex.IsMatch(email, emailExpression);

            }
            else
            {
                return false;
            }
        }

        public void AddEmployee()
        {
            EmployeeRepo obj = new EmployeeRepo();

            System.Console.WriteLine("Enter the number of employees you want to add: ");
            if (int.TryParse(System.Console.ReadLine(), out int number))
            {
                for (int i = 0; i < number; i++)
                {
                    Employee employee = new Employee();

                    int employeeId;
                    bool isEmployeeIdValid = false;

                    do
                    {
                        System.Console.WriteLine("Enter Employee ID: ");
                        if (int.TryParse(System.Console.ReadLine(), out employeeId))
                        {
                            if (!EmployeeRepo.IsValidEmployee(employeeId))
                            {
                                isEmployeeIdValid = true;
                                employee.employeeId = employeeId;
                            }
                            else
                            {
                                System.Console.WriteLine("Employee ID already exists. Please enter a new one.");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid input. Please enter a valid number for Employee ID.");
                        }
                    } while (!isEmployeeIdValid);

                    System.Console.WriteLine("Enter the First Name of the employee: ");
                    employee.firstName = Console.ReadLine();

                    System.Console.WriteLine("Enter the Last Name of the employee: ");
                    employee.lastName = Console.ReadLine();

                    string mobileNumber;
                    bool isMobileNumberValid = false;

                    do
                    {
                        System.Console.Write("Enter the employee phone number: ");
                        mobileNumber = Console.ReadLine()!;
                        isMobileNumberValid = IsValidPhoneNumber(mobileNumber);
                        if (!isMobileNumberValid)
                        {
                            System.Console.WriteLine("Enter a valid mobile number.");
                        }
                    } while (!isMobileNumberValid);

                    employee.mobileNumber = mobileNumber;

                    System.Console.Write("Enter the Employee Address: ");
                    employee.address = Console.ReadLine();

                    string email;
                    bool isEmailValid = false;

                    do
                    {
                        System.Console.Write("Enter the Employee Email ID: ");
                        email = Console.ReadLine()!;
                        isEmailValid = IsValidEmail(email);
                        if (!isEmailValid)
                        {
                            System.Console.WriteLine("Please enter a valid email ID.");
                        }
                    } while (!isEmailValid);

                    employee.email = email;

                    System.Console.WriteLine("Enter the role ID of the employee: ");
                    employee.roleId = int.Parse(Console.ReadLine()!);

                    if (RolesRepo.roleObj.Exists(r => r.roleId == employee.roleId))
                    {
                        obj.AddEmployee(employee.employeeId, employee.firstName!, employee.lastName!, employee.email, employee.mobileNumber, employee.address!, employee.roleId);

                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("The employees have been added successfully");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Role doesn't exist.");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("Add Role into the PPM by pressing '5' on the main menu Then try again!! ");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Invalid input. Please enter a valid number for the number of employees.");
            }
        }

        public static void ViewEmployee()
        {
            if (EmployeeRepo.empObj.Count == 0)
            {
                System.Console.WriteLine("No Employees Found!!");
            }
            else
            {
                System.Console.WriteLine("Employess list:");

                foreach (var list in EmployeeRepo.empObj)
                {
                    System.Console.WriteLine($"Employee ID:{list.employeeId}\nEmployee Name:{list.firstName} {list.lastName}\nEmployee email ID:{list.email}\nEmployee PhoneNumber:{list.mobileNumber}\nEmployee Address:{list.address}\nEmployee RoleID:{list.roleId}\n ");
                }
            }

        }


    }

}
