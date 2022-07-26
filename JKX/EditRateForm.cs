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
    public partial class EditRateForm : Form
    {
        public Rate LocalRate { get; set; }
        
        public EditRateForm(Rate rate)
        {
            if (rate == null)
            {
                throw new ArgumentNullException(nameof(rate));
            }
            InitializeComponent();
            LocalRate = new Rate(
                rate.Id,
                rate.Name,
                rate.ServiceId,
                rate.Price,
                rate.StartData,
                rate.EndData);
        }
        public EditRateForm()
        {
            InitializeComponent();
        }

        private void EditRateForm_Load(object sender, EventArgs e)
        {
            if (LocalRate == null) return;
            tbName.Text = LocalRate.Name;
            tbServiceId.Text = LocalRate.ServiceId.ToString();
            tbPrice.Text = LocalRate.Price.ToString();
            dtpDataFrom.Value = LocalRate.StartData;
            dtpDataTo.Value = LocalRate.EndData;
        }
        
        private void btnSaveRate_Click_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(tbPrice.Text))
            {
                errorProvider1.SetError(tbPrice, "Price is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(dtpDataFrom.Text))
            {
                errorProvider1.SetError(dtpDataFrom, "Data From is required");
                isValid = false;
            }
            if (string.IsNullOrEmpty(dtpDataTo.Text))
            {
                errorProvider1.SetError(dtpDataTo, "Data To is required");
                isValid = false;
            }

            if (isValid)
            {
                LocalRate = new Rate(tbName.Text, Convert.ToInt32(tbServiceId.Text), Convert.ToInt32(tbPrice.Text), dtpDataFrom.Value, dtpDataTo.Value);
                DialogResult = DialogResult.OK;

                Close();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //private void btnSaveRate_Click_Click(object sender, EventArgs e)
        //{

        //}
    }
}
