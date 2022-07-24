using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace PL.WinForms
{
    public partial class EditCounterForm : Form
    {
        public Counter LocalCounter { get; set; }
        public EditCounterForm(Counter counter)
        {
            if (counter == null)
            {
                throw new ArgumentNullException(nameof(counter));
            }
            InitializeComponent();
            LocalCounter = new Counter(
                counter.Id,
                counter.Name,
                counter.ServiceId,
                counter.SerialNumber,
                counter.Capacity,
                counter.DecimalCapacity,
                counter.InitialValue,
                counter.CreateData);
        }
        public EditCounterForm()
        {
            InitializeComponent();
        }
        private void EditCounterForm_Load(object sender, EventArgs e)
        {
            if (LocalCounter == null) return;
            tbName.Text = LocalCounter.Name;
            tbServiceId.Text = LocalCounter.ServiceId.ToString();
            tbSerialNumber.Text = LocalCounter.SerialNumber.ToString();
            tbCapacity.Text = LocalCounter.Capacity.ToString();
            tbDecimalCapacity.Text = LocalCounter.DecimalCapacity.ToString();
            tbInitialValue.Text = LocalCounter.InitialValue.ToString();
            dtpData.Value = LocalCounter.CreateData;           
        }

        private void btnSaveCounter_Click_Click(object sender, EventArgs e)
        {
            var isValid = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(tbName.Text))
            {
                errorProvider1.SetError(tbName, "Name is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(tbServiceId.Text))
            {
                errorProvider1.SetError(tbServiceId, "ServiceId is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(tbSerialNumber.Text))
            {
                errorProvider1.SetError(tbSerialNumber, "Serial Number is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(tbCapacity.Text))
            {
                errorProvider1.SetError(tbCapacity, "Capacity is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(tbDecimalCapacity.Text))
            {
                errorProvider1.SetError(tbDecimalCapacity, "Decimal Capacity is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(tbInitialValue.Text))
            {
                errorProvider1.SetError(tbInitialValue, "Initial Value is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(dtpData.Text))
            {
                errorProvider1.SetError(dtpData, "Data is required");
                isValid = false;
            }

            if (isValid)
            {
                LocalCounter = new Counter(tbName.Text, Convert.ToInt32(tbServiceId.Text), Convert.ToInt32(tbSerialNumber.Text)
                    , Convert.ToInt32(tbCapacity.Text), Convert.ToInt32(tbDecimalCapacity.Text), Convert.ToInt32(tbInitialValue.Text)
                    , dtpData.Value);
                DialogResult = DialogResult.OK;

                Close();
            }
        }
        
    }
}
