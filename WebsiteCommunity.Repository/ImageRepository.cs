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
    public class ImageRepository : BaseRepository<Image>
    {
        #region Methods
        public List<Image> ReadAll()
        {
            return DatabaseManager.ReadAll<Image>(connectionString, "Image_ReadAll", GetModelFromReader);
        }
        public void Insert(Image image)
        {
            DatabaseManager.Insert<Image>(connectionString, "Images_Create", GetParameters);
        }        
        public void ReadById(Guid id)
        {
            DatabaseManager.ReadById<Image>(connectionString, "Image_ReadById", "@ImageID", id, GetModelFromReader);
        }
        public void UpdateById(Image image)
        {
            DatabaseManager.UpdateById<Image>(connectionString, "Images_UpdateById", GetParameters);
        }
        public void DeleteById(Guid id)
        {
            DatabaseManager.DeleteById<Image>(connectionString, "Images_DeleteById", "@ImageID", id);
        }
        protected override Image GetModelFromReader(SqlDataReader reader)
        {
            Image image = new Image();
            image.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
            image.ImageName = reader.GetString(reader.GetOrdinal("ImageName"));
            return image;

        }
        protected override SqlParameter[] GetParameters(Image image)
        {
            SqlParameter[] parameter = { new SqlParameter("@ImageID", image.ImageID),
                                         new SqlParameter("@ImageName", image.ImageName) };
            return parameter;
        }
        #endregion
    }
}
