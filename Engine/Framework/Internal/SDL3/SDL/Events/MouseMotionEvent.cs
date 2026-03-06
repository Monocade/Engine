using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseMotionEvent
        {
            public SDL.EventType type;
            private uint reserved;
            public ulong timestamp;
            public uint windowID;
            public uint mouseID;
            private SDL.MouseButton state;
            public float x;
            public float y;
            public float x_relative;
            public float y_relative;
        }
    }
}