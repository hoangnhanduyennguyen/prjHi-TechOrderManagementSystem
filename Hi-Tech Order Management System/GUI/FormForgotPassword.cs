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
    public partial class FormForgotPassword : Form
    {
        public FormForgotPassword()
        {
            InitializeComponent();
        }
        // Return to Login 
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.Show();
        }
        // Validate and change password
        private void buttonValidate_Click(object sender, EventArgs e)
        {
            // Data Validation
            string empId = textBoxEmployeeId.Text.Trim();
            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Please enter your Employee ID.", "Empty Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeId.Focus();
                return;
            }

            string fname = textBoxFirstName.Text.Trim();
            if (Validator.IsEmpty(fname))
            {
                MessageBox.Show("Please enter your first name.", "Empty First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Focus();
                return;
            }

            string lname = textBoxLastName.Text.Trim();
            if (Validator.IsEmpty(lname))
            {
                MessageBox.Show("Please enter your last name.", "Empty Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Focus();
                return;
            }

            string email = textBoxEmail.Text.Trim();
            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Please enter your email.", "Empty Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            string pass = textBoxNewPassword.Text.Trim();
            if (Validator.IsEmpty(pass))
            {
                MessageBox.Show("Please enter your new password.", "Empty New Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNewPassword.Focus();
                return;
            }

            string reenter = textBoxReenter.Text.Trim();
            if (Validator.IsEmpty(reenter))
            {
                MessageBox.Show("Please reenter your password.", "Empty Reenter Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxReenter.Focus();
                return;
            }

            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Wrong Employee ID. Please try again.", "Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;
            }

            if(pass != reenter)
            {
                MessageBox.Show("New password and reenter password do not match.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNewPassword.Clear();
                textBoxReenter.Clear();
                textBoxNewPassword.Focus();
                return;
            }

            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if(emp == null)
            {
                MessageBox.Show("One of your input is wrong. Please try again.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeId.Focus();
                return;
            }
            else if( emp.FirstName != fname)
            {
                MessageBox.Show("One of your input is wrong. Please try again.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeId.Focus();
                return;
            }
            else if (emp.LastName != lname)
            {
                MessageBox.Show("One of your input is wrong. Please try again.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeId.Focus();
                return;
            }
            else if(emp.Email != email)
            {
                MessageBox.Show("One of your input is wrong. Please try again.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeId.Focus();
                return;
            }
            else
            {
                int uId = Convert.ToInt32(empId);
                UserAccount u = new UserAccount();
                u = u.SearchUserAccount(uId);
                if (u != null)
                {
                    if (MessageBox.Show("Do you want to change your password?", "Change Password Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                    {
                        u.Password = pass;
                        u.UpdateUser(u);
                        MessageBox.Show("Your password has been changed successfully.", "Change Password Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Your password has not been changed.", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Hide();
                    FormLogin login = new FormLogin();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Your account does not exist.", "Non-exist User Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBoxEmployeeId.Clear();
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxNewPassword.Clear();
                textBoxEmail.Clear();
                textBoxReenter.Clear();
            }
        }
    }
}
