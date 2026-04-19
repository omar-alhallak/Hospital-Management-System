using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Hospital_Management_System_WinForm.FormUI
{
    public partial class TreatmentsForm : Form
    {
        private readonly List<TreatmentRow> treatments = new List<TreatmentRow>();
        private readonly HashSet<int> validPatientIds = new HashSet<int> { 1, 2, 3, 5, 11 };
        private readonly HashSet<int> validDoctorIds = new HashSet<int> { 1, 4 };
        private string currentMode = "Add";

        public TreatmentsForm()
        {
            InitializeComponent();
        }

        private class TreatmentRow
        {
            public int TreatmentID { get; set; }
            public string Type { get; set; } = string.Empty;
            public int PatientID { get; set; }

            [Browsable(false)]
            public DateTime TreatmentDateValue { get; set; }

            public string TreatmentDate => TreatmentDateValue.ToShortDateString();
            public decimal Cost { get; set; }
            public string DischargeDate { get; set; } = string.Empty;
            public string Department { get; set; } = string.Empty;
            public string TreatingDoctor { get; set; } = string.Empty;
            public string Clinic { get; set; } = string.Empty;

            [Browsable(false)]
            public DateTime? DischargeDateValue { get; set; }

            [Browsable(false)]
            public int? DepartmentID { get; set; }

            [Browsable(false)]
            public int? TreatingDoctorID { get; set; }

            [Browsable(false)]
            public int? ClinicNumber { get; set; }
        }

        private class PatientSummaryRow
        {
            public int PatientID { get; set; }
            public string Note { get; set; } = string.Empty;
            public string Period { get; set; } = string.Empty;
        }

        private void TreatmentsForm_Load(object sender, EventArgs e)
        {
            dgvTreatments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTreatments.MultiSelect = false;
            dgvTreatments.ReadOnly = true;
            dgvTreatments.AllowUserToAddRows = false;
            dgvTreatments.AllowUserToDeleteRows = false;
            dgvTreatments.AutoGenerateColumns = true;
            dgvTreatments.SelectionChanged += dgvTreatments_SelectionChanged;

            LoadSampleTreatments();
            ShowAddMode();
            BindGrid(treatments);
        }

        private void LoadSampleTreatments()
        {
            treatments.Clear();

            treatments.Add(new TreatmentRow
            {
                TreatmentID = 1,
                Type = "Internal Treatment",
                PatientID = 1,
                TreatmentDateValue = new DateTime(2024, 1, 1),
                Cost = 1000m,
                DischargeDateValue = null,
                DepartmentID = 2
            });

            treatments.Add(new TreatmentRow
            {
                TreatmentID = 2,
                Type = "External Treatment",
                PatientID = 2,
                TreatmentDateValue = new DateTime(2025, 2, 2),
                Cost = 2000m,
                TreatingDoctorID = 1,
                ClinicNumber = 1
            });

            treatments.Add(new TreatmentRow
            {
                TreatmentID = 3,
                Type = "Internal Treatment",
                PatientID = 11,
                TreatmentDateValue = new DateTime(2025, 1, 5),
                Cost = 700m,
                DischargeDateValue = new DateTime(2025, 1, 10),
                DepartmentID = 1
            });

            treatments.Add(new TreatmentRow
            {
                TreatmentID = 4,
                Type = "Internal Treatment",
                PatientID = 11,
                TreatmentDateValue = new DateTime(2025, 1, 15),
                Cost = 800m,
                DischargeDateValue = new DateTime(2025, 1, 20),
                DepartmentID = 2
            });

            treatments.Add(new TreatmentRow
            {
                TreatmentID = 5,
                Type = "Internal Treatment",
                PatientID = 11,
                TreatmentDateValue = new DateTime(2025, 1, 25),
                Cost = 900m,
                DischargeDateValue = new DateTime(2025, 1, 30),
                DepartmentID = 3
            });

            treatments.Add(new TreatmentRow
            {
                TreatmentID = 6,
                Type = "Internal Treatment",
                PatientID = 3,
                TreatmentDateValue = new DateTime(2025, 1, 12),
                Cost = 650m,
                DischargeDateValue = null,
                DepartmentID = 1
            });

            UpdateTreatmentDetails();
        }

        private void UpdateTreatmentDetails()
        {
            foreach (TreatmentRow treatment in treatments)
            {
                if (treatment.Type == "Internal Treatment")
                {
                    string dischargeText = treatment.DischargeDateValue.HasValue
                        ? treatment.DischargeDateValue.Value.ToShortDateString()
                        : "Not Discharged Yet";

                    treatment.DischargeDate = dischargeText;
                    treatment.Department = treatment.DepartmentID?.ToString() ?? string.Empty;
                    treatment.TreatingDoctor = string.Empty;
                    treatment.Clinic = string.Empty;
                }
                else
                {
                    treatment.DischargeDate = string.Empty;
                    treatment.Department = string.Empty;
                    treatment.TreatingDoctor = treatment.TreatingDoctorID?.ToString() ?? string.Empty;
                    treatment.Clinic = treatment.ClinicNumber?.ToString() ?? string.Empty;
                }
            }
        }

        private void BindGrid<T>(IEnumerable<T> rows)
        {
            dgvTreatments.DataSource = null;
            dgvTreatments.DataSource = rows.ToList();

            if (dgvTreatments.Columns["TreatmentDateValue"] != null)
                dgvTreatments.Columns["TreatmentDateValue"].Visible = false;

            if (dgvTreatments.Columns["DischargeDateValue"] != null)
                dgvTreatments.Columns["DischargeDateValue"].Visible = false;

            if (dgvTreatments.Columns["DepartmentID"] != null)
                dgvTreatments.Columns["DepartmentID"].Visible = false;

            if (dgvTreatments.Columns["TreatingDoctorID"] != null)
                dgvTreatments.Columns["TreatingDoctorID"].Visible = false;

            if (dgvTreatments.Columns["ClinicNumber"] != null)
                dgvTreatments.Columns["ClinicNumber"].Visible = false;

            if (dgvTreatments.Columns["TreatmentID"] != null)
                dgvTreatments.Columns["TreatmentID"].HeaderText = "ID";

            if (dgvTreatments.Columns["PatientID"] != null)
                dgvTreatments.Columns["PatientID"].HeaderText = "Patient ID";

            if (dgvTreatments.Columns["DischargeDate"] != null)
                dgvTreatments.Columns["DischargeDate"].HeaderText = "Discharge Date";

            if (dgvTreatments.Columns["Department"] != null)
                dgvTreatments.Columns["Department"].HeaderText = "Department ID";

            if (dgvTreatments.Columns["TreatingDoctor"] != null)
                dgvTreatments.Columns["TreatingDoctor"].HeaderText = "Doctor ID";

            if (dgvTreatments.Columns["Clinic"] != null)
                dgvTreatments.Columns["Clinic"].HeaderText = "Clinic Number";

            dgvTreatments.ClearSelection();
            dgvTreatments.CurrentCell = null;
        }

        private void ResetInputs()
        {
            txtTreatmentID.Clear();
            txtPatientID.Clear();
            txtCost.Clear();
            txtExtra1.Clear();
            txtExtra2.Clear();
            dtpTreatmentDate.Value = DateTime.Today;
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";
            dtpEndDate.Value = DateTime.Today;
        }

        private void ClearSelectedTreatmentEditor()
        {
            txtSelectedCost.Clear();
            txtSelectedExtra1.Clear();
            txtSelectedExtra2.Clear();
            dtpSelectedTreatmentDate.Format = DateTimePickerFormat.Custom;
            dtpSelectedTreatmentDate.CustomFormat = " ";
            dtpSelectedTreatmentDate.Value = DateTime.Today;
            lblSelectedExtra1.Text = "Extra 1:";
            lblSelectedExtra2.Text = "Extra 2:";
        }

        private void ShowSelectedTreatmentEditor(bool visible)
        {
            lblSelectedTreatmentSection.Visible = visible;
            lblSelectedTreatmentDate.Visible = visible;
            dtpSelectedTreatmentDate.Visible = visible;
            lblSelectedCost.Visible = visible;
            txtSelectedCost.Visible = visible;
            lblSelectedExtra1.Visible = visible;
            txtSelectedExtra1.Visible = visible;
            lblSelectedExtra2.Visible = visible;
            txtSelectedExtra2.Visible = visible;
        }

        private void SetUpdateEditorVisibleFromSelection()
        {
            ShowSelectedTreatmentEditor(GetSelectedTreatment() != null);
        }

        private TreatmentRow? GetSelectedTreatment()
        {
            if (dgvTreatments.CurrentRow != null &&
                dgvTreatments.CurrentRow.Selected &&
                dgvTreatments.CurrentRow.DataBoundItem is TreatmentRow selectedTreatment)
            {
                return treatments.FirstOrDefault(treatment => treatment.TreatmentID == selectedTreatment.TreatmentID);
            }

            return null;
        }

        private void LoadSelectedTreatmentIntoEditor()
        {
            TreatmentRow? selectedTreatment = GetSelectedTreatment();

            if (selectedTreatment == null)
            {
                ClearSelectedTreatmentEditor();
                ShowSelectedTreatmentEditor(false);
                return;
            }

            ShowSelectedTreatmentEditor(true);
            dtpSelectedTreatmentDate.Format = DateTimePickerFormat.Short;
            dtpSelectedTreatmentDate.Value = selectedTreatment.TreatmentDateValue;
            txtSelectedCost.Text = selectedTreatment.Cost.ToString();

            if (selectedTreatment.Type == "Internal Treatment")
            {
                lblSelectedExtra1.Text = "Discharge Date:";
                lblSelectedExtra2.Text = "Department ID:";
                txtSelectedExtra1.Text = selectedTreatment.DischargeDateValue.HasValue
                    ? selectedTreatment.DischargeDateValue.Value.ToShortDateString()
                    : "N";
                txtSelectedExtra2.Text = selectedTreatment.DepartmentID?.ToString() ?? string.Empty;
            }
            else
            {
                lblSelectedExtra1.Text = "Treating Doctor ID:";
                lblSelectedExtra2.Text = "Clinic Number:";
                txtSelectedExtra1.Text = selectedTreatment.TreatingDoctorID?.ToString() ?? string.Empty;
                txtSelectedExtra2.Text = selectedTreatment.ClinicNumber?.ToString() ?? string.Empty;
            }
        }

        private void SetTreatmentTypeItems()
        {
            cmbTreatmentType.Items.Clear();
            cmbTreatmentType.Items.Add("Internal Treatment");
            cmbTreatmentType.Items.Add("External Treatment");
            cmbTreatmentType.SelectedIndex = 0;
        }

        private void ApplyTreatmentTypeFields()
        {
            string selectedType = cmbTreatmentType.SelectedItem?.ToString() ?? "Internal Treatment";

            if (selectedType == "Internal Treatment")
            {
                lblExtra1.Text = "Discharge Date:";
                lblExtra2.Text = "Department ID:";
            }
            else
            {
                lblExtra1.Text = "Treating Doctor ID:";
                lblExtra2.Text = "Clinic Number:";
            }

            lblExtra1.Visible = true;
            txtExtra1.Visible = true;
            lblExtra2.Visible = true;
            txtExtra2.Visible = true;
        }

        private void ShowAddMode()
        {
            currentMode = "Add";
            grpTreatmentAction.Text = "Treatment Action";
            btnSaveTreatment.Text = "Add";
            btnSaveTreatment.Visible = true;
            btnClearTreatment.Visible = true;

            lblTreatmentType.Visible = true;
            cmbTreatmentType.Visible = true;
            lblTreatmentType.Text = "Treatment Type:";
            lblTreatmentID.Visible = true;
            txtTreatmentID.Visible = true;
            lblTreatmentID.Text = "Treatment ID:";
            lblPatientID.Visible = true;
            txtPatientID.Visible = true;
            lblPatientID.Text = "Patient ID:";
            lblTreatmentDate.Visible = true;
            dtpTreatmentDate.Visible = true;
            lblTreatmentDate.Text = "Treatment Date:";
            lblCost.Visible = true;
            txtCost.Visible = true;
            lblCost.Text = "Cost:";
            dtpEndDate.Visible = false;
            lblEndDate.Visible = false;

            ShowSelectedTreatmentEditor(false);
            ClearSelectedTreatmentEditor();
            ResetInputs();
            SetTreatmentTypeItems();
            ApplyTreatmentTypeFields();
        }

        private void ShowUpdateMode()
        {
            currentMode = "Update";
            grpTreatmentAction.Text = "Update Treatment";
            btnSaveTreatment.Text = "Update";
            btnSaveTreatment.Visible = true;
            btnClearTreatment.Visible = true;

            lblTreatmentType.Visible = false;
            cmbTreatmentType.Visible = false;
            lblTreatmentID.Visible = false;
            txtTreatmentID.Visible = false;
            lblPatientID.Visible = false;
            txtPatientID.Visible = false;
            lblTreatmentDate.Visible = false;
            dtpTreatmentDate.Visible = false;
            lblCost.Visible = false;
            txtCost.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;
            lblEndDate.Visible = false;
            dtpEndDate.Visible = false;

            ShowSelectedTreatmentEditor(false);
            ClearSelectedTreatmentEditor();
            BindGrid(treatments);
            dgvTreatments.ClearSelection();
            dgvTreatments.CurrentCell = null;
        }

        private void ShowDisplayMode()
        {
            currentMode = "Display";
            grpTreatmentAction.Text = "Display Treatments";
            btnSaveTreatment.Visible = false;
            btnClearTreatment.Visible = false;

            ResetInputs();
            ShowSelectedTreatmentEditor(false);

            lblTreatmentType.Visible = true;
            cmbTreatmentType.Visible = true;
            lblTreatmentType.Text = "Display Type:";
            cmbTreatmentType.Items.Clear();
            cmbTreatmentType.Items.Add("Display All Treatments");
            cmbTreatmentType.Items.Add("Display Internal Treatments");
            cmbTreatmentType.Items.Add("Display External Treatments");
            cmbTreatmentType.SelectedIndex = 0;

            lblTreatmentID.Visible = false;
            txtTreatmentID.Visible = false;
            lblPatientID.Visible = false;
            txtPatientID.Visible = false;
            lblTreatmentDate.Visible = false;
            dtpTreatmentDate.Visible = false;
            lblCost.Visible = false;
            txtCost.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;
            lblEndDate.Visible = false;
            dtpEndDate.Visible = false;
        }

        private void ShowDisplayPatientTreatmentsMode()
        {
            currentMode = "DisplayPatientTreatments";
            grpTreatmentAction.Text = "Display Patient Treatments";
            btnSaveTreatment.Text = "Display";
            btnSaveTreatment.Visible = true;
            btnClearTreatment.Visible = true;

            ResetInputs();
            ShowSelectedTreatmentEditor(false);

            lblTreatmentType.Visible = false;
            cmbTreatmentType.Visible = false;
            lblTreatmentID.Visible = false;
            txtTreatmentID.Visible = false;
            lblPatientID.Visible = true;
            txtPatientID.Visible = true;
            lblPatientID.Text = "Patient ID:";
            lblTreatmentDate.Visible = false;
            dtpTreatmentDate.Visible = false;
            lblCost.Visible = false;
            txtCost.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;
            lblEndDate.Visible = false;
            dtpEndDate.Visible = false;
        }

        private void ShowDisplayAllDepartmentsMode()
        {
            currentMode = "DisplayAllDepartments";
            grpTreatmentAction.Text = "Patients In All Departments";
            btnSaveTreatment.Text = "Display";
            btnSaveTreatment.Visible = true;
            btnClearTreatment.Visible = true;

            ResetInputs();
            ShowSelectedTreatmentEditor(false);

            lblTreatmentType.Visible = false;
            cmbTreatmentType.Visible = false;
            lblTreatmentID.Visible = false;
            txtTreatmentID.Visible = false;
            lblPatientID.Visible = false;
            txtPatientID.Visible = false;
            lblTreatmentDate.Visible = true;
            dtpTreatmentDate.Visible = true;
            lblTreatmentDate.Text = "Start Date:";
            lblCost.Visible = false;
            txtCost.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;
            lblEndDate.Visible = true;
            dtpEndDate.Visible = true;
            lblEndDate.Text = "End Date:";
            dtpEndDate.Format = DateTimePickerFormat.Short;
        }

        private void ShowCountPatientsMode()
        {
            currentMode = "CountPatients";
            grpTreatmentAction.Text = "Count Patients In Department";
            btnSaveTreatment.Text = "Count";
            btnSaveTreatment.Visible = true;
            btnClearTreatment.Visible = true;

            ResetInputs();
            ShowSelectedTreatmentEditor(false);

            lblTreatmentType.Visible = false;
            cmbTreatmentType.Visible = false;
            lblTreatmentID.Visible = false;
            txtTreatmentID.Visible = false;
            lblPatientID.Visible = true;
            txtPatientID.Visible = true;
            lblPatientID.Text = "Department ID:";
            lblTreatmentDate.Visible = true;
            dtpTreatmentDate.Visible = true;
            lblTreatmentDate.Text = "Start Date:";
            lblCost.Visible = false;
            txtCost.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;
            lblEndDate.Visible = true;
            dtpEndDate.Visible = true;
            lblEndDate.Text = "End Date:";
            dtpEndDate.Format = DateTimePickerFormat.Short;
        }

        private void ApplyDisplayFilter()
        {
            string displayType = cmbTreatmentType.SelectedItem?.ToString() ?? "Display All Treatments";

            if (displayType == "Display All Treatments")
            {
                BindGrid(treatments);
                return;
            }

            string treatmentType = displayType switch
            {
                "Display Internal Treatments" => "Internal Treatment",
                "Display External Treatments" => "External Treatment",
                _ => string.Empty
            };

            BindGrid(treatments.Where(treatment => treatment.Type == treatmentType));
        }

        private void dgvTreatments_SelectionChanged(object? sender, EventArgs e)
        {
            if (currentMode == "Update")
            {
                SetUpdateEditorVisibleFromSelection();
                LoadSelectedTreatmentIntoEditor();
            }
        }

        private void cmbTreatmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTreatmentType.SelectedItem == null)
                return;

            if (currentMode == "Display")
            {
                ApplyDisplayFilter();
                return;
            }

            if (currentMode != "Add")
                return;

            ApplyTreatmentTypeFields();
        }

        private void btnSaveTreatment_Click(object sender, EventArgs e)
        {
            if (currentMode == "Update")
            {
                TreatmentRow? selectedTreatment = GetSelectedTreatment();

                if (selectedTreatment == null)
                {
                    MessageBox.Show("Select a treatment from the table first.", "Update Treatment",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!decimal.TryParse(txtSelectedCost.Text.Trim(), out decimal updatedCost))
                {
                    MessageBox.Show("Enter a valid cost.", "Update Treatment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedTreatment.TreatmentDateValue = dtpSelectedTreatmentDate.Value.Date;
                selectedTreatment.Cost = updatedCost;

                if (selectedTreatment.Type == "Internal Treatment")
                {
                    if (txtSelectedExtra1.Text.Trim().Equals("N", StringComparison.OrdinalIgnoreCase) ||
                        string.IsNullOrWhiteSpace(txtSelectedExtra1.Text))
                    {
                        selectedTreatment.DischargeDateValue = null;
                    }
                    else if (DateTime.TryParse(txtSelectedExtra1.Text.Trim(), out DateTime dischargeDate))
                    {
                        selectedTreatment.DischargeDateValue = dischargeDate;
                    }
                    else
                    {
                        MessageBox.Show("Enter a valid discharge date or N.", "Update Treatment",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(txtSelectedExtra2.Text.Trim(), out int updatedDepartmentId))
                    {
                        MessageBox.Show("Enter a valid department ID.", "Update Treatment",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    selectedTreatment.DepartmentID = updatedDepartmentId;
                }
                else
                {
                    if (!int.TryParse(txtSelectedExtra1.Text.Trim(), out int updatedDoctorId))
                    {
                        MessageBox.Show("Enter a valid treating doctor ID.", "Update Treatment",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(txtSelectedExtra2.Text.Trim(), out int updatedClinicNumber))
                    {
                        MessageBox.Show("Enter a valid clinic number.", "Update Treatment",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    selectedTreatment.TreatingDoctorID = updatedDoctorId;
                    selectedTreatment.ClinicNumber = updatedClinicNumber;
                }

                UpdateTreatmentDetails();
                BindGrid(treatments);
                MessageBox.Show("Treatment updated successfully.", "Update Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentMode == "DisplayPatientTreatments")
            {
                if (!int.TryParse(txtPatientID.Text.Trim(), out int patientId))
                {
                    MessageBox.Show("Enter a valid patient ID.", "Display Patient Treatments",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BindGrid(treatments.Where(treatment => treatment.PatientID == patientId));
                return;
            }

            if (currentMode == "DisplayAllDepartments")
            {
                DateTime startDate = dtpTreatmentDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;
                int[] allDepartments = { 1, 2, 3 };

                List<int> patientIds = treatments
                    .Where(treatment => treatment.Type == "Internal Treatment" &&
                                        treatment.TreatmentDateValue.Date >= startDate &&
                                        treatment.TreatmentDateValue.Date <= endDate &&
                                        treatment.DepartmentID.HasValue)
                    .GroupBy(treatment => treatment.PatientID)
                    .Where(group => allDepartments.All(departmentId =>
                        group.Any(treatment => treatment.DepartmentID == departmentId)))
                    .Select(group => group.Key)
                    .ToList();

                if (patientIds.Count == 0)
                {
                    MessageBox.Show("No internal patients were treated in all departments during this period.",
                        "Patients In All Departments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(new List<PatientSummaryRow>());
                    return;
                }

                BindGrid(patientIds.Select(patientId => new PatientSummaryRow
                {
                    PatientID = patientId,
                    Note = "Treated In All Departments",
                    Period = startDate.ToShortDateString() + " - " + endDate.ToShortDateString()
                }));
                return;
            }

            if (currentMode == "CountPatients")
            {
                if (!int.TryParse(txtPatientID.Text.Trim(), out int departmentId))
                {
                    MessageBox.Show("Enter a valid department ID.", "Count Patients",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime startDate = dtpTreatmentDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;

                int patientsCount = treatments
                    .Where(treatment => treatment.Type == "Internal Treatment" &&
                                        treatment.DepartmentID == departmentId &&
                                        treatment.TreatmentDateValue.Date >= startDate &&
                                        treatment.TreatmentDateValue.Date <= endDate)
                    .Select(treatment => treatment.PatientID)
                    .Distinct()
                    .Count();

                MessageBox.Show("Patients Count = " + patientsCount, "Count Patients",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string treatmentType = cmbTreatmentType.SelectedItem?.ToString() ?? "Internal Treatment";

            if (!int.TryParse(txtTreatmentID.Text.Trim(), out int treatmentId))
            {
                MessageBox.Show("Enter a valid treatment ID.", "Add Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (treatments.Any(treatment => treatment.TreatmentID == treatmentId))
            {
                MessageBox.Show("This treatment ID already exists.", "Add Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPatientID.Text.Trim(), out int patientIdToAdd))
            {
                MessageBox.Show("Enter a valid patient ID.", "Add Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validPatientIds.Contains(patientIdToAdd))
            {
                MessageBox.Show("Patient not found. Please enter a valid patient ID.", "Add Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCost.Text.Trim(), out decimal treatmentCost))
            {
                MessageBox.Show("Enter a valid cost.", "Add Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TreatmentRow newTreatment = new TreatmentRow
            {
                TreatmentID = treatmentId,
                Type = treatmentType,
                PatientID = patientIdToAdd,
                TreatmentDateValue = dtpTreatmentDate.Value.Date,
                Cost = treatmentCost
            };

            if (treatmentType == "Internal Treatment")
            {
                if (txtExtra1.Text.Trim().Equals("N", StringComparison.OrdinalIgnoreCase) ||
                    string.IsNullOrWhiteSpace(txtExtra1.Text))
                {
                    newTreatment.DischargeDateValue = null;
                }
                else if (DateTime.TryParse(txtExtra1.Text.Trim(), out DateTime dischargeDate))
                {
                    newTreatment.DischargeDateValue = dischargeDate;
                }
                else
                {
                    MessageBox.Show("Enter a valid discharge date or N.", "Add Treatment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtExtra2.Text.Trim(), out int departmentId))
                {
                    MessageBox.Show("Enter a valid department ID.", "Add Treatment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                newTreatment.DepartmentID = departmentId;
            }
            else
            {
                if (!int.TryParse(txtExtra1.Text.Trim(), out int doctorId))
                {
                    MessageBox.Show("Enter a valid treating doctor ID.", "Add Treatment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!validDoctorIds.Contains(doctorId))
                {
                    MessageBox.Show("Treating doctor not found. Please enter a valid doctor ID.", "Add Treatment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtExtra2.Text.Trim(), out int clinicNumber))
                {
                    MessageBox.Show("Enter a valid clinic number.", "Add Treatment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                newTreatment.TreatingDoctorID = doctorId;
                newTreatment.ClinicNumber = clinicNumber;
            }

            treatments.Add(newTreatment);
            UpdateTreatmentDetails();
            BindGrid(treatments);
            MessageBox.Show("Treatment added successfully.", "Add Treatment",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowAddMode();
        }

        private void btnDeleteTreatment_Click(object sender, EventArgs e)
        {
            TreatmentRow? selectedTreatment = GetSelectedTreatment();

            if (selectedTreatment == null)
            {
                MessageBox.Show("Select a treatment from the table first.", "Delete Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmDelete = MessageBox.Show(
                "Are you sure you want to delete treatment #" + selectedTreatment.TreatmentID + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmDelete != DialogResult.Yes)
                return;

            treatments.Remove(selectedTreatment);
            BindGrid(treatments);
            ClearSelectedTreatmentEditor();
        }

        private void btnClearTreatment_Click(object sender, EventArgs e)
        {
            if (currentMode == "Update")
            {
                LoadSelectedTreatmentIntoEditor();
                return;
            }

            if (currentMode == "Add")
            {
                ShowAddMode();
                return;
            }

            ResetInputs();
            ClearSelectedTreatmentEditor();
        }

        private void btnAddTreatment_Click(object sender, EventArgs e)
        {
            ShowAddMode();
            BindGrid(treatments);
        }

        private void btnUpdateTreatment_Click(object sender, EventArgs e)
        {
            ShowUpdateMode();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            ShowDisplayMode();
        }

        private void btnDisplayPatientTreatments_Click(object sender, EventArgs e)
        {
            ShowDisplayPatientTreatmentsMode();
        }

        private void btnDisplayAllDepartments_Click(object sender, EventArgs e)
        {
            ShowDisplayAllDepartmentsMode();
        }

        private void btnCountPatients_Click(object sender, EventArgs e)
        {
            ShowCountPatientsMode();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            Close();
        }
    }
}
