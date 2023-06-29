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
    public partial class AddBooks : Form
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-LSQ725T;database=libraryForm;integrated security=True");
        public AddBooks()
        {
            InitializeComponent();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtBookAuthor.Text != "" && txtBookName.Text != "" && txtBookPublication.Text != "" && txtBookPrice.Text != "" && txtBookQuantitz.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into book_info values('" + txtBookName.Text + "','" + txtBookAuthor.Text + "','" + txtBookPublication.Text + "','" + dateTimePicker1.Value.ToString() + "'," + txtBookPrice.Text + "," + txtBookQuantitz.Text + ")";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Date Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Text = "";
                txtBookAuthor.Text = "";
                txtBookPublication.Text = "";
                txtBookPrice.Text = "";
                txtBookQuantitz.Text = "";
            }
            else MessageBox.Show("Please enter all fild","Warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
           
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will DELETE your Unsave DATA", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Hide();
            }
          
        }
    }
}
