using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;

namespace _13_3layered_netcore
{
    public partial class UserAwardsForm : Form
    {
        public UserAwardsForm(List<Awards> awards)
        {
            InitializeComponent();
            dataGridView1.DataSource = awards;
        }

        private void UserAwards_Load(object sender, EventArgs e)
        {

        }
    }
}
