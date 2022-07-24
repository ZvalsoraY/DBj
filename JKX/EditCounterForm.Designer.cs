namespace PL.WinForms
{
    partial class EditCounterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbServiceId = new System.Windows.Forms.TextBox();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.tbCapacity = new System.Windows.Forms.TextBox();
            this.tbDecimalCapacity = new System.Windows.Forms.TextBox();
            this.tbInitialValue = new System.Windows.Forms.TextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.btnSaveCounter_Click = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ServiceId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serial Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Capacity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Decimal Capacity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Initial Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Data";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(175, 33);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(250, 27);
            this.tbName.TabIndex = 7;
            // 
            // tbServiceId
            // 
            this.tbServiceId.Location = new System.Drawing.Point(175, 66);
            this.tbServiceId.Name = "tbServiceId";
            this.tbServiceId.Size = new System.Drawing.Size(250, 27);
            this.tbServiceId.TabIndex = 8;
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(175, 103);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(250, 27);
            this.tbSerialNumber.TabIndex = 9;
            // 
            // tbCapacity
            // 
            this.tbCapacity.Location = new System.Drawing.Point(175, 143);
            this.tbCapacity.Name = "tbCapacity";
            this.tbCapacity.Size = new System.Drawing.Size(250, 27);
            this.tbCapacity.TabIndex = 10;
            // 
            // tbDecimalCapacity
            // 
            this.tbDecimalCapacity.Location = new System.Drawing.Point(175, 181);
            this.tbDecimalCapacity.Name = "tbDecimalCapacity";
            this.tbDecimalCapacity.Size = new System.Drawing.Size(250, 27);
            this.tbDecimalCapacity.TabIndex = 11;
            // 
            // tbInitialValue
            // 
            this.tbInitialValue.Location = new System.Drawing.Point(175, 220);
            this.tbInitialValue.Name = "tbInitialValue";
            this.tbInitialValue.Size = new System.Drawing.Size(250, 27);
            this.tbInitialValue.TabIndex = 12;
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(175, 260);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(250, 27);
            this.dtpData.TabIndex = 13;
            // 
            // btnSaveCounter_Click
            // 
            this.btnSaveCounter_Click.Location = new System.Drawing.Point(155, 328);
            this.btnSaveCounter_Click.Name = "btnSaveCounter_Click";
            this.btnSaveCounter_Click.Size = new System.Drawing.Size(94, 29);
            this.btnSaveCounter_Click.TabIndex = 14;
            this.btnSaveCounter_Click.Text = "Save";
            this.btnSaveCounter_Click.UseVisualStyleBackColor = true;
            this.btnSaveCounter_Click.Click += new System.EventHandler(this.btnSaveCounter_Click_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditCounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 389);
            this.Controls.Add(this.btnSaveCounter_Click);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.tbInitialValue);
            this.Controls.Add(this.tbDecimalCapacity);
            this.Controls.Add(this.tbCapacity);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.tbServiceId);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditCounterForm";
            this.Text = "EditCounterForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox tbName;
        private TextBox tbServiceId;
        private TextBox tbSerialNumber;
        private TextBox tbCapacity;
        private TextBox tbDecimalCapacity;
        private TextBox tbInitialValue;
        private DateTimePicker dtpData;
        private Button btnSaveCounter_Click;
        private ErrorProvider errorProvider1;
    }
}