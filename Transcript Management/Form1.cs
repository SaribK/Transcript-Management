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
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OFIG42E\\SQLEXPRESS;Initial Catalog=TranscriptDB;Persist Security Info=True;User ID=sarib;Password=sarib2001");

        //Insert into database
        private void button1_Click(object sender, EventArgs e)
        {
            //must check that the course has not already been added (i.e if already added, MessageBox.Show("Course already added"))
            con.Open();
            SqlCommand command = new SqlCommand("insert into grades_table values ('"+ txtCourseName.Text + "','" + txtCourseCode.Text + "','" + int.Parse(comboBox1.Text) + "','" + txtGrade.Text + "')", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted.");
            con.Close();
            BindData();
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from grades_table", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
