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
    
    public partial class IssueBook : Form
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-LSQ725T;database=libraryForm;integrated security=True");
        public IssueBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxEnrollmentNo.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where enrollment_no='" + textBoxEnrollmentNo.Text + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                if (dt.Rows.Count != 0)
                {


                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxStudenName.Text = dr["student_name"].ToString();
                        textBoxDepartment.Text = dr["Department"].ToString();
                        textBoxStudentSemester.Text = dr["student_semester"].ToString();
                        textBoxStudentContact.Text = dr["student_contact"].ToString();
                        textBoxStudentemail.Text = dr["student_email"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Enrollment No","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                  
                    textBoxStudenName.Text = "";
                    textBoxDepartment.Text = "";
                    textBoxStudentContact.Text = "";
                    textBoxStudentemail.Text = "";
                    textBoxStudentSemester.Text = "";
                }
               
                con.Close();
            }

            else MessageBox.Show("Please enter Enrollment No");
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select book_name from book_info";
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["book_name".ToString()]);
               
            }
            con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxStudenName.Text != "" && comboBox1.Text!="")
            {



                if (MessageBox.Show("Are you sure to want issue this book?", "ISSUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select issue_books from student_info where enrollment_no='" + textBoxEnrollmentNo.Text + "'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    ada.Fill(dt);

                    int i = int.Parse(dt.Rows[0][0].ToString());
                    if (i < 3)
                    {
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "select bok_quantity from book_info where book_name='" + comboBox1.Text + "'";
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter ada1 = new SqlDataAdapter(cmd1);
                        ada1.Fill(dt1);
                        int j = int.Parse(dt1.Rows[0][0].ToString());
                        if (j > 0)
                        {
                            SqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "insert into issue_book (student_name,Department,student_semester,student_contact,student_email,issue_book_name,issue_date,enrollment_no) values('" + textBoxStudenName.Text + "','" + textBoxDepartment.Text + "'," + textBoxStudentSemester.Text + "," + textBoxStudentContact.Text + ",'" + textBoxStudentemail.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Value.ToString() +"','"+ textBoxEnrollmentNo.Text+"')";
                            cmd2.ExecuteNonQuery();

                            SqlCommand cmd3 = con.CreateCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.CommandText = "update student_info set issue_books=issue_books+1 where enrollment_no='" + textBoxEnrollmentNo.Text + "'";
                            cmd3.ExecuteNonQuery();
                            MessageBox.Show("Issue succ");

                            SqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = CommandType.Text;
                            cmd4.CommandText = "update book_info set bok_quantity=bok_quantity-1 where book_name='" + comboBox1.Text + "'";
                            cmd4.ExecuteNonQuery();
                        }
                        else MessageBox.Show("This book is not on state");

                    }
                    else MessageBox.Show("Max number off issue books are 3 ");
                    con.Close();

                }

            }
            else MessageBox.Show("Cannot issue book because your filds are empty", "EMPTY FILDS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxEnrollmentNo.Text = "";



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBoxStudenName.Text = "";
            textBoxDepartment.Text = "";
            textBoxStudentContact.Text = "";
            textBoxStudentemail.Text = "";
            textBoxStudentSemester.Text = "";
        }
    }
}
