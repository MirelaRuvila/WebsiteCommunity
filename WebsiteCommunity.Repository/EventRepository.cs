using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using System.Data.SqlClient;
using WebsiteCommunity.Repository.Core;
using WebsiteCommunity.RepositoryAbstraction;

namespace WebsiteCommunity.Repository
{
    public class EventRepository : BaseRepository<Event> , IEventRepository
    {
        #region Methods
        public List<Event> ReadAll()
        {
            return DatabaseManager.ReadAll<Event>(connectionString, "Events_ReadAll", GetModelFromReader);
        }
        public Event Insert(Event event1)
        {
            return DatabaseManager.ExecuteNonQuery<Event>(event1, connectionString, "Events_Create", GetParameters);
        }
        public Event ReadById(Guid id)
        {
            return DatabaseManager.ReadById<Event>(connectionString, "Events_ReadById", "@EventID", id, GetModelFromReader);
        }
        public Event UpdateById(Event event1)
        { 
           return DatabaseManager.ExecuteNonQuery<Event>(event1, connectionString, "Events_UpdateById", GetParameters);
        }
        public Event Delete(Guid id)
        {
            return DatabaseManager.Delete<Event>(connectionString, "Events_DeleteById", "@EventID", id);
        }

        protected override Event GetModelFromReader(SqlDataReader reader)
        {
            Event event1 = new Event();
            event1.EventID = reader.GetGuid(reader.GetOrdinal("EventID"));
            event1.EventName = reader.GetString(reader.GetOrdinal("EventName"));
            event1.Description = reader.GetString(reader.GetOrdinal("Description"));
            return event1;

        }
        protected override SqlParameter[] GetParameters(Event event1)
        {
            SqlParameter[] parameter = { new SqlParameter("@EventID", event1.EventID),
                                         new SqlParameter("@EventName", event1.EventName),
                                         new SqlParameter("@Description", event1.Description) };
            return parameter;
        }
        #endregion 
    }
}
