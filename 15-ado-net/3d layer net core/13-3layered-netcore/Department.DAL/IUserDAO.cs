using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Department.DAL
{
    public interface IUserDAO
    {
        void AddUser(User user);
        void EditUser(int index, User newUser);
        void RemoveUser(int userID);
        void AddUserAward(int userID, int awardID);
        IEnumerable<int> GetUserAwards(int userID);
        void ClearUserAwards(int userID);
        IEnumerable<User> SortUserByASC(Func<User, object>[] sortDelegate, int index);
        IEnumerable<User> SortUserByASC(int index);
        IEnumerable<User> SortUserByDESC(Func<User, object>[] sortDelegate, int index);

        IEnumerable<User> GetUserList();
        User GetCurrentUser(int index);
    }
}
