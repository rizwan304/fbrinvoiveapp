using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace FBRInvoiceApp
{
    public partial class MainForm : Form
    {
        // API Configuration
        private const string SandboxApiUrl = "https://gw.fbr.gov.pk/di_data/v1/di/";
        private const string ProductionApiUrl = "https://gw.fbr.gov.pk/di_data/v1/di/";
        private string _currentApiUrl = SandboxApiUrl;
        private string _currentAuthToken = "your-api-token-here"; // Replace with your actual token
        private bool _isProductionMode = false;

        // Data Management
        private BindingList<InvoiceItem> _itemsList;
        private PrintDocument _printDocument = new PrintDocument();
        private PrintPreviewDialog _printPreviewDialog = new PrintPreviewDialog();
        private Image _fbrLogo;
        private string _lastInvoiceNumber = string.Empty;

        private string GenerateFBRInvoiceNumber(string customerId = "1354067")
        {
            DateTime now = DateTime.Now;
            string prefix = customerId.PadLeft(7, '0').Substring(0, 7);
            string docType = "DI";
            string timestamp = $"{now:yyyy}{now:MM}{now:dd}{now:HH}{now:mm}{now:ss}";
            string randomDigits = new Random().Next(10000, 99999).ToString();
            return $"{prefix}{docType}{timestamp}{randomDigits}-1";
        }
        public MainForm()
        {
            InitializeComponent();
            LoadResources();
            SetupForm();
        }

        private void LoadResources()
        {
            try
            {
                _fbrLogo = Properties.Resources.FBR_Logo;
                if (_fbrLogo == null)
                {
                    _fbrLogo = new Bitmap(100, 50);
                    using (Graphics g = Graphics.FromImage(_fbrLogo))
                    {
                        g.Clear(Color.LightGray);
                        g.DrawString("FBR", new Font("Arial", 12), Brushes.Black, 10, 10);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading resources: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupForm()
        {
            _itemsList = new BindingList<InvoiceItem>();
            dgvItems.DataSource = _itemsList;
            _itemsList.ListChanged += ItemsList_ListChanged;
            _printDocument.PrintPage += PrintDocument_PrintPage;

            LoadDropdowns();
            dtpInvoiceDate.Value = DateTime.Now;
            rdoRegistered.Checked = true;
            ClearForm();
            _printDocument.DocumentName = "FBR Invoice";
            _printPreviewDialog.Document = _printDocument;
        }

        private void ItemsList_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateTotals();
        }

        private void LoadDropdowns()
        {
            cmbInvoiceType.Items.AddRange(new[] { "Sale Invoice", "Debit Note" });
            cmbInvoiceType.SelectedIndex = 0;

            string[] provinces = {
                "PUNJAB", "SINDH", "KHYBER PAKHTUNKHWA",
                "BALOCHISTAN", "ISLAMABAD", "GILGIT BALTISTAN",
                "AZAD JAMMU & KASHMIR"
            };
            cmbBuyerProvince.Items.AddRange(provinces);
            cmbSellerProvince.Items.AddRange(provinces);
            cmbBuyerProvince.SelectedIndex = 0;
            cmbSellerProvince.SelectedIndex = 0;

            cmbUoM.Items.AddRange(new[] {
                "Numbers", "Pieces", "Kg", "Grams", "Liters",
                "Meters", "Square Meters", "Cubic Meters",
                "Pairs", "Dozen", "Sets", "Cartons"
            });
            cmbUoM.SelectedIndex = 0;

            cmbTaxRate.Items.AddRange(new[] { "0%", "5%", "10%", "17%", "18%" });
            cmbTaxRate.SelectedIndex = 4;

            var scenarios = new Dictionary<string, string>
            {
                {"SN001", "Sale of standard rate goods to registered buyers"},
                {"SN002", "Sale of standard rate goods to unregistered buyers"},
                {"SN003", "Sale of Steel (Melted and Re-Rolled)"},
                {"SN004", "Sale of steel scrap by Ship Breakers"},
                {"SN005", "Sales of reduced rate goods (Eighth Schedule)"},
                {"SN006", "Sale of exempt goods (Sixth Schedule)"},
                {"SN007", "Sale of zero-rated goods (Fifth Schedule)"},
                {"SN008", "Sale of 3rd schedule goods"},
                {"SN009", "Purchase from registered Cotton Ginners"},
                {"SN010", "Sale of telecom services by Mobile Operators"},
                {"SN011", "Sale of Steel through Toll Manufacturing"},
                {"SN012", "Sale of Petroleum products"},
                {"SN013", "Sale of electricity to retailers"},
                {"SN014", "Sale of Gas to CNG stations"},
                {"SN015", "Sale of mobile phones"},
                {"SN016", "Processing / Conversion of Goods"},
                {"SN017", "Sale of Goods where FED is charged in ST mode"},
                {"SN018", "Sale of Services where FED is charged in ST mode"},
                {"SN019", "Sale of Services (as per ICT Ordinance)"},
                {"SN020", "Sale of Electric Vehicles"},
                {"SN021", "Sale of Cement /Concrete Block"},
                {"SN022", "Sale of Potassium Chlorate"},
                {"SN023", "Sale of CNG"},
                {"SN024", "Sale of goods listed in SRO 297(1)/2023"},
                {"SN025", "Drugs sold at fixed ST rate under serial 81 of Eighth Schedule Table 1"},
                {"SN026", "Sale of goods at standard rate to end consumers by retailers"},
                {"SN027", "Sale of 3rd Schedule goods to end consumers by retailers"},
                {"SN028", "Sale of goods at reduced rate to end consumers by retailers"}
            };

            cmbScenario.DataSource = new BindingSource(scenarios, null);
            cmbScenario.DisplayMember = "Value";
            cmbScenario.ValueMember = "Key";
            cmbScenario.SelectedIndex = 0;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!ValidateItemInputs()) return;

            var item = new InvoiceItem
            {
                HsCode = txtHsCode.Text,
                ProductDescription = txtItemName.Text,
                UoM = cmbUoM.Text,
                Quantity = decimal.Parse(txtQuantity.Text),
                Rate = decimal.Parse(txtRate.Text),
                TaxRate = decimal.Parse(cmbTaxRate.Text.Replace("%", "")) / 100m,
                FurtherTax = string.IsNullOrEmpty(txtFurtherTaxItem.Text) ? 0 : decimal.Parse(txtFurtherTaxItem.Text),
                ExtraTax = string.IsNullOrEmpty(txtExtraTaxItem.Text) ? 0 : decimal.Parse(txtExtraTaxItem.Text),
                SroScheduleNo = txtSroSchedule.Text,
                FedPayable = string.IsNullOrEmpty(txtFedPayable.Text) ? 0 : decimal.Parse(txtFedPayable.Text),
                Discount = string.IsNullOrEmpty(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text),
                SaleType = GetSaleTypeForScenario(((KeyValuePair<string, string>)cmbScenario.SelectedItem).Key),
                SroItemSerialNo = txtSroItemSerialNo.Text
            };

            _itemsList.Add(item);
            ClearItemInputs();
        }
       
            private void btnRefreshInvoice_Click(object sender, EventArgs e)
            {
                txtSerialNo.Text = GenerateFBRInvoiceNumber();
            }
        
        private async void btnPost_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoice()) return;

            // Generate FBR-compliant invoice number (format: 1354067DI2025080413542967121-1)
            string GenerateInvoiceNumber()
            {
                DateTime now = DateTime.Now;
                string prefix = "1354067"; // From your example, or use txtCustomerId.Text if available
                string docType = "DI";
                string timestamp = $"{now:yyyy}{now:MM}{now:dd}{now:HH}{now:mm}{now:ss}";
                string randomDigits = new Random().Next(10000, 99999).ToString();
                return $"{prefix}{docType}{timestamp}{randomDigits}-1";
            }

            string invoiceNumber = GenerateInvoiceNumber();
            txtSerialNo.Text = invoiceNumber; // Display in your serial number field

            var selectedScenario = (KeyValuePair<string, string>)cmbScenario.SelectedItem;

            // Prepare complete FBR invoice data
            var invoiceData = new
            {
                invoiceNumber = invoiceNumber, // Include generated invoice number
                invoiceType = cmbInvoiceType.Text,
                invoiceDate = dtpInvoiceDate.Value.ToString("yyyy-MM-dd"),
                sellerNTNCNIC = txtSellerNTN.Text,
                sellerBusinessName = txtSellerName.Text,
                sellerProvince = cmbSellerProvince.Text,
                sellerAddress = txtSellerAddress.Text,
                buyerNTNCNIC = txtBuyerCNIC.Text,
                buyerBusinessName = txtBuyerName.Text,
                buyerProvince = cmbBuyerProvince.Text,
                buyerAddress = txtBuyerAddress.Text,
                buyerRegistrationType = rdoRegistered.Checked ? "Registered" : "Unregistered",
                invoiceRefNo = invoiceNumber, // Use same number as reference
                scenarioId = selectedScenario.Key,
                items = _itemsList.Select(item => new
                {
                    hsCode = item.HsCode,
                    productDescription = item.ProductDescription,
                    rate = item.TaxRate.ToString("P0"),
                    uoM = item.UoM,
                    quantity = item.Quantity,
                    totalValues = item.AmountIncludingTax,
                    valueSalesExcludingST = item.ValueExcludingTax,
                    salesTaxApplicable = item.TaxAmount,
                    furtherTax = item.FurtherTax,
                    extraTax = item.ExtraTax,
                    sroscheduleNo = item.SroScheduleNo,
                    fedPayable = item.FedPayable,
                    discount = item.Discount,
                    saleType = item.SaleType,
                    sroItemSerialNo = item.SroItemSerialNo
                }).ToList()
            };

            // Convert to JSON
            string jsonPayload = JsonConvert.SerializeObject(invoiceData, Formatting.Indented);
            txtJson.Text = jsonPayload;
            txtFbrResponse.Text = "Submitting invoice to FBR...";

            try
            {
                using (var client = new HttpClient())
                {
                    // Configure API request
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _currentAuthToken);
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // Select appropriate endpoint
                    string endpoint = _isProductionMode ? "postinvoicedata" : "postinvoicedata_sb";

                    // Send to FBR API
                    HttpResponseMessage response = await client.PostAsync(_currentApiUrl + endpoint, content);
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // Process successful response
                        var result = JsonConvert.DeserializeObject<InvoiceResponse>(responseString);
                        txtFbrResponse.Text = $"SUCCESS ({response.StatusCode}):\n{JsonConvert.SerializeObject(result, Formatting.Indented)}";

                        if (result != null && !string.IsNullOrEmpty(result.InvoiceNumber))
                        {
                            _lastInvoiceNumber = result.InvoiceNumber;
                            MessageBox.Show($"Invoice submitted successfully!\nFBR Invoice #: {result.InvoiceNumber}\n" +
                                          $"Your Invoice #: {invoiceNumber}",
                                          "Success",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Handle API errors
                        txtFbrResponse.Text = $"API ERROR ({response.StatusCode}):\n{responseString}";
                        MessageBox.Show($"FBR API Error: {response.ReasonPhrase}\n\n" +
                                       $"Invoice was NOT submitted.\n" +
                                       $"Your local invoice #: {invoiceNumber}",
                                       "API Error",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                txtFbrResponse.Text = $"EXCEPTION:\n{ex.Message}\n{ex.StackTrace}";
                MessageBox.Show($"System Error: {ex.Message}\n\n" +
                              $"Invoice was NOT submitted.\n" +
                              $"Your local invoice #: {invoiceNumber}",
                              "System Exception",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            finally
            {
                // Update UI after operation completes
                btnPost.Enabled = true;
                btnPost.Text = "Submit to FBR";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_itemsList.Count == 0)
            {
                MessageBox.Show("Cannot print an empty invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _printPreviewDialog.WindowState = FormWindowState.Maximized;
                _printPreviewDialog.PrintPreviewControl.Zoom = 1.0;
                _printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Printing error: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the entire form?", "Confirm Clear",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        private void btnToggleMode_Click(object sender, EventArgs e)
        {
            _isProductionMode = !_isProductionMode;
            _currentApiUrl = _isProductionMode ? ProductionApiUrl : SandboxApiUrl;

            if (_isProductionMode)
            {
                btnToggleMode.Text = "Switch to Sandbox";
                btnToggleMode.BackColor = Color.FromArgb(40, 167, 69);
                lblModeStatus.Text = "PRODUCTION MODE";
                lblModeStatus.ForeColor = Color.Red;
            }
            else
            {
                btnToggleMode.Text = "Switch to Production";
                btnToggleMode.BackColor = Color.FromArgb(23, 162, 184);
                lblModeStatus.Text = "SANDBOX MODE";
                lblModeStatus.ForeColor = Color.Blue;
            }
        }

        private string GetSaleTypeForScenario(string scenarioId)
        {
            switch (scenarioId)
            {
                case "SN001": return "Standard Rate";
                case "SN002": return "Standard Rate";
                case "SN003": return "Steel Melting and re-rolling";
                case "SN004": return "Ship breaking";
                case "SN005": return "Reduced Rate";
                case "SN006": return "Exempt Goods";
                case "SN007": return "Goods at zero-rate";
                case "SN008": return "3rd Schedule Goods";
                case "SN009": return "Cotton Ginners";
                case "SN010": return "Telecommunication services";
                case "SN011": return "Toll Manufacturing";
                case "SN012": return "Petroleum Products";
                case "SN013": return "Electricity Supply to Retailers";
                case "SN014": return "Gas to CNG stations";
                case "SN015": return "Mobile Phones";
                case "SN016": return "Processing/ Conversion of Goods";
                case "SN017": return "Goods (FED in ST Mode)";
                case "SN018": return "Services (FED in ST Mode)";
                case "SN019": return "Services";
                case "SN020": return "Electric Vehicle";
                case "SN021": return "Cement /Concrete Block";
                case "SN022": return "Potassium Chlorate";
                case "SN023": return "CNG Sales";
                case "SN024": return "Goods as per SRO.297(1)/2023";
                case "SN025": return "Non-Adjustable Supplies";
                case "SN026": return "Goods at standard rate (default)";
                case "SN027": return "3rd Schedule Goods";
                case "SN028": return "Goods at reduced rate";
                default: return "Standard Rate";
            }
        }

        private void UpdateTotals()
        {
            decimal valueExclTax = _itemsList.Sum(item => item.ValueExcludingTax);
            decimal totalTax = _itemsList.Sum(item => item.TaxAmount);
            decimal furtherTax = _itemsList.Sum(item => item.FurtherTax);
            decimal extraTax = _itemsList.Sum(item => item.ExtraTax);

            txtGrossTotal.Text = valueExclTax.ToString("N2");
            txtValueExclTax.Text = valueExclTax.ToString("N2");
            txtTaxAmount.Text = totalTax.ToString("N2");
            txtFurtherTax.Text = furtherTax.ToString("N2");
            txtExtraTax.Text = extraTax.ToString("N2");
            txtInclTax.Text = (valueExclTax + totalTax + furtherTax + extraTax).ToString("N2");
        }

        private void ClearItemInputs()
        {
            txtHsCode.Clear();
            txtItemName.Clear();
            txtQuantity.Clear();
            txtRate.Clear();
            txtFurtherTaxItem.Clear();
            txtExtraTaxItem.Clear();
            txtSroSchedule.Clear();
            txtFedPayable.Clear();
            txtDiscount.Clear();
            txtSroItemSerialNo.Clear();
            cmbUoM.SelectedIndex = 0;
            cmbTaxRate.SelectedIndex = 4;
            txtHsCode.Focus();
        }

        private void ClearForm()
        {
            txtBuyerName.Clear();
            txtBuyerAddress.Clear();
            txtBuyerCNIC.Clear();
            cmbBuyerProvince.SelectedIndex = 0;
            _itemsList.Clear();
            txtFbrResponse.Clear();
            txtJson.Clear();
            txtSerialNo.Text = GenerateFBRInvoiceNumber();
            dtpInvoiceDate.Value = DateTime.Now;
            cmbScenario.SelectedIndex = 0;
            txtBuyerName.Focus();
            _lastInvoiceNumber = string.Empty;
            UpdateTotals();
        }

        private string GenerateFBRInvoiceNumber()
        {
            // FBR-compliant invoice number format: 1 + YYMMDD + 7 random digits
            return $"1{DateTime.Now:yyMMdd}{new Random().Next(1000000, 9999999)}";
        }

        private bool ValidateItemInputs()
        {
            if (string.IsNullOrWhiteSpace(txtHsCode.Text))
            {
                MessageBox.Show("HS Code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHsCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Item Description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemName.Focus();
                return false;
            }

            if (!decimal.TryParse(txtQuantity.Text, out decimal qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }

            if (!decimal.TryParse(txtRate.Text, out decimal rate) || rate <= 0)
            {
                MessageBox.Show("Rate must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRate.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateInvoice()
        {
            if (string.IsNullOrWhiteSpace(txtSellerNTN.Text))
            {
                MessageBox.Show("Seller NTN/CNIC is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSellerNTN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSellerName.Text))
            {
                MessageBox.Show("Seller Business Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSellerName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBuyerName.Text))
            {
                MessageBox.Show("Buyer Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuyerName.Focus();
                return false;
            }

            if (_itemsList.Count == 0)
            {
                MessageBox.Show("Invoice must have at least one item.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var selectedScenario = ((KeyValuePair<string, string>)cmbScenario.SelectedItem).Key;
            if ((selectedScenario == "SN001" || selectedScenario == "SN003" || selectedScenario == "SN009") && !rdoRegistered.Checked)
            {
                MessageBox.Show("Registered buyer is required for this scenario.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Color primaryColor = Color.FromArgb(50, 50, 50);
            Color accentColor = Color.FromArgb(70, 130, 180);
            Color lightGray = Color.FromArgb(245, 245, 245);

            Font headerFont = new Font("Segoe UI", 24, FontStyle.Bold);
            Font companyFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Font invoiceFont = new Font("Segoe UI", 9, FontStyle.Regular);
            Font sectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font tableHeaderFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font tableBodyFont = new Font("Segoe UI", 9, FontStyle.Regular);
            Font totalFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font footerFont = new Font("Segoe UI", 8, FontStyle.Italic);

            float leftMargin = e.MarginBounds.Left + 20;
            float rightMargin = e.MarginBounds.Right - 20;
            float contentWidth = rightMargin - leftMargin;
            float yPos = e.MarginBounds.Top + 20;

            // Header Section with FBR Logo
            g.DrawLine(new Pen(accentColor, 1.5f), leftMargin, yPos - 10, rightMargin, yPos - 10);
            yPos += 10;

            // Draw FBR logo
            if (_fbrLogo != null)
            {
                g.DrawImage(_fbrLogo, leftMargin, yPos, 120, 60);
            }

            float companyX = leftMargin + 130;
            g.DrawString("FBR DIGITAL INVOICE", headerFont, new SolidBrush(accentColor), companyX, yPos);
            yPos += headerFont.Height + 5;

            using (StringFormat format = new StringFormat { LineAlignment = StringAlignment.Center })
            {
                g.DrawString(txtSellerName.Text, companyFont, new SolidBrush(primaryColor),
                        companyX, yPos, format);
                yPos += companyFont.Height;
                g.DrawString(txtSellerAddress.Text,
                        companyFont, new SolidBrush(primaryColor), companyX, yPos, format);
                yPos += companyFont.Height + 20;
            }

            // Invoice Meta Section
            RectangleF metaPanel = new RectangleF(leftMargin, yPos, contentWidth, 40);
            g.FillRectangle(new SolidBrush(lightGray), metaPanel);

            string scenarioText = ((KeyValuePair<string, string>)cmbScenario.SelectedItem).Value;

            using (StringFormat rightAlign = new StringFormat { Alignment = StringAlignment.Far })
            {
                g.DrawString($"Invoice No: {_lastInvoiceNumber}", invoiceFont, new SolidBrush(primaryColor),
                        leftMargin, yPos + 12);
                g.DrawString($"Date: {dtpInvoiceDate.Value:dd-MMM-yyyy}", invoiceFont, new SolidBrush(primaryColor),
                        rightMargin, yPos + 12, rightAlign);
                g.DrawString($"Scenario: {scenarioText}", invoiceFont, new SolidBrush(primaryColor),
                        leftMargin, yPos + 30);
            }
            yPos += metaPanel.Height + 15;

            // Customer Section
            g.DrawString("Buyer's Information:", sectionFont, new SolidBrush(accentColor), leftMargin, yPos);
            yPos += sectionFont.Height + 10;

            RectangleF customerPanel = new RectangleF(leftMargin, yPos, contentWidth, 80);
            g.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), customerPanel);
            g.DrawRectangle(new Pen(Color.LightGray, 0.5f), customerPanel.X, customerPanel.Y, customerPanel.Width, customerPanel.Height);

            float customerContentY = yPos + 10;
            g.DrawString(txtBuyerName.Text, tableBodyFont, new SolidBrush(primaryColor), leftMargin + 10, customerContentY);
            customerContentY += tableBodyFont.Height;
            g.DrawString(txtBuyerAddress.Text, tableBodyFont, new SolidBrush(primaryColor), leftMargin + 10, customerContentY);
            customerContentY += tableBodyFont.Height;
            g.DrawString($"CNIC/NTN: {txtBuyerCNIC.Text}", tableBodyFont, new SolidBrush(primaryColor), leftMargin + 10, customerContentY);
            customerContentY += tableBodyFont.Height;
            g.DrawString($"Province: {cmbBuyerProvince.Text}", tableBodyFont, new SolidBrush(primaryColor), leftMargin + 10, customerContentY);

            yPos += customerPanel.Height + 20;

            // Items Table
            float[] columnWidths = { contentWidth * 0.35f, contentWidth * 0.1f, contentWidth * 0.1f,
                  contentWidth * 0.1f, contentWidth * 0.1f, contentWidth * 0.1f, contentWidth * 0.15f };
            string[] headers = { "Description", "HS Code", "Qty", "UoM", "Rate", "Tax", "Amount" };

            RectangleF headerRect = new RectangleF(leftMargin, yPos, contentWidth, 30);
            g.FillRectangle(new SolidBrush(accentColor), headerRect);

            float headerTextY = yPos + (headerRect.Height - tableHeaderFont.Height) / 2;
            float x = leftMargin;
            for (int i = 0; i < headers.Length; i++)
            {
                RectangleF colRect = new RectangleF(x, headerTextY, columnWidths[i], tableHeaderFont.Height);
                using (StringFormat format = i == 0 ? StringFormat.GenericDefault :
                    new StringFormat { Alignment = StringAlignment.Far })
                {
                    g.DrawString(headers[i], tableHeaderFont, Brushes.White, colRect, format);
                }
                x += columnWidths[i];
            }
            yPos += headerRect.Height;

            bool alternate = false;
            foreach (var item in _itemsList)
            {
                RectangleF rowRect = new RectangleF(leftMargin, yPos, contentWidth, 20);
                if (alternate)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(248, 248, 248)), rowRect);
                }

                x = leftMargin;
                g.DrawString(item.ProductDescription, tableBodyFont, new SolidBrush(primaryColor),
                        new RectangleF(x, yPos, columnWidths[0], 20));
                x += columnWidths[0];

                g.DrawString(item.HsCode, tableBodyFont, new SolidBrush(primaryColor),
                        new RectangleF(x, yPos, columnWidths[1], 20),
                        new StringFormat { Alignment = StringAlignment.Center });
                x += columnWidths[1];

                g.DrawString(item.Quantity.ToString("N2"), tableBodyFont, new SolidBrush(primaryColor),
                        new RectangleF(x, yPos, columnWidths[2], 20),
                        new StringFormat { Alignment = StringAlignment.Far });
                x += columnWidths[2];

                g.DrawString(item.UoM, tableBodyFont, new SolidBrush(primaryColor),
                        new RectangleF(x, yPos, columnWidths[3], 20),
                        new StringFormat { Alignment = StringAlignment.Center });
                x += columnWidths[3];

                g.DrawString(item.Rate.ToString("N2"), tableBodyFont, new SolidBrush(primaryColor),
                        new RectangleF(x, yPos, columnWidths[4], 20),
                        new StringFormat { Alignment = StringAlignment.Far });
                x += columnWidths[4];

                g.DrawString(item.TaxRate.ToString("P0"), tableBodyFont, new SolidBrush(primaryColor),
                        new RectangleF(x, yPos, columnWidths[5], 20),
                        new StringFormat { Alignment = StringAlignment.Far });
                x += columnWidths[5];

                g.DrawString(item.AmountIncludingTax.ToString("N2"), tableBodyFont, new SolidBrush(primaryColor),
                        new RectangleF(x, yPos, columnWidths[6], 20),
                        new StringFormat { Alignment = StringAlignment.Far });

                yPos += 20;
                alternate = !alternate;
            }

            // Totals Section
            yPos += 20;
            g.DrawLine(new Pen(accentColor, 1.5f), leftMargin + contentWidth * 0.5f, yPos, rightMargin, yPos);
            yPos += 15;

            DrawAmountRow(g, "Sub Total:", txtGrossTotal.Text,
                    leftMargin + contentWidth * 0.5f, rightMargin, ref yPos,
                    totalFont, tableBodyFont, new SolidBrush(primaryColor));

            DrawAmountRow(g, "Sales Tax:", txtTaxAmount.Text,
                    leftMargin + contentWidth * 0.5f, rightMargin, ref yPos,
                    totalFont, tableBodyFont, new SolidBrush(primaryColor));

            DrawAmountRow(g, "Further Tax:", txtFurtherTax.Text,
                    leftMargin + contentWidth * 0.4f, rightMargin, ref yPos,
                    totalFont, tableBodyFont, new SolidBrush(primaryColor));

            DrawAmountRow(g, "Extra Tax:", txtExtraTax.Text,
                    leftMargin + contentWidth * 0.5f, rightMargin, ref yPos,
                    totalFont, tableBodyFont, new SolidBrush(primaryColor));

            DrawAmountRow(g, "Total Amount:", txtInclTax.Text,
                    leftMargin + contentWidth * 0.5f, rightMargin, ref yPos,
                    new Font(totalFont, FontStyle.Bold | FontStyle.Underline),
                    new Font(tableBodyFont, FontStyle.Bold), new SolidBrush(accentColor));

            // Footer Section
            yPos += 40;
            g.DrawLine(new Pen(Color.LightGray, 0.5f), leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            string footerText = "Thank you for your business! | This is an FBR compliant digital invoice";
            SizeF footerSize = g.MeasureString(footerText, footerFont);
            g.DrawString(footerText, footerFont, new SolidBrush(primaryColor),
                    leftMargin + (contentWidth - footerSize.Width) / 2, yPos);
        }

        private void DrawAmountRow(Graphics g, string label, string value,
                 float left, float right, ref float yPos,
                 Font labelFont, Font valueFont, Brush brush)
        {
            float valueWidth = 100;
            float labelWidth = right - left - valueWidth - 10;

            g.DrawString(label, labelFont, brush,
                    new RectangleF(left, yPos, labelWidth, labelFont.Height),
                    new StringFormat { Alignment = StringAlignment.Far });

            g.DrawString(value, valueFont, brush,
                    new RectangleF(right - valueWidth, yPos, valueWidth, valueFont.Height),
                    new StringFormat { Alignment = StringAlignment.Far });

            yPos += labelFont.Height + 5;
        }
    }

    public class InvoiceItem
    {
        public string HsCode { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string UoM { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public decimal TaxRate { get; set; }
        public decimal FurtherTax { get; set; }
        public decimal ExtraTax { get; set; }
        public string SroScheduleNo { get; set; } = string.Empty;
        public decimal FedPayable { get; set; }
        public decimal Discount { get; set; }
        public string SaleType { get; set; } = string.Empty;
        public string SroItemSerialNo { get; set; } = string.Empty;

        public decimal ValueExcludingTax => Quantity * Rate;
        public decimal TaxAmount => ValueExcludingTax * TaxRate;
        public decimal AmountIncludingTax => ValueExcludingTax + TaxAmount + FurtherTax + ExtraTax - Discount;

        public override string ToString()
        {
            return $"{ProductDescription} - {Quantity} {UoM} @ {Rate:N2}";
        }
    }

    public class InvoiceResponse
    {
        public string InvoiceNumber { get; set; }
        public string Dated { get; set; }
        public string USIN { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}