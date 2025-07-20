using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolSystem
{
    public partial class FrmTeacher : Form
    {
        public FrmTeacher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmClubs frmClubs = new FrmClubs();
            frmClubs.Show();
        }

        private void BtnLecture_Click(object sender, EventArgs e)
        {
            FrmLectures frmLectures = new FrmLectures();
            frmLectures.Show();
        }

        private void BtnStudentAffairs_Click(object sender, EventArgs e)
        {
            FrmStudentAffairs frmStudentAffairs = new FrmStudentAffairs();
            frmStudentAffairs.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnExamNotes_Click(object sender, EventArgs e)
        {
            FrmExamNotes frmExamNotes = new FrmExamNotes();
            frmExamNotes.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmTeachers frmTeachers = new FrmTeachers();
            frmTeachers.Show();
        }
    }
}
