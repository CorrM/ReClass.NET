using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReClassNET.DataExchange.ReClass;
using ReClassNET.Extensions;
using ReClassNET.Forms;
using ReClassNET.Memory;
using ReClassNET.MemoryScanner;
using ReClassNET.MemoryScanner.Comparer;
using ReClassNET.Nodes;
using ReClassNET.Util;

namespace ReClassNET.UI
{
	public partial class MemoryCompareControl : ScrollableCustomControl
	{
        public enum ViewTypes
        {
            NotMatter,
            Matches,
            NotMatches
        }

		private ReClassNetProject project;
        private KeyBoardManager keyBoard;
        private ClassNode classNode;

		private readonly List<HotSpot> hotSpots = new List<HotSpot>();
		private readonly List<HotSpot> selectedNodes = new List<HotSpot>();

		private HotSpot selectionCaret;
		private HotSpot selectionAnchor;

		private readonly FontEx font;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ReClassNetProject Project
		{
			get => project;
			set
			{
				Contract.Requires(value != null);

				project = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ClassNode ClassNode
		{
			get => classNode;
			set
			{
                ClearSelection();

				OnSelectionChanged();

				classNode = value;

                VerticalScroll.Value = 0;
				if (classNode != null && Memory?.Process != null)
				{
					classNode.UpdateAddress(Memory.Process);
				}

                Invalidate();
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public MemoryBuffer Memory { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewTypes ViewType { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<MemoryBuffer> OtherMemoryBuffer { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr ClassOffset;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CompareOptions ShowOptions;

        public IEnumerable<BaseNode> SelectedNodes => selectedNodes.Select(s => s.Node);
		public event EventHandler SelectionChanged;

		/// <summary>The context menu of a node.</summary>
		public ContextMenuStrip NodeContextMenu => selectedNodeContextMenuStrip;

		private readonly MemoryPreviewPopUp memoryPreviewPopUp;

		public MemoryCompareControl()
		{
			InitializeComponent();

            if (Program.DesignMode)
				return;

            font = Program.MonoSpaceFont;
			memoryPreviewPopUp = new MemoryPreviewPopUp(font);
            keyBoard = new KeyBoardManager();
        }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			VerticalScroll.Enabled = true;
			VerticalScroll.Visible = false;
			VerticalScroll.SmallChange = 10;
			HorizontalScroll.Enabled = true;
			HorizontalScroll.Visible = false;
			HorizontalScroll.SmallChange = 100;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (DesignMode)
			{
				e.Graphics.FillRectangle(Brushes.White, ClientRectangle);
				return;
			}

			hotSpots.Clear();

			using (var brush = new SolidBrush(Program.Settings.BackgroundColor))
			{
				e.Graphics.FillRectangle(brush, ClientRectangle);
			}

			if (ClassNode == null)
			{
				return;
			}

			if (Memory.Process != null)
			{
				ClassNode.UpdateAddress(Memory.Process);
			}

			if (memoryPreviewPopUp.Visible)
			{
				memoryPreviewPopUp.UpdateMemory();
			}

			Memory.Size = ClassNode.MemorySize;
			Memory.Update(ClassOffset == IntPtr.Zero ? ClassNode.Offset : ClassOffset);

			BaseHexNode.CurrentHighlightTime = DateTime.Now;

            var view = new ViewInfo
            {
                Settings = Program.Settings,
                Context = e.Graphics,
                Font = font,
                Address = ClassNode.Offset,
                ClientArea = ClientRectangle,
                Level = 0,
                Memory = Memory,
                MultipleNodesSelected = selectedNodes.Count > 1,
                HotSpots = hotSpots,
                Tag = ViewType,
                Tag2 = OtherMemoryBuffer,
                ShowOptions = ShowOptions
            };

			try
			{
				var drawnSize = ClassNode.DrawCompare(view, -HorizontalScroll.Value, -VerticalScroll.Value * font.Height);
				drawnSize.Width += 50;

				/*foreach (var spot in hotSpots.Where(h => h.Type == HotSpotType.Select))
				{
					e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(150, 255, 0, 0)), 1), spot.Rect);
				}*/

				if (drawnSize.Height > ClientSize.Height)
				{
					VerticalScroll.Enabled = true;

					VerticalScroll.LargeChange = ClientSize.Height / font.Height;
					VerticalScroll.Maximum = (drawnSize.Height - ClientSize.Height) / font.Height + VerticalScroll.LargeChange;
				}
				else
				{
					VerticalScroll.Enabled = false;
					VerticalScroll.Value = 0;
				}

				if (drawnSize.Width > ClientSize.Width)
				{
					HorizontalScroll.Enabled = true;

					HorizontalScroll.LargeChange = ClientSize.Width;
					HorizontalScroll.Maximum = drawnSize.Width - ClientSize.Width + HorizontalScroll.LargeChange;
				}
				else
				{
					HorizontalScroll.Enabled = false;
					HorizontalScroll.Value = 0;
				}
			}
			catch (Exception ex)
			{
				Debug.Assert(false);
			}
		}

		private void OnSelectionChanged()
		{
			SelectionChanged?.Invoke(this, EventArgs.Empty);
		}

		#region Process Input
		protected override void OnMouseClick(MouseEventArgs e)
		{
			Contract.Requires(e != null);
			bool invalidate = false;

			foreach (var hotSpot in hotSpots)
			{
				if (hotSpot.Rect.Contains(e.Location))
				{
					try
					{
						var hitObject = hotSpot.Node;

						if (hotSpot.Type == HotSpotType.OpenClose)
						{
							hitObject.ToggleLevelOpen(hotSpot.Level);

							invalidate = true;

							break;
						}
						if (hotSpot.Type == HotSpotType.Click)
						{
							hitObject.Update(hotSpot);

							invalidate = true;

							break;
						}
						if (hotSpot.Type == HotSpotType.Select)
						{
							if (e.Button == MouseButtons.Left)
							{
								if (ModifierKeys == Keys.None)
								{
									ClearSelection();

									hitObject.IsSelected = true;

									selectedNodes.Add(hotSpot);

									OnSelectionChanged();

									selectionAnchor = selectionCaret = hotSpot;
								}
								else if (ModifierKeys == Keys.Control)
								{
									hitObject.IsSelected = !hitObject.IsSelected;

									if (hitObject.IsSelected)
									{
										selectedNodes.Add(hotSpot);
									}
									else
									{
										selectedNodes.Remove(selectedNodes.FirstOrDefault(c => c.Node == hitObject));
									}

									OnSelectionChanged();
								}
								else if (ModifierKeys == Keys.Shift)
								{
									if (selectedNodes.Count > 0)
									{
										var selectedNode = selectedNodes[0].Node;
										if (hitObject.ParentNode != null && selectedNode.ParentNode != hitObject.ParentNode)
										{
											continue;
										}

										if (hotSpot.Node is BaseContainerNode)
										{
											continue;
										}

										var first = Utils.Min(selectedNodes[0], hotSpot, h => h.Node.Offset.ToInt32());
										var last = first == hotSpot ? selectedNodes[0] : hotSpot;

										ClearSelection();

										var containerNode = selectedNode.ParentNode;
										foreach (var spot in containerNode.Nodes
											.SkipWhile(n => n != first.Node)
											.TakeUntil(n => n == last.Node)
											.Select(n => new HotSpot
											{
												Address = containerNode.Offset.Add(n.Offset),
												Node = n,
												Memory = first.Memory,
												Level = first.Level
											}))
										{
											spot.Node.IsSelected = true;
											selectedNodes.Add(spot);
										}

										OnSelectionChanged();

										selectionAnchor = first;
										selectionCaret = last;
									}
								}
							}
							else if (e.Button == MouseButtons.Right)
							{
								// If there is only one selected node, select the node the user clicked at.
								if (selectedNodes.Count <= 1)
								{
									ClearSelection();

									hitObject.IsSelected = true;

									selectedNodes.Add(hotSpot);

									OnSelectionChanged();

									selectionAnchor = selectionCaret = hotSpot;
								}

								selectedNodeContextMenuStrip.Show(this, e.Location);
							}

							invalidate = true;
						}
						else if (hotSpot.Type == HotSpotType.Drop)
						{
							selectedNodeContextMenuStrip.Show(this, e.Location);

							break;
						}
					}
					catch (Exception ex)
					{
						Program.Logger.Log(ex);
					}
				}
			}

			if (invalidate)
			{
				Invalidate();
			}

			base.OnMouseClick(e);
		}

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			Contract.Requires(e != null);
			base.OnMouseDoubleClick(e);

			BaseNode toggleNode = null;
			var level = 0;

			foreach (var hotSpot in hotSpots.Where(h => h.Type == HotSpotType.Edit || h.Type ==  HotSpotType.Select))
			{
				if (hotSpot.Rect.Contains(e.Location))
				{
					if (hotSpot.Type == HotSpotType.Edit)
					{
						return;
					}

					if (hotSpot.Type == HotSpotType.Select)
					{
						toggleNode = hotSpot.Node;
						level = hotSpot.Level;
					}
				}
			}

			if (toggleNode != null)
			{
				toggleNode.ToggleLevelOpen(level);

				Invalidate();
			}
		}

		private Point toolTipPosition;
		protected override void OnMouseHover(EventArgs e)
		{
			Contract.Requires(e != null);

			base.OnMouseHover(e);

			if (selectedNodes.Count > 1)
			{
				var memorySize = selectedNodes.Sum(h => h.Node.MemorySize);
				nodeInfoToolTip.Show($"{selectedNodes.Count} Nodes selected, {memorySize} bytes", this, toolTipPosition.OffsetEx(16, 16));
			}
			else
			{
				foreach (var spot in hotSpots.Where(h => h.Type == HotSpotType.Select))
				{
					if (spot.Rect.Contains(toolTipPosition))
					{
						if (spot.Node.UseMemoryPreviewToolTip(spot, spot.Memory, out var previewAddress) &&
                            keyBoard.input.InputDeviceState.IsKeyDown(WindowsInput.Native.VirtualKeyCode.CONTROL)) // Control Key IsDown
						{
							memoryPreviewPopUp.InitializeMemory(spot.Memory.Process, previewAddress);
							memoryPreviewPopUp.Show(this, toolTipPosition.OffsetEx(16, 16));
						}
						else
						{
							var text = spot.Node.GetToolTipText(spot, spot.Memory);
							if (!string.IsNullOrEmpty(text))
							{
								nodeInfoToolTip.Show(text, this, toolTipPosition.OffsetEx(16, 16));
							}
						}

						return;
					}
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			Contract.Requires(e != null);

			base.OnMouseMove(e);

			if (e.Location != toolTipPosition)
			{
				toolTipPosition = e.Location;

				nodeInfoToolTip.Hide(this);

				if (memoryPreviewPopUp.Visible)
				{
					memoryPreviewPopUp.Close();

					Invalidate();
				}

				ResetMouseEventArgs();
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (memoryPreviewPopUp.Visible)
			{
				memoryPreviewPopUp.HandleMouseWheelEvent(e);
			}
			else
			{
				// base.OnMouseWheel(e);
			}
		}

		protected override void OnScroll(ScrollEventArgs e)
		{
			Contract.Requires(e != null);
			base.OnScroll(e);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			return base.ProcessCmdKey(ref msg, keyData);
		}
		#endregion

		#region Event Handler
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			Invalidate();
		}

		private void repaintTimer_Tick(object sender, EventArgs e)
		{
			if (DesignMode)
			{
				return;
			}

			Invalidate(false);
		}

		private void selectedNodeContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			var count = selectedNodes.Count;
			var node = selectedNodes.Select(s => s.Node).FirstOrDefault();
			var parentNode = node?.ParentNode;

			var nodeIsClass = node is ClassNode;
			var nodeIsValueNode = false;
        }
		#endregion

		/// <summary>Groups the selected nodes in blocks if the nodes are continues.</summary>
		/// <param name="selection">The selection to partition.</param>
		/// <returns>An enumeration with blocks of continues nodes.</returns>
		private static IEnumerable<List<HotSpot>> PartitionSelectedNodes(IEnumerable<HotSpot> selection)
		{
			Contract.Requires(selection != null);

			List<HotSpot> partition;
			using (var it = selection.GetEnumerator())
			{
				if (!it.MoveNext())
				{
					yield break;
				}

				partition = new List<HotSpot> { it.Current };

				var last = it.Current;

				while (it.MoveNext())
				{
					if (it.Current.Address != last.Address + last.Node.MemorySize)
					{
						yield return partition;

						partition = new List<HotSpot>();
					}

					partition.Add(it.Current);

					last = it.Current;
				}
			}

			if (partition.Count != 0)
			{
				yield return partition;
			}
		}

		/// <summary>Recursive replace all splitted nodes.</summary>
		/// <param name="parentNode">The parent node.</param>
		/// <param name="type">The node type.</param>
		/// <param name="nodesToReplace">The nodes to replace.</param>
		/// <returns>The new nodes.</returns>
		private static IEnumerable<BaseNode> RecursiveReplaceNodes(BaseContainerNode parentNode, Type type, IEnumerable<BaseNode> nodesToReplace)
		{
			Contract.Requires(parentNode != null);
			Contract.Requires(type != null);
			Contract.Requires(nodesToReplace != null);
			Contract.Ensures(Contract.Result<IEnumerable<BaseNode>>() != null);

			foreach (var nodeToReplace in nodesToReplace)
			{
				var temp = new List<BaseNode>();
				if (parentNode.ReplaceChildNode(nodeToReplace, type, ref temp))
				{
					var node = temp.First();

					node.IsSelected = true;

					yield return node;

					if (temp.Count > 1)
					{
						foreach (var n in RecursiveReplaceNodes(parentNode, type, temp.Skip(1)))
						{
							yield return n;
						}
					}
				}
			}
		}

		private void ClearSelection()
		{
			selectedNodes.ForEach(h => h.Node.ClearSelection());

			selectedNodes.Clear();
		}

		private void RemoveSelectedNodes()
		{
			selectedNodes.WhereNot(h => h.Node is ClassNode).ForEach(h => h.Node.ParentNode.RemoveNode(h.Node));

			selectedNodes.Clear();

			OnSelectionChanged();

			Invalidate();
		}

		private bool IsCycleFree(ClassNode parent, ClassNode node)
		{
			if (!ClassUtil.IsCycleFree(parent, node, project.Classes))
			{
				MessageBox.Show("Invalid operation because this would create a class cycle.", "Cycle Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}

			return true;
		}
    }
}
