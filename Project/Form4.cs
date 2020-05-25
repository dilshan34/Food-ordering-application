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

namespace Project
{
    public partial class Form4 : Form
    {
        SqlDataAdapter sda;

        DataTable dt;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select the table");
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db2.mdf;Integrated Security=True;Connect Timeout=30");

            SqlCommand r = new SqlCommand("Update orderdb SET pay ='sent' WHERE table_no = '" + comboBox1.Text + "'", con);
            SqlCommand cmd = new SqlCommand("insert into bill (table_no,bill,show_bill) values ('" + comboBox1.Text + "','" + textBox2.Text + "','no')", con);



            try
            {
                con.Open();
                r.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            con.Close();
            MessageBox.Show("SUCCESSFULLY!!!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db1.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            sda = new SqlDataAdapter("select * from food", con);
            dt = new DataTable();
            sda.Fill(dt);


            dataGridView1.DataSource = dt;






            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db2.mdf;Integrated Security=True;Connect Timeout=30");

           
            con.Open();
           
            sda = new SqlDataAdapter("select * from orderdb where pay='requested'", con);
            dt = new DataTable();
            sda.Fill(dt);


            dataGridView2.DataSource = dt;
            






            con.Close();
        }

        private void kitchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 openForm = new Form1();
            openForm.Show();
            Visible = false;
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 openForm = new Form3();
            openForm.Show();
            Visible = false;
        }
    }
}
