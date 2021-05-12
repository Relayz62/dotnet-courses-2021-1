using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Department.BLL;
using Department.DAL;
using Department.DAL.SQL;

namespace _13_3layered_netcore
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUserDAO userDAO = new SQLUserDAO();
            IAwardDAO awardDAO = new SQLAwardsDAO();
            ILogicBLL logicBLL = new LogicBLL(userDAO, awardDAO);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(logicBLL));
        }
    }
}
