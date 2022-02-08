using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using HiTechLibrary.Business;
using HiTechLibrary.DataAccess;
using HiTechLibrary.Validation;


namespace Hi_Tech_Order_Management_System.GUI
{
    public partial class FormCustomer : Form
    {
        SqlDataAdapter da;
        SqlDataAdapter da1;
        DataSet dsHiTechDB;
        DataTable dtCustomers;
        DataTable dtOrders;
        SqlCommandBuilder sqlBuilder;
        DataRelation re;

        public FormCustomer()
        {
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            dsHiTechDB = new DataSet("HiTechDB");
            dtCustomers = new DataTable("Customers");
            dtCustomers.Columns.Add("CustomerId", typeof(Int32));
            dtCustomers.Columns.Add("CustomerName", typeof(string));
            dtCustomers.Columns.Add("StreetName", typeof(string));
            dtCustomers.Columns.Add("Province", typeof(string));
            dtCustomers.Columns.Add("City", typeof(string));
            dtCustomers.Columns.Add("PostalCode", typeof(string));
            dtCustomers.Columns.Add("PhoneNumber", typeof(string));
            dtCustomers.Columns.Add("ContactName", typeof(string));
            dtCustomers.Columns.Add("ContactEmail", typeof(string));
            dtCustomers.Columns.Add("CreditLimit", typeof(Int32));
            dtCustomers.Columns.Add("Status", typeof(Int32));
            dtCustomers.PrimaryKey = new DataColumn[] { dtCustomers.Columns["CustomerId"] };
            dsHiTechDB.Tables.Add(dtCustomers);

            dtOrders = new DataTable("Orders");
            dtOrders.Columns.Add("OrderId", typeof(Int32));
            dtOrders.Columns.Add("OrderDate", typeof(DateTime));
            dtOrders.Columns.Add("OrderType", typeof(string));
            dtOrders.Columns.Add("RequiredDate", typeof(DateTime));
            dtOrders.Columns.Add("ShippingDate", typeof(DateTime));
            dtOrders.Columns.Add("OrderStatus", typeof(Int32));
            dtOrders.Columns.Add("CustomerId", typeof(Int32));
            dtOrders.Columns.Add("EmployeeId", typeof(Int32));
            dtOrders.PrimaryKey = new DataColumn[] { dtOrders.Columns["OrderId"] };
            dsHiTechDB.Tables.Add(dtOrders);

            re = new DataRelation("reOsCs", dtCustomers.Columns["CustomerId"], dtOrders.Columns["CustomerId"]);

            da1 = new SqlDataAdapter("SELECT * FROM Orders", UtilityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(da1);
            da1.Fill(dsHiTechDB.Tables["Orders"]);

            da = new SqlDataAdapter("SELECT * FROM Customers", UtilityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(da);
            da.Fill(dsHiTechDB.Tables["Customers"]);

            Status status = new Status();
            List<Status> listStatus = status.SearchStatus("Customer");
            foreach (var item in listStatus)
            {
                comboBoxStatus.Items.Add(item.Id + ". " + item.Description);
            }
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
            string custId = textBoxCustomerID.Text.Trim();
            string custName = textBoxCustomerName.Text.Trim();
            string street = textBoxStreetName.Text.Trim();
            string province = textBoxProvince.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string postCode = textBoxPostalCode.Text.Trim();
            string phoneNumber = maskedTextBoxPhoneNum.Text.Trim();
            string conName = textBoxContactName.Text.Trim();
            string conEmail = textBoxContactEmail.Text.Trim();
            string creditLimit = textBoxCreditLimit.Text.Trim();

            // Validate input
            if (Validator.IsEmpty(custId))
            {
                MessageBox.Show("Customer ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }

            if (Validator.IsEmpty(custName))
            {
                MessageBox.Show("Customer Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerName.Focus();
                return;
            }

            if (Validator.IsEmpty(street))
            {
                MessageBox.Show("Street Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreetName.Focus();
                return;
            }

            if (Validator.IsEmpty(province))
            {
                MessageBox.Show("Province is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProvince.Focus();
                return;
            }

            if (Validator.IsEmpty(city))
            {
                MessageBox.Show("City is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Focus();
                return;
            }

            if (Validator.IsEmpty(postCode))
            {
                MessageBox.Show("Postal Code is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostalCode.Focus();
                return;
            }

            if (!maskedTextBoxPhoneNum.MaskCompleted)
            {
                MessageBox.Show("Please enter your phone number (e.g (514)-111-1111).", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPhoneNum.Clear();
                maskedTextBoxPhoneNum.Focus();
                return;
            }

            if (Validator.IsEmpty(conName))
            {
                MessageBox.Show("Contact Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactName.Focus();
                return;
            }

            if (Validator.IsEmpty(conEmail))
            {
                MessageBox.Show("Contact Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactEmail.Focus();
                return;
            }

            if (Validator.IsEmpty(creditLimit))
            {
                MessageBox.Show("Credit Limit is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProvince.Focus();
                return;
            }

            if (comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Status is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxStatus.Focus();
                return;
            }

            if (comboBoxStatus.SelectedIndex == 1)
            {
                MessageBox.Show("Cannot save an inactive customer.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxStatus.Focus();
                return;
            }

            // Validate Invalid Information
            if (!Validator.IsValidId(custId, 6))
            {
                MessageBox.Show("Customer ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            if (!Validator.IsValidString(custName))
            {
                MessageBox.Show("Customer Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerName.Clear();
                textBoxCustomerName.Focus();
                return;
            }

            if (!Validator.IsValidString(province))
            {
                MessageBox.Show("Province can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProvince.Clear();
                textBoxProvince.Focus();
                return;
            }

            if (!Validator.IsValidString(city))
            {
                MessageBox.Show("City can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Clear();
                textBoxCity.Focus();
                return;
            }

            if (!Validator.IsValidString(street))
            {
                MessageBox.Show("Street Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreetName.Clear();
                textBoxStreetName.Focus();
                return;
            }

            if (!Validator.IsValidString(conName))
            {
                MessageBox.Show("Contact Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactName.Clear();
                textBoxContactName.Focus();
                return;
            }

            if (!Validator.IsValidEmail(conEmail))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactEmail.Clear();
                textBoxContactEmail.Focus();
                return;
            }

            if (!Validator.IsValidPostalCode(postCode))
            {
                MessageBox.Show("Please enter a valid Postal Code (e.g A1A 1A1).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostalCode.Clear();
                textBoxPostalCode.Focus();
                return;
            }

            if (!Validator.IsValidNumber(creditLimit))
            {
                MessageBox.Show("Please enter a valid Credit Limit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCreditLimit.Clear();
                textBoxCreditLimit.Focus();
                return;
            }

            // Validate duplicate CustomerId
            DataRow drCust = dtCustomers.NewRow();
            drCust = dtCustomers.Rows.Find(Convert.ToInt32(custId));
            if (drCust != null)
            {
                MessageBox.Show("This Customer ID already exist.", "Duplicate Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            //When data is valid
            if (MessageBox.Show("Do you want to save this Customer information? ", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                string stt = comboBoxStatus.Text.Trim();
                string[] sttInfo = stt.Split('.');
                int sttId = Convert.ToInt32(sttInfo[0]);
                DataRow custSave = dtCustomers.Rows.Add(Convert.ToInt32(custId), custName, street, province, city, postCode,phoneNumber, conName, conEmail, Convert.ToInt32(creditLimit), sttId);
                da.Update(dtCustomers);
                MessageBox.Show("Customer has been saved successfully.", "Save Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Customer has NOT been saved", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxCustomerID.Clear();
            textBoxCustomerName.Clear();
            textBoxProvince.Clear();
            textBoxCity.Clear();
            textBoxStreetName.Clear();
            textBoxPostalCode.Clear();
            textBoxContactName.Clear();
            textBoxContactEmail.Clear();
            textBoxCreditLimit.Clear();
            maskedTextBoxPhoneNum.Clear();
            textBoxCustomerID.Focus();
            comboBoxStatus.SelectedIndex = -1;
        }
        // Search button
        private void buttonSearchCust_Click(object sender, EventArgs e)
        {
            textBoxCustomerName.Clear();
            textBoxProvince.Clear();
            textBoxCity.Clear();
            textBoxStreetName.Clear();
            textBoxPostalCode.Clear();
            textBoxContactName.Clear();
            textBoxContactEmail.Clear();
            textBoxCreditLimit.Clear();
            maskedTextBoxPhoneNum.Clear();
            comboBoxStatus.SelectedIndex = -1;

            string input = textBoxCustomerID.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Please input Customer ID.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            if (!Validator.IsValidId(input, 6))
            {
                MessageBox.Show("Please input a 6-digit number.", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }
            DataRow drSearch = dtCustomers.Rows.Find(Convert.ToInt32(input));
            if (drSearch != null)
            {
                textBoxCustomerID.Text = drSearch["CustomerId"].ToString();
                textBoxCustomerName.Text = drSearch["CustomerName"].ToString();
                textBoxProvince.Text = drSearch["Province"].ToString();
                textBoxCity.Text = drSearch["City"].ToString();
                textBoxStreetName.Text = drSearch["StreetName"].ToString();
                textBoxPostalCode.Text = drSearch["PostalCode"].ToString();
                textBoxContactName.Text = drSearch["ContactName"].ToString();
                textBoxContactEmail.Text = drSearch["ContactEmail"].ToString();
                textBoxCreditLimit.Text = drSearch["CreditLimit"].ToString();
                maskedTextBoxPhoneNum.Text = drSearch["PhoneNumber"].ToString();
                if (drSearch["Status"].ToString() == "5") 
                { 
                    comboBoxStatus.SelectedIndex = 0;
                }else
                {
                    if (comboBoxStatus.Items.Count == 1)
                    {
                        comboBoxStatus.Items.Add("6. Inactive");
                    }
                    comboBoxStatus.SelectedItem = "6. Inactive";
                }
            }
            else
            {
                MessageBox.Show("This Customer ID does not exist.", "Non-exist Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
            }   
        }
        // List all customers
        private void buttonSearchAll_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            List<Customer> listCust = new List<Customer>();
            listCust = cust.ListAllCustomer();
            listViewCustomer.Items.Clear();
            if (listCust.Count != 0)
            {
                foreach (var c in listCust)
                {
                    ListViewItem item = new ListViewItem(c.CustomerId.ToString());
                    item.SubItems.Add(c.CustomerName);
                    item.SubItems.Add(c.StreetName);
                    item.SubItems.Add(c.Province);
                    item.SubItems.Add(c.City);
                    item.SubItems.Add(c.PostalCode);
                    item.SubItems.Add(c.ContactName);
                    item.SubItems.Add(c.ContactEmail);
                    item.SubItems.Add(c.CreditLimit.ToString());
                    item.SubItems.Add(c.Status.ToString());
                    item.SubItems.Add(c.PhoneNumber.ToString());
                    listViewCustomer.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("There is no Customer in the database.", "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Clear All button
        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            textBoxCustomerID.Clear();
            textBoxCustomerName.Clear();
            textBoxProvince.Clear();
            textBoxCity.Clear();
            textBoxStreetName.Clear();
            textBoxPostalCode.Clear();
            textBoxContactName.Clear();
            textBoxContactEmail.Clear();
            textBoxCreditLimit.Clear();
            listViewCustomer.Items.Clear();
            maskedTextBoxPhoneNum.Clear();
            textBoxCustomerID.Focus();
            comboBoxStatus.SelectedIndex = -1;
        }
        // Update button
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string custId = textBoxCustomerID.Text.Trim();
            string custName = textBoxCustomerName.Text.Trim();
            string street = textBoxStreetName.Text.Trim();
            string province = textBoxProvince.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string postCode = textBoxPostalCode.Text.Trim();
            string phoneNumber = maskedTextBoxPhoneNum.Text.Trim();
            string conName = textBoxContactName.Text.Trim();
            string conEmail = textBoxContactEmail.Text.Trim();
            string creditLimit = textBoxCreditLimit.Text.Trim();
            // Validate empty field
            if (Validator.IsEmpty(custId))
            {
                MessageBox.Show("Customer ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }

            if (Validator.IsEmpty(custName))
            {
                MessageBox.Show("Customer Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerName.Focus();
                return;
            }

            if (Validator.IsEmpty(street))
            {
                MessageBox.Show("Street Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreetName.Focus();
                return;
            }

            if (Validator.IsEmpty(province))
            {
                MessageBox.Show("Province is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProvince.Focus();
                return;
            }

            if (Validator.IsEmpty(city))
            {
                MessageBox.Show("City is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Focus();
                return;
            }

            if (Validator.IsEmpty(postCode))
            {
                MessageBox.Show("Postal Code is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostalCode.Focus();
                return;
            }

            if (!maskedTextBoxPhoneNum.MaskCompleted)
            {
                MessageBox.Show("Please enter your phone number (e.g (514)-111-1111).", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPhoneNum.Clear();
                maskedTextBoxPhoneNum.Focus();
                return;
            }

            if (Validator.IsEmpty(conName))
            {
                MessageBox.Show("Contact Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactName.Focus();
                return;
            }

            if (Validator.IsEmpty(conEmail))
            {
                MessageBox.Show("Contact Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactEmail.Focus();
                return;
            }

            if (Validator.IsEmpty(creditLimit))
            {
                MessageBox.Show("Credit Limit is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProvince.Focus();
                return;
            }

            if (comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Status is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxStatus.Focus();
                return;
            }

            if (comboBoxStatus.SelectedIndex == 1)
            {
                MessageBox.Show("Cannot update an inactive customer.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }

            // Check Invalid Information
            if (!Validator.IsValidId(custId, 6))
            {
                MessageBox.Show("User ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            if (!Validator.IsValidString(custName))
            {
                MessageBox.Show("Customer Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerName.Clear();
                textBoxCustomerName.Focus();
                return;
            }

            if (!Validator.IsValidString(province))
            {
                MessageBox.Show("Province can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProvince.Clear();
                textBoxProvince.Focus();
                return;
            }

            if (!Validator.IsValidString(city))
            {
                MessageBox.Show("City can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Clear();
                textBoxCity.Focus();
                return;
            }

            if (!Validator.IsValidString(street))
            {
                MessageBox.Show("Street Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreetName.Clear();
                textBoxStreetName.Focus();
                return;
            }

            if (!Validator.IsValidString(conName))
            {
                MessageBox.Show("Contact Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactName.Clear();
                textBoxContactName.Focus();
                return;
            }

            if (!Validator.IsValidEmail(conEmail))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactEmail.Clear();
                textBoxContactEmail.Focus();
                return;
            }

            if (!Validator.IsValidPostalCode(postCode))
            {
                MessageBox.Show("Please enter a valid Postal Code (e.g A1A 1A1).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostalCode.Clear();
                textBoxPostalCode.Focus();
                return;
            }

            if (!Validator.IsValidNumber(creditLimit))
            {
                MessageBox.Show("Please enter a valid Credit Limit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCreditLimit.Clear();
                textBoxCreditLimit.Focus();
                return;
            }

            // Validate duplicate CustomerId
            DataRow drCust = dtCustomers.NewRow();
            drCust = dtCustomers.Rows.Find(Convert.ToInt32(custId));
            if (drCust == null)
            {
                MessageBox.Show("This Customer ID does not exist.", "Non-exist Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }else if (Convert.ToInt32(drCust["Status"]) == 6)
            {
                MessageBox.Show("This Customer is inactive.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerName.Clear();
                textBoxProvince.Clear();
                textBoxCity.Clear();
                textBoxStreetName.Clear();
                textBoxPostalCode.Clear();
                textBoxContactName.Clear();
                textBoxContactEmail.Clear();
                textBoxCreditLimit.Clear();
                maskedTextBoxPhoneNum.Clear();
                comboBoxStatus.SelectedIndex = -1;
                textBoxCustomerID.Focus();
                return;
            }

            //When data is valid
            if (MessageBox.Show("Do you want to update this Customer information? ", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                string stt = comboBoxStatus.Text.Trim();
                string[] sttInfo = stt.Split('.');
                int sttId = Convert.ToInt32(sttInfo[0]);
                drCust["CustomerName"] = custName;
                drCust["Province"] = province;
                drCust["City"] = city;
                drCust["StreetName"] = street;
                drCust["PostalCode"] = postCode;
                drCust["PhoneNumber"] = phoneNumber;
                drCust["ContactName"] = conName;
                drCust["ContactEmail"] = conEmail;
                drCust["CreditLimit"] = Convert.ToInt32(creditLimit);
                drCust["Status"] = sttId;
                da.Update(dtCustomers);
                MessageBox.Show("Customer has been updated successfully.", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Customer information has NOT been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxCustomerID.Clear();
            textBoxCustomerName.Clear();
            textBoxProvince.Clear();
            textBoxCity.Clear();
            textBoxStreetName.Clear();
            textBoxPostalCode.Clear();
            textBoxContactName.Clear();
            textBoxContactEmail.Clear();
            textBoxCreditLimit.Clear();
            maskedTextBoxPhoneNum.Clear();
            comboBoxStatus.SelectedIndex = -1;
            textBoxCustomerID.Focus();
        }
        // Delete button
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string custId = textBoxCustomerID.Text.Trim();
            string custName = textBoxCustomerName.Text.Trim();
            string street = textBoxStreetName.Text.Trim();
            string province = textBoxProvince.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string postCode = textBoxPostalCode.Text.Trim();
            string phoneNumber = maskedTextBoxPhoneNum.Text.Trim();
            string conName = textBoxContactName.Text.Trim();
            string conEmail = textBoxContactEmail.Text.Trim();
            string creditLimit = textBoxCreditLimit.Text.Trim();
            // Validate empty field
            if (Validator.IsEmpty(custId))
            {
                MessageBox.Show("Customer ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }

            if (Validator.IsEmpty(custName))
            {
                MessageBox.Show("Customer Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerName.Focus();
                return;
            }

            if (Validator.IsEmpty(street))
            {
                MessageBox.Show("Street Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreetName.Focus();
                return;
            }

            if (Validator.IsEmpty(province))
            {
                MessageBox.Show("Province is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProvince.Focus();
                return;
            }

            if (Validator.IsEmpty(city))
            {
                MessageBox.Show("City is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Focus();
                return;
            }

            if (Validator.IsEmpty(postCode))
            {
                MessageBox.Show("Postal Code is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostalCode.Focus();
                return;
            }

            if (!maskedTextBoxPhoneNum.MaskCompleted)
            {
                MessageBox.Show("Please enter your phone number (e.g (514)-111-1111).", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPhoneNum.Clear();
                maskedTextBoxPhoneNum.Focus();
                return;
            }

            if (Validator.IsEmpty(conName))
            {
                MessageBox.Show("Contact Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactName.Focus();
                return;
            }

            if (Validator.IsEmpty(conEmail))
            {
                MessageBox.Show("Contact Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactEmail.Focus();
                return;
            }

            if (Validator.IsEmpty(creditLimit))
            {
                MessageBox.Show("Credit Limit is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProvince.Focus();
                return;
            }

            if (comboBoxStatus.SelectedIndex == 1)
            {
                MessageBox.Show("This customer is already inactivated.", "Inactivate Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }

            // Validate Invalid Information
            if (!Validator.IsValidId(custId, 6))
            {
                MessageBox.Show("User ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            if (!Validator.IsValidString(custName))
            {
                MessageBox.Show("Customer Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerName.Clear();
                textBoxCustomerName.Focus();
                return;
            }

            if (!Validator.IsValidString(province))
            {
                MessageBox.Show("Province can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProvince.Clear();
                textBoxProvince.Focus();
                return;
            }

            if (!Validator.IsValidString(city))
            {
                MessageBox.Show("City can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Clear();
                textBoxCity.Focus();
                return;
            }

            if (!Validator.IsValidString(street))
            {
                MessageBox.Show("Street Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreetName.Clear();
                textBoxStreetName.Focus();
                return;
            }

            if (!Validator.IsValidString(conName))
            {
                MessageBox.Show("Contact Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactName.Clear();
                textBoxContactName.Focus();
                return;
            }

            if (!Validator.IsValidEmail(conEmail))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactEmail.Clear();
                textBoxContactEmail.Focus();
                return;
            }

            if (!Validator.IsValidPostalCode(postCode))
            {
                MessageBox.Show("Please enter a valid Postal Code (e.g A1A 1A1).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostalCode.Clear();
                textBoxPostalCode.Focus();
                return;
            }

            if (!Validator.IsValidNumber(creditLimit))
            {
                MessageBox.Show("Please enter a valid Credit Limit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCreditLimit.Clear();
                textBoxCreditLimit.Focus();
                return;
            }

            // Validate duplicate CustomerId
            DataRow drCust = dtCustomers.NewRow();
            drCust = dtCustomers.Rows.Find(Convert.ToInt32(custId));
            if (drCust == null)
            {
                MessageBox.Show("This Customer ID does not exist.", "Non-exist Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }
            else if (Convert.ToInt32(drCust["Status"]) == 6)
            {
                MessageBox.Show("This customer is inactive.", "Inactivate Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerName.Clear();
                textBoxProvince.Clear();
                textBoxCity.Clear();
                textBoxStreetName.Clear();
                textBoxPostalCode.Clear();
                textBoxContactName.Clear();
                textBoxContactEmail.Clear();
                textBoxCreditLimit.Clear();
                maskedTextBoxPhoneNum.Clear();
                comboBoxStatus.SelectedIndex = -1;
                textBoxCustomerID.Focus();
                return;
            }

            //When data is valid
            IEnumerable<DataRow> rowOrders = dtOrders.AsEnumerable().Where(r => r.Field<int>("CustomerId") == Convert.ToInt32(custId));
            DataRow[] orderRows = rowOrders.ToArray();
            if (orderRows.Length != 0)
            {
                if (MessageBox.Show("This customer may have some orders that are in progress or pending. Inactivate this customer will also cancel these orders.\nDo you really want to continue?", "Inactivate Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    DataRow dr;
                    foreach (DataRow row in orderRows)
                    {
                        dr = dtOrders.NewRow();
                        dr = dtOrders.Rows.Find(row["OrderId"]);
                        if (Convert.ToInt32(dr["OrderStatus"]) == 1 || Convert.ToInt32(dr["OrderStatus"]) == 2)
                        {
                            dr["OrderStatus"] = 7;
                            da1.Update(dtOrders);
                        }
                    }
                    DataRow drCustomer = dtCustomers.Rows.Find(Convert.ToInt32(custId));
                    drCustomer["Status"] = 6;
                    da.Update(dtCustomers);
                    MessageBox.Show("One customer was inactivated.", "Inactivate Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer has NOT been inactivated.", "Inactivate Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (MessageBox.Show("Do you really want to inactivate this customer?", "Inactivate Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    DataRow drCustomer = dtCustomers.Rows.Find(Convert.ToInt32(custId));
                    drCustomer["Status"] = 6;
                    da.Update(dtCustomers);
                    MessageBox.Show("One customer was inactivated.", "Inactivate Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer has NOT been inactivated.", "Inactivate Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            textBoxCustomerID.Clear();
            textBoxCustomerName.Clear();
            textBoxProvince.Clear();
            textBoxCity.Clear();
            textBoxStreetName.Clear();
            textBoxPostalCode.Clear();
            textBoxContactName.Clear();
            textBoxContactEmail.Clear();
            textBoxCreditLimit.Clear();
            maskedTextBoxPhoneNum.Clear();
            comboBoxStatus.SelectedIndex = -1;
            textBoxCustomerID.Focus();
        }
        //Search by Customer Name
        private void buttonSearchCustName_Click(object sender, EventArgs e)
        {
            textBoxCustomerID.Clear();
            textBoxProvince.Clear();
            textBoxCity.Clear();
            textBoxStreetName.Clear();
            textBoxPostalCode.Clear();
            textBoxContactName.Clear();
            textBoxContactEmail.Clear();
            textBoxCreditLimit.Clear();
            maskedTextBoxPhoneNum.Clear();
            comboBoxStatus.SelectedIndex = -1;
            listViewCustomer.Items.Clear();

            string input = textBoxCustomerName.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Please input Customer Name.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerName.Clear();
                textBoxCustomerName.Focus();
                return;
            }

            if (!Validator.IsValidString(input))
            {
                MessageBox.Show("Customer Name only containt characters or space(s).", "Invalid Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerName.Clear();
                textBoxCustomerName.Focus();
                return;
            }

            string expression;
            expression = "CustomerName = '" + input + "'";
            DataRow[] foundRows;

            // Use the Select method to find all rows matching the filter.
            foundRows = dtCustomers.Select(expression);

            if (foundRows.Length != 0)
            {
                for (int i = 0; i < foundRows.Length; i++)
                {
                    ListViewItem item = new ListViewItem(foundRows[i][0].ToString());
                    item.SubItems.Add(foundRows[i][1].ToString());
                    item.SubItems.Add(foundRows[i][2].ToString());
                    item.SubItems.Add(foundRows[i][3].ToString());
                    item.SubItems.Add(foundRows[i][4].ToString());
                    item.SubItems.Add(foundRows[i][5].ToString());
                    item.SubItems.Add(foundRows[i][7].ToString());
                    item.SubItems.Add(foundRows[i][8].ToString());
                    item.SubItems.Add(foundRows[i][9].ToString());
                    item.SubItems.Add(foundRows[i][10].ToString());
                    item.SubItems.Add(foundRows[i][6].ToString());
                    listViewCustomer.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Customer Name does not exist.", "Non-exist Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxCustomerName.Clear();
        }
        private void comboBoxStatus_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBoxStatus.Items.Count >= 2)
            {
                comboBoxStatus.Items.Remove("6. Inactive");
            }
        }
    }
}
