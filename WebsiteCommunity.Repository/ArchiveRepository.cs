using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebsiteCommunity.Models;
using WebsiteCommunity.Repository.Core;

namespace WebsiteCommunity.Repository
{
    public class ArchiveRepository : BaseRepository<Archive>
    {
        #region Methods
        public List<Archive> ReadAll()
        {
            return DatabaseManager.ReadAll<Archive>(connectionString, "Archives_ReadAll", GetModelFromReader);        
        }        
        public void Insert(Archive archive)
        {
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
        public void ReadById(Guid id)
        {
            DatabaseManager.ReadById<Archive>(connectionString, "Archives_ReadById", "@ArchiveID", id, GetModelFromReader);
        }
        public void UpdateById(Archive archive)
        {
            DatabaseManager.UpdateById<Archive>(connectionString, "Archives_UpdateById", GetParameters);
        }
        public void DeleteById(Guid id)
        {
            DatabaseManager.DeleteById<Archive>(connectionString, "Archives_DeleteById", "@ArchiveID", id);
        }
        protected override Archive GetModelFromReader(SqlDataReader reader)
        {
            Archive archive = new Archive();
            archive.ArchiveID = reader.GetGuid(reader.GetOrdinal("ArchiveID"));
            archive.ArchiveName = reader.GetString(reader.GetOrdinal("ArchiveName"));
            archive.VideoID = reader.GetGuid(reader.GetOrdinal("VideoID"));
            archive.Data = reader.GetDateTime(reader.GetOrdinal("Data"));
            archive.Description = reader.GetString(reader.GetOrdinal("Description"));
            return archive;
        }
        protected override SqlParameter[] GetParameters(Archive archive)
        {
            SqlParameter[] parameter = { new SqlParameter("@ArchiveID", archive.ArchiveID),
                                         new SqlParameter("@ArchiveName", archive.ArchiveName),
                                         new SqlParameter("@Description", archive.Description),
                                         new SqlParameter("@Data", archive.Data),
                                         new SqlParameter("@VideoID", archive.VideoID) };
            return parameter;
        }
        #endregion 
    }
}
