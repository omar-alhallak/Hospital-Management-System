namespace Hospital_Management_System_WinForm.FormUI
{
    partial class TreatmentsForm
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
            btnAddTreatment = new Button();
            btnUpdateTreatment = new Button();
            btnDeleteTreatment = new Button();
            btnDisplay = new Button();
            btnDisplayPatientTreatments = new Button();
            btnDisplayAllDepartments = new Button();
            btnCountPatients = new Button();
            btnBack = new Button();
            panel1 = new Panel();
            dgvTreatments = new DataGridView();
            grpTreatmentAction = new GroupBox();
            btnClearTreatment = new Button();
            btnSaveTreatment = new Button();
            dtpEndDate = new DateTimePicker();
            lblEndDate = new Label();
            txtExtra2 = new TextBox();
            lblExtra2 = new Label();
            txtExtra1 = new TextBox();
            lblExtra1 = new Label();
            txtCost = new TextBox();
            lblCost = new Label();
            dtpTreatmentDate = new DateTimePicker();
            lblTreatmentDate = new Label();
            txtPatientID = new TextBox();
            lblPatientID = new Label();
            txtTreatmentID = new TextBox();
            lblTreatmentID = new Label();
            cmbTreatmentType = new ComboBox();
            lblTreatmentType = new Label();
            lblSelectedTreatmentSection = new Label();
            lblSelectedTreatmentDate = new Label();
            dtpSelectedTreatmentDate = new DateTimePicker();
            lblSelectedCost = new Label();
            txtSelectedCost = new TextBox();
            lblSelectedExtra1 = new Label();
            txtSelectedExtra1 = new TextBox();
            lblSelectedExtra2 = new Label();
            txtSelectedExtra2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTreatments).BeginInit();
            grpTreatmentAction.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddTreatment
            // 
            btnAddTreatment.AutoSize = true;
            btnAddTreatment.BackColor = Color.DarkGray;
            btnAddTreatment.FlatAppearance.BorderSize = 0;
            btnAddTreatment.FlatStyle = FlatStyle.Flat;
            btnAddTreatment.Font = new Font("Microsoft Sans Serif", 12F);
            btnAddTreatment.ForeColor = Color.WhiteSmoke;
            btnAddTreatment.Location = new Point(10, 12);
            btnAddTreatment.Name = "btnAddTreatment";
            btnAddTreatment.Padding = new Padding(10, 0, 10, 0);
            btnAddTreatment.Size = new Size(266, 39);
            btnAddTreatment.TabIndex = 0;
            btnAddTreatment.Text = "Add Treatment To Patient";
            btnAddTreatment.UseVisualStyleBackColor = false;
            btnAddTreatment.Click += btnAddTreatment_Click;
            // 
            // btnUpdateTreatment
            // 
            btnUpdateTreatment.AutoSize = true;
            btnUpdateTreatment.BackColor = Color.DarkGray;
            btnUpdateTreatment.FlatAppearance.BorderSize = 0;
            btnUpdateTreatment.FlatStyle = FlatStyle.Flat;
            btnUpdateTreatment.Font = new Font("Microsoft Sans Serif", 12F);
            btnUpdateTreatment.ForeColor = Color.WhiteSmoke;
            btnUpdateTreatment.Location = new Point(282, 12);
            btnUpdateTreatment.Name = "btnUpdateTreatment";
            btnUpdateTreatment.Padding = new Padding(10, 0, 10, 0);
            btnUpdateTreatment.Size = new Size(212, 39);
            btnUpdateTreatment.TabIndex = 1;
            btnUpdateTreatment.Text = "Update Treatment";
            btnUpdateTreatment.UseVisualStyleBackColor = false;
            btnUpdateTreatment.Click += btnUpdateTreatment_Click;
            // 
            // btnDeleteTreatment
            // 
            btnDeleteTreatment.AutoSize = true;
            btnDeleteTreatment.BackColor = Color.DarkGray;
            btnDeleteTreatment.FlatAppearance.BorderSize = 0;
            btnDeleteTreatment.FlatStyle = FlatStyle.Flat;
            btnDeleteTreatment.Font = new Font("Microsoft Sans Serif", 12F);
            btnDeleteTreatment.ForeColor = Color.WhiteSmoke;
            btnDeleteTreatment.Location = new Point(500, 12);
            btnDeleteTreatment.Name = "btnDeleteTreatment";
            btnDeleteTreatment.Padding = new Padding(10, 0, 10, 0);
            btnDeleteTreatment.Size = new Size(205, 39);
            btnDeleteTreatment.TabIndex = 2;
            btnDeleteTreatment.Text = "Delete Treatment";
            btnDeleteTreatment.UseVisualStyleBackColor = false;
            btnDeleteTreatment.Click += btnDeleteTreatment_Click;
            // 
            // btnDisplay
            // 
            btnDisplay.AutoSize = true;
            btnDisplay.BackColor = Color.DarkGray;
            btnDisplay.FlatAppearance.BorderSize = 0;
            btnDisplay.FlatStyle = FlatStyle.Flat;
            btnDisplay.Font = new Font("Microsoft Sans Serif", 12F);
            btnDisplay.ForeColor = Color.WhiteSmoke;
            btnDisplay.Location = new Point(1005, 12);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Padding = new Padding(10, 0, 10, 0);
            btnDisplay.Size = new Size(130, 39);
            btnDisplay.TabIndex = 3;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = false;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnDisplayPatientTreatments
            // 
            btnDisplayPatientTreatments.AutoSize = true;
            btnDisplayPatientTreatments.BackColor = Color.DarkGray;
            btnDisplayPatientTreatments.FlatAppearance.BorderSize = 0;
            btnDisplayPatientTreatments.FlatStyle = FlatStyle.Flat;
            btnDisplayPatientTreatments.Font = new Font("Microsoft Sans Serif", 12F);
            btnDisplayPatientTreatments.ForeColor = Color.WhiteSmoke;
            btnDisplayPatientTreatments.Location = new Point(711, 12);
            btnDisplayPatientTreatments.Name = "btnDisplayPatientTreatments";
            btnDisplayPatientTreatments.Padding = new Padding(10, 0, 10, 0);
            btnDisplayPatientTreatments.Size = new Size(288, 39);
            btnDisplayPatientTreatments.TabIndex = 4;
            btnDisplayPatientTreatments.Text = "Display Patient Treatments";
            btnDisplayPatientTreatments.UseVisualStyleBackColor = false;
            btnDisplayPatientTreatments.Click += btnDisplayPatientTreatments_Click;
            // 
            // btnDisplayAllDepartments
            // 
            btnDisplayAllDepartments.AutoSize = true;
            btnDisplayAllDepartments.BackColor = Color.DarkGray;
            btnDisplayAllDepartments.FlatAppearance.BorderSize = 0;
            btnDisplayAllDepartments.FlatStyle = FlatStyle.Flat;
            btnDisplayAllDepartments.Font = new Font("Microsoft Sans Serif", 12F);
            btnDisplayAllDepartments.ForeColor = Color.WhiteSmoke;
            btnDisplayAllDepartments.Location = new Point(10, 60);
            btnDisplayAllDepartments.Name = "btnDisplayAllDepartments";
            btnDisplayAllDepartments.Padding = new Padding(10, 0, 10, 0);
            btnDisplayAllDepartments.Size = new Size(431, 39);
            btnDisplayAllDepartments.TabIndex = 5;
            btnDisplayAllDepartments.Text = "Display Patients Treated In All Departments";
            btnDisplayAllDepartments.UseVisualStyleBackColor = false;
            btnDisplayAllDepartments.Click += btnDisplayAllDepartments_Click;
            // 
            // btnCountPatients
            // 
            btnCountPatients.AutoSize = true;
            btnCountPatients.BackColor = Color.DarkGray;
            btnCountPatients.FlatAppearance.BorderSize = 0;
            btnCountPatients.FlatStyle = FlatStyle.Flat;
            btnCountPatients.Font = new Font("Microsoft Sans Serif", 12F);
            btnCountPatients.ForeColor = Color.WhiteSmoke;
            btnCountPatients.Location = new Point(447, 60);
            btnCountPatients.Name = "btnCountPatients";
            btnCountPatients.Padding = new Padding(10, 0, 10, 0);
            btnCountPatients.Size = new Size(311, 39);
            btnCountPatients.TabIndex = 6;
            btnCountPatients.Text = "Count Patients In Department";
            btnCountPatients.UseVisualStyleBackColor = false;
            btnCountPatients.Click += btnCountPatients_Click;
            // 
            // btnBack
            // 
            btnBack.AutoSize = true;
            btnBack.BackColor = Color.DarkGray;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Microsoft Sans Serif", 12F);
            btnBack.ForeColor = Color.WhiteSmoke;
            btnBack.Location = new Point(764, 60);
            btnBack.Name = "btnBack";
            btnBack.Padding = new Padding(10, 0, 10, 0);
            btnBack.Size = new Size(95, 39);
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
            panel1.Size = new Size(1138, 1);
            panel1.TabIndex = 8;
            // 
            // dgvTreatments
            // 
            dgvTreatments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTreatments.Location = new Point(10, 135);
            dgvTreatments.Name = "dgvTreatments";
            dgvTreatments.RowHeadersWidth = 51;
            dgvTreatments.Size = new Size(690, 306);
            dgvTreatments.TabIndex = 9;
            // 
            // grpTreatmentAction
            // 
            grpTreatmentAction.BackColor = SystemColors.ControlDark;
            grpTreatmentAction.Controls.Add(btnClearTreatment);
            grpTreatmentAction.Controls.Add(btnSaveTreatment);
            grpTreatmentAction.Controls.Add(dtpEndDate);
            grpTreatmentAction.Controls.Add(lblEndDate);
            grpTreatmentAction.Controls.Add(txtExtra2);
            grpTreatmentAction.Controls.Add(lblExtra2);
            grpTreatmentAction.Controls.Add(txtExtra1);
            grpTreatmentAction.Controls.Add(lblExtra1);
            grpTreatmentAction.Controls.Add(txtCost);
            grpTreatmentAction.Controls.Add(lblCost);
            grpTreatmentAction.Controls.Add(dtpTreatmentDate);
            grpTreatmentAction.Controls.Add(lblTreatmentDate);
            grpTreatmentAction.Controls.Add(txtPatientID);
            grpTreatmentAction.Controls.Add(lblPatientID);
            grpTreatmentAction.Controls.Add(txtTreatmentID);
            grpTreatmentAction.Controls.Add(lblTreatmentID);
            grpTreatmentAction.Controls.Add(cmbTreatmentType);
            grpTreatmentAction.Controls.Add(lblTreatmentType);
            grpTreatmentAction.Location = new Point(713, 135);
            grpTreatmentAction.Name = "grpTreatmentAction";
            grpTreatmentAction.Size = new Size(440, 456);
            grpTreatmentAction.TabIndex = 10;
            grpTreatmentAction.TabStop = false;
            grpTreatmentAction.Text = "Treatment Action";
            // 
            // btnClearTreatment
            // 
            btnClearTreatment.BackColor = Color.Gainsboro;
            btnClearTreatment.FlatAppearance.BorderSize = 0;
            btnClearTreatment.FlatStyle = FlatStyle.Flat;
            btnClearTreatment.ForeColor = Color.Black;
            btnClearTreatment.Location = new Point(169, 420);
            btnClearTreatment.Name = "btnClearTreatment";
            btnClearTreatment.Size = new Size(145, 30);
            btnClearTreatment.TabIndex = 17;
            btnClearTreatment.Text = "Clear";
            btnClearTreatment.UseVisualStyleBackColor = false;
            btnClearTreatment.Click += btnClearTreatment_Click;
            // 
            // btnSaveTreatment
            // 
            btnSaveTreatment.BackColor = Color.FromArgb(126, 192, 238);
            btnSaveTreatment.FlatAppearance.BorderSize = 0;
            btnSaveTreatment.FlatStyle = FlatStyle.Flat;
            btnSaveTreatment.ForeColor = Color.White;
            btnSaveTreatment.Location = new Point(18, 420);
            btnSaveTreatment.Name = "btnSaveTreatment";
            btnSaveTreatment.Size = new Size(145, 30);
            btnSaveTreatment.TabIndex = 16;
            btnSaveTreatment.Text = "Add";
            btnSaveTreatment.UseVisualStyleBackColor = false;
            btnSaveTreatment.Click += btnSaveTreatment_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(206, 370);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(220, 27);
            dtpEndDate.TabIndex = 15;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblEndDate.Location = new Point(18, 370);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(79, 20);
            lblEndDate.TabIndex = 14;
            lblEndDate.Text = "End Date";
            // 
            // txtExtra2
            // 
            txtExtra2.Location = new Point(206, 320);
            txtExtra2.Name = "txtExtra2";
            txtExtra2.Size = new Size(220, 27);
            txtExtra2.TabIndex = 13;
            // 
            // lblExtra2
            // 
            lblExtra2.AutoSize = true;
            lblExtra2.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblExtra2.Location = new Point(18, 320);
            lblExtra2.Name = "lblExtra2";
            lblExtra2.Size = new Size(67, 20);
            lblExtra2.TabIndex = 12;
            lblExtra2.Text = "Extra 2:";
            // 
            // txtExtra1
            // 
            txtExtra1.Location = new Point(206, 270);
            txtExtra1.Name = "txtExtra1";
            txtExtra1.Size = new Size(220, 27);
            txtExtra1.TabIndex = 11;
            // 
            // lblExtra1
            // 
            lblExtra1.AutoSize = true;
            lblExtra1.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblExtra1.Location = new Point(18, 270);
            lblExtra1.Name = "lblExtra1";
            lblExtra1.Size = new Size(67, 20);
            lblExtra1.TabIndex = 10;
            lblExtra1.Text = "Extra 1:";
            // 
            // txtCost
            // 
            txtCost.Location = new Point(206, 220);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(220, 27);
            txtCost.TabIndex = 9;
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblCost.Location = new Point(18, 220);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(44, 20);
            lblCost.TabIndex = 8;
            lblCost.Text = "Cost";
            // 
            // dtpTreatmentDate
            // 
            dtpTreatmentDate.Format = DateTimePickerFormat.Short;
            dtpTreatmentDate.Location = new Point(206, 170);
            dtpTreatmentDate.Name = "dtpTreatmentDate";
            dtpTreatmentDate.Size = new Size(220, 27);
            dtpTreatmentDate.TabIndex = 7;
            // 
            // lblTreatmentDate
            // 
            lblTreatmentDate.AutoSize = true;
            lblTreatmentDate.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblTreatmentDate.Location = new Point(18, 170);
            lblTreatmentDate.Name = "lblTreatmentDate";
            lblTreatmentDate.Size = new Size(126, 20);
            lblTreatmentDate.TabIndex = 6;
            lblTreatmentDate.Text = "Treatment Date";
            // 
            // txtPatientID
            // 
            txtPatientID.Location = new Point(206, 120);
            txtPatientID.Name = "txtPatientID";
            txtPatientID.Size = new Size(220, 27);
            txtPatientID.TabIndex = 5;
            // 
            // lblPatientID
            // 
            lblPatientID.AutoSize = true;
            lblPatientID.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblPatientID.Location = new Point(18, 120);
            lblPatientID.Name = "lblPatientID";
            lblPatientID.Size = new Size(83, 20);
            lblPatientID.TabIndex = 4;
            lblPatientID.Text = "Patient ID";
            // 
            // txtTreatmentID
            // 
            txtTreatmentID.Location = new Point(206, 70);
            txtTreatmentID.Name = "txtTreatmentID";
            txtTreatmentID.Size = new Size(220, 27);
            txtTreatmentID.TabIndex = 3;
            // 
            // lblTreatmentID
            // 
            lblTreatmentID.AutoSize = true;
            lblTreatmentID.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblTreatmentID.Location = new Point(18, 70);
            lblTreatmentID.Name = "lblTreatmentID";
            lblTreatmentID.Size = new Size(107, 20);
            lblTreatmentID.TabIndex = 2;
            lblTreatmentID.Text = "Treatment ID";
            // 
            // cmbTreatmentType
            // 
            cmbTreatmentType.FormattingEnabled = true;
            cmbTreatmentType.Location = new Point(206, 20);
            cmbTreatmentType.Name = "cmbTreatmentType";
            cmbTreatmentType.Size = new Size(220, 28);
            cmbTreatmentType.TabIndex = 1;
            cmbTreatmentType.SelectedIndexChanged += cmbTreatmentType_SelectedIndexChanged;
            // 
            // lblTreatmentType
            // 
            lblTreatmentType.AutoSize = true;
            lblTreatmentType.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblTreatmentType.Location = new Point(18, 20);
            lblTreatmentType.Name = "lblTreatmentType";
            lblTreatmentType.Size = new Size(126, 20);
            lblTreatmentType.TabIndex = 0;
            lblTreatmentType.Text = "Treatment Type";
            // 
            // lblSelectedTreatmentSection
            // 
            lblSelectedTreatmentSection.AutoSize = true;
            lblSelectedTreatmentSection.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            lblSelectedTreatmentSection.Location = new Point(10, 451);
            lblSelectedTreatmentSection.Name = "lblSelectedTreatmentSection";
            lblSelectedTreatmentSection.Size = new Size(173, 20);
            lblSelectedTreatmentSection.TabIndex = 11;
            lblSelectedTreatmentSection.Text = "Selected Treatment";
            lblSelectedTreatmentSection.Visible = false;
            // 
            // lblSelectedTreatmentDate
            // 
            lblSelectedTreatmentDate.AutoSize = true;
            lblSelectedTreatmentDate.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedTreatmentDate.Location = new Point(10, 483);
            lblSelectedTreatmentDate.Name = "lblSelectedTreatmentDate";
            lblSelectedTreatmentDate.Size = new Size(126, 20);
            lblSelectedTreatmentDate.TabIndex = 12;
            lblSelectedTreatmentDate.Text = "Treatment Date";
            lblSelectedTreatmentDate.Visible = false;
            // 
            // dtpSelectedTreatmentDate
            // 
            dtpSelectedTreatmentDate.Format = DateTimePickerFormat.Short;
            dtpSelectedTreatmentDate.Location = new Point(160, 479);
            dtpSelectedTreatmentDate.Name = "dtpSelectedTreatmentDate";
            dtpSelectedTreatmentDate.Size = new Size(200, 27);
            dtpSelectedTreatmentDate.TabIndex = 13;
            dtpSelectedTreatmentDate.Visible = false;
            // 
            // lblSelectedCost
            // 
            lblSelectedCost.AutoSize = true;
            lblSelectedCost.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedCost.Location = new Point(376, 483);
            lblSelectedCost.Name = "lblSelectedCost";
            lblSelectedCost.Size = new Size(44, 20);
            lblSelectedCost.TabIndex = 14;
            lblSelectedCost.Text = "Cost";
            lblSelectedCost.Visible = false;
            // 
            // txtSelectedCost
            // 
            txtSelectedCost.Location = new Point(430, 479);
            txtSelectedCost.Name = "txtSelectedCost";
            txtSelectedCost.Size = new Size(230, 27);
            txtSelectedCost.TabIndex = 15;
            txtSelectedCost.Visible = false;
            // 
            // lblSelectedExtra1
            // 
            lblSelectedExtra1.AutoSize = true;
            lblSelectedExtra1.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedExtra1.Location = new Point(10, 518);
            lblSelectedExtra1.Name = "lblSelectedExtra1";
            lblSelectedExtra1.Size = new Size(67, 20);
            lblSelectedExtra1.TabIndex = 16;
            lblSelectedExtra1.Text = "Extra 1:";
            lblSelectedExtra1.Visible = false;
            // 
            // txtSelectedExtra1
            // 
            txtSelectedExtra1.Location = new Point(202, 514);
            txtSelectedExtra1.Name = "txtSelectedExtra1";
            txtSelectedExtra1.Size = new Size(158, 27);
            txtSelectedExtra1.TabIndex = 17;
            txtSelectedExtra1.Visible = false;
            // 
            // lblSelectedExtra2
            // 
            lblSelectedExtra2.AutoSize = true;
            lblSelectedExtra2.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblSelectedExtra2.Location = new Point(376, 518);
            lblSelectedExtra2.Name = "lblSelectedExtra2";
            lblSelectedExtra2.Size = new Size(67, 20);
            lblSelectedExtra2.TabIndex = 18;
            lblSelectedExtra2.Text = "Extra 2:";
            lblSelectedExtra2.Visible = false;
            // 
            // txtSelectedExtra2
            // 
            txtSelectedExtra2.Location = new Point(512, 514);
            txtSelectedExtra2.Name = "txtSelectedExtra2";
            txtSelectedExtra2.Size = new Size(148, 27);
            txtSelectedExtra2.TabIndex = 19;
            txtSelectedExtra2.Visible = false;
            // 
            // TreatmentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1165, 603);
            Controls.Add(txtSelectedExtra2);
            Controls.Add(lblSelectedExtra2);
            Controls.Add(txtSelectedExtra1);
            Controls.Add(lblSelectedExtra1);
            Controls.Add(txtSelectedCost);
            Controls.Add(lblSelectedCost);
            Controls.Add(dtpSelectedTreatmentDate);
            Controls.Add(lblSelectedTreatmentDate);
            Controls.Add(lblSelectedTreatmentSection);
            Controls.Add(grpTreatmentAction);
            Controls.Add(dgvTreatments);
            Controls.Add(panel1);
            Controls.Add(btnBack);
            Controls.Add(btnCountPatients);
            Controls.Add(btnDisplayAllDepartments);
            Controls.Add(btnDisplayPatientTreatments);
            Controls.Add(btnDisplay);
            Controls.Add(btnDeleteTreatment);
            Controls.Add(btnUpdateTreatment);
            Controls.Add(btnAddTreatment);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TreatmentsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Treatments Management";
            Load += TreatmentsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTreatments).EndInit();
            grpTreatmentAction.ResumeLayout(false);
            grpTreatmentAction.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddTreatment;
        private Button btnUpdateTreatment;
        private Button btnDeleteTreatment;
        private Button btnDisplay;
        private Button btnDisplayPatientTreatments;
        private Button btnDisplayAllDepartments;
        private Button btnCountPatients;
        private Button btnBack;
        private Panel panel1;
        private DataGridView dgvTreatments;
        private GroupBox grpTreatmentAction;
        private Button btnClearTreatment;
        private Button btnSaveTreatment;
        private DateTimePicker dtpEndDate;
        private Label lblEndDate;
        private TextBox txtExtra2;
        private Label lblExtra2;
        private TextBox txtExtra1;
        private Label lblExtra1;
        private TextBox txtCost;
        private Label lblCost;
        private DateTimePicker dtpTreatmentDate;
        private Label lblTreatmentDate;
        private TextBox txtPatientID;
        private Label lblPatientID;
        private TextBox txtTreatmentID;
        private Label lblTreatmentID;
        private ComboBox cmbTreatmentType;
        private Label lblTreatmentType;
        private Label lblSelectedTreatmentSection;
        private Label lblSelectedTreatmentDate;
        private DateTimePicker dtpSelectedTreatmentDate;
        private Label lblSelectedCost;
        private TextBox txtSelectedCost;
        private Label lblSelectedExtra1;
        private TextBox txtSelectedExtra1;
        private Label lblSelectedExtra2;
        private TextBox txtSelectedExtra2;
    }
}
