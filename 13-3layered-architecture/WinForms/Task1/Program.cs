using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Department.BLL;
using Department.DAL;

namespace Task1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUserDAO userDAO = new UserDAO();
            IAwardDAO awardDAO = new AwardsDAO();
            ILogicBLL logicBLL = new LogicBLL(userDAO, awardDAO);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(logicBLL));
        }
    }
}
