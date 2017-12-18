using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebsiteCommunity.Repository.Core
{
    internal class DatabaseManager
    {
        #region Methods
        public static List<TModel> ReadAll<TModel>(string connectionString, string storedProcedureName, Func<SqlDataReader, TModel> getModelFromReader, SqlParameter[] parameters = default(SqlParameter[]))
        {
            List<TModel> result = new List<TModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = storedProcedureName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parameters != null)
                            command.Parameters.AddRange(parameters); //function getParameters

                        connection.Open();
                        command.ExecuteNonQuery();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(getModelFromReader(reader));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
            }

            return result;
        }
        public static TModel ExecuteNonQuery<TModel>(TModel model, string connectionString, string storedProcedureName, Func<TModel, SqlParameter[]> getParameters, SqlParameter[] parameters = default(SqlParameter[]))
            where TModel : new()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = storedProcedureName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        parameters = getParameters(model);
                        if (parameters != null)
                           command.Parameters.AddRange(parameters);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
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
            return default(TModel);
        }
        public static TModel ReadById<TModel>(string connectionString, string storedProcedureName, string parameterName, Guid id, Func<SqlDataReader, TModel> getModelFromReader)
        {
            List<TModel> result = new List<TModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = storedProcedureName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(parameterName, id));

                        connection.Open();
                        command.ExecuteNonQuery();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               result.Add(getModelFromReader(reader));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error {0}", ex.ToString());
                }
            }
            return result.Single();
        }
        public static TModel Delete<TModel>(string connectionString, string storedProcedureName, string parameterName, Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = storedProcedureName;
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter(parameterName, id));
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
            return default(TModel);
        }
        #endregion
    }
}
