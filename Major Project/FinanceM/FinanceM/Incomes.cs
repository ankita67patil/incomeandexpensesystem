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
    public partial class Incomes : Form
    {
        public Incomes()
        {
            InitializeComponent();
            GetTotInc();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HPW\Documents\IemDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        private void Clear()
        {
            IncNameTb.Text = "";
            IncAmtTb.Text = "";
            IncDesc.Text = "";
            CatTb.Text="";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (IncNameTb.Text == "" || IncAmtTb.Text == "" || IncDesc.Text == "" || CatTb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into IncomeTbl(IncName,IncAmt,IncCat,IncDate,IncDesc,IncUser)values(@IN,@IA,@IC,@ID,@IDe,@IU)", Con);
                    cmd.Parameters.AddWithValue("@IN", IncNameTb.Text);
                    cmd.Parameters.AddWithValue("@IA", IncAmtTb.Text);
                    cmd.Parameters.AddWithValue("@IC", CatTb.Text);
                    cmd.Parameters.AddWithValue("@ID", IncDate.Value.Date);
                    cmd.Parameters.AddWithValue("@IDe", IncDesc.Text);
                    cmd.Parameters.AddWithValue("@IU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Added..!");
                    Con.Close();
                    GetTotInc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewIncomes Obj = new ViewIncomes();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
            this.Hide();
        }
        private void GetTotInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Inc = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotIncLbl.Text = "Rs " + dt.Rows[0][0].ToString();
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
            Budget Obj = new Budget();
            Obj.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            ViewBudget Obj = new ViewBudget();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {
            ViewUsers Obj = new ViewUsers();
            Obj.Show();
            this.Hide();
        }
    }
}
