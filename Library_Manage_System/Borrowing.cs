
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
    public partial class Borrowing : Form
    {
        public Borrowing()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (BorrowDataClasses1DataContext dbcon = new BorrowDataClasses1DataContext())
            {
                using (BookDataClasses1DataContext bookDbcon = new BookDataClasses1DataContext())
                {
                    string bookName = txtBName.Text;

                    // Check if the book is available
                    var bookToBorrow = bookDbcon.BookTbs.SingleOrDefault(b => b.Book_Name == bookName && b.Count > 0);

                    if (bookToBorrow != null)
                    {
                        // Book is available, proceed with adding the borrow record
                        BorroeTb borrow = new BorroeTb
                        {
                            Student_Id = txtId.Text,
                            Student_Name = txtStName.Text,
                            Book_Name = txtBName.Text,
                            Gat_Date = txtGetD.Text,
                            Return_Date = txtReturnD.Text
                        };

                        dbcon.BorroeTbs.InsertOnSubmit(borrow);
                        dbcon.SubmitChanges();

                        // Decrease the book count
                        bookToBorrow.Count -= 1;
                        bookDbcon.SubmitChanges();

                        MessageBox.Show("Data Saved", "Borrow", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtId.Clear();
                        txtStName.Clear();
                        txtBName.Clear();
                        txtGetD.Clear();
                        txtReturnD.Clear();
                        txtId.Focus();

                        var st = from s in dbcon.BorroeTbs select s;
                        dbShow.DataSource = st.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Book not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtId.Clear();
                        txtStName.Clear();
                        txtBName.Clear();
                        txtGetD.Clear();
                        txtReturnD.Clear();
                        txtId.Focus();
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (BorrowDataClasses1DataContext dbcon = new BorrowDataClasses1DataContext())
            {
                string id = txtId.Text;
                var borrowUpdate = dbcon.BorroeTbs.SingleOrDefault(stu => stu.Student_Id == id);

                if (borrowUpdate != null)
                {
                    borrowUpdate.Student_Name = txtStName.Text;
                    borrowUpdate.Book_Name = txtBName.Text;
                    borrowUpdate.Gat_Date = txtGetD.Text;
                    borrowUpdate.Return_Date = txtReturnD.Text;

                    dbcon.SubmitChanges(); // Submit the changes to the database
                    MessageBox.Show("Data Saved", "Borrow", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtId.Clear();
                    txtStName.Clear();
                    txtBName.Clear();
                    txtGetD.Clear();
                    txtReturnD.Clear();

                    var st = from s in dbcon.BorroeTbs select s;
                    dbShow.DataSource = st.ToList();
                }
                else
                {
                    MessageBox.Show("Borrow record not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (BorrowDataClasses1DataContext dbcon = new BorrowDataClasses1DataContext())
            {
                string id = txtId.Text;
                string bookName = txtBName.Text;
                var studentToDelete = dbcon.BorroeTbs.SingleOrDefault(stu => stu.Student_Id == id && stu.Book_Name == bookName);
                if (studentToDelete != null)
                {
                    dbcon.BorroeTbs.DeleteOnSubmit(studentToDelete); // Delete the student record
                    dbcon.SubmitChanges(); // Submit the changes to the database

                    // Increase the book count
                    using (BookDataClasses1DataContext bookDbcon = new BookDataClasses1DataContext())
                    {
                        var bookToReturn = bookDbcon.BookTbs.SingleOrDefault(b => b.Book_Name == bookName);
                        if (bookToReturn != null)
                        {
                            bookToReturn.Count += 1;
                            bookDbcon.SubmitChanges();
                        }
                    }

                    MessageBox.Show("Data deleted", "Borrow", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtId.Clear();
                    txtStName.Clear();
                   
                    var st = from s in dbcon.BorroeTbs select s;
                    dbShow.DataSource = st.ToList();
                }
                else
                {
                    MessageBox.Show("Borrow record not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            using (BorrowDataClasses1DataContext dbcon = new BorrowDataClasses1DataContext())
            {
                var st = from s in dbcon.BorroeTbs select s;
                dbShow.DataSource = st.ToList();
            }
        }

        private void txtId_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtStName.Focus();
        }

        private void txtName_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBName.Focus();
        }

        private void txtBook_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGetD.Focus();
        }

        private void txtGet_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtReturnD.Focus();
        }

        private void txtReturn_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtId.Focus();
        }

        private void Borrowing_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }
    }
}

