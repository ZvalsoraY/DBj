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

        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var deleteForm = new DeleteForm();
            var dialogResult = deleteForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {

                if (TabPage.SelectedIndex == 0)
                {
                    var xqxx = dgvServices.SelectedCells[0].RowIndex;
                    var yqxx = dgvServices.Rows[xqxx].Cells[0].Value;
                    var currentService = _serviceBL.GetAll().First(x => x.Id == Convert.ToInt32(yqxx));
                    _serviceBL.Delete(currentService);
                    dgvServices.DataSource = _serviceBL.GetAll();
                }

                if (TabPage.SelectedIndex == 1)
                {
                    var xqxx = dgvRates.SelectedCells[0].RowIndex;
                    var yqxx = dgvRates.Rows[xqxx].Cells[0].Value;
                    var currentRate = _rateBL.GetAll().First(x => x.Id == Convert.ToInt32(yqxx));
                    _rateBL.Delete(currentRate);
                    dgvRates.DataSource = _rateBL.GetAll();
                }

                if (TabPage.SelectedIndex == 2)
                {
                    var xqxx = dgvCounters.SelectedCells[0].RowIndex;
                    var yqxx = dgvCounters.Rows[xqxx].Cells[0].Value;
                    var currentCounter = _counterBL.GetAll().First(x => x.Id == Convert.ToInt32(yqxx));
                    _counterBL.Delete(currentCounter);
                    dgvCounters.DataSource = _counterBL.GetAll();
                }

                if (TabPage.SelectedIndex == 3)
                {
                    var xqxx = dgvReadings.SelectedCells[0].RowIndex;
                    var yqxx = dgvReadings.Rows[xqxx].Cells[0].Value;
                    var currentReading = _readingBL.GetAll().First(x => x.Id == Convert.ToInt32(yqxx));
                    _readingBL.Delete(currentReading);
                    dgvReadings.DataSource = _readingBL.GetAll();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (TabPage.SelectedIndex == 0)
            {
                var xqxx = dgvServices.SelectedCells[0].RowIndex;
                var yqxx = dgvServices.Rows[xqxx].Cells[0].Value;
                var currentService = _serviceBL.GetAll().First(x => x.Id == Convert.ToInt32(yqxx));

                var editServiceForm = new EditServiceForm(currentService);
                var dialogResult = editServiceForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var editedService = editServiceForm.LocalService;
                    editedService.Id = currentService.Id;
                    _serviceBL.Edit(editedService);

                    dgvServices.DataSource = _serviceBL.GetAll();
                }
            }
            if (TabPage.SelectedIndex == 1)
            {
                var xqxx = dgvRates.SelectedCells[0].RowIndex;
                var yqxx = dgvRates.Rows[xqxx].Cells[0].Value;
                var currentRate = _rateBL.GetAll().First(x => x.Id == Convert.ToInt32(yqxx));

                var editRateForm = new EditRateForm(currentRate);
                var dialogResult = editRateForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var editedRate = editRateForm.LocalRate;
                    editedRate.Id = currentRate.Id;
                    _rateBL.Edit(editedRate);

                    dgvRates.DataSource = _rateBL.GetAll();
                }
            }
            if (TabPage.SelectedIndex == 2)
            {
                var xqxx = dgvCounters.SelectedCells[0].RowIndex;
                var yqxx = dgvCounters.Rows[xqxx].Cells[0].Value;
                var currentCounter = _counterBL.GetAll().First(x => x.Id == Convert.ToInt32(yqxx));

                var editCounterForm = new EditCounterForm(currentCounter);
                var dialogResult = editCounterForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var editedCounter = editCounterForm.LocalCounter;
                    editedCounter.Id = currentCounter.Id;
                    _counterBL.Edit(editedCounter);

                    dgvCounters.DataSource = _counterBL.GetAll();
                }
            }
            if (TabPage.SelectedIndex == 3)
            {
                var xqxx = dgvReadings.SelectedCells[0].RowIndex;
                var yqxx = dgvReadings.Rows[xqxx].Cells[0].Value;
                var currentReading = _readingBL.GetAll().First(x => x.Id == Convert.ToInt32(yqxx));

                var editReadingForm = new EditReadingForm(currentReading);
                var dialogResult = editReadingForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var editedReading = editReadingForm.LocalReading;
                    editedReading.Id = currentReading.Id;
                    _readingBL.Edit(editedReading);

                    dgvReadings.DataSource = _readingBL.GetAll();
                }
            }
        }
    }
}