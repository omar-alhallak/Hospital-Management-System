namespace Hospital_Management_System_WinForm.FormUI
{
    partial class DoctorsForm
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
            btnAddDoctor = new Button();
            btnUpdateDoctor = new Button();
            btnDeleteDoctor = new Button();
            btnUpdateFixedStaffSalary = new Button();
            btnPromoteTraineeDoctor = new Button();
            btnDisplay = new Button();
            btnSearch = new Button();
            btnBack = new Button();
            lblFixedSalary = new Label();
            panel1 = new Panel();
            dgvDoctors = new DataGridView();
            lblSelectedDoctorSection = new Label();
            lblSelectedDoctorName = new Label();
            txtSelectedDoctorName = new TextBox();
            lblSelectedDoctorAddress = new Label();
            txtSelectedDoctorAddress = new TextBox();
            lblSelectedDoctorBirthDate = new Label();
            dtpSelectedDoctorBirthDate = new DateTimePicker();
            grpDoctorAction = new GroupBox();
            btnClearDoctor = new Button();
            btnSaveDoctor = new Button();
            txtExtra2 = new TextBox();
            lblExtra2 = new Label();
            txtExtra1 = new TextBox();
            lblExtra1 = new Label();
            dtpBirthDate = new DateTimePicker();
            lblBirthDate = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtDoctorName = new TextBox();
            lblDoctorName = new Label();
            txtDoctorID = new TextBox();
            lblDoctorID = new Label();
            cmbDoctorType = new ComboBox();
            lblDoctorType = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).BeginInit();
            grpDoctorAction.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddDoctor
            // 
            btnAddDoctor.AutoSize = true;
            btnAddDoctor.BackColor = Color.DarkGray;
            btnAddDoctor.FlatAppearance.BorderColor = Color.Red;
            btnAddDoctor.FlatAppearance.BorderSize = 0;
            btnAddDoctor.FlatStyle = FlatStyle.Flat;
            btnAddDoctor.Font = new Font("Microsoft Sans Serif", 12F);
            btnAddDoctor.ForeColor = Color.WhiteSmoke;
            btnAddDoctor.Location = new Point(10, 12);
            btnAddDoctor.Name = "btnAddDoctor";
            btnAddDoctor.Size = new Size(132, 39);
            btnAddDoctor.TabIndex = 0;
            btnAddDoctor.Text = "Add Doctor";
            btnAddDoctor.UseVisualStyleBackColor = false;
            btnAddDoctor.Click += btnAddDoctor_Click;
            // 
            // btnUpdateDoctor
            // 
            btnUpdateDoctor.AutoSize = true;
            btnUpdateDoctor.BackColor = Color.DarkGray;
            btnUpdateDoctor.FlatAppearance.BorderColor = Color.Red;
            btnUpdateDoctor.FlatAppearance.BorderSize = 0;
            btnUpdateDoctor.FlatStyle = FlatStyle.Flat;
            btnUpdateDoctor.Font = new Font("Microsoft Sans Serif", 12F);
            btnUpdateDoctor.ForeColor = Color.WhiteSmoke;
            btnUpdateDoctor.Location = new Point(148, 12);
            btnUpdateDoctor.Name = "btnUpdateDoctor";
            btnUpdateDoctor.Size = new Size(162, 39);
            btnUpdateDoctor.TabIndex = 0;
            btnUpdateDoctor.Text = "Update Doctor";
            btnUpdateDoctor.UseVisualStyleBackColor = false;
            btnUpdateDoctor.Click += btnUpdateDoctor_Click;
            // 
            // btnDeleteDoctor
            // 
            btnDeleteDoctor.AutoSize = true;
            btnDeleteDoctor.BackColor = Color.DarkGray;
            btnDeleteDoctor.FlatAppearance.BorderColor = Color.Red;
            btnDeleteDoctor.FlatAppearance.BorderSize = 0;
            btnDeleteDoctor.FlatStyle = FlatStyle.Flat;
            btnDeleteDoctor.Font = new Font("Microsoft Sans Serif", 12F);
            btnDeleteDoctor.ForeColor = Color.WhiteSmoke;
            btnDeleteDoctor.Location = new Point(315, 12);
            btnDeleteDoctor.Name = "btnDeleteDoctor";
            btnDeleteDoctor.Size = new Size(155, 39);
            btnDeleteDoctor.TabIndex = 0;
            btnDeleteDoctor.Text = "Delete Doctor";
            btnDeleteDoctor.UseVisualStyleBackColor = false;
            btnDeleteDoctor.Click += btnDeleteDoctor_Click;
            // 
            // btnUpdateFixedStaffSalary
            // 
            btnUpdateFixedStaffSalary.AutoSize = true;
            btnUpdateFixedStaffSalary.BackColor = Color.DarkGray;
            btnUpdateFixedStaffSalary.FlatAppearance.BorderColor = Color.Red;
            btnUpdateFixedStaffSalary.FlatAppearance.BorderSize = 0;
            btnUpdateFixedStaffSalary.FlatStyle = FlatStyle.Flat;
            btnUpdateFixedStaffSalary.Font = new Font("Microsoft Sans Serif", 12F);
            btnUpdateFixedStaffSalary.ForeColor = Color.WhiteSmoke;
            btnUpdateFixedStaffSalary.Location = new Point(476, 12);
            btnUpdateFixedStaffSalary.Name = "btnUpdateFixedStaffSalary";
            btnUpdateFixedStaffSalary.Size = new Size(269, 39);
            btnUpdateFixedStaffSalary.TabIndex = 0;
            btnUpdateFixedStaffSalary.Text = "Update Fixed Staff Salary";
            btnUpdateFixedStaffSalary.UseVisualStyleBackColor = false;
            btnUpdateFixedStaffSalary.Click += btnUpdateFixedStaffSalary_Click;
            // 
            // btnPromoteTraineeDoctor
            // 
            btnPromoteTraineeDoctor.AutoSize = true;
            btnPromoteTraineeDoctor.BackColor = Color.DarkGray;
            btnPromoteTraineeDoctor.FlatAppearance.BorderColor = Color.Red;
            btnPromoteTraineeDoctor.FlatAppearance.BorderSize = 0;
            btnPromoteTraineeDoctor.FlatStyle = FlatStyle.Flat;
            btnPromoteTraineeDoctor.Font = new Font("Microsoft Sans Serif", 12F);
            btnPromoteTraineeDoctor.ForeColor = Color.WhiteSmoke;
            btnPromoteTraineeDoctor.Location = new Point(751, 12);
            btnPromoteTraineeDoctor.Name = "btnPromoteTraineeDoctor";
            btnPromoteTraineeDoctor.Size = new Size(246, 39);
            btnPromoteTraineeDoctor.TabIndex = 0;
            btnPromoteTraineeDoctor.Text = "Promote Trainee Doctor";
            btnPromoteTraineeDoctor.UseVisualStyleBackColor = false;
            btnPromoteTraineeDoctor.Click += btnPromoteTraineeDoctor_Click;
            // 
            // btnDisplay
            // 
            btnDisplay.AutoSize = true;
            btnDisplay.BackColor = Color.DarkGray;
            btnDisplay.FlatAppearance.BorderColor = Color.Red;
            btnDisplay.FlatAppearance.BorderSize = 0;
            btnDisplay.FlatStyle = FlatStyle.Flat;
            btnDisplay.Font = new Font("Microsoft Sans Serif", 12F);
            btnDisplay.ForeColor = Color.WhiteSmoke;
            btnDisplay.Location = new Point(10, 60);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(95, 39);
            btnDisplay.TabIndex = 0;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = false;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.BackColor = Color.DarkGray;
            btnSearch.FlatAppearance.BorderColor = Color.Red;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F);
            btnSearch.ForeColor = Color.WhiteSmoke;
            btnSearch.Location = new Point(111, 60);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(99, 39);
            btnSearch.TabIndex = 0;
            btnSearch.Text = " Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnBack
            // 
            btnBack.AutoSize = true;
            btnBack.BackColor = Color.DarkGray;
            btnBack.FlatAppearance.BorderColor = Color.Red;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Microsoft Sans Serif", 12F);
            btnBack.ForeColor = Color.WhiteSmoke;
            btnBack.Location = new Point(218, 60);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 39);
            btnBack.TabIndex = 0;
            btnBack.Text = " Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblFixedSalary
            // 
            lblFixedSalary.AutoSize = true;
            lblFixedSalary.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFixedSalary.Location = new Point(10, 135);
            lblFixedSalary.Name = "lblFixedSalary";
            lblFixedSalary.Size = new Size(267, 22);
            lblFixedSalary.TabIndex = 1;
            lblFixedSalary.Text = "Current Fixed Staff Salary: 1000";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Location = new Point(15, 119);
            panel1.Name = "panel1";
            panel1.Size = new Size(982, 1);
            panel1.TabIndex = 2;
            // 
            // dgvDoctors
            // 
            dgvDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoctors.Location = new Point(10, 172);
            dgvDoctors.Name = "dgvDoctors";
            dgvDoctors.RowHeadersWidth = 51;
            dgvDoctors.Size = new Size(577, 269);
            dgvDoctors.TabIndex = 3;
            // 
            // lblSelectedDoctorSection
            // 
            lblSelectedDoctorSection.AutoSize = true;
            lblSelectedDoctorSection.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            lblSelectedDoctorSection.Location = new Point(10, 454);
            lblSelectedDoctorSection.Name = "lblSelectedDoctorSection";
            lblSelectedDoctorSection.Size = new Size(137, 20);
            lblSelectedDoctorSection.TabIndex = 4;
            lblSelectedDoctorSection.Text = "Selected Doctor";
            lblSelectedDoctorSection.Visible = false;
            // 
            // lblSelectedDoctorName
            // 
            lblSelectedDoctorName.AutoSize = true;
            lblSelectedDoctorName.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedDoctorName.Location = new Point(10, 486);
            lblSelectedDoctorName.Name = "lblSelectedDoctorName";
            lblSelectedDoctorName.Size = new Size(109, 20);
            lblSelectedDoctorName.TabIndex = 5;
            lblSelectedDoctorName.Text = "Doctor Name";
            lblSelectedDoctorName.Visible = false;
            // 
            // txtSelectedDoctorName
            // 
            txtSelectedDoctorName.Location = new Point(144, 482);
            txtSelectedDoctorName.Name = "txtSelectedDoctorName";
            txtSelectedDoctorName.Size = new Size(220, 27);
            txtSelectedDoctorName.TabIndex = 6;
            txtSelectedDoctorName.Visible = false;
            // 
            // lblSelectedDoctorAddress
            // 
            lblSelectedDoctorAddress.AutoSize = true;
            lblSelectedDoctorAddress.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedDoctorAddress.Location = new Point(10, 520);
            lblSelectedDoctorAddress.Name = "lblSelectedDoctorAddress";
            lblSelectedDoctorAddress.Size = new Size(71, 20);
            lblSelectedDoctorAddress.TabIndex = 7;
            lblSelectedDoctorAddress.Text = "Address";
            lblSelectedDoctorAddress.Visible = false;
            // 
            // txtSelectedDoctorAddress
            // 
            txtSelectedDoctorAddress.Location = new Point(144, 516);
            txtSelectedDoctorAddress.Name = "txtSelectedDoctorAddress";
            txtSelectedDoctorAddress.Size = new Size(220, 27);
            txtSelectedDoctorAddress.TabIndex = 8;
            txtSelectedDoctorAddress.Visible = false;
            // 
            // lblSelectedDoctorBirthDate
            // 
            lblSelectedDoctorBirthDate.AutoSize = true;
            lblSelectedDoctorBirthDate.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedDoctorBirthDate.Location = new Point(10, 554);
            lblSelectedDoctorBirthDate.Name = "lblSelectedDoctorBirthDate";
            lblSelectedDoctorBirthDate.Size = new Size(86, 20);
            lblSelectedDoctorBirthDate.TabIndex = 9;
            lblSelectedDoctorBirthDate.Text = "Birth Date";
            lblSelectedDoctorBirthDate.Visible = false;
            // 
            // dtpSelectedDoctorBirthDate
            // 
            dtpSelectedDoctorBirthDate.Format = DateTimePickerFormat.Short;
            dtpSelectedDoctorBirthDate.Location = new Point(144, 550);
            dtpSelectedDoctorBirthDate.Name = "dtpSelectedDoctorBirthDate";
            dtpSelectedDoctorBirthDate.Size = new Size(220, 27);
            dtpSelectedDoctorBirthDate.TabIndex = 10;
            dtpSelectedDoctorBirthDate.Visible = false;
            // 
            // grpDoctorAction
            // 
            grpDoctorAction.BackColor = SystemColors.ControlDark;
            grpDoctorAction.Controls.Add(btnClearDoctor);
            grpDoctorAction.Controls.Add(btnSaveDoctor);
            grpDoctorAction.Controls.Add(txtExtra2);
            grpDoctorAction.Controls.Add(lblExtra2);
            grpDoctorAction.Controls.Add(txtExtra1);
            grpDoctorAction.Controls.Add(lblExtra1);
            grpDoctorAction.Controls.Add(dtpBirthDate);
            grpDoctorAction.Controls.Add(lblBirthDate);
            grpDoctorAction.Controls.Add(txtAddress);
            grpDoctorAction.Controls.Add(lblAddress);
            grpDoctorAction.Controls.Add(txtDoctorName);
            grpDoctorAction.Controls.Add(lblDoctorName);
            grpDoctorAction.Controls.Add(txtDoctorID);
            grpDoctorAction.Controls.Add(lblDoctorID);
            grpDoctorAction.Controls.Add(cmbDoctorType);
            grpDoctorAction.Controls.Add(lblDoctorType);
            grpDoctorAction.Location = new Point(593, 135);
            grpDoctorAction.Name = "grpDoctorAction";
            grpDoctorAction.Size = new Size(402, 446);
            grpDoctorAction.TabIndex = 4;
            grpDoctorAction.TabStop = false;
            grpDoctorAction.Text = "Doctor Action";
            // 
            // btnClearDoctor
            // 
            btnClearDoctor.BackColor = Color.Gainsboro;
            btnClearDoctor.FlatAppearance.BorderSize = 0;
            btnClearDoctor.FlatStyle = FlatStyle.Flat;
            btnClearDoctor.ForeColor = Color.Black;
            btnClearDoctor.Location = new Point(158, 401);
            btnClearDoctor.Name = "btnClearDoctor";
            btnClearDoctor.Size = new Size(133, 29);
            btnClearDoctor.TabIndex = 15;
            btnClearDoctor.Text = "Clear";
            btnClearDoctor.UseVisualStyleBackColor = false;
            btnClearDoctor.Click += btnClearDoctor_Click;
            // 
            // btnSaveDoctor
            // 
            btnSaveDoctor.BackColor = Color.FromArgb(126, 192, 238);
            btnSaveDoctor.FlatAppearance.BorderSize = 0;
            btnSaveDoctor.FlatStyle = FlatStyle.Flat;
            btnSaveDoctor.ForeColor = Color.White;
            btnSaveDoctor.Location = new Point(21, 401);
            btnSaveDoctor.Name = "btnSaveDoctor";
            btnSaveDoctor.Size = new Size(131, 29);
            btnSaveDoctor.TabIndex = 14;
            btnSaveDoctor.Text = "Add";
            btnSaveDoctor.UseVisualStyleBackColor = false;
            btnSaveDoctor.Click += btnSaveDoctor_Click;
            // 
            // txtExtra2
            // 
            txtExtra2.Location = new Point(186, 354);
            txtExtra2.Name = "txtExtra2";
            txtExtra2.Size = new Size(210, 27);
            txtExtra2.TabIndex = 13;
            // 
            // lblExtra2
            // 
            lblExtra2.AutoSize = true;
            lblExtra2.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblExtra2.Location = new Point(11, 354);
            lblExtra2.Name = "lblExtra2";
            lblExtra2.Size = new Size(67, 20);
            lblExtra2.TabIndex = 12;
            lblExtra2.Text = "Extra 2:";
            // 
            // txtExtra1
            // 
            txtExtra1.Location = new Point(186, 289);
            txtExtra1.Name = "txtExtra1";
            txtExtra1.Size = new Size(210, 27);
            txtExtra1.TabIndex = 11;
            // 
            // lblExtra1
            // 
            lblExtra1.AutoSize = true;
            lblExtra1.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblExtra1.Location = new Point(11, 289);
            lblExtra1.Name = "lblExtra1";
            lblExtra1.Size = new Size(67, 20);
            lblExtra1.TabIndex = 10;
            lblExtra1.Text = "Extra 1:";
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
            // txtDoctorName
            // 
            txtDoctorName.Location = new Point(186, 134);
            txtDoctorName.Name = "txtDoctorName";
            txtDoctorName.Size = new Size(210, 27);
            txtDoctorName.TabIndex = 5;
            // 
            // lblDoctorName
            // 
            lblDoctorName.AutoSize = true;
            lblDoctorName.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblDoctorName.Location = new Point(6, 134);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Size = new Size(109, 20);
            lblDoctorName.TabIndex = 4;
            lblDoctorName.Text = "Doctor Name";
            // 
            // txtDoctorID
            // 
            txtDoctorID.Location = new Point(186, 83);
            txtDoctorID.Name = "txtDoctorID";
            txtDoctorID.Size = new Size(210, 27);
            txtDoctorID.TabIndex = 3;
            // 
            // lblDoctorID
            // 
            lblDoctorID.AutoSize = true;
            lblDoctorID.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblDoctorID.Location = new Point(6, 83);
            lblDoctorID.Name = "lblDoctorID";
            lblDoctorID.Size = new Size(82, 20);
            lblDoctorID.TabIndex = 2;
            lblDoctorID.Text = "Doctor ID";
            // 
            // cmbDoctorType
            // 
            cmbDoctorType.FormattingEnabled = true;
            cmbDoctorType.Items.AddRange(new object[] { "Staff Doctor", "Trainee Doctor", "Contract Doctor" });
            cmbDoctorType.Location = new Point(186, 37);
            cmbDoctorType.Name = "cmbDoctorType";
            cmbDoctorType.Size = new Size(210, 28);
            cmbDoctorType.TabIndex = 1;
            cmbDoctorType.SelectedIndexChanged += cmbDoctorType_SelectedIndexChanged;
            // 
            // lblDoctorType
            // 
            lblDoctorType.AutoSize = true;
            lblDoctorType.BackColor = SystemColors.ControlDark;
            lblDoctorType.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblDoctorType.Location = new Point(6, 37);
            lblDoctorType.Name = "lblDoctorType";
            lblDoctorType.Size = new Size(101, 20);
            lblDoctorType.TabIndex = 0;
            lblDoctorType.Text = "Doctor Type";
            // 
            // DoctorsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1007, 603);
            Controls.Add(grpDoctorAction);
            Controls.Add(dtpSelectedDoctorBirthDate);
            Controls.Add(lblSelectedDoctorBirthDate);
            Controls.Add(txtSelectedDoctorAddress);
            Controls.Add(lblSelectedDoctorAddress);
            Controls.Add(txtSelectedDoctorName);
            Controls.Add(lblSelectedDoctorName);
            Controls.Add(lblSelectedDoctorSection);
            Controls.Add(dgvDoctors);
            Controls.Add(panel1);
            Controls.Add(lblFixedSalary);
            Controls.Add(btnBack);
            Controls.Add(btnSearch);
            Controls.Add(btnDisplay);
            Controls.Add(btnPromoteTraineeDoctor);
            Controls.Add(btnUpdateFixedStaffSalary);
            Controls.Add(btnDeleteDoctor);
            Controls.Add(btnUpdateDoctor);
            Controls.Add(btnAddDoctor);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DoctorsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Doctors Management";
            Load += DoctorsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).EndInit();
            grpDoctorAction.ResumeLayout(false);
            grpDoctorAction.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddDoctor;
        private Button btnUpdateDoctor;
        private Button btnDeleteDoctor;
        private Button btnUpdateFixedStaffSalary;
        private Button btnPromoteTraineeDoctor;
        private Button btnDisplay;
        private Button btnSearch;
        private Button btnBack;
        private Label lblFixedSalary;
        private Panel panel1;
        private DataGridView dgvDoctors;
        private Label lblSelectedDoctorSection;
        private Label lblSelectedDoctorName;
        private TextBox txtSelectedDoctorName;
        private Label lblSelectedDoctorAddress;
        private TextBox txtSelectedDoctorAddress;
        private Label lblSelectedDoctorBirthDate;
        private DateTimePicker dtpSelectedDoctorBirthDate;
        private GroupBox grpDoctorAction;
        private ComboBox cmbDoctorType;
        private Label lblDoctorType;    
        private TextBox txtDoctorName;
        private Label lblDoctorName;
        private TextBox txtDoctorID;
        private Label lblDoctorID;
        private Label lblExtra2;
        private TextBox txtExtra1;
        private Label lblExtra1;
        private DateTimePicker dtpBirthDate;
        private Label lblBirthDate;
        private TextBox txtAddress;
        private Label lblAddress;
        private Button btnClearDoctor;
        private Button btnSaveDoctor;
        private TextBox txtExtra2;
    }
}
