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
    public class PhotoGalleryRepository : BaseRepository<PhotoGallery>
    {
        #region Methods
        public List<PhotoGallery> ReadAll()
        {
            return DatabaseManager.ReadAll<PhotoGallery>(connectionString, "PhotoGallery_ReadAll", GetModelFromReader);
        }
        public void Insert(PhotoGallery photoGallery)
        {
            DatabaseManager.Insert<PhotoGallery>(connectionString, "PhotoGallery_Create", GetParameters);
        }       
        public void ReadById(Guid id)
        {
            DatabaseManager.ReadById<PhotoGallery>(connectionString, "PhotoGallery_ReadById", "@PhotoGalleryID", id, GetModelFromReader);
        }
        public void UpdateById(PhotoGallery photoGallery)
        {
            DatabaseManager.UpdateById<PhotoGallery>(connectionString, "PhotoGallery_UpdateById", GetParameters);
        }
        public void DeleteById(Guid id)
        {
            DatabaseManager.DeleteById<PhotoGallery>(connectionString, "PhotoGallery_DeleteById", "@PhotoGalleryID", id);
        }
        protected override PhotoGallery GetModelFromReader(SqlDataReader reader)
        {
            PhotoGallery photoGallery = new PhotoGallery();
            photoGallery.PhotoGalleryID = reader.GetGuid(reader.GetOrdinal("PhotoGalleryID"));
            photoGallery.PhotoGalleryName = reader.GetString(reader.GetOrdinal("PhotoGalleryName"));
            photoGallery.Description = reader.GetString(reader.GetOrdinal("Description"));
            return photoGallery;
        }
        protected override SqlParameter[] GetParameters(PhotoGallery photoGallery)
        {
            SqlParameter[] parameter = { new SqlParameter("@PhotoGalleryID", photoGallery.PhotoGalleryID),
                                         new SqlParameter("@PhotoGalleryName", photoGallery.PhotoGalleryName),
                                         new SqlParameter("@Description", photoGallery.Description) };
            return parameter;
        }
        #endregion 
    }
}
