using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolSystem
{
    public partial class FrmStudentNote : Form
    {
        public FrmStudentNote()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=ALICAN\SQLEXPRESS;Initial Catalog=SchoolSystem;Integrated Security=True;TrustServerCertificate=True");

        public string no;

        private void FrmStudentNote_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT LectureName,Exam1,Exam2,Exam3,ProjectNote,Average,Status FROM TBL_Notes \r\nINNER JOIN TBL_Lectures ON TBL_Notes.LectureID=TBL_Lectures.LectureID Where StudentID=@p1", connection);
            command.Parameters.AddWithValue("@p1", no);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();

            SqlCommand command2 = new SqlCommand("SELECT StudentName,StudentSurname FROM TBL_Students WHERE StudentID=@p1", connection);
            command2.Parameters.AddWithValue("@p1", no);

            connection.Open();
            SqlDataReader dr = command2.ExecuteReader();
            while(dr.Read())
            {
                this.Text = dr[0] + " " + dr[1];
            }
            connection.Close();
        }
    }
}
