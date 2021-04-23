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
        void EditUser(int index, User newUser, List<Awards> awards);
        void RemoveUser(User user);
        IEnumerable<User> GetUserList();
        User GetCurrentUser(int ID);
        //IEnumerable<User> SortUserByASC(int index);
        //IEnumerable<User> SortUserByDESC(int index);
        void SortUserByASC(int index);
        void SortUserByDESC(int index);

        void AddAward(Awards award);
        void EditAward(int index, Awards newAward);
        void RemoveAward(Awards award);
        IEnumerable<Awards> GetAwardList();
        Awards GetCurrentAward(int ID);
        void SortAwardByASC(int index);
        void SortAwardByDESC(int index);
    }
}
