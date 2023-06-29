using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryForm2
{
    public partial class ReturnIssueBook : Form
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-LSQ725T;database=libraryForm;integrated security=True");
        public ReturnIssueBook()
        {
            InitializeComponent();
        }

        void dataShow()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_book where enrollment_no='" + textBoxEnrollmentNo.Text + "'and return_issue_date is null ";
            cmd.ExecuteNonQuery();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataShow();
        }


        int i;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Show();
            con.Open();
             i =Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
           
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select issue_book_name,issue_date from issue_book where id=" +i +"";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dt);
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Are you sure to return book?", "RETURNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
           {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update issue_book set return_issue_date='" + dateTimePicker1.Value.ToString() + "'where id=" + i +"";
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update book_info set bok_quantity=bok_quantity+1 where book_name='" + textBox1.Text + "'";
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update student_info set issue_books=issue_books-1 where enrollment_no='" + textBoxEnrollmentNo.Text + "'";
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Succ return book");
                con.Close();
                dataShow();

            }
            
        }
    }
}
