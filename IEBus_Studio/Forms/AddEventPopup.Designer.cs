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
            this.label2.Location = new System.Drawing.Point(11, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Master Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Slave Address:";
            // 
            // masterAddress
            // 
            this.masterAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.masterAddress.Location = new System.Drawing.Point(134, 68);
            this.masterAddress.Name = "masterAddress";
            this.masterAddress.Size = new System.Drawing.Size(100, 20);
            this.masterAddress.TabIndex = 3;
            // 
            // slaveAddress
            // 
            this.slaveAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.slaveAddress.Location = new System.Drawing.Point(134, 108);
            this.slaveAddress.Name = "slaveAddress";
            this.slaveAddress.Size = new System.Drawing.Size(100, 20);
            this.slaveAddress.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(171, 154);
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
            this.addButton.Location = new System.Drawing.Point(90, 154);
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
            this.masterErrorLabel.Location = new System.Drawing.Point(131, 52);
            this.masterErrorLabel.Name = "masterErrorLabel";
            this.masterErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.masterErrorLabel.TabIndex = 7;
            // 
            // slaveErrorLabel
            // 
            this.slaveErrorLabel.AutoSize = true;
            this.slaveErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.slaveErrorLabel.Location = new System.Drawing.Point(131, 92);
            this.slaveErrorLabel.Name = "slaveErrorLabel";
            this.slaveErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.slaveErrorLabel.TabIndex = 8;
            // 
            // AddEventPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 189);
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
            this.Text = "AddEventPopup";
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
    }
}