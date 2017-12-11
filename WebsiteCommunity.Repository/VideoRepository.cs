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
    public class VideoRepository : BaseRepository<Video>
    {
        #region Methods
        public List<Video> ReadAll()
        {
            return DatabaseManager.ReadAll<Video>(connectionString, "Video_ReadAll", GetModelFromReader);
        }
        public void Insert(Video video)
        {
            DatabaseManager.Insert<Video>(connectionString, "Video_Create", GetParameters);
        }       
        public void ReadById(Guid id)
        {
            DatabaseManager.ReadById<Video>(connectionString, "Video_ReadById", "@VideoID", id, GetModelFromReader);
        }
        public void UpdateById(Video video)
        {
            DatabaseManager.UpdateById<Video>(connectionString, "Video_UpdateById", GetParameters);
        }
        public void DeleteById(Guid id)
        {
            DatabaseManager.DeleteById<Video>(connectionString, "Video_DeleteById", "@VideoID", id);
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
