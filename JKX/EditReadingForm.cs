using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.WinForms
{
    public partial class EditReadingForm : Form
    {
        public Reading LocalReading { get; set; }
        public EditReadingForm(Reading reading)
        {

            if (reading == null)
            {
                throw new ArgumentNullException(nameof(reading));
            }
            InitializeComponent();
            //LocalUser = user;
            LocalReading = new Reading(
                reading.Id,//
                reading.ServiceId,
                reading.CurValue,
                reading.TransDate);
        }
        public EditReadingForm()
        {
            InitializeComponent();
        }

        private void EditReadingForm_Load(object sender, EventArgs e)
        {
            if (LocalReading == null) return;
            tbServiceId.Text = LocalReading.ServiceId.ToString();
            tbValue.Text = LocalReading.CurValue.ToString();
            dtData.Value = LocalReading.TransDate;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var isValid = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(tbServiceId.Text))
            {
                errorProvider1.SetError(tbServiceId, "ServiceId is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(tbValue.Text))
            {
                errorProvider1.SetError(tbValue, "Value is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(dtData.Text))
            {
                errorProvider1.SetError(dtData, "Data is required");
                isValid = false;
            }

            if (isValid)
            {
                LocalReading = new Reading(Convert.ToInt32(tbServiceId.Text), double.Parse(tbValue.Text), dtData.Value);//
                DialogResult = DialogResult.OK;

                Close();
            }
        }
    }
}
