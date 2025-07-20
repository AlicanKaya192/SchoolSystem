using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please enter your number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FrmStudentNote frmStudentNote = new FrmStudentNote();
                frmStudentNote.no = textBox1.Text; // Assuming textBox1 contains the student ID
                frmStudentNote.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmTeacher frmTeacher = new FrmTeacher();
            frmTeacher.Show();
            this.Hide(); // Hide the current form
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
        }
    }
}
