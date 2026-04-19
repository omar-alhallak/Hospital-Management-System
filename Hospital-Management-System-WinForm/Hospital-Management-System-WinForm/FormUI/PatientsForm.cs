using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Hospital_Management_System_WinForm.FormUI
{
    public partial class PatientsForm : Form
    {
        private readonly List<PatientRow> patients = new List<PatientRow>();
        private string currentMode = "Add";

        public PatientsForm()
        {
            InitializeComponent();
        }

        private class PatientRow
        {
            public int PatientID { get; set; }
            public string PatientName { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;

            [Browsable(false)]
            public DateTime BirthDateValue { get; set; }

            public string BirthDate => BirthDateValue.ToShortDateString();
            public string Status { get; set; } = string.Empty;

            [Browsable(false)]
            public bool IsDischarged { get; set; }

            [Browsable(false)]
            public bool IsAccepted { get; set; }
        }

        private void PatientsForm_Load(object sender, EventArgs e)
        {
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.MultiSelect = false;
            dgvPatients.ReadOnly = true;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.AutoGenerateColumns = true;
            dgvPatients.SelectionChanged += dgvPatients_SelectionChanged;

            LoadSamplePatients();
            ShowAddMode();
            BindGrid(patients);
        }

        private void LoadSamplePatients()
        {
            patients.Clear();

            patients.Add(new PatientRow
            {
                PatientID = 1,
                PatientName = "Bilal",
                Type = "Internal Patient",
                Address = "Damascus",
                BirthDateValue = new DateTime(2020, 1, 1),
                Status = "Discharged",
                IsDischarged = true
            });

            patients.Add(new PatientRow
            {
                PatientID = 2,
                PatientName = "Bilal",
                Type = "Internal Patient",
                Address = "Sham",
                BirthDateValue = new DateTime(2020, 2, 2),
                Status = "Not Discharged",
                IsDischarged = false
            });

            patients.Add(new PatientRow
            {
                PatientID = 3,
                PatientName = "Omar",
                Type = "External Patient",
                Address = "Sham",
                BirthDateValue = new DateTime(2020, 3, 3),
                Status = "Accepted",
                IsAccepted = true
            });

            patients.Add(new PatientRow
            {
                PatientID = 5,
                PatientName = "Khaled",
                Type = "External Patient",
                Address = "Lebanon",
                BirthDateValue = new DateTime(2020, 5, 5),
                Status = "Not Accepted",
                IsAccepted = false
            });
        }

        private void BindGrid(IEnumerable<PatientRow> rows)
        {
            dgvPatients.DataSource = null;
            dgvPatients.DataSource = rows.ToList();

            if (dgvPatients.Columns["BirthDateValue"] != null)
                dgvPatients.Columns["BirthDateValue"].Visible = false;

            if (dgvPatients.Columns["IsDischarged"] != null)
                dgvPatients.Columns["IsDischarged"].Visible = false;

            if (dgvPatients.Columns["IsAccepted"] != null)
                dgvPatients.Columns["IsAccepted"].Visible = false;

            if (dgvPatients.Columns["PatientID"] != null)
                dgvPatients.Columns["PatientID"].HeaderText = "ID";

            if (dgvPatients.Columns["PatientName"] != null)
                dgvPatients.Columns["PatientName"].HeaderText = "Patient Name";

            dgvPatients.ClearSelection();
            dgvPatients.CurrentCell = null;
        }

        private void ResetInputs()
        {
            txtPatientID.Clear();
            txtPatientName.Clear();
            txtAddress.Clear();
            dtpBirthDate.Value = DateTime.Today;
        }

        private void ClearSelectedPatientEditor()
        {
            txtSelectedPatientName.Clear();
            txtSelectedPatientAddress.Clear();
            dtpSelectedPatientBirthDate.Format = DateTimePickerFormat.Custom;
            dtpSelectedPatientBirthDate.CustomFormat = " ";
            dtpSelectedPatientBirthDate.Value = DateTime.Today;
            cmbSelectedPatientStatus.SelectedIndex = -1;
        }

        private void SetPatientTypeItems()
        {
            cmbPatientType.Items.Clear();
            cmbPatientType.Items.Add("Internal Patient");
            cmbPatientType.Items.Add("External Patient");
            cmbPatientType.SelectedIndex = 0;
        }

        private void LoadStatusOptionsForAdd()
        {
            string patientType = cmbPatientType.SelectedItem?.ToString() ?? "Internal Patient";
            cmbStatus.Items.Clear();

            if (patientType == "Internal Patient")
            {
                cmbStatus.Items.Add("Discharged");
                cmbStatus.Items.Add("Not Discharged");
            }
            else
            {
                cmbStatus.Items.Add("Accepted");
                cmbStatus.Items.Add("Not Accepted");
            }

            cmbStatus.SelectedIndex = 0;
        }

        private void ShowSelectedPatientEditor(bool visible)
        {
            lblSelectedPatientSection.Visible = visible;
            lblSelectedPatientName.Visible = visible;
            txtSelectedPatientName.Visible = visible;
            lblSelectedPatientAddress.Visible = visible;
            txtSelectedPatientAddress.Visible = visible;
            lblSelectedPatientBirthDate.Visible = visible;
            dtpSelectedPatientBirthDate.Visible = visible;
            lblSelectedPatientStatus.Visible = visible;
            cmbSelectedPatientStatus.Visible = visible;
        }

        private PatientRow? GetSelectedPatient()
        {
            if (dgvPatients.CurrentRow != null &&
                dgvPatients.CurrentRow.Selected &&
                dgvPatients.CurrentRow.DataBoundItem is PatientRow selectedPatient)
            {
                return patients.FirstOrDefault(patient => patient.PatientID == selectedPatient.PatientID);
            }

            return null;
        }

        private void LoadSelectedPatientIntoEditor()
        {
            PatientRow? selectedPatient = GetSelectedPatient();

            if (selectedPatient == null)
            {
                ClearSelectedPatientEditor();
                return;
            }

            txtSelectedPatientName.Text = selectedPatient.PatientName;
            txtSelectedPatientAddress.Text = selectedPatient.Address;
            dtpSelectedPatientBirthDate.Format = DateTimePickerFormat.Short;
            dtpSelectedPatientBirthDate.Value = selectedPatient.BirthDateValue;

            cmbSelectedPatientStatus.Items.Clear();

            if (selectedPatient.Type == "Internal Patient")
            {
                cmbSelectedPatientStatus.Items.Add("Discharged");
                cmbSelectedPatientStatus.Items.Add("Not Discharged");
            }
            else
            {
                cmbSelectedPatientStatus.Items.Add("Accepted");
                cmbSelectedPatientStatus.Items.Add("Not Accepted");
            }

            cmbSelectedPatientStatus.SelectedItem = selectedPatient.Status;
        }

        private void RefreshGridForCurrentMode()
        {
            if (currentMode == "Display")
            {
                ApplyDisplayFilter();
                return;
            }

            if (currentMode == "Discharge")
            {
                BindGrid(patients.Where(patient => patient.Type == "Internal Patient" && !patient.IsDischarged));
                return;
            }

            if (currentMode == "Accept")
            {
                BindGrid(patients.Where(patient => patient.Type == "External Patient" && !patient.IsAccepted));
                return;
            }

            BindGrid(patients);
        }

        private void ApplyDisplayFilter()
        {
            string selectedDisplayType = cmbPatientType.SelectedItem?.ToString() ?? "Display All Patients";

            if (selectedDisplayType == "Display All Patients")
            {
                BindGrid(patients);
                return;
            }

            string patientTypeToShow = selectedDisplayType switch
            {
                "Display Internal Patients" => "Internal Patient",
                "Display External Patients" => "External Patient",
                _ => string.Empty
            };

            BindGrid(patients.Where(patient => patient.Type == patientTypeToShow));
        }

        private void ShowAddMode()
        {
            currentMode = "Add";
            grpPatientAction.Text = "Patient Action";
            btnSavePatient.Text = "Add";
            btnSavePatient.Visible = true;
            btnClearPatient.Visible = true;

            lblPatientType.Visible = true;
            cmbPatientType.Visible = true;
            lblPatientType.Text = "Patient Type:";
            lblPatientID.Visible = true;
            txtPatientID.Visible = true;
            lblPatientID.Text = "Patient ID:";
            lblPatientName.Visible = true;
            txtPatientName.Visible = true;
            lblPatientName.Text = "Patient Name:";
            lblAddress.Visible = true;
            txtAddress.Visible = true;
            lblBirthDate.Visible = true;
            dtpBirthDate.Visible = true;
            lblStatus.Visible = true;
            cmbStatus.Visible = true;

            ShowSelectedPatientEditor(false);
            ClearSelectedPatientEditor();
            ResetInputs();
            SetPatientTypeItems();
            LoadStatusOptionsForAdd();
        }

        private void ShowUpdateMode()
        {
            currentMode = "Update";
            grpPatientAction.Text = "Update Patient";
            btnSavePatient.Text = "Update";
            btnSavePatient.Visible = true;
            btnClearPatient.Visible = true;

            lblPatientType.Visible = false;
            cmbPatientType.Visible = false;
            lblPatientID.Visible = false;
            txtPatientID.Visible = false;
            lblPatientName.Visible = false;
            txtPatientName.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblStatus.Visible = false;
            cmbStatus.Visible = false;

            ShowSelectedPatientEditor(true);
            ClearSelectedPatientEditor();
            BindGrid(patients);
            dgvPatients.ClearSelection();
            dgvPatients.CurrentCell = null;
        }

        private void ShowSearchMode()
        {
            currentMode = "Search";
            grpPatientAction.Text = "Search Patient";
            btnSavePatient.Text = "Search";
            btnSavePatient.Visible = true;
            btnClearPatient.Visible = true;

            ShowSelectedPatientEditor(false);
            ClearSelectedPatientEditor();
            ResetInputs();

            lblPatientType.Visible = true;
            cmbPatientType.Visible = true;
            lblPatientType.Text = "Search Type:";
            cmbPatientType.Items.Clear();
            cmbPatientType.Items.Add("Search By ID");
            cmbPatientType.Items.Add("Search By Name");
            cmbPatientType.SelectedIndex = 0;

            lblPatientID.Visible = false;
            txtPatientID.Visible = false;
            lblPatientName.Visible = true;
            txtPatientName.Visible = true;
            lblPatientName.Text = "Search Value:";
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblStatus.Visible = false;
            cmbStatus.Visible = false;
        }

        private void ShowDisplayMode()
        {
            currentMode = "Display";
            grpPatientAction.Text = "Display Patients";
            btnSavePatient.Visible = false;
            btnClearPatient.Visible = false;

            ShowSelectedPatientEditor(false);
            ClearSelectedPatientEditor();
            ResetInputs();

            lblPatientType.Visible = true;
            cmbPatientType.Visible = true;
            lblPatientType.Text = "Display Type:";
            cmbPatientType.Items.Clear();
            cmbPatientType.Items.Add("Display All Patients");
            cmbPatientType.Items.Add("Display Internal Patients");
            cmbPatientType.Items.Add("Display External Patients");
            cmbPatientType.SelectedIndex = 0;

            lblPatientID.Visible = false;
            txtPatientID.Visible = false;
            lblPatientName.Visible = false;
            txtPatientName.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblStatus.Visible = false;
            cmbStatus.Visible = false;
        }

        private void ShowDischargeMode()
        {
            currentMode = "Discharge";
            grpPatientAction.Text = "Discharge Internal Patient";
            btnSavePatient.Text = "Discharge";
            btnSavePatient.Visible = true;
            btnClearPatient.Visible = true;

            ShowSelectedPatientEditor(false);
            ClearSelectedPatientEditor();
            ResetInputs();

            lblPatientType.Visible = false;
            cmbPatientType.Visible = false;
            lblPatientID.Visible = true;
            txtPatientID.Visible = true;
            lblPatientID.Text = "Internal Patient ID:";
            lblPatientName.Visible = false;
            txtPatientName.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblStatus.Visible = false;
            cmbStatus.Visible = false;

            BindGrid(patients.Where(patient => patient.Type == "Internal Patient" && !patient.IsDischarged));
        }

        private void ShowAcceptMode()
        {
            currentMode = "Accept";
            grpPatientAction.Text = "Accept External Patient";
            btnSavePatient.Text = "Accept";
            btnSavePatient.Visible = true;
            btnClearPatient.Visible = true;

            ShowSelectedPatientEditor(false);
            ClearSelectedPatientEditor();
            ResetInputs();

            lblPatientType.Visible = false;
            cmbPatientType.Visible = false;
            lblPatientID.Visible = true;
            txtPatientID.Visible = true;
            lblPatientID.Text = "External Patient ID:";
            lblPatientName.Visible = false;
            txtPatientName.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblStatus.Visible = false;
            cmbStatus.Visible = false;

            BindGrid(patients.Where(patient => patient.Type == "External Patient" && !patient.IsAccepted));
        }

        private void dgvPatients_SelectionChanged(object? sender, EventArgs e)
        {
            if (currentMode == "Update")
                LoadSelectedPatientIntoEditor();

            if (currentMode == "Discharge" || currentMode == "Accept")
            {
                PatientRow? selectedPatient = GetSelectedPatient();
                txtPatientID.Text = selectedPatient?.PatientID.ToString() ?? string.Empty;
            }
        }

        private void cmbPatientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPatientType.SelectedItem == null)
                return;

            if (currentMode == "Display")
            {
                ApplyDisplayFilter();
                return;
            }

            if (currentMode != "Add")
                return;

            LoadStatusOptionsForAdd();
        }

        private void btnSavePatient_Click(object sender, EventArgs e)
        {
            if (currentMode == "Update")
            {
                PatientRow? selectedPatient = GetSelectedPatient();

                if (selectedPatient == null)
                {
                    MessageBox.Show("Select a patient from the table first.", "Update Patient",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                selectedPatient.PatientName = txtSelectedPatientName.Text.Trim();
                selectedPatient.Address = txtSelectedPatientAddress.Text.Trim();
                selectedPatient.BirthDateValue = dtpSelectedPatientBirthDate.Value.Date;

                string updatedStatus = cmbSelectedPatientStatus.SelectedItem?.ToString() ?? selectedPatient.Status;
                selectedPatient.Status = updatedStatus;

                if (selectedPatient.Type == "Internal Patient")
                    selectedPatient.IsDischarged = updatedStatus == "Discharged";
                else
                    selectedPatient.IsAccepted = updatedStatus == "Accepted";

                RefreshGridForCurrentMode();
                MessageBox.Show("Patient updated successfully.", "Update Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentMode == "Search")
            {
                string selectedSearchType = cmbPatientType.SelectedItem?.ToString() ?? "Search By ID";
                string searchValue = txtPatientName.Text.Trim();

                if (selectedSearchType == "Search By ID")
                {
                    if (!int.TryParse(searchValue, out int patientId))
                    {
                        MessageBox.Show("Enter a valid patient ID.", "Search Patient",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    PatientRow? foundPatient = patients.FirstOrDefault(patient => patient.PatientID == patientId);

                    if (foundPatient == null)
                    {
                        MessageBox.Show("Patient not found.", "Search Patient",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    BindGrid(new[] { foundPatient });
                    return;
                }

                BindGrid(patients.Where(patient =>
                    patient.PatientName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)));
                return;
            }

            if (currentMode == "Discharge")
            {
                if (!int.TryParse(txtPatientID.Text.Trim(), out int patientId))
                {
                    MessageBox.Show("Enter a valid internal patient ID.", "Discharge Patient",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PatientRow? internalPatient = patients.FirstOrDefault(patient =>
                    patient.PatientID == patientId && patient.Type == "Internal Patient" && !patient.IsDischarged);

                if (internalPatient == null)
                {
                    MessageBox.Show("No internal patient available for discharge with this ID.", "Discharge Patient",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                internalPatient.IsDischarged = true;
                internalPatient.Status = "Discharged";
                RefreshGridForCurrentMode();
                MessageBox.Show("Internal patient discharged successfully.", "Discharge Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentMode == "Accept")
            {
                if (!int.TryParse(txtPatientID.Text.Trim(), out int patientId))
                {
                    MessageBox.Show("Enter a valid external patient ID.", "Accept Patient",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PatientRow? externalPatient = patients.FirstOrDefault(patient =>
                    patient.PatientID == patientId && patient.Type == "External Patient" && !patient.IsAccepted);

                if (externalPatient == null)
                {
                    MessageBox.Show("No external patient available for acceptance with this ID.", "Accept Patient",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                externalPatient.IsAccepted = true;
                externalPatient.Status = "Accepted";
                RefreshGridForCurrentMode();
                MessageBox.Show("External patient accepted successfully.", "Accept Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string patientType = cmbPatientType.SelectedItem?.ToString() ?? "Internal Patient";

            if (!int.TryParse(txtPatientID.Text.Trim(), out int newPatientId))
            {
                MessageBox.Show("Enter a valid patient ID.", "Add Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (patients.Any(patient => patient.PatientID == newPatientId))
            {
                MessageBox.Show("This patient ID already exists.", "Add Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patientStatus = cmbStatus.SelectedItem?.ToString() ?? "Not Discharged";

            patients.Add(new PatientRow
            {
                PatientID = newPatientId,
                PatientName = txtPatientName.Text.Trim(),
                Type = patientType,
                Address = txtAddress.Text.Trim(),
                BirthDateValue = dtpBirthDate.Value.Date,
                Status = patientStatus,
                IsDischarged = patientStatus == "Discharged",
                IsAccepted = patientStatus == "Accepted"
            });

            RefreshGridForCurrentMode();
            MessageBox.Show("Patient added successfully.", "Add Patient",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowAddMode();
        }

        private void btnClearPatient_Click(object sender, EventArgs e)
        {
            if (currentMode == "Update")
            {
                LoadSelectedPatientIntoEditor();
                return;
            }

            if (currentMode == "Add")
            {
                ShowAddMode();
                return;
            }

            ResetInputs();
            ClearSelectedPatientEditor();
        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            PatientRow? selectedPatient = GetSelectedPatient();

            if (selectedPatient == null)
            {
                MessageBox.Show("Select a patient from the table first.", "Delete Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmDelete = MessageBox.Show(
                "Are you sure you want to delete " + selectedPatient.PatientName + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmDelete != DialogResult.Yes)
                return;

            patients.Remove(selectedPatient);
            ClearSelectedPatientEditor();
            RefreshGridForCurrentMode();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            ShowAddMode();
            BindGrid(patients);
        }

        private void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            ShowUpdateMode();
        }

        private void btnDischargeInternalPatient_Click(object sender, EventArgs e)
        {
            ShowDischargeMode();
        }

        private void btnAcceptExternalPatient_Click(object sender, EventArgs e)
        {
            ShowAcceptMode();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            ShowDisplayMode();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowSearchMode();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            Close();
        }
    }
}
