using System.Drawing;
using ReClassNET.Extensions;
using ReClassNET.UI;
using ReClassNET.Util;

namespace ReClassNET.Nodes
{
	public class ClassInstanceArrayNode : BaseArrayNode
	{
		/// <summary>Size of the node in bytes.</summary>
		public override int MemorySize { get { return InnerNode.MemorySize * Count; } set { } } 

		public override bool PerformCycleCheck => true;

		public override void Intialize()
		{
			InnerNode = ClassNode.Create();
			InnerNode.Intialize();
		}

		/// <summary>Draws this node.</summary>
		/// <param name="view">The view information.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <returns>The pixel size the node occupies.</returns>
		public override Size Draw(ViewInfo view, int x, int y)
		{
			return Draw(view, x, y, "Array", HotSpotType.ChangeType);
		}

        public override Size DrawCompare(ViewInfo view, int x, int y)
        {
            return Draw(view, x, y);
        }

        protected override Size DrawChild(ViewInfo view, int x, int y)
		{
			var v = view.Clone();
			v.Address = view.Address.Add(Offset) + InnerNode.MemorySize * CurrentIndex;
			v.Memory = view.Memory.Clone();
			v.Memory.Offset += Offset.ToInt32() + InnerNode.MemorySize * CurrentIndex;

			return InnerNode.Draw(v, x, y);
		}
	}
}
