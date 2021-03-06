﻿using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace ReClassNET.Extensions
{
	public static class BinaryReaderWriterExtension
	{
		public static IntPtr ReadIntPtr(this BinaryReader br)
		{
			Contract.Requires(br != null);
            if (Program.RemoteProcess.Is64)
                return (IntPtr)br.ReadInt64();
            else
                return (IntPtr)br.ReadInt32();
		}

		public static void Write(this BinaryWriter bw, IntPtr value)
		{
			Contract.Requires(bw != null);

            if (Program.RemoteProcess.Is64)
                bw.Write(value.ToInt64());
            else
                bw.Write(value.ToInt32());
		}
	}
}
