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
			this.newFileButton = new System.Windows.Forms.ToolStripButton();
			this.saveButton = new System.Windows.Forms.ToolStripButton();
			this.saveAsButton = new System.Windows.Forms.ToolStripButton();
			this.openButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panelEditor.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileButton,
            this.openButton,
            this.saveButton,
            this.saveAsButton,
            this.toolStripSeparator,
            this.runButton,
            this.toolStripDropDownLogConsole});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(855, 25);
			this.toolStrip.TabIndex = 0;
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
			this.runButton.Size = new System.Drawing.Size(67, 22);
			this.runButton.Text = "&Executa";
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
			this.statusStrip.Location = new System.Drawing.Point(0, 550);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(855, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// fileNameLabel
			// 
			this.fileNameLabel.Name = "fileNameLabel";
			this.fileNameLabel.Size = new System.Drawing.Size(690, 17);
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
			this.panelEditor.Size = new System.Drawing.Size(855, 345);
			this.panelEditor.TabIndex = 3;
			// 
			// scintilla
			// 
			this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scintilla.IndentationGuides = ScintillaNET.IndentView.LookBoth;
			this.scintilla.Location = new System.Drawing.Point(0, 0);
			this.scintilla.Name = "scintilla";
			this.scintilla.Size = new System.Drawing.Size(855, 345);
			this.scintilla.TabIndex = 0;
			this.scintilla.UseTabs = true;
			this.scintilla.StyleNeeded += new System.EventHandler<ScintillaNET.StyleNeededEventArgs>(this.scintilla_StyleNeeded);
			this.scintilla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scintilla_KeyDown);
			this.scintilla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scintilla_KeyPress);
			// 
			// logBox
			// 
			this.logBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.logBox.IsInputEnabled = true;
			this.logBox.Location = new System.Drawing.Point(0, 370);
			this.logBox.Name = "logBox";
			this.logBox.SendKeyboardCommandsToProcess = false;
			this.logBox.ShowDiagnostics = false;
			this.logBox.Size = new System.Drawing.Size(855, 180);
			this.logBox.TabIndex = 4;
			// 
			// newFileButton
			// 
			this.newFileButton.Image = ((System.Drawing.Image)(resources.GetObject("newFileButton.Image")));
			this.newFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newFileButton.Name = "newFileButton";
			this.newFileButton.Size = new System.Drawing.Size(78, 22);
			this.newFileButton.Text = "Fisier nou";
			this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
			this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(71, 22);
			this.saveButton.Text = "Salveaza";
			this.saveButton.Click += new System.EventHandler(this.saveFileButton_Click);
			// 
			// saveAsButton
			// 
			this.saveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAsButton.Image")));
			this.saveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveAsButton.Name = "saveAsButton";
			this.saveAsButton.Size = new System.Drawing.Size(86, 22);
			this.saveAsButton.Text = "Salveaza ca";
			this.saveAsButton.Click += new System.EventHandler(this.saveFileAsButton_Click);
			// 
			// openButton
			// 
			this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
			this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(75, 22);
			this.openButton.Text = "Deschide";
			this.openButton.Click += new System.EventHandler(this.openFileButton_Click);
			// 
			// Editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(855, 572);
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
		private System.Windows.Forms.ToolStripButton newFileButton;
		private System.Windows.Forms.ToolStripButton openButton;
		private System.Windows.Forms.ToolStripButton saveButton;
		private System.Windows.Forms.ToolStripButton saveAsButton;
	}
}

