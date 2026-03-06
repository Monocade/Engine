using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct TextEditingEvent
        {
            public SDL.EventType type;
            private uint reserved;
            public ulong timestamp;
            public uint windowID;
            public byte* text;
            public int start;
            public int length;
        }
    }
}