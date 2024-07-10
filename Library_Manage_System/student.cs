
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
    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StudentDataClasses1DataContext dbcon = new StudentDataClasses1DataContext();
            StudentTb stuTb = new StudentTb();

            stuTb.Student_Id = txtId.Text;
            stuTb.Student_Name = txtName.Text;
            stuTb.Age = Convert.ToInt32(txtAge.Text);
            stuTb.Faculty = txtFaculty.Text;
            stuTb.Phone_no = txtPhone.Text;
            stuTb.Email = txtEmail.Text;

            dbcon.StudentTbs.InsertOnSubmit(stuTb); // Insert the new student record
            dbcon.SubmitChanges(); // Submit the changes to the database

            MessageBox.Show("Data Saved", "Student", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtFaculty.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtId.Focus();

            var st = from s in dbcon.StudentTbs select s;
            DataShow.DataSource = st.ToList(); // Ensure to list the data to bind it correctly
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            StudentDataClasses1DataContext dbcon = new StudentDataClasses1DataContext();
            StudentTb stuTb = new StudentTb();

            var st = from s in dbcon.StudentTbs select s;
            DataShow.DataSource = st.ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentDataClasses1DataContext dbcon = new StudentDataClasses1DataContext();
            String id = txtId.Text;
            var studentToUpdate = dbcon.StudentTbs.SingleOrDefault(stu => stu.Student_Id == id);

            if (studentToUpdate != null)
            {
                studentToUpdate.Student_Name = txtName.Text;
                studentToUpdate.Age = Convert.ToInt32(txtAge.Text);
                studentToUpdate.Faculty = txtFaculty.Text;
                studentToUpdate.Phone_no = txtPhone.Text;
                studentToUpdate.Email = txtEmail.Text;

                dbcon.SubmitChanges(); // Submit the changes to the database
                MessageBox.Show("Data Update", "Student", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                txtId.Clear();
                txtName.Clear();
                txtAge.Clear();
                txtFaculty.Clear();
                txtPhone.Clear();
                txtEmail.Clear();

                var st = from s in dbcon.StudentTbs select s;
                DataShow.DataSource = st.ToList();
            }
            else
            {
                MessageBox.Show("Student not found", "Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            StudentDataClasses1DataContext dbcon = new StudentDataClasses1DataContext();
            String id = txtId.Text;
            var studentToDelete = dbcon.StudentTbs.SingleOrDefault(stu => stu.Student_Id == id && stu.Student_Name == txtName.Text);

            if (studentToDelete != null)
            {
                dbcon.StudentTbs.DeleteOnSubmit(studentToDelete); // Delete the student record
                dbcon.SubmitChanges(); // Submit the changes to the database
                MessageBox.Show("Data Deleted", "Student", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtId.Clear();
                txtName.Clear();

                var st = from s in dbcon.StudentTbs select s;
                DataShow.DataSource = st.ToList();
            }
            else
            {
                MessageBox.Show("Student not found", "Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtAge.Focus();
            }
        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtFaculty.Focus();
            
        }

        private void txtFaculty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPhone.Focus();
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEmail.Focus();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtId.Focus();
        }

        private void btnAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void student_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }
    }
}

