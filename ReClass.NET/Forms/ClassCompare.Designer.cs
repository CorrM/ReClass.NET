namespace ReClassNET.Forms
{
    partial class ClassCompare
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
            this.components = new System.ComponentModel.Container();
            this.bannerBox = new ReClassNET.UI.BannerBox();
            this.ClassBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addressPanel = new ReClassNET.UI.PanelWithScorllBar();
            this.Box2 = new ReClassNET.UI.PlaceholderTextBox();
            this.Box1 = new ReClassNET.UI.PlaceholderTextBox();
            this.addAddressBox = new System.Windows.Forms.Button();
            this.removeAddressBox = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LayoutPanel = new ReClassNET.UI.ScrollableSplitTable();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PointerCheck = new System.Windows.Forms.CheckBox();
            this.ViewTypeBox = new System.Windows.Forms.ComboBox();
            this.ShowHexBox = new System.Windows.Forms.CheckBox();
            this.ShowHiddenBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bannerBox)).BeginInit();
            this.addressPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bannerBox
            // 
            this.bannerBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.bannerBox.Icon = global::ReClassNET.Properties.Resources.compare32x32;
            this.bannerBox.Location = new System.Drawing.Point(0, 0);
            this.bannerBox.Name = "bannerBox";
            this.bannerBox.Size = new System.Drawing.Size(704, 48);
            this.bannerBox.TabIndex = 4;
            this.bannerBox.Text = "Compare memory based on class";
            this.bannerBox.Title = "Class Compare";
            // 
            // ClassBox
            // 
            this.ClassBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassBox.FormattingEnabled = true;
            this.ClassBox.Location = new System.Drawing.Point(46, 16);
            this.ClassBox.Name = "ClassBox";
            this.ClassBox.Size = new System.Drawing.Size(134, 21);
            this.ClassBox.TabIndex = 0;
            this.ClassBox.SelectedIndexChanged += new System.EventHandler(this.ClassBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Class :";
            // 
            // addressPanel
            // 
            this.addressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressPanel.AutoScroll = true;
            this.addressPanel.Controls.Add(this.Box2);
            this.addressPanel.Controls.Add(this.Box1);
            this.addressPanel.Location = new System.Drawing.Point(10, 96);
            this.addressPanel.Name = "addressPanel";
            this.addressPanel.Size = new System.Drawing.Size(685, 45);
            this.addressPanel.TabIndex = 1;
            // 
            // Box2
            // 
            this.Box2.BackColor = System.Drawing.SystemColors.Window;
            this.Box2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Box2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Box2.Location = new System.Drawing.Point(116, 4);
            this.Box2.Name = "Box2";
            this.Box2.PlaceholderText = "Address";
            this.Box2.Size = new System.Drawing.Size(107, 20);
            this.Box2.TabIndex = 1;
            // 
            // Box1
            // 
            this.Box1.BackColor = System.Drawing.SystemColors.Window;
            this.Box1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Box1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Box1.Location = new System.Drawing.Point(3, 4);
            this.Box1.Name = "Box1";
            this.Box1.PlaceholderText = "Address";
            this.Box1.Size = new System.Drawing.Size(107, 20);
            this.Box1.TabIndex = 0;
            // 
            // addAddressBox
            // 
            this.addAddressBox.Location = new System.Drawing.Point(182, 16);
            this.addAddressBox.Name = "addAddressBox";
            this.addAddressBox.Size = new System.Drawing.Size(23, 21);
            this.addAddressBox.TabIndex = 1;
            this.addAddressBox.Text = "+";
            this.addAddressBox.UseVisualStyleBackColor = true;
            this.addAddressBox.Click += new System.EventHandler(this.AddAddressBox_Click);
            // 
            // removeAddressBox
            // 
            this.removeAddressBox.Location = new System.Drawing.Point(206, 16);
            this.removeAddressBox.Name = "removeAddressBox";
            this.removeAddressBox.Size = new System.Drawing.Size(23, 21);
            this.removeAddressBox.TabIndex = 2;
            this.removeAddressBox.Text = "-";
            this.removeAddressBox.UseVisualStyleBackColor = true;
            this.removeAddressBox.Click += new System.EventHandler(this.RemoveAddressBox_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ClassBox);
            this.groupBox2.Controls.Add(this.removeAddressBox);
            this.groupBox2.Controls.Add(this.addAddressBox);
            this.groupBox2.Location = new System.Drawing.Point(10, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 44);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compare Options";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutPanel.Location = new System.Drawing.Point(0, 147);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.Size = new System.Drawing.Size(704, 303);
            this.LayoutPanel.TabIndex = 6;
            this.LayoutPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tableLayoutPanel1_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PointerCheck);
            this.groupBox3.Controls.Add(this.ViewTypeBox);
            this.groupBox3.Location = new System.Drawing.Point(246, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 44);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View Options";
            // 
            // PointerCheck
            // 
            this.PointerCheck.AutoSize = true;
            this.PointerCheck.Location = new System.Drawing.Point(163, 18);
            this.PointerCheck.Name = "PointerCheck";
            this.PointerCheck.Size = new System.Drawing.Size(103, 17);
            this.PointerCheck.TabIndex = 2;
            this.PointerCheck.Text = "Include Pointers";
            this.PointerCheck.UseVisualStyleBackColor = true;
            this.PointerCheck.CheckedChanged += new System.EventHandler(this.PointerCheck_CheckedChanged);
            // 
            // ViewTypeBox
            // 
            this.ViewTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ViewTypeBox.FormattingEnabled = true;
            this.ViewTypeBox.Items.AddRange(new object[] {
            "not mattar",
            "value match",
            "value not match"});
            this.ViewTypeBox.Location = new System.Drawing.Point(6, 16);
            this.ViewTypeBox.Name = "ViewTypeBox";
            this.ViewTypeBox.Size = new System.Drawing.Size(151, 21);
            this.ViewTypeBox.TabIndex = 1;
            this.ViewTypeBox.SelectedIndexChanged += new System.EventHandler(this.ViewTypeBox_SelectedIndexChanged);
            // 
            // ShowHexBox
            // 
            this.ShowHexBox.AutoSize = true;
            this.ShowHexBox.Location = new System.Drawing.Point(522, 55);
            this.ShowHexBox.Name = "ShowHexBox";
            this.ShowHexBox.Size = new System.Drawing.Size(74, 17);
            this.ShowHexBox.TabIndex = 9;
            this.ShowHexBox.Text = "Show Hex";
            this.ShowHexBox.UseVisualStyleBackColor = true;
            this.ShowHexBox.CheckedChanged += new System.EventHandler(this.ShowHexBox_CheckedChanged);
            // 
            // ShowHiddenBox
            // 
            this.ShowHiddenBox.AutoSize = true;
            this.ShowHiddenBox.Location = new System.Drawing.Point(522, 76);
            this.ShowHiddenBox.Name = "ShowHiddenBox";
            this.ShowHiddenBox.Size = new System.Drawing.Size(88, 17);
            this.ShowHiddenBox.TabIndex = 10;
            this.ShowHiddenBox.Text = "Show Hidden";
            this.ShowHiddenBox.UseVisualStyleBackColor = true;
            this.ShowHiddenBox.CheckedChanged += new System.EventHandler(this.ShowHiddenBox_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(613, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Nothing Yet";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(613, 76);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(82, 17);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Nothing Yet";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // ClassCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ShowHiddenBox);
            this.Controls.Add(this.ShowHexBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.LayoutPanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.addressPanel);
            this.Controls.Add(this.bannerBox);
            this.MinimumSize = new System.Drawing.Size(720, 489);
            this.Name = "ClassCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReClass.NET - Class Compare";
            this.Load += new System.EventHandler(this.ClassCompare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bannerBox)).EndInit();
            this.addressPanel.ResumeLayout(false);
            this.addressPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UI.BannerBox bannerBox;
        private System.Windows.Forms.ComboBox ClassBox;
        private System.Windows.Forms.Label label1;
        private UI.PanelWithScorllBar addressPanel;
        private System.Windows.Forms.Button addAddressBox;
        private System.Windows.Forms.Button removeAddressBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer1;
        private UI.ScrollableSplitTable LayoutPanel;
        private UI.PlaceholderTextBox Box2;
        private UI.PlaceholderTextBox Box1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ViewTypeBox;
        private System.Windows.Forms.CheckBox PointerCheck;
        private System.Windows.Forms.CheckBox ShowHexBox;
        private System.Windows.Forms.CheckBox ShowHiddenBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}