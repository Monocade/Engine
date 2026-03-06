using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [Flags]
        public enum FontStyle : uint
        {
            Normal        = 0x00,
            Bold          = 0x01,
            Italic        = 0x02,
            Underline     = 0x04,
            Strikethrough = 0x08
        }
    }
}