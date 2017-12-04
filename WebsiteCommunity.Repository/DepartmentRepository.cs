using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using System.Data.SqlClient;

namespace WebsiteCommunity.Repository
{
    public class DepartmentRepository
    {
        #region Methods
        public List<Department> ReadAll()
        {
            List<Department> departments = new List<Department>();
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

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
        public void Insert(Department department)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Departments_Create";
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
        public void ReadById(Guid Id)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";
            Department department = new Department();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Departments_ReadById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@DepartmentID", Id));

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            { 
                                department.DepartmentID = reader.GetGuid(reader.GetOrdinal("DepartmentID"));
                                department.DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName"));
                                department.Description = reader.GetString(reader.GetOrdinal("Description"));                               
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("There was an error {0}", ex.ToString());
                }
            }
        }
        public void UpdateById(Guid Id, Department department)
        {
           
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Departments_UpdateById";
                command.CommandType = System.Data.CommandType.StoredProcedure;
               
                command.Parameters.Add(new SqlParameter("@DepartmentID", Id));
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
        public void DeleteById(Guid Id)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Departments_DeleteById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@DepartmentID", Id));
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
        #endregion
    }
}
