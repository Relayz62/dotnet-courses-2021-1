using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Department.DAL;
using Department.BLL;
using Microsoft.AspNetCore.Http;
using PLL.Models;

namespace PLL.Controllers
{
    public class UsersController : Controller
    {
        private IUserDAO _userDAO;
        private IAwardDAO _awardDAO;
        private ILogicBLL _logicBLL;
        public UsersController()
        {
            _userDAO = new SQLUserDAO();
            _awardDAO = new SQLAwardsDAO();
            _logicBLL = new LogicBLL(_userDAO, _awardDAO);
        }
        public IActionResult Index()
        {
            ViewBag.HeaderText = "Users List";
            return View(_logicBLL.GetUserList());
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(int ID)
        {
            _logicBLL.RemoveUser(ID);
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit(int ID)
        {
            var currentUser = _logicBLL.GetCurrentUser(ID);
            return View(currentUser);
        }
        //public ActionResult Edit(int ID)
        //{
        //    var currentUser = _logicBLL.GetCurrentUser(ID);
        //    return View(UserViewModel.GetViewModel(currentUser, _logicBLL.GetAwardList().ToList()));
        //}
        public IActionResult Save(UserViewModel user, IEnumerable<string> awards)
        {
            
            if (user != null)
            {
                var currentUser = _logicBLL.GetCurrentUser(user.ID);

                if (currentUser != null)
                {
                    currentUser.FirstName = user.FirstName;
                    currentUser.LastName = user.LastName;
                    currentUser.Birthdate = user.Birthdate;
                }
                _logicBLL.EditUser(user.ID, currentUser, currentUser.AwardsList);
                _logicBLL.ClearUserAwards(user.ID);
                foreach (var awardID in awards)
                {
                    _logicBLL.AddUserAward(user.ID, int.Parse(awardID));
                }
            }
            return RedirectToAction("Index");
        }
        //public IActionResult Save(UserViewModel userModel)
        //{
        //    if (userModel != null)
        //    {
        //        var currentUser = _logicBLL.GetCurrentUser(userModel.ID);
        //        if (currentUser != null)
        //        {
        //            var user = userModel.ToUser();
        //            currentUser.FirstName = user.FirstName;
        //            currentUser.LastName = user.LastName;
        //            currentUser.Birthdate = user.Birthdate;
        //            currentUser.AwardsList = user.AwardsList;

        //            foreach (AWa award in userModel.AvailableAwards)
        //            {
        //                _logicBLL.AddUserAward(currentUser.ID, award);
        //            }
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                string firstName = collection["FirstName"];
                string lastName = collection["LastName"];
                DateTime birthdate = Convert.ToDateTime(collection["Birthdate"]);
                User user = new User(firstName, lastName, birthdate);
                _logicBLL.AddUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int ID)
        {
            User currentUser = _logicBLL.GetCurrentUser(ID);
            return View(currentUser);
        }
    }
}
