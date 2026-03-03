using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [Flags]
        public enum WindowFlags : ulong
        {
            Fullscreen = 0x1,
            OpenGL = 0x2,
            Hidden = 0x08,
            Borderless = 0x10,
            Resizable = 0x20,
            Minimized = 0x40,
            Maximized = 0x080,
            HighPixelDensity = 0x2000,
        }
    }
}