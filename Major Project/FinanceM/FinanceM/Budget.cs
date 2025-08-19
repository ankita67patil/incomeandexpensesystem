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
    public partial class Budget : Form
    {
        public Budget()
        {
            InitializeComponent();
            GetTotBud();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Incomes Obj = new Incomes();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewIncomes Obj = new ViewIncomes();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HPW\Documents\IemDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        private void Clear()
        {
            BudAmtTb.Text = "";
            BudDescTb.Text = "";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (BudAmtTb.Text == "" || BudDescTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Budget(BudAmt,BudsDate,BudeDate,BudDesc,BudUser)values(@BA,@BDs,@BDe,@BDes,@BU)", Con);
                    cmd.Parameters.AddWithValue("@BA", BudAmtTb.Text);
                    cmd.Parameters.AddWithValue("@BDs", BudsDate.Value.Date);
                    cmd.Parameters.AddWithValue("@BDe", BudeDate.Value.Date);
                    cmd.Parameters.AddWithValue("@BDes", BudDescTb.Text);
                    cmd.Parameters.AddWithValue("@BU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Budget Added..!");
                    Con.Close();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
        
        private void label15_Click(object sender, EventArgs e)
        {
            ViewBudget Obj = new ViewBudget();
            Obj.Show();
            this.Hide();
        }

        private void GetTotBud()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(BudAmt) from Budget where BudUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Bud = Convert.ToInt32(dt.Rows[0][0].ToString());
                BudLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception Ex)
            {
                Con.Close();
            }
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            ViewUsers Obj = new ViewUsers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click_1(object sender, EventArgs e)
        {
            if (BudAmtTb.Text == "" || BudDescTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Budget(BudAmt,BudsDate,BudeDate,BudDesc,BudUser)values(@BA,@BDs,@BD,@BDe,@BU)", Con);
                    cmd.Parameters.AddWithValue("@BA", BudAmtTb.Text);
                    cmd.Parameters.AddWithValue("@BDs", BudsDate.Value.Date);
                    cmd.Parameters.AddWithValue("@BD", BudeDate.Value.Date);
                    cmd.Parameters.AddWithValue("@BDe", BudDescTb.Text);
                    cmd.Parameters.AddWithValue("@BU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Budget Added..!");
                    Con.Close();
                    GetTotBud();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        }
        
    }

