using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Department.BLL
{
    public interface ILogicBLL
    {
        void AddUser(string name, string lastName, DateTime birthdate);
        void AddUser(User user);
        void AddUserAward(User user, List<Awards> awards);
        void AddUserAward(int userID, int awardID);
        void ClearUserAwards(int userID);
        void EditUser(int index, User newUser, List<Awards> awards);
        IEnumerable<int> GetUserAwards(int userID);
        void RemoveUser(int userID);
        IEnumerable<User> GetUserList();
        User GetCurrentUser(int ID);
        //IEnumerable<User> SortUserByASC(int index);
        //IEnumerable<User> SortUserByDESC(int index);
        void SortUserByASC(int index);
        void SortUserByDESC(int index);

        void AddAward(Awards award);
        void EditAward(int index, Awards newAward);
        void RemoveAward(int awardID);
        IEnumerable<Awards> GetAwardList();
        Awards GetCurrentAward(int ID);
        void SortAwardByASC(int index);
        void SortAwardByDESC(int index);
    }
}
