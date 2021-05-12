using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Department.DAL
{
    public class SQLUserDAO : IUserDAO, IDisposable
    {
        private SqlConnection _connection;
        public SQLUserDAO()
        {
            _connection = new SqlConnection(Configuration.ConfigurationLoad());
        }

        public void AddUser(User user)
        {
            using (var command = new SqlCommand())
            {
                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = _connection;

                command.Parameters.AddWithValue("@firstName", user.FirstName);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("@birthday", user.Birthdate);

                command.Prepare();
                _connection.Open();


                var result = command.ExecuteScalar();

                _connection.Close();

            }
        }

        public void AddUserAward(int userID, int awardID)
        {
            using (var command = new SqlCommand())
            {
                command.CommandText = "AddUserAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = _connection;

                command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                command.Parameters.AddWithValue("@awardID", awardID);

                command.Prepare();
                _connection.Open();


                var result = command.ExecuteScalar();

                _connection.Close();

            }
        }

        public void ClearUserAwards(int userID)
        {
            using (var command = new SqlCommand())
            {
                command.CommandText = "ClearUserAwards";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = _connection;

                command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;

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

        public void EditUser(int index, User newUser)
        {
            using (var command = new SqlCommand())
            {
                command.CommandText = "ChangeUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = _connection;

                command.Parameters.AddWithValue("@id", index);
                command.Parameters.AddWithValue("@firstName", newUser.FirstName);
                command.Parameters.AddWithValue("@lastName", newUser.LastName);
                command.Parameters.AddWithValue("@birthday", newUser.Birthdate);

                command.Prepare();
                _connection.Open();


                var result = command.ExecuteScalar();

                _connection.Close();

            }
        }

        public User GetCurrentUser(int index)
        {
            using (SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName, Birthday FROM Users WHERE Id = @ID", _connection))
            {
                _connection.Open();
                command.Parameters.Add("@ID", SqlDbType.Int).Value = index;
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ID = (int)reader["ID"];
                        string firstName = (string)reader.GetValue("FirstName");
                        string lastName = (string)reader.GetValue("LastName");
                        DateTime birthdate = (DateTime)reader.GetValue("Birthday");
                        _connection.Close();
                        return new User(firstName, lastName, birthdate) { ID = ID };
                    }
                }
            }
            _connection.Close();
            return null;
        }

        public IEnumerable<int> GetUserAwards(int userID)
        {
            using (var command = new SqlCommand())
            {
                command.CommandText = "GetUserAwards";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = _connection;

                command.Parameters.AddWithValue("@userID", userID);

                command.Prepare();
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int awardsID = (int)reader["AwardID"];

                        yield return awardsID;
                    }                    
                }
                _connection.Close();


            }
        }

        public IEnumerable<User> GetUserList()
        {
            using (SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName, Birthday FROM Users", _connection))
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ID = (int)reader["ID"];
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        DateTime birthdate = (DateTime)reader["Birthday"];

                        yield return new User(firstName, lastName, birthdate) { ID = ID };
                    }
                }
                _connection.Close();
            }

        }

        public void RemoveUser(int userID)
        {
            using (var command = new SqlCommand())
            {
                command.CommandText = "DeleteUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = _connection;

                command.Parameters.Add("@id", SqlDbType.Int).Value = userID;

                command.Prepare();
                _connection.Open();


                var result = command.ExecuteScalar();

                _connection.Close();

            }
        }

        public IEnumerable<User> SortUserByASC(int index)
        {
            //using (SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName, Birthday FROM Users Order By ID DESC", _connection))
            //{
            //    _connection.Open();
            //    command.Parameters.Add("@column", SqlDbType.Int).Value = index;
            //    command.Prepare();

            //    var result = command.ExecuteScalar();

            //    _connection.Close();
            //    return GetUserList();
            //}
            return GetUserList();
        }

        public IEnumerable<User> SortUserByASC(Func<User, object>[] sortDelegate, int index)
        {
            return null;
        }

        public IEnumerable<User> SortUserByDESC(Func<User, object>[] sortDelegate, int index)
        {
            return null;
        }
    }
}
