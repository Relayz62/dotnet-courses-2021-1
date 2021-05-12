using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Department.BLL;
using Entities;

namespace _13_3layered_netcore
{
    public partial class Main : Form
    {
        private BindingSource _usersBS = new BindingSource();
        private BindingSource _awardsBS = new BindingSource();
        private readonly ILogicBLL _logicBLL;

        private int _currentUserID;
        private int _currentAwardID;
        public Main(ILogicBLL logicBLL)
        {
            InitializeComponent();
            _logicBLL = logicBLL;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(_logicBLL.GetAwardList().ToList());

            if (userForm.ShowDialog() == DialogResult.OK)
            {
                _logicBLL.AddUserAward(userForm.NewUser, userForm.Awards);
                foreach (Awards item in userForm.Awards)
                {
                    _logicBLL.AddUserAward(userForm.NewUser.ID, item.ID);
                }
                UpdateTable();
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            _usersBS.DataSource = _logicBLL.GetUserList();
            _awardsBS.DataSource = _logicBLL.GetAwardList();
            dgvUser.DataSource = _usersBS;
            dgvAwards.DataSource = _awardsBS;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _currentUserID = (int)dgvUser[0, dgvUser.CurrentCell.RowIndex].Value;
            User user = _logicBLL.GetCurrentUser(_currentUserID);
            UserForm userForm = new UserForm(user, _logicBLL.GetAwardList().ToList());

            if (userForm.ShowDialog() == DialogResult.OK)
            {
                _logicBLL.EditUser(_currentUserID, userForm.NewUser, userForm.Awards);
                UpdateTable();
            }
        }

        private void btnAddAwards_Click(object sender, EventArgs e)
        {

            AwardsForm awardsForm = new AwardsForm();

            if (awardsForm.ShowDialog() == DialogResult.OK)
            {
                _logicBLL.AddAward(awardsForm.NewAwards);
                UpdateTable();
            }


        }

        private void btnEditAwards_Click(object sender, EventArgs e)
        {
            _currentAwardID = (int)dgvAwards[0, dgvAwards.CurrentCell.RowIndex].Value;
            Awards award = _logicBLL.GetCurrentAward(_currentAwardID);
            AwardsForm awardsForm = new AwardsForm(award);

            if (awardsForm.ShowDialog() == DialogResult.OK)
            {
                _logicBLL.EditAward(_currentAwardID, awardsForm.NewAwards);
                UpdateTable();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _currentUserID = (int)dgvUser[0, dgvUser.CurrentCell.RowIndex].Value;
                DialogResult result =
                    MessageBox.Show("Вы уверены, что хотите удалить данный элемент?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _logicBLL.RemoveUser(_currentUserID);
                    UpdateTable();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не выбран ни один элемент", "Ошибка");
            }

        }

        private void btnDeleteAwards_Click(object sender, EventArgs e)
        {
            try
            {
                _currentAwardID = (int)dgvAwards[0, dgvAwards.CurrentCell.RowIndex].Value;
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить данный элемент?", "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _logicBLL.RemoveAward(_currentAwardID);
                    UpdateTable();
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Не выбран ни один элемент", "Ошибка");
            }
        }



        private bool isFirstClick = true;
        private void dgvUser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (isFirstClick)
            //{
            //    _logicBLL.SortUserByASC(e.ColumnIndex);
            //    isFirstClick = false;
            //}
            //else
            //{
            //    _logicBLL.SortUserByDESC(e.ColumnIndex);
            //    isFirstClick = true;
            //}
            //UpdateTable();
        }
        private bool isFirstClickAward = true;
        private void dgvAwards_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (isFirstClickAward)
            //{
            //    _logicBLL.SortAwardByASC(e.ColumnIndex);
            //    isFirstClickAward = false;
            //}
            //else
            //{
            //    _logicBLL.SortAwardByDESC(e.ColumnIndex);
            //    isFirstClickAward = true;
            //}
            //UpdateTable();
        }

        private void UpdateTable()
        {
            _usersBS.DataSource = _logicBLL.GetUserList();
            _awardsBS.DataSource = _logicBLL.GetAwardList();
            _usersBS.ResetBindings(true);
            _awardsBS.ResetBindings(true);
        }

        private void btnViewAwards_Click(object sender, EventArgs e)
        {
            try
            {
                _currentUserID = (int)dgvUser[0, dgvUser.CurrentCell.RowIndex].Value;
                List<int> awardIDs = new List<int>();
                List<Awards> usersAwards = new List<Awards>();
                awardIDs.AddRange(_logicBLL.GetUserAwards(_currentUserID));
                foreach (var award in awardIDs)
                {
                    usersAwards.Add(_logicBLL.GetCurrentAward(award));
                }
                if(usersAwards.Count == 0)
                {
                    MessageBox.Show("У пользователя нет наград", "Информация");
                    return;
                }
                UserAwardsForm userAwardsForm = new UserAwardsForm(usersAwards);
                userAwardsForm.ShowDialog();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Ошибка, ничего не выбрано.", "Ошибка");
            }


        }
    }
}
