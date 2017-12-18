using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.RepositoryAbstraction
{
    public interface IDepartmentRepository
    {
        List<Department> ReadAll();
        Department Insert(Department department);
        Department ReadById(Guid id);
        Department UpdateById(Department department);
        Department Delete(Guid id);
    }
}
