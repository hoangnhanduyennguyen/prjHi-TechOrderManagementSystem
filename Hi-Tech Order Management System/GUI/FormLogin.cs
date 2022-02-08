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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Data Validation
            string userId = textBoxUserID.Text.Trim();
            if (Validator.IsEmpty(userId))
            {
                MessageBox.Show("Please enter User ID.", "Empty User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (!Validator.IsValidId(userId,4))
            {
                MessageBox.Show("Wrong User ID or Password. Please try again.", "Login Unsuccessfully", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Clear();
                textBoxPassword.Focus();
                return;
            }

            string pw = textBoxPassword.Text.Trim();
            if (Validator.IsEmpty(pw))
            {
                MessageBox.Show("Please enter Password.", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            int uId = Convert.ToInt32(userId);
            UserAccount u = new UserAccount();
            u = u.SearchUserAccount(uId);
            if (u == null)
            {
                MessageBox.Show("Wrong User ID or Password. Please try again.", "Login Unsuccessfully", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Clear();
                textBoxPassword.Focus();
                return;
            }

            // When data is valid 
            UserAccount user = new UserAccount();
            user = user.SearchUserAccount(uId, pw);
            if (user == null)
            {
                MessageBox.Show("Wrong User ID or Password. Please try again.", "Login Unsuccessfully", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Clear();
                textBoxPassword.Focus();
                return;
            }
            else
            {
                Employee emp = new Employee();
                emp = emp.SearchEmployee(uId);
                Job job = new Job();
                job = job.SearchJob(emp.JobId);
                string jobTitle = job.JobTitle;
                MessageBox.Show("Login as " + jobTitle, "Login Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (jobTitle == "MIS Manager")
                {
                    this.Hide();
                    FormUserEmployee ueForm = new FormUserEmployee();
                    ueForm.ShowDialog();
                }
                else if (jobTitle == "Sales Manager")
                {
                    this.Hide();
                    FormCustomer custForm = new FormCustomer();
                    custForm.ShowDialog();
                }
                else if (jobTitle == "Inventory Controller")
                {
                    this.Hide();
                    FormBook bookForm = new FormBook();
                    bookForm.ShowDialog();
                }
                else if (jobTitle == "Order Clerks")
                {
                    this.Hide();
                    FormOrder formOrder = new FormOrder(uId);
                    formOrder.ShowDialog();
                }
                textBoxPassword.Clear();
            }
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                Application.Exit();
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void buttonForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormForgotPassword forgot = new FormForgotPassword();
            forgot.Show();
        }
    }
}
