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
        private SaveFileDialog chooseOutputFile;
        private System.IO.Ports.SerialPort serialPort1;
        private IContainer components;
        private ToolStripMenuItem changeMessageTableToolStripMenuItem;
        private TabControl MessageTableTabs;
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
        private Button scanDevices;
        private OpenFileDialog openFileDialog1;
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
        private DataGridViewTextBoxColumn Event_Name;
        private DataGridViewTextBoxColumn Event_Description;
        private DataGridViewTextBoxColumn Event_Broadcast;
        private DataGridViewTextBoxColumn Event_Master;
        private DataGridViewTextBoxColumn event_Slave;
        private DataGridViewTextBoxColumn Event_Control;
        private DataGridViewTextBoxColumn Event_DataSize;
        private DataGridViewTextBoxColumn Event_Data;
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
        private Button Connect;
        private TabPage liveMessages;
        private Label label7;
        private DataGridView ParsedMessageTable;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Master;
        private DataGridViewTextBoxColumn Slave;
        private DataGridViewTextBoxColumn Control;
        private DataGridViewTextBoxColumn DataSize;
        private DataGridViewTextBoxColumn Data1;
        private CheckBox checkBox1;
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts_connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.eventDiscoveryTab = new System.Windows.Forms.TabPage();
            this.andOr = new System.Windows.Forms.ComboBox();
            this.variableDataFilter = new System.Windows.Forms.CheckBox();
            this.slaveFilter = new System.Windows.Forms.ComboBox();
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
            this.masterFilter = new System.Windows.Forms.ComboBox();
            this.discoverEvent = new System.Windows.Forms.Button();
            this.secondsToDiscover = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.devicesTab = new System.Windows.Forms.TabPage();
            this.autoAddDevices = new System.Windows.Forms.CheckBox();
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
            this.Connect = new System.Windows.Forms.Button();
            this.liveMessages = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.ParsedMessageTable = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Master = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chooseOutputFile = new System.Windows.Forms.SaveFileDialog();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MessageTableTabs.SuspendLayout();
            this.eventDiscoveryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventDiscoveryTable)).BeginInit();
            this.EventActionsMenuStrip.SuspendLayout();
            this.devicesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesTable)).BeginInit();
            this.eventsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsTable)).BeginInit();
            this.BottomTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.liveMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsedMessageTable)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_connectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(819, 22);
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
            this.toolStrip1.Size = new System.Drawing.Size(819, 25);
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
            this.menuStrip1.Size = new System.Drawing.Size(819, 24);
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
            this.panel1.Size = new System.Drawing.Size(819, 487);
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
            this.splitContainer1.Size = new System.Drawing.Size(819, 487);
            this.splitContainer1.SplitterDistance = 313;
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
            this.MessageTableTabs.Name = "MessageTableTabs";
            this.MessageTableTabs.SelectedIndex = 0;
            this.MessageTableTabs.Size = new System.Drawing.Size(819, 313);
            this.MessageTableTabs.TabIndex = 5;
            // 
            // eventDiscoveryTab
            // 
            this.eventDiscoveryTab.Controls.Add(this.andOr);
            this.eventDiscoveryTab.Controls.Add(this.variableDataFilter);
            this.eventDiscoveryTab.Controls.Add(this.slaveFilter);
            this.eventDiscoveryTab.Controls.Add(this.timeLeftLabel);
            this.eventDiscoveryTab.Controls.Add(this.eventDiscoveryTable);
            this.eventDiscoveryTab.Controls.Add(this.masterFilter);
            this.eventDiscoveryTab.Controls.Add(this.discoverEvent);
            this.eventDiscoveryTab.Controls.Add(this.secondsToDiscover);
            this.eventDiscoveryTab.Controls.Add(this.label10);
            this.eventDiscoveryTab.Controls.Add(this.label9);
            this.eventDiscoveryTab.Controls.Add(this.label8);
            this.eventDiscoveryTab.Location = new System.Drawing.Point(4, 22);
            this.eventDiscoveryTab.Name = "eventDiscoveryTab";
            this.eventDiscoveryTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventDiscoveryTab.Size = new System.Drawing.Size(811, 287);
            this.eventDiscoveryTab.TabIndex = 3;
            this.eventDiscoveryTab.Text = "Event Discovery";
            this.eventDiscoveryTab.UseVisualStyleBackColor = true;
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
            this.variableDataFilter.Location = new System.Drawing.Point(514, 24);
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
            // eventDiscoveryTable
            // 
            this.eventDiscoveryTable.AllowUserToAddRows = false;
            this.eventDiscoveryTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            this.eventDiscoveryTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.eventDiscoveryTable.Location = new System.Drawing.Point(3, 51);
            this.eventDiscoveryTable.Margin = new System.Windows.Forms.Padding(0);
            this.eventDiscoveryTable.Name = "eventDiscoveryTable";
            this.eventDiscoveryTable.RowTemplate.ContextMenuStrip = this.EventActionsMenuStrip;
            this.eventDiscoveryTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.eventDiscoveryTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.eventDiscoveryTable.RowTemplate.Height = 18;
            this.eventDiscoveryTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.eventDiscoveryTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDiscoveryTable.Size = new System.Drawing.Size(805, 233);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "\"0x\"0000";
            this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn22.HeaderText = "Master";
            this.dataGridViewTextBoxColumn22.MaxInputLength = 1024;
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn23
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Format = "\"0x\"0000";
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn23.HeaderText = "Slave";
            this.dataGridViewTextBoxColumn23.MaxInputLength = 1024;
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn24
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Format = "\"0x\"0000";
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn24.HeaderText = "Control";
            this.dataGridViewTextBoxColumn24.MaxInputLength = 50;
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn24.Width = 50;
            // 
            // dataGridViewTextBoxColumn25
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle5;
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
            this.addEventToolStripMenuItem.Click += new System.EventHandler(this.addEventToolStripMenuItem_Click);
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
            this.discoverEvent.Location = new System.Drawing.Point(702, 21);
            this.discoverEvent.Name = "discoverEvent";
            this.discoverEvent.Size = new System.Drawing.Size(92, 20);
            this.discoverEvent.TabIndex = 2;
            this.discoverEvent.Text = "Discover Event";
            this.discoverEvent.UseVisualStyleBackColor = true;
            this.discoverEvent.Click += new System.EventHandler(this.discoverEvent_Click);
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
            this.devicesTab.Controls.Add(this.autoAddDevices);
            this.devicesTab.Controls.Add(this.scanDevices);
            this.devicesTab.Controls.Add(this.addDevice);
            this.devicesTab.Controls.Add(this.devicesTable);
            this.devicesTab.Location = new System.Drawing.Point(4, 22);
            this.devicesTab.Name = "devicesTab";
            this.devicesTab.Padding = new System.Windows.Forms.Padding(3);
            this.devicesTab.Size = new System.Drawing.Size(811, 287);
            this.devicesTab.TabIndex = 4;
            this.devicesTab.Text = "Device Discovery";
            this.devicesTab.UseVisualStyleBackColor = true;
            // 
            // autoAddDevices
            // 
            this.autoAddDevices.AutoSize = true;
            this.autoAddDevices.Checked = true;
            this.autoAddDevices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoAddDevices.Location = new System.Drawing.Point(122, 13);
            this.autoAddDevices.Name = "autoAddDevices";
            this.autoAddDevices.Size = new System.Drawing.Size(144, 17);
            this.autoAddDevices.TabIndex = 9;
            this.autoAddDevices.Text = "Auto add unique devices";
            this.autoAddDevices.UseVisualStyleBackColor = true;
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
            this.addDevice.Location = new System.Drawing.Point(713, 10);
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
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Transparent;
            this.devicesTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
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
            this.devicesTable.Size = new System.Drawing.Size(805, 245);
            this.devicesTable.TabIndex = 6;
            this.devicesTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.saveDeviceChanges);
            this.devicesTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.saveDeviceChanges);
            // 
            // devices_deviceAddress
            // 
            this.devices_deviceAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devices_deviceAddress.DefaultCellStyle = dataGridViewCellStyle7;
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
            this.eventsTab.Controls.Add(this.addEvent);
            this.eventsTab.Controls.Add(this.eventsTable);
            this.eventsTab.Location = new System.Drawing.Point(4, 22);
            this.eventsTab.Name = "eventsTab";
            this.eventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventsTab.Size = new System.Drawing.Size(811, 287);
            this.eventsTab.TabIndex = 5;
            this.eventsTab.Text = "Defined Events";
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
            this.eventsTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent;
            this.eventsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
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
            this.eventsTable.Size = new System.Drawing.Size(805, 245);
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
            this.Event_Control.Width = 50;
            // 
            // Event_DataSize
            // 
            this.Event_DataSize.HeaderText = "DataSize";
            this.Event_DataSize.Name = "Event_DataSize";
            this.Event_DataSize.ReadOnly = true;
            this.Event_DataSize.Width = 75;
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
            this.BottomTabs.Size = new System.Drawing.Size(819, 170);
            this.BottomTabs.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.terminal);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(811, 144);
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
            this.terminal.Size = new System.Drawing.Size(394, 138);
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
            this.groupBox1.Controls.Add(this.Connect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 138);
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
            this.port.Text = "COM4";
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
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(182, 280);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 6;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            // 
            // liveMessages
            // 
            this.liveMessages.Controls.Add(this.label7);
            this.liveMessages.Controls.Add(this.ParsedMessageTable);
            this.liveMessages.Controls.Add(this.checkBox1);
            this.liveMessages.Location = new System.Drawing.Point(4, 22);
            this.liveMessages.Name = "liveMessages";
            this.liveMessages.Padding = new System.Windows.Forms.Padding(3);
            this.liveMessages.Size = new System.Drawing.Size(811, 144);
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
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Transparent;
            this.ParsedMessageTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.ParsedMessageTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.ParsedMessageTable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.ParsedMessageTable.Location = new System.Drawing.Point(3, 26);
            this.ParsedMessageTable.Margin = new System.Windows.Forms.Padding(0);
            this.ParsedMessageTable.Name = "ParsedMessageTable";
            this.ParsedMessageTable.ReadOnly = true;
            this.ParsedMessageTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.ParsedMessageTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.ParsedMessageTable.RowTemplate.Height = 18;
            this.ParsedMessageTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParsedMessageTable.Size = new System.Drawing.Size(805, 115);
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
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Master.DefaultCellStyle = dataGridViewCellStyle10;
            this.Master.HeaderText = "Master";
            this.Master.MaxInputLength = 1024;
            this.Master.Name = "Master";
            this.Master.ReadOnly = true;
            this.Master.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Slave
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info;
            this.Slave.DefaultCellStyle = dataGridViewCellStyle11;
            this.Slave.HeaderText = "Slave";
            this.Slave.MaxInputLength = 1024;
            this.Slave.Name = "Slave";
            this.Slave.ReadOnly = true;
            this.Slave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Control
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.AliceBlue;
            this.Control.DefaultCellStyle = dataGridViewCellStyle12;
            this.Control.HeaderText = "Control";
            this.Control.MaxInputLength = 50;
            this.Control.Name = "Control";
            this.Control.ReadOnly = true;
            this.Control.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Control.Width = 75;
            // 
            // DataSize
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = "0";
            this.DataSize.DefaultCellStyle = dataGridViewCellStyle13;
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
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(670, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Lookup Device Names";
            this.checkBox1.UseVisualStyleBackColor = true;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 558);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = "IEBus Studio";
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
            ((System.ComponentModel.ISupportInitialize)(this.eventDiscoveryTable)).EndInit();
            this.EventActionsMenuStrip.ResumeLayout(false);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem addEventItem = (ToolStripDropDownItem)sender;

            AddEventPopup eventPopup = new AddEventPopup(eventManager);
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
            dllCreator.Creator DC = new dllCreator.Creator("Acura", "TSX", 2004);
            DC.DeviceManager.AddDevice(0x131, "Touch Screen", "The touch screen.");
            DC.DeviceManager.AddDevice(0x183, "Navigation Unit", "The big black box in the back.");
            DC.AddEvent("TouchScreenPress", "Triggers when the touch screen is well... touched!", 0x131, 0x183, "37:31:D:0:1:3:%X:%Y:0:0:0:0:0:0:%Unknown1");
            DC.CompileDLL(Application.StartupPath + "\\");

            this.port.Items.Clear();
            this.port.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        }


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            DataReceived(this.serialPort1.ReadExisting());
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

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
                    Console.WriteLine(e.GetBaseException());
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
                            string[] rawArray = wrkMessage.Split(':');
                            string[] parsedArray = wrkMessage.Split(':');

                            //AutoAdd devices
                            if (this.autoAddDevices.Checked)
                            {
                                // AutoAdd Master device
                                if (!isDeviceDefined(Convert.ToInt32(rawArray[1], 16)))
                                {
                                    Device d = new Device(Convert.ToInt32(rawArray[1], 16), "Unknown", "");
                                    this.deviceManager.addDevice(d);

                                    // ReRender the device list
                                    displayDeviceList();
                                }

                                // AutoAdd Slave device
                                if (!isDeviceDefined(Convert.ToInt32(rawArray[2], 16)))
                                {
                                    Device d = new Device(Convert.ToInt32(rawArray[2], 16), "Unknown", "");
                                    this.deviceManager.addDevice(d);

                                    // ReRender the device list
                                    displayDeviceList();
                                }
                            }

                            //Add 0x format to some raw columns
                            rawArray[1] = "0x" + rawArray[1];
                            rawArray[2] = "0x" + rawArray[2];
                            rawArray[3] = "0x" + rawArray[3];

                            //Prepare parsed record
                            parsedArray[1] = parseDeviceAddress(parsedArray[1]);
                            parsedArray[2] = parseDeviceAddress(parsedArray[2]);
                            parsedArray[3] = parseControl(parsedArray[3]);
                            parsedArray[5] = parseData(parsedArray);
                            parsedArray = new string[] { parsedArray[0], parsedArray[1], parsedArray[2], parsedArray[3], parsedArray[4], parsedArray[5] };

                        //Populate a new row for each table
                        //RawMessageTable.Rows.Add(rawArray);
                        ParsedMessageTable.Rows.Add(parsedArray);

                            if (eventDiscoverer.discoveryingEvents())
                            {
                                rawArray = wrkMessage.Split(':');

                                char broadcast = rawArray[0][0];
                                int master_address = Convert.ToInt32(rawArray[1], 16); 
                                int slave_address = Convert.ToInt32(rawArray[2], 16);
                                char control = rawArray[3][0];
                                ushort datasize = (ushort)Convert.ToInt16(parsedArray[4]);
                                string data = parsedArray[5];


                                Event discoveredEvent = new Event("Unkown", "Unkown", broadcast, master_address, slave_address, control, datasize, data);
                                eventDiscoverer.addEvent(discoveredEvent);

                                displayDiscoveredEventList();
                            }
                        }
                    }
                }
                leftOverText = text;
            }
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
                if (d.Address == master_address) { return d.Name; }

            return pmaster;
        }

        private string parseControl(string pcontrol)
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
                result += pdata[i];
            }

            return result;
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

        private void displayDiscoveredEventList()
        {
            // Store the devices temporarily
            ArrayList discoveredEventList = new ArrayList(eventDiscoverer.DiscoveredEvents);

            eventDiscoveryTable.SuspendLayout();

            // Remove all existing rows (saveDeviceChanges() is invoked)
            eventDiscoveryTable.Rows.Clear();

            // Restore the devices to the device manager
            eventDiscoverer.DiscoveredEvents = discoveredEventList;

            // Display each devices info as a row
            for (int i = 0; i < eventDiscoverer.DiscoveredEvents.Count; i++)
            {
                DiscoveredEvent devent = (DiscoveredEvent)(eventDiscoverer.DiscoveredEvents[i]);
                Event ev = (Event)devent.TheEvent;

                string master = parseDeviceAddress(Convert.ToString(ev.Master, 16));
                string slave = parseDeviceAddress(Convert.ToString(ev.Slave, 16));
                string data = "";
                foreach (string var in ev.Variables)
                    data += var;
                eventDiscoveryTable.Rows.Add(devent.NumberOfInstances, ev.Broadcast, master, slave, ev.Control, ev.Size, data);
            }
            eventDiscoveryTable.ResumeLayout();
        }

        private void displayDeviceList()
        {
            // Store the devices temporarily
            ArrayList deviceList = new ArrayList(deviceManager.Devices);

            devicesTable.SuspendLayout();

            // Remove all existing rows (saveDeviceChanges() is invoked)
            devicesTable.Rows.Clear();

            // Restore the devices to the device manager
            deviceManager.Devices = deviceList;

            // Display each devices info as a row
            for (int i = 0; i < deviceManager.Devices.Count; i++)
            {
                Device device = (Device)(deviceManager.Devices[i]);
                devicesTable.Rows.Add(Convert.ToString(device.Address, 16), device.Name, device.Description);
            }

            devicesTable.ResumeLayout();
        }

        private void addDevice_Click(object sender, EventArgs e)
        {
            // Create a new device
            Device device = new Device(0, "Unkown Name", "Unkown Description");

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
            ArrayList eventList = new ArrayList(eventManager.Events);

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
            Event ev = new Event("Unkown", "Unkown", '1', 0, 0, 'F', 0, "");

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
                char broadcast = ((string)eventsTable.Rows[i].Cells[2].Value)[0];
                int master_address = Convert.ToInt32((string)eventsTable.Rows[i].Cells[3].Value, 16);
                int slave_address = Convert.ToInt32((string)eventsTable.Rows[i].Cells[4].Value, 16);
                char control = (char)eventsTable.Rows[i].Cells[5].Value;
                ushort datasize = 15; //(ushort)eventsTable.Rows[i].Cells[6].Value;  <-- bombs on the cast
                string data = (string)eventsTable.Rows[i].Cells[7].Value;

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
            string xml = "<root>" + deviceManager.ouputAsXML() + eventManager.ouputAsXML() + "</root>";

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
                deviceManager.addDevice(new Device(Convert.ToInt32(device.ChildNodes[2].FirstChild.Value, 16), device.ChildNodes[0].FirstChild.Value, device.ChildNodes[1].FirstChild.Value));

            foreach (XmlNode ev in events)
            {
                string name = ev.ChildNodes[0].FirstChild.Value;
                string description = ev.ChildNodes[1].FirstChild.Value;
                char broadcast = ev.ChildNodes[2].FirstChild.Value[0];
                int master = Convert.ToInt32(ev.ChildNodes[3].FirstChild.Value, 16);
                int slave = Convert.ToInt32(ev.ChildNodes[4].FirstChild.Value, 16);
                char control = ev.ChildNodes[5].FirstChild.Value[0];
                ushort size = Convert.ToUInt16(ev.ChildNodes[6].FirstChild.Value, 10);

                string data = "";
                for (int i = 6; i < ev.ChildNodes.Count; i++)
                {
                    if (i != 6)
                        data += ":";
                    data += ev.ChildNodes[i].FirstChild.Value;
                }
                    
                eventManager.addEvent(new Event(name, description, broadcast, master, slave, control, size, data));
            }

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
