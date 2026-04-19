//using Hospital_Management_System_WinForm.Application.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System_WinForm.FormUI
{
    public partial class MainForm : Form
    {
        //private DoctorManagement doctorMang;
        public MainForm()//DoctorManagement doctorMang
        {
            InitializeComponent();
            //this.doctorMang = doctorMang;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            DoctorsForm form = new DoctorsForm();
            form.Show();
            Hide();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            PatientsForm form = new PatientsForm();
            form.Show();
            Hide();
        }

        private void btnTreatments_Click(object sender, EventArgs e)
        {
            TreatmentsForm form = new TreatmentsForm();
            form.Show();
            Hide();
        }
    }
}
