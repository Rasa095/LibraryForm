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
    public partial class completeBookDetail : Form
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-LSQ725T;database=libraryForm;integrated security=True");
        public completeBookDetail()
        {
            InitializeComponent();
        }

       

        private void completeBookDetail_Load(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_book where return_issue_date is null";
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from issue_book";
            DataTable dt1 = new DataTable();
            SqlDataAdapter ada1 = new SqlDataAdapter(cmd1);
            ada1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            
            con.Close();
        }
    }
}
