﻿using System;
using System.Drawing;
using ReClassNET.Memory;
using ReClassNET.UI;

namespace ReClassNET.Nodes
{
	public class ClassPtrArrayNode : BaseArrayNode
	{
		private readonly MemoryBuffer memory = new MemoryBuffer();

		public override int MemorySize { get { return IntPtr.Size * Count; } set { } }

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
			return Draw(view, x, y, "PtrArray", HotSpotType.ChangeType);
		}

        public override Size DrawCompare(ViewInfo view, int x, int y)
        {
            return Draw(view, x, y);
        }

        protected override Size DrawChild(ViewInfo view, int x, int y)
		{
			var ptr = view.Memory.ReadIntPtr(Offset + IntPtr.Size * CurrentIndex);

			memory.Size = InnerNode.MemorySize;
			memory.Process = view.Memory.Process;
			memory.Update(ptr);

			var v = view.Clone();
			v.Address = ptr;
			v.Memory = memory;

			return InnerNode.Draw(v, x, y);
		}
	}
}
