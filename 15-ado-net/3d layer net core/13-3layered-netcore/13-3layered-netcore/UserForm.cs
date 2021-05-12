using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace _13_3layered_netcore
{
    public partial class UserForm : Form
    {
        public User NewUser { get; set; }
        public List<Awards> Awards = new List<Awards>();

        public UserForm(List<Awards> awardsList)
        {
            InitializeComponent();
            Awards = awardsList;
            clbAwards.Visible = false;
        }
        public UserForm(User user, List<Awards> awardsList)
        {
            InitializeComponent();
            clbAwards.Visible = true;
            NewUser = user;
            tbName.Text = user.FirstName;
            tbLastName.Text = NewUser.LastName;
            dtpBirthdate.Value = NewUser.Birthdate;
            Awards = awardsList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NewUser is null)
            {
                string firstName = tbName.Text;
                string lastName = tbLastName.Text;
                DateTime birthdate = dtpBirthdate.Value;
                NewUser = new User(firstName, lastName, birthdate);
                UpdateAward();
                DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
            }
            else
            {
                NewUser.FirstName = tbName.Text;
                NewUser.LastName = tbLastName.Text;
                NewUser.Birthdate = dtpBirthdate.Value;
                UpdateAward();
                DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            foreach (var award in Awards)
            {
                clbAwards.Items.Add(award.Title);
            }
        }

        private void UpdateAward()
        {
            List<Awards> temp = new List<Awards>();
            for (int i = 0; i < clbAwards.Items.Count; i++)
            {
                if (clbAwards.GetItemChecked(i) == true &&
                    clbAwards.Items[i].ToString() == Awards[i].Title)
                    temp.Add(Awards[i]);
            }
            Awards = temp;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (btnCancel.Focused) return;
            if (string.IsNullOrEmpty(tbName.Text) || tbName.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbName, "Поле не должно быть пустым/длина поля не должна превышать 50 символов.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbName, string.Empty);
            }
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (btnCancel.Focused) return;
            if (string.IsNullOrEmpty(tbLastName.Text) || tbLastName.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbLastName, "Поле не должно быть пустым/длина поля не должна превышать 50 символов.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbLastName, string.Empty);
            }
        }
    }
}
