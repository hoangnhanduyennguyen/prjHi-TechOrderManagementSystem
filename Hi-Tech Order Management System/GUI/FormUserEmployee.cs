using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechLibrary.Validation;
using HiTechLibrary.Business;
using HiTechLibrary.DataAccess;

namespace Hi_Tech_Order_Management_System.GUI
{
    public partial class FormUserEmployee : Form
    {
        public FormUserEmployee()
        {
            InitializeComponent();
        }
        //Exit button 
        private void buttonExitUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                Application.Exit();
            }
        }
        //Add user button
        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string userId = textBoxUserID.Text.Trim();
            string pw = textBoxPassword.Text.Trim();
            string empId = textBoxEI.Text.Trim();
            // Validate empty field
            if (Validator.IsEmpty(userId))
            {
                MessageBox.Show("User ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (Validator.IsEmpty(pw))
            {
                MessageBox.Show("Password is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Focus();
                return;
            }

            // Validate ID
            if (!Validator.IsValidId(userId, 4))
            {
                MessageBox.Show("User ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Employee ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Clear();
                textBoxEI.Focus();
                return;
            }

            // Validate duplicate UserId
            UserAccount user = new UserAccount();
            user = user.SearchUserAccount(Convert.ToInt32(userId));
            if (user != null)
            {
                MessageBox.Show("This User ID already exist.", "Duplicate User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Clear();
                textBoxEI.Focus();
                return;
            }

            // Validate that one Employee can only have 1 account
            UserAccount anUser = new UserAccount();
            anUser = anUser.SearchUserAccountByEmpId(Convert.ToInt32(empId));
            if (anUser != null)
            {
                MessageBox.Show("This Employee ID already has an User Account.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxPassword.Clear();
                textBoxEI.Clear();
                textBoxUserID.Focus();
                return;
            }

            // When data is valid
            if (MessageBox.Show("Do you want to save this user? ", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                UserAccount userSave = new UserAccount();
                userSave.EmployeeId = Convert.ToInt32(empId);
                userSave.Password = pw;
                userSave.UserId = Convert.ToInt32(userId);
                userSave.SaveUser(userSave);
                MessageBox.Show("User has been saved successfully.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User has NOT been saved.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxUserID.Clear();
            textBoxEI.Clear();
            textBoxPassword.Clear();
            textBoxUserID.Focus();
        }
        // Update user button
        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            string userId = textBoxUserID.Text.Trim();
            string pw = textBoxPassword.Text.Trim();
            string empId = textBoxEI.Text.Trim();
            // Validate empty field
            if (Validator.IsEmpty(userId))
            {
                MessageBox.Show("User ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (Validator.IsEmpty(pw))
            {
                MessageBox.Show("Password is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Focus();
                return;
            }

            //Validate ID
            UserAccount user = new UserAccount();
            user = user.SearchUserAccount(Convert.ToInt32(userId));
            if(user == null)
            {
                MessageBox.Show("User ID does not exist.", "Non-exist User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            if(user.EmployeeId != Convert.ToInt32(empId))
            {
                MessageBox.Show("Employee ID cannot be updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Clear();
                textBoxEI.Focus();
                return;
            }

            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Clear();
                textBoxEI.Focus();
                return;
            }

            // When data is valid
            if (MessageBox.Show("Do you want to update this User Information?","Update Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString() == "Yes")
            {
                UserAccount userUpdate = new UserAccount();
                userUpdate.UserId = Convert.ToInt32(userId);
                userUpdate.Password = pw;
                userUpdate.EmployeeId = Convert.ToInt32(empId);
                userUpdate.UpdateUser(userUpdate);
                MessageBox.Show("User has been updated.", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nothing has been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxUserID.Clear();
            textBoxEI.Clear();
            textBoxPassword.Clear();
            textBoxUserID.Focus();
        }
        //Delete user button
        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            string userId = textBoxUserID.Text.Trim();
            string pw = textBoxPassword.Text.Trim();
            string empId = textBoxEI.Text.Trim();
            // Check empty field
            if (Validator.IsEmpty(userId))
            {
                MessageBox.Show("User ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (Validator.IsEmpty(pw))
            {
                MessageBox.Show("Password is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Focus();
                return;
            }

            // Check Invalid ID
            if (!Validator.IsValidId(userId, 4))
            {
                MessageBox.Show("User ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Employee ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Clear();
                textBoxEI.Focus();
                return;
            }

            // Check duplicate UserId
            UserAccount user = new UserAccount();
            user = user.SearchUserAccount(Convert.ToInt32(userId));
            if (user == null)
            {
                MessageBox.Show("This User ID does not exist.", "Non-exist User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            Job job = new Job();
            job = job.SearchJob(emp.JobId);
            string jobTitle = job.JobTitle;
            if (jobTitle == "MIS Manager")
            {
                MessageBox.Show("Cannot delete a MIS Manager account. You may want to update this user account!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxEI.Clear();
                textBoxPassword.Clear();
                textBoxUserID.Focus();
                return;
            }
            else if (jobTitle == "Order Clerks")
            {
                MessageBox.Show("Cannot delete an Order Clerk account. You may want to update this user account!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxEI.Clear();
                textBoxPassword.Clear();
                textBoxUserID.Focus();
                return;
            }

            // When data is valid
            if (MessageBox.Show("Do you want to delete this user? ", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                user.DeleteUser(Convert.ToInt32(userId));
                MessageBox.Show("User has been deleted successfully.", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User has NOT been deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxUserID.Clear();
            textBoxEI.Clear();
            textBoxPassword.Clear();
            textBoxUserID.Focus();
        }
        private void comboBoxUserOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = comboBoxUserOption.SelectedIndex;
            if (select == 0)
            {
                labelUserInfo.Text = "Please input User ID.";
            }
            else if(select == 1)
            {
                labelUserInfo.Text = "Please input Employee ID.";
            }
        }
        // Search for user button
        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            textBoxUserID.Clear();
            textBoxPassword.Clear();
            textBoxEI.Clear();
            string input = textBoxUserInput.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Input is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserInput.Focus();
                return;
            }
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("Please input a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserInput.Clear();
                textBoxUserInput.Focus();
                return;
            }

            int select = comboBoxUserOption.SelectedIndex;
            switch (select)
            {
                case -1:
                    MessageBox.Show("Please choose an option.", "Empty Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxUserOption.Focus();
                    break;
                case 0:
                    int uId = Convert.ToInt32(input);
                    UserAccount userSearch = new UserAccount();
                    userSearch = userSearch.SearchUserAccount(uId);
                    if (userSearch == null)
                    {
                        MessageBox.Show("This User ID does not exist.", "Non-exist User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxUserInput.Clear();
                        textBoxUserInput.Focus();
                        return;
                    }
                    else
                    {
                        textBoxUserID.Text = userSearch.UserId.ToString();
                        textBoxPassword.Text = userSearch.Password;
                        textBoxEI.Text = userSearch.EmployeeId.ToString();
                        textBoxUserInput.Clear();
                        labelUserInfo.Text = "";
                        comboBoxUserOption.SelectedIndex = -1;
                    }
                    break;
                case 1:
                    int eId = Convert.ToInt32(input);
                    UserAccount userSearch1 = new UserAccount();
                    userSearch1 = userSearch1.SearchUserAccountByEmpId(eId);
                    if (userSearch1 == null)
                    {
                        MessageBox.Show("This Employee ID does not exist or does not has an account.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxUserInput.Clear();
                        textBoxUserInput.Focus();
                        return;
                    }
                    else
                    {
                        textBoxUserID.Text = userSearch1.UserId.ToString();
                        textBoxPassword.Text = userSearch1.Password;
                        textBoxEI.Text = userSearch1.EmployeeId.ToString();
                        textBoxUserInput.Clear();
                        labelUserInfo.Text = "";
                        comboBoxUserOption.SelectedIndex = -1;
                    }
                    break;
            }
        }
        // List all user button
        private void buttonListAllUser_Click(object sender, EventArgs e)
        {
            listViewUser.Items.Clear();
            List<UserAccount> listUser = new List<UserAccount>();
            UserAccount user = new UserAccount();
            listUser = user.SearchAllUser();
            if(listUser.Count != 0)
            {
                foreach (UserAccount uA in listUser)
                {
                    ListViewItem item = new ListViewItem(uA.UserId.ToString());
                    item.SubItems.Add(uA.Password);
                    item.SubItems.Add(uA.EmployeeId.ToString());
                    listViewUser.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("There is no User to display.", "Empty User Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Clear all textboxes
        private void buttonClear_Click(object sender, EventArgs e)
        {
            listViewUser.Items.Clear();
            textBoxEI.Clear();
            textBoxUserID.Clear();
            textBoxPassword.Clear();
            comboBoxUserOption.SelectedIndex = -1;
            textBoxUserInput.Clear();
            labelUserInfo.Text = "";
        }
        // Save employee button
        private void buttonSaveEmp_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string empId = textBoxEmployeeID.Text.Trim();
            string fName = textBoxFN.Text.Trim();
            string lName = textBoxLN.Text.Trim();
            string pNum = maskedTextBoxPN.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            // Validate empty input
            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Focus();
                return;
            }

            if (Validator.IsEmpty(fName))
            {
                MessageBox.Show("First Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFN.Focus();
                return;
            }

            if (Validator.IsEmpty(lName))
            {
                MessageBox.Show("Last Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLN.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Email is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            if (!maskedTextBoxPN.MaskFull)
            {
                MessageBox.Show("Please enter a 10-digit phone number", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPN.Clear();
                maskedTextBoxPN.Focus();
                return;
            }

            if (comboBoxJob.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a job position", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxJob.Focus();
                return;
            }

            // Validate ID
            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Please enter a 4-digit Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            //Validate Name
            if (!Validator.IsValidString(fName))
            {
                MessageBox.Show("First Name can only contain characters and white spaces", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFN.Clear();
                textBoxFN.Focus();
                return;
            }

            if (!Validator.IsValidString(lName))
            {
                MessageBox.Show("Last Name can only contain characters and white spaces", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLN.Clear();
                textBoxLN.Focus();
                return;
            }

            // Validate Email
            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com)", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            // Validate duplicate EmployeeId
            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp != null)
            {
                MessageBox.Show("This Employee ID already exist", "Duplicate Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            string jobId = comboBoxJob.SelectedItem.ToString();
            string[] job = jobId.Split(',');

            // When data is valid
            if (MessageBox.Show("Do you want to save this employee? ", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                Employee empSave = new Employee();
                empSave.EmployeeId = Convert.ToInt32(empId);
                empSave.FirstName = fName;
                empSave.LastName = lName;
                empSave.PhoneNumber = pNum;
                empSave.Email = email;
                empSave.JobId = Convert.ToInt32(job[0]);
                empSave.SaveEmployee(empSave);
                MessageBox.Show("Employee has been saved successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Employee has NOT been saved", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            textBoxEmployeeID.Clear();
            textBoxFN.Clear();
            textBoxLN.Clear();
            maskedTextBoxPN.Clear();
            textBoxEmail.Clear();
            comboBoxJob.SelectedIndex = -1;
            listViewEmployee.Items.Clear();
            textBoxEmployeeID.Focus();
        }
        // Update employee button
        private void buttonUpdateEmp_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string empId = textBoxEmployeeID.Text.Trim();
            string fName = textBoxFN.Text.Trim();
            string lName = textBoxLN.Text.Trim();
            string pNum = maskedTextBoxPN.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            // Validate empty field
            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Focus();
                return;
            }

            if (Validator.IsEmpty(fName))
            {
                MessageBox.Show("First Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFN.Focus();
                return;
            }

            if (Validator.IsEmpty(lName))
            {
                MessageBox.Show("Last Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLN.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Email is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            if (!maskedTextBoxPN.MaskFull)
            {
                MessageBox.Show("Please enter a 10-digit phone number", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPN.Clear();
                maskedTextBoxPN.Focus();
                return;
            }

            if (comboBoxJob.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a job position", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxJob.Focus();
                return;
            }

            // Validate employee ID
            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Please enter a 4-digit Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            //Validate Name
            if (!Validator.IsValidString(fName))
            {
                MessageBox.Show("First Name can only contain characters and white spaces", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFN.Clear();
                textBoxFN.Focus();
                return;
            }

            if (!Validator.IsValidString(lName))
            {
                MessageBox.Show("Last Name can only contain characters and white spaces", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLN.Clear();
                textBoxLN.Focus();
                return;
            }

            // Validate Email
            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com)", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            // Validate if EmployeeId exist or not 
            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            string jobId = comboBoxJob.SelectedItem.ToString();
            string[] job = jobId.Split(',');

            // When data is valid
            if (MessageBox.Show("Do you want to update this Employee Information?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                Employee empUpdate = new Employee();
                empUpdate.EmployeeId = Convert.ToInt32(empId);
                empUpdate.FirstName = fName;
                empUpdate.LastName = lName;
                empUpdate.PhoneNumber = pNum;
                empUpdate.Email = email;
                empUpdate.JobId = Convert.ToInt32(job[0]);
                empUpdate.UpdateEmployee(empUpdate);
                MessageBox.Show("Employee has been updated.", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nothing has been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxEmployeeID.Clear();
            comboBoxJob.SelectedIndex = -1;
            textBoxFN.Clear();
            textBoxLN.Clear();
            maskedTextBoxPN.Clear();
            textBoxEmail.Clear();
            textBoxEmployeeID.Focus();
        }
        // Delete employee button
        private void buttonDeleteEmp_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string empId = textBoxEmployeeID.Text.Trim();
            string fName = textBoxFN.Text.Trim();
            string lName = textBoxLN.Text.Trim();
            string pNum = maskedTextBoxPN.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            // Validate empty field
            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEI.Focus();
                return;
            }

            if (Validator.IsEmpty(fName))
            {
                MessageBox.Show("First Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFN.Focus();
                return;
            }

            if (Validator.IsEmpty(lName))
            {
                MessageBox.Show("Last Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLN.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Email is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            if (!maskedTextBoxPN.MaskFull)
            {
                MessageBox.Show("Please enter a 10-digit phone number", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPN.Clear();
                maskedTextBoxPN.Focus();
                return;
            }

            if (comboBoxJob.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a job position", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxJob.Focus();
                return;
            }

            // Validate employee ID
            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Please enter a 4-digit Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            //Validate Name
            if (!Validator.IsValidString(fName))
            {
                MessageBox.Show("First Name can only contain characters and white spaces", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFN.Clear();
                textBoxFN.Focus();
                return;
            }

            if (!Validator.IsValidString(lName))
            {
                MessageBox.Show("Last Name can only contain characters and white spaces", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLN.Clear();
                textBoxLN.Focus();
                return;
            }

            // Validate Email
            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com)", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            // Validate if EmployeeId exist
            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            Job job = new Job();
            job = job.SearchJob(emp.JobId);
            string jobTitle = job.JobTitle;
            if (jobTitle == "MIS Manager")
            {
                MessageBox.Show("Cannot delete a MIS Manager.\nYou may want to update this employee information!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                comboBoxJob.SelectedIndex = -1;
                textBoxFN.Clear();
                textBoxLN.Clear();
                maskedTextBoxPN.Clear();
                textBoxEmail.Clear();
                textBoxEmployeeID.Focus();
                return;
            }
            else if (jobTitle == "Order Clerks")
            {
                MessageBox.Show("Cannot delete an Order Clerk.\nYou may want to update this employee information!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                comboBoxJob.SelectedIndex = -1;
                textBoxFN.Clear();
                textBoxLN.Clear();
                maskedTextBoxPN.Clear();
                textBoxEmail.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            UserAccount user = new UserAccount();
            user = user.SearchUserAccountByEmpId(Convert.ToInt32(empId));
            if (user != null)
            {
                if (MessageBox.Show("This Employee has a User Account. \nDo you want to delete this Employee and User Account Information?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    user.DeleteUser(user.UserId);
                    Employee empDelete = new Employee();
                    empDelete.DeleteEmployee(Convert.ToInt32(empId));
                    MessageBox.Show("Employee has been deleted.", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nothing has been deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this Employee Information?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    Employee empDelete = new Employee();
                    empDelete.DeleteEmployee(Convert.ToInt32(empId));
                    MessageBox.Show("Employee has been deleted.", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nothing has been deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            textBoxEmployeeID.Clear();
            comboBoxJob.SelectedIndex = -1;
            textBoxFN.Clear();
            textBoxLN.Clear();
            maskedTextBoxPN.Clear();
            textBoxEmail.Clear();
            textBoxEmployeeID.Focus();
        }
        // Clear all textboxes
        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            textBoxEmployeeID.Clear();
            textBoxFN.Clear();
            textBoxLN.Clear();
            maskedTextBoxPN.Clear();
            textBoxEmail.Clear();
            comboBoxJob.SelectedIndex = -1;
            comboBoxEmployee.SelectedIndex = -1;
            listViewEmployee.Items.Clear();
            textBoxEmployeeID.Focus();
        }
        // Search for an employee
        private void buttonSearchEmp_Click(object sender, EventArgs e)
        {
            textBoxEmployeeID.Clear();
            textBoxFN.Clear();
            textBoxLN.Clear();
            maskedTextBoxPN.Clear();
            textBoxEmail.Clear();
            comboBoxJob.SelectedIndex = -1;
            string input = textBoxInputEmp.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Input is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxInputEmp.Focus();
                return;
            }

            int select = comboBoxEmployee.SelectedIndex;
            switch (select)
            {
                case -1:
                    MessageBox.Show("Please choose an option.", "Empty Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxEmployee.Focus();
                    break;
                case 0:
                    if (!Validator.IsValidId(input, 4))
                    {
                        MessageBox.Show("Please input a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputEmp.Clear();
                        textBoxInputEmp.Focus();
                        return;
                    }

                    int eId = Convert.ToInt32(input);
                    Employee empSearch = new Employee();
                    empSearch = empSearch.SearchEmployee(eId);
                    if (empSearch == null)
                    {
                        MessageBox.Show("This Employee ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputEmp.Clear();
                        textBoxInputEmp.Focus();
                        return;
                    }
                    else
                    {
                        textBoxEmployeeID.Text = empSearch.EmployeeId.ToString();
                        textBoxFN.Text = empSearch.FirstName;
                        textBoxLN.Text = empSearch.LastName;
                        maskedTextBoxPN.Text = empSearch.PhoneNumber;
                        textBoxEmail.Text = empSearch.Email;
                        if (empSearch.JobId == 11111)
                        {
                            comboBoxJob.SelectedIndex = 0;
                        }
                        else if (empSearch.JobId == 22222)
                        {
                            comboBoxJob.SelectedIndex = 1;
                        }else if (empSearch.JobId == 33333)
                        {
                            comboBoxJob.SelectedIndex = 2;
                        } else if (empSearch.JobId == 44444)
                        {
                            comboBoxJob.SelectedIndex = 3;
                        }else 
                        {
                            comboBoxJob.SelectedIndex = 4;
                        }
                        textBoxInputEmp.Clear();
                        labelInfoEmp.Text = "";
                        comboBoxEmployee.SelectedIndex = -1;
                    }
                    break;
                case 1:
                    listViewEmployee.Items.Clear();
                    if (!Validator.IsValidString(input))
                    {
                        MessageBox.Show("First Name can only contant characters and/or space", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputEmp.Clear();
                        textBoxInputEmp.Focus();
                        return;
                    }
                    List<Employee> listEmp = new List<Employee>();
                    Employee empSearch1 = new Employee();
                    listEmp = empSearch1.SearchEmployeeByName(input, "FirstName");
                    if (listEmp.Count == 0)
                    {
                        MessageBox.Show("This First Name does not exist.", "Non-exist First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputEmp.Clear();
                        textBoxInputEmp.Focus();
                        return;
                    }
                    else
                    {
                        foreach (Employee emp in listEmp)
                        {
                            ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                            item.SubItems.Add(emp.FirstName);
                            item.SubItems.Add(emp.LastName);
                            item.SubItems.Add(emp.PhoneNumber);
                            item.SubItems.Add(emp.Email);
                            item.SubItems.Add(emp.JobId.ToString());
                            listViewEmployee.Items.Add(item);
                        }
                        textBoxInputEmp.Clear();
                        labelInfoEmp.Text = "";
                        comboBoxEmployee.SelectedIndex = -1;
                    }
                    break;
                case 2:
                    listViewEmployee.Items.Clear();
                    if (!Validator.IsValidString(input))
                    {
                        MessageBox.Show("Last Name can only contant characters and/or space", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputEmp.Clear();
                        textBoxInputEmp.Focus();
                        return;
                    }
                    List<Employee> listEmp2 = new List<Employee>();
                    Employee empSearch2 = new Employee();
                    listEmp2 = empSearch2.SearchEmployeeByName(input, "LastName");
                    if (listEmp2.Count == 0)
                    {
                        MessageBox.Show("This Last Name does not exist.", "Non-exist Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInputEmp.Clear();
                        textBoxInputEmp.Focus();
                        return;
                    }
                    else
                    {
                        foreach (Employee emp1 in listEmp2)
                        {
                            ListViewItem item = new ListViewItem(emp1.EmployeeId.ToString());
                            item.SubItems.Add(emp1.FirstName);
                            item.SubItems.Add(emp1.LastName);
                            item.SubItems.Add(emp1.PhoneNumber);
                            item.SubItems.Add(emp1.Email);
                            item.SubItems.Add(emp1.JobId.ToString());
                            listViewEmployee.Items.Add(item);
                        }
                        textBoxInputEmp.Clear();
                        labelInfoEmp.Text = "";
                        comboBoxEmployee.SelectedIndex = -1;
                    }
                    break;
            }
        }
        // List all employees
        private void buttonSearchAll_Click(object sender, EventArgs e)
        {
            listViewEmployee.Items.Clear();
            List<Employee> listEmp = new List<Employee>();
            Employee emp = new Employee();
            listEmp = emp.SearchAllEmployee();
            if (listEmp.Count != 0)
            {
                foreach (Employee em in listEmp)
                {
                    ListViewItem item = new ListViewItem(em.EmployeeId.ToString());
                    item.SubItems.Add(em.FirstName);
                    item.SubItems.Add(em.LastName);
                    item.SubItems.Add(em.PhoneNumber);
                    item.SubItems.Add(em.Email);
                    item.SubItems.Add(em.JobId.ToString());
                    listViewEmployee.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("There is no Employee to display.", "Empty Employee Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Exit button
        private void buttonExitEmp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                Application.Exit();
            }
        }

        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = comboBoxEmployee.SelectedIndex;
            if (select == 0)
            {
                labelInfoEmp.Text = "Please input Employee ID.";
            }
            else if (select == 1)
            {
                labelInfoEmp.Text = "Please input Employee First Name.";
            }
            else if (select == 2)
            {
                labelInfoEmp.Text = "Please input Employee Last Name.";
            }
        }
        //Log out button
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Hide();
                FormLogin login = new FormLogin();
                login.ShowDialog();
            }
        }

        private void FormUserEmployee_Load(object sender, EventArgs e)
        {
            Job job = new Job();
            List<Job> listJob = new List<Job>();
            listJob = job.SearchJobList();
            foreach (var j in listJob)
            {
                comboBoxJob.Items.Add(j.JobId + ", " + j.JobTitle);
            }
        }
    }
}
