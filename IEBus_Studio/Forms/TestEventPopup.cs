using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ExpressionEvaluation;

namespace IEBus_Studio
{
    public partial class TestEventPopup : Form
    {
        private Form1 _mainForm;
        private Event _theEvent;
        private System.IO.Ports.SerialPort _serialPort;
        private TextBox[] _variables;
        private Label[] _variableLabels;
        private Label[] _variableHexLabels;
        private ToolTip[] _variableTooltips;
        private int checksumFieldIndex;

        public string parsedChecksumCalc;
        public ExpressionEval expr = new ExpressionEval();

        public TestEventPopup(Form1 mainForm, Event theEvent, System.IO.Ports.SerialPort serialPort)
        {
            expr.AdditionalFunctionEventHandler += new AdditionalFunctionEventHandler(expr_AdditionalFunctionEventHandler);

            InitializeComponent();
            _mainForm = mainForm;
            _theEvent = theEvent;
            _serialPort = serialPort;

            _variables = new TextBox[_theEvent.DynamicVariables.Count];
            _variableLabels = new Label[_theEvent.DynamicVariables.Count];
            _variableHexLabels = new Label[_theEvent.DynamicVariables.Count];
            _variableTooltips = new ToolTip[_theEvent.DynamicVariables.Count];

            this.Text = "Test: "+theEvent.Name;
            this.EventDescription.Text = theEvent.Description;
            this.label1.Text = theEvent.Name;

            int dynTop = 112;

            // Create the labels and textboxes for all the variables
            for (int i = 0; i < _variables.Length; i++)
            {
                // Create the label for the variable
                _variableLabels[i] = new Label();
                _variableLabels[i].Name = "variable" + i + "Label";
                _variableLabels[i].Text = _theEvent.DynamicVariables[i].Replace("%", "") + ": ";
                _variableLabels[i].Anchor = AnchorStyles.Top | AnchorStyles.Left;
                _variableLabels[i].Top = dynTop + 4 + (26 * i);
                _variableLabels[i].Left = 25;
                _variableLabels[i].AutoSize = true;
                _variableLabels[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Controls.Add(_variableLabels[i]);

                // Create the tooltip for the label
                _variableTooltips[i] = new ToolTip();
                _variableTooltips[i].SetToolTip(_variableLabels[i], "Variable data for the "+_theEvent.DynamicVariables[i].Replace("%", "")+" field.");

                // Create the textbox for the variable
                _variables[i] = new TextBox();
                _variables[i].Name = "variable" + i + "Data";
                _variables[i].Text = "0";
                _variables[i].Anchor = AnchorStyles.Top | AnchorStyles.Right;
                _variables[i].Width = 100;
                _variables[i].Top = dynTop + (26 * i);
                _variables[i].Left = this.Width - 120;
                _variables[i].TextChanged += new System.EventHandler(this.updateChecksumValue);

                // Create the hex label for the variable
                _variableHexLabels[i] = new Label();
                _variableHexLabels[i].Name = "variable" + i + "HexLabel";
                _variableHexLabels[i].Text = "0x0";
                _variableHexLabels[i].Anchor = AnchorStyles.Top | AnchorStyles.Right;
                _variableHexLabels[i].Width = 50;
                _variableHexLabels[i].Top = dynTop  + (26 * i);
                _variableHexLabels[i].Left = _variables[i].Left - 55;
                _variableHexLabels[i].TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                _variableHexLabels[i].AutoSize = false;
                _variableHexLabels[i].RightToLeft = RightToLeft.No;
                this.Controls.Add(_variableHexLabels[i]);

                //Makes use of the ExpressionEval project by railerb
                //Found at http://www.codeproject.com/csharp/expressionevaluator.asp
                if ((!_theEvent.ChecksumCalc.Equals("")) && ((_theEvent.DynamicVariables[i].ToLower()).Contains("checksum")))
                {
                    checksumFieldIndex = i;
                    parsedChecksumCalc = _theEvent.ChecksumCalc;
                    //Replace the named variables with actual variable references
                    for (int k = 0; k < _variables.Length; k++)
                    {
                        if ( _theEvent.ChecksumCalc.Contains(_theEvent.DynamicVariables[k]) )
                        {
                            parsedChecksumCalc = parsedChecksumCalc.Replace(_theEvent.DynamicVariables[k], "$variables(" + k + ")");
                        }
                    }
                    expr.Expression = parsedChecksumCalc;
                }
                this.Controls.Add(_variables[i]);
            }

            this.Height = _theEvent.DynamicVariables.Count * 26 + 188;
        }

        private bool IsNumeric(string s)
        {
            try
            {
                Int32.Parse(s);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void updateChecksumValue(object sender, EventArgs e)
        {
            TextBox tempBox = (TextBox)sender;
            if ((tempBox.Text == "") || (!IsNumeric(tempBox.Text)))
            {
                tempBox.Text = "0";
            }
            _variables[checksumFieldIndex].Text = expr.Evaluate().ToString();
            
            for (int i = 0; i < _variables.Length; i++)
            {
                _variableHexLabels[i].Text = String.Format("0x{0:X}", Convert.ToInt32(_variables[i].Text));
            }
        }

        private void expr_AdditionalFunctionEventHandler(object sender, AdditionalFunctionEventArgs e)
        {
            object[] parameters = e.GetParameters();
            switch (e.Name)
            {
                case "variables":
                    e.ReturnValue = Convert.ToInt32(_variables[Convert.ToInt32(parameters[0].ToString())].Text);
                    break;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            _mainForm.Enabled = true;
            _mainForm.Focus();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            List<string> varNames = new List<string>();
            List<string> varValues = new List<string>();

            for(int i = 0; i < _variables.Length; i++)
            {
                varNames.Add(_variableLabels[i].Text.Substring(0, _variableLabels[i].Text.Length - 1));
                varValues.Add(_variables[i].Text);
            }

            _theEvent.perform(_serialPort, varNames, varValues);

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