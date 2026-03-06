using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [Flags]
        public enum MouseButton : uint
        {
            Left = 0x1,
            Middle = 0x2,
            Right = 0x4,
        }
    }
}