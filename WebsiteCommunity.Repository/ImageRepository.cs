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
    public class ImageRepository : BaseRepository<Image> , IImageRepository
    {
        #region Methods
        public List<Image> ReadAll()
        {
            return DatabaseManager.ReadAll<Image>(connectionString, "Image_ReadAll", GetModelFromReader);
        }
        public Image Insert(Image image)
        {
            return DatabaseManager.ExecuteNonQuery<Image>(image, connectionString, "Images_Create", GetParameters);
        }        
        public Image ReadById(Guid id)
        {
            return DatabaseManager.ReadById<Image>(connectionString, "Image_ReadById", "@ImageID", id, GetModelFromReader);
        }
        public Image UpdateById(Image image)
        {
            return DatabaseManager.ExecuteNonQuery<Image>(image, connectionString, "Images_UpdateById", GetParameters);
        }
        public Image Delete(Guid id)
        {
            return DatabaseManager.Delete<Image>(connectionString, "Images_DeleteById", "@ImageID", id);
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
