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
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.ImgPhotoGallery_Create";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ImageID", imgPhotoGallery.ImageID));
                command.Parameters.Add(new SqlParameter("@PhotoGalleryID", imgPhotoGallery.PhotoGalleryID));

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
        protected override ImgPhotoGallery GetModelFromReader(SqlDataReader reader)
        {
            ImgPhotoGallery imgPhotoGallery = new ImgPhotoGallery();
            imgPhotoGallery.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
            imgPhotoGallery.PhotoGalleryID = reader.GetGuid(reader.GetOrdinal("PhotoGalleryID"));
            return imgPhotoGallery;

        }
        protected override SqlParameter[] GetParameters(SqlParameter[] parameter)
        {
            Department department = new Department();
            SqlCommand command = new SqlCommand();
            //SqlParameter parameter = new SqlParameter();
            return parameter;
        }
        #endregion
    }
}
