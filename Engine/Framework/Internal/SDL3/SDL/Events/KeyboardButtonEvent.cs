using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardButtonEvent
        {
            public SDL.EventType type;
            private uint reserved;
            public ulong timestamp;
            public uint windowID;
            public uint keyboardID;
            public SDL.ScanCode scanCode;
            public SDL.KeyCode keyCode;
            public SDL.KeyModifier keyModifier;
            private ushort raw;
            public Utils.Bool down;
            public Utils.Bool repeat;
        }
    }
}