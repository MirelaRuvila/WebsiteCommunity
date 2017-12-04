using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using System.Data.SqlClient;

namespace WebsiteCommunity.Repository
{
    class EventRepository
    {
        #region Methods
        public List<Event> ReadAll()
        {
            List<Event> events = new List<Event>();
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Events_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Event event1 = new Event();
                                event1.EventID = reader.GetGuid(reader.GetOrdinal("EventID"));
                                event1.EventName = reader.GetString(reader.GetOrdinal("EventName"));
                                event1.Description = reader.GetString(reader.GetOrdinal("Description"));
                                events.Add(event1);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
            }
            return events;
        }
        public void Insert(Event event1)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

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
        public void ReadById(Guid Id)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";
            Event event1 = new Event();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Events_ReadById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@EventID", Id));

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                event1.EventID = reader.GetGuid(reader.GetOrdinal("EventID"));
                                event1.EventName = reader.GetString(reader.GetOrdinal("EventName"));
                                event1.Description = reader.GetString(reader.GetOrdinal("Description"));
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
            Event event1 = new Event();
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Events_UpdateById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EventID", Id));
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
        public void DeleteById(Guid Id)
        {
            string connectionString = "Data Source=LIGIA-PC\\SQLEXPRESS;Initial Catalog=Community;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Events_DeleteById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EventID", Id));
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
