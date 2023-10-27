using System;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;
using PPM.Domain;
using PPM.UIConsole;

namespace PPM.Main
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.Clear();
            int choice;
            while (true)
            {
                ConsoleUi.Title();
                choice = ConsoleUi.MenuDriven();

                switch (choice)
                {
                    case 1:
                        ProjectUI addProjectObj = new ProjectUI();
                        addProjectObj.AddProject();
                        break;

                    case 2:
                        
                        ProjectUI.ViewProject();
                        break;

                    case 3:
                        EmployeeUI empAddObj = new EmployeeUI();
                        empAddObj.AddEmployee();
                        break;

                    case 4:
                        
                        EmployeeUI.ViewEmployee();
                        break;

                    case 5:
                        RolesUI roleAddObj = new RolesUI();
                        roleAddObj.AddRole();
                        break;

                    case 6:
                        
                        RolesUI.ViewRole();
                        break;

                    case 7:
                        ProjectUI.AddEmployeeToProject();
                        break;

                    case 8:
                        ProjectUI.DeleteEmployeeFromProject();
                        break;

                    case 9:
                        ProjectUI.ViewProjectDetail();
                        break;

                    case 10:
                        ConsoleUi.Exit();
                        return;

                    default:
                        ConsoleUi.Default();
                        break;
                }

            }

        }
    }
}