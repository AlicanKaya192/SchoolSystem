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
    public partial class FrmTeachers : Form
    {
        public FrmTeachers()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=ALICAN\SQLEXPRESS;Initial Catalog=SchoolSystem;Integrated Security=True;TrustServerCertificate=True");
        private void FrmTeachers_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM TBL_Lectures", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DisplayMember = "LectureName";
            comboBox1.ValueMember = "LectureID";
            comboBox1.DataSource = dt;
            list();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            list();
        }

        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TeacherID, LectureName AS Branch, TeacherName FROM TBL_Teachers INNER JOIN TBL_Lectures ON TBL_Teachers.TeacherBranch=TBL_Lectures.LectureID", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO TBL_Teachers (TeacherBranch, TeacherName) VALUES (@p1, @p2)", connection);
            command.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);
            command.Parameters.AddWithValue("@p2", TxtName.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Teacher added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
            TxtID.Clear();
            TxtName.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM TBL_Teachers WHERE TeacherID=@p1", connection);
            command.Parameters.AddWithValue("@p1", TxtID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Teacher deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
            TxtID.Clear();
            TxtName.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE TBL_Teachers SET TeacherBranch=@p1, TeacherName=@p2 WHERE TeacherID=@p3", connection);
            command.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);
            command.Parameters.AddWithValue("@p2", TxtName.Text);
            command.Parameters.AddWithValue("@p3", TxtID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Teacher updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }
    }
}
