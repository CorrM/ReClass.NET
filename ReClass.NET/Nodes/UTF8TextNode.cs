using System.Drawing;
using System.Text;
using ReClassNET.UI;

namespace ReClassNET.Nodes
{
	public class Utf8TextNode : BaseTextNode
	{
		public override Encoding Encoding => Encoding.UTF8;

        public override int MemorySize { set => throw new System.NotImplementedException(); }

        public override Size Draw(ViewInfo view, int x, int y)
		{
			return DrawText(view, x, y, "Text8");
		}

        public override Size DrawCompare(ViewInfo view, int x, int y)
        {
            return Draw(view, x, y);
        }
    }
}
