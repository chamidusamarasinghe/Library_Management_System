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
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BookDataClasses1DataContext dbcon = new BookDataClasses1DataContext();
            BookTb book = new BookTb();

            book.Book_Id = txtId.Text;
            book.Book_Name = txtName.Text;
            book.Count = Convert.ToInt32(txtCount.Text);
            book.Author = txtAuthor.Text;
            book.Year = Convert.ToInt32(txtYear.Text);

            dbcon.BookTbs.InsertOnSubmit(book);
            dbcon.SubmitChanges();

            MessageBox.Show("Data Saved", "Book", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtId.Clear();
            txtName.Clear();
            txtCount.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            txtId.Focus();

            var st = from s in dbcon.BookTbs select s;
            dbShow.DataSource = st.ToList();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BookDataClasses1DataContext dbcon = new BookDataClasses1DataContext();
            BookTb book = new BookTb();

            string id = txtId.Text;
            var bookUodate = dbcon.BookTbs.SingleOrDefault(stu => stu.Book_Id == id);

            if (bookUodate != null)
            {
                bookUodate.Book_Name = txtName.Text;
                bookUodate.Count = Convert.ToInt32(txtCount.Text);
                bookUodate.Author = txtAuthor.Text;
                bookUodate.Year = Convert.ToInt32(txtYear.Text);

                dbcon.SubmitChanges(); // Submit the changes to the database
                MessageBox.Show("Data Update", "Book", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtId.Clear();
                txtName.Clear();
                txtCount.Clear();
                txtAuthor.Clear();
                txtYear.Clear();

                var st = from s in dbcon.BookTbs select s;
                dbShow.DataSource = st.ToList();
            }
            else
            {
                MessageBox.Show("Book not found", "Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            BookDataClasses1DataContext dbcon = new BookDataClasses1DataContext();
            BookTb book = new BookTb();

            var st = from s in dbcon.BookTbs select s;
            dbShow.DataSource = st.ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            BookDataClasses1DataContext dbcon = new BookDataClasses1DataContext();
            BookTb book = new BookTb();

            string id = txtId.Text;
            var studentToDelete = dbcon.BookTbs.SingleOrDefault(stu => stu.Book_Id == id && stu.Book_Name == txtName.Text);
            if (studentToDelete != null)
            {
                dbcon.BookTbs.DeleteOnSubmit(studentToDelete); // Delete the student record
                dbcon.SubmitChanges(); // Submit the changes to the database
                MessageBox.Show("Data Deleted", "Book", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                txtId.Clear();
                txtName.Clear();

                var st = from s in dbcon.BookTbs select s;
                dbShow.DataSource = st.ToList();
            }
            else
            {
                MessageBox.Show("Student not found", "Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtId_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtName.Focus();
        }

        private void txtName_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCount.Focus();
        }

        private void txtCount_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAuthor.Focus();
        }

        private void txtAuthor_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtYear.Focus();
        }

        private void txtYear_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtId.Focus();
        }

        private void Book_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }
    }
}
