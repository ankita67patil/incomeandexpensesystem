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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetTotInc();
            GetToExp();
            GetTotUsers();
            GetTotBud();
            GetNumExp();
            GetNumInc();
            GetIncLDate();
            GetExpLDate();
            GetMaxInc();
            GetMinInc();
            GetMaxExp();
            GetMinExp();
            GetBalance();
            GetMaxExpCat();
            GetMaxIncCat();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void IncLbl_Click(object sender, EventArgs e)
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
        private void GetTotInc() 
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Inc = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotIncTbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
        }
        int Inc, Exp, Bud, User;
        private void GetToExp()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Exp = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotExpLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
        }

        private void GetTotUsers()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(UName) from UserTbl where User='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                User = Convert.ToInt32(dt.Rows[0][0].ToString());
                Con.Close();
            }
            catch (Exception Ex)
            {
                Con.Close();
            }
        }
        private void GetTotBud()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(BudAmt) from Budget where BudUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Bud = Convert.ToInt32(dt.Rows[0][0].ToString());
                BudLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch(Exception Ex)
            {
                Con.Close();
            }
        }
        
        private void GetBalance()
        {
            double Bal = Inc - Exp;
            BalanceLbl.Text = "Rs "+Bal;
        }
        private void GetMaxExpCat() 
        {
            try 
            {
                Con.Open();
                string InnerQuery = "select Max(ExpAmt) from ExpenseTbl";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
                sda1.Fill(dt1);
                string Query = "select ExpCat from ExpenseTbl where ExpAmt = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BestExpLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
           
        }
        private void GetMaxIncCat()
        {
            Con.Open();
            string InnerQuery = "select Max(IncAmt) from IncomeTbl";
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
            sda1.Fill(dt1);
            string Query = "select IncCat from IncomeTbl where IncAmt = '" + dt1.Rows[0][0].ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BestIncLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetNumExp()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NumExpLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
        }
        private void GetNumInc()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from IncomeTbl where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NumIncLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
            
        }
        private void GetIncLDate()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(IncDate) from IncomeTbl where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DateIncLbl.Text = dt.Rows[0][0].ToString();
                DateIncLbl1.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
        }
        private void GetMaxInc()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxIncLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
        }
        private void GetMinInc()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinIncLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
        }
        private void GetMaxExp()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxExpLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
        }
        private void GetMinExp()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinExpLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
        }
        private void GetExpLDate()
        {
            try 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpDate) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DateExpLbl.Text = dt.Rows[0][0].ToString();
                DateExpLbl1.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception Ex)
            {
                Con.Close();
            }
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BudLbl_Click(object sender, EventArgs e)
        {
            Budget Obj = new Budget();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            ViewBudget Obj = new ViewBudget();
            Obj.Show();
            this.Hide();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            Incomes Obj = new Incomes();
            Obj.Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            ViewIncomes Obj = new ViewIncomes();
            Obj.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Budget Obj = new Budget();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            ViewBudget Obj = new ViewBudget();
            Obj.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewUsers Obj = new ViewUsers();
            Obj.Show();
            this.Hide();
        }
    }
}

    

