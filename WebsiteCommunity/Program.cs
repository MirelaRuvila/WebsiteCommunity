using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using WebsiteCommunity.Repository;

namespace WebsiteCommunity
{
    class Program
    {
        static void Main(string[] args)
        {
            DepartmentRepository departmentRepository = new DepartmentRepository();
            Department department1 = new Department();

            department1.DepartmentID = Guid.NewGuid();
            department1.DepartmentName = "Social";
            department1.Description = "be nice, be creative";

            departmentRepository.Insert(department1);

            List<Department> departments = departmentRepository.ReadAll();
            foreach(Department department in departments)
            {
                Console.WriteLine("{0} {1}", department.DepartmentName, department.Description);
            }
            Console.WriteLine("\n");
            departmentRepository.ReadById(department1.DepartmentID);
            //Console.WriteLine(department1.DepartmentName);
            
            department1.DepartmentName = "Medical";
            department1.Description = "";
            departmentRepository.UpdateById(department1.DepartmentID, department1);
            Console.WriteLine("{0} {1}", department1.DepartmentName, department1.Description);
            Console.WriteLine("\n");

            Department department2 = new Department();
            department2.DepartmentID = Guid.NewGuid();
            department2.DepartmentName = "Example";
            department2.Description = "";
            departmentRepository.Insert(department2);

            List<Department> departments1 = departmentRepository.ReadAll();
            foreach (Department department in departments1)
            {
                Console.WriteLine("{0} {1}", department.DepartmentName, department.Description);
            }
            Console.WriteLine("\n");

            departmentRepository.DeleteById(department2.DepartmentID);

            Console.WriteLine("Departamentele ramase: ");
            List<Department> departments2 = departmentRepository.ReadAll();
            foreach (Department department in departments2)
            {
                Console.WriteLine("{0} {1}", department.DepartmentName, department.Description);
            }
            Console.Read();

        }
    }
}
