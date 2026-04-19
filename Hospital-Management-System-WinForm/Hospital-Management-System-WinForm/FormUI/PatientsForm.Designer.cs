namespace Hospital_Management_System_WinForm.FormUI
{
    partial class PatientsForm
    {
        private System.ComponentModel.IContainer components = null;

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
            btnAddPatient = new Button();
            btnUpdatePatient = new Button();
            btnDeletePatient = new Button();
            btnDischargeInternalPatient = new Button();
            btnAcceptExternalPatient = new Button();
            btnDisplay = new Button();
            btnSearch = new Button();
            btnBack = new Button();
            panel1 = new Panel();
            dgvPatients = new DataGridView();
            grpPatientAction = new GroupBox();
            btnClearPatient = new Button();
            btnSavePatient = new Button();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            dtpBirthDate = new DateTimePicker();
            lblBirthDate = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPatientName = new TextBox();
            lblPatientName = new Label();
            txtPatientID = new TextBox();
            lblPatientID = new Label();
            cmbPatientType = new ComboBox();
            lblPatientType = new Label();
            lblSelectedPatientSection = new Label();
            lblSelectedPatientName = new Label();
            txtSelectedPatientName = new TextBox();
            lblSelectedPatientAddress = new Label();
            txtSelectedPatientAddress = new TextBox();
            lblSelectedPatientBirthDate = new Label();
            dtpSelectedPatientBirthDate = new DateTimePicker();
            lblSelectedPatientStatus = new Label();
            cmbSelectedPatientStatus = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            grpPatientAction.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddPatient
            // 
            btnAddPatient.AutoSize = true;
            btnAddPatient.BackColor = Color.DarkGray;
            btnAddPatient.FlatAppearance.BorderSize = 0;
            btnAddPatient.FlatStyle = FlatStyle.Flat;
            btnAddPatient.Font = new Font("Microsoft Sans Serif", 12F);
            btnAddPatient.ForeColor = Color.WhiteSmoke;
            btnAddPatient.Location = new Point(10, 12);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(135, 39);
            btnAddPatient.TabIndex = 0;
            btnAddPatient.Text = "Add Patient";
            btnAddPatient.UseVisualStyleBackColor = false;
            btnAddPatient.Click += btnAddPatient_Click;
            // 
            // btnUpdatePatient
            // 
            btnUpdatePatient.AutoSize = true;
            btnUpdatePatient.BackColor = Color.DarkGray;
            btnUpdatePatient.FlatAppearance.BorderSize = 0;
            btnUpdatePatient.FlatStyle = FlatStyle.Flat;
            btnUpdatePatient.Font = new Font("Microsoft Sans Serif", 12F);
            btnUpdatePatient.ForeColor = Color.WhiteSmoke;
            btnUpdatePatient.Location = new Point(151, 12);
            btnUpdatePatient.Name = "btnUpdatePatient";
            btnUpdatePatient.Size = new Size(165, 39);
            btnUpdatePatient.TabIndex = 1;
            btnUpdatePatient.Text = "Update Patient";
            btnUpdatePatient.UseVisualStyleBackColor = false;
            btnUpdatePatient.Click += btnUpdatePatient_Click;
            // 
            // btnDeletePatient
            // 
            btnDeletePatient.AutoSize = true;
            btnDeletePatient.BackColor = Color.DarkGray;
            btnDeletePatient.FlatAppearance.BorderSize = 0;
            btnDeletePatient.FlatStyle = FlatStyle.Flat;
            btnDeletePatient.Font = new Font("Microsoft Sans Serif", 12F);
            btnDeletePatient.ForeColor = Color.WhiteSmoke;
            btnDeletePatient.Location = new Point(322, 12);
            btnDeletePatient.Name = "btnDeletePatient";
            btnDeletePatient.Size = new Size(157, 39);
            btnDeletePatient.TabIndex = 2;
            btnDeletePatient.Text = "Delete Patient";
            btnDeletePatient.UseVisualStyleBackColor = false;
            btnDeletePatient.Click += btnDeletePatient_Click;
            // 
            // btnDischargeInternalPatient
            // 
            btnDischargeInternalPatient.AutoSize = true;
            btnDischargeInternalPatient.BackColor = Color.DarkGray;
            btnDischargeInternalPatient.FlatAppearance.BorderSize = 0;
            btnDischargeInternalPatient.FlatStyle = FlatStyle.Flat;
            btnDischargeInternalPatient.Font = new Font("Microsoft Sans Serif", 12F);
            btnDischargeInternalPatient.ForeColor = Color.WhiteSmoke;
            btnDischargeInternalPatient.Location = new Point(485, 12);
            btnDischargeInternalPatient.Name = "btnDischargeInternalPatient";
            btnDischargeInternalPatient.Size = new Size(259, 39);
            btnDischargeInternalPatient.TabIndex = 3;
            btnDischargeInternalPatient.Text = "Discharge Internal Patient";
            btnDischargeInternalPatient.UseVisualStyleBackColor = false;
            btnDischargeInternalPatient.Click += btnDischargeInternalPatient_Click;
            // 
            // btnAcceptExternalPatient
            // 
            btnAcceptExternalPatient.AutoSize = true;
            btnAcceptExternalPatient.BackColor = Color.DarkGray;
            btnAcceptExternalPatient.FlatAppearance.BorderSize = 0;
            btnAcceptExternalPatient.FlatStyle = FlatStyle.Flat;
            btnAcceptExternalPatient.Font = new Font("Microsoft Sans Serif", 12F);
            btnAcceptExternalPatient.ForeColor = Color.WhiteSmoke;
            btnAcceptExternalPatient.Location = new Point(750, 12);
            btnAcceptExternalPatient.Name = "btnAcceptExternalPatient";
            btnAcceptExternalPatient.Size = new Size(247, 39);
            btnAcceptExternalPatient.TabIndex = 4;
            btnAcceptExternalPatient.Text = "Accept External Patient";
            btnAcceptExternalPatient.UseVisualStyleBackColor = false;
            btnAcceptExternalPatient.Click += btnAcceptExternalPatient_Click;
            // 
            // btnDisplay
            // 
            btnDisplay.AutoSize = true;
            btnDisplay.BackColor = Color.DarkGray;
            btnDisplay.FlatAppearance.BorderSize = 0;
            btnDisplay.FlatStyle = FlatStyle.Flat;
            btnDisplay.Font = new Font("Microsoft Sans Serif", 12F);
            btnDisplay.ForeColor = Color.WhiteSmoke;
            btnDisplay.Location = new Point(10, 60);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(95, 39);
            btnDisplay.TabIndex = 5;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = false;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.BackColor = Color.DarkGray;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F);
            btnSearch.ForeColor = Color.WhiteSmoke;
            btnSearch.Location = new Point(111, 60);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(99, 39);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnBack
            // 
            btnBack.AutoSize = true;
            btnBack.BackColor = Color.DarkGray;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Microsoft Sans Serif", 12F);
            btnBack.ForeColor = Color.WhiteSmoke;
            btnBack.Location = new Point(216, 60);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(96, 39);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Location = new Point(15, 119);
            panel1.Name = "panel1";
            panel1.Size = new Size(982, 1);
            panel1.TabIndex = 8;
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(10, 135);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.Size = new Size(577, 306);
            dgvPatients.TabIndex = 9;
            // 
            // grpPatientAction
            // 
            grpPatientAction.BackColor = SystemColors.ControlDark;
            grpPatientAction.Controls.Add(btnClearPatient);
            grpPatientAction.Controls.Add(btnSavePatient);
            grpPatientAction.Controls.Add(cmbStatus);
            grpPatientAction.Controls.Add(lblStatus);
            grpPatientAction.Controls.Add(dtpBirthDate);
            grpPatientAction.Controls.Add(lblBirthDate);
            grpPatientAction.Controls.Add(txtAddress);
            grpPatientAction.Controls.Add(lblAddress);
            grpPatientAction.Controls.Add(txtPatientName);
            grpPatientAction.Controls.Add(lblPatientName);
            grpPatientAction.Controls.Add(txtPatientID);
            grpPatientAction.Controls.Add(lblPatientID);
            grpPatientAction.Controls.Add(cmbPatientType);
            grpPatientAction.Controls.Add(lblPatientType);
            grpPatientAction.Location = new Point(593, 135);
            grpPatientAction.Name = "grpPatientAction";
            grpPatientAction.Size = new Size(402, 446);
            grpPatientAction.TabIndex = 10;
            grpPatientAction.TabStop = false;
            grpPatientAction.Text = "Patient Action";
            // 
            // btnClearPatient
            // 
            btnClearPatient.BackColor = Color.Gainsboro;
            btnClearPatient.FlatAppearance.BorderSize = 0;
            btnClearPatient.FlatStyle = FlatStyle.Flat;
            btnClearPatient.ForeColor = Color.Black;
            btnClearPatient.Location = new Point(157, 392);
            btnClearPatient.Name = "btnClearPatient";
            btnClearPatient.Size = new Size(133, 30);
            btnClearPatient.TabIndex = 13;
            btnClearPatient.Text = "Clear";
            btnClearPatient.UseVisualStyleBackColor = false;
            btnClearPatient.Click += btnClearPatient_Click;
            // 
            // btnSavePatient
            // 
            btnSavePatient.BackColor = Color.FromArgb(126, 192, 238);
            btnSavePatient.FlatAppearance.BorderSize = 0;
            btnSavePatient.FlatStyle = FlatStyle.Flat;
            btnSavePatient.ForeColor = Color.White;
            btnSavePatient.Location = new Point(20, 392);
            btnSavePatient.Name = "btnSavePatient";
            btnSavePatient.Size = new Size(131, 30);
            btnSavePatient.TabIndex = 12;
            btnSavePatient.Text = "Add";
            btnSavePatient.UseVisualStyleBackColor = false;
            btnSavePatient.Click += btnSavePatient_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(186, 289);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(210, 28);
            cmbStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblStatus.Location = new Point(6, 289);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 20);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(186, 237);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(210, 27);
            dtpBirthDate.TabIndex = 9;
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblBirthDate.Location = new Point(6, 237);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(86, 20);
            lblBirthDate.TabIndex = 8;
            lblBirthDate.Text = "Birth Date";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(186, 189);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(210, 27);
            txtAddress.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblAddress.Location = new Point(6, 189);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(71, 20);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Address";
            // 
            // txtPatientName
            // 
            txtPatientName.Location = new Point(186, 134);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new Size(210, 27);
            txtPatientName.TabIndex = 5;
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblPatientName.Location = new Point(6, 134);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(112, 20);
            lblPatientName.TabIndex = 4;
            lblPatientName.Text = "Patient Name";
            // 
            // txtPatientID
            // 
            txtPatientID.Location = new Point(186, 83);
            txtPatientID.Name = "txtPatientID";
            txtPatientID.Size = new Size(210, 27);
            txtPatientID.TabIndex = 3;
            // 
            // lblPatientID
            // 
            lblPatientID.AutoSize = true;
            lblPatientID.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblPatientID.Location = new Point(6, 83);
            lblPatientID.Name = "lblPatientID";
            lblPatientID.Size = new Size(85, 20);
            lblPatientID.TabIndex = 2;
            lblPatientID.Text = "Patient ID";
            // 
            // cmbPatientType
            // 
            cmbPatientType.FormattingEnabled = true;
            cmbPatientType.Location = new Point(186, 37);
            cmbPatientType.Name = "cmbPatientType";
            cmbPatientType.Size = new Size(210, 28);
            cmbPatientType.TabIndex = 1;
            cmbPatientType.SelectedIndexChanged += cmbPatientType_SelectedIndexChanged;
            // 
            // lblPatientType
            // 
            lblPatientType.AutoSize = true;
            lblPatientType.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblPatientType.Location = new Point(6, 37);
            lblPatientType.Name = "lblPatientType";
            lblPatientType.Size = new Size(104, 20);
            lblPatientType.TabIndex = 0;
            lblPatientType.Text = "Patient Type";
            // 
            // lblSelectedPatientSection
            // 
            lblSelectedPatientSection.AutoSize = true;
            lblSelectedPatientSection.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            lblSelectedPatientSection.Location = new Point(10, 451);
            lblSelectedPatientSection.Name = "lblSelectedPatientSection";
            lblSelectedPatientSection.Size = new Size(139, 20);
            lblSelectedPatientSection.TabIndex = 11;
            lblSelectedPatientSection.Text = "Selected Patient";
            lblSelectedPatientSection.Visible = false;
            // 
            // lblSelectedPatientName
            // 
            lblSelectedPatientName.AutoSize = true;
            lblSelectedPatientName.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedPatientName.Location = new Point(10, 483);
            lblSelectedPatientName.Name = "lblSelectedPatientName";
            lblSelectedPatientName.Size = new Size(112, 20);
            lblSelectedPatientName.TabIndex = 12;
            lblSelectedPatientName.Text = "Patient Name";
            lblSelectedPatientName.Visible = false;
            // 
            // txtSelectedPatientName
            // 
            txtSelectedPatientName.Location = new Point(144, 479);
            txtSelectedPatientName.Name = "txtSelectedPatientName";
            txtSelectedPatientName.Size = new Size(180, 27);
            txtSelectedPatientName.TabIndex = 13;
            txtSelectedPatientName.Visible = false;
            // 
            // lblSelectedPatientAddress
            // 
            lblSelectedPatientAddress.AutoSize = true;
            lblSelectedPatientAddress.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedPatientAddress.Location = new Point(10, 517);
            lblSelectedPatientAddress.Name = "lblSelectedPatientAddress";
            lblSelectedPatientAddress.Size = new Size(71, 20);
            lblSelectedPatientAddress.TabIndex = 14;
            lblSelectedPatientAddress.Text = "Address";
            lblSelectedPatientAddress.Visible = false;
            // 
            // txtSelectedPatientAddress
            // 
            txtSelectedPatientAddress.Location = new Point(144, 513);
            txtSelectedPatientAddress.Name = "txtSelectedPatientAddress";
            txtSelectedPatientAddress.Size = new Size(180, 27);
            txtSelectedPatientAddress.TabIndex = 15;
            txtSelectedPatientAddress.Visible = false;
            // 
            // lblSelectedPatientBirthDate
            // 
            lblSelectedPatientBirthDate.AutoSize = true;
            lblSelectedPatientBirthDate.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedPatientBirthDate.Location = new Point(10, 551);
            lblSelectedPatientBirthDate.Name = "lblSelectedPatientBirthDate";
            lblSelectedPatientBirthDate.Size = new Size(86, 20);
            lblSelectedPatientBirthDate.TabIndex = 16;
            lblSelectedPatientBirthDate.Text = "Birth Date";
            lblSelectedPatientBirthDate.Visible = false;
            // 
            // dtpSelectedPatientBirthDate
            // 
            dtpSelectedPatientBirthDate.Format = DateTimePickerFormat.Short;
            dtpSelectedPatientBirthDate.Location = new Point(144, 547);
            dtpSelectedPatientBirthDate.Name = "dtpSelectedPatientBirthDate";
            dtpSelectedPatientBirthDate.Size = new Size(180, 27);
            dtpSelectedPatientBirthDate.TabIndex = 17;
            dtpSelectedPatientBirthDate.Visible = false;
            // 
            // lblSelectedPatientStatus
            // 
            lblSelectedPatientStatus.AutoSize = true;
            lblSelectedPatientStatus.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedPatientStatus.Location = new Point(333, 483);
            lblSelectedPatientStatus.Name = "lblSelectedPatientStatus";
            lblSelectedPatientStatus.Size = new Size(56, 20);
            lblSelectedPatientStatus.TabIndex = 18;
            lblSelectedPatientStatus.Text = "Status";
            lblSelectedPatientStatus.Visible = false;
            // 
            // cmbSelectedPatientStatus
            // 
            cmbSelectedPatientStatus.FormattingEnabled = true;
            cmbSelectedPatientStatus.Location = new Point(395, 479);
            cmbSelectedPatientStatus.Name = "cmbSelectedPatientStatus";
            cmbSelectedPatientStatus.Size = new Size(192, 28);
            cmbSelectedPatientStatus.TabIndex = 19;
            cmbSelectedPatientStatus.Visible = false;
            // 
            // PatientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1007, 603);
            Controls.Add(cmbSelectedPatientStatus);
            Controls.Add(lblSelectedPatientStatus);
            Controls.Add(dtpSelectedPatientBirthDate);
            Controls.Add(lblSelectedPatientBirthDate);
            Controls.Add(txtSelectedPatientAddress);
            Controls.Add(lblSelectedPatientAddress);
            Controls.Add(txtSelectedPatientName);
            Controls.Add(lblSelectedPatientName);
            Controls.Add(lblSelectedPatientSection);
            Controls.Add(grpPatientAction);
            Controls.Add(dgvPatients);
            Controls.Add(panel1);
            Controls.Add(btnBack);
            Controls.Add(btnSearch);
            Controls.Add(btnDisplay);
            Controls.Add(btnAcceptExternalPatient);
            Controls.Add(btnDischargeInternalPatient);
            Controls.Add(btnDeletePatient);
            Controls.Add(btnUpdatePatient);
            Controls.Add(btnAddPatient);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "PatientsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Patients Management";
            Load += PatientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            grpPatientAction.ResumeLayout(false);
            grpPatientAction.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddPatient;
        private Button btnUpdatePatient;
        private Button btnDeletePatient;
        private Button btnDischargeInternalPatient;
        private Button btnAcceptExternalPatient;
        private Button btnDisplay;
        private Button btnSearch;
        private Button btnBack;
        private Panel panel1;
        private DataGridView dgvPatients;
        private GroupBox grpPatientAction;
        private Button btnClearPatient;
        private Button btnSavePatient;
        private ComboBox cmbStatus;
        private Label lblStatus;
        private DateTimePicker dtpBirthDate;
        private Label lblBirthDate;
        private TextBox txtAddress;
        private Label lblAddress;
        private TextBox txtPatientName;
        private Label lblPatientName;
        private TextBox txtPatientID;
        private Label lblPatientID;
        private ComboBox cmbPatientType;
        private Label lblPatientType;
        private Label lblSelectedPatientSection;
        private Label lblSelectedPatientName;
        private TextBox txtSelectedPatientName;
        private Label lblSelectedPatientAddress;
        private TextBox txtSelectedPatientAddress;
        private Label lblSelectedPatientBirthDate;
        private DateTimePicker dtpSelectedPatientBirthDate;
        private Label lblSelectedPatientStatus;
        private ComboBox cmbSelectedPatientStatus;
    }
}
