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
    public partial class AwardsForm : Form
    {
        public Awards NewAwards { get; set; }
        public AwardsForm()
        {
            InitializeComponent();
        }

        public AwardsForm(Awards awards) : this()
        {
            NewAwards = awards;
            tbTitle.Text = awards.Title;
            tbDescription.Text = awards.Description;
        }

        private void AwardsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (NewAwards is null)
            {
                string title = tbTitle.Text;
                string desc = tbDescription.Text;
                NewAwards = new Awards(title, desc);
                DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
            }
            else
            {
                NewAwards.Title = tbTitle.Text;
                NewAwards.Description = tbDescription.Text;
                DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (btnCancel.Focused) return;
            if (string.IsNullOrEmpty(tbTitle.Text) || tbTitle.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTitle, "Поле не должно быть пустым/длина поля не должна превышать 50 символов.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbTitle, string.Empty);
            }
        }

        private void tbDescription_Validating(object sender, CancelEventArgs e)
        {
            if (btnCancel.Focused) return;
            if (string.IsNullOrEmpty(tbDescription.Text) || tbDescription.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbDescription, "Поле не должно быть пустым/длина поля не должна превышать 50 символов.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbDescription, string.Empty);
            }
        }
    }
}
