using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.DAL
{
    public class UserDAO //: IUserDAO
    {
        private List<User> _users = new List<User>();
        public void AddUser(User user)
        {
            if (user == null) 
                throw new ArgumentNullException("User");

            _users.Add(user);
        }

        public IEnumerable<User> GetUserList()
        {
            return _users;
        }     


        public void EditUser(int ID, User newUser)
        {
            int index = _users.FindIndex(u=>u.ID == ID);
            _users[index] = newUser;
        }

        public void RemoveUser(int userID)
        {
            _users.Remove(GetCurrentUser(userID));
        }

        public User GetCurrentUser(int ID)
        {
            return _users.FirstOrDefault(u=> u.ID == ID);
        }

        public IEnumerable<User> SortUserByASC(Func<User,object>[] sortDelegate, int index)
        {
            return _users = _users.OrderBy(sortDelegate[index]).ToList();
        }
        public IEnumerable<User> SortUserByDESC(Func<User, object>[] sortDelegate, int index)
        {
            return _users = _users.OrderByDescending(sortDelegate[index]).ToList();
        }

        public IEnumerable<User> SortUserByASC(int index)
        {
            return null;
        }

        public void AddUserAward(int userID, int awardID)
        {
           
        }


        public void ClearUserAwards(int userID)
        {
            
        }

        IEnumerable<int> GetUserAwards(int userID)
        {
            return null;
        }
    }
}
