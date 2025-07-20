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
    public partial class FrmExamNotes : Form
    {
        public FrmExamNotes()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=ALICAN\SQLEXPRESS;Initial Catalog=SchoolSystem;Integrated Security=True;TrustServerCertificate=True");

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        DataSet1TableAdapters.TBL_NotesTableAdapter noteTableAdapter = new DataSet1TableAdapters.TBL_NotesTableAdapter();

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = noteTableAdapter.NoteList(int.Parse(TxtID.Text));
        }

        private void FrmExamNotes_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM TBL_Lectures", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DisplayMember = "LectureName";
            comboBox1.ValueMember = "LectureID";
            comboBox1.DataSource = dt;
        }

        int noteID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            noteID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            TxtExam1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtExam2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtExam3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProject.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtAverage.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        int exam1, exam2, exam3, project;

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtAverage.Clear();
            TxtExam1.Clear();
            TxtExam2.Clear();
            TxtExam3.Clear();
            TxtProject.Clear();
            TxtStatus.Clear();
            TxtID.Clear();
            comboBox1.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            TxtID.Focus();
        }

        double average;
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                exam1 = Convert.ToInt16(TxtExam1.Text);
                exam2 = Convert.ToInt16(TxtExam2.Text);
                exam3 = Convert.ToInt16(TxtExam3.Text);
                project = Convert.ToInt16(TxtProject.Text);
                average = (exam1 + exam2 + exam3 + project) / 4;

                TxtAverage.Text = average.ToString();
                if (average >= 50)
                {
                    TxtStatus.Text = "True";
                }
                else
                {
                    TxtStatus.Text = "False";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid exam scores", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtExam1.Clear();
                TxtExam2.Clear();
                TxtExam3.Clear();
                TxtProject.Clear();
                TxtAverage.Clear();
                TxtStatus.Clear();
                TxtExam1.Focus();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            noteTableAdapter.NoteUpdate(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(TxtID.Text), byte.Parse(TxtExam1.Text), byte.Parse(TxtExam2.Text), byte.Parse(TxtExam3.Text), byte.Parse(TxtProject.Text), decimal.Parse(TxtAverage.Text),bool.Parse(TxtStatus.Text), noteID);
            MessageBox.Show("Exam notes updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
