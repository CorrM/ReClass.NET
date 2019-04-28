﻿using System.Diagnostics.Contracts;
using System.Drawing;
using System.Text;
using ReClassNET.Extensions;
using ReClassNET.Memory;
using ReClassNET.UI;
using ReClassNET.Util;

namespace ReClassNET.Nodes
{
	public abstract class BaseTextNode : BaseNode
	{
		public int Length { get; set; }

		/// <summary>Size of the node in bytes.</summary>
		public override int MemorySize => Length * CharacterSize;

		/// <summary>The encoding of the string.</summary>
		public abstract Encoding Encoding { get; }

		/// <summary>Size of one character in bytes.</summary>
		private int CharacterSize => Encoding.GetSimpleByteCountPerChar();

		public override void CopyFromNode(BaseNode node)
		{
			Length = node.MemorySize / CharacterSize;
		}

		protected Size DrawText(ViewInfo view, int x, int y, string type)
		{
			Contract.Requires(view != null);
			Contract.Requires(type != null);

			if (IsHidden)
			{
				return DrawHidden(view, x, y);
			}

			var length = MemorySize / CharacterSize;
			var text = ReadValueFromMemory(view.Memory);

			DrawInvalidMemoryIndicator(view, y);

			var origX = x;

			AddSelection(view, x, y, view.Font.Height);

			x += TextPadding;
			x = AddIcon(view, x, y, Icons.Text, HotSpot.NoneId, HotSpotType.None);
			x = AddAddressOffset(view, x, y);

			x = AddText(view, x, y, view.Settings.TypeColor, HotSpot.NoneId, type) + view.Font.Width;
			x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NameId, Name);
			x = AddText(view, x, y, view.Settings.IndexColor, HotSpot.NoneId, "[");
			x = AddText(view, x, y, view.Settings.IndexColor, 0, length.ToString());
			x = AddText(view, x, y, view.Settings.IndexColor, HotSpot.NoneId, "]") + view.Font.Width;

			x = AddText(view, x, y, view.Settings.TextColor, HotSpot.NoneId, "= '");
			x = AddText(view, x, y, view.Settings.TextColor, 1, text.LimitLength(150));
			x = AddText(view, x, y, view.Settings.TextColor, HotSpot.NoneId, "'") + view.Font.Width;

			x = AddComment(view, x, y);

			AddTypeDrop(view, y);
			AddDelete(view, y);

			return new Size(x - origX, view.Font.Height);
		}

        protected Size DrawTextCompare(ViewInfo view, int x, int y, string type)
        {
            Contract.Requires(view != null);
            Contract.Requires(type != null);

            if (IsHidden && !view.ShowOptions.ShowHidden)
            {
                return DrawHidden(view, x, y);
            }

            var length = MemorySize / CharacterSize;
            var text = ReadValueFromMemory(view.Memory);

            // DrawInvalidMemoryIndicator(view, y);

            var origX = x;

            AddSelection(view, x, y, view.Font.Height);

            x += TextPadding;
            // x = AddIcon(view, x, y, Icons.Text, HotSpot.NoneId, HotSpotType.None);
            x = AddAddressOffset(view, x, y, true, false);

            x = AddText(view, x, y, view.Settings.TypeColor, HotSpot.NoneId, type) + view.Font.Width;
            x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NameId, Name);
            x = AddText(view, x, y, view.Settings.IndexColor, HotSpot.NoneId, "[");
            x = AddText(view, x, y, view.Settings.IndexColor, 0, length.ToString());
            x = AddText(view, x, y, view.Settings.IndexColor, HotSpot.NoneId, "]") + view.Font.Width;

            x = AddText(view, x, y, view.Settings.TextColor, HotSpot.NoneId, "= '");
            x = AddText(view, x, y, view.Settings.TextColor, 1, text.LimitLength(150));
            x = AddText(view, x, y, view.Settings.TextColor, HotSpot.NoneId, "'") + view.Font.Width;

            // x = AddComment(view, x, y);

            // AddTypeDrop(view, y);
            // AddDelete(view, y);

            return new Size(x - origX, view.Font.Height);
        }


        public override int CalculateDrawnHeight(ViewInfo view)
		{
			return IsHidden && !view.ShowOptions.ShowHidden ? HiddenHeight : view.Font.Height;
		}

		public override void Update(HotSpot spot)
		{
			base.Update(spot);

			if (spot.Id == 0)
			{
				if (int.TryParse(spot.Text, out var val) && val > 0)
				{
					Length = val;

					ParentNode.ChildHasChanged(this);
				}
			}
		}

		public string ReadValueFromMemory(MemoryBuffer memory)
		{
			return memory.ReadString(Encoding, Offset, MemorySize);
		}
	}
}
