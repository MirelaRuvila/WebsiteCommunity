using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using System.Data.SqlClient;

namespace WebsiteCommunity.Repository
{
    class PhotoGalleryRepository
    {
        #region Methods
        public List<PhotoGallery> ReadAll()
        {
            List<PhotoGallery> photogalleries = new List<PhotoGallery>();
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.PhotoGallery_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhotoGallery photogallery = new PhotoGallery();
                                photogallery.PhotoGalleryID = reader.GetGuid(reader.GetOrdinal("PhotoGalleryID"));
                                photogallery.PhotoGalleryName = reader.GetString(reader.GetOrdinal("PhotoGalleryName"));
                                photogallery.Description = reader.GetString(reader.GetOrdinal("Description"));
                                photogalleries.Add(photogallery);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
            }
            return photogalleries;
        }
        public void Insert(PhotoGallery photogallery)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.PhotoGallery_Create";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@PhotoGalleryID", photogallery.PhotoGalleryID));
                command.Parameters.Add(new SqlParameter("@PhotoGalleryName", photogallery.PhotoGalleryName));
                command.Parameters.Add(new SqlParameter("@Description", photogallery.Description));

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
        public void ReadById(Guid Id)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";
            PhotoGallery photogallery = new PhotoGallery();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.PhotoGallery_ReadById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@PhotoGalleryID", Id));

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                photogallery.PhotoGalleryID = reader.GetGuid(reader.GetOrdinal("PhotoGalleryID"));
                                photogallery.PhotoGalleryName = reader.GetString(reader.GetOrdinal("PhotoGalleryName"));
                                photogallery.Description = reader.GetString(reader.GetOrdinal("Description"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error {0}", ex.ToString());
                }
            }
        }
        public void UpdateById(Guid Id)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";
            PhotoGallery photogallery = new PhotoGallery();

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.PhotoGallery_UpdateById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@PhotoGalleryID", Id));
                command.Parameters.Add(new SqlParameter("@PhotoGalleryName", photogallery.PhotoGalleryName));
                command.Parameters.Add(new SqlParameter("@Description", photogallery.Description));

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
        public void DeleteById(Guid Id)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.PhotoGallery_DeleteById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@PhotoGalleryID", Id));
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
