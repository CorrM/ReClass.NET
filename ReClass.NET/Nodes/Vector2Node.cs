using System.Drawing;
using System.Runtime.InteropServices;
using ReClassNET.UI;

namespace ReClassNET.Nodes
{
	public class Vector2Node : BaseMatrixNode
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct Vector2Data
		{
			[FieldOffset(0)]
			public readonly float X;
			[FieldOffset(4)]
			public readonly float Y;
		}

		public override int ValueTypeSize => sizeof(float);

		public override int MemorySize { get { return 2 * ValueTypeSize; } set { } }

		/// <summary>Draws this node.</summary>
		/// <param name="view">The view information.</param>
		/// <param name="x2">The x coordinate.</param>
		/// <param name="y2">The y coordinate.</param>
		/// <returns>The pixel size the node occupies.</returns>
		public override Size Draw(ViewInfo view, int x2, int y2)
		{
			return DrawVectorType(view, x2, y2, "Vector2", (ref int x, ref int y) =>
			{
				var value = view.Memory.ReadObject<Vector2Data>(Offset);

				x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NoneId, "(");
				x = AddText(view, x, y, view.Settings.ValueColor, 0, $"{value.X:0.000}");
				x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, view.Settings.ValueColor, 1, $"{value.Y:0.000}");
				x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NoneId, ")");
			});
		}

        public override Size DrawCompare(ViewInfo view, int x2, int y2)
        {
            return DrawVectorTypeCompare(view, x2, y2, "Vector2", (ref int x, ref int y) =>
            {
                var value = view.Memory.ReadObject<Vector2Data>(Offset);

                x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NoneId, "(");
                x = AddText(view, x, y, view.Settings.ValueColor, 0, $"{value.X:0.000}");
                x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NoneId, ",");
                x = AddText(view, x, y, view.Settings.ValueColor, 1, $"{value.Y:0.000}");
                x = AddText(view, x, y, view.Settings.NameColor, HotSpot.NoneId, ")");
            });
        }

        protected override int CalculateValuesHeight(ViewInfo view)
		{
			return 0;
		}

		public override void Update(HotSpot spot)
		{
			base.Update(spot);

			Update(spot, 2);
		}
	}
}
