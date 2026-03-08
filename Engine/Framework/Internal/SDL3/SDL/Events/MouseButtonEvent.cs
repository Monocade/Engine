using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseButtonEvent
        {
            public SDL.EventType type;
            private uint reserved;
            public ulong timestamp;
            public uint windowID;
            public uint mouseID;
            public byte button;
            public Utils.Bool down;
            private byte clicks;
            private byte padding;
            public float x;
            public float y;
        }
    }
}