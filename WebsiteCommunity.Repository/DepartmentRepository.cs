using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using System.Data.SqlClient;
using WebsiteCommunity.Repository.Core;
using WebsiteCommunity.RepositoryAbstraction;

namespace WebsiteCommunity.Repository 
{
    public class DepartmentRepository : BaseRepository<Department> , IDepartmentRepository
    {
        #region Methods
        public List<Department> ReadAll()
        {
            return DatabaseManager.ReadAll<Department>(connectionString, "dbo.Departments_ReadAll", GetModelFromReader);
        }

        public Department Insert(Department department)
        {
           return DatabaseManager.ExecuteNonQuery<Department>(department, connectionString, "Departments_Create", GetParameters);
        }
        public Department ReadById(Guid id)
        {
           return DatabaseManager.ReadById<Department>(connectionString, "Departments_ReadById", "@DepartmentID", id, GetModelFromReader);
        }
        public Department UpdateById(Department department)
        {
           return DatabaseManager.ExecuteNonQuery<Department>(department, connectionString, "Departments_UpdateById", GetParameters);     
        }        
        public Department Delete(Guid id)
        {
           return DatabaseManager.Delete<Department>(connectionString, "Departments_DeleteById", "@DepartmentID", id);
        }

        protected override Department GetModelFromReader(SqlDataReader reader)
        {
            Department department = new Department();
            department.DepartmentID = reader.GetGuid(reader.GetOrdinal("DepartmentID"));
            department.DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName"));
            department.Description = reader.GetString(reader.GetOrdinal("Description"));
            return department;
        }
        protected override SqlParameter[] GetParameters(Department department)
        {
            SqlParameter[] parameter = { new SqlParameter("@DepartmentID", department.DepartmentID),
                                         new SqlParameter("@DepartmentName", department.DepartmentName),
                                         new SqlParameter("@Description", department.Description) };
            return parameter;
        }
        
        #endregion
    }
}
