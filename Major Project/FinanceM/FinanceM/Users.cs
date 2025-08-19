using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinanceM
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddressTb_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HPW\Documents\IemDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        private void Clear()
        {
            UnameTb.Text = "";
            PasswordTb.Text = "";
            PhoneTb.Text = "";
            AddressTb.Text = "";
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PhoneTb.Text == "" || PasswordTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else 
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl(Uname,UDOB,Uphone,UPass,UAddress)values(@UN,@UD,@UP,@UPA,@UA)", Con);
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UD",DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@UP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UPA", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@UA", AddressTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added..!");
                    Con.Close();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
           
        }
    }
}



