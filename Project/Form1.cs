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

using System.Data.SqlClient;

namespace Project
{
    public partial class Form1 : Form
    {
        SqlDataAdapter sda;
        
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
            fillCombo();
            show();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db1.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
           SqlCommand cmd = new SqlCommand("insert into food (food_name,prize) values ('" + textBox1.Text + "','" + textBox2.Text + "')", con);


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }



            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }


            MessageBox.Show("Inserted Successfully ");

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand r = new SqlCommand("Update food SET prize ='" + textBox4.Text + "' WHERE Id = '" + textBox3.Text + "'", con);


            try
            {
                con.Open();
                r.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            con.Close();
            MessageBox.Show("SUCCESSFULLY!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand r = new SqlCommand("DELETE FROM food where Id= '" + textBox5.Text + "'", con);
            try
            {
                con.Open();
                r.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            con.Close();
            MessageBox.Show("DELETED!!!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db1.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            sda = new SqlDataAdapter("select * from food", con);
            dt = new DataTable();
            sda.Fill(dt);


            dataGridView1.DataSource = dt;






            con.Close();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 openForm = new Form3();
            openForm.Show();
            Visible = false;

            
        }

        private void kitchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 openForm = new Form4();
            openForm.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }






        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select the Table");
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db2.mdf;Integrated Security=True;Connect Timeout=30");

            SqlCommand r = new SqlCommand("Update orderdb SET delivery ='sent' WHERE Id = '" + comboBox1.SelectedItem + "'", con);


            try
            {
                con.Open();
                r.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            con.Close();
            Form1 openForm = new Form1();
            openForm.Show();
            Visible = false;


        }
        void fillCombo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db2.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                con.Open();

                SqlDataReader dr = new SqlCommand("select * from orderdb where delivery='no' ", con).ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr.GetValue(0).ToString());
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }



            con.Close();







        }

        void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db2.mdf;Integrated Security=True;Connect Timeout=30");


            con.Open();

            sda = new SqlDataAdapter("select * from orderdb where delivery='no'", con);
            dt = new DataTable();

            try
            {
                sda.Fill(dt);


                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }






            con.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db2.mdf;Integrated Security=True;Connect Timeout=30");


            con.Open();

            sda = new SqlDataAdapter("select * from orderdb where delivery='no'", con);
            dt = new DataTable();

            try
            {
                sda.Fill(dt);


                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }






            con.Close();

        }
    }
}
