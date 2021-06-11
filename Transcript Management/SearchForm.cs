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

namespace Transcript_Management
{
    public partial class formSearch : Form
    {
        public formSearch()
        {
            InitializeComponent();
        }

        private void formSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OFIG42E\\SQLEXPRESS;Initial Catalog=TranscriptDB;Persist Security Info=True;User ID=sarib;Password=sarib2001");

        //search database
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT courseName as 'Course Name', courseCode as 'Course Code', courseYear as 'Year Taken', courseGrade as 'Grade' FROM grades_table where courseCode LIKE '%" + txtCourseCode.Text+"%'", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
