using System.Drawing;
using System.Text;
using ReClassNET.UI;

namespace ReClassNET.Nodes
{
	public class Utf16TextNode : BaseTextNode
	{
		public override Encoding Encoding => Encoding.Unicode;

        public override int MemorySize { set => throw new System.NotImplementedException(); }

        public override Size Draw(ViewInfo view, int x, int y)
		{
			return DrawText(view, x, y, "Text16");
		}
	}
}
