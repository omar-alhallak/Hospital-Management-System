namespace Hospital_Management_System_WinForm.FormUI
{
    partial class MainForm
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
            lblTitle = new Label();
            label1 = new Label();
            btnDoctors = new Button();
            btnPatients = new Button();
            btnTreatments = new Button();
            btnExit = new Button();
            panelLine = new Panel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(215, 62);
            lblTitle.Margin = new Padding(8, 0, 8, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(496, 39);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hospital Management System";
            lblTitle.Click += lblTitle_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 1);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // btnDoctors
            // 
            btnDoctors.BackColor = Color.FromArgb(126, 192, 238);
            btnDoctors.FlatAppearance.BorderSize = 0;
            btnDoctors.FlatStyle = FlatStyle.Flat;
            btnDoctors.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnDoctors.ForeColor = Color.White;
            btnDoctors.Location = new Point(324, 160);
            btnDoctors.Name = "btnDoctors";
            btnDoctors.Size = new Size(260, 55);
            btnDoctors.TabIndex = 2;
            btnDoctors.Text = "Doctors Management";
            btnDoctors.UseVisualStyleBackColor = false;
            btnDoctors.Click += btnDoctors_Click;
            // 
            // btnPatients
            // 
            btnPatients.BackColor = Color.FromArgb(126, 192, 238);
            btnPatients.FlatAppearance.BorderSize = 0;
            btnPatients.FlatStyle = FlatStyle.Flat;
            btnPatients.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnPatients.ForeColor = Color.White;
            btnPatients.Location = new Point(324, 240);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(260, 55);
            btnPatients.TabIndex = 3;
            btnPatients.Text = "Patients Management";
            btnPatients.UseVisualStyleBackColor = false;
            btnPatients.Click += btnPatients_Click;
            // 
            // btnTreatments
            // 
            btnTreatments.BackColor = Color.FromArgb(126, 192, 238);
            btnTreatments.FlatAppearance.BorderSize = 0;
            btnTreatments.FlatStyle = FlatStyle.Flat;
            btnTreatments.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnTreatments.ForeColor = Color.White;
            btnTreatments.Location = new Point(324, 320);
            btnTreatments.Name = "btnTreatments";
            btnTreatments.Size = new Size(260, 55);
            btnTreatments.TabIndex = 4;
            btnTreatments.Text = "Treatments Management";
            btnTreatments.UseVisualStyleBackColor = false;
            btnTreatments.Click += btnTreatments_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.IndianRed;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.Black;
            btnExit.Location = new Point(395, 399);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(110, 40);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // panelLine
            // 
            panelLine.BackColor = Color.Black;
            panelLine.Location = new Point(65, 126);
            panelLine.Name = "panelLine";
            panelLine.Size = new Size(770, 1);
            panelLine.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(20F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(902, 543);
            Controls.Add(panelLine);
            Controls.Add(btnExit);
            Controls.Add(btnTreatments);
            Controls.Add(btnPatients);
            Controls.Add(btnDoctors);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(8, 9, 8, 9);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hospital Management System";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label1;
        private Button btnDoctors;
        private Button btnPatients;
        private Button btnTreatments;
        private Button btnExit;
        private Panel panelLine;
    }
}
