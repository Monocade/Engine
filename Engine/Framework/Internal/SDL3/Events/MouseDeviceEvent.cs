using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseDeviceEvent
        {
            public SDL.EventType type;
            private uint reserved;
            public ulong timestamp;
            public uint mouseID;
        }
    }
}