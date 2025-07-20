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
    public partial class FrmStudentAffairs : Form
    {
        public FrmStudentAffairs()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=ALICAN\SQLEXPRESS;Initial Catalog=SchoolSystem;Integrated Security=True;TrustServerCertificate=True");

        DataSet1TableAdapters.TBL_StudentsTableAdapter studentsTableAdapter = new DataSet1TableAdapters.TBL_StudentsTableAdapter();
        private void FrmStudentAffairs_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = studentsTableAdapter.StudentList();
            SqlCommand command = new SqlCommand("SELECT * FROM TBL_Clubs", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DisplayMember = "ClubName";
            comboBox1.ValueMember = "ClubID";
            comboBox1.DataSource = dt;
        }

        string g = "";
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            studentsTableAdapter.StudentAdd(TxtName.Text, TxtSurname.Text, byte.Parse(comboBox1.SelectedValue.ToString()), g);
            MessageBox.Show("Student added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = studentsTableAdapter.StudentList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TxtID.Text = comboBox1.SelectedValue.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            studentsTableAdapter.StudentDelete(int.Parse(TxtID.Text));
            MessageBox.Show("Student deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Female")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            studentsTableAdapter.StudentUpdate(TxtName.Text, TxtSurname.Text, byte.Parse(comboBox1.SelectedValue.ToString()), g, int.Parse(TxtID.Text));
            MessageBox.Show("Student updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                g = "Female";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                g = "Male";
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = studentsTableAdapter.BringStudent(TxtSearch.Text);
        }
    }
}
