using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1ListaPrzebojów
{
    public partial class InsertingDate2 : Form
    {
        public InsertingDate2()
        {
            InitializeComponent();
        }

        private void InsertingDate2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var insertingDate = new InsertingDiffrent();
            insertingDate.Closed += (s, args) => this.Close();
            insertingDate.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main = new MainProgram();
            main.Closed += (s, args) => this.Close();
            main.Show();
        }
    }
}
