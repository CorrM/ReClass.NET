using System.Drawing;
using System.Text;
using ReClassNET.UI;

namespace ReClassNET.Nodes
{
	public class Utf32TextNode : BaseTextNode
	{
		public override Encoding Encoding => Encoding.UTF32;

        public override int MemorySize { set => throw new System.NotImplementedException(); }

        public override Size Draw(ViewInfo view, int x, int y)
		{
			return DrawText(view, x, y, "Text32");
		}

        public override Size DrawCompare(ViewInfo view, int x, int y)
        {
            return DrawTextCompare(view, x, y, "Text32");
        }
    }
}
