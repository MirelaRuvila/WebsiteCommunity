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
    public class ImgPhotoGalleryRepository : BaseRepository <ImgPhotoGallery> , IImgPhotoGalleryRepository
    {
        #region Methods
        public List<ImgPhotoGallery> ReadAll()
        {
            return DatabaseManager.ReadAll(connectionString, "ImgPhotoGallery_ReadAll", GetModelFromReader);
        }       
        public ImgPhotoGallery Insert(ImgPhotoGallery imgPhotoGallery)
        {
            return DatabaseManager.ExecuteNonQuery<ImgPhotoGallery>(imgPhotoGallery, connectionString, "ImgPhotoGallery_Create", GetParameters);
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
