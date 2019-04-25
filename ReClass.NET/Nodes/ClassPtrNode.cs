﻿using System;
using System.Drawing;
using System.Globalization;
using ReClassNET.Extensions;
using ReClassNET.Memory;
using ReClassNET.UI;
using ReClassNET.Util;

namespace ReClassNET.Nodes
{
	public class ClassPtrNode : BaseReferenceNode
	{
		private readonly MemoryBuffer memory = new MemoryBuffer();

		public override int MemorySize { get; set; } = Program.TargetProcessIs64 ? 8 : 4;

		public override bool PerformCycleCheck => false;

        public override void Intialize()
		{
			var node = ClassNode.Create();
			node.Intialize();
			node.AddBytes(64);
			InnerNode = node;
		}

		public override Size Draw(ViewInfo view, int x, int y)
		{
			if (IsHidden)
			{
				return DrawHidden(view, x, y);
			}

			DrawInvalidMemoryIndicator(view, y);

			var origX = x;
			var origY = y;

			AddSelection(view, x, y, view.Font.Height);

			x = AddOpenClose(view, x, y);
			x = AddIcon(view, x, y, Icons.Pointer, -1, HotSpotType.None);

			var tx = x;
			x = AddAddressOffset(view, x, y);

			x = AddText(view, x, y, view.Settings.TypeColor, HotSpot.NoneId, "Ptr") + view.Font.Width;
			x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NameId, Name) + view.Font.Width;
			x = AddText(view, x, y, view.Settings.ValueColor, HotSpot.NoneId, $"<{InnerNode.Name}>") + view.Font.Width;
			x = AddIcon(view, x, y, Icons.Change, 4, HotSpotType.ChangeType) + view.Font.Width;

			var ptr = view.Memory.ReadIntPtr(Offset);

			x = AddText(view, x, y, view.Settings.OffsetColor, HotSpot.NoneId, "->") + view.Font.Width;
			x = AddText(view, x, y, view.Settings.ValueColor, 0, "0x" + ptr.ToString(Constants.AddressHexFormat)) + view.Font.Width;

			x = AddComment(view, x, y);

			AddTypeDrop(view, y);
			AddDelete(view, y);

			y += view.Font.Height;

			var size = new Size(x - origX, y - origY);

			if (levelsOpen[view.Level])
			{
				memory.Size = InnerNode.MemorySize;
				memory.Process = view.Memory.Process;
				memory.Update(ptr);

				var v = view.Clone();
				v.Address = ptr;
				v.Memory = memory;

				var innerSize = InnerNode.Draw(v, tx, y);

				size.Width = Math.Max(size.Width, innerSize.Width + tx - origX);
				size.Height += innerSize.Height;
			}

			return size;
		}

        public override Size DrawCompare(ViewInfo view, int x, int y)
        {
            if (IsHidden)
            {
                return DrawHidden(view, x, y);
            }

            // DrawInvalidMemoryIndicator(view, y);

            var origX = x;
            var origY = y;

            AddSelection(view, x, y, view.Font.Height);

            x = AddOpenClose(view, x, y);
            // x = AddIcon(view, x, y, Icons.Pointer, -1, HotSpotType.None);

            var tx = x;
            x = AddAddressOffset(view, x, y, true, false);

            x = AddText(view, x, y, view.Settings.TypeColor, HotSpot.NoneId, "Ptr") + view.Font.Width;
            x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NameId, Name) + view.Font.Width;
            // x = AddText(view, x, y, view.Settings.ValueColor, HotSpot.NoneId, $"<{InnerNode.Name}>") + view.Font.Width;
            // x = AddIcon(view, x, y, Icons.Change, 4, HotSpotType.ChangeType) + view.Font.Width;

            var ptr = view.Memory.ReadIntPtr(Offset);

            x = AddText(view, x, y, view.Settings.OffsetColor, HotSpot.NoneId, "->") + view.Font.Width;
            x = AddText(view, x, y, view.Settings.ValueColor, 0, "0x" + ptr.ToString(Constants.AddressHexFormat)) + view.Font.Width;

            // x = AddComment(view, x, y);

            // AddTypeDrop(view, y);
            // AddDelete(view, y);

            y += view.Font.Height;

            var size = new Size(x - origX, y - origY);

            if (levelsOpen[view.Level])
            {
                memory.Size = InnerNode.MemorySize;
                memory.Process = view.Memory.Process;
                memory.Update(ptr);

                var v = view.Clone();
                v.Address = ptr;
                v.Memory = memory;

                var innerSize = InnerNode.DrawCompare(v, tx, y);

                size.Width = Math.Max(size.Width, innerSize.Width + tx - origX);
                size.Height += innerSize.Height;
            }

            return size;
        }

        public override int CalculateDrawnHeight(ViewInfo view)
		{
			if (IsHidden)
			{
				return HiddenHeight;
			}

			var height = view.Font.Height;
			if (levelsOpen[view.Level])
			{
				height += InnerNode.CalculateDrawnHeight(view);
			}
			return height;
		}

		public override void Update(HotSpot spot)
		{
			base.Update(spot);

			if (spot.Id == 0)
			{
				if (spot.Text.TryGetHexString(out var hexValue) && long.TryParse(hexValue, NumberStyles.HexNumber, null, out var val))
				{
                    IntPtr address;
                    if (Program.TargetProcessIs64)
                        address = (IntPtr)val;
                    else
                        address = (IntPtr)unchecked((int)val);

                    spot.Memory.Process.WriteRemoteMemory(spot.Address, address);
				}
			}
		}
	}
}
