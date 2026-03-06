using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Texture
        {
            public SDL.PixelFormat format;
            public int w;
            public int h;
            private int refcount;
        }
    }
}