using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct TouchFingerEvent
        {
            public SDL.EventType type;
            private uint reserved;
            public ulong timestamp;
            public ulong touchID;
            public ulong fingerID;
            public float x;
            public float y;
            public float x_delta;
            public float y_delta;
            public float pressure;
            public uint windowID;
        }
    }
}