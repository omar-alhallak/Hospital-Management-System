using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Hospital_Management_System_WinForm.FormUI
{
    public partial class DoctorsForm : Form
    {
        private readonly List<DoctorRow> doctors = new List<DoctorRow>();
        private string currentMode = "Add";
        private decimal fixedStaffSalary = 1000m;

        public DoctorsForm()
        {
            InitializeComponent();
        }

        private class DoctorRow
        {
            public int DoctorID { get; set; }
            public string DoctorName { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;

            [Browsable(false)]
            public DateTime BirthDateValue { get; set; }

            public string BirthDate => BirthDateValue.ToShortDateString();
            public string ExtraInfo { get; set; } = string.Empty;
            public decimal Salary { get; set; }

            [Browsable(false)]
            public bool CanBePromoted { get; set; }
        }

        private void DoctorsForm_Load(object sender, EventArgs e)
        {
            dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctors.MultiSelect = false;
            dgvDoctors.AutoGenerateColumns = true;
            dgvDoctors.ReadOnly = true;
            dgvDoctors.AllowUserToAddRows = false;
            dgvDoctors.AllowUserToDeleteRows = false;
            dgvDoctors.SelectionChanged += dgvDoctors_SelectionChanged;

            LoadSampleDoctors();
            UpdateFixedSalaryLabel();
            ShowAddMode();
            BindGrid(doctors);
        }

        private void LoadSampleDoctors()
        {
            doctors.Clear();

            doctors.Add(new DoctorRow
            {
                DoctorID = 1,
                DoctorName = "Bilal",
                Type = "Staff Doctor",
                Address = "Damascus",
                BirthDateValue = new DateTime(1988, 5, 12),
                ExtraInfo = "Hire Date: 01/10/2018",
                Salary = fixedStaffSalary
            });

            doctors.Add(new DoctorRow
            {
                DoctorID = 2,
                DoctorName = "Omar",
                Type = "Trainee Doctor",
                Address = "Aleppo",
                BirthDateValue = new DateTime(1997, 3, 8),
                ExtraInfo = "Start: 01/01/2023 | End: Not Finished Yet",
                Salary = 700m,
                CanBePromoted = true
            });

            doctors.Add(new DoctorRow
            {
                DoctorID = 3,
                DoctorName = "Khaled",
                Type = "Contract Doctor",
                Address = "Homs",
                BirthDateValue = new DateTime(1991, 10, 19),
                ExtraInfo = "Contract",
                Salary = 850m
            });

            doctors.Add(new DoctorRow
            {
                DoctorID = 4,
                DoctorName = "Sami",
                Type = "Staff Doctor",
                Address = "Latakia",
                BirthDateValue = new DateTime(1985, 9, 5),
                ExtraInfo = "Hire Date: 07/04/2015",
                Salary = fixedStaffSalary
            });

            doctors.Add(new DoctorRow
            {
                DoctorID = 5,
                DoctorName = "Lina",
                Type = "Trainee Doctor",
                Address = "Tartus",
                BirthDateValue = new DateTime(1999, 7, 21),
                ExtraInfo = "Start: 01/01/2025 | End: Not Finished Yet",
                Salary = 650m,
                CanBePromoted = false
            });
        }

        private void UpdateFixedSalaryLabel()
        {
            lblFixedSalary.Text = "Current Fixed Staff Salary: " + fixedStaffSalary;
        }

        private void BindGrid(IEnumerable<DoctorRow> rows)
        {
            dgvDoctors.DataSource = null;
            dgvDoctors.DataSource = rows.ToList();

            if (dgvDoctors.Columns["BirthDateValue"] != null)
                dgvDoctors.Columns["BirthDateValue"].Visible = false;

            if (dgvDoctors.Columns["CanBePromoted"] != null)
                dgvDoctors.Columns["CanBePromoted"].Visible = false;

            if (dgvDoctors.Columns["DoctorID"] != null)
                dgvDoctors.Columns["DoctorID"].HeaderText = "ID";

            if (dgvDoctors.Columns["DoctorName"] != null)
                dgvDoctors.Columns["DoctorName"].HeaderText = "Doctor Name";

            if (dgvDoctors.Columns["BirthDate"] != null)
                dgvDoctors.Columns["BirthDate"].HeaderText = "Birth Date";

            if (dgvDoctors.Columns["ExtraInfo"] != null)
                dgvDoctors.Columns["ExtraInfo"].HeaderText = "Details";

            dgvDoctors.ClearSelection();
            dgvDoctors.CurrentCell = null;
        }

        private void ResetInputs()
        {
            txtDoctorID.Clear();
            txtDoctorName.Clear();
            txtAddress.Clear();
            txtExtra1.Clear();
            txtExtra2.Clear();
            dtpBirthDate.Value = DateTime.Today;
        }

        private void ClearSelectedDoctorEditor()
        {
            txtSelectedDoctorName.Clear();
            txtSelectedDoctorAddress.Clear();
            dtpSelectedDoctorBirthDate.Format = DateTimePickerFormat.Custom;
            dtpSelectedDoctorBirthDate.CustomFormat = " ";
            dtpSelectedDoctorBirthDate.Value = DateTime.Today;
        }

        private void SetDoctorTypeItems()
        {
            cmbDoctorType.Items.Clear();
            cmbDoctorType.Items.Add("Staff Doctor");
            cmbDoctorType.Items.Add("Trainee Doctor");
            cmbDoctorType.Items.Add("Contract Doctor");
            cmbDoctorType.SelectedIndex = 0;
        }

        private void ShowSelectedDoctorEditor(bool visible)
        {
            lblSelectedDoctorSection.Visible = visible;
            lblSelectedDoctorName.Visible = visible;
            txtSelectedDoctorName.Visible = visible;
            lblSelectedDoctorAddress.Visible = visible;
            txtSelectedDoctorAddress.Visible = visible;
            lblSelectedDoctorBirthDate.Visible = visible;
            dtpSelectedDoctorBirthDate.Visible = visible;
        }

        private DoctorRow? GetSelectedDoctor()
        {
            if (dgvDoctors.CurrentRow != null &&
                dgvDoctors.CurrentRow.Selected &&
                dgvDoctors.CurrentRow.DataBoundItem is DoctorRow selectedDoctor)
            {
                return doctors.FirstOrDefault(doctor => doctor.DoctorID == selectedDoctor.DoctorID);
            }

            return null;
        }

        private void LoadSelectedDoctorIntoEditor()
        {
            DoctorRow? selectedDoctor = GetSelectedDoctor();

            if (selectedDoctor == null)
            {
                ClearSelectedDoctorEditor();
                return;
            }

            txtSelectedDoctorName.Text = selectedDoctor.DoctorName;
            txtSelectedDoctorAddress.Text = selectedDoctor.Address;
            dtpSelectedDoctorBirthDate.Format = DateTimePickerFormat.Short;
            dtpSelectedDoctorBirthDate.Value = selectedDoctor.BirthDateValue;
        }

        private void RefreshGridForCurrentMode()
        {
            if (currentMode == "Display")
            {
                ApplyDisplayFilter();
                return;
            }

            if (currentMode == "Promote")
            {
                BindGrid(doctors.Where(doctor => doctor.Type == "Trainee Doctor" && doctor.CanBePromoted));
                return;
            }

            BindGrid(doctors);
        }

        private void ApplyDisplayFilter()
        {
            string selectedDisplayType = cmbDoctorType.SelectedItem?.ToString() ?? "Display All Doctors";

            if (selectedDisplayType == "Display All Doctors")
            {
                BindGrid(doctors);
                return;
            }

            string doctorTypeToShow = selectedDisplayType switch
            {
                "Display Staff Doctors" => "Staff Doctor",
                "Display Trainee Doctors" => "Trainee Doctor",
                "Display Contract Doctors" => "Contract Doctor",
                _ => string.Empty
            };

            IEnumerable<DoctorRow> filteredDoctors = doctors.Where(doctor => doctor.Type == doctorTypeToShow);
            BindGrid(filteredDoctors);
        }

        private void ShowAddMode()
        {
            currentMode = "Add";
            grpDoctorAction.Text = "Doctor Action";
            btnSaveDoctor.Text = "Add";
            btnSaveDoctor.Visible = true;
            btnClearDoctor.Visible = true;

            lblDoctorID.Text = "Doctor ID:";
            lblDoctorName.Text = "Doctor Name:";
            lblDoctorType.Text = "Doctor Type:";

            lblDoctorType.Visible = true;
            cmbDoctorType.Visible = true;
            lblDoctorID.Visible = true;
            txtDoctorID.Visible = true;
            lblDoctorName.Visible = true;
            txtDoctorName.Visible = true;
            lblAddress.Visible = true;
            txtAddress.Visible = true;
            lblBirthDate.Visible = true;
            dtpBirthDate.Visible = true;

            ShowSelectedDoctorEditor(false);
            ClearSelectedDoctorEditor();
            ResetInputs();
            SetDoctorTypeItems();
        }

        private void ShowUpdateMode()
        {
            currentMode = "Update";
            grpDoctorAction.Text = "Update Doctor";
            btnSaveDoctor.Text = "Update";
            btnSaveDoctor.Visible = true;
            btnClearDoctor.Visible = true;

            lblDoctorType.Visible = false;
            cmbDoctorType.Visible = false;
            lblDoctorID.Visible = false;
            txtDoctorID.Visible = false;
            lblDoctorName.Visible = false;
            txtDoctorName.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;

            ShowSelectedDoctorEditor(true);
            ClearSelectedDoctorEditor();
            BindGrid(doctors);
            dgvDoctors.ClearSelection();
            dgvDoctors.CurrentCell = null;
        }

        private void ShowSearchMode()
        {
            currentMode = "Search";
            grpDoctorAction.Text = "Search Doctor";
            btnSaveDoctor.Text = "Search";
            btnSaveDoctor.Visible = true;
            btnClearDoctor.Visible = true;

            ResetInputs();
            ShowSelectedDoctorEditor(false);

            lblDoctorType.Visible = true;
            cmbDoctorType.Visible = true;
            lblDoctorType.Text = "Search Type:";
            cmbDoctorType.Items.Clear();
            cmbDoctorType.Items.Add("Search By ID");
            cmbDoctorType.Items.Add("Search By Name");
            cmbDoctorType.SelectedIndex = 0;

            lblDoctorID.Visible = false;
            txtDoctorID.Visible = false;
            lblDoctorName.Visible = true;
            txtDoctorName.Visible = true;
            lblDoctorName.Text = "Search Value:";
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;
        }

        private void ShowDisplayMode()
        {
            currentMode = "Display";
            grpDoctorAction.Text = "Display Doctors";
            btnSaveDoctor.Visible = false;
            btnClearDoctor.Visible = false;

            ResetInputs();
            ShowSelectedDoctorEditor(false);

            lblDoctorType.Visible = true;
            cmbDoctorType.Visible = true;
            lblDoctorType.Text = "Display Type:";
            cmbDoctorType.Items.Clear();
            cmbDoctorType.Items.Add("Display All Doctors");
            cmbDoctorType.Items.Add("Display Staff Doctors");
            cmbDoctorType.Items.Add("Display Trainee Doctors");
            cmbDoctorType.Items.Add("Display Contract Doctors");
            cmbDoctorType.SelectedIndex = 0;

            lblDoctorID.Visible = false;
            txtDoctorID.Visible = false;
            lblDoctorName.Visible = false;
            txtDoctorName.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;
        }

        private void ShowSalaryMode()
        {
            currentMode = "Salary";
            grpDoctorAction.Text = "Update Fixed Staff Salary";
            btnSaveDoctor.Text = "Update Salary";
            btnSaveDoctor.Visible = true;
            btnClearDoctor.Visible = true;

            ResetInputs();
            ShowSelectedDoctorEditor(false);

            lblDoctorType.Visible = false;
            cmbDoctorType.Visible = false;
            lblDoctorID.Visible = false;
            txtDoctorID.Visible = false;
            lblDoctorName.Visible = true;
            txtDoctorName.Visible = true;
            lblDoctorName.Text = "New Fixed Staff Salary:";
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;
        }

        private void ShowPromoteMode()
        {
            currentMode = "Promote";
            grpDoctorAction.Text = "Promote Trainee Doctor";
            btnSaveDoctor.Text = "Promote";
            btnSaveDoctor.Visible = true;
            btnClearDoctor.Visible = true;

            ResetInputs();
            ShowSelectedDoctorEditor(false);

            lblDoctorType.Visible = false;
            cmbDoctorType.Visible = false;
            lblDoctorID.Visible = true;
            txtDoctorID.Visible = true;
            lblDoctorID.Text = "Trainee Doctor ID:";
            lblDoctorName.Visible = false;
            txtDoctorName.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            txtExtra2.Visible = false;

            BindGrid(doctors.Where(doctor => doctor.Type == "Trainee Doctor" && doctor.CanBePromoted));
        }

        private void dgvDoctors_SelectionChanged(object? sender, EventArgs e)
        {
            if (currentMode == "Update")
                LoadSelectedDoctorIntoEditor();

            if (currentMode == "Promote")
            {
                DoctorRow? selectedDoctor = GetSelectedDoctor();
                txtDoctorID.Text = selectedDoctor?.DoctorID.ToString() ?? string.Empty;
            }
        }

        private void cmbDoctorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDoctorType.SelectedItem == null)
                return;

            if (currentMode == "Display")
            {
                ApplyDisplayFilter();
                return;
            }

            if (currentMode != "Add")
                return;

            txtExtra1.Clear();
            txtExtra2.Clear();

            string selectedType = cmbDoctorType.SelectedItem.ToString() ?? string.Empty;

            if (selectedType == "Staff Doctor")
            {
                lblExtra1.Text = "Hire Date:";
                lblExtra1.Visible = true;
                txtExtra1.Visible = true;
                lblExtra2.Visible = false;
                txtExtra2.Visible = false;
            }
            else if (selectedType == "Trainee Doctor")
            {
                lblExtra1.Text = "Training Start Date:";
                lblExtra1.Visible = true;
                txtExtra1.Visible = true;
                lblExtra2.Text = "Training End Date:";
                lblExtra2.Visible = true;
                txtExtra2.Visible = true;
            }
            else
            {
                lblExtra1.Visible = false;
                txtExtra1.Visible = false;
                lblExtra2.Visible = false;
                txtExtra2.Visible = false;
            }
        }

        private void btnClearDoctor_Click(object sender, EventArgs e)
        {
            if (currentMode == "Update")
            {
                LoadSelectedDoctorIntoEditor();
                return;
            }

            if (currentMode == "Display")
            {
                ShowDisplayMode();
                return;
            }

            if (currentMode == "Add")
            {
                ShowAddMode();
                return;
            }

            ResetInputs();
            ClearSelectedDoctorEditor();
        }

        private void btnSaveDoctor_Click(object sender, EventArgs e)
        {
            if (currentMode == "Update")
            {
                DoctorRow? selectedDoctor = GetSelectedDoctor();

                if (selectedDoctor == null)
                {
                    MessageBox.Show("Select a doctor from the table first.", "Update Doctor",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                selectedDoctor.DoctorName = txtSelectedDoctorName.Text.Trim();
                selectedDoctor.Address = txtSelectedDoctorAddress.Text.Trim();
                selectedDoctor.BirthDateValue = dtpSelectedDoctorBirthDate.Value.Date;

                RefreshGridForCurrentMode();
                MessageBox.Show("Doctor data updated successfully.", "Update Doctor",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentMode == "Search")
            {
                string selectedSearchType = cmbDoctorType.SelectedItem?.ToString() ?? "Search By ID";
                string searchValue = txtDoctorName.Text.Trim();

                if (selectedSearchType == "Search By ID")
                {
                    if (!int.TryParse(searchValue, out int doctorId))
                    {
                        MessageBox.Show("Enter a valid doctor ID.", "Search Doctor",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DoctorRow? foundDoctor = doctors.FirstOrDefault(doctor => doctor.DoctorID == doctorId);

                    if (foundDoctor == null)
                    {
                        MessageBox.Show("Doctor not found.", "Search Doctor",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    BindGrid(new[] { foundDoctor });
                    return;
                }

                BindGrid(doctors.Where(doctor =>
                    doctor.DoctorName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)));
                return;
            }

            if (currentMode == "Salary")
            {
                if (!decimal.TryParse(txtDoctorName.Text.Trim(), out decimal newSalary))
                {
                    MessageBox.Show("Enter a valid salary.", "Update Salary",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                fixedStaffSalary = newSalary;

                foreach (DoctorRow doctor in doctors.Where(doctor => doctor.Type == "Staff Doctor"))
                    doctor.Salary = fixedStaffSalary;

                UpdateFixedSalaryLabel();
                RefreshGridForCurrentMode();

                MessageBox.Show("Fixed staff salary updated successfully.", "Update Salary",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentMode == "Promote")
            {
                if (!int.TryParse(txtDoctorID.Text.Trim(), out int doctorId))
                {
                    MessageBox.Show("Enter a valid trainee doctor ID.", "Promote Doctor",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DoctorRow? traineeDoctor = doctors.FirstOrDefault(doctor =>
                    doctor.DoctorID == doctorId && doctor.Type == "Trainee Doctor" && doctor.CanBePromoted);

                if (traineeDoctor == null)
                {
                    MessageBox.Show("No promotable trainee doctor was found with this ID.", "Promote Doctor",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                traineeDoctor.Type = "Staff Doctor";
                traineeDoctor.ExtraInfo = "Promoted To Staff Doctor";
                traineeDoctor.Salary = fixedStaffSalary;
                traineeDoctor.CanBePromoted = false;

                BindGrid(doctors.Where(doctor => doctor.Type == "Trainee Doctor" && doctor.CanBePromoted));
                MessageBox.Show("Doctor promoted successfully.", "Promote Doctor",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedType = cmbDoctorType.SelectedItem?.ToString() ?? "Staff Doctor";

            if (!int.TryParse(txtDoctorID.Text.Trim(), out int newDoctorId))
            {
                MessageBox.Show("Enter a valid doctor ID.", "Add Doctor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (doctors.Any(doctor => doctor.DoctorID == newDoctorId))
            {
                MessageBox.Show("This doctor ID already exists.", "Add Doctor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DoctorRow newDoctor = new DoctorRow
            {
                DoctorID = newDoctorId,
                DoctorName = txtDoctorName.Text.Trim(),
                Type = selectedType,
                Address = txtAddress.Text.Trim(),
                BirthDateValue = dtpBirthDate.Value.Date,
                Salary = selectedType == "Staff Doctor" ? fixedStaffSalary :
                    selectedType == "Trainee Doctor" ? 700m : 850m,
                CanBePromoted = selectedType == "Trainee Doctor"
            };

            if (selectedType == "Staff Doctor")
                newDoctor.ExtraInfo = "Hire Date: " + txtExtra1.Text.Trim();
            else if (selectedType == "Trainee Doctor")
                newDoctor.ExtraInfo = "Start: " + txtExtra1.Text.Trim() + " | End: " + (string.IsNullOrWhiteSpace(txtExtra2.Text) ? "Not Finished Yet" : txtExtra2.Text.Trim());
            else
                newDoctor.ExtraInfo = "Contract";

            doctors.Add(newDoctor);
            RefreshGridForCurrentMode();

            MessageBox.Show("Doctor added successfully.", "Add Doctor",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowAddMode();
        }

        private void btnDeleteDoctor_Click(object sender, EventArgs e)
        {
            DoctorRow? selectedDoctor = GetSelectedDoctor();

            if (selectedDoctor == null)
            {
                MessageBox.Show("Select a doctor from the table first.", "Delete Doctor",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmDelete = MessageBox.Show(
                "Are you sure you want to delete " + selectedDoctor.DoctorName + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmDelete != DialogResult.Yes)
                return;

            doctors.Remove(selectedDoctor);
            ClearSelectedDoctorEditor();
            RefreshGridForCurrentMode();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            ShowAddMode();
            BindGrid(doctors);
        }

        private void btnUpdateDoctor_Click(object sender, EventArgs e)
        {
            ShowUpdateMode();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowSearchMode();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            ShowDisplayMode();
        }

        private void btnUpdateFixedStaffSalary_Click(object sender, EventArgs e)
        {
            ShowSalaryMode();
        }

        private void btnPromoteTraineeDoctor_Click(object sender, EventArgs e)
        {
            ShowPromoteMode();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            Close();
        }
    }
}
