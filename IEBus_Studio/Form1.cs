using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace IEBus_Studio
{
	/// <summary>
	/// Summary description for Form1.
    /// </summary>


	public class Form1 : System.Windows.Forms.Form
    {
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripButton newToolStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton printToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton cutToolStripButton;
        private ToolStripButton copyToolStripButton;
        private ToolStripButton pasteToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton helpToolStripButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private Button Connect;
        private GroupBox groupBox1;
        private ComboBox bitsPerSecond;
        private Label label1;
        private Label label2;
        private ComboBox dataBits;
        private Label label4;
        private ComboBox stopBits;
        private Label label3;
        private ComboBox parity;
        private Label label5;
        private ComboBox flowControl;
        private Label label6;
        private ComboBox port;
        private Button connectComButton;
        private Button disconnectComButton;
        private GroupBox groupBox2;
        private TextBox outputPath;
        private Button outputBrowse;
        private SaveFileDialog chooseOutputFile;
        private CheckBox outputRawCheckBox;
        private Label label7;
        private Button stopButton;
        private Button pauseButton;
        private Button startButton;
        private System.IO.Ports.SerialPort serialPort1;
        private IContainer components;
        private ToolStripMenuItem changeMessageTableToolStripMenuItem;
        private TabControl MessageTableTabs;
        private TabPage RawMessageTableTab;
        private DataGridView RawMessageTable;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private TabPage ParsedMessageTableTab;
        private DataGridView ParsedMessageTable;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Master;
        private DataGridViewTextBoxColumn Slave;
        private DataGridViewTextBoxColumn Control;
        private DataGridViewTextBoxColumn DataSize;
        private DataGridViewTextBoxColumn Data1;
        private TabPage terminalTab;
        private TextBox terminal;
        private TabPage eventDiscoveryTab;
        private Button discoverEvent;
        private TextBox secondsToDiscover;
        private Label label8;
        private DataGridView eventDiscoveryTable;
        private TabPage devicesTab;
        private DataGridView devicesTable;
        private Button addDevice;
        private TabPage eventsTab;
        private DataGridView eventsTable;
        private Button addEvent;
        private DataGridViewTextBoxColumn Event_Name;
        private DataGridViewTextBoxColumn Event_Description;
        private DataGridViewTextBoxColumn Event_Broadcast;
        private DataGridViewTextBoxColumn Event_MasterDevice;
        private DataGridViewTextBoxColumn event_SlaveAddress;
        private DataGridViewTextBoxColumn Event_Control;
        private DataGridViewTextBoxColumn Event_DataSize;
        private DataGridViewTextBoxColumn Event_Data;
        private Button scanDevices;
        private OpenFileDialog openFileDialog1;
        private DataGridViewTextBoxColumn devices_deviceAddress;
        private DataGridViewTextBoxColumn devices_name;
        private DataGridViewTextBoxColumn devices_description;
        private ContextMenuStrip EventActionsMenuStrip;
        private ToolStripMenuItem addEventToolStripMenuItem;

        private EventManager eventManager = new EventManager();
        private DeviceManager deviceManager = new DeviceManager();
        private EventDiscovery eventDiscoverer = new EventDiscovery();
        private string opened_filename = "";
        private Label timeLeftLabel;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        public String serialBuffer = "This is a test.";

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//byte[] test = null;
			//PacketDecoder myDecoder = new PacketDecoder(test);
			//myDecoder.packet.data

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeMessageTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MessageTableTabs = new System.Windows.Forms.TabControl();
            this.RawMessageTableTab = new System.Windows.Forms.TabPage();
            this.RawMessageTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParsedMessageTableTab = new System.Windows.Forms.TabPage();
            this.ParsedMessageTable = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Master = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalTab = new System.Windows.Forms.TabPage();
            this.terminal = new System.Windows.Forms.TextBox();
            this.eventDiscoveryTab = new System.Windows.Forms.TabPage();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.eventDiscoveryTable = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventActionsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discoverEvent = new System.Windows.Forms.Button();
            this.secondsToDiscover = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.devicesTab = new System.Windows.Forms.TabPage();
            this.scanDevices = new System.Windows.Forms.Button();
            this.addDevice = new System.Windows.Forms.Button();
            this.devicesTable = new System.Windows.Forms.DataGridView();
            this.devices_deviceAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devices_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devices_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventsTab = new System.Windows.Forms.TabPage();
            this.addEvent = new System.Windows.Forms.Button();
            this.eventsTable = new System.Windows.Forms.DataGridView();
            this.Event_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_Broadcast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_MasterDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_SlaveAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_DataSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.outputRawCheckBox = new System.Windows.Forms.CheckBox();
            this.outputPath = new System.Windows.Forms.TextBox();
            this.outputBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.disconnectComButton = new System.Windows.Forms.Button();
            this.connectComButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowControl = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stopBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.parity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataBits = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bitsPerSecond = new System.Windows.Forms.ComboBox();
            this.Connect = new System.Windows.Forms.Button();
            this.chooseOutputFile = new System.Windows.Forms.SaveFileDialog();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MessageTableTabs.SuspendLayout();
            this.RawMessageTableTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RawMessageTable)).BeginInit();
            this.ParsedMessageTableTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsedMessageTable)).BeginInit();
            this.terminalTab.SuspendLayout();
            this.eventDiscoveryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventDiscoveryTable)).BeginInit();
            this.EventActionsMenuStrip.SuspendLayout();
            this.devicesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesTable)).BeginInit();
            this.eventsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(831, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(148, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator6,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(147, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeMessageTableToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // changeMessageTableToolStripMenuItem
            // 
            this.changeMessageTableToolStripMenuItem.Name = "changeMessageTableToolStripMenuItem";
            this.changeMessageTableToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.changeMessageTableToolStripMenuItem.Text = "Choose Message Table";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(126, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 490);
            this.panel1.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel1.Controls.Add(this.MessageTableTabs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(831, 490);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.TabIndex = 0;
            // 
            // MessageTableTabs
            // 
            this.MessageTableTabs.Controls.Add(this.RawMessageTableTab);
            this.MessageTableTabs.Controls.Add(this.ParsedMessageTableTab);
            this.MessageTableTabs.Controls.Add(this.terminalTab);
            this.MessageTableTabs.Controls.Add(this.eventDiscoveryTab);
            this.MessageTableTabs.Controls.Add(this.devicesTab);
            this.MessageTableTabs.Controls.Add(this.eventsTab);
            this.MessageTableTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageTableTabs.Location = new System.Drawing.Point(0, 0);
            this.MessageTableTabs.Name = "MessageTableTabs";
            this.MessageTableTabs.SelectedIndex = 0;
            this.MessageTableTabs.Size = new System.Drawing.Size(831, 334);
            this.MessageTableTabs.TabIndex = 5;
            // 
            // RawMessageTableTab
            // 
            this.RawMessageTableTab.Controls.Add(this.RawMessageTable);
            this.RawMessageTableTab.Location = new System.Drawing.Point(4, 22);
            this.RawMessageTableTab.Name = "RawMessageTableTab";
            this.RawMessageTableTab.Padding = new System.Windows.Forms.Padding(3);
            this.RawMessageTableTab.Size = new System.Drawing.Size(823, 308);
            this.RawMessageTableTab.TabIndex = 0;
            this.RawMessageTableTab.Text = "Raw";
            this.RawMessageTableTab.UseVisualStyleBackColor = true;
            // 
            // RawMessageTable
            // 
            this.RawMessageTable.AllowUserToAddRows = false;
            this.RawMessageTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            this.RawMessageTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.RawMessageTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RawMessageTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RawMessageTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RawMessageTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20});
            this.RawMessageTable.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RawMessageTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawMessageTable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.RawMessageTable.Location = new System.Drawing.Point(3, 3);
            this.RawMessageTable.MultiSelect = false;
            this.RawMessageTable.Name = "RawMessageTable";
            this.RawMessageTable.ReadOnly = true;
            this.RawMessageTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.RawMessageTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.RawMessageTable.RowTemplate.Height = 18;
            this.RawMessageTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RawMessageTable.ShowEditingIcon = false;
            this.RawMessageTable.Size = new System.Drawing.Size(817, 302);
            this.RawMessageTable.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "B";
            this.Column1.MaxInputLength = 1;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.ToolTipText = "Broadcast Bit";
            this.Column1.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "\"0x\"0000";
            dataGridViewCellStyle2.NullValue = "0x0";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "Master";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Format = "\"0x\"0000";
            dataGridViewCellStyle3.NullValue = "0x0";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "Slave";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 65;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Format = "\"0x\"0000";
            dataGridViewCellStyle4.NullValue = "0x0";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "Control";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "Size";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 35;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 25;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 25;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 25;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 25;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "";
            this.dataGridViewTextBoxColumn9.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 25;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "";
            this.dataGridViewTextBoxColumn10.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 25;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "";
            this.dataGridViewTextBoxColumn11.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 25;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "";
            this.dataGridViewTextBoxColumn12.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 25;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "";
            this.dataGridViewTextBoxColumn13.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 25;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "";
            this.dataGridViewTextBoxColumn14.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 25;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "";
            this.dataGridViewTextBoxColumn15.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 25;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "";
            this.dataGridViewTextBoxColumn16.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 25;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "";
            this.dataGridViewTextBoxColumn17.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 25;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "";
            this.dataGridViewTextBoxColumn18.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 25;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "";
            this.dataGridViewTextBoxColumn19.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 25;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn20.HeaderText = "";
            this.dataGridViewTextBoxColumn20.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // ParsedMessageTableTab
            // 
            this.ParsedMessageTableTab.Controls.Add(this.ParsedMessageTable);
            this.ParsedMessageTableTab.Location = new System.Drawing.Point(4, 22);
            this.ParsedMessageTableTab.Name = "ParsedMessageTableTab";
            this.ParsedMessageTableTab.Padding = new System.Windows.Forms.Padding(3);
            this.ParsedMessageTableTab.Size = new System.Drawing.Size(823, 308);
            this.ParsedMessageTableTab.TabIndex = 1;
            this.ParsedMessageTableTab.Text = "Parsed";
            this.ParsedMessageTableTab.UseVisualStyleBackColor = true;
            // 
            // ParsedMessageTable
            // 
            this.ParsedMessageTable.AllowUserToAddRows = false;
            this.ParsedMessageTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ParsedMessageTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.ParsedMessageTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ParsedMessageTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ParsedMessageTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParsedMessageTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Master,
            this.Slave,
            this.Control,
            this.DataSize,
            this.Data1});
            this.ParsedMessageTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.ParsedMessageTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParsedMessageTable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.ParsedMessageTable.Location = new System.Drawing.Point(3, 3);
            this.ParsedMessageTable.Margin = new System.Windows.Forms.Padding(0);
            this.ParsedMessageTable.Name = "ParsedMessageTable";
            this.ParsedMessageTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.ParsedMessageTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.ParsedMessageTable.RowTemplate.Height = 18;
            this.ParsedMessageTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParsedMessageTable.Size = new System.Drawing.Size(817, 302);
            this.ParsedMessageTable.TabIndex = 4;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "B";
            this.Column2.MaxInputLength = 1;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.ToolTipText = "Broadcast Bit";
            this.Column2.Width = 20;
            // 
            // Master
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Master.DefaultCellStyle = dataGridViewCellStyle7;
            this.Master.HeaderText = "Master";
            this.Master.MaxInputLength = 1024;
            this.Master.Name = "Master";
            this.Master.ReadOnly = true;
            this.Master.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Slave
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info;
            this.Slave.DefaultCellStyle = dataGridViewCellStyle8;
            this.Slave.HeaderText = "Slave";
            this.Slave.MaxInputLength = 1024;
            this.Slave.Name = "Slave";
            this.Slave.ReadOnly = true;
            this.Slave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Control
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            this.Control.DefaultCellStyle = dataGridViewCellStyle9;
            this.Control.HeaderText = "Control";
            this.Control.MaxInputLength = 50;
            this.Control.Name = "Control";
            this.Control.ReadOnly = true;
            this.Control.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Control.Width = 75;
            // 
            // DataSize
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = "0";
            this.DataSize.DefaultCellStyle = dataGridViewCellStyle10;
            this.DataSize.HeaderText = "Size";
            this.DataSize.MaxInputLength = 2;
            this.DataSize.Name = "DataSize";
            this.DataSize.ReadOnly = true;
            this.DataSize.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataSize.Width = 35;
            // 
            // Data1
            // 
            this.Data1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Data1.HeaderText = "Data";
            this.Data1.MaxInputLength = 4;
            this.Data1.Name = "Data1";
            this.Data1.ReadOnly = true;
            // 
            // terminalTab
            // 
            this.terminalTab.Controls.Add(this.terminal);
            this.terminalTab.Location = new System.Drawing.Point(4, 22);
            this.terminalTab.Name = "terminalTab";
            this.terminalTab.Padding = new System.Windows.Forms.Padding(3);
            this.terminalTab.Size = new System.Drawing.Size(823, 308);
            this.terminalTab.TabIndex = 2;
            this.terminalTab.Text = "Terminal";
            this.terminalTab.UseVisualStyleBackColor = true;
            // 
            // terminal
            // 
            this.terminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminal.Location = new System.Drawing.Point(3, 3);
            this.terminal.Multiline = true;
            this.terminal.Name = "terminal";
            this.terminal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.terminal.Size = new System.Drawing.Size(817, 302);
            this.terminal.TabIndex = 0;
            // 
            // eventDiscoveryTab
            // 
            this.eventDiscoveryTab.Controls.Add(this.timeLeftLabel);
            this.eventDiscoveryTab.Controls.Add(this.eventDiscoveryTable);
            this.eventDiscoveryTab.Controls.Add(this.discoverEvent);
            this.eventDiscoveryTab.Controls.Add(this.secondsToDiscover);
            this.eventDiscoveryTab.Controls.Add(this.label8);
            this.eventDiscoveryTab.Location = new System.Drawing.Point(4, 22);
            this.eventDiscoveryTab.Name = "eventDiscoveryTab";
            this.eventDiscoveryTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventDiscoveryTab.Size = new System.Drawing.Size(823, 308);
            this.eventDiscoveryTab.TabIndex = 3;
            this.eventDiscoveryTab.Text = "Event Discovery";
            this.eventDiscoveryTab.UseVisualStyleBackColor = true;
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.Location = new System.Drawing.Point(295, 13);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(0, 13);
            this.timeLeftLabel.TabIndex = 6;
            // 
            // eventDiscoveryTable
            // 
            this.eventDiscoveryTable.AllowUserToAddRows = false;
            this.eventDiscoveryTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.eventDiscoveryTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.eventDiscoveryTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventDiscoveryTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.eventDiscoveryTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventDiscoveryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDiscoveryTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26});
            this.eventDiscoveryTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.eventDiscoveryTable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.eventDiscoveryTable.Location = new System.Drawing.Point(3, 39);
            this.eventDiscoveryTable.Margin = new System.Windows.Forms.Padding(0);
            this.eventDiscoveryTable.Name = "eventDiscoveryTable";
            this.eventDiscoveryTable.RowTemplate.ContextMenuStrip = this.EventActionsMenuStrip;
            this.eventDiscoveryTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.eventDiscoveryTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.eventDiscoveryTable.RowTemplate.Height = 18;
            this.eventDiscoveryTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.eventDiscoveryTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDiscoveryTable.Size = new System.Drawing.Size(817, 266);
            this.eventDiscoveryTable.TabIndex = 5;
            this.eventDiscoveryTable.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.EventDiscoveryTable_RowContextMenuStripNeeded);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Instances";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "B";
            this.dataGridViewTextBoxColumn21.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn21.ToolTipText = "Broadcast Bit";
            this.dataGridViewTextBoxColumn21.Width = 25;
            // 
            // dataGridViewTextBoxColumn22
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.Format = "\"0x\"0000";
            this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn22.HeaderText = "Master Address";
            this.dataGridViewTextBoxColumn22.MaxInputLength = 1024;
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn22.Width = 115;
            // 
            // dataGridViewTextBoxColumn23
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle13.Format = "\"0x\"0000";
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn23.HeaderText = "Slave Address";
            this.dataGridViewTextBoxColumn23.MaxInputLength = 1024;
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn23.Width = 115;
            // 
            // dataGridViewTextBoxColumn24
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle14.Format = "\"0x\"0000";
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn24.HeaderText = "Control";
            this.dataGridViewTextBoxColumn24.MaxInputLength = 50;
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn24.Width = 50;
            // 
            // dataGridViewTextBoxColumn25
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = "0";
            this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn25.HeaderText = "Size";
            this.dataGridViewTextBoxColumn25.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn25.Width = 75;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn26.HeaderText = "Data";
            this.dataGridViewTextBoxColumn26.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            // 
            // EventActionsMenuStrip
            // 
            this.EventActionsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEventToolStripMenuItem});
            this.EventActionsMenuStrip.Name = "EventActions";
            this.EventActionsMenuStrip.Size = new System.Drawing.Size(136, 26);
            // 
            // addEventToolStripMenuItem
            // 
            this.addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            this.addEventToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addEventToolStripMenuItem.Text = "Add Event";
            // 
            // discoverEvent
            // 
            this.discoverEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discoverEvent.Location = new System.Drawing.Point(723, 10);
            this.discoverEvent.Name = "discoverEvent";
            this.discoverEvent.Size = new System.Drawing.Size(92, 20);
            this.discoverEvent.TabIndex = 2;
            this.discoverEvent.Text = "Discover Event";
            this.discoverEvent.UseVisualStyleBackColor = true;
            this.discoverEvent.Click += new System.EventHandler(this.discoverEvent_Click);
            // 
            // secondsToDiscover
            // 
            this.secondsToDiscover.Location = new System.Drawing.Point(179, 10);
            this.secondsToDiscover.Name = "secondsToDiscover";
            this.secondsToDiscover.Size = new System.Drawing.Size(98, 20);
            this.secondsToDiscover.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Number of Seconds To Discover:";
            // 
            // devicesTab
            // 
            this.devicesTab.Controls.Add(this.scanDevices);
            this.devicesTab.Controls.Add(this.addDevice);
            this.devicesTab.Controls.Add(this.devicesTable);
            this.devicesTab.Location = new System.Drawing.Point(4, 22);
            this.devicesTab.Name = "devicesTab";
            this.devicesTab.Padding = new System.Windows.Forms.Padding(3);
            this.devicesTab.Size = new System.Drawing.Size(823, 308);
            this.devicesTab.TabIndex = 4;
            this.devicesTab.Text = "Devices";
            this.devicesTab.UseVisualStyleBackColor = true;
            // 
            // scanDevices
            // 
            this.scanDevices.Location = new System.Drawing.Point(8, 10);
            this.scanDevices.Name = "scanDevices";
            this.scanDevices.Size = new System.Drawing.Size(92, 20);
            this.scanDevices.TabIndex = 8;
            this.scanDevices.Text = "Scan Devices";
            this.scanDevices.UseVisualStyleBackColor = true;
            this.scanDevices.Click += new System.EventHandler(this.scanDevices_Click);
            // 
            // addDevice
            // 
            this.addDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addDevice.Location = new System.Drawing.Point(725, 10);
            this.addDevice.Name = "addDevice";
            this.addDevice.Size = new System.Drawing.Size(92, 20);
            this.addDevice.TabIndex = 7;
            this.addDevice.Text = "Add Device";
            this.addDevice.UseVisualStyleBackColor = true;
            this.addDevice.Click += new System.EventHandler(this.addDevice_Click);
            // 
            // devicesTable
            // 
            this.devicesTable.AllowUserToAddRows = false;
            this.devicesTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.devicesTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.devicesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.devicesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.devicesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.devicesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.devices_deviceAddress,
            this.devices_name,
            this.devices_description});
            this.devicesTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.devicesTable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.devicesTable.Location = new System.Drawing.Point(3, 39);
            this.devicesTable.Margin = new System.Windows.Forms.Padding(0);
            this.devicesTable.Name = "devicesTable";
            this.devicesTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.devicesTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.devicesTable.RowTemplate.Height = 18;
            this.devicesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.devicesTable.Size = new System.Drawing.Size(817, 266);
            this.devicesTable.TabIndex = 6;
            this.devicesTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.saveDeviceChanges);
            this.devicesTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.saveDeviceChanges);
            // 
            // devices_deviceAddress
            // 
            this.devices_deviceAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devices_deviceAddress.DefaultCellStyle = dataGridViewCellStyle17;
            this.devices_deviceAddress.HeaderText = "Address";
            this.devices_deviceAddress.MaxInputLength = 1024;
            this.devices_deviceAddress.Name = "devices_deviceAddress";
            this.devices_deviceAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // devices_name
            // 
            this.devices_name.HeaderText = "Name";
            this.devices_name.Name = "devices_name";
            this.devices_name.Width = 250;
            // 
            // devices_description
            // 
            this.devices_description.HeaderText = "Description";
            this.devices_description.Name = "devices_description";
            this.devices_description.Width = 450;
            // 
            // eventsTab
            // 
            this.eventsTab.Controls.Add(this.addEvent);
            this.eventsTab.Controls.Add(this.eventsTable);
            this.eventsTab.Location = new System.Drawing.Point(4, 22);
            this.eventsTab.Name = "eventsTab";
            this.eventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventsTab.Size = new System.Drawing.Size(823, 308);
            this.eventsTab.TabIndex = 5;
            this.eventsTab.Text = "Events";
            this.eventsTab.UseVisualStyleBackColor = true;
            // 
            // addEvent
            // 
            this.addEvent.Location = new System.Drawing.Point(8, 10);
            this.addEvent.Name = "addEvent";
            this.addEvent.Size = new System.Drawing.Size(92, 20);
            this.addEvent.TabIndex = 8;
            this.addEvent.Text = "Add Event";
            this.addEvent.UseVisualStyleBackColor = true;
            this.addEvent.Click += new System.EventHandler(this.addEvent_Click);
            // 
            // eventsTable
            // 
            this.eventsTable.AllowUserToAddRows = false;
            this.eventsTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.eventsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle18;
            this.eventsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventsTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.eventsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Event_Name,
            this.Event_Description,
            this.Event_Broadcast,
            this.Event_MasterDevice,
            this.event_SlaveAddress,
            this.Event_Control,
            this.Event_DataSize,
            this.Event_Data});
            this.eventsTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.eventsTable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.eventsTable.Location = new System.Drawing.Point(3, 39);
            this.eventsTable.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.eventsTable.Name = "eventsTable";
            this.eventsTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.eventsTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.eventsTable.RowTemplate.Height = 18;
            this.eventsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventsTable.Size = new System.Drawing.Size(817, 266);
            this.eventsTable.TabIndex = 7;
            this.eventsTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.saveEventChanges);
            this.eventsTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.saveEventChanges);
            // 
            // Event_Name
            // 
            this.Event_Name.HeaderText = "Name";
            this.Event_Name.Name = "Event_Name";
            // 
            // Event_Description
            // 
            this.Event_Description.HeaderText = "Description";
            this.Event_Description.Name = "Event_Description";
            // 
            // Event_Broadcast
            // 
            this.Event_Broadcast.HeaderText = "B";
            this.Event_Broadcast.Name = "Event_Broadcast";
            this.Event_Broadcast.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Event_Broadcast.ToolTipText = "Broadcast";
            this.Event_Broadcast.Width = 20;
            // 
            // Event_MasterDevice
            // 
            this.Event_MasterDevice.HeaderText = "Master Device";
            this.Event_MasterDevice.Name = "Event_MasterDevice";
            this.Event_MasterDevice.Width = 115;
            // 
            // event_SlaveAddress
            // 
            this.event_SlaveAddress.HeaderText = "Slave Address";
            this.event_SlaveAddress.Name = "event_SlaveAddress";
            this.event_SlaveAddress.Width = 115;
            // 
            // Event_Control
            // 
            this.Event_Control.HeaderText = "Control";
            this.Event_Control.Name = "Event_Control";
            this.Event_Control.Width = 50;
            // 
            // Event_DataSize
            // 
            this.Event_DataSize.HeaderText = "DataSize";
            this.Event_DataSize.Name = "Event_DataSize";
            this.Event_DataSize.Width = 75;
            // 
            // Event_Data
            // 
            this.Event_Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Event_Data.HeaderText = "Data";
            this.Event_Data.Name = "Event_Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.pauseButton);
            this.groupBox2.Controls.Add(this.startButton);
            this.groupBox2.Controls.Add(this.outputRawCheckBox);
            this.groupBox2.Controls.Add(this.outputPath);
            this.groupBox2.Controls.Add(this.outputBrowse);
            this.groupBox2.Location = new System.Drawing.Point(431, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 135);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Control output to the file";
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton.Location = new System.Drawing.Point(10, 102);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pauseButton.Location = new System.Drawing.Point(224, 102);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(60, 23);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Location = new System.Drawing.Point(290, 102);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(88, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // outputRawCheckBox
            // 
            this.outputRawCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.outputRawCheckBox.AutoSize = true;
            this.outputRawCheckBox.Location = new System.Drawing.Point(10, 21);
            this.outputRawCheckBox.Name = "outputRawCheckBox";
            this.outputRawCheckBox.Size = new System.Drawing.Size(134, 17);
            this.outputRawCheckBox.TabIndex = 2;
            this.outputRawCheckBox.Text = "Output Raw Messages";
            this.outputRawCheckBox.UseVisualStyleBackColor = true;
            // 
            // outputPath
            // 
            this.outputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputPath.Location = new System.Drawing.Point(10, 45);
            this.outputPath.Name = "outputPath";
            this.outputPath.Size = new System.Drawing.Size(274, 20);
            this.outputPath.TabIndex = 1;
            // 
            // outputBrowse
            // 
            this.outputBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.outputBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.outputBrowse.Location = new System.Drawing.Point(290, 43);
            this.outputBrowse.Name = "outputBrowse";
            this.outputBrowse.Size = new System.Drawing.Size(88, 23);
            this.outputBrowse.TabIndex = 0;
            this.outputBrowse.Text = "Browse";
            this.outputBrowse.UseVisualStyleBackColor = true;
            this.outputBrowse.Click += new System.EventHandler(this.outputBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.disconnectComButton);
            this.groupBox1.Controls.Add(this.connectComButton);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.port);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.flowControl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.stopBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.parity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dataBits);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bitsPerSecond);
            this.groupBox1.Controls.Add(this.Connect);
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 135);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // disconnectComButton
            // 
            this.disconnectComButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.disconnectComButton.Location = new System.Drawing.Point(233, 102);
            this.disconnectComButton.Name = "disconnectComButton";
            this.disconnectComButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectComButton.TabIndex = 20;
            this.disconnectComButton.Text = "Disconnect";
            this.disconnectComButton.UseVisualStyleBackColor = true;
            this.disconnectComButton.Click += new System.EventHandler(this.disconnectComButton_Click);
            // 
            // connectComButton
            // 
            this.connectComButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.connectComButton.Location = new System.Drawing.Point(314, 102);
            this.connectComButton.Name = "connectComButton";
            this.connectComButton.Size = new System.Drawing.Size(90, 23);
            this.connectComButton.TabIndex = 19;
            this.connectComButton.Text = "Connect";
            this.connectComButton.UseVisualStyleBackColor = true;
            this.connectComButton.Click += new System.EventHandler(this.connectComButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Port";
            // 
            // port
            // 
            this.port.FormattingEnabled = true;
            this.port.Items.AddRange(new object[] {
            "COM4",
            "COM3",
            "COM2",
            "COM1"});
            this.port.Location = new System.Drawing.Point(71, 17);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(132, 21);
            this.port.TabIndex = 17;
            this.port.Text = "COM1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Flow";
            // 
            // flowControl
            // 
            this.flowControl.FormattingEnabled = true;
            this.flowControl.Items.AddRange(new object[] {
            "Xon / Xoff",
            "None"});
            this.flowControl.Location = new System.Drawing.Point(272, 71);
            this.flowControl.Name = "flowControl";
            this.flowControl.Size = new System.Drawing.Size(132, 21);
            this.flowControl.TabIndex = 15;
            this.flowControl.Text = "None";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Stop bits";
            // 
            // stopBits
            // 
            this.stopBits.FormattingEnabled = true;
            this.stopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stopBits.Location = new System.Drawing.Point(272, 44);
            this.stopBits.Name = "stopBits";
            this.stopBits.Size = new System.Drawing.Size(132, 21);
            this.stopBits.TabIndex = 13;
            this.stopBits.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Parity";
            // 
            // parity
            // 
            this.parity.FormattingEnabled = true;
            this.parity.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None",
            "Mark",
            "Space"});
            this.parity.Location = new System.Drawing.Point(272, 17);
            this.parity.Name = "parity";
            this.parity.Size = new System.Drawing.Size(132, 21);
            this.parity.TabIndex = 11;
            this.parity.Text = "None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Data bits";
            // 
            // dataBits
            // 
            this.dataBits.FormattingEnabled = true;
            this.dataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.dataBits.Location = new System.Drawing.Point(71, 69);
            this.dataBits.Name = "dataBits";
            this.dataBits.Size = new System.Drawing.Size(132, 21);
            this.dataBits.TabIndex = 9;
            this.dataBits.Text = "8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Baud rate";
            // 
            // bitsPerSecond
            // 
            this.bitsPerSecond.FormattingEnabled = true;
            this.bitsPerSecond.Items.AddRange(new object[] {
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.bitsPerSecond.Location = new System.Drawing.Point(71, 44);
            this.bitsPerSecond.Name = "bitsPerSecond";
            this.bitsPerSecond.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bitsPerSecond.Size = new System.Drawing.Size(132, 21);
            this.bitsPerSecond.TabIndex = 7;
            this.bitsPerSecond.Tag = "";
            this.bitsPerSecond.Text = "9600";
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(182, 280);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 6;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            // 
            // chooseOutputFile
            // 
            this.chooseOutputFile.DefaultExt = "txt";
            this.chooseOutputFile.Filter = "XML|*.xml|Text Files|*.txt";
            this.chooseOutputFile.Title = "Choose output file...";
            this.chooseOutputFile.FileOk += new System.ComponentModel.CancelEventHandler(this.chooseOutputFile_FileOk);
            // 
            // serialPort1
            // 
            this.serialPort1.WriteBufferSize = 2;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(831, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "IEBus Studio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.MessageTableTabs.ResumeLayout(false);
            this.RawMessageTableTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RawMessageTable)).EndInit();
            this.ParsedMessageTableTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ParsedMessageTable)).EndInit();
            this.terminalTab.ResumeLayout(false);
            this.terminalTab.PerformLayout();
            this.eventDiscoveryTab.ResumeLayout(false);
            this.eventDiscoveryTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventDiscoveryTable)).EndInit();
            this.EventActionsMenuStrip.ResumeLayout(false);
            this.devicesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.devicesTable)).EndInit();
            this.eventsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}

        private void outputBrowse_Click(object sender, EventArgs e)
        {
            if (chooseOutputFile.ShowDialog() == DialogResult.OK)
            {
                this.outputPath.Text = chooseOutputFile.FileName;
                Stream saveStream = chooseOutputFile.OpenFile();
                StreamWriter saveWriter = new StreamWriter(saveStream);
                saveWriter.Write(serialBuffer);
                saveWriter.Close();
            }
        }


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SetText(this.serialPort1.ReadExisting());
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        //delegate void SetTextCallback(string text);

        string packetBuffer;
        string leftOverText = "";

		private void SetText(string text)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
            
            if (this.terminal.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                try
                {
                    this.Invoke(d, new object[] { text });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException());
                    //leftOverText += text;
                }
            }
            else
            {
                this.terminal.Text += text;
                text = leftOverText + text;

                //If there is not a complete packet yet, then come back later
                if ((text.Contains("^") && text.Contains("~")))
                {
                    int clearStart = text.LastIndexOf('^') + 1;
                    Console.WriteLine("clearStart: " + clearStart);
                    Console.WriteLine("text.Length: " + text.Length);
                    if (clearStart < text.Length)
                    {
                        leftOverText = text.Substring(clearStart);
                        text = text.Substring(0,clearStart);
                    }

                    string[] split1 = text.Split('^');
                    for (int i = 0; i < split1.Length; i++)
                    {
                        Console.WriteLine("i: " + i);
                        Console.WriteLine("split1.Length: " + split1.Length);
                        string[] split2 = split1[i].Split('~');
                        string wrkMessage = split2[1];
                        string[] rawArray = wrkMessage.Split(':');
                        string[] parsedArray = wrkMessage.Split(':');

                        //Add 0x format to some raw columns
                        rawArray[1] = "0x" + rawArray[1];
                        rawArray[2] = "0x" + rawArray[2];
                        rawArray[3] = "0x" + rawArray[3];

                        //Prepare parsed record
                        parsedArray[1] = parseMaster(parsedArray[1]);
                        parsedArray[2] = parseSlave(parsedArray[2]);
                        parsedArray[3] = parseControl(parsedArray[3]);
                        parsedArray[5] = parseData(parsedArray);
                        parsedArray = new string[] { parsedArray[0], parsedArray[1], parsedArray[2], parsedArray[3], parsedArray[4], parsedArray[5] };

                        //Populate a new row for each table
                        RawMessageTable.Rows.Add(rawArray);
                        ParsedMessageTable.Rows.Add(parsedArray);

                        if (eventDiscoverer.discoveryingEvents())
                        {
                            rawArray = wrkMessage.Split(':');

                            string broadcast = rawArray[0];
                            string master_address = rawArray[1]; // HexStringConverter.ToHyphenatedHexString(rawArray[1], 3);
                            string slave_address = rawArray[2]; // HexStringConverter.ToHyphenatedHexString(rawArray[2], 3);
                            string control = parsedArray[3];
                            ushort datasize = (ushort)Convert.ToInt16(parsedArray[4]);

                            string data = "";
                            for (int j = 0; j < 16; j++)
                            {
                                if (j != 0)
                                    data += "-";
                                if ((j + 5) < rawArray.Length)
                                {
                                    while (rawArray[j + 5].Length < 2) rawArray[j + 5] = "0" + rawArray[j + 5];
                                    data += rawArray[j + 5];
                                }
                                else
                                    data += "00";
                            }
                            

                            Event discoveredEvent = new Event("", "", broadcast, master_address, slave_address, control, datasize, data);
                            eventDiscoverer.addEvent(discoveredEvent);

                            displayDiscoveredDeviceList();
                        }
                    }
                }
                else
                {
                    //If you didn't process anything then carry all over for later
                    leftOverText = text;
                }
            }
		}

        private string parseMaster(string pmaster)
        {
            //TODO: Tie into the library that the user chooses from the menu
            return pmaster;
        }

        private string parseSlave(string pslave)
        {
            //TODO: Tie into the library that the user chooses from the menu
            return pslave;
        }

        private string parseControl(string pcontrol)
        {
            if (pcontrol == "0") { return "SSR";    }           //Slave status (SSR) read
            if (pcontrol == "1") { return "Undef";  }           //Undefined
            if (pcontrol == "2") { return "Undef";  }           //Undefined
            if (pcontrol == "3") { return "DRL";    }           //Data read and lock
            if (pcontrol == "4") { return "LARL8";  }           //Lock address read (Lower 8 bits)
            if (pcontrol == "5") { return "LARU4";  }           //Lock address read (Upper 4 bits)
            if (pcontrol == "6") { return "SSRU";   }           //Slave status (SSR) read and unlock
            if (pcontrol == "7") { return "DR"; }               //Data read
            if (pcontrol == "8") { return "Undef";  }           //Undefined
            if (pcontrol == "9") { return "Undef";  }           //Undefined
            if (pcontrol == "A") { return "CWL"; }              //Command write and lock
            if (pcontrol == "B") { return "DWL"; }              //Data write and lock
            if (pcontrol == "C") { return "Undef"; }            //Undefined
            if (pcontrol == "D") { return "Undef"; }            //Undefined
            if (pcontrol == "E") { return "CW"; }               //Command write
            if (pcontrol == "F") { return "DW"; }               //Data write
            return "Undef";                                     //Undefined
        }

        private string parseData(string[] pdata)
        {
            //Learn how to parse different packet types
            string result = "";

            for (int i = 5; i < pdata.Length; i++)
            {
                result += pdata[i];
            }

            return result;
        }

        private void connectComButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.serialPort1.Close();

                this.serialPort1.PortName = this.port.Text;
                this.serialPort1.BaudRate = Convert.ToInt16(this.bitsPerSecond.Text);
                this.serialPort1.DataBits = Convert.ToInt16(this.dataBits.Text);
               
                // Set the Parity
                switch(this.parity.SelectedText)
                {
                    case "None":
                        this.serialPort1.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "Even":
                        this.serialPort1.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "Odd":
                        this.serialPort1.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "Mark":
                        this.serialPort1.Parity = System.IO.Ports.Parity.Mark;
                        break;
                    case "Space":
                        this.serialPort1.Parity = System.IO.Ports.Parity.Space;
                        break;
                }

                // Set the StopBits
                switch(this.stopBits.SelectedText)
                {
                    case "1":
                        this.serialPort1.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "1.5":
                        this.serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "2":
                        this.serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                }

                // Set the Flow Control
                switch (this.flowControl.SelectedText)
                {
                    case "Xon / Xoff":
                        this.serialPort1.Handshake = System.IO.Ports.Handshake.XOnXOff;
                        break;
                    case "None":
                        this.serialPort1.Handshake = System.IO.Ports.Handshake.None;
                        break;
                }

                this.serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            Console.WriteLine(this.serialPort1.PortName + " port opened and successfully.");
        }

        private void disconnectComButton_Click(object sender, EventArgs e)
        {
            this.serialPort1.Close();
        }

        private void discoverEvent_Click(object sender, EventArgs e)
        {
            // Remove all existing rows (saveDeviceChanges() is invoked)
            eventDiscoveryTable.Rows.Clear();

            // Get the number of seconds to scan for
            long time = 0;
            if (secondsToDiscover.Text == null || secondsToDiscover.Text == "")
            {
                MessageBox.Show("You must first select a time interval", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
                time = Convert.ToInt64(secondsToDiscover.Text);

            // if the serial port isn't open
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("There is no serial port connection open, you must open a connection first", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            eventDiscoverer = new EventDiscovery();
            eventDiscoverer.TimeLeft = time;
            eventDiscoverer.Start(this, timeLeftLabel);
        }

        private void displayDiscoveredDeviceList()
        {
            // Store the devices temporarily
            ArrayList discoveredEventList = new ArrayList(eventDiscoverer.DiscoveredEvents);

            // Remove all existing rows (saveDeviceChanges() is invoked)
            eventDiscoveryTable.Rows.Clear();

            // Restore the devices to the device manager
            eventDiscoverer.DiscoveredEvents = discoveredEventList;

            // Display each devices info as a row
            for (int i = 0; i < eventDiscoverer.DiscoveredEvents.Count; i++)
            {
                DiscoveredEvent devent = (DiscoveredEvent)(eventDiscoverer.DiscoveredEvents[i]);
                Event ev = (Event)devent.TheEvent;
                eventDiscoveryTable.Rows.Add(devent.NumberOfInstances, ev.BroadcastString, ev.Master_Address_String, ev.Slave_Address_String, ev.ControlString, ev.DataSize, ev.DataString);
            }
        }

        private void displayDeviceList()
        {
            // Store the devices temporarily
            ArrayList deviceList = new ArrayList(deviceManager.Devices);

            // Remove all existing rows (saveDeviceChanges() is invoked)
            devicesTable.Rows.Clear();

            // Restore the devices to the device manager
            deviceManager.Devices = deviceList;

            // Display each devices info as a row
            for (int i = 0; i < deviceManager.Devices.Count; i++)
            {
                Device device = (Device)(deviceManager.Devices[i]);
                devicesTable.Rows.Add(device.AddressString, device.Name, device.Description);
            }
        }

        private void addDevice_Click(object sender, EventArgs e)
        {
            // Create a new device
            Device device = new Device();

            // Add it to the device list
            deviceManager.addDevice(device);

            // ReRender the device list
            displayDeviceList();
        }

   
        // Gets the values from the devicesTable and loads them into memory
        private void saveDeviceChanges(object e, object args)
        {
            // Remove all existing devices
            deviceManager.Devices.Clear();

            // Get devices from dataview and save to memory
            for (int i = 0; i < devicesTable.Rows.Count; i++)
            {
                string address     = (string)devicesTable.Rows[i].Cells[0].Value;
                string name        = (string)devicesTable.Rows[i].Cells[1].Value;
                string description = (string)devicesTable.Rows[i].Cells[2].Value;
                Device device      = new Device(address, name, description);

                deviceManager.Devices.Add(device);
            }
        }

        private void displayEventList()
        {
            // Store the devices temporarily
            ArrayList eventList = new ArrayList(eventManager.Events);

            // Remove all existing rows (saveDeviceChanges() is invoked)
            eventsTable.Rows.Clear();

            // Restore the devices to the device manager
            eventManager.Events = eventList;

            // Display each devices info as a row
            for (int i = 0; i < eventManager.Events.Count; i++)
            {
                Event ev = (Event)(eventManager.Events[i]);

                string b = "1";
                if(!ev.Broadcast) b = "0";

                eventsTable.Rows.Add(ev.Name, ev.Description, b, System.BitConverter.ToString(ev.Master_Address), System.BitConverter.ToString(ev.Slave_Address), Convert.ToString(ev.Control, 16), ev.DataSize, System.BitConverter.ToString(ev.Data));
            }
        }

        private void addEvent_Click(object sender, EventArgs e)
        {
            // Create the event with default values
            Event ev = new Event();

            // Add event to event list
            eventManager.addEvent(ev);

            //ReRender event list
            displayEventList();
        }

        // Gets the values from the eventsTable and loads them into memory
        private void saveEventChanges(object e, object args)
        {
            // Remove all existing events
            eventManager.Events.Clear();

            // Get events from dataview and save to memory
            for (int i = 0; i < eventsTable.Rows.Count; i++)
            {

                string name           = (string)eventsTable.Rows[i].Cells[0].Value;
                string description    = (string)eventsTable.Rows[i].Cells[1].Value;
                string broadcast      = (string)eventsTable.Rows[i].Cells[2].Value;
                string master_address = (string)eventsTable.Rows[i].Cells[3].Value;
                string slave_address  = (string)eventsTable.Rows[i].Cells[4].Value;
                string control        = (string)eventsTable.Rows[i].Cells[5].Value;
                ushort datasize       = (ushort)eventsTable.Rows[i].Cells[6].Value;
                string data           = (string)eventsTable.Rows[i].Cells[7].Value;
                  
                // Create the event object with all the data from the table
                Event ev = new Event(name, description, broadcast, master_address, slave_address, control, datasize, data);

                // Add the event to the event manager list
                eventManager.Events.Add(ev);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chooseOutputFile.ShowDialog();
        }

        private void chooseOutputFile_FileOk(object sender, CancelEventArgs e)
        {
            // Convert the device and event list to xml
            string xml = "<root>" + deviceManager.ouputAsXML() + eventManager.ouputAsXML() + "</root>" ;

            // Open the file to save to
            this.opened_filename = chooseOutputFile.FileName;
            FileStream file = File.Open(this.opened_filename, FileMode.OpenOrCreate);
            
            // Convert xml string bytes and write to file
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            file.Write(encoding.GetBytes(xml), 0, xml.Length);

            file.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If no file is currently opened
            if (this.opened_filename == "")
            {
                // Let the user select a file to save to
                chooseOutputFile.ShowDialog();
                return;
            }

            // Convert the device and event list to xml
            string xml = "<root>" + deviceManager.ouputAsXML() + eventManager.ouputAsXML() + "</root>";

            // Open the file to save to
            FileStream file = File.Open(this.opened_filename, FileMode.OpenOrCreate);

            // Convert xml string bytes and write to file
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            file.Write(encoding.GetBytes(xml), 0, xml.Length);

            file.Close();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
           // Call the menu item click of file->save
           saveToolStripMenuItem_Click(sender, e);
        }

        private void scanDevices_Click(object sender, EventArgs e)
        {

        }


        private void EventDiscoveryTable_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            DataGridViewRow EventDiscoveryRow = eventDiscoveryTable.Rows[e.RowIndex];

            //toolStripMenuItem1.Enabled = true;

            e.ContextMenuStrip = EventActionsMenuStrip;

            //contextMenuRowIndex = e.RowIndex;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Open the xml file
            this.opened_filename = openFileDialog1.FileName;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(this.opened_filename);

            // Remove the existing devices and events
            deviceManager.Devices.Clear();
            eventManager.Events.Clear();


            XmlNodeList devices = xDoc.GetElementsByTagName("device");
            XmlNodeList events = xDoc.GetElementsByTagName("event");

            foreach (XmlNode device in devices)
                deviceManager.addDevice(new Device(device.ChildNodes[2].FirstChild.Value, device.ChildNodes[0].FirstChild.Value, device.ChildNodes[1].FirstChild.Value));

            foreach (XmlNode ev in events)
                eventManager.addEvent(new Event(ev.ChildNodes[0].FirstChild.Value, ev.ChildNodes[1].FirstChild.Value, ev.ChildNodes[2].FirstChild.Value, ev.ChildNodes[3].FirstChild.Value, ev.ChildNodes[4].FirstChild.Value, ev.ChildNodes[5].FirstChild.Value, (ushort)Convert.ToInt16(ev.ChildNodes[6].FirstChild.Value), ev.ChildNodes[7].FirstChild.Value));


            displayDeviceList();
            displayEventList();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            // Call the menu item click of file->save
            openToolStripMenuItem_Click(sender, e);
        }

        
    }
}
