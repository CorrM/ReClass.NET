namespace ReClassNET.UI
{
    partial class ScrollableSplitTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelControl = new ReClassNET.UI.SplitTablePanel();
            this.SuspendLayout();
            // 
            // PanelControl
            // 
            this.PanelControl.AutoScroll = true;
            this.PanelControl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.PanelControl.ColumnCount = 1;
            this.PanelControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 490F));
            this.PanelControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControl.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.PanelControl.Location = new System.Drawing.Point(0, 0);
            this.PanelControl.Name = "PanelControl";
            this.PanelControl.RowCount = 1;
            this.PanelControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelControl.Size = new System.Drawing.Size(482, 287);
            this.PanelControl.SplitterSize = 6;
            this.PanelControl.TabIndex = 1;
            // 
            // ScrollableSplitTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelControl);
            this.Name = "ScrollableSplitTable";
            this.Size = new System.Drawing.Size(482, 287);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitTablePanel PanelControl;
    }
}
