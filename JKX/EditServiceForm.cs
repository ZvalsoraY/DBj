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
    public partial class EditServiceForm : Form
    {
        public Service LocalService { get; set; }

        public EditServiceForm(Service service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }
            InitializeComponent();
            LocalService = new Service(
                service.Id,
                service.Name);
        }
        public EditServiceForm()
        {
            InitializeComponent();
        }

        private void EditServiceForm_Load(object sender, EventArgs e)
        {
            if (LocalService == null) return;
            tbName.Text = LocalService.Name;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveService_Click_Click(object sender, EventArgs e)
        {
            var isValid = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(tbName.Text))
            {
                errorProvider1.SetError(tbName, "Name is required");
                isValid = false;
            }

            if (isValid)
            {
                LocalService = new Service(tbName.Text);
                DialogResult = DialogResult.OK;

                Close();
            }
        }
    }
}

