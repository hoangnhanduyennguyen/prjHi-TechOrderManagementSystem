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
using Hi_Tech_Order_Management_System.HiTechModel;

namespace Hi_Tech_Order_Management_System.GUI
{
    public partial class FormOrder : Form
    {
        HiTechDatabaseEntities dBEntities = new HiTechDatabaseEntities();
        int employeeId;
        public FormOrder(int uId)
        {
            InitializeComponent();
            employeeId = uId;
        }
        //Exit button
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

        private void FormOrder_Load(object sender, EventArgs e)
        {
            Status status = new Status();
            var listStatus = (from stt in dBEntities.Statuses
                                  where stt.Id == 1 || stt.Id == 2 || stt.Id == 3 || stt.Id == 4
                              select stt).ToList<Status>();
            foreach (var item in listStatus)
            {
                comboBoxOrderStatus.Items.Add(item.Id + ". " + item.Description);
            }
            string[] orderTypes = { "By Phone", "By Email" };
            foreach (var item in orderTypes)
            {
                comboBoxOrderType.Items.Add(item);
            }
        }
        // Save button
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string iSBN = textBoxISBN.Text.Trim();
            string quantityOrdered = textBoxQuantity.Text.Trim();
            string customerId = textBoxCustomerID.Text.Trim();
            string orderDate = maskedTextBoxOrderDate.Text;
            string requiredDate = maskedTextBoxRequiredDate.Text;
            string shippingDate = maskedTextBoxShippingDate.Text;


            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("ISBN is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(quantityOrdered))
            {
                MessageBox.Show("Quantity Ordered is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQuantity.Focus();
                return;
            }

            if (Validator.IsEmpty(customerId))
            {
                MessageBox.Show("Customer ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }

            if (!maskedTextBoxOrderDate.MaskCompleted)
            {
                MessageBox.Show("Order Date is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxOrderDate.Focus();
                return;
            }

            if (!maskedTextBoxRequiredDate.MaskCompleted)
            {
                MessageBox.Show("Required Date is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxRequiredDate.Focus();
                return;
            }

            if (!maskedTextBoxShippingDate.MaskCompleted)
            {
                MessageBox.Show("Shipping Date is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxShippingDate.Focus();
                return;
            }

            if (comboBoxOrderStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose an order status.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxOrderStatus.Focus();
                return;
            }

            if (comboBoxOrderType.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose an order type.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxOrderType.Focus();
                return;
            }

            if (!Validator.IsValidId(iSBN, 13))
            {
                MessageBox.Show("ISBN is a 13-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            if (!Validator.IsValidId(customerId, 6))
            {
                MessageBox.Show("Customer ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            if (!Validator.IsValidDate(orderDate))
            {
                MessageBox.Show("Please enter an valid order date (MM/DD/YYYY)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxOrderDate.Focus();
                return;
            }
            if (!Validator.IsValidDate(requiredDate))
            {
                MessageBox.Show("Please enter an valid required date (MM/DD/YYYY)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                maskedTextBoxRequiredDate.Clear();
                maskedTextBoxRequiredDate.Focus();
                return;
            }
            if (!Validator.IsValidDate(shippingDate))
            {
                MessageBox.Show("Please enter an valid shipping date (MM/DD/YYYY)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxShippingDate.Focus();
                return;
            }

            int qo;
            try
            {
                qo = Convert.ToInt32(quantityOrdered);
            }
            catch (Exception)
            {
                MessageBox.Show("Quantity order is a number.", "Invalid Quantity Ordered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQuantity.Clear();
                textBoxQuantity.Focus();
                return;
            }

            DateTime od = Convert.ToDateTime(orderDate);
            DateTime sd = Convert.ToDateTime(shippingDate);
            DateTime rd = Convert.ToDateTime(requiredDate);
            if (sd < od)
            {
                MessageBox.Show("Shipping date has to be further than Order date", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxOrderDate.Focus();
                return;
            }
            if (rd < od)
            {
                MessageBox.Show("Required date has to be further than Order date", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                maskedTextBoxOrderDate.Focus();
                return;
            }
            if (rd < sd)
            {
                MessageBox.Show("Required date has to be further than Shipping date", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxRequiredDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Focus();
                return;
            }

            // Generate orderId automatically
            int orderIdMax =  (from o in dBEntities.Orders
                              select o).Max(o => o.OrderId);
            
            Book book = new Book();
            book = dBEntities.Books.Find(iSBN);
            if (book == null)
            {
                MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }else if (book.Status == 9)
            {
                MessageBox.Show("This Book is out of stock.", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            Customer cust = new Customer();
            cust = dBEntities.Customers.Find(Convert.ToInt32(customerId));
            if (cust == null)
            {
                MessageBox.Show("This Customer ID does not exist.", "Non-exist Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            } else if (cust.Status == 6)
            {
                MessageBox.Show("This Customer is inactive.", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            if (book.QOH == 0)
            {
                MessageBox.Show("This book will be available soon.", "Insufficient Quantity On Hand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                return;
            }
            else if (qo > book.QOH)
            {
                if(MessageBox.Show("The on hand quantity is insufficient for the order. \n Do you want to order " + book.QOH + " books?", "Insufficient Quantity On Hand", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    textBoxQuantity.Text = book.QOH.ToString();
                    qo = book.QOH;
                    book.QOH = 0;
                    book.Status = 9;
                    string stt = comboBoxOrderStatus.Text.Trim();
                    string[] sttInfo = stt.Split('.');
                    int sttId = Convert.ToInt32(sttInfo[0]);
                    Order orderSave = new Order();
                    orderSave.OrderId = orderIdMax + 1;
                    orderSave.OrderDate = od;
                    orderSave.OrderType = comboBoxOrderType.Text.Trim();
                    orderSave.OrderStatus = sttId;
                    orderSave.ShippingDate = sd;
                    orderSave.RequiredDate = rd;
                    orderSave.EmployeeId = employeeId;
                    orderSave.CustomerId = Convert.ToInt32(customerId);
                    dBEntities.Orders.Add(orderSave);

                    OrderLine orderLine = new OrderLine();
                    orderLine.OrderId = orderIdMax + 1;
                    orderLine.ISBN = iSBN;
                    orderLine.QuantityOrdered = qo;
                    dBEntities.OrderLines.Add(orderLine);
                    dBEntities.SaveChanges();
                    MessageBox.Show("Order is saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Order has not been saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                return;
            }

            if (MessageBox.Show("Do you want to create this Order?", "Create Order Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                book.QOH = book.QOH - qo;
                string stt = comboBoxOrderStatus.Text.Trim();
                string[] sttInfo = stt.Split('.');
                int sttId = Convert.ToInt32(sttInfo[0]);
                Order orderSave = new Order();
                orderSave.OrderId = orderIdMax + 1;
                orderSave.OrderDate = od;
                orderSave.OrderType = comboBoxOrderType.Text.Trim();
                orderSave.OrderStatus = sttId;
                orderSave.ShippingDate = sd;
                orderSave.RequiredDate = rd;
                orderSave.EmployeeId = employeeId;
                orderSave.CustomerId = Convert.ToInt32(customerId);
                dBEntities.Orders.Add(orderSave);

                OrderLine orderLine = new OrderLine();
                orderLine.OrderId = orderIdMax + 1;
                orderLine.ISBN = iSBN;
                orderLine.QuantityOrdered = qo;
                dBEntities.OrderLines.Add(orderLine);
                dBEntities.SaveChanges();
                MessageBox.Show("Order is saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Order has not been saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxOrderId.Clear();
            textBoxISBN.Clear();
            textBoxQuantity.Clear();
            maskedTextBoxOrderDate.Clear();
            maskedTextBoxShippingDate.Clear();
            maskedTextBoxRequiredDate.Clear();
            comboBoxOrderStatus.SelectedIndex = -1;
            comboBoxOrderType.SelectedIndex = -1;
            textBoxCustomerID.Clear();
        }
        // Update button
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string orderId = textBoxOrderId.Text.Trim();
            string iSBN = textBoxISBN.Text.Trim();
            string quantityOrdered = textBoxQuantity.Text.Trim();
            string customerId = textBoxCustomerID.Text.Trim();
            string orderDate = maskedTextBoxOrderDate.Text;
            string requiredDate = maskedTextBoxRequiredDate.Text;
            string shippingDate = maskedTextBoxShippingDate.Text;

            // Validate data
            if (Validator.IsEmpty(orderId))
            {
                MessageBox.Show("Order ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Focus();
                return;
            }

            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("ISBN is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(quantityOrdered))
            {
                MessageBox.Show("Quantity Ordered is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQuantity.Focus();
                return;
            }

            if (Validator.IsEmpty(customerId))
            {
                MessageBox.Show("Customer ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }

            if (!maskedTextBoxOrderDate.MaskCompleted)
            {
                MessageBox.Show("Order Date is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxOrderDate.Focus();
                return;
            }

            if (!maskedTextBoxRequiredDate.MaskCompleted)
            {
                MessageBox.Show("Required Date is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxRequiredDate.Focus();
                return;
            }

            if (!maskedTextBoxShippingDate.MaskCompleted)
            {
                MessageBox.Show("Shipping Date is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxShippingDate.Focus();
                return;
            }

            if (comboBoxOrderStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose an order status.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxOrderStatus.Focus();
                return;
            }

            if (comboBoxOrderType.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose an order type.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxOrderType.Focus();
                return;
            }

            // Check Invalid Information
            if (!Validator.IsValidId(orderId, 7))
            {
                MessageBox.Show("Order ID is a 7-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }

            if (!Validator.IsValidId(iSBN, 13))
            {
                MessageBox.Show("ISBN is a 13-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            if (!Validator.IsValidId(customerId, 6))
            {
                MessageBox.Show("Customer ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            if (!Validator.IsValidDate(orderDate))
            {
                MessageBox.Show("Please enter an valid order date (MM/DD/YYYY)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxOrderDate.Focus();
                return;
            }
            if (!Validator.IsValidDate(requiredDate))
            {
                MessageBox.Show("Please enter an valid required date (MM/DD/YYYY)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                maskedTextBoxRequiredDate.Clear();
                maskedTextBoxRequiredDate.Focus();
                return;
            }
            if (!Validator.IsValidDate(shippingDate))
            {
                MessageBox.Show("Please enter an valid shipping date (MM/DD/YYYY)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxShippingDate.Focus();
                return;
            }

            int qo;
            try
            {
                qo = Convert.ToInt32(quantityOrdered);
            }
            catch (Exception)
            {
                MessageBox.Show("Quantity order is a number.", "Invalid Quantity Ordered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQuantity.Clear();
                textBoxQuantity.Focus();
                return;
            }

            DateTime od = Convert.ToDateTime(orderDate);
            DateTime sd = Convert.ToDateTime(shippingDate);
            DateTime rd = Convert.ToDateTime(requiredDate);
            if (sd < od)
            {
                MessageBox.Show("Shipping date has to be further than Order date", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxOrderDate.Focus();
                return;
            }
            if (rd < od)
            {
                MessageBox.Show("Required date has to be further than Order date", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                maskedTextBoxOrderDate.Focus();
                return;
            }
            if (rd < sd)
            {
                MessageBox.Show("Required date has to be further than Shipping date", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxRequiredDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Focus();
                return;
            }

            int oId = Convert.ToInt32(orderId);
            Order order = new Order();
            order = dBEntities.Orders.Find(oId);

            Customer cust = new Customer();
            cust = dBEntities.Customers.Find(Convert.ToInt32(order.CustomerId));

            if (order == null)
            {
                MessageBox.Show("This Order ID does not exist.", "Non-exist Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                textBoxOrderId.Focus();
                return;
            }
            else if (order.OrderStatus == 7 || order.OrderStatus == 3 || order.OrderStatus == 4)
            {
                MessageBox.Show("Cannot update order that was canceled/shipped/completed.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxOrderId.Focus();
                return;
            }
            else if (cust.Status == 6)
            {
                MessageBox.Show("This Customer is inactive.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxOrderId.Focus();
                return;
            }

            Book book = new Book();
            book = dBEntities.Books.Find(iSBN);
            if (book == null)
            {
                MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxISBN.Focus();
                return;
            }
            else if (book.Status == 9)
            {
                MessageBox.Show("This Book is out of stock.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                textBoxISBN.Focus();
                return;
            }

            var oL = dBEntities.OrderLines.Where(ol => ol.OrderId == oId && ol.ISBN == iSBN).FirstOrDefault();
            if (oL == null)
            {
                MessageBox.Show("Order Line does not exist.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxOrderId.Focus();
                return;
            }

            string stt = comboBoxOrderStatus.Text.Trim();
            string[] sttInfo = stt.Split('.');
            int sttId = Convert.ToInt32(sttInfo[0]);

            if (oL.QuantityOrdered != qo)
            {
                if (qo > oL.QuantityOrdered)
                {
                    if (book.QOH == 0)
                    {
                        MessageBox.Show("Cannot increase quantity ordered at the moment.", "Insufficient Quantity On Hand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxOrderId.Clear();
                        textBoxISBN.Clear();
                        textBoxQuantity.Clear();
                        maskedTextBoxOrderDate.Clear();
                        maskedTextBoxShippingDate.Clear();
                        maskedTextBoxRequiredDate.Clear();
                        comboBoxOrderStatus.SelectedIndex = -1;
                        comboBoxOrderType.SelectedIndex = -1;
                        textBoxCustomerID.Clear();
                        return;
                    }
                    else if (qo - oL.QuantityOrdered > book.QOH)
                    {
                        int temp = oL.QuantityOrdered + book.QOH;
                        if (MessageBox.Show("The quantity on hand is insufficient for updating. \n Do you want to update quantity ordered to " + temp.ToString() + " books?", "Insufficient Quantity On Hand", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                        {
                            textBoxQuantity.Text = temp.ToString();
                            qo = temp;
                            book.QOH = 0;
                            book.Status = 9;
                            order.OrderDate = od;
                            order.OrderType = comboBoxOrderType.Text.Trim();
                            order.OrderStatus = sttId;
                            order.ShippingDate = sd;
                            order.RequiredDate = rd;
                            order.EmployeeId = employeeId;
                            order.CustomerId = Convert.ToInt32(customerId);
                            oL.QuantityOrdered = qo;
                            dBEntities.SaveChanges();
                            MessageBox.Show("Updated successfully.", "Update Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Order has not been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        textBoxOrderId.Clear();
                        textBoxISBN.Clear();
                        textBoxQuantity.Clear();
                        maskedTextBoxOrderDate.Clear();
                        maskedTextBoxShippingDate.Clear();
                        maskedTextBoxRequiredDate.Clear();
                        comboBoxOrderStatus.SelectedIndex = -1;
                        comboBoxOrderType.SelectedIndex = -1;
                        textBoxCustomerID.Clear();
                        return;
                    }
                    else if(qo - oL.QuantityOrdered < book.QOH)
                    {
                        if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                        {
                            book.QOH = book.QOH - (qo - oL.QuantityOrdered);
                            order.OrderDate = od;
                            order.OrderType = comboBoxOrderType.Text.Trim();
                            order.OrderStatus = sttId;
                            order.ShippingDate = sd;
                            order.RequiredDate = rd;
                            order.EmployeeId = employeeId;
                            order.CustomerId = Convert.ToInt32(customerId);
                            oL.QuantityOrdered = qo;
                            dBEntities.SaveChanges();
                            MessageBox.Show("Updated successfully.", "Update Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Order has not been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        textBoxOrderId.Clear();
                        textBoxISBN.Clear();
                        textBoxQuantity.Clear();
                        maskedTextBoxOrderDate.Clear();
                        maskedTextBoxShippingDate.Clear();
                        maskedTextBoxRequiredDate.Clear();
                        comboBoxOrderStatus.SelectedIndex = -1;
                        comboBoxOrderType.SelectedIndex = -1;
                        textBoxCustomerID.Clear();
                        return;
                    }
                }else
                {
                    if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                    {
                        book.QOH = book.QOH + (oL.QuantityOrdered - qo);
                        order.OrderDate = od;
                        order.OrderType = comboBoxOrderType.Text.Trim();
                        order.OrderStatus = sttId;
                        order.ShippingDate = sd;
                        order.RequiredDate = rd;
                        order.EmployeeId = employeeId;
                        order.CustomerId = Convert.ToInt32(customerId);
                        oL.QuantityOrdered = qo;
                        dBEntities.SaveChanges();
                        MessageBox.Show("Updated successfully.", "Update Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxOrderId.Clear();
                        textBoxISBN.Clear();
                        textBoxQuantity.Clear();
                        maskedTextBoxOrderDate.Clear();
                        maskedTextBoxShippingDate.Clear();
                        maskedTextBoxRequiredDate.Clear();
                        comboBoxOrderStatus.SelectedIndex = -1;
                        comboBoxOrderType.SelectedIndex = -1;
                        textBoxCustomerID.Clear();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Order has not been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    textBoxOrderId.Clear();
                    textBoxISBN.Clear();
                    textBoxQuantity.Clear();
                    maskedTextBoxOrderDate.Clear();
                    maskedTextBoxShippingDate.Clear();
                    maskedTextBoxRequiredDate.Clear();
                    comboBoxOrderStatus.SelectedIndex = -1;
                    comboBoxOrderType.SelectedIndex = -1;
                    textBoxCustomerID.Clear();
                    return;
                }
            }
            if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                order.OrderDate = od;
                order.OrderType = comboBoxOrderType.Text.Trim();
                order.OrderStatus = sttId;
                order.ShippingDate = sd;
                order.RequiredDate = rd;
                order.EmployeeId = employeeId;
                order.CustomerId = Convert.ToInt32(customerId);
                oL.QuantityOrdered = qo;
                dBEntities.SaveChanges();
                MessageBox.Show("Updated successfully.", "Update Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Order has not been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxOrderId.Clear();
            textBoxISBN.Clear();
            textBoxQuantity.Clear();
            maskedTextBoxOrderDate.Clear();
            maskedTextBoxShippingDate.Clear();
            maskedTextBoxRequiredDate.Clear();
            comboBoxOrderStatus.SelectedIndex = -1;
            comboBoxOrderType.SelectedIndex = -1;
            textBoxCustomerID.Clear();
        }
        //Cancel button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Validate data input
            // Get all inputs
            string orderId = textBoxOrderId.Text.Trim();
            string iSBN = textBoxISBN.Text.Trim();
            string quantityOrdered = textBoxQuantity.Text.Trim();
            string customerId = textBoxCustomerID.Text.Trim();
            string orderDate = maskedTextBoxOrderDate.Text;
            string requiredDate = maskedTextBoxRequiredDate.Text;
            string shippingDate = maskedTextBoxShippingDate.Text;

            // Check empty field
            if (Validator.IsEmpty(orderId))
            {
                MessageBox.Show("Order ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Focus();
                return;
            }

            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("ISBN is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(quantityOrdered))
            {
                MessageBox.Show("Quantity Ordered is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQuantity.Focus();
                return;
            }

            if (Validator.IsEmpty(customerId))
            {
                MessageBox.Show("Customer ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }

            if (!maskedTextBoxOrderDate.MaskCompleted)
            {
                MessageBox.Show("Order Date is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxOrderDate.Focus();
                return;
            }

            if (!maskedTextBoxRequiredDate.MaskCompleted)
            {
                MessageBox.Show("Required Date is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxRequiredDate.Focus();
                return;
            }

            if (!maskedTextBoxShippingDate.MaskCompleted)
            {
                MessageBox.Show("Shipping Date is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxShippingDate.Focus();
                return;
            }

            if (comboBoxOrderStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose an order status.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxOrderStatus.Focus();
                return;
            }

            if (comboBoxOrderType.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose an order type.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxOrderType.Focus();
                return;
            }

            // Check Invalid Information
            if (!Validator.IsValidId(orderId, 7))
            {
                MessageBox.Show("Order ID is a 7-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }

            if (!Validator.IsValidId(iSBN, 13))
            {
                MessageBox.Show("ISBN is a 13-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            if (!Validator.IsValidId(customerId, 6))
            {
                MessageBox.Show("Customer ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            if (!Validator.IsValidDate(orderDate))
            {
                MessageBox.Show("Please enter an valid order date (MM/DD/YYYY)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxOrderDate.Focus();
                return;
            }
            if (!Validator.IsValidDate(requiredDate))
            {
                MessageBox.Show("Please enter an valid required date (MM/DD/YYYY)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                maskedTextBoxRequiredDate.Clear();
                maskedTextBoxRequiredDate.Focus();
                return;
            }
            if (!Validator.IsValidDate(shippingDate))
            {
                MessageBox.Show("Please enter an valid shipping date (MM/DD/YYYY)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxShippingDate.Focus();
                return;
            }

            int qo;
            try
            {
                qo = Convert.ToInt32(quantityOrdered);
            }
            catch (Exception)
            {
                MessageBox.Show("Quantity order is a number.", "Invalid Quantity Ordered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQuantity.Clear();
                textBoxQuantity.Focus();
                return;
            }

            DateTime od = Convert.ToDateTime(orderDate);
            DateTime sd = Convert.ToDateTime(shippingDate);
            DateTime rd = Convert.ToDateTime(requiredDate);
            if (sd < od)
            {
                MessageBox.Show("Shipping date has to be further than Order date", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxOrderDate.Focus();
                return;
            }
            if (rd < od)
            {
                MessageBox.Show("Required date has to be further than Order date", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                maskedTextBoxOrderDate.Focus();
                return;
            }
            if (rd < sd)
            {
                MessageBox.Show("Required date has to be further than Shipping date", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxRequiredDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Focus();
                return;
            }

            //Duplicate OrderId
            Order order = new Order();
            order = dBEntities.Orders.Find(Convert.ToInt32(orderId));
            if (order == null)
            {
                MessageBox.Show("This Order ID does not exist.", "Non-exist Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }else if (order.OrderStatus == 7)
            {
                MessageBox.Show("This Order was already cancelled.", "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                return;
            }
            else if(order.OrderStatus == 3 || order.OrderStatus == 4)
            {
                MessageBox.Show("Cannot cancel an order that was completed/shipped.", "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                return;
            }

            Book book = new Book();
            book = dBEntities.Books.Find(iSBN);
            if (book == null)
            {
                MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            Customer cust = new Customer();
            cust = dBEntities.Customers.Find(Convert.ToInt32(customerId));
            if (cust == null)
            {
                MessageBox.Show("This Customer ID does not exist.", "Non-exist Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            // When data is valid
            if (MessageBox.Show("Do you want to cancel this Order?", "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                order.OrderStatus = 7;
                int oId = Convert.ToInt32(orderId);
                var oL = dBEntities.OrderLines.Where(ol => ol.OrderId == oId  && ol.ISBN == iSBN).FirstOrDefault();
                book.QOH += oL.QuantityOrdered;
                dBEntities.SaveChanges();
                MessageBox.Show("Order is cancelled successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Order has not been cancelled", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxOrderId.Clear();
            textBoxISBN.Clear();
            textBoxQuantity.Clear();
            maskedTextBoxOrderDate.Clear();
            maskedTextBoxShippingDate.Clear();
            maskedTextBoxRequiredDate.Clear();
            comboBoxOrderStatus.SelectedIndex = -1;
            comboBoxOrderType.SelectedIndex = -1;
            textBoxCustomerID.Clear();
        }
        //Clear all button
        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            textBoxOrderId.Clear();
            textBoxISBN.Clear();
            textBoxQuantity.Clear();
            maskedTextBoxOrderDate.Clear();
            maskedTextBoxShippingDate.Clear();
            maskedTextBoxRequiredDate.Clear();
            comboBoxOrderStatus.SelectedIndex = -1;
            comboBoxOrderType.SelectedIndex = -1;
            textBoxCustomerID.Clear();
            listViewOrder.Items.Clear();
            textBoxInput.Clear();
        }
        // Search for order
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();
            string input = textBoxInput.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Please enter your input to search.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxInput.Focus();
                return;
            }

            int select = comboBoxSearch.SelectedIndex;

            switch (select)
            {
                case -1:
                    MessageBox.Show("Please choose a field to search.", "Empty Search Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxSearch.Focus();
                    break;
                case 0:
                    if (!Validator.IsValidId(input, 7))
                    {
                        MessageBox.Show("Order ID is a 7-digit number.", "Invalid Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }
                    int ordId = Convert.ToInt32(input);
                    
                    var listOrders = (from od in dBEntities.Orders
                                      where od.OrderId == ordId
                                      select od).ToList<Order>();

                    if (listOrders.Count != 0)
                    {
                        foreach (Order order in listOrders)
                        {
                            var listOrderLines = (from ol in dBEntities.OrderLines
                                                  where ol.OrderId == order.OrderId
                                                  select ol).ToList<OrderLine>();
                            foreach (OrderLine orderLine in listOrderLines)
                            {
                                ListViewItem item = new ListViewItem(order.OrderId.ToString());
                                item.SubItems.Add(orderLine.ISBN);
                                item.SubItems.Add(orderLine.QuantityOrdered.ToString());
                                item.SubItems.Add(order.OrderDate.Date.ToShortDateString());
                                item.SubItems.Add(order.RequiredDate.Date.ToShortDateString());
                                item.SubItems.Add(order.ShippingDate.Date.ToShortDateString());
                                item.SubItems.Add(order.OrderStatus.ToString());
                                item.SubItems.Add(order.OrderType.ToString());
                                item.SubItems.Add(order.CustomerId.ToString());
                                item.SubItems.Add(order.EmployeeId.ToString());
                                listViewOrder.Items.Add(item);
                            }
                        }
                        textBoxInput.Clear();
                        comboBoxSearch.SelectedIndex = -1;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No Order found.", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 1:
                    if (!Validator.IsValidId(input, 13))
                    {
                        MessageBox.Show("ISBN is a 13-digit number.", "Invalid ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }

                    var listOrderLines1 = (from ol in dBEntities.OrderLines
                                      where ol.ISBN == input
                                      select ol).ToList<OrderLine>();

                    if (listOrderLines1.Count != 0)
                    {
                        foreach (OrderLine orderLine in listOrderLines1)
                        {
                            var listOrders1 = (from od in dBEntities.Orders
                                                  where od.OrderId == orderLine.OrderId
                                                  select od).ToList<Order>();
                            foreach (Order order in listOrders1)
                            {
                                ListViewItem item = new ListViewItem(order.OrderId.ToString());
                                item.SubItems.Add(orderLine.ISBN);
                                item.SubItems.Add(orderLine.QuantityOrdered.ToString());
                                item.SubItems.Add(order.OrderDate.Date.ToShortDateString());
                                item.SubItems.Add(order.RequiredDate.Date.ToShortDateString());
                                item.SubItems.Add(order.ShippingDate.Date.ToShortDateString());
                                item.SubItems.Add(order.OrderStatus.ToString());
                                item.SubItems.Add(order.OrderType.ToString());
                                item.SubItems.Add(order.CustomerId.ToString());
                                item.SubItems.Add(order.EmployeeId.ToString());
                                listViewOrder.Items.Add(item);
                            }
                        }
                        textBoxInput.Clear();
                        comboBoxSearch.SelectedIndex = -1;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No Order found.", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2:
                    if (!Validator.IsValidId(input, 6))
                    {
                        MessageBox.Show("Customer ID is a 6-digit number.", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }
                    int custId = Convert.ToInt32(input);

                    var listOrders2 = (from od in dBEntities.Orders
                                      where od.CustomerId == custId
                                      select od).ToList<Order>();

                    if (listOrders2.Count != 0)
                    {
                        foreach (Order order in listOrders2)
                        {
                            var listOrderLines2 = (from ol in dBEntities.OrderLines
                                                  where ol.OrderId == order.OrderId
                                                  select ol).ToList<OrderLine>();
                            foreach (OrderLine orderLine in listOrderLines2)
                            {
                                ListViewItem item = new ListViewItem(order.OrderId.ToString());
                                item.SubItems.Add(orderLine.ISBN);
                                item.SubItems.Add(orderLine.QuantityOrdered.ToString());
                                item.SubItems.Add(order.OrderDate.Date.ToShortDateString());
                                item.SubItems.Add(order.RequiredDate.Date.ToShortDateString());
                                item.SubItems.Add(order.ShippingDate.Date.ToShortDateString());
                                item.SubItems.Add(order.OrderStatus.ToString());
                                item.SubItems.Add(order.OrderType.ToString());
                                item.SubItems.Add(order.CustomerId.ToString());
                                item.SubItems.Add(order.EmployeeId.ToString());
                                listViewOrder.Items.Add(item);
                            }
                        }
                        textBoxInput.Clear();
                        comboBoxSearch.SelectedIndex = -1;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No Order found.", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
            textBoxInput.Clear();
            comboBoxSearch.SelectedIndex = -1;
        }
        // List all orders
        private void buttonListAll_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();
            var listOrders = (from od in dBEntities.Orders
                              select od).ToList<Order>();

            if (listOrders.Count != 0)
            {
                foreach (Order order in listOrders)
                {
                    var listOrderLines = (from ol in dBEntities.OrderLines
                                          where ol.OrderId == order.OrderId
                                          select ol).ToList<OrderLine>();
                    foreach (OrderLine orderLine in listOrderLines)
                    {
                        ListViewItem item = new ListViewItem(order.OrderId.ToString());
                        item.SubItems.Add(orderLine.ISBN);
                        item.SubItems.Add(orderLine.QuantityOrdered.ToString());
                        item.SubItems.Add(order.OrderDate.Date.ToShortDateString());
                        item.SubItems.Add(order.RequiredDate.Date.ToShortDateString());
                        item.SubItems.Add(order.ShippingDate.Date.ToShortDateString());
                        item.SubItems.Add(order.OrderStatus.ToString());
                        item.SubItems.Add(order.OrderType.ToString());
                        item.SubItems.Add(order.CustomerId.ToString());
                        item.SubItems.Add(order.EmployeeId.ToString());
                        listViewOrder.Items.Add(item);
                    }
                }
                return;
            }
            else
            {
                MessageBox.Show("There is no Order in the database", "No order found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Return today value
        private void buttonToday_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Today;
            maskedTextBoxOrderDate.Text = currentDate.ToShortDateString();
        }
        // Add button
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string iSBN = textBoxISBN.Text.Trim();
            string orderId = textBoxOrderId.Text.Trim();
            string quantityOrdered = textBoxQuantity.Text.Trim();

            if (Validator.IsEmpty(orderId))
            {
                MessageBox.Show("Order ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Focus();
                return;
            }

            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("ISBN is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(quantityOrdered))
            {
                MessageBox.Show("Quantity Ordered is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQuantity.Focus();
                return;
            }

            if (!Validator.IsValidId(orderId, 7))
            {
                MessageBox.Show("OrderId is a 7-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }

            if (!Validator.IsValidId(iSBN, 13))
            {
                MessageBox.Show("ISBN is a 13-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            int qo;
            try
            {
                qo = Convert.ToInt32(quantityOrdered);
            }
            catch (Exception)
            {
                MessageBox.Show("Quantity order is a number.", "Invalid Quantity Ordered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQuantity.Clear();
                textBoxQuantity.Focus();
                return;
            }

            int oId = Convert.ToInt32(orderId);
            Order order = new Order();
            order = dBEntities.Orders.Find(oId);

            Customer cust = new Customer();
            cust = dBEntities.Customers.Find(Convert.ToInt32(order.CustomerId));

            if (order == null)
            {
                MessageBox.Show("This Order ID does not exist.", "Non-exist Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxOrderId.Focus();
                return;
            }
            else if (order.OrderStatus == 7)
            {
                MessageBox.Show("This Order was canceled.", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxOrderId.Focus();
                return;
            }else if (cust.Status == 6)
            {
                MessageBox.Show("This Customer is inactive.", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxOrderId.Focus();
                return;
            }

            Book book = new Book();
            book = dBEntities.Books.Find(iSBN);
            if (book == null)
            {
                MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxISBN.Focus();
                return;
            }
            else if (book.Status == 9)
            {
                MessageBox.Show("This Book is out of stock.", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxISBN.Focus();
                return;
            }

            OrderLine orderLine = new OrderLine();
            var oL = dBEntities.OrderLines.Where(ol => ol.OrderId == oId && ol.ISBN == iSBN).FirstOrDefault();
            if( oL != null)
            {
                MessageBox.Show("This Order has already been added.", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                textBoxOrderId.Focus();
                return;
            }

            if (book.QOH == 0)
            {
                MessageBox.Show("This book will be available soon.", "Insufficient Quantity On Hand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                return;
            }
            else if (qo > book.QOH)
            {
                if (MessageBox.Show("The on hand quantity is insufficient for the order. \n Do you want to order " + book.QOH + " books?", "Insufficient Quantity On Hand", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    textBoxQuantity.Text = book.QOH.ToString();
                    qo = book.QOH;
                    book.QOH = 0;
                    book.Status = 9;
                    OrderLine ordLine = new OrderLine();
                    ordLine.OrderId = oId;
                    ordLine.ISBN = iSBN;
                    ordLine.QuantityOrdered = qo;
                    dBEntities.OrderLines.Add(ordLine);
                    dBEntities.SaveChanges();
                    MessageBox.Show("Added successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Order has not been added.", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxQuantity.Clear();
                maskedTextBoxOrderDate.Clear();
                maskedTextBoxShippingDate.Clear();
                maskedTextBoxRequiredDate.Clear();
                comboBoxOrderStatus.SelectedIndex = -1;
                comboBoxOrderType.SelectedIndex = -1;
                textBoxCustomerID.Clear();
                return;
            }
            /*else
            {
                book.QOH = book.QOH - qo;
                //dBEntities.SaveChanges();
            }*/

            // When data is valid
            if (MessageBox.Show("Do you want to add the Book: "+ book.BookTitle + " to the Order ID: "+ order.OrderId + "?", "Add Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                book.QOH = book.QOH - qo;
                OrderLine ordLine = new OrderLine();
                ordLine.OrderId = oId;
                ordLine.ISBN = iSBN;
                ordLine.QuantityOrdered = qo;
                dBEntities.OrderLines.Add(ordLine);
                dBEntities.SaveChanges();
                MessageBox.Show("Added successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Order has not been added.", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxOrderId.Clear();
            textBoxISBN.Clear();
            textBoxQuantity.Clear();
            maskedTextBoxOrderDate.Clear();
            maskedTextBoxShippingDate.Clear();
            maskedTextBoxRequiredDate.Clear();
            comboBoxOrderStatus.SelectedIndex = -1;
            comboBoxOrderType.SelectedIndex = -1;
            textBoxCustomerID.Clear();
        }
        
        private void comboBoxOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Search for OrderLine button
        private void buttonSearchOrderLine_Click(object sender, EventArgs e)
        {
            textBoxQuantity.Clear();
            maskedTextBoxOrderDate.Clear();
            maskedTextBoxShippingDate.Clear();
            maskedTextBoxRequiredDate.Clear();
            comboBoxOrderStatus.SelectedIndex = -1;
            comboBoxOrderType.SelectedIndex = -1;
            textBoxCustomerID.Clear();
            string orderId = textBoxOrderId.Text.Trim();
            string iSBN = textBoxISBN.Text.Trim();

            if (Validator.IsEmpty(orderId))
            {
                MessageBox.Show("Order ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Focus();
                return;
            }

            if (Validator.IsEmpty(iSBN))
            {
                MessageBox.Show("ISBN is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (!Validator.IsValidId(orderId, 7))
            {
                MessageBox.Show("OrderId is a 7-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }

            if (!Validator.IsValidId(iSBN, 13))
            {
                MessageBox.Show("ISBN is a 13-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            int oId = Convert.ToInt32(orderId);
            Order order = new Order();
            order = dBEntities.Orders.Find(oId);

            Book book = new Book();
            book = dBEntities.Books.Find(iSBN);

            var orderLine = dBEntities.OrderLines.Where(ol => ol.OrderId == oId && ol.ISBN == iSBN).FirstOrDefault();

            if (order == null)
            {
                MessageBox.Show("This Order ID does not exist.", "Non-exist Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }/*
            else if (order.OrderStatus == 7)
            {
                MessageBox.Show("This Order was canceled.", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxOrderId.Focus();
                return;
            }*/
            else if (book == null)
            {
                MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }
            else if (orderLine == null)
            {
                MessageBox.Show("This Order Line does not exist.", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxISBN.Clear();
                textBoxOrderId.Focus();
                return;
            }else
            {
                if (comboBoxOrderStatus.Items.Count == 4)
                {
                    comboBoxOrderStatus.Items.Add("7. Cancelled");
                }
                textBoxQuantity.Text = orderLine.QuantityOrdered.ToString();
                textBoxCustomerID.Text = order.CustomerId.ToString();
                maskedTextBoxOrderDate.Text = Convert.ToDateTime(order.OrderDate.ToString()).ToString("MM/dd/yyyy"); 
                maskedTextBoxShippingDate.Text = Convert.ToDateTime(order.ShippingDate.ToString()).ToString("MM/dd/yyyy");
                maskedTextBoxRequiredDate.Text = Convert.ToDateTime(order.RequiredDate.ToString()).ToString("MM/dd/yyyy");
                switch (order.OrderType)
                {
                    case "By Phone":
                        comboBoxOrderType.SelectedIndex = 0;
                        break;
                    case "By Email":
                        comboBoxOrderType.SelectedIndex = 1;
                        break;
                }
                switch (order.OrderStatus)
                {
                    case 1:
                        comboBoxOrderStatus.SelectedIndex = 0;
                        break;
                    case 2:
                        comboBoxOrderStatus.SelectedIndex = 1;
                        break;
                    case 3:
                        comboBoxOrderStatus.SelectedIndex = 2;
                        break;
                    case 4:
                        comboBoxOrderStatus.SelectedIndex = 3;
                        break;
                    case 7:
                        comboBoxOrderStatus.SelectedIndex = 4;
                        break;
                }
            }

        }
        
        private void comboBoxOrderStatus_MouseClick(object sender, MouseEventArgs e)
        {
            if(comboBoxOrderStatus.Items.Count >= 5)
            {
                comboBoxOrderStatus.Items.Remove("7. Cancelled");
            }
        }
    }
}
