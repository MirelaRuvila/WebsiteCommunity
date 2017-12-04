using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.Repository
{
    class ImgPhotoGalleryRepository
    {
        #region Methods
        public List<ImgPhotoGallery> ReadAll()
        {
            List<ImgPhotoGallery> imgphotogalleries = new List<ImgPhotoGallery>();
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.ImgPhotoGallery_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ImgPhotoGallery imgphotogallery = new ImgPhotoGallery();
                                imgphotogallery.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
                                imgphotogallery.PhotoGalleryID = reader.GetGuid(reader.GetOrdinal("PhotoGalleryID"));
                                imgphotogalleries.Add(imgphotogallery);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
            }
            return imgphotogalleries;
        }
        public void Insert(ImgPhotoGallery imgphotogallery)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.ImgPhotoGallery_Create";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ImageID", imgphotogallery.ImageID));
                command.Parameters.Add(new SqlParameter("@PhotoGalleryID", imgphotogallery.PhotoGalleryID));

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
       
        #endregion
    }
}
