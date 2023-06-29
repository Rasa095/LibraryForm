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

    public partial class ViewStudent : Form
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-LSQ725T;database=libraryForm;integrated security=True");
        public ViewStudent()
        {
            InitializeComponent();
        }

        void loadDataGrid()
        {

            con.Open();
            SqlCommand com = con.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from student_info";
            com.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(com);
            ada.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void ViewStudent_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }
        int i;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i =Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            panel2.Visible = true;

            con.Open();
            SqlCommand com = con.CreateCommand();
            com.CommandType = CommandType.Text;           
            com.CommandText = "select * from student_info where id="+i+"";
            DataTable dt = new DataTable();           
            SqlDataAdapter ada = new SqlDataAdapter(com);
            ada.Fill(dt);

            txtBoxName.Text = dt.Rows[0][1].ToString();
            txtEnrollme.Text = dt.Rows[0][2].ToString();
            txtDepartment.Text = dt.Rows[0][3].ToString();
            txtStudentSem.Text = dt.Rows[0][4].ToString();
            txtStudentCont.Text = dt.Rows[0][5].ToString();
            txtStudentEmail.Text = dt.Rows[0][6].ToString();

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtBoxName.Text = "";
            txtDepartment.Text = "";
            txtEnrollme.Text = "";
            txtStudentCont.Text = "";
            txtStudentEmail.Text = "";
            txtStudentSem.Text = "";
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure for update?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand com = con.CreateCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = "update student_info set student_name='" + txtBoxName.Text + "',enrollment_no='" + txtEnrollme.Text + "',Department='" + txtDepartment.Text + "',student_semester='" + txtStudentSem.Text + "',student_contact=" + txtStudentCont.Text + ",student_email='" + txtStudentEmail.Text + "' where id=" + i + "";
                com.ExecuteNonQuery();
                MessageBox.Show("Update Succ");
                con.Close();
                loadDataGrid();
            }
          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete?", "DELETED", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand com = con.CreateCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = "delete from student_info where id=" + i + "";
                com.ExecuteNonQuery();
                MessageBox.Show("Delete Succ");
                con.Close();
                loadDataGrid();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = con.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from student_info where student_name like'"+textBox1.Text+"%'";
            com.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(com);
            ada.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
