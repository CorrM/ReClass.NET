namespace ReClassNET.UI
{
	partial class MemoryCompareControl
    {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.selectedNodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.repaintTimer = new System.Windows.Forms.Timer(this.components);
            this.nodeInfoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.selectedNodeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectedNodeContextMenuStrip
            // 
            this.selectedNodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.selectedNodeContextMenuStrip.Name = "selectedNodeContextMenuStrip";
            this.selectedNodeContextMenuStrip.Size = new System.Drawing.Size(96, 26);
            this.selectedNodeContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.selectedNodeContextMenuStrip_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItem1.Text = "Test";
            // 
            // repaintTimer
            // 
            this.repaintTimer.Enabled = true;
            this.repaintTimer.Interval = 250;
            this.repaintTimer.Tick += new System.EventHandler(this.repaintTimer_Tick);
            // 
            // nodeInfoToolTip
            // 
            this.nodeInfoToolTip.ShowAlways = true;
            // 
            // MemoryCompareControl
            // 
            this.DoubleBuffered = true;
            this.Name = "MemoryCompareControl";
            this.Size = new System.Drawing.Size(277, 252);
            this.selectedNodeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip selectedNodeContextMenuStrip;
		private System.Windows.Forms.Timer repaintTimer;
		private System.Windows.Forms.ToolTip nodeInfoToolTip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
