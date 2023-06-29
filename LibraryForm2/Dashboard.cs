using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryForm2
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure You want to Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }

            
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks add = new AddBooks();
            add.Show();                
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook view = new ViewBook();
            view.Show();
                
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addstud = new AddStudent();
            addstud.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudent viewstud = new ViewStudent();
            viewstud.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook issue = new IssueBook();
            issue.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnIssueBook rtrn = new ReturnIssueBook();
            rtrn.Show();
        }

        private void completeBookDetalisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            completeBookDetail comp = new completeBookDetail();
            comp.Show();
        }
    }
}
