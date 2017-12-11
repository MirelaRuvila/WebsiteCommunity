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
        public void ReadById(Guid id)
        {
            DatabaseManager.ReadById<Image>(connectionString, "Image_ReadById", "@ImageID", id, GetModelFromReader);
        }
        public void UpdateById(Image image)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Images_UpdateById";
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
