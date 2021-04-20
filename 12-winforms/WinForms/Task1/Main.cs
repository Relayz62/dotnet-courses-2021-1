using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Main : Form
    {
        private BindingList<User> _userBL = new BindingList<User>();
        private BindingList<Awards> _awardsBL = new BindingList<Awards>();
        public Main()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(_awardsBL);

            if (userForm.ShowDialog() == DialogResult.OK)
            {
                _userBL.Add(userForm.NewUser);
                foreach (var award in userForm.Awards)
                {
                    userForm.NewUser.AddAward(award);
                }
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            dgvUser.DataSource = _userBL;
            dgvAwards.DataSource = _awardsBL;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            User user = _userBL[dgvUser.CurrentCell.RowIndex];
            UserForm userForm = new UserForm(user, _awardsBL);

            if (userForm.ShowDialog() == DialogResult.OK)
            {
                _userBL[dgvUser.CurrentCell.RowIndex] = userForm.NewUser;
                userForm.NewUser.ClearAward();
                foreach (var award in userForm.Awards)
                {
                    userForm.NewUser.AddAward(award);
                }
            }
        }

        private void btnAddAwards_Click(object sender, EventArgs e)
        {

            AwardsForm awardsForm = new AwardsForm();

            if (awardsForm.ShowDialog() == DialogResult.OK)
            {
                _awardsBL.Add(awardsForm.NewAwards);
            }


        }

        private void btnEditAwards_Click(object sender, EventArgs e)
        {
            Awards awards = _awardsBL[dgvAwards.CurrentCell.RowIndex];
            if (awards == null) return;
            AwardsForm awardsForm = new AwardsForm(awards);

            if (awardsForm.ShowDialog() == DialogResult.OK)
            {
                _awardsBL[dgvAwards.CurrentCell.RowIndex] = awardsForm.NewAwards;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_userBL[dgvUser.CurrentCell.RowIndex] == null) return;
            DialogResult result =
                MessageBox.Show("Вы уверены, что хотите удалить данный элемент?",
                "Подтверждение",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _userBL.Remove(_userBL[dgvUser.CurrentCell.RowIndex]);
            }
        }

        private void btnDeleteAwards_Click(object sender, EventArgs e)
        {
            if (_awardsBL[dgvAwards.CurrentCell.RowIndex] == null) return;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить данный элемент?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (User user in _userBL)
                {
                    user.RemoveAward(_awardsBL[dgvAwards.CurrentCell.RowIndex]);
                }
                _awardsBL.Remove(_awardsBL[dgvAwards.CurrentCell.RowIndex]);
            }
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


        private bool isFirstClick = true;
        private void dgvUser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (isFirstClick)
            {
                _userBL = new BindingList<User>(_userBL.OrderBy(getUsers[e.ColumnIndex]).ToList());
                isFirstClick = false;
            }
            else
            {
                _userBL = new BindingList<User>(_userBL.OrderByDescending(getUsers[e.ColumnIndex]).ToList());
                isFirstClick = true;
            }
            dgvUser.DataSource = _userBL;
        }
        private bool isFirstClickAward = true;
        private void dgvAwards_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (isFirstClickAward)
            {
                _awardsBL = new BindingList<Awards>(_awardsBL.OrderBy(getAwards[e.ColumnIndex]).ToList());
                isFirstClickAward = false;
            }
            else
            {
                _awardsBL = new BindingList<Awards>(_awardsBL.OrderByDescending(getAwards[e.ColumnIndex]).ToList());
                isFirstClickAward = true;
            }
            dgvAwards.DataSource = _awardsBL;
        }
    }
}
