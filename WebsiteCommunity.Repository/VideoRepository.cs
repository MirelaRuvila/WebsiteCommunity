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
    public class VideoRepository : BaseRepository<Video>
    {
        #region Methods
        public List<Video> ReadAll()
        {
            return DatabaseManager.ReadAll<Video>(connectionString, "Video_ReadAll", GetModelFromReader);
        }
        public void Insert(Video video)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Video_Create";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@VideoID", video.VideoID));
                command.Parameters.Add(new SqlParameter("@VideoTypeName", video.VideoTypeName));

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
            DatabaseManager.ReadById<Video>(connectionString, "Video_ReadById", "@VideoID", id, GetModelFromReader);
        }
        public void UpdateById(Video video)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Video_UpdateById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@VideoID", video.VideoID));
                command.Parameters.Add(new SqlParameter("@VideoTypeName", video.VideoTypeName));

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
            DatabaseManager.DeleteById<Video>(connectionString, "Video_DeleteById", "@VideoID", id);
        }
        protected override Video GetModelFromReader(SqlDataReader reader)
        {
            Video video = new Video();
            video.VideoID = reader.GetGuid(reader.GetOrdinal("VideoID"));
            video.VideoTypeName = reader.GetString(reader.GetOrdinal("VideoTypeName"));
            return video;
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
