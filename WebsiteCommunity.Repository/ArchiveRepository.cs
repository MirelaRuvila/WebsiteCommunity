using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.Repository
{
    class ArchiveRepository
    {
        #region Methods
        public List<Archive> ReadAll()
        {
            List<Archive> archives = new List<Archive>();
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Archives_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Archive archive = new Archive();
                                archive.ArchiveID = reader.GetGuid(reader.GetOrdinal("ArchiveID"));
                                archive.ArchiveName = reader.GetString(reader.GetOrdinal("ArchiveName"));
                                archive.VideoID = reader.GetGuid(reader.GetOrdinal("VideoID"));
                                archive.Data = reader.GetDateTime(reader.GetOrdinal("Data"));
                                archive.Description = reader.GetString(reader.GetOrdinal("Description"));
                                archives.Add(archive);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
            }
            return archives;
        }
        public void Insert(Archive archive)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Archives_Create";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ArchiveID", archive.ArchiveID));
                command.Parameters.Add(new SqlParameter("@ArchiveName", archive.ArchiveName));
                command.Parameters.Add(new SqlParameter("@VideoID", archive.VideoID));
                command.Parameters.Add(new SqlParameter("@Data", archive.Data));
                command.Parameters.Add(new SqlParameter("@Description", archive.Description));

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
            Archive archive = new Archive();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Archives_ReadById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@ArchiveID", Id));

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                archive.ArchiveID = reader.GetGuid(reader.GetOrdinal("ArchiveID"));
                                archive.ArchiveName = reader.GetString(reader.GetOrdinal("ArchiveName"));
                                archive.VideoID = reader.GetGuid(reader.GetOrdinal("VideoID"));
                                archive.Data = reader.GetDateTime(reader.GetOrdinal("Data"));
                                archive.Description = reader.GetString(reader.GetOrdinal("Description"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error {0}", ex.ToString());
                }
            }
        }
        public void UpdateById(Guid Id)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";
            Archive archive = new Archive();

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Archives_UpdateById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ArchiveID", Id));
                command.Parameters.Add(new SqlParameter("@ArchiveName", archive.ArchiveName));
                command.Parameters.Add(new SqlParameter("@VideoID", archive.VideoID));
                command.Parameters.Add(new SqlParameter("@Data", archive.Data));
                command.Parameters.Add(new SqlParameter("@Description", archive.Description));

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
                command.CommandText = "dbo.Archives_DeleteById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ArchiveID", Id));
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
