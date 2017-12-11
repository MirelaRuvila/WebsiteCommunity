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
    public class EventRepository : BaseRepository<Event>
    {
        #region Methods
        public List<Event> ReadAll()
        {
            return DatabaseManager.ReadAll<Event>(connectionString, "Events_ReadAll", GetModelFromReader);
        }
        public void Insert(Event event1)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Events_Create";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EventID", event1.EventID));
                command.Parameters.Add(new SqlParameter("@EventName", event1.EventName));
                command.Parameters.Add(new SqlParameter("@Description", event1.Description));

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
            DatabaseManager.ReadById<Event>(connectionString, "Events_ReadById", "@EventID", id, GetModelFromReader);
        }
        public void UpdateById(Event event1)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Events_UpdateById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EventID", event1.EventID));
                command.Parameters.Add(new SqlParameter("@EventName", event1.EventName));
                command.Parameters.Add(new SqlParameter("@Description", event1.Description));

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
            DatabaseManager.DeleteById<Event>(connectionString, "Events_DeleteById", "@EventID", id);
        }

        protected override Event GetModelFromReader(SqlDataReader reader)
        {
            Event event1 = new Event();
            event1.EventID = reader.GetGuid(reader.GetOrdinal("EventID"));
            event1.EventName = reader.GetString(reader.GetOrdinal("EventName"));
            event1.Description = reader.GetString(reader.GetOrdinal("Description"));
            return event1;

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
