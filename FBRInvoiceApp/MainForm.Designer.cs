using System.Windows.Forms;

namespace FBRInvoiceApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        // Add these controls to your existing declarations
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Button btnRefreshInvoice;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.GroupBox gbSeller;
        private System.Windows.Forms.ComboBox cmbSellerProvince;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSellerAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSellerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSellerNTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbBuyer;
        private System.Windows.Forms.RadioButton rdoUnregistered;
        private System.Windows.Forms.RadioButton rdoRegistered;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbBuyerProvince;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuyerAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuyerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBuyerCNIC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbInvoiceDetails;
        private System.Windows.Forms.ComboBox cmbInvoiceType;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbScenario;
        private System.Windows.Forms.Label label1;
     
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbItemEntry;
        private System.Windows.Forms.TextBox txtSroItemSerialNo;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtFedPayable;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtSroSchedule;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtExtraTaxItem;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtFurtherTaxItem;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cmbTaxRate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbUoM;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtHsCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.GroupBox gbTotals;
        private System.Windows.Forms.TextBox txtInclTax;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtExtraTax;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFurtherTax;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTaxAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtGrossTotal;
        private System.Windows.Forms.Label labelGrossTotal;
        private System.Windows.Forms.TextBox txtValueExclTax;
        private System.Windows.Forms.Label labelValueExclTax;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtJson;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtFbrResponse;
        private System.Windows.Forms.Button btnToggleMode;
        private System.Windows.Forms.Label lblModeStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbSeller = new System.Windows.Forms.GroupBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(20, 25);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(60, 13);
            this.lblInvoiceNo.TabIndex = 20;
            this.lblInvoiceNo.Text = "Invoice #:";
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.btnRefreshInvoice = new System.Windows.Forms.Button();
            this.cmbSellerProvince = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSellerAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSellerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSellerNTN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbBuyer = new System.Windows.Forms.GroupBox();
            this.rdoUnregistered = new System.Windows.Forms.RadioButton();
            this.rdoRegistered = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbBuyerProvince = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuyerAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuyerName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBuyerCNIC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbInvoiceDetails = new System.Windows.Forms.GroupBox();
            this.cmbInvoiceType = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbScenario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.gbItemEntry = new System.Windows.Forms.GroupBox();
            this.txtSroItemSerialNo = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtFedPayable = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtSroSchedule = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtExtraTaxItem = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtFurtherTaxItem = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cmbTaxRate = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbUoM = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHsCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.gbTotals = new System.Windows.Forms.GroupBox();
            this.txtInclTax = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtExtraTax = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFurtherTax = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTaxAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGrossTotal = new System.Windows.Forms.TextBox();
            this.labelGrossTotal = new System.Windows.Forms.Label();
            this.txtValueExclTax = new System.Windows.Forms.TextBox();
            this.labelValueExclTax = new System.Windows.Forms.Label();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtJson = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtFbrResponse = new System.Windows.Forms.TextBox();
            this.btnToggleMode = new System.Windows.Forms.Button();
            this.lblModeStatus = new System.Windows.Forms.Label();
            this.gbSeller.SuspendLayout();
            this.gbBuyer.SuspendLayout();
            this.gbInvoiceDetails.SuspendLayout();
            this.gbItemEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.gbTotals.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSeller
            // 
            this.gbSeller.Controls.Add(this.cmbSellerProvince);
            this.gbSeller.Controls.Add(this.label21);
            this.gbSeller.Controls.Add(this.txtSellerAddress);
            this.gbSeller.Controls.Add(this.label4);
            this.gbSeller.Controls.Add(this.txtSellerName);
            this.gbSeller.Controls.Add(this.label3);
            this.gbSeller.Controls.Add(this.txtSellerNTN);
            this.gbSeller.Controls.Add(this.label2);
            this.gbSeller.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSeller.Location = new System.Drawing.Point(12, 54);
            this.gbSeller.Name = "gbSeller";
            this.gbSeller.Size = new System.Drawing.Size(434, 140);
            this.gbSeller.TabIndex = 2;
            this.gbSeller.TabStop = false;
            this.gbSeller.Text = "Seller Details";
            // 
            // cmbSellerProvince
            // 
            this.cmbSellerProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSellerProvince.FormattingEnabled = true;
            this.cmbSellerProvince.Location = new System.Drawing.Point(110, 107);
            this.cmbSellerProvince.Name = "cmbSellerProvince";
            this.cmbSellerProvince.Size = new System.Drawing.Size(312, 23);
            this.cmbSellerProvince.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 110);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 15);
            this.label21.TabIndex = 6;
            this.label21.Text = "Province:";
            // 
            // txtSellerAddress
            // 
            this.txtSellerAddress.Location = new System.Drawing.Point(110, 78);
            this.txtSellerAddress.Name = "txtSellerAddress";
            this.txtSellerAddress.Size = new System.Drawing.Size(312, 23);
            this.txtSellerAddress.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Address:";
            // 
            // txtSellerName
            // 
            this.txtSellerName.Location = new System.Drawing.Point(110, 49);
            this.txtSellerName.Name = "txtSellerName";
            this.txtSellerName.Size = new System.Drawing.Size(312, 23);
            this.txtSellerName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Business Name:";
            // 
            // txtSellerNTN
            // 
            this.txtSellerNTN.Location = new System.Drawing.Point(110, 20);
            this.txtSellerNTN.Name = "txtSellerNTN";
            this.txtSellerNTN.Size = new System.Drawing.Size(176, 23);
            this.txtSellerNTN.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "NTN/CNIC:";
            // 
            // gbBuyer
            // 
            this.gbBuyer.Controls.Add(this.rdoUnregistered);
            this.gbBuyer.Controls.Add(this.rdoRegistered);
            this.gbBuyer.Controls.Add(this.label20);
            this.gbBuyer.Controls.Add(this.cmbBuyerProvince);
            this.gbBuyer.Controls.Add(this.label5);
            this.gbBuyer.Controls.Add(this.txtBuyerAddress);
            this.gbBuyer.Controls.Add(this.label6);
            this.gbBuyer.Controls.Add(this.txtBuyerName);
            this.gbBuyer.Controls.Add(this.label7);
            this.gbBuyer.Controls.Add(this.txtBuyerCNIC);
            this.gbBuyer.Controls.Add(this.label8);
            this.gbBuyer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuyer.Location = new System.Drawing.Point(452, 54);
            this.gbBuyer.Name = "gbBuyer";
            this.gbBuyer.Size = new System.Drawing.Size(434, 169);
            this.gbBuyer.TabIndex = 3;
            this.gbBuyer.TabStop = false;
            this.gbBuyer.Text = "Buyer Details";
            // 
            // rdoUnregistered
            // 
            this.rdoUnregistered.AutoSize = true;
            this.rdoUnregistered.Location = new System.Drawing.Point(217, 139);
            this.rdoUnregistered.Name = "rdoUnregistered";
            this.rdoUnregistered.Size = new System.Drawing.Size(92, 19);
            this.rdoUnregistered.TabIndex = 5;
            this.rdoUnregistered.TabStop = true;
            this.rdoUnregistered.Text = "Unregistered";
            this.rdoUnregistered.UseVisualStyleBackColor = true;
            // 
            // rdoRegistered
            // 
            this.rdoRegistered.AutoSize = true;
            this.rdoRegistered.Location = new System.Drawing.Point(110, 139);
            this.rdoRegistered.Name = "rdoRegistered";
            this.rdoRegistered.Size = new System.Drawing.Size(80, 19);
            this.rdoRegistered.TabIndex = 4;
            this.rdoRegistered.TabStop = true;
            this.rdoRegistered.Text = "Registered";
            this.rdoRegistered.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 141);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 15);
            this.label20.TabIndex = 8;
            this.label20.Text = "Type:";
            // 
            // cmbBuyerProvince
            // 
            this.cmbBuyerProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuyerProvince.FormattingEnabled = true;
            this.cmbBuyerProvince.Location = new System.Drawing.Point(110, 107);
            this.cmbBuyerProvince.Name = "cmbBuyerProvince";
            this.cmbBuyerProvince.Size = new System.Drawing.Size(312, 23);
            this.cmbBuyerProvince.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Province:";
            // 
            // txtBuyerAddress
            // 
            this.txtBuyerAddress.Location = new System.Drawing.Point(110, 78);
            this.txtBuyerAddress.Name = "txtBuyerAddress";
            this.txtBuyerAddress.Size = new System.Drawing.Size(312, 23);
            this.txtBuyerAddress.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Address:";
            // 
            // txtBuyerName
            // 
            this.txtBuyerName.Location = new System.Drawing.Point(110, 49);
            this.txtBuyerName.Name = "txtBuyerName";
            this.txtBuyerName.Size = new System.Drawing.Size(312, 23);
            this.txtBuyerName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Buyer Name:";
            // 
            // txtBuyerCNIC
            // 
            this.txtBuyerCNIC.Location = new System.Drawing.Point(110, 20);
            this.txtBuyerCNIC.Name = "txtBuyerCNIC";
            this.txtBuyerCNIC.Size = new System.Drawing.Size(176, 23);
            this.txtBuyerCNIC.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "NTN/CNIC:";
            // 
            // gbInvoiceDetails
            // 
            this.gbInvoiceDetails.Controls.Add(this.cmbInvoiceType);
            this.gbInvoiceDetails.Controls.Add(this.label23);
            this.gbInvoiceDetails.Controls.Add(this.cmbScenario);
            this.gbInvoiceDetails.Controls.Add(this.label1);
            this.gbInvoiceDetails.Controls.Add(this.txtSerialNo);
            this.gbInvoiceDetails.Controls.Add(this.label9);
            this.gbInvoiceDetails.Controls.Add(this.dtpInvoiceDate);
            this.gbInvoiceDetails.Controls.Add(this.label10);
            this.gbInvoiceDetails.Location = new System.Drawing.Point(13, 213);
            this.gbInvoiceDetails.Name = "gbInvoiceDetails";
            this.gbInvoiceDetails.Size = new System.Drawing.Size(873, 82);
            this.gbInvoiceDetails.TabIndex = 4;
            this.gbInvoiceDetails.TabStop = false;
            this.gbInvoiceDetails.Text = "Invoice Info";
            // 
            // cmbInvoiceType
            // 
            this.cmbInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceType.FormattingEnabled = true;
            this.cmbInvoiceType.Location = new System.Drawing.Point(344, 22);
            this.cmbInvoiceType.Name = "cmbInvoiceType";
            this.cmbInvoiceType.Size = new System.Drawing.Size(149, 21);
            this.cmbInvoiceType.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(267, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 13);
            this.label23.TabIndex = 6;
            this.label23.Text = "Invoice Type:";
            // 
            // cmbScenario
            // 
            this.cmbScenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScenario.FormattingEnabled = true;
            this.cmbScenario.Location = new System.Drawing.Point(109, 52);
            this.cmbScenario.Name = "cmbScenario";
            this.cmbScenario.Size = new System.Drawing.Size(384, 21);
            this.cmbScenario.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scenario:";
            // 
            // txtSerialNo
           
            this.txtSerialNo.Location = new System.Drawing.Point(120, 22);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.ReadOnly = true;
            this.txtSerialNo.Size = new System.Drawing.Size(250, 20);
            this.txtSerialNo.TabIndex = 21;
            // 
            this.btnRefreshInvoice.Location = new System.Drawing.Point(380, 20);
            this.btnRefreshInvoice.Name = "btnRefreshInvoice";
            this.btnRefreshInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshInvoice.TabIndex = 22;
            this.btnRefreshInvoice.Text = "Refresh";
            this.btnRefreshInvoice.UseVisualStyleBackColor = true;
            this.btnRefreshInvoice.Click += new System.EventHandler(this.btnRefreshInvoice_Click);
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Invoice Ref No:";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(595, 22);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(121, 20);
            this.dtpInvoiceDate.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(517, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Invoice Date:";
            // 
            // gbItemEntry
            // 
            this.gbItemEntry.Controls.Add(this.txtSroItemSerialNo);
            this.gbItemEntry.Controls.Add(this.label29);
            this.gbItemEntry.Controls.Add(this.txtDiscount);
            this.gbItemEntry.Controls.Add(this.label28);
            this.gbItemEntry.Controls.Add(this.txtFedPayable);
            this.gbItemEntry.Controls.Add(this.label27);
            this.gbItemEntry.Controls.Add(this.txtSroSchedule);
            this.gbItemEntry.Controls.Add(this.label26);
            this.gbItemEntry.Controls.Add(this.txtExtraTaxItem);
            this.gbItemEntry.Controls.Add(this.label25);
            this.gbItemEntry.Controls.Add(this.txtFurtherTaxItem);
            this.gbItemEntry.Controls.Add(this.label24);
            this.gbItemEntry.Controls.Add(this.btnAddItem);
            this.gbItemEntry.Controls.Add(this.cmbTaxRate);
            this.gbItemEntry.Controls.Add(this.label16);
            this.gbItemEntry.Controls.Add(this.txtRate);
            this.gbItemEntry.Controls.Add(this.label15);
            this.gbItemEntry.Controls.Add(this.txtQuantity);
            this.gbItemEntry.Controls.Add(this.label14);
            this.gbItemEntry.Controls.Add(this.cmbUoM);
            this.gbItemEntry.Controls.Add(this.label13);
            this.gbItemEntry.Controls.Add(this.txtItemName);
            this.gbItemEntry.Controls.Add(this.label12);
            this.gbItemEntry.Controls.Add(this.txtHsCode);
            this.gbItemEntry.Controls.Add(this.label11);
            this.gbItemEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbItemEntry.Location = new System.Drawing.Point(13, 292);
            this.gbItemEntry.Name = "gbItemEntry";
            this.gbItemEntry.Size = new System.Drawing.Size(873, 150);
            this.gbItemEntry.TabIndex = 5;
            this.gbItemEntry.TabStop = false;
            this.gbItemEntry.Text = "Add Invoice Item";
            // 
            // txtSroItemSerialNo
            // 
            this.txtSroItemSerialNo.Location = new System.Drawing.Point(717, 81);
            this.txtSroItemSerialNo.Name = "txtSroItemSerialNo";
            this.txtSroItemSerialNo.Size = new System.Drawing.Size(141, 23);
            this.txtSroItemSerialNo.TabIndex = 10;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(619, 84);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(90, 15);
            this.label29.TabIndex = 24;
            this.label29.Text = "SRO Item Serial:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(472, 81);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(121, 23);
            this.txtDiscount.TabIndex = 9;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(409, 84);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(57, 15);
            this.label28.TabIndex = 22;
            this.label28.Text = "Discount:";
            // 
            // txtFedPayable
            // 
            this.txtFedPayable.Location = new System.Drawing.Point(282, 81);
            this.txtFedPayable.Name = "txtFedPayable";
            this.txtFedPayable.Size = new System.Drawing.Size(121, 23);
            this.txtFedPayable.TabIndex = 8;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(203, 84);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 15);
            this.label27.TabIndex = 20;
            this.label27.Text = "FED Payable:";
            // 
            // txtSroSchedule
            // 
            this.txtSroSchedule.Location = new System.Drawing.Point(92, 81);
            this.txtSroSchedule.Name = "txtSroSchedule";
            this.txtSroSchedule.Size = new System.Drawing.Size(105, 23);
            this.txtSroSchedule.TabIndex = 7;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(10, 84);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(61, 15);
            this.label26.TabIndex = 18;
            this.label26.Text = "SRO Schd:";
            // 
            // txtExtraTaxItem
            // 
            this.txtExtraTaxItem.Location = new System.Drawing.Point(717, 52);
            this.txtExtraTaxItem.Name = "txtExtraTaxItem";
            this.txtExtraTaxItem.Size = new System.Drawing.Size(141, 23);
            this.txtExtraTaxItem.TabIndex = 6;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(654, 55);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 15);
            this.label25.TabIndex = 16;
            this.label25.Text = "Extra Tax:";
            // 
            // txtFurtherTaxItem
            // 
            this.txtFurtherTaxItem.Location = new System.Drawing.Point(509, 52);
            this.txtFurtherTaxItem.Name = "txtFurtherTaxItem";
            this.txtFurtherTaxItem.Size = new System.Drawing.Size(121, 23);
            this.txtFurtherTaxItem.TabIndex = 5;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(428, 55);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 15);
            this.label24.TabIndex = 14;
            this.label24.Text = "Further Tax:";
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(717, 110);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(141, 34);
            this.btnAddItem.TabIndex = 11;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // cmbTaxRate
            // 
            this.cmbTaxRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaxRate.FormattingEnabled = true;
            this.cmbTaxRate.Location = new System.Drawing.Point(282, 52);
            this.cmbTaxRate.Name = "cmbTaxRate";
            this.cmbTaxRate.Size = new System.Drawing.Size(121, 23);
            this.cmbTaxRate.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(220, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 15);
            this.label16.TabIndex = 10;
            this.label16.Text = "Tax Rate:";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(92, 52);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(105, 23);
            this.txtRate.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "Rate:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(717, 23);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(141, 23);
            this.txtQuantity.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(654, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "Quantity:";
            // 
            // cmbUoM
            // 
            this.cmbUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUoM.FormattingEnabled = true;
            this.cmbUoM.Location = new System.Drawing.Point(509, 23);
            this.cmbUoM.Name = "cmbUoM";
            this.cmbUoM.Size = new System.Drawing.Size(121, 23);
            this.cmbUoM.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(428, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "UoM:";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(173, 23);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(230, 23);
            this.txtItemName.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(131, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Item:";
            // 
            // txtHsCode
            // 
            this.txtHsCode.Location = new System.Drawing.Point(50, 23);
            this.txtHsCode.Name = "txtHsCode";
            this.txtHsCode.Size = new System.Drawing.Size(75, 23);
            this.txtHsCode.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "HS:";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItems.Location = new System.Drawing.Point(13, 448);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(873, 200);
            this.dgvItems.TabIndex = 6;
            // 
            // gbTotals
            // 
            this.gbTotals.Controls.Add(this.txtInclTax);
            this.gbTotals.Controls.Add(this.label22);
            this.gbTotals.Controls.Add(this.txtExtraTax);
            this.gbTotals.Controls.Add(this.label19);
            this.gbTotals.Controls.Add(this.txtFurtherTax);
            this.gbTotals.Controls.Add(this.label18);
            this.gbTotals.Controls.Add(this.txtTaxAmount);
            this.gbTotals.Controls.Add(this.label17);
            this.gbTotals.Controls.Add(this.txtGrossTotal);
            this.gbTotals.Controls.Add(this.labelGrossTotal);
            this.gbTotals.Controls.Add(this.txtValueExclTax);
            this.gbTotals.Controls.Add(this.labelValueExclTax);
            this.gbTotals.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTotals.Location = new System.Drawing.Point(13, 654);
            this.gbTotals.Name = "gbTotals";
            this.gbTotals.Size = new System.Drawing.Size(873, 100);
            this.gbTotals.TabIndex = 7;
            this.gbTotals.TabStop = false;
            this.gbTotals.Text = "Invoice Totals";
            // 
            // txtInclTax
            // 
            this.txtInclTax.Location = new System.Drawing.Point(717, 65);
            this.txtInclTax.Name = "txtInclTax";
            this.txtInclTax.ReadOnly = true;
            this.txtInclTax.Size = new System.Drawing.Size(141, 23);
            this.txtInclTax.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(619, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 15);
            this.label22.TabIndex = 10;
            this.label22.Text = "Total Inc. Tax:";
            // 
            // txtExtraTax
            // 
            this.txtExtraTax.Location = new System.Drawing.Point(472, 65);
            this.txtExtraTax.Name = "txtExtraTax";
            this.txtExtraTax.ReadOnly = true;
            this.txtExtraTax.Size = new System.Drawing.Size(121, 23);
            this.txtExtraTax.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(409, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 15);
            this.label19.TabIndex = 8;
            this.label19.Text = "Extra Tax:";
            // 
            // txtFurtherTax
            // 
            this.txtFurtherTax.Location = new System.Drawing.Point(282, 65);
            this.txtFurtherTax.Name = "txtFurtherTax";
            this.txtFurtherTax.ReadOnly = true;
            this.txtFurtherTax.Size = new System.Drawing.Size(121, 23);
            this.txtFurtherTax.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(203, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 15);
            this.label18.TabIndex = 6;
            this.label18.Text = "Further Tax:";
            // 
            // txtTaxAmount
            // 
            this.txtTaxAmount.Location = new System.Drawing.Point(92, 65);
            this.txtTaxAmount.Name = "txtTaxAmount";
            this.txtTaxAmount.ReadOnly = true;
            this.txtTaxAmount.Size = new System.Drawing.Size(105, 23);
            this.txtTaxAmount.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "Sales Tax:";
            // 
            // txtGrossTotal
            // 
            this.txtGrossTotal.Location = new System.Drawing.Point(717, 22);
            this.txtGrossTotal.Name = "txtGrossTotal";
            this.txtGrossTotal.ReadOnly = true;
            this.txtGrossTotal.Size = new System.Drawing.Size(141, 23);
            this.txtGrossTotal.TabIndex = 3;
            // 
            // labelGrossTotal
            // 
            this.labelGrossTotal.AutoSize = true;
            this.labelGrossTotal.Location = new System.Drawing.Point(619, 25);
            this.labelGrossTotal.Name = "labelGrossTotal";
            this.labelGrossTotal.Size = new System.Drawing.Size(67, 15);
            this.labelGrossTotal.TabIndex = 2;
            this.labelGrossTotal.Text = "Gross Total:";
            // 
            // txtValueExclTax
            // 
            this.txtValueExclTax.Location = new System.Drawing.Point(92, 22);
            this.txtValueExclTax.Name = "txtValueExclTax";
            this.txtValueExclTax.ReadOnly = true;
            this.txtValueExclTax.Size = new System.Drawing.Size(105, 23);
            this.txtValueExclTax.TabIndex = 1;
            // 
            // labelValueExclTax
            // 
            this.labelValueExclTax.AutoSize = true;
            this.labelValueExclTax.Location = new System.Drawing.Point(10, 25);
            this.labelValueExclTax.Name = "labelValueExclTax";
            this.labelValueExclTax.Size = new System.Drawing.Size(62, 15);
            this.labelValueExclTax.TabIndex = 0;
            this.labelValueExclTax.Text = "Value Excl:";
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.ForeColor = System.Drawing.Color.White;
            this.btnPost.Location = new System.Drawing.Point(745, 760);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(141, 34);
            this.btnPost.TabIndex = 8;
            this.btnPost.Text = "Post Invoice";
            this.btnPost.UseVisualStyleBackColor = false;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(598, 760);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(141, 34);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print Invoice";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(451, 760);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(141, 34);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 800);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(873, 200);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtJson);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(865, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "JSON Request";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtJson
            // 
            this.txtJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJson.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJson.Location = new System.Drawing.Point(3, 3);
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtJson.Size = new System.Drawing.Size(859, 168);
            this.txtJson.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtFbrResponse);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(865, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FBR Response";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtFbrResponse
            // 
            this.txtFbrResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFbrResponse.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFbrResponse.Location = new System.Drawing.Point(3, 3);
            this.txtFbrResponse.Multiline = true;
            this.txtFbrResponse.Name = "txtFbrResponse";
            this.txtFbrResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFbrResponse.Size = new System.Drawing.Size(859, 168);
            this.txtFbrResponse.TabIndex = 0;
            // 
            // btnToggleMode
            // 
            this.btnToggleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnToggleMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleMode.ForeColor = System.Drawing.Color.White;
            this.btnToggleMode.Location = new System.Drawing.Point(745, 12);
            this.btnToggleMode.Name = "btnToggleMode";
            this.btnToggleMode.Size = new System.Drawing.Size(141, 34);
            this.btnToggleMode.TabIndex = 12;
            this.btnToggleMode.Text = "Toggle Mode";
            this.btnToggleMode.UseVisualStyleBackColor = false;
            this.btnToggleMode.Click += new System.EventHandler(this.btnToggleMode_Click);
            // 
            // lblModeStatus
            // 
            this.lblModeStatus.AutoSize = true;
            this.lblModeStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeStatus.ForeColor = System.Drawing.Color.Red;
            this.lblModeStatus.Location = new System.Drawing.Point(12, 18);
            this.lblModeStatus.Name = "lblModeStatus";
            this.lblModeStatus.Size = new System.Drawing.Size(98, 21);
            this.lblModeStatus.TabIndex = 13;
            this.lblModeStatus.Text = "TEST MODE";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 1012);
            this.Controls.Add(this.lblModeStatus);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.btnRefreshInvoice);
            this.Controls.Add(this.btnToggleMode);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.gbTotals);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.gbItemEntry);
            this.Controls.Add(this.gbInvoiceDetails);
            this.Controls.Add(this.gbBuyer);
            this.Controls.Add(this.gbSeller);
            this.Name = "MainForm";
            this.Text = "FBR Invoice Application";
            this.gbSeller.ResumeLayout(false);
            this.gbSeller.PerformLayout();
            this.gbBuyer.ResumeLayout(false);
            this.gbBuyer.PerformLayout();
            this.gbInvoiceDetails.ResumeLayout(false);
            this.gbInvoiceDetails.PerformLayout();
            this.gbItemEntry.ResumeLayout(false);
            this.gbItemEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.gbTotals.ResumeLayout(false);
            this.gbTotals.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}