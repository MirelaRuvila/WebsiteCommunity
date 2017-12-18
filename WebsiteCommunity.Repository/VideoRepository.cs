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
    public class VideoRepository : BaseRepository<Video> , IVideoRepository
    {
        #region Methods
        public List<Video> ReadAll()
        {
            return DatabaseManager.ReadAll<Video>(connectionString, "Video_ReadAll", GetModelFromReader);
        }
        public Video Insert(Video video)
        {
            return DatabaseManager.ExecuteNonQuery<Video>(video, connectionString, "Video_Create", GetParameters);
        }       
        public Video ReadById(Guid id)
        {
            return DatabaseManager.ReadById<Video>(connectionString, "Video_ReadById", "@VideoID", id, GetModelFromReader);
        }
        public Video UpdateById(Video video)
        {
            return DatabaseManager.ExecuteNonQuery<Video>(video, connectionString, "Video_UpdateById", GetParameters);
        }
        public Video Delete(Guid id)
        {
            return DatabaseManager.Delete<Video>(connectionString, "Video_DeleteById", "@VideoID", id);
        }
        protected override Video GetModelFromReader(SqlDataReader reader)
        {
            Video video = new Video();
            video.VideoID = reader.GetGuid(reader.GetOrdinal("VideoID"));
            video.VideoTypeName = reader.GetString(reader.GetOrdinal("VideoTypeName"));
            return video;
        }
        protected override SqlParameter[] GetParameters(Video video)
        {
            SqlParameter[] parameter = { new SqlParameter("@VideoID", video.VideoID),
                                         new SqlParameter("@VideoTypeName", video.VideoTypeName) };
            return parameter;
        }
        #endregion
    }
}
