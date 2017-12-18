using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Business.Core;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.Business
{
    public class DepartmentBusiness
    {
        public List<Department> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.DepartmentRepository.ReadAll();
        }
        public Department Insert(Department department)
        {
            return BusinessContext.Current.RepositoryContext.DepartmentRepository.Insert(department);
        }
        public Department ReadById(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.DepartmentRepository.ReadById(id);
        }
        public Department UpdateById(Department department)
        {
            return BusinessContext.Current.RepositoryContext.DepartmentRepository.UpdateById(department);
        }
        public Department Delete(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.DepartmentRepository.Delete(id);
        }
    }
}
