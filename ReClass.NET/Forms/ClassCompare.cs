using ReClassNET.Memory;
using ReClassNET.Nodes;
using ReClassNET.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReClassNET.Forms
{
    public partial class ClassCompare : IconForm
    {
        struct CompareItem
        {
            public PlaceholderTextBox AddressBox;
            public MemoryCompareControl ViewBox;
        }

        private List<CompareItem> CompareItems;
        private IEnumerable<ClassNode> Classes;

        public ClassCompare(IEnumerable<ClassNode> classes)
        {
            Contract.Requires(classes != null);
            InitializeComponent();

            // Init
            Classes = classes;
            CompareItems = new List<CompareItem>();
            var ViewBox1 = new MemoryCompareControl()
            {
                Name = "ViewBox1",
                Dock = DockStyle.Fill,
                Memory = new MemoryBuffer() { Process = Program.RemoteProcess }
            };
            var ViewBox2 = new MemoryCompareControl()
            {
                Name = "ViewBox2",
                Dock = DockStyle.Fill,
                Memory = new MemoryBuffer() { Process = Program.RemoteProcess }
            };

            // Events
            ViewBox1.Leave += ViewBox_Leave;
            ViewBox2.Leave += ViewBox_Leave;

            Box1.TextChanged += AddressBox_TextChanged;
            Box2.TextChanged += AddressBox_TextChanged;

            // Add To Panel
            // LayoutPanel.Panel.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent, Width = 50 });
            LayoutPanel.Panel.Controls.Add(ViewBox1, 0, 0);
            LayoutPanel.Panel.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Absolute, Width = 150 });
            LayoutPanel.Panel.Controls.Add(ViewBox2, 1, 0);

            // Fill Info
            ClassBox.Items.AddRange(classes.Select(t => t.Name).ToArray());
            CompareItems.Add(new CompareItem() { AddressBox = Box1, ViewBox = ViewBox1 });
            CompareItems.Add(new CompareItem() { AddressBox = Box2, ViewBox = ViewBox2 });

            // Some Settings
            LayoutPanel.VerticalScroll.Visible = true;
            LayoutPanel.HorizontalScroll.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GlobalWindowManager.AddWindow(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            GlobalWindowManager.RemoveWindow(this);
        }

        private void ClassCompare_Load(object sender, EventArgs e)
        {
            ClassBox.SelectedIndex = 0;
            ViewTypeBox.SelectedIndex = 0;
        }

        private void AddAddressBox_Click(object sender, EventArgs e)
        {
            // Get Some Info
            var lastItem = CompareItems.Last();
            var newLoc = lastItem.AddressBox.Location; newLoc.X += lastItem.AddressBox.Size.Width + 6;
            var klass = Classes.FirstOrDefault(c => c.Name == ClassBox.Text);

            // AddressBox
            var newBox = new PlaceholderTextBox
            {
                Name = $"Box{CompareItems.Count + 1}",
                Location = newLoc,
                PlaceholderText = "Address",
                Font = Box1.Font,
                Text = klass.Offset.ToString("X2")
            };
            newBox.TextChanged += AddressBox_TextChanged;

            // ViewBox
            var viewBox = new MemoryCompareControl()
            {
                Name = $"ViewBox{CompareItems.Count}",
                Dock = DockStyle.Fill,
                Memory = new MemoryBuffer() { Process = Program.RemoteProcess },
                ClassNode = Classes.FirstOrDefault(c => c.Name == ClassBox.Text)
            };
            viewBox.Leave += ViewBox_Leave;

            // Add To List
            CompareItems.Add(new CompareItem() { AddressBox = newBox, ViewBox = viewBox });

            // Add Controls
            addressPanel.Controls.Add(newBox);
            LayoutPanel.Panel.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Absolute, Width = 150 });
            LayoutPanel.Panel.Controls.Add(viewBox, CompareItems.Count - 1, 0);

            // Update ViewBox
            viewBox.Invalidate();
        }

        private void ViewBox_Leave(object sender, EventArgs e)
        {
            if (!(sender is MemoryCompareControl viewBox))
                return;

            // DeSelect
            foreach (var item in viewBox.SelectedNodes)
                item.ClearSelection();
        }

        private void RemoveAddressBox_Click(object sender, EventArgs e)
        {
            // Minmum boxs is 2
            if (CompareItems.Count <= 2) return;

            // Remove AddressBox
            int index = CompareItems.FindIndex(a => a.AddressBox.Name == $"Box{CompareItems.Count}");
            addressPanel.Controls.RemoveAt(index);
            LayoutPanel.Panel.Controls.RemoveAt(index);
            CompareItems.RemoveAt(index);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Contract.Ensures(CompareItems[0].ViewBox != null);

            LayoutPanel.VerticalScroll.LargeChange = CompareItems[0].ViewBox.VerticalScroll.LargeChange;
            LayoutPanel.VerticalScroll.Maximum = CompareItems[0].ViewBox.VerticalScroll.Maximum;
            LayoutPanel.HorizontalScroll.LargeChange = CompareItems[0].ViewBox.HorizontalScroll.LargeChange;
            LayoutPanel.HorizontalScroll.Maximum = CompareItems[0].ViewBox.HorizontalScroll.Maximum;

            var Other = CompareItems.Select(t => t.ViewBox.Memory).ToList();
            foreach (var item in CompareItems.Select(i => i.ViewBox))
            {
                item.OtherMemoryBuffer = Other;
            }
        }

        private void tableLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (var item in LayoutPanel.Panel.Controls.OfType<MemoryCompareControl>().ToArray())
            {
                if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                    item.VerticalScroll.Value = e.NewValue;
                else if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    item.HorizontalScroll.Value = e.NewValue;
            }
        }

        private void ClassBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var klass = Classes.FirstOrDefault(c => c.Name == ClassBox.Text);

            foreach (var item in CompareItems.Select(i => i.AddressBox))
            {
                if (string.IsNullOrWhiteSpace(item.Text))
                    item.Text = klass.Offset.ToString("X2");
            }

            foreach (var item in CompareItems)
            {
                // item.VerticalScroll.Visible = true;
                // item.HorizontalScroll.Visible = true;
                IntPtr newOffset = klass.Offset;
                try { newOffset = new IntPtr(Convert.ToInt32(item.AddressBox.Text, 16)); } catch (Exception) { }
                item.ViewBox.ClassNode = klass;
                item.ViewBox.ClassOffset = newOffset;
                item.ViewBox.Invalidate();
            }
        }

        private void ViewTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in CompareItems.Select(i => i.ViewBox))
            {
                item.ViewType = (MemoryCompareControl.ViewTypes)ViewTypeBox.SelectedIndex;
            }
        }

        private void AddressBox_TextChanged(object sender, EventArgs e)
        {
            if (!(sender is PlaceholderTextBox AddressBox))
                return;

            var ci = CompareItems.Find(c => c.AddressBox.Name == AddressBox.Name);

            var klass = Classes.FirstOrDefault(c => c.Name == ClassBox.Text);
            IntPtr newOffset = klass.Offset;
            try { newOffset = new IntPtr(Convert.ToInt32(ci.AddressBox.Text, 16)); } catch (Exception) { }
            ci.ViewBox.ClassOffset = newOffset;
        }

        private void PointerCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in CompareItems.Select(i => i.ViewBox))
            {
                item.ComparePointer = PointerCheck.Checked;
            }
        }
    }
}
