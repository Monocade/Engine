using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum ScaleMode
        {
            Invalid = -1,
            Nearest = 0,
            Linear = 1,
            Pixel = 2,
        }
    }
}