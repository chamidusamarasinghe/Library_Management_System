using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Library_Manage_System
{
    public partial class Librarian : Form
    {
        public Librarian()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LibrarianDataClasses1DataContext dbcon = new LibrarianDataClasses1DataContext();
            LibrarianTb libTb = new LibrarianTb();

            libTb.Librarian_Id = txtId.Text;
            libTb.Librarian_Name = txtLiName.Text;
            libTb.Age = Convert.ToInt32(txtAge.Text);
            libTb.Adress = txtAdress.Text;
            libTb.Phone_No = Convert.ToInt32(txtPhone.Text);
            

            dbcon.LibrarianTbs.InsertOnSubmit(libTb); // Insert the new student record
            dbcon.SubmitChanges(); // Submit the changes to the database

            MessageBox.Show("Data Saved", "Librarian", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            txtId.Clear();
            txtLiName.Clear();
            txtAge.Clear();
            txtAdress.Clear();
            txtPhone.Clear();
            txtId.Focus();

            var st = from s in dbcon.LibrarianTbs select s;
            DataShow.DataSource = st.ToList(); // Ensure to list the data to bind it correctly
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LibrarianDataClasses1DataContext dbcon = new LibrarianDataClasses1DataContext();

            String id = txtId.Text;
            var librarianUpdate = dbcon.LibrarianTbs.SingleOrDefault(stu => stu.Librarian_Id == id);

            if (librarianUpdate != null)
            {
                librarianUpdate.Librarian_Name = txtLiName.Text;
                librarianUpdate.Age = Convert.ToInt32(txtAge.Text);
                librarianUpdate.Adress = txtAdress.Text;
                librarianUpdate.Phone_No = Convert.ToInt32(txtPhone.Text);

                dbcon.SubmitChanges(); // Submit the changes to the database
                MessageBox.Show("Data Update", "Librarian", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                txtId.Clear();
                txtLiName.Clear();
                txtAge.Clear();
                txtAdress.Clear();
                txtPhone.Clear();

                var st = from s in dbcon.LibrarianTbs select s;
                DataShow.DataSource = st.ToList();
            }
            else
            {
                MessageBox.Show("Librarian not found", "Librarian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LibrarianDataClasses1DataContext dbcon = new LibrarianDataClasses1DataContext();
            String id = txtId.Text;
            var LibrarianDelete = dbcon.LibrarianTbs.SingleOrDefault(stu => stu.Librarian_Id == id && stu.Librarian_Name == txtLiName.Text);

            if (LibrarianDelete != null)
            {
                dbcon.LibrarianTbs.DeleteOnSubmit(LibrarianDelete); // Delete the student record
                dbcon.SubmitChanges(); // Submit the changes to the database
                MessageBox.Show("Data Delete", "Librarian", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                txtId.Clear();
                txtLiName.Clear();
                
                var st = from s in dbcon.LibrarianTbs select s;
                DataShow.DataSource = st.ToList();
            }
            else
            {
                MessageBox.Show("Librarian not found", "Librarian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LibrarianDataClasses1DataContext dbcon = new LibrarianDataClasses1DataContext();
            LibrarianTb libTb = new LibrarianTb();

            var st = from s in dbcon.LibrarianTbs select s;
            DataShow.DataSource = st.ToList();
        }

        private void txtId_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLiName.Focus();
        }

        private void txtName_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAge.Focus();
        }

        private void txtAge_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAdress.Focus();
        }

        private void txtAddress_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPhone.Focus();
        }

        private void txtPhone_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtId.Focus();
        }

        private void Librarian_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }
    }
}
