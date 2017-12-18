using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebsiteCommunity.Models;
using WebsiteCommunity.Repository.Core;
using WebsiteCommunity.RepositoryAbstraction;

namespace WebsiteCommunity.Repository
{
    public class ArchiveRepository : BaseRepository<Archive> , IArchiveRepository
    {
        #region Methods
        public List<Archive> ReadAll()
        {
            return DatabaseManager.ReadAll<Archive>(connectionString, "Archives_ReadAll", GetModelFromReader);        
        }        
        public Archive Insert(Archive archive)
        {
           return DatabaseManager.ExecuteNonQuery<Archive>(archive, connectionString, "Archives_Create", GetParameters);
        }
        public Archive ReadById(Guid id)
        {
           return DatabaseManager.ReadById<Archive>(connectionString, "Archives_ReadById", "@ArchiveID", id, GetModelFromReader);
        }
        public Archive UpdateById(Archive archive)
        {
           return DatabaseManager.ExecuteNonQuery<Archive>(archive, connectionString, "Archives_UpdateById", GetParameters);
        }
        public Archive Delete(Guid id)
        {
           return DatabaseManager.Delete<Archive>(connectionString, "Archives_DeleteById", "@ArchiveID", id);
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
