using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manage_System
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        void loadform()
        {
            InfoDataClasses1DataContext dbcon = new InfoDataClasses1DataContext();
            InfoTable obj = new InfoTable();


        }

        private Form activeform = null; //check anothe form open or not
        private void open_SubForm(Form subForm)
        {
            if (activeform != null)//check avalable open form have or not
            {
                activeform.Close(); //close active form
            }

            activeform = subForm;
            subForm.TopLevel = false;//CLOSE HEADER BAR,BUTTON
            subForm.FormBorderStyle = FormBorderStyle.None;//
            subForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(subForm);//WHERE OPEN NEW FORM
            panel2.Tag = subForm;
            subForm.BringToFront();
            subForm.Show();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //student info = new student();
            //info.Show();
            open_SubForm(new student());

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            //Book info = new Book();
            //info.Show();
            open_SubForm(new Book());
        }

        private void btnBoorow_Click(object sender, EventArgs e)
        {
            //Borrowing info = new Borrowing();
            //info.Show();
            open_SubForm(new Borrowing());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            open_SubForm(new Librarian());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open_SubForm(new aBOUT());
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
