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
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
            GetToExp();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Incomes Obj = new Incomes();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HPW\Documents\IemDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        private void Clear()
        {
            ExpAmtTb.Text = "";
            ExpNameTb.Text = "";
            ExpDescTb.Text = "";
            CatCb.SelectedIndex = 0;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ExpNameTb.Text == "" || ExpAmtTb.Text == "" || ExpDescTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ExpenseTbl(ExpName,ExpAmt,ExpCat,ExpDate,ExpDesc,ExpUser)values(@EN,@EA,@EC,@ED,@EDe,@EU)", Con);
                    cmd.Parameters.AddWithValue("@EN", ExpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", ExpAmtTb.Text);
                    cmd.Parameters.AddWithValue("@EC", CatCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", ExpDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EDe", ExpDescTb.Text);
                    cmd.Parameters.AddWithValue("@EU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expense Added..!");
                    Con.Close();
                    GetToExp();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewIncomes Obj = new ViewIncomes();
            Obj.Show();
            this.Hide();
        }
        private void GetToExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Exp = Convert.ToInt32(dt.Rows[0][0].ToString());
                ExpLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception Ex)
            {
                Con.Close();
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Budget Obj = new Budget();
            Obj.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            ViewBudget Obj = new ViewBudget();
            Obj.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            ViewUsers Obj = new ViewUsers();
            Obj.Show();
            this.Hide();
        }
    }
}
