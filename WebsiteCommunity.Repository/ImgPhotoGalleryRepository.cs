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
    public class ImgPhotoGalleryRepository : BaseRepository <ImgPhotoGallery>
    {
        #region Methods
        public List<ImgPhotoGallery> ReadAll()
        {
            return DatabaseManager.ReadAll(connectionString, "ImgPhotoGallery_ReadAll", GetModelFromReader);
        }       
        public void Insert(ImgPhotoGallery imgPhotoGallery)
        {
            DatabaseManager.Insert<ImgPhotoGallery>(connectionString, "ImgPhotoGallery_Create", GetParameters);
        }
        protected override ImgPhotoGallery GetModelFromReader(SqlDataReader reader)
        {
            ImgPhotoGallery imgPhotoGallery = new ImgPhotoGallery();
            imgPhotoGallery.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
            imgPhotoGallery.PhotoGalleryID = reader.GetGuid(reader.GetOrdinal("PhotoGalleryID"));
            return imgPhotoGallery;

        }
        protected override SqlParameter[] GetParameters(ImgPhotoGallery imgPhotoGallery)
        {
            SqlParameter[] parameter = { new SqlParameter("@ImageID", imgPhotoGallery.ImageID),
                                         new SqlParameter("@PhotoGalleryID", imgPhotoGallery.PhotoGalleryID) };
            return parameter;
        }
        #endregion
    }
}
