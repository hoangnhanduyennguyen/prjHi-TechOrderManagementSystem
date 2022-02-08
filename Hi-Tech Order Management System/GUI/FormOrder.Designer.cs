namespace Hi_Tech_Order_Management_System.GUI
{
    partial class FormOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxOrderStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.listViewOrder = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonListAll = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.maskedTextBoxOrderDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxRequiredDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxShippingDate = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxOrderType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxCustomerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonToday = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSearchOrderLine = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxOrderStatus
            // 
            this.comboBoxOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOrderStatus.FormattingEnabled = true;
            this.comboBoxOrderStatus.Location = new System.Drawing.Point(911, 83);
            this.comboBoxOrderStatus.Name = "comboBoxOrderStatus";
            this.comboBoxOrderStatus.Size = new System.Drawing.Size(133, 24);
            this.comboBoxOrderStatus.TabIndex = 8;
            this.comboBoxOrderStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderStatus_SelectedIndexChanged);
            this.comboBoxOrderStatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBoxOrderStatus_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(908, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 189;
            this.label7.Text = "Order Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(579, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 186;
            this.label6.Text = "Customer ID";
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogOut.Location = new System.Drawing.Point(826, 557);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(130, 38);
            this.buttonLogOut.TabIndex = 185;
            this.buttonLogOut.Text = "Logout";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrderId.Location = new System.Drawing.Point(75, 84);
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.Size = new System.Drawing.Size(111, 23);
            this.textBoxOrderId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(425, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 184;
            this.label1.Text = "Shipping Date";
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearAll.Location = new System.Drawing.Point(307, 280);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(91, 49);
            this.buttonClearAll.TabIndex = 173;
            this.buttonClearAll.Text = "Clear All";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 183;
            this.label5.Text = "(7-digit number)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.labelInfo);
            this.groupBox2.Controls.Add(this.textBoxInput);
            this.groupBox2.Controls.Add(this.comboBoxSearch);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.buttonSearch);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(564, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 133);
            this.groupBox2.TabIndex = 174;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Operation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-50, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 200;
            this.label10.Text = "ISBN";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(167, 71);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 18);
            this.labelInfo.TabIndex = 16;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(153, 92);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(180, 25);
            this.textBoxInput.TabIndex = 7;
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "Order ID",
            "ISBN",
            "Customer ID"});
            this.comboBoxSearch.Location = new System.Drawing.Point(153, 29);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(152, 26);
            this.comboBoxSearch.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(55, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "Search By";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(347, 22);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(104, 38);
            this.buttonSearch.TabIndex = 8;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(335, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(407, 47);
            this.label11.TabIndex = 182;
            this.label11.Text = "Order Management";
            // 
            // listViewOrder
            // 
            this.listViewOrder.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader1});
            this.listViewOrder.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewOrder.GridLines = true;
            this.listViewOrder.HideSelection = false;
            this.listViewOrder.Location = new System.Drawing.Point(30, 350);
            this.listViewOrder.Name = "listViewOrder";
            this.listViewOrder.ShowItemToolTips = true;
            this.listViewOrder.Size = new System.Drawing.Size(1055, 181);
            this.listViewOrder.TabIndex = 181;
            this.listViewOrder.UseCompatibleStateImageBehavior = false;
            this.listViewOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Order ID";
            this.columnHeader10.Width = 79;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "ISBN";
            this.columnHeader11.Width = 137;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Quantity Ordered";
            this.columnHeader12.Width = 139;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Order Date";
            this.columnHeader13.Width = 94;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Required Date";
            this.columnHeader14.Width = 117;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Shipping Date";
            this.columnHeader15.Width = 122;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Order Status";
            this.columnHeader16.Width = 95;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Order Type";
            this.columnHeader17.Width = 87;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Customer ID";
            this.columnHeader18.Width = 92;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "EmployeeID";
            this.columnHeader1.Width = 92;
            // 
            // buttonListAll
            // 
            this.buttonListAll.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListAll.Location = new System.Drawing.Point(194, 280);
            this.buttonListAll.Name = "buttonListAll";
            this.buttonListAll.Size = new System.Drawing.Size(93, 49);
            this.buttonListAll.TabIndex = 175;
            this.buttonListAll.Text = "List All Orders";
            this.buttonListAll.UseVisualStyleBackColor = true;
            this.buttonListAll.Click += new System.EventHandler(this.buttonListAll_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(420, 280);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 49);
            this.buttonCancel.TabIndex = 172;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(420, 215);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(91, 49);
            this.buttonUpdate.TabIndex = 171;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(979, 557);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(106, 38);
            this.buttonExit.TabIndex = 176;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(75, 215);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 49);
            this.buttonSave.TabIndex = 170;
            this.buttonSave.Text = "Create New Order";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(731, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 16);
            this.label12.TabIndex = 180;
            this.label12.Text = "Order Type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(425, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 16);
            this.label13.TabIndex = 179;
            this.label13.Text = "Required Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(230, 133);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 16);
            this.label14.TabIndex = 178;
            this.label14.Text = "Order Date";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(72, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 16);
            this.label15.TabIndex = 177;
            this.label15.Text = "Order ID";
            // 
            // maskedTextBoxOrderDate
            // 
            this.maskedTextBoxOrderDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxOrderDate.Location = new System.Drawing.Point(233, 152);
            this.maskedTextBoxOrderDate.Mask = "00/00/0000";
            this.maskedTextBoxOrderDate.Name = "maskedTextBoxOrderDate";
            this.maskedTextBoxOrderDate.Size = new System.Drawing.Size(142, 23);
            this.maskedTextBoxOrderDate.TabIndex = 3;
            this.maskedTextBoxOrderDate.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBoxRequiredDate
            // 
            this.maskedTextBoxRequiredDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxRequiredDate.Location = new System.Drawing.Point(429, 83);
            this.maskedTextBoxRequiredDate.Mask = "00/00/0000";
            this.maskedTextBoxRequiredDate.Name = "maskedTextBoxRequiredDate";
            this.maskedTextBoxRequiredDate.Size = new System.Drawing.Size(100, 23);
            this.maskedTextBoxRequiredDate.TabIndex = 4;
            this.maskedTextBoxRequiredDate.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBoxShippingDate
            // 
            this.maskedTextBoxShippingDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxShippingDate.Location = new System.Drawing.Point(428, 148);
            this.maskedTextBoxShippingDate.Mask = "00/00/0000";
            this.maskedTextBoxShippingDate.Name = "maskedTextBoxShippingDate";
            this.maskedTextBoxShippingDate.Size = new System.Drawing.Size(100, 23);
            this.maskedTextBoxShippingDate.TabIndex = 5;
            this.maskedTextBoxShippingDate.ValidatingType = typeof(System.DateTime);
            // 
            // comboBoxOrderType
            // 
            this.comboBoxOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderType.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOrderType.FormattingEnabled = true;
            this.comboBoxOrderType.Location = new System.Drawing.Point(734, 84);
            this.comboBoxOrderType.Name = "comboBoxOrderType";
            this.comboBoxOrderType.Size = new System.Drawing.Size(125, 24);
            this.comboBoxOrderType.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(72, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 16);
            this.label8.TabIndex = 198;
            this.label8.Text = "Quantity Ordered";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantity.Location = new System.Drawing.Point(75, 154);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(111, 23);
            this.textBoxQuantity.TabIndex = 2;
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxISBN.Location = new System.Drawing.Point(233, 85);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(142, 23);
            this.textBoxISBN.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(230, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 16);
            this.label16.TabIndex = 201;
            this.label16.Text = "(13-digit number)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(230, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 16);
            this.label17.TabIndex = 200;
            this.label17.Text = "ISBN";
            // 
            // textBoxCustomerID
            // 
            this.textBoxCustomerID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomerID.Location = new System.Drawing.Point(582, 83);
            this.textBoxCustomerID.Name = "textBoxCustomerID";
            this.textBoxCustomerID.Size = new System.Drawing.Size(102, 23);
            this.textBoxCustomerID.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(579, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 203;
            this.label2.Text = "(6-digit number)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 204;
            this.label3.Text = "(MM/DD/YYYY)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(425, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 205;
            this.label4.Text = "(MM/DD/YYYY)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(425, 173);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 16);
            this.label18.TabIndex = 206;
            this.label18.Text = "(MM/DD/YYYY)";
            // 
            // buttonToday
            // 
            this.buttonToday.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToday.Location = new System.Drawing.Point(194, 215);
            this.buttonToday.Name = "buttonToday";
            this.buttonToday.Size = new System.Drawing.Size(93, 49);
            this.buttonToday.TabIndex = 207;
            this.buttonToday.Text = "Today";
            this.buttonToday.UseVisualStyleBackColor = true;
            this.buttonToday.Click += new System.EventHandler(this.buttonToday_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(307, 215);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(87, 49);
            this.buttonAdd.TabIndex = 208;
            this.buttonAdd.Text = "Add ";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSearchOrderLine
            // 
            this.buttonSearchOrderLine.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchOrderLine.Location = new System.Drawing.Point(75, 280);
            this.buttonSearchOrderLine.Name = "buttonSearchOrderLine";
            this.buttonSearchOrderLine.Size = new System.Drawing.Size(100, 49);
            this.buttonSearchOrderLine.TabIndex = 209;
            this.buttonSearchOrderLine.Text = "Search Order Line";
            this.buttonSearchOrderLine.UseVisualStyleBackColor = true;
            this.buttonSearchOrderLine.Click += new System.EventHandler(this.buttonSearchOrderLine_Click);
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 607);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSearchOrderLine);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonToday);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCustomerID);
            this.Controls.Add(this.textBoxISBN);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.comboBoxOrderType);
            this.Controls.Add(this.maskedTextBoxShippingDate);
            this.Controls.Add(this.maskedTextBoxRequiredDate);
            this.Controls.Add(this.maskedTextBoxOrderDate);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxOrderStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.textBoxOrderId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listViewOrder);
            this.Controls.Add(this.buttonListAll);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOrder";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOrderStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.TextBox textBoxOrderId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView listViewOrder;
        private System.Windows.Forms.Button buttonListAll;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxOrderDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRequiredDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxShippingDate;
        private System.Windows.Forms.ComboBox comboBoxOrderType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxCustomerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button buttonToday;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSearchOrderLine;
    }
}