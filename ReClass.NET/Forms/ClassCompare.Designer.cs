﻿namespace ReClassNET.Forms
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LayoutPanel = new ReClassNET.UI.ScrollableSplitTable();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ViewTypeBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bannerBox)).BeginInit();
            this.addressPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.ClassBox.Location = new System.Drawing.Point(51, 16);
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
            this.addAddressBox.Location = new System.Drawing.Point(191, 16);
            this.addAddressBox.Name = "addAddressBox";
            this.addAddressBox.Size = new System.Drawing.Size(23, 21);
            this.addAddressBox.TabIndex = 1;
            this.addAddressBox.Text = "+";
            this.addAddressBox.UseVisualStyleBackColor = true;
            this.addAddressBox.Click += new System.EventHandler(this.AddAddressBox_Click);
            // 
            // removeAddressBox
            // 
            this.removeAddressBox.Location = new System.Drawing.Point(215, 16);
            this.removeAddressBox.Name = "removeAddressBox";
            this.removeAddressBox.Size = new System.Drawing.Size(23, 21);
            this.removeAddressBox.TabIndex = 2;
            this.removeAddressBox.Text = "-";
            this.removeAddressBox.UseVisualStyleBackColor = true;
            this.removeAddressBox.Click += new System.EventHandler(this.RemoveAddressBox_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(112, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Match Class Items";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(133, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(109, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Memory Compare";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ClassBox);
            this.groupBox2.Controls.Add(this.removeAddressBox);
            this.groupBox2.Controls.Add(this.addAddressBox);
            this.groupBox2.Location = new System.Drawing.Point(10, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 44);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(264, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 44);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memory Scane Type";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ViewTypeBox);
            this.groupBox3.Location = new System.Drawing.Point(518, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(177, 44);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View Options";
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
            this.ViewTypeBox.Size = new System.Drawing.Size(168, 21);
            this.ViewTypeBox.TabIndex = 1;
            this.ViewTypeBox.SelectedIndexChanged += new System.EventHandler(this.ViewTypeBox_SelectedIndexChanged);
            // 
            // ClassCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UI.BannerBox bannerBox;
        private System.Windows.Forms.ComboBox ClassBox;
        private System.Windows.Forms.Label label1;
        private UI.PanelWithScorllBar addressPanel;
        private System.Windows.Forms.Button addAddressBox;
        private System.Windows.Forms.Button removeAddressBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer1;
        private UI.ScrollableSplitTable LayoutPanel;
        private UI.PlaceholderTextBox Box2;
        private UI.PlaceholderTextBox Box1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ViewTypeBox;
    }
}