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
    public partial class FrmClubs : Form
    {
        public FrmClubs()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=ALICAN\SQLEXPRESS;Initial Catalog=SchoolSystem;Integrated Security=True;TrustServerCertificate=True");
        private void FrmClubs_Load(object sender, EventArgs e)
        {
            list();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            list();
        }

        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tbl_Clubs", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Tbl_Clubs (ClubName) VALUES (@p1)", connection);
            command.Parameters.AddWithValue("@p1", TxtClubName.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Club added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Tbl_Clubs SET ClubName=@p1 WHERE ClubID=@p2", connection);
            command.Parameters.AddWithValue("@p1", TxtClubName.Text);
            command.Parameters.AddWithValue("@p2", TxtClubID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Club updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Tbl_Clubs WHERE ClubID=@p1", connection);
            command.Parameters.AddWithValue("@p1", TxtClubID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Club deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightYellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtClubID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtClubName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
