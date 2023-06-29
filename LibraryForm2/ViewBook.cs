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
    public partial class ViewBook : Form
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-LSQ725T;database=libraryForm;integrated security=True");
        public ViewBook()
        {
            InitializeComponent();
        }

        void DispBooks()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from book_info";
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            DispBooks();


        }

      
        int i;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            
            i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from book_info where id=" + i + "";
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dt);
            txtBookName.Text = dt.Rows[0][1].ToString();
            txtBookAutor.Text = dt.Rows[0][2].ToString();
            txtBookPublication.Text = dt.Rows[0][3].ToString();
            dateTimePicker1.Text = dt.Rows[0][4].ToString();
            txtBookPrice.Text = dt.Rows[0][5].ToString();
            txtBookQuantity.Text = dt.Rows[0][6].ToString();
            con.Close();
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure for updating?", "Updating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book_info set book_name='" + txtBookName.Text + "',book_author_name='" + txtBookAutor.Text + "',book_publication='" + txtBookPublication.Text + "',book_purchase_date='" + dateTimePicker1.Value.ToString() + "',book_price=" + txtBookPrice.Text + ",bok_quantity=" + txtBookQuantity.Text + " where id=" + i + "";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succ update");
                dataGridView1.Refresh();
                con.Close();
                DispBooks();

            }
         
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where book_name like '"+textBox1.Text+"%'";
                DataTable dt = new DataTable();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info";
                DataTable dt = new DataTable();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            panel2.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to Deleted this Book?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from book_info where id=" + i + "";
                cmd.ExecuteNonQuery();
                con.Close();
                DispBooks();
            }

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
