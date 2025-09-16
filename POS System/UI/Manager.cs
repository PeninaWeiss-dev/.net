using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            ViewAll viewAll = new ViewAll("Customers");
            this.Hide();
            viewAll.FormClosed += Menu_FormClosed;
            viewAll.Show();

        }
        private void Menu_FormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
