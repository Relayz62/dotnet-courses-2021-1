using Department.BLL;
using Department.DAL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLL.Controllers
{
    public class AwardsController : Controller
    {
        private IUserDAO _userDAO;
        private IAwardDAO _awardDAO;
        private ILogicBLL _logicBLL;
        public AwardsController()
        {
            _userDAO = new SQLUserDAO();
            _awardDAO = new SQLAwardsDAO();
            _logicBLL = new LogicBLL(_userDAO, _awardDAO);
        }
        public IActionResult Index()
        {
            ViewBag.HeaderText = "Awards List";
            return View(_logicBLL.GetAwardList());
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
            var currentAward = _logicBLL.GetCurrentAward(ID);
            return View(currentAward);
        }
        public IActionResult Save(AwardViewModel award)
        {
            if (award != null)
            {
                var currentAward = _logicBLL.GetCurrentAward(award.ID);
                if (currentAward != null)
                {
                    currentAward.Title = award.Title;
                    currentAward.Description = award.Description;
                }
                _logicBLL.EditAward(award.ID, currentAward);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                string title = collection["Title"];
                string desciprtion = collection["Description"];
                Awards award = new Awards(title, desciprtion);
                _logicBLL.AddAward(award);

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
    }
}
