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
namespace LibraryForm2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Clear();
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Clear();
                textBox2.PasswordChar = '*';
            }
        }

      

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=wZSkxsIaEJA");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/filip.grastic.9");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/not_rasaa/");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-LSQ725T;database=libraryForm;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from loginTable where username='" + textBox1.Text + "' and pass='" + textBox2.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                
                this.Hide();
                Dashboard das = new Dashboard();
                das.Show();
               
            }
            else MessageBox.Show("Wrong user Username or Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            CreateAcc creat = new CreateAcc();
            creat.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
