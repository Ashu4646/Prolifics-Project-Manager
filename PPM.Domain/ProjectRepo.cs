
using PPM.Model;
namespace PPM.Domain
{
    public class ProjectRepo : EmployeeRepo
    {
        public static List<Project> listObj = new List<Project>();
        public void AddProject(int ProjectId, string ProjectName, DateOnly startDate, DateOnly endDate)
        {
            Project ProjectObj = new Project
            {
                projectId = ProjectId,
                projectName = ProjectName,
                startDate = startDate,
                endDate = endDate

            };
            listObj.Add(ProjectObj);

        }

      
        public bool IsProjectId(int ProjectId)
        {
            bool result = listObj.Exists(x => x.projectId == ProjectId);
            return result;

        }
          public static List<Project> ViewProjects()
        {
                return listObj;
        }




        // Method to add an employee to a project
        public static void AddEmployeeToProject(int projectId, int employeeId)
        {
            Project project = listObj.FirstOrDefault(p => p.projectId == projectId)!;
            Employee employee = empObj.FirstOrDefault(e => e.employeeId == employeeId)!;
            if (project != null && employee != null)
            {
                project.employeesProject.Add(employee);
                
            }
            else
            {
                Console.WriteLine("Project or Employee not found.");
            }

           
        }
        //Method to Delete Employee from Project
        public static void DeleteEmployeeFromProject(int projectId, int employeeId)
        {
            Project project = listObj.FirstOrDefault(p => p.projectId == projectId)!;
            if (project != null)
            {
                Employee employee = project.employeesProject.FirstOrDefault(e => e.employeeId == employeeId)!;
                if (employee != null)
                {
                    project.employeesProject.Remove(employee);
                    
                }
                else
                {
                    Console.WriteLine("Employee not found in the project.");
                }
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }
        public static Project GetProjectById(int projectId)
        {
            {

                return listObj.FirstOrDefault(p => p.projectId == projectId)!;
            }

        }
        //Method to view Project Detail
        public class Roless : RolesRepo
        {
            public static void ViewProjectDetail(int projectId)
            {

                Project project = listObj.FirstOrDefault(p => p.projectId == projectId)!;
                if (project != null)
                {
                    Console.WriteLine($"Project Details - ID: {project.projectId}\nName: {project.projectName}\nStart Date: {project.startDate}\nEnd Date: {project.endDate}");

                    // Group employees by role and display them
                    var employeesByRole = project.employeesProject.GroupBy(e => e.roleId);

                    foreach (var roleGroup in employeesByRole)
                    {
                        Roles role = roleObj.FirstOrDefault(r => r.roleId == roleGroup.Key)!;
                        Console.WriteLine($"Role: {role.roleName}");
                        foreach (var employee in roleGroup)
                        {
                            Console.WriteLine($"  Employee: {employee.firstName} {employee.lastName}");
                        }
                    }
                }

            }
        }



        

        
    }
}