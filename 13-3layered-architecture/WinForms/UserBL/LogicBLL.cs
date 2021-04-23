using Department.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Department.BLL
{
    public class LogicBLL : ILogicBLL
    {
        private readonly IUserDAO _userDAO;
        private readonly IAwardDAO _awardDAO;

        public LogicBLL(IUserDAO userDAO, IAwardDAO awardDAO)
        {
            _userDAO = userDAO;
            _awardDAO = awardDAO;
        }

        public void AddAward(Awards award)
        {
            if (award == null)
                throw new ArgumentNullException("Award is null");
            _awardDAO.AddAward(award);
        }

        public void AddUser(string name, string lastName, DateTime birthdate)
        {
            User user = new User(name, lastName, birthdate);
            this.AddUser(user);
        }

        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User is null");
            _userDAO.AddUser(user);
        }

        public void AddUserAward(User user, List<Awards> awards)
        {
            if (user == null)
                throw new ArgumentNullException("User is null");
            if(awards == null)
                throw new ArgumentNullException("User is null");
            _userDAO.AddUser(user);
            foreach (var award in awards)
            {
                _userDAO.GetCurrentUser(user.ID).AddAward(award);
            }
        }

        public void EditAward(int index, Awards newAward)
        {
            _awardDAO.EditAward(index, newAward);
        }

        public void EditUser(int index, User newUser, List<Awards> awards)
        {
            _userDAO.EditUser(index, newUser);
            newUser.ClearAwards();
            foreach (var award in awards)
            {
                _userDAO.GetCurrentUser(newUser.ID).AddAward(award);
            }
        }

        public IEnumerable<Awards> GetAwardList()
        {
            return _awardDAO.GetAwardList();
        }

        public Awards GetCurrentAward(int ID)
        {
            return _awardDAO.GetCurrentAward(ID);
        }

        public User GetCurrentUser(int index)
        {
            return _userDAO.GetCurrentUser(index);
        }

        public IEnumerable<User> GetUserList()
        {
            return _userDAO.GetUserList();
        }

        public void RemoveAward(Awards award)
        {
            if (award == null)
                throw new ArgumentNullException("Award is null");
            foreach (var user in _userDAO.GetUserList())
            {
                user.RemoveAward(award);
            }
            _awardDAO.RemoveAward(award);
        }

        public void RemoveUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User is null");
            _userDAO.RemoveUser(user);
        }

        //public IEnumerable<User> SortUserByASC(int index)
        //{
        //     return _userDAO.GetUserList().ToList().OrderBy(getUsers[index]);
        //}

        //public IEnumerable<User> SortUserByDESC(int index)
        //{
        //    return _userDAO.GetUserList().ToList().OrderByDescending(getUsers[index]);
        //}

        public void SortUserByASC(int index)
        {
            _userDAO.SortUserByASC(getUsers, index);
        }

        public void SortUserByDESC(int index)
        {
            _userDAO.SortUserByDESC(getUsers, index);
        }
        public void SortAwardByASC(int index)
        {
            _awardDAO.SortAwardByASC(getAwards, index);
        }

        public void SortAwardByDESC(int index)
        {
            _awardDAO.SortAwardByDESC(getAwards, index);
        }

        private Func<User, object>[] getUsers =
{
               user => user.ID,
               user => user.FirstName,
               user => user.LastName,
               user => user.Birthdate,
               user => user.Age,
               user => user.Award
        };
        private Func<Awards, object>[] getAwards =
       {
               award => award.ID,
               award => award.Title,
               award => award.Description
        };
    }
}
