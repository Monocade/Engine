using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct GamepadButtonEvent
        {
            public SDL.EventType type;
            private uint reserved;
            public ulong timestamp;
            public uint gamepadID;
            public SDL.GamepadButton button;
            public Utils.Bool down;
            private byte padding1;
            private byte padding2;
        }
    }
}