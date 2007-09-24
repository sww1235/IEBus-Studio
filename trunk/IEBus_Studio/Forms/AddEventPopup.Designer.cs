namespace IEBus_Studio
{
    partial class AddEventPopup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.masterAddress = new System.Windows.Forms.TextBox();
            this.slaveAddress = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.masterErrorLabel = new System.Windows.Forms.Label();
            this.slaveErrorLabel = new System.Windows.Forms.Label();
            this.broadcastCheckbox = new System.Windows.Forms.CheckBox();
            this.controlCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Give the device a master address and a slave address in a hex string format. (ie." +
                " 0x131)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Master Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Slave Address:";
            // 
            // masterAddress
            // 
            this.masterAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.masterAddress.Location = new System.Drawing.Point(134, 74);
            this.masterAddress.Name = "masterAddress";
            this.masterAddress.Size = new System.Drawing.Size(99, 20);
            this.masterAddress.TabIndex = 3;
            // 
            // slaveAddress
            // 
            this.slaveAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.slaveAddress.Location = new System.Drawing.Point(134, 100);
            this.slaveAddress.Name = "slaveAddress";
            this.slaveAddress.Size = new System.Drawing.Size(99, 20);
            this.slaveAddress.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(170, 162);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(89, 162);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add Event";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // masterErrorLabel
            // 
            this.masterErrorLabel.AutoSize = true;
            this.masterErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.masterErrorLabel.Location = new System.Drawing.Point(131, 50);
            this.masterErrorLabel.Name = "masterErrorLabel";
            this.masterErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.masterErrorLabel.TabIndex = 7;
            // 
            // slaveErrorLabel
            // 
            this.slaveErrorLabel.AutoSize = true;
            this.slaveErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.slaveErrorLabel.Location = new System.Drawing.Point(131, 118);
            this.slaveErrorLabel.Name = "slaveErrorLabel";
            this.slaveErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.slaveErrorLabel.TabIndex = 8;
            // 
            // broadcastCheckbox
            // 
            this.broadcastCheckbox.AutoSize = true;
            this.broadcastCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.broadcastCheckbox.Location = new System.Drawing.Point(12, 50);
            this.broadcastCheckbox.Name = "broadcastCheckbox";
            this.broadcastCheckbox.Size = new System.Drawing.Size(74, 17);
            this.broadcastCheckbox.TabIndex = 10;
            this.broadcastCheckbox.Text = "Broadcast";
            this.broadcastCheckbox.UseVisualStyleBackColor = true;
            // 
            // controlCombo
            // 
            this.controlCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.controlCombo.FormattingEnabled = true;
            this.controlCombo.Items.AddRange(new object[] {
            "SlaveStatusRead",
            "Undefined1",
            "Undefined2",
            "DataReadAndLock",
            "LockAddressRead_Lower8Bits",
            "LockAddressRead_Upper4Bits",
            "SlaveStatusReadAndUnlock",
            "DataRead",
            "Undefined3",
            "Undefined4",
            "CommandWriteAndLock",
            "DataWriteAndLock",
            "Undefined5",
            "Undefined6",
            "CommandWrite",
            "DataWrite"});
            this.controlCombo.Location = new System.Drawing.Point(134, 126);
            this.controlCombo.Name = "controlCombo";
            this.controlCombo.Size = new System.Drawing.Size(99, 21);
            this.controlCombo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Control";
            // 
            // AddEventPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 197);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.controlCombo);
            this.Controls.Add(this.broadcastCheckbox);
            this.Controls.Add(this.slaveErrorLabel);
            this.Controls.Add(this.masterErrorLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.slaveAddress);
            this.Controls.Add(this.masterAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEventPopup";
            this.Text = "Add Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox masterAddress;
        private System.Windows.Forms.TextBox slaveAddress;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label masterErrorLabel;
        private System.Windows.Forms.Label slaveErrorLabel;
        private System.Windows.Forms.CheckBox broadcastCheckbox;
        private System.Windows.Forms.ComboBox controlCombo;
        private System.Windows.Forms.Label label4;
    }
}