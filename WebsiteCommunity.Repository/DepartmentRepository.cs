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
        /*
        public List<Department> ReadAll1()
         {
             List<Department> departments = new List<Department>();

             using (SqlConnection connection = new SqlConnection(connectionString))
             {
                 try
                 {
                     using (SqlCommand command = new SqlCommand())
                     {
                         command.Connection = connection;
                         command.CommandText = "dbo.Departments_ReadAll";
                         command.CommandType = System.Data.CommandType.StoredProcedure;

                         connection.Open();
                         using (SqlDataReader reader = command.ExecuteReader())
                         {
                             while (reader.Read())
                             {
                                 Department department = new Department();
                                 department.DepartmentID = reader.GetGuid(reader.GetOrdinal("DepartmentID"));
                                 department.DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName"));
                                 department.Description = reader.GetString(reader.GetOrdinal("Description"));
                                 departments.Add(department);
                             }
                         }
                     }
                 }
                 catch(Exception ex)
                 {
                     Console.WriteLine("There was an error: {0}", ex.ToString());
                 }
             }
             return departments;
         }
        */  
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
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Departments_UpdateById";
                command.CommandType = System.Data.CommandType.StoredProcedure;
               
                command.Parameters.Add(new SqlParameter("@DepartmentID", department.DepartmentID));
                command.Parameters.Add(new SqlParameter("@DepartmentName", department.DepartmentName));
                command.Parameters.Add(new SqlParameter("@Description", department.Description));

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("There was an SQL error: {0}", sqlEx.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: {0}", ex.ToString());
            }
            finally
            {
                connection.Close();
            }
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
        protected override SqlParameter[] GetParameters(SqlParameter[] parameter)
        {
            Department department = new Department();
            SqlCommand command = new SqlCommand();
            //SqlParameter[] parameter = default(SqlParameter[]);
            parameter[0] = new SqlParameter("@DepartmentID", department.DepartmentID);
            parameter[1] = new SqlParameter("@DepartmentName", department.DepartmentName);
            parameter[2] = new SqlParameter("@Description", department.Description);
            return parameter;
        }
        
        #endregion
    }
}
