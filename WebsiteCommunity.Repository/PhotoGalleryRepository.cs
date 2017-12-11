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
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.PhotoGallery_Create";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@PhotoGalleryID", photoGallery.PhotoGalleryID));
                command.Parameters.Add(new SqlParameter("@PhotoGalleryName", photoGallery.PhotoGalleryName));
                command.Parameters.Add(new SqlParameter("@Description", photoGallery.Description));

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
            DatabaseManager.ReadById<PhotoGallery>(connectionString, "PhotoGallery_ReadById", "@PhotoGalleryID", id, GetModelFromReader);
        }
        public void UpdateById(PhotoGallery photoGallery)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.PhotoGallery_UpdateById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@PhotoGalleryID", photoGallery.PhotoGalleryID));
                command.Parameters.Add(new SqlParameter("@PhotoGalleryName", photoGallery.PhotoGalleryName));
                command.Parameters.Add(new SqlParameter("@Description", photoGallery.Description));

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
