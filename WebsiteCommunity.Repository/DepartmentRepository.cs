using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using System.Data.SqlClient;
using WebsiteCommunity.Repository.Core;

namespace WebsiteCommunity.Repository 
{
    public class DepartmentRepository : BaseRepository<Department>
    {
        #region Methods
        public List<Department> ReadAll()
        {
            return DatabaseManager.ReadAll<Department>(connectionString, "dbo.Departments_ReadAll",
                GetModelFromReader);
            //return ReadAll("dbo.Students_ReadAll");
        }

        public void Insert(Department department)
        {
            DatabaseManager.Insert<Department>(connectionString, "Departments_Create", GetParameters);
        }
        public void ReadById(Guid id)
        {
            DatabaseManager.ReadById<Department>(connectionString, "Departments_ReadById", "@DepartmentID", id, GetModelFromReader);
        }
        public void UpdateById(Department department)
        {
            DatabaseManager.UpdateById<Department>(connectionString, "Departments_UpdateById", GetParameters);     
        }        
        public void DeleteById(Guid id)
        {
            DatabaseManager.DeleteById<Department>(connectionString, "Departments_DeleteById", "@DepartmentID", id);
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
