﻿using System.Drawing;
using System.Globalization;
using ReClassNET.Extensions;
using ReClassNET.Memory;
using ReClassNET.UI;
using ReClassNET.Util;

namespace ReClassNET.Nodes
{
	public class UInt8Node : BaseNumericNode
	{
		public override int MemorySize { get; set; } = 1;

		public override Size Draw(ViewInfo view, int x, int y)
		{
			var value = ReadValueFromMemory(view.Memory);
			return DrawNumeric(view, x, y, Icons.Unsigned, "UInt8", value.ToString(), $"0x{value:X}");
		}

		public override void Update(HotSpot spot)
		{
			base.Update(spot);

			if (spot.Id == 0 || spot.Id == 1)
			{
				if (byte.TryParse(spot.Text, out var val) || spot.Text.TryGetHexString(out var hexValue) && byte.TryParse(hexValue, NumberStyles.HexNumber, null, out val))
				{
					spot.Memory.Process.WriteRemoteMemory(spot.Address, val);
				}
			}
		}

		public byte ReadValueFromMemory(MemoryBuffer memory)
		{
			return memory.ReadUInt8(Offset);
		}
	}
}
