using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechLibrary.Business;
using HiTechLibrary.Validation;

namespace Hi_Tech_Order_Management_System.GUI
{
    public partial class FormBook : Form
    {
        public FormBook()
        {
            InitializeComponent();
        }
        // Exit button
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                Application.Exit();
            }
        }
        // Log out button   
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Hide();
                FormLogin login = new FormLogin();
                login.ShowDialog();
            }
        }
        // Save button
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string iSBN = textBoxISBN.Text.Trim();
            string title = textBoxBookTitle.Text.Trim();
            string price = textBoxUnitPrice.Text.Trim();
            decimal uPrice = 0;
            string qoh = textBoxQOH.Text.Trim();
            string authorId = textBoxAuthorID.Text.Trim();
            string fname = textBoxFirstName.Text.Trim();
            string lname = textBoxLastName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string edition = textBoxEdition.Text.Trim();
            string yearPub = textBoxYearPublished.Text.Trim();
            // Validate empty field
            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("ISBN is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(title))
            {
                MessageBox.Show("Book Title is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxBookTitle.Focus();
                return;
            }

            if (Validator.IsEmpty(price))
            {
                MessageBox.Show("Unit Price is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUnitPrice.Focus();
                return;
            }

            if (Validator.IsEmpty(qoh))
            {
                MessageBox.Show("Quantity On Hand is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Focus();
                return;
            }

            if (Validator.IsEmpty(yearPub))
            {
                MessageBox.Show("Year Published is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxYearPublished.Focus();
                return;
            }

            if (Validator.IsEmpty(edition))
            {
                MessageBox.Show("Edition is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEdition.Focus();
                return;
            }

            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a Category ID", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxCategory.Focus();
                return;
            }

            if (comboBoxPublisher.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a Publisher ID", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxPublisher.Focus();
                return;
            }

            if (comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Status is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxStatus.Focus();
                return;
            }

            if (Validator.IsEmpty(authorId))
            {
                MessageBox.Show("Author ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Focus();
                return;
            }

            if (Validator.IsEmpty(fname))
            {
                MessageBox.Show("Author's First Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Focus();
                return;
            }

            if (Validator.IsEmpty(lname))
            {
                MessageBox.Show("Author's Last Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Author's Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            // Validate Invalid ID
            if (!Validator.IsValidId(iSBN, 13))
            {
                MessageBox.Show("Please enter a 13-digit ISBN.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            // Validate duplicate ISBN
            Book book = new Book();
            book = book.SearchBook(iSBN);
            if (book != null)
            {
                MessageBox.Show("This ISBN already exist. You may want to add another Author to this Book.", "Duplicate ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonAddAuthorToBook.Focus();
                return;
            }

            try
            {
                uPrice = Convert.ToDecimal(price);
            }
            catch (Exception )
            {
                MessageBox.Show("Please enter a valid Unit Price.","Invalid Unit Price",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBoxUnitPrice.Clear();
                textBoxUnitPrice.Focus();
                return;
            }

            int quantity;
            try
            {
                quantity = Convert.ToInt32(qoh);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid Quantity On Hand.", "Invalid Quantity On Hand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Clear();
                textBoxQOH.Focus();
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity On Hand must be greater than 0.", "Invalid Quantity On Hand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Clear();
                textBoxQOH.Focus();
                return;
            }

            if (!Validator.IsValidYear(yearPub))
            {
                MessageBox.Show("Please input a valid Year Published.", "Invalid Year Published", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxYearPublished.Clear();
                textBoxYearPublished.Focus();
                return;
            }

            if (Convert.ToInt32(yearPub) > Convert.ToInt32(DateTime.Now.Year))
            {
                MessageBox.Show("Year Published must be in the past.", "Invalid Year Published", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxYearPublished.Clear();
                textBoxYearPublished.Focus();
                return;
            }

            if (!Validator.IsValidId(authorId, 3))
            {
                MessageBox.Show("Author ID is a 3-digit number.", "Invalid Author ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Clear();
                textBoxAuthorID.Focus();
                return;
            }

            if (!Validator.IsValidString(fname))
            {
                MessageBox.Show("First Name can only contain characters and white space.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            if (!Validator.IsValidString(lname))
            {
                MessageBox.Show("Last Name can only contain characters and white space.", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }


            if (MessageBox.Show("Do you want to save this Book? ", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                Author au = new Author();
                au = au.SearchAuthor(Convert.ToInt32(authorId));
                if (au == null)
                {
                    //Save Author
                    Author auSave = new Author();
                    auSave.AuthorId = Convert.ToInt32(authorId);
                    auSave.FirstName = fname;
                    auSave.LastName = lname;
                    auSave.Email = email;
                    auSave.SaveAuthor(auSave);
                }

                //Save Book
                string stt = comboBoxStatus.Text.Trim();
                string[] sttInfo = stt.Split('.');
                int sttId = Convert.ToInt32(sttInfo[0]);

                string publisher = comboBoxPublisher.Text.Trim();
                string[] publisherInfo = publisher.Split('.');
                int publisherId = Convert.ToInt32(publisherInfo[0]);

                string category = comboBoxCategory.Text.Trim();
                string[] categoryInfo = category.Split('.');
                int categoryId = Convert.ToInt32(categoryInfo[0]);

                Book bookSave = new Book();
                bookSave.ISBN = iSBN;
                bookSave.BookTitle = title;
                bookSave.UnitPrice = uPrice;
                bookSave.QOH = quantity;
                bookSave.PublisherId = Convert.ToInt32(publisherId);
                bookSave.CategoryId = Convert.ToInt32(categoryId);
                bookSave.Status = sttId;
                bookSave.SaveBook(bookSave);

                //Save AuthorBook
                AuthorBook auBo = new AuthorBook();
                auBo.AuthorId = Convert.ToInt32(authorId);
                auBo.ISBN = iSBN;
                auBo.Edition = edition;
                auBo.YearPublished = yearPub;
                auBo.SaveAuthorBook(auBo);
                MessageBox.Show("Book has been saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Book has NOT been saved", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            textBoxEdition.Clear();
            textBoxYearPublished.Clear();
            textBoxAuthorID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            comboBoxPublisher.SelectedIndex = -1;
            comboBoxCategory.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            textBoxISBN.Focus();
        }
        // Update button
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string iSBN = textBoxISBN.Text.Trim();
            string title = textBoxBookTitle.Text.Trim();
            string price = textBoxUnitPrice.Text.Trim();
            decimal uPrice = 0;
            string qoh = textBoxQOH.Text.Trim();
            string authorId = textBoxAuthorID.Text.Trim();
            string fname = textBoxFirstName.Text.Trim();
            string lname = textBoxLastName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string edition = textBoxEdition.Text.Trim();
            string yearPub = textBoxYearPublished.Text.Trim();
            // Validate empty field
            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("ISBN is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(title))
            {
                MessageBox.Show("Book Title is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxBookTitle.Focus();
                return;
            }

            if (Validator.IsEmpty(price))
            {
                MessageBox.Show("Unit Price is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUnitPrice.Focus();
                return;
            }

            if (Validator.IsEmpty(qoh))
            {
                MessageBox.Show("Quantity On Hand is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Focus();
                return;
            }

            if (Validator.IsEmpty(yearPub))
            {
                MessageBox.Show("Year Published is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxYearPublished.Focus();
                return;
            }

            if (Validator.IsEmpty(edition))
            {
                MessageBox.Show("Edition is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEdition.Focus();
                return;
            }

            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a Category ID", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxCategory.Focus();
                return;
            }

            if (comboBoxPublisher.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a Publisher ID", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxPublisher.Focus();
                return;
            }

            if (comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Status is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxStatus.Focus();
                return;
            }

            if (Validator.IsEmpty(authorId))
            {
                MessageBox.Show("Author ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Focus();
                return;
            }

            if (Validator.IsEmpty(fname))
            {
                MessageBox.Show("Author's First Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Focus();
                return;
            }

            if (Validator.IsEmpty(lname))
            {
                MessageBox.Show("Author's Last Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Author's Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            // Validate Invalid ID
            if (!Validator.IsValidId(iSBN, 13))
            {
                MessageBox.Show("Please enter a 13-digit ISBN.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            // Validate duplicate ISBN
            Book book = new Book();
            book = book.SearchBook(iSBN);
            if (book == null)
            {
                MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            try
            {
                uPrice = Convert.ToDecimal(price);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid Unit Price.", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUnitPrice.Clear();
                textBoxUnitPrice.Focus();
                return;
            }

            int quantity;
            try
            {
                quantity = Convert.ToInt32(qoh);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid Quantity On Hand.", "Invalid Quantity On Hand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Clear();
                textBoxQOH.Focus();
                return;
            }

            if (quantity < 0)
            {
                MessageBox.Show("Quantity On Hand must be greater than or equal 0.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Clear();
                textBoxQOH.Focus();
                return;
            }

            if (quantity == 0)
            {
                book.Status = 9;
                if (comboBoxStatus.Items.Count <=3)
                {
                    comboBoxStatus.Items.Add("9. Out of Stock");
                }
                comboBoxStatus.SelectedItem = "9. Out of Stock";
            }

            if (!Validator.IsValidYear(yearPub))
            {
                MessageBox.Show("Please input a valid Year Published.", "Invalid Year Published", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxYearPublished.Clear();
                textBoxYearPublished.Focus();
                return;
            }

            if (Convert.ToInt32(yearPub) > Convert.ToInt32(DateTime.Now.Year))
            {
                MessageBox.Show("Year Published must be in the past.", "Invalid Year Published", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxYearPublished.Clear();
                textBoxYearPublished.Focus();
                return;
            }

            if (!Validator.IsValidId(authorId, 3))
            {
                MessageBox.Show("Author ID is a 3-digit number.", "Invalid Author ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Clear();
                textBoxAuthorID.Focus();
                return;
            }

            if (!Validator.IsValidString(fname))
            {
                MessageBox.Show("First Name can only contain characters and white space.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            if (!Validator.IsValidString(lname))
            {
                MessageBox.Show("Last Name can only contain characters and white space.", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            Author au = new Author();
            au = au.SearchAuthor(Convert.ToInt32(authorId));
            if (au == null)
            {
                MessageBox.Show("Cannot find this author.\nPlease add the author and update again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonAddAuthorToBook.Focus();
                return;
            }

            AuthorBook auBo = new AuthorBook();
            auBo = auBo.SearchAuthorBook(Convert.ToInt32(authorId), iSBN);
            if (auBo == null)
            {
                MessageBox.Show("This author does not write this Book according to the database.\nPlease add the author to the Book and update again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonAddAuthorToBook.Focus();
                return;
            }

            if (MessageBox.Show("Do you want to update this Book? ", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {

                //Update Author
                Author auUpdate = new Author();
                auUpdate.AuthorId = Convert.ToInt32(authorId);
                auUpdate.FirstName = fname;
                auUpdate.LastName = lname;
                auUpdate.Email = email;
                auUpdate.UpdateAuthor(auUpdate);

                //Update Book
                string stt = comboBoxStatus.Text.Trim();
                string[] sttInfo = stt.Split('.');
                int sttId = Convert.ToInt32(sttInfo[0]);

                string publisher = comboBoxPublisher.Text.Trim();
                string[] publisherInfo = publisher.Split('.');
                int publisherId = Convert.ToInt32(publisherInfo[0]);

                string category = comboBoxCategory.Text.Trim();
                string[] categoryInfo = category.Split('.');
                int categoryId = Convert.ToInt32(categoryInfo[0]);

                Book bookUpdate = new Book();
                bookUpdate.ISBN = iSBN;
                bookUpdate.BookTitle = title;
                bookUpdate.UnitPrice = uPrice;
                bookUpdate.QOH = quantity;
                bookUpdate.PublisherId = Convert.ToInt32(publisherId);
                bookUpdate.CategoryId = Convert.ToInt32(categoryId);
                bookUpdate.Status = sttId;
                bookUpdate.UpdateBook(bookUpdate);

                //Update AuthorBook
                AuthorBook auBoUpdate = new AuthorBook();
                auBoUpdate.AuthorId = Convert.ToInt32(authorId);
                auBoUpdate.ISBN = iSBN;
                auBoUpdate.Edition = edition;
                auBoUpdate.YearPublished = yearPub;
                auBoUpdate.UpdateAuthorBook(auBoUpdate);
                MessageBox.Show("Book has been updated successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Book has NOT been updated", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            textBoxEdition.Clear();
            textBoxYearPublished.Clear();
            textBoxAuthorID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            comboBoxPublisher.SelectedIndex = -1;
            comboBoxCategory.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            textBoxISBN.Focus();
        }
        //Delete button
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string iSBN = textBoxISBN.Text.Trim();
            string title = textBoxBookTitle.Text.Trim();
            string price = textBoxUnitPrice.Text.Trim();
            decimal uPrice = 0;
            string qoh = textBoxQOH.Text.Trim();
            string authorId = textBoxAuthorID.Text.Trim();
            string fname = textBoxFirstName.Text.Trim();
            string lname = textBoxLastName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string edition = textBoxEdition.Text.Trim();
            string yearPub = textBoxYearPublished.Text.Trim();
            // Validate empty field
            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("ISBN is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(title))
            {
                MessageBox.Show("Book Title is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxBookTitle.Focus();
                return;
            }

            if (Validator.IsEmpty(price))
            {
                MessageBox.Show("Unit Price is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUnitPrice.Focus();
                return;
            }

            if (Validator.IsEmpty(qoh))
            {
                MessageBox.Show("Quantity On Hand is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Focus();
                return;
            }

            if (Validator.IsEmpty(yearPub))
            {
                MessageBox.Show("Year Published is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxYearPublished.Focus();
                return;
            }

            if (Validator.IsEmpty(edition))
            {
                MessageBox.Show("Edition is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEdition.Focus();
                return;
            }

            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a Category ID", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxCategory.Focus();
                return;
            }

            if (comboBoxPublisher.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a Publisher ID", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxPublisher.Focus();
                return;
            }

            if (comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Status is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxStatus.Focus();
                return;
            }

            if (Validator.IsEmpty(authorId))
            {
                MessageBox.Show("Author ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Focus();
                return;
            }

            if (Validator.IsEmpty(fname))
            {
                MessageBox.Show("Author's First Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Focus();
                return;
            }

            if (Validator.IsEmpty(lname))
            {
                MessageBox.Show("Author's Last Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Author's Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            // Validate Invalid ID
            if (!Validator.IsValidId(iSBN, 13))
            {
                MessageBox.Show("Please enter a 13-digit ISBN.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            // Validate duplicate ISBN
            Book book = new Book();
            book = book.SearchBook(iSBN);
            if (book == null)
            {
                MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            try
            {
                uPrice = Convert.ToDecimal(price);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid Unit Price.", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUnitPrice.Clear();
                textBoxUnitPrice.Focus();
                return;
            }

            int quantity;
            try
            {
                quantity = Convert.ToInt32(qoh);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid Quantity On Hand.", "Invalid Quantity On Hand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Clear();
                textBoxQOH.Focus();
                return;
            }

            if (quantity > 0)
            {
                MessageBox.Show("Cannot delete Book with Quantity On Hand greater than 0.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Clear();
                textBoxQOH.Focus();
                return;
            }

            if (!Validator.IsValidYear(yearPub))
            {
                MessageBox.Show("Please input a valid Year Published.", "Invalid Year Published", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxYearPublished.Clear();
                textBoxYearPublished.Focus();
                return;
            }

            if (Convert.ToInt32(yearPub) > Convert.ToInt32(DateTime.Now.Year))
            {
                MessageBox.Show("Year Published must be in the past.", "Invalid Year Published", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxYearPublished.Clear();
                textBoxYearPublished.Focus();
                return;
            }

            if (!Validator.IsValidId(authorId, 3))
            {
                MessageBox.Show("Author ID is a 3-digit number.", "Invalid Author ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Clear();
                textBoxAuthorID.Focus();
                return;
            }

            if (!Validator.IsValidString(fname))
            {
                MessageBox.Show("First Name can only contain characters and white space.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            if (!Validator.IsValidString(lname))
            {
                MessageBox.Show("Last Name can only contain characters and white space.", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            Author au = new Author();
            au = au.SearchAuthor(Convert.ToInt32(authorId));
            if (au == null)
            {
                MessageBox.Show("Cannot find this author.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonAddAuthorToBook.Focus();
                return;
            }

            AuthorBook auBo;
            auBo = new AuthorBook();
            auBo = auBo.SearchAuthorBook(Convert.ToInt32(authorId), iSBN);
            if (auBo == null)
            {
                MessageBox.Show("This author does not write this Book according to the database.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonAddAuthorToBook.Focus();
                return;
            }

            OrderLine ordLine = new OrderLine();
            List<OrderLine> listOL = new List<OrderLine>();
            listOL = ordLine.SearchListOrderLine(iSBN);
            if(listOL != null)
            {
                MessageBox.Show("This Book was ordered and cannot be deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxBookTitle.Clear();
                textBoxUnitPrice.Clear();
                textBoxQOH.Clear();
                textBoxEdition.Clear();
                textBoxYearPublished.Clear();
                textBoxAuthorID.Clear();
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxEmail.Clear();
                comboBoxPublisher.SelectedIndex = -1;
                comboBoxCategory.SelectedIndex = -1;
                comboBoxStatus.SelectedIndex = -1;
                textBoxISBN.Focus();
                return;
            }

            if (MessageBox.Show("Do you want to delete this Book? ", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                List<AuthorBook> listAB;
                List<AuthorBook> listAB1;
                listAB = new List<AuthorBook>();
                listAB = auBo.SearchListAuthorBook(iSBN);
                foreach (var aB in listAB)
                {
                    listAB1 = new List<AuthorBook>();
                    listAB1 = auBo.SearchListAuthorBook(aB.AuthorId);
                    auBo.DeleteAuthorBook(aB.AuthorId, iSBN);
                    if (listAB1.Count == 1)
                    {
                        au.DeleteAuthor(aB.AuthorId);
                    }
                }
                book.DeleteBook(iSBN);
                MessageBox.Show("Book has been deleted successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Book has NOT been deleted", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            textBoxEdition.Clear();
            textBoxYearPublished.Clear();
            textBoxAuthorID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            comboBoxPublisher.SelectedIndex = -1;
            comboBoxCategory.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            textBoxISBN.Focus();
        }
        // Clear all button
        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            listViewBook.Items.Clear();
            textBoxInputBook.Clear();
            textBoxYearPublished.Clear();
            textBoxEdition.Clear();
            textBoxAuthorID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            comboBoxPublisher.SelectedIndex = -1;
            comboBoxCategory.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            comboBoxBook.SelectedIndex = -1;
            textBoxISBN.Focus();
        }
        // Search book button
        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            listViewBook.Items.Clear();
            string input = textBoxInputBook.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Input is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxInputBook.Focus();
                return;
            }

            //When data is valid
            int select = comboBoxBook.SelectedIndex;
            switch (select)
            {
                case -1:
                    MessageBox.Show("Please choose an option.", "Empty Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxBook.Focus();
                    break;
                case 0:
                    if (!Validator.IsValidId(input, 13))
                    {
                        MessageBox.Show("Please input a 13-digit ISBN.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputBook.Clear();
                        textBoxInputBook.Focus();
                        return;
                    }
                    Book book = new Book();
                    book = book.SearchBook(input);
                    if (book == null)
                    {
                        MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputBook.Clear();
                        textBoxInputBook.Focus();
                        return;
                    }
                    else
                    {
                        AuthorBook auBo = new AuthorBook();
                        List<AuthorBook> authorBooks = new List<AuthorBook>();
                        authorBooks = auBo.SearchListAuthorBook(input);
                        if (authorBooks == null)
                        {
                            MessageBox.Show("Please update this Book information", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxInputBook.Clear();
                            labelInfo.Text = "";
                            comboBoxBook.SelectedIndex = -1;
                            return;
                        }
                        else
                        {
                            
                            foreach (var b in authorBooks)
                            {
                                ListViewItem item = new ListViewItem(book.ISBN.ToString());
                                item.SubItems.Add(book.BookTitle.ToString());
                                item.SubItems.Add(book.UnitPrice.ToString());
                                item.SubItems.Add(book.QOH.ToString());
                                item.SubItems.Add(book.PublisherId.ToString());
                                item.SubItems.Add(book.CategoryId.ToString());
                                item.SubItems.Add(book.Status.ToString());
                                item.SubItems.Add(b.AuthorId.ToString());
                                item.SubItems.Add(b.Edition.ToString());
                                item.SubItems.Add(b.YearPublished.ToString());
                                listViewBook.Items.Add(item);
                            }
                        }
                    }
                    textBoxInputBook.Clear();
                    labelInfo.Text = "";
                    comboBoxBook.SelectedIndex = -1;
                    break;
                case 1:
                    Book book1 = new Book();
                    List<Book> listBookTitle = new List<Book>();
                    listBookTitle = book1.SearchBookByTitle(input);
                    if (listBookTitle != null)
                    {
                        foreach (var b in listBookTitle)
                        {
                            AuthorBook auBo = new AuthorBook();
                            List<AuthorBook> authorBooks = new List<AuthorBook>();
                            authorBooks = auBo.SearchListAuthorBook(b.ISBN);
                            if (authorBooks == null)
                            {
                                MessageBox.Show("Please update this Book information", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxInputBook.Clear();
                                labelInfo.Text = "";
                                comboBoxBook.SelectedIndex = -1;
                                return;
                            }
                            else
                            {
                                foreach (var aB in authorBooks)
                                {
                                    ListViewItem item = new ListViewItem(b.ISBN.ToString());
                                    item.SubItems.Add(b.BookTitle.ToString());
                                    item.SubItems.Add(b.UnitPrice.ToString());
                                    item.SubItems.Add(b.QOH.ToString());
                                    item.SubItems.Add(b.PublisherId.ToString());
                                    item.SubItems.Add(b.CategoryId.ToString());
                                    item.SubItems.Add(b.Status.ToString());
                                    item.SubItems.Add(aB.AuthorId.ToString());
                                    item.SubItems.Add(aB.Edition.ToString());
                                    item.SubItems.Add(aB.YearPublished.ToString());
                                    listViewBook.Items.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Book Title does not exist.", "Non-exist Book Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBoxInputBook.Clear();
                    labelInfo.Text = "";
                    comboBoxBook.SelectedIndex = -1;
                    break;
                case 2:
                    if (!Validator.IsValidId(input, 3))
                    {
                        MessageBox.Show("Author ID is a 3-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputBook.Clear();
                        textBoxInputBook.Focus();
                        return;
                    }
                    Author author = new Author();
                    author = author.SearchAuthor(Convert.ToInt32(input));
                    if (author == null)
                    {
                        MessageBox.Show("Cannot find this Author.", "Non-exist Author ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputBook.Clear();
                        textBoxInputBook.Focus();
                        return;
                    }
                    else
                    {
                        AuthorBook auBo = new AuthorBook();
                        List<AuthorBook> authorBooks = new List<AuthorBook>();
                        authorBooks = auBo.SearchListAuthorBook(Convert.ToInt32(input));
                        if (authorBooks == null)
                        {
                            MessageBox.Show("Please update this Book information", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxInputBook.Clear();
                            labelInfo.Text = "";
                            comboBoxBook.SelectedIndex = -1;
                            return;
                        }
                        else
                        {
                            Book book4;
                            foreach (var b in authorBooks)
                            {
                                book4 = new Book();
                                book4 = book4.SearchBook(b.ISBN.ToString());
                                ListViewItem item = new ListViewItem(b.ISBN.ToString());
                                item.SubItems.Add(book4.BookTitle.ToString());
                                item.SubItems.Add(book4.UnitPrice.ToString());
                                item.SubItems.Add(book4.QOH.ToString());
                                item.SubItems.Add(book4.PublisherId.ToString());
                                item.SubItems.Add(book4.CategoryId.ToString());
                                item.SubItems.Add(book4.Status.ToString());
                                item.SubItems.Add(b.AuthorId.ToString());
                                item.SubItems.Add(b.Edition.ToString());
                                item.SubItems.Add(b.YearPublished.ToString());
                                listViewBook.Items.Add(item);
                            }
                        }
                    }
                    textBoxInputBook.Clear();
                    labelInfo.Text = "";
                    comboBoxBook.SelectedIndex = -1;
                    break;
                case 3:
                    if (!Validator.IsValidId(input,1))
                    {
                        MessageBox.Show("Please input a 1-digit Publisher ID.", "Invalid Publisher ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputBook.Clear();
                        textBoxInputBook.Focus();
                        return;
                    }
                    int pId = Convert.ToInt32(input);
                    Book book2 = new Book();
                    List<Book> listBookPub = new List<Book>();
                    listBookPub = book2.SearchBook(pId, "PublisherId");
                    if (listBookPub != null)
                    {
                        foreach (var b in listBookPub)
                        {
                            ListViewItem item = new ListViewItem(b.ISBN.ToString());
                            item.SubItems.Add(b.BookTitle.ToString());
                            item.SubItems.Add(b.UnitPrice.ToString());
                            item.SubItems.Add(b.QOH.ToString());
                            item.SubItems.Add(b.PublisherId.ToString());
                            item.SubItems.Add(b.CategoryId.ToString());
                            item.SubItems.Add(b.Status.ToString());
                            listViewBook.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found.", "Empty Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBoxInputBook.Clear();
                    labelInfo.Text = "";
                    comboBoxBook.SelectedIndex = -1;
                    break;
                case 4:
                    if (!Validator.IsValidId(input, 2))
                    {
                        MessageBox.Show("Please input a 2-digit Category ID.", "Invalid Category ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputBook.Clear();
                        textBoxInputBook.Focus();
                        return;
                    }
                    int cId = Convert.ToInt32(input);
                    Book book3 = new Book();
                    List<Book> listBookCat = new List<Book>();
                    listBookCat = book3.SearchBook(cId, "CategoryId");
                    if (listBookCat != null)
                    {
                        foreach (var b in listBookCat)
                        {
                            ListViewItem item = new ListViewItem(b.ISBN.ToString());
                            item.SubItems.Add(b.BookTitle.ToString());
                            item.SubItems.Add(b.UnitPrice.ToString());
                            item.SubItems.Add(b.QOH.ToString());
                            item.SubItems.Add(b.PublisherId.ToString());
                            item.SubItems.Add(b.CategoryId.ToString());
                            item.SubItems.Add(b.Status.ToString());
                            listViewBook.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found.", "Empty Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBoxInputBook.Clear();
                    labelInfo.Text = "";
                    comboBoxBook.SelectedIndex = -1;
                    break;

            }
        }
        // List all books button
        private void buttonSearchAll_Click(object sender, EventArgs e)
        {
            List<Book> listBook = new List<Book>();
            Book book = new Book();
            listBook = book.SearchAllBook();
            List<AuthorBook> listAuBo = new List<AuthorBook>();
            AuthorBook auBo = new AuthorBook();
            listViewBook.Items.Clear();
            if (listBook != null)
            {
                foreach (var b in listBook)
                {
                    listAuBo = auBo.SearchListAuthorBook(b.ISBN.ToString());
                    AuthorBook aB = new AuthorBook();
                    aB = listAuBo.First();
                    ListViewItem item = new ListViewItem(b.ISBN.ToString());
                    item.SubItems.Add(b.BookTitle.ToString());
                    item.SubItems.Add(b.UnitPrice.ToString());
                    item.SubItems.Add(b.QOH.ToString());
                    item.SubItems.Add(b.PublisherId.ToString());
                    item.SubItems.Add(b.CategoryId.ToString());
                    item.SubItems.Add(b.Status.ToString());
                    
                    Author au;
                    string authorName = "";
                    foreach (var aB1 in listAuBo)
                    {
                        au = new Author();
                        au = au.SearchAuthor(aB1.AuthorId);
                        authorName += au.FirstName +" "+ au.LastName + "\n " ;
                    }
                    item.SubItems.Add(authorName);
                    item.SubItems.Add(aB.Edition.ToString());
                    item.SubItems.Add(aB.YearPublished.ToString());
                    listViewBook.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("There is no book in the database.", "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBoxBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = comboBoxBook.SelectedIndex;
            if (select == 0)
            {
                labelInfo.Text = "Please input ISBN.";
            }
            else if (select == 1)
            {
                labelInfo.Text = "Please input Book Title.";
            }
            else if (select == 2)
            {
                labelInfo.Text = "Please input Publisher ID.";
            }
            else if (select == 3)
            {
                labelInfo.Text = "Please input Category ID.";
            }
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            Status status = new Status();
            List<Status> listStatus = status.SearchStatus("Book");
            foreach (var item in listStatus)
            {
                comboBoxStatus.Items.Add(item.Id + ". " + item.Description);
            }

            Publisher publisher = new Publisher();
            List<Publisher> listPub = publisher.SearchAllPublisher();
            foreach(var item in listPub)
            {
                comboBoxPublisher.Items.Add(item.PublisherId + ". " + item.PublisherName);
            }

            Category category = new Category();
            List<Category> listCat = category.SearchAllCategory();
            foreach (var item in listCat)
            {
                comboBoxCategory.Items.Add(item.CategoryId + ". " + item.CategoryName);
            }
        }
        // Add author to a book
        private void buttonAddAuthorToBook_Click(object sender, EventArgs e)
        {
            // Validate input data
            string iSBN = textBoxISBN.Text.Trim();
            string authorId = textBoxAuthorID.Text.Trim();
            string fname = textBoxFirstName.Text.Trim();
            string lname = textBoxLastName.Text.Trim();
            string email = textBoxEmail.Text.Trim();

            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("ISBN is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(authorId))
            {
                MessageBox.Show("Author ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Focus();
                return;
            }

            if (Validator.IsEmpty(fname))
            {
                MessageBox.Show("Author's FirstName is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Focus();
                return;
            }

            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("Author's Last Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            if (!Validator.IsValidId(iSBN, 13))
            {
                MessageBox.Show("ISBN is a 13-digit number.", "Invalid ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            if (!Validator.IsValidId(authorId, 3))
            {
                MessageBox.Show("Author ID is a 3-digit number.", "Invalid Author ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Clear();
                textBoxAuthorID.Focus();
                return;
            }

            if (!Validator.IsValidString(fname))
            {
                MessageBox.Show("Author's First Name can contain only characters and white space.", "Invalid Author's First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            if (!Validator.IsValidString(lname))
            {
                MessageBox.Show("Author's Last Name can contain only characters or white space.", "Invalid Author's Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Author's Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            Book book = new Book();
            book = book.SearchBook(iSBN);
            if (book == null)
            {
                MessageBox.Show("This ISBN does not exist.", "ISBN Cannot Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            AuthorBook auBo = new AuthorBook();
            auBo = auBo.SearchAuthorBook(Convert.ToInt32(authorId), iSBN);
            if ( auBo != null)
            {
                MessageBox.Show("Author "+ authorId + " was already added to Book " + iSBN, "Duplicate Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Clear();
                textBoxISBN.Clear();
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxEmail.Clear();
                textBoxAuthorID.Focus();
                return;
            }

            AuthorBook auBo1 = new AuthorBook();
            List<AuthorBook> authorBooks = new List<AuthorBook>();
            authorBooks = auBo1.SearchListAuthorBook(iSBN);
            if(authorBooks == null)
            {
                MessageBox.Show("Please update this Book information", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                auBo1 = authorBooks.FirstOrDefault();
            }
            
            // When data is valid
            if (MessageBox.Show("Do you want to add Author "+ authorId+ " to Book " + iSBN,"Add Author Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString() == "Yes")
            {
                Author author = new Author();
                author = author.SearchAuthor(Convert.ToInt32(authorId));
                if (author == null)
                {
                    Author auSave = new Author();
                    auSave.AuthorId = Convert.ToInt32(authorId);
                    auSave.FirstName = fname;
                    auSave.LastName = lname;
                    auSave.Email = email;
                    auSave.SaveAuthor(auSave);
                }
                AuthorBook auBoSave = new AuthorBook();
                auBoSave.AuthorId = Convert.ToInt32(authorId);
                auBoSave.ISBN = iSBN;
                auBoSave.Edition = auBo1.Edition;
                auBoSave.YearPublished = auBo1.YearPublished;
                auBoSave.SaveAuthorBook(auBoSave);
                MessageBox.Show("One Author has been added to the Book.", "Add Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No change has been made.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            textBoxEdition.Clear();
            textBoxYearPublished.Clear();
            textBoxAuthorID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            comboBoxPublisher.SelectedIndex = -1;
            comboBoxCategory.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            textBoxAuthorID.Focus();
        }
        // Search for author
        private void buttonSearchAuthor_Click(object sender, EventArgs e)
        {
            // Validate input data
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();

            string authorId = textBoxAuthorID.Text.Trim();

            if (Validator.IsEmpty(authorId))
            {
                MessageBox.Show("Author ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Focus();
                return;
            }

            if (!Validator.IsValidId(authorId, 3))
            {
                MessageBox.Show("Author ID is a 3-digit number.", "Invalid Author ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Clear();
                textBoxAuthorID.Focus();
                return;
            }

            Author author = new Author();
            author = author.SearchAuthor(Convert.ToInt32(authorId));

            if (author == null)
            {
                MessageBox.Show("Cannot found this Author.", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAuthorID.Clear();
                textBoxAuthorID.Focus();
                return;
            }
            else
            {
                textBoxFirstName.Text = author.FirstName;
                textBoxLastName.Text = author.LastName;
                textBoxEmail.Text = author.Email;
            }
        }
        // Search for book by ISBN
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textBoxBookTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            textBoxYearPublished.Clear();
            textBoxEdition.Clear();
            comboBoxPublisher.SelectedIndex = -1;
            comboBoxCategory.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            string input = textBoxISBN.Text.Trim();
            if (!Validator.IsValidId(input, 13))
            {
                MessageBox.Show("Please input a 13-digit ISBN.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }
            Book book = new Book();
            book = book.SearchBook(input);
            if (book == null)
            {
                MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }
            else
            {
                AuthorBook auBo = new AuthorBook();
                List<AuthorBook> listAuBo = new List<AuthorBook>();
                listAuBo = auBo.SearchListAuthorBook(input);
                if(listAuBo != null)
                {
                    auBo = listAuBo.FirstOrDefault();
                    textBoxEdition.Text = auBo.Edition.ToString();
                    textBoxYearPublished.Text = auBo.YearPublished.ToString();
                }
                textBoxISBN.Text = book.ISBN;
                textBoxBookTitle.Text = book.BookTitle;
                textBoxUnitPrice.Text = book.UnitPrice.ToString();
                textBoxQOH.Text = book.QOH.ToString();
                Publisher pub = new Publisher();
                pub = pub.SearchPublisher(book.PublisherId);
                Category cat = new Category();
                cat = cat.SearchCategory(book.CategoryId);
                comboBoxPublisher.SelectedItem = pub.PublisherId.ToString() + ". " + pub.PublisherName;
                comboBoxCategory.SelectedItem = cat.CategoryId.ToString() + ". " + cat.CategoryName;
                int stt = book.Status;
                if (stt == 8)
                {
                    comboBoxStatus.SelectedIndex = 0;
                }
                else if (stt == 10)
                {
                    comboBoxStatus.SelectedIndex = 1;
                }else if (stt == 11)
                {
                    comboBoxStatus.SelectedIndex = 2;
                }else if (stt == 9)
                {
                    if(comboBoxStatus.Items.Count == 3)
                    {
                        comboBoxStatus.Items.Add("9. Out of Stock");
                    }
                    comboBoxStatus.SelectedIndex = 3;
                }
            }
        }

        private void comboBoxStatus_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBoxStatus.Items.Count >= 3)
            {
                comboBoxStatus.Items.Remove("9. Out of Stock");
            }
        }
    }
}
