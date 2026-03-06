using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseWheelEvent
        {
            public SDL.EventType type;
            private uint reserved;
            public ulong timestamp;
            public uint windowID;
            public uint mouseID;
            public float x;
            public float y;
            public SDL.MouseWheel direction;
            public float x_mouse;
            public float y_mouse;
            public int x_integer;
            public int y_integer;
        }
    }
}