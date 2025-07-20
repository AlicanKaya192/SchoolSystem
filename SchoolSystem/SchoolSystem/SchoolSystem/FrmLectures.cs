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
    public partial class FrmLectures : Form
    {
        public FrmLectures()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TBL_LecturesTableAdapter adapter = new DataSet1TableAdapters.TBL_LecturesTableAdapter();
        private void FrmLectures_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = adapter.LectureList();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            adapter.LectureAdd(TxtLectureName.Text);
            MessageBox.Show("Lecture added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = adapter.LectureList();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            adapter.LectureDelete(byte.Parse(TxtLectureID.Text));
            MessageBox.Show("Lecture deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            adapter.LectureUpdate(TxtLectureName.Text, byte.Parse(TxtLectureID.Text));
            MessageBox.Show("Lecture updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtLectureID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtLectureName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
