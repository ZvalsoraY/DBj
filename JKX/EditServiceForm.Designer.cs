namespace PL.WinForms
{
    partial class EditServiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveService_Click = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(87, 58);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(273, 27);
            this.tbName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSaveService_Click
            // 
            this.btnSaveService_Click.Location = new System.Drawing.Point(94, 132);
            this.btnSaveService_Click.Name = "btnSaveService_Click";
            this.btnSaveService_Click.Size = new System.Drawing.Size(94, 29);
            this.btnSaveService_Click.TabIndex = 2;
            this.btnSaveService_Click.Text = "Save";
            this.btnSaveService_Click.UseVisualStyleBackColor = true;
            this.btnSaveService_Click.Click += new System.EventHandler(this.btnSaveService_Click_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 280);
            this.Controls.Add(this.btnSaveService_Click);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Name = "EditServiceForm";
            this.Text = "EditServiceForm";
            this.Load += new System.EventHandler(this.EditServiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbName;
        private Label label1;
        private Button btnSaveService_Click;
        private ErrorProvider errorProvider1;
    }
}