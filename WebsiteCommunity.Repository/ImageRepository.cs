using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using System.Data.SqlClient;

namespace WebsiteCommunity.Repository
{
    class ImageRepository
    {
        #region Methods
        public List<Image> ReadAll()
        {
            List<Image> images = new List<Image>();
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Images_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Image image = new Image();
                                image.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
                                image.ImageName = reader.GetString(reader.GetOrdinal("ImageName"));
                                images.Add(image);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
            }
            return images;
        }
        public void Insert(Image image)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Images_Create";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ImageID", image.ImageID));
                command.Parameters.Add(new SqlParameter("@ImageName", image.ImageName));

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
            Image image = new Image();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Image_ReadById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@ImageID", Id));

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                image.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
                                image.ImageName = reader.GetString(reader.GetOrdinal("ImageName"));
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
            Image image = new Image();
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Images_UpdateById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ImageID", Id));
                command.Parameters.Add(new SqlParameter("@ImageName", image.ImageName));

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
                command.CommandText = "dbo.Images_DeleteById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ImageID", Id));
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
