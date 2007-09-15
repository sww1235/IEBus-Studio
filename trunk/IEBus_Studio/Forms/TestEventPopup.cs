using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEBus_Studio
{
    public partial class TestEventPopup : Form
    {
        private Form1 _mainForm;
        private Event _theEvent;
        private TextBox[] _variables;
        private Label[] _variableLabels;

        public TestEventPopup(Form1 mainForm, Event theEvent)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _theEvent = theEvent;

            _variables = new TextBox[_theEvent.DynamicVariables.Count];
            _variableLabels = new Label[_theEvent.DynamicVariables.Count];

            // Create the labels and textboxes for all the variables
            for (int i = 0; i < _variables.Length; i++)
            {
                // Create the label for the variable
                _variableLabels[i] = new Label();
                _variableLabels[i].Name = "variable" + i + "Label";
                _variableLabels[i].Text = _theEvent.DynamicVariables[i] + ": ";
                _variableLabels[i].Anchor = AnchorStyles.Top | AnchorStyles.Left;
                _variableLabels[i].Top = 50 + 35 * i;
                _variableLabels[i].Left = 10;
                _variableLabels[i].AutoSize = true;
                this.Controls.Add(_variableLabels[i]);

                // Create the textbox for the variable
                _variables[i] = new TextBox();
                _variables[i].Name = "variable" + i + "Data";
                _variables[i].Text = "0";
                _variables[i].Anchor = AnchorStyles.Top | AnchorStyles.Right;
                _variables[i].Width = 100;
                _variables[i].Top = 50 + 35 * i;
                _variables[i].Left = this.Width - 110;
                this.Controls.Add(_variables[i]);
            }

            this.Height = _theEvent.DynamicVariables.Count * 35 + 125;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < _variables.Length; i++)
            {
                string varName = _variableLabels[i].Text.Substring(0, _variableLabels[i].Text.Length - 1);
                string varValue = _variables[i].Text;
            }
            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
        }

        void TestEventPopup_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
        }
    }
}