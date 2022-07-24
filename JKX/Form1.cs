using System;
using Interfaces;
using PL.WinForms;
using System.Linq;
using System.Windows.Forms;

namespace JKX
{
    public partial class Form1 : Form
    {
        private ICounterBL _counterBL;
        private IRateBL _rateBL;
        private IReadingBL _readingBL;
        private IServiceBL _serviceBL;
        public Form1(ICounterBL counterBL, IRateBL rateBL, IReadingBL readingBL, IServiceBL serviceBL)
        {
            _counterBL = counterBL;
            _rateBL = rateBL;
            _readingBL = readingBL;
            _serviceBL = serviceBL;
            InitializeComponent();
            dgvServices.DataSource = _serviceBL.GetAll();
            dgvRates.DataSource = _rateBL.GetAll();
            dgvReadings.DataSource = _readingBL.GetAll();
            dgvCounters.DataSource = _counterBL.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvServices.DataSource = _serviceBL.GetAll();
            dgvRates.DataSource = _rateBL.GetAll();
            dgvCounters.DataSource = _counterBL.GetAll();
            dgvReadings.DataSource = _readingBL.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (TabPage.SelectedIndex == 0)
            {
                var editServiceForm = new EditServiceForm();
                var dialogResult = editServiceForm.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    _serviceBL.Add(editServiceForm.LocalService);

                    dgvServices.DataSource = _serviceBL.GetAll();
                }
            }
            if (TabPage.SelectedIndex == 1)
            {
                var editRateForm = new EditRateForm();
                var dialogResult = editRateForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _rateBL.Add(editRateForm.LocalRate);
                    dgvRates.DataSource = _rateBL.GetAll();
                }
            }
            if (TabPage.SelectedIndex == 2)
            {
                var editCounterForm = new EditCounterForm();
                var dialogResult = editCounterForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _counterBL.Add(editCounterForm.LocalCounter);
                    dgvCounters.DataSource = _counterBL.GetAll();
                }
            }
            if (TabPage.SelectedIndex == 3)
            {
                var editReadingsForm = new EditReadingForm();
                var dialogResult = editReadingsForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _readingBL.Add(editReadingsForm.LocalReading);
                    dgvReadings.DataSource = _readingBL.GetAll();
                }
            }
        }
    }
}