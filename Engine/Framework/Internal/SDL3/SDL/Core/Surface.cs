using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Surface
        {
            public SDL.SurfaceFlags flags;
            public SDL.PixelFormat format;
            public int w;
            public int h;
            public int pitch;
            public IntPtr pixels;
            private int refcount;
            private IntPtr reserved;
        }
    }
}