using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Department.DAL
{
    public class SQLAwardsDAO : IAwardDAO, IDisposable
    {
        private SqlConnection _connection;
        public SQLAwardsDAO()
        {
            //_connection = new SqlConnection(Configuration.ConfigurationLoad());
            _connection = new SqlConnection(Configuration.Load());
        }
        public void AddAward(Awards award)
        {
            using (var command = new SqlCommand())
            {
                command.CommandText = "AddAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = _connection;

                command.Parameters.AddWithValue("@title", award.Title);
                command.Parameters.AddWithValue("@description", award.Description);

                command.Prepare();
                _connection.Open();


                var result = command.ExecuteScalar();

                _connection.Close();

            }
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }

        public void EditAward(int index, Awards newAward)
        {
            using (var command = new SqlCommand())
            {
                command.CommandText = "ChangeAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = _connection;

                command.Parameters.AddWithValue("@id", index);
                command.Parameters.AddWithValue("@title", newAward.Title);
                command.Parameters.AddWithValue("@description", newAward.Description);

                command.Prepare();
                _connection.Open();


                var result = command.ExecuteScalar();

                _connection.Close();

            }
        }

        public IEnumerable<Awards> GetAwardList()
        {
            using (SqlCommand command = new SqlCommand("SELECT Id, Title, Description FROM Awards", _connection))
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ID = (int)reader["ID"];
                        string title = (string)reader["Title"];
                        string description = (string)reader["Description"];

                        yield return new Awards(title, description) { ID = ID };
                    }
                }
                _connection.Close();
            }
        }

        public Awards GetCurrentAward(int index)
        {
            using (SqlCommand command = new SqlCommand("SELECT Id, Title, Description FROM Awards WHERE Id = @ID", _connection))
            {
                _connection.Open();
                command.Parameters.Add("@ID", SqlDbType.Int).Value = index;
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ID = (int)reader["Id"];
                        string title = (string)reader["Title"];
                        string description = (string)reader["Description"];
                        _connection.Close();
                        return new Awards(title, description) { ID = ID }; 
                    }
                }
            }
            _connection.Close();
            return null;
        }

        public void RemoveAward(int awardID)
        {
            using (var command = new SqlCommand())
            {
                command.CommandText = "DeleteAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = _connection;

                command.Parameters.Add("@id", SqlDbType.Int).Value = awardID;

                command.Prepare();
                _connection.Open();


                var result = command.ExecuteScalar();

                _connection.Close();

            }
        }

        public IEnumerable<Awards> SortAwardByASC(Func<Awards, object>[] sortDelegate, int index)
        {
            return GetAwardList();
        }

        public IEnumerable<Awards> SortAwardByDESC(Func<Awards, object>[] sortDelegate, int index)
        {
            return GetAwardList();
        }
    }
}
