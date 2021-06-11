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
    public partial class formHome : Form
    {
        public formHome()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OFIG42E\\SQLEXPRESS;Initial Catalog=TranscriptDB;Persist Security Info=True;User ID=sarib;Password=sarib2001");

        private void button1_Click(object sender, EventArgs e)
        {
            formInsert fI = new formInsert();
            this.Hide();
            fI.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formSearch fS = new formSearch();
            this.Hide();
            fS.ShowDialog();
        }

        private void formHome_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT AVG(courseGrade) as GPA from grades_table", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.SelectCommand.CommandType = CommandType.Text;
            sd.Fill(dt);
            string value = dt.Rows[0].ItemArray[0].ToString();
            label1.Text = "Overall GPA: " + value;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            SqlCommand command2 = new SqlCommand("SELECT AVG(courseGrade) as GPA from grades_table where courseYear = '" + int.Parse(comboBox1.Text) + "'", con);
            SqlDataAdapter sd2 = new SqlDataAdapter(command2);
            DataTable dt2 = new DataTable();
            sd2.SelectCommand.CommandType = CommandType.Text;
            sd2.Fill(dt2);
            string value2 = dt2.Rows[0].ItemArray[0].ToString();
            if (value2 == "")
            {
                label2.Text = "Specific Year GPA: N/A";
            }
            else
            {
                label2.Text = "Specific Year GPA: " + value2;
            }
        }
    }
}
