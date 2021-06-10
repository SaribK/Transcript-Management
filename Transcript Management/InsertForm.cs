﻿using System;
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
    public partial class formInsert : Form
    {
        public formInsert()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OFIG42E\\SQLEXPRESS;Initial Catalog=TranscriptDB;Persist Security Info=True;User ID=sarib;Password=sarib2001");

        //insert into database
        private void button1_Click(object sender, EventArgs e)
        {
            //TODO must check that the course has not already been added (i.e if already added, MessageBox.Show("Course already added"))
            //TODO must check that no text boxes are left empty
            //TODO must check that int required text boxes are only given numbers
            con.Open();
            SqlCommand command = new SqlCommand("insert into grades_table values ('"+ txtCourseName.Text + "','" + txtCourseCode.Text + "','" + int.Parse(comboBox1.Text) + "','" + txtGrade.Text + "')", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted.");
            con.Close();
            BindData();
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("select courseName as 'Course Name', courseCode as 'Course Code', courseYear as 'Year Taken', courseGrade as 'Grade' from grades_table", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        //update database
        private void button2_Click(object sender, EventArgs e)
        {
            //TODO if txtbox has no text, do not change that column
            con.Open();
            SqlCommand command = new SqlCommand("update grades_table set " + "courseName = '" + txtCourseName.Text + "', courseYear ='" + comboBox1.Text + "', courseGrade = '" + txtGrade.Text + "' where courseCode = '" + txtCourseCode.Text + "'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated.");
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //TODO if courseCode does not exist, as them to enter a valid course code
            if (txtCourseCode.Text != "")
            {
                if (MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Delete grades_table where courseCode = '" + txtCourseCode.Text + "'", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Deleted.");
                    BindData();
                }
            }
            else
            {
                MessageBox.Show("Enter a course code");
            }
        }

        private void formInsert_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}