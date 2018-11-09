using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAHP
{
    public partial class Calculate : Form
    {
        public Calculate()
        {
            InitializeComponent();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ratingMatrix_Click(object sender, EventArgs e)
        {

        }

        public void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AHPForm().Show();
        }


        private void Calculate_Load(object sender, EventArgs e)
        {


        }
    }
}