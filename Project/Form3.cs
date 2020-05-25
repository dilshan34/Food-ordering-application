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
using System.Data.Common;
using System.Configuration;

namespace Project
{
    public partial class Form3 : Form
    {
        SqlDataAdapter sda;

        DataTable dt;


        public Form3()
        {
            InitializeComponent();
            showPrize();
            foodList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

          
        }
        void foodList()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db1.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from food ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            listBox1.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                listBox1.Items.Add(row["food_name"].ToString());

            }
            conn.Close();
        }

        private void MoveListBoxItems(ListBox source, ListBox destination)
        {
            ListBox.SelectedObjectCollection sourceItems = source.SelectedItems;
            foreach (var item in sourceItems)
            {
                destination.Items.Add(item);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(listBox1, listBox2);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select the Table");
                return;
            }

            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select the Food");
                return;
            }

            //String item=Text(listBox2.SelectedItems);
            //SqlDataAdapter sda = new SqlDataAdapter("insert into orders (foodname) values ('" + listBox2.SelectedItems + "')", conn);
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db2.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("insert into orderdb (foodname,table_no,pay) values ('" + listBox2.SelectedItem + "','" + comboBox1.Text + "','no')", conn);
            SqlCommand r = new SqlCommand("Update orderdb SET delivery ='no' WHERE table_no = '" + comboBox1.Text + "'", conn);

            listBox2.Items.Remove(listBox2.SelectedItem);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                r.ExecuteNonQuery();
            }



            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }

            

            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select the table");
            }

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db1.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from food ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            listBox1.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                listBox1.Items.Add(row["food_name"].ToString());

            }
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
           
        }

        void showPrize()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db1.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            sda = new SqlDataAdapter("select * from food", con);
            dt = new DataTable();
            sda.Fill(dt);


            dataGridView1.DataSource = dt;






            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select the table");
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db2.mdf;Integrated Security=True;Connect Timeout=30");

            SqlCommand q = new SqlCommand("Update bill SET show_bill ='yes' WHERE table_no = '" + comboBox1.Text + "'", con);


            
            SqlCommand r = new SqlCommand("Update orderdb SET pay ='requested' WHERE table_no = '" + comboBox1.Text + "'", con);


            try
            {
                con.Open();
                q.ExecuteNonQuery();
                r.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            con.Close();
            MessageBox.Show("SUCCESSFULLY!!!");
        }

        private void kitchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 openForm = new Form1();
            openForm.Show();
            Visible = false;
        }

        private void cashierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 openForm = new Form4();
            openForm.Show();
            Visible = false;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select the table");
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DB\db2.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand r = new SqlCommand("Update orderdb SET pay ='paied' WHERE table_no = '" + comboBox1.Text + "'", con);


            con.Open();

            sda = new SqlDataAdapter("select (bill) from bill where show_bill='no' and table_no='"+ comboBox1.Text + "'", con);
            dt = new DataTable();
            sda.Fill(dt);


            dataGridView1.DataSource = dt;
            r.ExecuteNonQuery();







            con.Close();






        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
