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
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton helpToolStripButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private System.IO.Ports.SerialPort serialPort1;
        private IContainer components;
        private ToolStripMenuItem changeMessageTableToolStripMenuItem;
        private TabControl MessageTableTabs;
        private TabPage eventDiscoveryTab;
        private Button discoverEvent;
        private TextBox secondsToDiscover;
        private Label label8;
        private TabPage devicesTab;
        private DataGridView devicesTable;
        private Button addDevice;
        private TabPage eventsTab;
        private DataGridView eventsTable;
        private Button addEvent;
        private ContextMenuStrip EventActionsMenuStrip;
        private ToolStripMenuItem addEventToolStripMenuItem;

        private EventManager eventManager = new EventManager();
        private DeviceManager deviceManager = new DeviceManager();
        private EventDiscovery eventDiscoverer = new EventDiscovery();
        private string openedFilename = string.Empty ;
        private Label timeLeftLabel;
        private TabControl BottomTabs;
        private TabPage tabPage1;
        private TextBox terminal;
        private GroupBox groupBox1;
        private Button disconnectComButton;
        private Button connectComButton;
        private Label label6;
        private ComboBox port;
        private Label label5;
        private ComboBox flowControl;
        private Label label4;
        private ComboBox stopBits;
        private Label label3;
        private ComboBox parity;
        private Label label2;
        private ComboBox dataBits;
        private Label label1;
        private ComboBox bitsPerSecond;
        private TabPage liveMessages;
        private Label label7;
        private DataGridView ParsedMessageTable;
        private CheckBox lookupDeviceNames;
        private CheckBox variableDataFilter;
        private Label label10;
        private ComboBox slaveFilter;
        private Label label9;
        private ComboBox masterFilter;
        private ToolStripStatusLabel ts_connectionStatus;
        private ComboBox andOr;
        private CheckBox autoAddDevices;
        private DataGridViewTextBoxColumn devices_deviceAddress;
        private DataGridViewTextBoxColumn devices_name;
        private DataGridViewTextBoxColumn devices_description;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Master;
        private DataGridViewTextBoxColumn Slave;
        private DataGridViewTextBoxColumn Control;
        private DataGridViewTextBoxColumn DataSize;
        private DataGridViewTextBoxColumn Data1;
        private DataGridViewTextBoxColumn id;
        private AdvancedDataGridView.TreeGridView patternGrid;
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
        private ToolStripMenuItem exportDLLToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private SaveFileDialog exportDLLSaveAsDialog;
        private DataGridViewTextBoxColumn Event_Name;
        private DataGridViewTextBoxColumn Event_Description;
        private DataGridViewTextBoxColumn Event_Broadcast;
        private DataGridViewTextBoxColumn Event_Master;
        private DataGridViewTextBoxColumn event_Slave;
        private DataGridViewTextBoxColumn Event_Control;
        private DataGridViewTextBoxColumn Event_DataSize;
        private DataGridViewTextBoxColumn Event_Data;
        private DataGridViewButtonColumn defineColumn;
        private AdvancedDataGridView.TreeGridColumn matchesColumn;
        private DataGridViewTextBoxColumn broadcastColumn;
        private DataGridViewTextBoxColumn masterColumn;
        private DataGridViewTextBoxColumn slaveColumn;
        private DataGridViewTextBoxColumn controlColumn;
        private DataGridViewTextBoxColumn sizeColumn;
        private DataGridViewTextBoxColumn dataColumn;
        private DataGridViewTextBoxColumn rawMasterColumn;
        private DataGridViewTextBoxColumn rawSlaveColumn;
        private DataGridViewTextBoxColumn rawControlColumn;
        public String serialBuffer = "This is a test.";

        public Form1()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts_connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportDLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeMessageTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MessageTableTabs = new System.Windows.Forms.TabControl();
            this.eventDiscoveryTab = new System.Windows.Forms.TabPage();
            this.andOr = new System.Windows.Forms.ComboBox();
            this.variableDataFilter = new System.Windows.Forms.CheckBox();
            this.slaveFilter = new System.Windows.Forms.ComboBox();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.masterFilter = new System.Windows.Forms.ComboBox();
            this.discoverEvent = new System.Windows.Forms.Button();
            this.patternGrid = new AdvancedDataGridView.TreeGridView();
            this.secondsToDiscover = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.devicesTab = new System.Windows.Forms.TabPage();
            this.autoAddDevices = new System.Windows.Forms.CheckBox();
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
            this.Event_Master = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_Slave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_DataSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.terminal = new System.Windows.Forms.TextBox();
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
            this.liveMessages = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.ParsedMessageTable = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Master = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lookupDeviceNames = new System.Windows.Forms.CheckBox();
            this.EventActionsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.exportDLLSaveAsDialog = new System.Windows.Forms.SaveFileDialog();
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
            this.defineColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.matchesColumn = new AdvancedDataGridView.TreeGridColumn();
            this.broadcastColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slaveColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawMasterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawSlaveColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawControlColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MessageTableTabs.SuspendLayout();
            this.eventDiscoveryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patternGrid)).BeginInit();
            this.devicesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesTable)).BeginInit();
            this.eventsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsTable)).BeginInit();
            this.BottomTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.liveMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsedMessageTable)).BeginInit();
            this.EventActionsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_connectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 524);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(813, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts_connectionStatus
            // 
            this.ts_connectionStatus.Enabled = false;
            this.ts_connectionStatus.Name = "ts_connectionStatus";
            this.ts_connectionStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(813, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
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
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exportDLLToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
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
            // exportDLLToolStripMenuItem
            // 
            this.exportDLLToolStripMenuItem.Name = "exportDLLToolStripMenuItem";
            this.exportDLLToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exportDLLToolStripMenuItem.Text = "&Export DLL";
            this.exportDLLToolStripMenuItem.Click += new System.EventHandler(this.exportDLLToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
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
            this.searchToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.searchToolStripMenuItem.Text = "&Contents";
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
            this.panel1.Size = new System.Drawing.Size(813, 475);
            this.panel1.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
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
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.BottomTabs);
            this.splitContainer1.Size = new System.Drawing.Size(813, 475);
            this.splitContainer1.SplitterDistance = 302;
            this.splitContainer1.TabIndex = 0;
            // 
            // MessageTableTabs
            // 
            this.MessageTableTabs.Controls.Add(this.eventDiscoveryTab);
            this.MessageTableTabs.Controls.Add(this.devicesTab);
            this.MessageTableTabs.Controls.Add(this.eventsTab);
            this.MessageTableTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageTableTabs.Location = new System.Drawing.Point(0, 0);
            this.MessageTableTabs.Margin = new System.Windows.Forms.Padding(0);
            this.MessageTableTabs.Multiline = true;
            this.MessageTableTabs.Name = "MessageTableTabs";
            this.MessageTableTabs.SelectedIndex = 0;
            this.MessageTableTabs.Size = new System.Drawing.Size(813, 302);
            this.MessageTableTabs.TabIndex = 5;
            // 
            // eventDiscoveryTab
            // 
            this.eventDiscoveryTab.BackColor = System.Drawing.SystemColors.Control;
            this.eventDiscoveryTab.Controls.Add(this.andOr);
            this.eventDiscoveryTab.Controls.Add(this.variableDataFilter);
            this.eventDiscoveryTab.Controls.Add(this.slaveFilter);
            this.eventDiscoveryTab.Controls.Add(this.timeLeftLabel);
            this.eventDiscoveryTab.Controls.Add(this.masterFilter);
            this.eventDiscoveryTab.Controls.Add(this.discoverEvent);
            this.eventDiscoveryTab.Controls.Add(this.patternGrid);
            this.eventDiscoveryTab.Controls.Add(this.secondsToDiscover);
            this.eventDiscoveryTab.Controls.Add(this.label10);
            this.eventDiscoveryTab.Controls.Add(this.label9);
            this.eventDiscoveryTab.Controls.Add(this.label8);
            this.eventDiscoveryTab.Location = new System.Drawing.Point(4, 22);
            this.eventDiscoveryTab.Name = "eventDiscoveryTab";
            this.eventDiscoveryTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventDiscoveryTab.Size = new System.Drawing.Size(805, 276);
            this.eventDiscoveryTab.TabIndex = 3;
            this.eventDiscoveryTab.Text = "Event Discovery";
            // 
            // andOr
            // 
            this.andOr.FormattingEnabled = true;
            this.andOr.Items.AddRange(new object[] {
            "And",
            "Or"});
            this.andOr.Location = new System.Drawing.Point(211, 22);
            this.andOr.Name = "andOr";
            this.andOr.Size = new System.Drawing.Size(59, 21);
            this.andOr.TabIndex = 7;
            this.andOr.Text = "And";
            // 
            // variableDataFilter
            // 
            this.variableDataFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.variableDataFilter.AutoSize = true;
            this.variableDataFilter.Location = new System.Drawing.Point(508, 24);
            this.variableDataFilter.Name = "variableDataFilter";
            this.variableDataFilter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.variableDataFilter.Size = new System.Drawing.Size(171, 17);
            this.variableDataFilter.TabIndex = 6;
            this.variableDataFilter.Text = "Pattern match for variable data";
            this.variableDataFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.variableDataFilter.UseVisualStyleBackColor = true;
            // 
            // slaveFilter
            // 
            this.slaveFilter.FormattingEnabled = true;
            this.slaveFilter.Items.AddRange(new object[] {
            "Build from device class"});
            this.slaveFilter.Location = new System.Drawing.Point(276, 22);
            this.slaveFilter.Name = "slaveFilter";
            this.slaveFilter.Size = new System.Drawing.Size(132, 21);
            this.slaveFilter.TabIndex = 4;
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.Location = new System.Drawing.Point(430, 26);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(0, 13);
            this.timeLeftLabel.TabIndex = 6;
            // 
            // masterFilter
            // 
            this.masterFilter.FormattingEnabled = true;
            this.masterFilter.Items.AddRange(new object[] {
            "Build from device class"});
            this.masterFilter.Location = new System.Drawing.Point(75, 22);
            this.masterFilter.Name = "masterFilter";
            this.masterFilter.Size = new System.Drawing.Size(131, 21);
            this.masterFilter.TabIndex = 2;
            // 
            // discoverEvent
            // 
            this.discoverEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discoverEvent.Location = new System.Drawing.Point(696, 21);
            this.discoverEvent.Name = "discoverEvent";
            this.discoverEvent.Size = new System.Drawing.Size(92, 20);
            this.discoverEvent.TabIndex = 2;
            this.discoverEvent.Text = "Discover Event";
            this.discoverEvent.UseVisualStyleBackColor = true;
            this.discoverEvent.Click += new System.EventHandler(this.discoverEvent_Click);
            // 
            // patternGrid
            // 
            this.patternGrid.AllowUserToAddRows = false;
            this.patternGrid.AllowUserToDeleteRows = false;
            this.patternGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.patternGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.patternGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.patternGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.patternGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.patternGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.defineColumn,
            this.matchesColumn,
            this.broadcastColumn,
            this.masterColumn,
            this.slaveColumn,
            this.controlColumn,
            this.sizeColumn,
            this.dataColumn,
            this.rawMasterColumn,
            this.rawSlaveColumn,
            this.rawControlColumn});
            this.patternGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.patternGrid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.patternGrid.ImageList = null;
            this.patternGrid.Location = new System.Drawing.Point(3, 55);
            this.patternGrid.Name = "patternGrid";
            this.patternGrid.ReadOnly = true;
            this.patternGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patternGrid.Size = new System.Drawing.Size(799, 218);
            this.patternGrid.TabIndex = 8;
            this.patternGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellClick);
            // 
            // secondsToDiscover
            // 
            this.secondsToDiscover.Location = new System.Drawing.Point(8, 23);
            this.secondsToDiscover.Name = "secondsToDiscover";
            this.secondsToDiscover.Size = new System.Drawing.Size(49, 20);
            this.secondsToDiscover.TabIndex = 1;
            this.secondsToDiscover.Text = "5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Slave filter:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Master filter:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Seconds:";
            // 
            // devicesTab
            // 
            this.devicesTab.BackColor = System.Drawing.SystemColors.Control;
            this.devicesTab.Controls.Add(this.autoAddDevices);
            this.devicesTab.Controls.Add(this.addDevice);
            this.devicesTab.Controls.Add(this.devicesTable);
            this.devicesTab.Location = new System.Drawing.Point(4, 22);
            this.devicesTab.Name = "devicesTab";
            this.devicesTab.Padding = new System.Windows.Forms.Padding(3);
            this.devicesTab.Size = new System.Drawing.Size(805, 276);
            this.devicesTab.TabIndex = 4;
            this.devicesTab.Text = "Device Discovery";
            // 
            // autoAddDevices
            // 
            this.autoAddDevices.AutoSize = true;
            this.autoAddDevices.Checked = true;
            this.autoAddDevices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoAddDevices.Location = new System.Drawing.Point(119, 13);
            this.autoAddDevices.Name = "autoAddDevices";
            this.autoAddDevices.Size = new System.Drawing.Size(144, 17);
            this.autoAddDevices.TabIndex = 9;
            this.autoAddDevices.Text = "Auto add unique devices";
            this.autoAddDevices.UseVisualStyleBackColor = true;
            // 
            // addDevice
            // 
            this.addDevice.Location = new System.Drawing.Point(8, 10);
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
            this.devicesTable.Size = new System.Drawing.Size(799, 234);
            this.devicesTable.TabIndex = 6;
            this.devicesTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.saveDeviceChanges);
            this.devicesTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.saveDeviceChanges);
            // 
            // devices_deviceAddress
            // 
            this.devices_deviceAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.devices_deviceAddress.HeaderText = "Address";
            this.devices_deviceAddress.MaxInputLength = 1024;
            this.devices_deviceAddress.MinimumWidth = 60;
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
            this.eventsTab.BackColor = System.Drawing.SystemColors.Control;
            this.eventsTab.Controls.Add(this.addEvent);
            this.eventsTab.Controls.Add(this.eventsTable);
            this.eventsTab.Location = new System.Drawing.Point(4, 22);
            this.eventsTab.Name = "eventsTab";
            this.eventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventsTab.Size = new System.Drawing.Size(805, 276);
            this.eventsTab.TabIndex = 5;
            this.eventsTab.Text = "Defined Events";
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
            this.eventsTable.AllowUserToDeleteRows = false;
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
            this.Event_Master,
            this.event_Slave,
            this.Event_Control,
            this.Event_DataSize,
            this.Event_Data});
            this.eventsTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.eventsTable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.eventsTable.Location = new System.Drawing.Point(3, 39);
            this.eventsTable.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.eventsTable.Name = "eventsTable";
            this.eventsTable.ReadOnly = true;
            this.eventsTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.eventsTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.eventsTable.RowTemplate.Height = 18;
            this.eventsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventsTable.Size = new System.Drawing.Size(799, 234);
            this.eventsTable.TabIndex = 7;
            this.eventsTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.saveEventChanges);
            this.eventsTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.saveEventChanges);
            // 
            // Event_Name
            // 
            this.Event_Name.HeaderText = "Name";
            this.Event_Name.Name = "Event_Name";
            this.Event_Name.ReadOnly = true;
            // 
            // Event_Description
            // 
            this.Event_Description.HeaderText = "Description";
            this.Event_Description.Name = "Event_Description";
            this.Event_Description.ReadOnly = true;
            // 
            // Event_Broadcast
            // 
            this.Event_Broadcast.HeaderText = "B";
            this.Event_Broadcast.Name = "Event_Broadcast";
            this.Event_Broadcast.ReadOnly = true;
            this.Event_Broadcast.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Event_Broadcast.ToolTipText = "Broadcast";
            this.Event_Broadcast.Width = 20;
            // 
            // Event_Master
            // 
            this.Event_Master.HeaderText = "Master";
            this.Event_Master.Name = "Event_Master";
            this.Event_Master.ReadOnly = true;
            this.Event_Master.Width = 115;
            // 
            // event_Slave
            // 
            this.event_Slave.HeaderText = "Slave";
            this.event_Slave.Name = "event_Slave";
            this.event_Slave.ReadOnly = true;
            this.event_Slave.Width = 115;
            // 
            // Event_Control
            // 
            this.Event_Control.HeaderText = "Control";
            this.Event_Control.Name = "Event_Control";
            this.Event_Control.ReadOnly = true;
            this.Event_Control.Width = 75;
            // 
            // Event_DataSize
            // 
            this.Event_DataSize.HeaderText = "Size";
            this.Event_DataSize.Name = "Event_DataSize";
            this.Event_DataSize.ReadOnly = true;
            this.Event_DataSize.Width = 35;
            // 
            // Event_Data
            // 
            this.Event_Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Event_Data.HeaderText = "Data";
            this.Event_Data.Name = "Event_Data";
            this.Event_Data.ReadOnly = true;
            // 
            // BottomTabs
            // 
            this.BottomTabs.Controls.Add(this.tabPage1);
            this.BottomTabs.Controls.Add(this.liveMessages);
            this.BottomTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomTabs.Location = new System.Drawing.Point(0, 0);
            this.BottomTabs.Margin = new System.Windows.Forms.Padding(0);
            this.BottomTabs.Name = "BottomTabs";
            this.BottomTabs.SelectedIndex = 0;
            this.BottomTabs.ShowToolTips = true;
            this.BottomTabs.Size = new System.Drawing.Size(813, 169);
            this.BottomTabs.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.terminal);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(805, 143);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serial Port";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // terminal
            // 
            this.terminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.terminal.Location = new System.Drawing.Point(414, 3);
            this.terminal.Multiline = true;
            this.terminal.Name = "terminal";
            this.terminal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.terminal.Size = new System.Drawing.Size(388, 135);
            this.terminal.TabIndex = 0;
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
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 137);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Settings";
            // 
            // disconnectComButton
            // 
            this.disconnectComButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.disconnectComButton.Location = new System.Drawing.Point(228, 108);
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
            this.connectComButton.Location = new System.Drawing.Point(309, 108);
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
            this.label6.Location = new System.Drawing.Point(8, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Port";
            // 
            // port
            // 
            this.port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.port.FormattingEnabled = true;
            this.port.Items.AddRange(new object[] {
            "COM4",
            "COM3",
            "COM2",
            "COM1"});
            this.port.Location = new System.Drawing.Point(67, 19);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(132, 21);
            this.port.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 77);
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
            this.flowControl.Location = new System.Drawing.Point(266, 74);
            this.flowControl.Name = "flowControl";
            this.flowControl.Size = new System.Drawing.Size(132, 21);
            this.flowControl.TabIndex = 15;
            this.flowControl.Text = "None";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 22);
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
            this.stopBits.Location = new System.Drawing.Point(266, 19);
            this.stopBits.Name = "stopBits";
            this.stopBits.Size = new System.Drawing.Size(132, 21);
            this.stopBits.TabIndex = 13;
            this.stopBits.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 49);
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
            this.parity.Location = new System.Drawing.Point(67, 46);
            this.parity.Name = "parity";
            this.parity.Size = new System.Drawing.Size(132, 21);
            this.parity.TabIndex = 11;
            this.parity.Text = "None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 49);
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
            this.dataBits.Location = new System.Drawing.Point(266, 46);
            this.dataBits.Name = "dataBits";
            this.dataBits.Size = new System.Drawing.Size(132, 21);
            this.dataBits.TabIndex = 9;
            this.dataBits.Text = "8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 77);
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
            this.bitsPerSecond.Location = new System.Drawing.Point(67, 74);
            this.bitsPerSecond.Name = "bitsPerSecond";
            this.bitsPerSecond.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bitsPerSecond.Size = new System.Drawing.Size(132, 21);
            this.bitsPerSecond.TabIndex = 7;
            this.bitsPerSecond.Tag = "";
            this.bitsPerSecond.Text = "9600";
            // 
            // liveMessages
            // 
            this.liveMessages.Controls.Add(this.label7);
            this.liveMessages.Controls.Add(this.ParsedMessageTable);
            this.liveMessages.Controls.Add(this.lookupDeviceNames);
            this.liveMessages.Location = new System.Drawing.Point(4, 22);
            this.liveMessages.Name = "liveMessages";
            this.liveMessages.Padding = new System.Windows.Forms.Padding(3);
            this.liveMessages.Size = new System.Drawing.Size(805, 143);
            this.liveMessages.TabIndex = 1;
            this.liveMessages.Text = "Live Messages";
            this.liveMessages.ToolTipText = "Raw messages currently being transmitted over the COM port connected to parsed in" +
                "to a data grid view.";
            this.liveMessages.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(325, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "View live messages as the are coming in over the serial connection.";
            // 
            // ParsedMessageTable
            // 
            this.ParsedMessageTable.AllowUserToAddRows = false;
            this.ParsedMessageTable.AllowUserToDeleteRows = false;
            this.ParsedMessageTable.AllowUserToResizeColumns = false;
            this.ParsedMessageTable.AllowUserToResizeRows = false;
            this.ParsedMessageTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ParsedMessageTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ParsedMessageTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ParsedMessageTable.CausesValidation = false;
            this.ParsedMessageTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.ParsedMessageTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParsedMessageTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Master,
            this.Slave,
            this.Control,
            this.DataSize,
            this.Data1,
            this.id});
            this.ParsedMessageTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.ParsedMessageTable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.ParsedMessageTable.Location = new System.Drawing.Point(3, 26);
            this.ParsedMessageTable.Margin = new System.Windows.Forms.Padding(0);
            this.ParsedMessageTable.MultiSelect = false;
            this.ParsedMessageTable.Name = "ParsedMessageTable";
            this.ParsedMessageTable.ReadOnly = true;
            this.ParsedMessageTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ParsedMessageTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.ParsedMessageTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.ParsedMessageTable.RowTemplate.Height = 18;
            this.ParsedMessageTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParsedMessageTable.Size = new System.Drawing.Size(799, 114);
            this.ParsedMessageTable.TabIndex = 4;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "B";
            this.Column2.MaxInputLength = 1;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.ToolTipText = "Broadcast Bit";
            this.Column2.Width = 20;
            // 
            // Master
            // 
            this.Master.HeaderText = "Master";
            this.Master.MaxInputLength = 1024;
            this.Master.Name = "Master";
            this.Master.ReadOnly = true;
            this.Master.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Slave
            // 
            this.Slave.HeaderText = "Slave";
            this.Slave.MaxInputLength = 1024;
            this.Slave.Name = "Slave";
            this.Slave.ReadOnly = true;
            this.Slave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Control
            // 
            this.Control.HeaderText = "Control";
            this.Control.MaxInputLength = 50;
            this.Control.Name = "Control";
            this.Control.ReadOnly = true;
            this.Control.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Control.Width = 75;
            // 
            // DataSize
            // 
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
            // id
            // 
            this.id.FillWeight = 2F;
            this.id.HeaderText = "";
            this.id.MinimumWidth = 2;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 2;
            // 
            // lookupDeviceNames
            // 
            this.lookupDeviceNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupDeviceNames.AutoSize = true;
            this.lookupDeviceNames.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lookupDeviceNames.Checked = true;
            this.lookupDeviceNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lookupDeviceNames.Location = new System.Drawing.Point(670, 6);
            this.lookupDeviceNames.Name = "lookupDeviceNames";
            this.lookupDeviceNames.Size = new System.Drawing.Size(135, 17);
            this.lookupDeviceNames.TabIndex = 7;
            this.lookupDeviceNames.Text = "Lookup Device Names";
            this.lookupDeviceNames.UseVisualStyleBackColor = true;
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
            this.addEventToolStripMenuItem.Click += new System.EventHandler(this.addEventToolStripMenuItem_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.WriteBufferSize = 2;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // exportDLLSaveAsDialog
            // 
            this.exportDLLSaveAsDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.exportDLLSaveAsDialog_FileOk);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Address";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 1024;
            this.dataGridViewTextBoxColumn1.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 450;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Description";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "B";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.ToolTipText = "Broadcast";
            this.dataGridViewTextBoxColumn6.Width = 20;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Master";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 115;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Slave";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 115;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Control";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 50;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "DataSize";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 75;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.HeaderText = "Data";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "B";
            this.dataGridViewTextBoxColumn12.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn12.ToolTipText = "Broadcast Bit";
            this.dataGridViewTextBoxColumn12.Width = 20;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Master";
            this.dataGridViewTextBoxColumn13.MaxInputLength = 1024;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Slave";
            this.dataGridViewTextBoxColumn14.MaxInputLength = 1024;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Control";
            this.dataGridViewTextBoxColumn15.MaxInputLength = 50;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn15.Width = 75;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Size";
            this.dataGridViewTextBoxColumn16.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn16.Width = 35;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.HeaderText = "Data";
            this.dataGridViewTextBoxColumn17.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.FillWeight = 2F;
            this.dataGridViewTextBoxColumn18.HeaderText = "";
            this.dataGridViewTextBoxColumn18.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Visible = false;
            this.dataGridViewTextBoxColumn18.Width = 2;
            // 
            // defineColumn
            // 
            this.defineColumn.HeaderText = "Define";
            this.defineColumn.Name = "defineColumn";
            this.defineColumn.ReadOnly = true;
            this.defineColumn.Width = 44;
            // 
            // matchesColumn
            // 
            this.matchesColumn.DefaultNodeImage = null;
            this.matchesColumn.HeaderText = "Matches";
            this.matchesColumn.MinimumWidth = 75;
            this.matchesColumn.Name = "matchesColumn";
            this.matchesColumn.ReadOnly = true;
            this.matchesColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.matchesColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.matchesColumn.Width = 75;
            // 
            // broadcastColumn
            // 
            this.broadcastColumn.HeaderText = "Broadcast";
            this.broadcastColumn.Name = "broadcastColumn";
            this.broadcastColumn.ReadOnly = true;
            this.broadcastColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.broadcastColumn.Width = 61;
            // 
            // masterColumn
            // 
            this.masterColumn.HeaderText = "Master";
            this.masterColumn.Name = "masterColumn";
            this.masterColumn.ReadOnly = true;
            this.masterColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.masterColumn.Width = 45;
            // 
            // slaveColumn
            // 
            this.slaveColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.slaveColumn.HeaderText = "Slave";
            this.slaveColumn.Name = "slaveColumn";
            this.slaveColumn.ReadOnly = true;
            this.slaveColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.slaveColumn.Width = 45;
            // 
            // controlColumn
            // 
            this.controlColumn.HeaderText = "Control";
            this.controlColumn.Name = "controlColumn";
            this.controlColumn.ReadOnly = true;
            this.controlColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.controlColumn.Width = 46;
            // 
            // sizeColumn
            // 
            this.sizeColumn.HeaderText = "Size";
            this.sizeColumn.Name = "sizeColumn";
            this.sizeColumn.ReadOnly = true;
            this.sizeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sizeColumn.Width = 33;
            // 
            // dataColumn
            // 
            this.dataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataColumn.HeaderText = "Data";
            this.dataColumn.Name = "dataColumn";
            this.dataColumn.ReadOnly = true;
            this.dataColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // rawMasterColumn
            // 
            this.rawMasterColumn.HeaderText = "RawMaster";
            this.rawMasterColumn.Name = "rawMasterColumn";
            this.rawMasterColumn.ReadOnly = true;
            this.rawMasterColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rawMasterColumn.Visible = false;
            this.rawMasterColumn.Width = 67;
            // 
            // rawSlaveColumn
            // 
            this.rawSlaveColumn.HeaderText = "RawSlave";
            this.rawSlaveColumn.Name = "rawSlaveColumn";
            this.rawSlaveColumn.ReadOnly = true;
            this.rawSlaveColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rawSlaveColumn.Visible = false;
            this.rawSlaveColumn.Width = 62;
            // 
            // rawControlColumn
            // 
            this.rawControlColumn.HeaderText = "RawControl";
            this.rawControlColumn.Name = "rawControlColumn";
            this.rawControlColumn.ReadOnly = true;
            this.rawControlColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rawControlColumn.Visible = false;
            this.rawControlColumn.Width = 68;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 546);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = "IEBus Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.MessageTableTabs.ResumeLayout(false);
            this.eventDiscoveryTab.ResumeLayout(false);
            this.eventDiscoveryTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patternGrid)).EndInit();
            this.devicesTab.ResumeLayout(false);
            this.devicesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesTable)).EndInit();
            this.eventsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsTable)).EndInit();
            this.BottomTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.liveMessages.ResumeLayout(false);
            this.liveMessages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsedMessageTable)).EndInit();
            this.EventActionsMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem addEventItem = (ToolStripDropDownItem)sender;

            AddEventPopup eventPopup = new AddEventPopup(eventManager, null, null);
            eventPopup.Show();
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

            /*
            dllCreator.Creator DC = new dllCreator.Creator("Acura", "TSX", 2004);
            DC.DeviceManager.AddDevice(0x131, "Touch Screen", "The touch screen.");
            DC.DeviceManager.AddDevice(0x183, "Navigation Unit", "The big black box in the back.");
            DC.AddEvent("TouchScreenDown", "Triggers when the touch screen is well... touched!", 1, 0x131, 0x183, ControlByte.DataWrite, "37:31:D:0:1:3:%X:%Y:0:0:0:0:0:0:%Unknown1");
            DC.AddEvent("TouchScreenUp", "Triggers when the touch screen is well... touched!", 1, 0x131, 0x183,  ControlByte.DataWrite, "37:31:D:0:1:3:0:0:0:0:0:0:0:0:82");
            DC.AddEvent("SomthingElse", "Triggers when the touch screen is well... touched!", 1, 0x131, 0x183, ControlByte.DataWrite, "37:31:%Unk4:0:1:3:%X:%Y:0:%Unk3:0:%Unk2:0:0:%Unknown1");
            DC.AddEvent("SmallerPattern", "Triggers when the touch screen is well... touched!",1, 0x131, 0x183, ControlByte.DataWrite, "37:31:D:0:1:3:%X:%Y:0:0:0");
            DC.AddEvent("TouchScreenPress", "Triggers when the touch screen is well... touched!", 1, 0x131, 0x183, ControlByte.DataWrite, "37:31:D:0:1:3:%X:%Y:0:0:%Unknown1");
            DC.CompileDLL(Application.StartupPath + "\\" + DC.PrefferedFilename);
            */
            this.port.Items.Clear();
            this.port.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            this.port.SelectedIndex = 0;
        }


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            DataReceived(this.serialPort1.ReadExisting());
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void DGRefreshCallback();

        private void refreshDataGrids()
        {
            if (this.ParsedMessageTable.InvokeRequired)
            {
                DGRefreshCallback messageTableDelegate = new DGRefreshCallback(refreshDataGrids);
                try
                {
                    this.Invoke(messageTableDelegate);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException());
                }
            }
            else
            {
                //this.ParsedMessageTable.Refresh();
                this.ParsedMessageTable.Invalidate();
            }
        }

        string leftOverText = "";
        private void DataReceived(string text)
        {
            if (this.terminal.InvokeRequired)
            {
                SetTextCallback terminalDelegate = new SetTextCallback(DataReceived);
                try
                {
                    this.Invoke(terminalDelegate, new object[] { text });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                this.terminal.Text += text;
                text = leftOverText + text;
                while (text.IndexOf('^') > text.IndexOf('~'))
                {
                    if (text.Contains("~"))
                    {
                        int wrkStart = text.IndexOf('~') + 1;
                        int wrkEnd = text.IndexOf('^');
                        string wrkMessage = text.Substring(wrkStart, wrkEnd - wrkStart);
                        if (wrkEnd < text.Length)
                            text = text.Substring(wrkEnd + 1);

                        if (!wrkMessage.Contains("*"))
                        {
                            string[] currentMessageArray = wrkMessage.Split(':');

                            //AutoAdd devices
                            if (this.autoAddDevices.Checked)
                            {
                                // AutoAdd Master device
                                if (!isDeviceDefined(Convert.ToInt32(currentMessageArray[1], 16)))
                                {
                                    Device d = new Device(Convert.ToInt32(currentMessageArray[1], 16), "Undefined", "Describe me.");
                                    this.deviceManager.AddDevice(d);

                                    // ReRender the device list
                                    displayDeviceList();
                                }

                                // AutoAdd Slave device
                                if (!isDeviceDefined(Convert.ToInt32(currentMessageArray[2], 16)))
                                {
                                    Device d = new Device(Convert.ToInt32(currentMessageArray[2], 16), "Undefined", "Describe me.");
                                    this.deviceManager.AddDevice(d);

                                    // ReRender the device list
                                    displayDeviceList();
                                }
                            }

                            currentMessageArray[5] = parseData(currentMessageArray);

                            //Prepare message record
                            if (this.lookupDeviceNames.Checked)
                            {
                                //currentMessageArray[3] = parseControl(currentMessageArray[3]);
                                ParsedMessageTable.Rows.Add(currentMessageArray[0], parseDeviceAddress(currentMessageArray[1]), parseDeviceAddress(currentMessageArray[2]), currentMessageArray[3], currentMessageArray[4], currentMessageArray[5], this.ParsedMessageTable.RowCount);

                            }
                            else
                            {
                                //currentMessageArray[3] = "0x" + currentMessageArray[3];
                                ParsedMessageTable.Rows.Add(currentMessageArray[0], "0x" + currentMessageArray[1], "0x" + currentMessageArray[2], currentMessageArray[3], currentMessageArray[4], currentMessageArray[5], this.ParsedMessageTable.RowCount);
                            }

                            if (eventDiscoverer.discoveryingEvents())
                            {
                                int broadcast = Convert.ToInt32(currentMessageArray[0]);
                                int master_address = Convert.ToInt32(currentMessageArray[1], 16);
                                int slave_address = Convert.ToInt32(currentMessageArray[2], 16);
                                ControlByte control = (ControlByte)Convert.ToInt32(currentMessageArray[3], 16);
                                string data = currentMessageArray[5];
                                Event discoveredEvent = new Event("Undefined", "Undefined", broadcast, master_address, slave_address, control, data);
                                eventDiscoverer.addEvent(discoveredEvent);
                                patternMatch();
                            }
                        }
                    }
                }
                leftOverText = text;

                this.ParsedMessageTable.Sort(this.ParsedMessageTable.Columns[6], ListSortDirection.Descending);
                this.terminal.SelectionStart = terminal.Text.Length;
                this.terminal.ScrollToCaret();
                refreshDataGrids();
            }
        }

        public void patternMatch()
        {
            System.Collections.Generic.SortedList<string, ArrayList> Patterns = new SortedList<string, ArrayList>();
            for (int i = 0; i < eventDiscoverer.DiscoveredEvents.Count; i++)
            {
                Event origEvent = eventDiscoverer.DiscoveredEvents[i];
                for (int k = 0; k < eventDiscoverer.DiscoveredEvents.Count; k++)
                {
                    string pattern = string.Empty;
                    Event compareEvent = eventDiscoverer.DiscoveredEvents[k];

                    if ((origEvent.Master == compareEvent.Master) &&
                     (origEvent.Slave == compareEvent.Slave) &&
                     (origEvent.Control == compareEvent.Control) &&
                     (origEvent.Broadcast == compareEvent.Broadcast) &&
                     (origEvent.Size == compareEvent.Size))
                    {
                        for (int v = 0; v < origEvent.Variables.Count; v++)
                        {
                            if (origEvent.Variables[v] == compareEvent.Variables[v])
                                pattern += origEvent.Variables[v] + ":";
                            else
                                pattern += "*:";
                        }
                    }
                    pattern = pattern.TrimEnd(':');
                    if (!pattern.Equals(string.Empty))
                    {
                        if (Patterns.ContainsKey(pattern))
                        {
                            if (!Patterns[pattern].Contains(k))
                                Patterns[pattern].Add(k);

                        }
                        else
                        {
                            Patterns.Add(pattern, new ArrayList());
                            Patterns[pattern].Add(k);
                        }
                    }

                }
            }
            patternGrid.SuspendLayout();
            patternGrid.Nodes.Clear();
            for (int x = 0; x < Patterns.Count; x++)
            {
                string cPattern = Patterns.Keys[x];
                string cMatches = Patterns.Values[x].Count.ToString();

                Event tempEvent = eventDiscoverer.DiscoveredEvents[(int)(Patterns.Values[x][0])];

                string master = parseDeviceAddress(Convert.ToString(tempEvent.Master, 16));
                string slave = parseDeviceAddress(Convert.ToString(tempEvent.Slave, 16));

                AdvancedDataGridView.TreeGridNode node = patternGrid.Nodes.Add("Define", cMatches, tempEvent.Broadcast.ToString(), master, slave, tempEvent.Control.ToString(), tempEvent.Size.ToString(), cPattern, tempEvent.Master, tempEvent.Slave, tempEvent.Control);

                for (int i = 0; i < Patterns.Values[x].Count; i++)
                {
                    Event origEvent = eventDiscoverer.DiscoveredEvents[(int)(Patterns.Values[x][i])];

                    string DataString = String.Empty;
                    for (int v = 0; v < origEvent.Variables.Count; v++)
                    {
                        if (v == origEvent.Variables.Count - 1)
                            DataString += origEvent.Variables[v].ToString();
                        else
                            DataString += origEvent.Variables[v].ToString() + ":";
                    }
                    node.Nodes.Add("Define", "1", origEvent.Broadcast.ToString(), origEvent.Master.ToString(), origEvent.Slave.ToString(), origEvent.Control.ToString(), origEvent.Size.ToString(), DataString);

                }
            }
            //patternGrid.ort(matchesColumn, ListSortDirection.Descending);
            patternGrid.Sort(new IEBus_Studio.RowComparer(SortOrder.Descending));
            patternGrid.ResumeLayout();
        }
        public string BuildWildcard(string[] rData, int[] Indices)
        {
            string DataString = String.Empty;
            for (int x = 0; x < Indices.Length; x++)
                rData[Indices[x]] = "*";

            for (int x = 0; x < rData.Length; x++)
            {
                if (x == rData.Length - 1)
                    DataString += rData[x].ToString();
                else
                    DataString += rData[x].ToString() + ":";
            }
            return DataString;
        }
        private bool isDeviceDefined(int device)
        {
            foreach (Device d in this.deviceManager.Devices)
                if (d.Address == device) { return true; }
            return false;
        }

        private string parseDeviceAddress(string pmaster)
        {
            int master_address = Convert.ToInt32(pmaster, 16);

            foreach (Device d in this.deviceManager.Devices)
            {
                if (d.Address == master_address)
                {
                    if (d.Name == "Undefined")
                    {
                        return "0x" + pmaster;
                    }
                    return d.Name;
                }
            }

            return "0x" + pmaster;
        }

        private string parseControl(string pcontrol)
        {
            if (pcontrol == "0") { return "Slave status read"; }                  //Slave status (SSR) read
            if (pcontrol == "1") { return "Undefined"; }                          //Undefined
            if (pcontrol == "2") { return "Undefined"; }                          //Undefined
            if (pcontrol == "3") { return "Data read and lock"; }                 //Data read and lock
            if (pcontrol == "4") { return "Lock address read (Lower 8 bits)"; }   //Lock address read (Lower 8 bits)
            if (pcontrol == "5") { return "Lock address read (Upper 4 bits)"; }   //Lock address read (Upper 4 bits)
            if (pcontrol == "6") { return "Slave status (SSR) read and unlock"; } //Slave status (SSR) read and unlock
            if (pcontrol == "7") { return "Data read"; }                          //Data read
            if (pcontrol == "8") { return "Undefined"; }                          //Undefined
            if (pcontrol == "9") { return "Undefined"; }                          //Undefined
            if (pcontrol == "A") { return "Command write and lock"; }             //Command write and lock
            if (pcontrol == "B") { return "Data write and lock"; }                //Data write and lock
            if (pcontrol == "C") { return "Undefined"; }                          //Undefined
            if (pcontrol == "D") { return "Undefined"; }                          //Undefined
            if (pcontrol == "E") { return "Command write"; }                      //Command write
            if (pcontrol == "F") { return "Data write"; }                         //Data write
            return "Undefined";                                                   //Undefined
        }

        private string parseControlAbreviated(string pcontrol)
        {
            if (pcontrol == "0") { return "SSR"; }           //Slave status (SSR) read
            if (pcontrol == "1") { return "Undef"; }           //Undefined
            if (pcontrol == "2") { return "Undef"; }           //Undefined
            if (pcontrol == "3") { return "DRL"; }           //Data read and lock
            if (pcontrol == "4") { return "LARL8"; }           //Lock address read (Lower 8 bits)
            if (pcontrol == "5") { return "LARU4"; }           //Lock address read (Upper 4 bits)
            if (pcontrol == "6") { return "SSRU"; }           //Slave status (SSR) read and unlock
            if (pcontrol == "7") { return "DR"; }               //Data read
            if (pcontrol == "8") { return "Undef"; }           //Undefined
            if (pcontrol == "9") { return "Undef"; }           //Undefined
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
                result += pdata[i] + ":";
            }

            return result.TrimEnd(':');
        }

        private void connectComButton_Click(object sender, EventArgs e)
        {
            if (this.serialPort1.IsOpen)
            {
                MessageBox.Show("COM port is already open!");
                return;
            }

            try
            {
                this.serialPort1.Close();

                this.serialPort1.PortName = this.port.Text;
                this.serialPort1.BaudRate = Convert.ToInt16(this.bitsPerSecond.Text);
                this.serialPort1.DataBits = Convert.ToInt16(this.dataBits.Text);

                // Set the Parity
                switch (this.parity.SelectedText)
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
                switch (this.stopBits.SelectedText)
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
                this.ts_connectionStatus.Text = "Connected to " + this.port.Text;
                this.ParsedMessageTable.Rows.Clear();
                this.terminal.Clear();
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
            if (this.serialPort1.IsOpen)
            {
                this.serialPort1.Close();
                this.ts_connectionStatus.Text = "";
            }
            else
            {
                MessageBox.Show("COM port is not open!");
            }
        }

        private void discoverEvent_Click(object sender, EventArgs e)
        {


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


        private void displayDeviceList()
        {
            // Store the devices temporarily
            System.Collections.Generic.List<IEBus_Studio.Device> deviceList = new System.Collections.Generic.List<IEBus_Studio.Device>(deviceManager.Devices);

            devicesTable.SuspendLayout();

            // Remove all existing rows (saveDeviceChanges() is invoked)
            devicesTable.Rows.Clear();

            // Restore the devices to the device manager
            deviceManager.Devices = deviceList;

            // Display each devices info as a row
            for (int i = 0; i < deviceManager.Devices.Count; i++)
            {
                devicesTable.Rows.Add(Convert.ToString(deviceManager.Devices[i].Address, 16), deviceManager.Devices[i].Name, deviceManager.Devices[i].Description);
            }

            devicesTable.ResumeLayout();
        }

        private void addDevice_Click(object sender, EventArgs e)
        {
            // Create a new device
            Device device = new Device(0, "Unkown Name", "Unkown Description");

            // Add it to the device list
            deviceManager.AddDevice(device);

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
                int address = Convert.ToInt32((string)devicesTable.Rows[i].Cells[0].Value, 16);
                string name = (string)devicesTable.Rows[i].Cells[1].Value;
                string description = (string)devicesTable.Rows[i].Cells[2].Value;
                Device device = new Device(address, name, description);

                deviceManager.Devices.Add(device);
            }
        }

        private void displayEventList()
        {
            // Store the devices temporarily
            System.Collections.Generic.List<IEBus_Studio.Event> eventList = new System.Collections.Generic.List<IEBus_Studio.Event>(eventManager.Events);

            // Pause drawing for a sec (speed boost)
            eventsTable.SuspendLayout();

            // Remove all existing rows (saveDeviceChanges() is invoked)
            eventsTable.Rows.Clear();

            // Restore the devices to the device manager
            eventManager.Events = eventList;

            // Display each devices info as a row
            for (int i = 0; i < eventManager.Events.Count; i++)
            {
                Event ev = (Event)(eventManager.Events[i]);


                //    string master = deviceManager.GetDeviceName(ev.Master_Address);
                //    if (master == null) master = ev.Master_Address_String;

                //    string slave = deviceManager.GetDeviceName(ev.Slave_Address);
                //    if (slave == null) master = ev.Slave_Address_String;
                string master = parseDeviceAddress(Convert.ToString(ev.Master, 16));
                string slave = parseDeviceAddress(Convert.ToString(ev.Slave, 16));
                string data = "";
                foreach (string var in ev.Variables)
                    data += var;
                eventsTable.Rows.Add(ev.Name, ev.Description, ev.Broadcast, master, slave, ev.Control, ev.Size, data);
            }

            // Resume Drawing
            eventsTable.ResumeLayout();
        }

        private void addEvent_Click(object sender, EventArgs e)
        {
            // Create the event with default values
            Event ev = new Event("Unkown", "Unkown", 1, 0, 0, ControlByte.DataWrite, "");

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

                string name = (string)eventsTable.Rows[i].Cells[0].Value;
                string description = (string)eventsTable.Rows[i].Cells[1].Value;
                int broadcast = Convert.ToInt32((string)eventsTable.Rows[i].Cells[2].Value);
                int master_address = Convert.ToInt32((string)eventsTable.Rows[i].Cells[3].Value, 16);
                int slave_address = Convert.ToInt32((string)eventsTable.Rows[i].Cells[4].Value, 16);
                ControlByte control = (ControlByte)Convert.ToInt32((string)eventsTable.Rows[i].Cells[5].Value, 16);
                string data = (string)eventsTable.Rows[i].Cells[7].Value;

                // Create the event object with all the data from the table
                Event ev = new Event(name, description, broadcast, master_address, slave_address, control, data);

                // Add the event to the event manager list
                eventManager.Events.Add(ev);
            }
        }


        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                // Get the event data of the event to be defined
                int broadcast = Convert.ToInt32((string)patternGrid.Rows[e.RowIndex].Cells["broadcastColumn"].Value);
                int master = (int)patternGrid.Rows[e.RowIndex].Cells["rawMasterColumn"].Value;
                int slave = (int)patternGrid.Rows[e.RowIndex].Cells["rawSlaveColumn"].Value;
                ControlByte control = (ControlByte)patternGrid.Rows[e.RowIndex].Cells["rawControlColumn"].Value;
                string data = (string)patternGrid.Rows[e.RowIndex].Cells["dataColumn"].Value;

                // Create an event from the data
                Event theEvent = new Event("", "", broadcast, master, slave, control, data);

                // Create the popup giving it the eventManager and the event
                AddEventPopup addEventPopup = new AddEventPopup(eventManager, theEvent, this);

                // Lock the main form and show the popup
                this.Enabled = false;
                addEventPopup.Show();
            }
        }
        private void exportDLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openedFilename == "")
            {
                MessageBox.Show("Please save your work first by choosing File->SaveAs or open an existing library.");
                return;
            }

            dllCreator.Creator dc = new dllCreator.Creator("Acura", "TSX", 2004);
            exportDLLSaveAsDialog.FileName = dc.PrefferedFilename;
            dc = null;
            exportDLLSaveAsDialog.ShowDialog();
        }
        private void exportDLLSaveAsDialog_FileOk(object sender, CancelEventArgs e)
        {
            //exportDLLSaveAsDialog.FileName;
            dllCreator.Creator DC = new dllCreator.Creator("Acura", "TSX", 2004);

            foreach (Device curDevice in deviceManager.Devices)
            {
                DC.DeviceManager.AddDevice(curDevice);
            }

            foreach (Event curEvent in eventManager.Events)
            {
                DC.AddEvent(curEvent);
            }

            DC.CompileDLL(exportDLLSaveAsDialog.FileName);

            /*
            dllCreator.Creator DC = new dllCreator.Creator("Acura", "TSX", 2004);
            DC.DeviceManager.AddDevice(0x131, "Touch Screen", "The touch screen.");
            DC.DeviceManager.AddDevice(0x183, "Navigation Unit", "The big black box in the back.");
            DC.AddEvent("TouchScreenDown", "Triggers when the touch screen is well... touched!", 0x131, 0x183, "37:31:D:0:1:3:%X:%Y:0:0:0:0:0:0:%Unknown1");
            DC.AddEvent("TouchScreenUp", "Triggers when the touch screen is well... touched!", 0x131, 0x183, "37:31:D:0:1:3:0:0:0:0:0:0:0:0:82");
            DC.AddEvent("SomthingElse", "Triggers when the touch screen is well... touched!", 0x131, 0x183, "37:31:%Unk4:0:1:3:%X:%Y:0:%Unk3:0:%Unk2:0:0:%Unknown1");
            DC.AddEvent("SmallerPattern", "Triggers when the touch screen is well... touched!", 0x131, 0x183, "37:31:D:0:1:3:%X:%Y:0:0:0");
            DC.AddEvent("TouchScreenPress", "Triggers when the touch screen is well... touched!", 0x131, 0x183, "37:31:D:0:1:3:%X:%Y:0:0:%Unknown1");
            */

        }
        #region "Saving and Loading"
        private void SaveIEB(bool SaveAs)
        {
            if (openedFilename != string.Empty && !SaveAs)
            {
                IEBFile saveFile = new IEBFile();
                saveFile.Save(openedFilename, eventManager, deviceManager);
            }
            else
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = "IEBus Data File|*.ieb";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    openedFilename = SFD.FileName; 
                    this.Text = "IEBus Studio - " + System.IO.Path.GetFileName(SFD.FileName);
                    IEBFile saveFile = new IEBFile();
                    saveFile.Save(SFD.FileName, eventManager, deviceManager);
                }
            }
        }
        private void LoadIEB()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "IEBus Data File|*.ieb";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                openedFilename = OFD.FileName; 
                this.Text = "IEBus Studio - " + System.IO.Path.GetFileName(OFD.FileName);

                IEBFile openFile = new IEBFile();
                openFile.Load(OFD.FileName);
                eventManager = openFile.EventManager;
                deviceManager = openFile.DeviceManager;

                displayDeviceList();
                displayEventList();
                this.MessageTableTabs.SelectedTab = this.MessageTableTabs.TabPages["eventsTab"];
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveIEB(true);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveIEB(false);
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveIEB(false);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadIEB();
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            LoadIEB();
        }
        #endregion
    }

}
