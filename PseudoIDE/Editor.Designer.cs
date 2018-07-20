namespace PseudoIDE
{
	partial class Editor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.newFileButton = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileButton = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileButton = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileAsButton = new System.Windows.Forms.ToolStripMenuItem();
			this.exitButton = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.runButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownLogConsole = new System.Windows.Forms.ToolStripDropDownButton();
			this.toggleLoxBoxButton = new System.Windows.Forms.ToolStripMenuItem();
			this.clearLogButton = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.fileNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.lineLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.columnLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panelEditor = new System.Windows.Forms.Panel();
			this.scintilla = new ScintillaNET.Scintilla();
			this.logBox = new ConsoleControl.ConsoleControl();
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panelEditor.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolStripSeparator,
            this.runButton,
            this.toolStripDropDownLogConsole});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(800, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// fileMenu
			// 
			this.fileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileButton,
            this.openFileButton,
            this.saveFileButton,
            this.saveFileAsButton,
            this.exitButton});
			this.fileMenu.Image = ((System.Drawing.Image)(resources.GetObject("fileMenu.Image")));
			this.fileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(38, 22);
			this.fileMenu.Text = "&File";
			// 
			// newFileButton
			// 
			this.newFileButton.Name = "newFileButton";
			this.newFileButton.Size = new System.Drawing.Size(114, 22);
			this.newFileButton.Text = "&New";
			this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
			// 
			// openFileButton
			// 
			this.openFileButton.Name = "openFileButton";
			this.openFileButton.Size = new System.Drawing.Size(114, 22);
			this.openFileButton.Text = "&Open";
			this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
			// 
			// saveFileButton
			// 
			this.saveFileButton.Name = "saveFileButton";
			this.saveFileButton.Size = new System.Drawing.Size(114, 22);
			this.saveFileButton.Text = "&Save";
			this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
			// 
			// saveFileAsButton
			// 
			this.saveFileAsButton.Name = "saveFileAsButton";
			this.saveFileAsButton.Size = new System.Drawing.Size(114, 22);
			this.saveFileAsButton.Text = "Save &As";
			this.saveFileAsButton.Click += new System.EventHandler(this.saveFileAsButton_Click);
			// 
			// exitButton
			// 
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(114, 22);
			this.exitButton.Text = "&Exit";
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// runButton
			// 
			this.runButton.Image = ((System.Drawing.Image)(resources.GetObject("runButton.Image")));
			this.runButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.runButton.Name = "runButton";
			this.runButton.Size = new System.Drawing.Size(48, 22);
			this.runButton.Text = "&Run";
			this.runButton.Click += new System.EventHandler(this.runButton_Click);
			// 
			// toolStripDropDownLogConsole
			// 
			this.toolStripDropDownLogConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownLogConsole.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleLoxBoxButton,
            this.clearLogButton});
			this.toolStripDropDownLogConsole.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownLogConsole.Image")));
			this.toolStripDropDownLogConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownLogConsole.Name = "toolStripDropDownLogConsole";
			this.toolStripDropDownLogConsole.Size = new System.Drawing.Size(40, 22);
			this.toolStripDropDownLogConsole.Text = "Log";
			// 
			// toggleLoxBoxButton
			// 
			this.toggleLoxBoxButton.Name = "toggleLoxBoxButton";
			this.toggleLoxBoxButton.Size = new System.Drawing.Size(110, 22);
			this.toggleLoxBoxButton.Text = "Toggle";
			this.toggleLoxBoxButton.Click += new System.EventHandler(this.toggleLoxBoxButton_Click);
			// 
			// clearLogButton
			// 
			this.clearLogButton.Name = "clearLogButton";
			this.clearLogButton.Size = new System.Drawing.Size(110, 22);
			this.clearLogButton.Text = "Clear";
			this.clearLogButton.Click += new System.EventHandler(this.clearLogButton_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNameLabel,
            this.lineLabel,
            this.columnLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 428);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(800, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// fileNameLabel
			// 
			this.fileNameLabel.Name = "fileNameLabel";
			this.fileNameLabel.Size = new System.Drawing.Size(635, 17);
			this.fileNameLabel.Spring = true;
			this.fileNameLabel.Text = "FileName";
			this.fileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lineLabel
			// 
			this.lineLabel.AutoSize = false;
			this.lineLabel.Name = "lineLabel";
			this.lineLabel.Size = new System.Drawing.Size(75, 17);
			this.lineLabel.Text = "Ln";
			this.lineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// columnLabel
			// 
			this.columnLabel.AutoSize = false;
			this.columnLabel.Name = "columnLabel";
			this.columnLabel.Size = new System.Drawing.Size(75, 17);
			this.columnLabel.Text = "Col";
			this.columnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// panelEditor
			// 
			this.panelEditor.Controls.Add(this.scintilla);
			this.panelEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelEditor.Location = new System.Drawing.Point(0, 25);
			this.panelEditor.Name = "panelEditor";
			this.panelEditor.Size = new System.Drawing.Size(800, 223);
			this.panelEditor.TabIndex = 3;
			// 
			// scintilla
			// 
			this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scintilla.IndentationGuides = ScintillaNET.IndentView.LookBoth;
			this.scintilla.Location = new System.Drawing.Point(0, 0);
			this.scintilla.Name = "scintilla";
			this.scintilla.Size = new System.Drawing.Size(800, 223);
			this.scintilla.TabIndex = 0;
			this.scintilla.UseTabs = true;
			this.scintilla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scintilla_KeyDown);
			// 
			// logBox
			// 
			this.logBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.logBox.IsInputEnabled = true;
			this.logBox.Location = new System.Drawing.Point(0, 248);
			this.logBox.Name = "logBox";
			this.logBox.SendKeyboardCommandsToProcess = false;
			this.logBox.ShowDiagnostics = false;
			this.logBox.Size = new System.Drawing.Size(800, 180);
			this.logBox.TabIndex = 4;
			// 
			// Editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panelEditor);
			this.Controls.Add(this.logBox);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "Editor";
			this.Text = "PseudoIDE";
			this.Load += new System.EventHandler(this.Editor_Load);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.panelEditor.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripDropDownButton fileMenu;
		private System.Windows.Forms.ToolStripMenuItem newFileButton;
		private System.Windows.Forms.ToolStripMenuItem openFileButton;
		private System.Windows.Forms.ToolStripMenuItem saveFileButton;
		private System.Windows.Forms.ToolStripMenuItem saveFileAsButton;
		private System.Windows.Forms.ToolStripMenuItem exitButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripButton runButton;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel lineLabel;
		private System.Windows.Forms.ToolStripStatusLabel columnLabel;
		private System.Windows.Forms.ToolStripStatusLabel fileNameLabel;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Panel panelEditor;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownLogConsole;
		private System.Windows.Forms.ToolStripMenuItem toggleLoxBoxButton;
		private System.Windows.Forms.ToolStripMenuItem clearLogButton;
		private ConsoleControl.ConsoleControl logBox;
		private ScintillaNET.Scintilla scintilla;
	}
}

