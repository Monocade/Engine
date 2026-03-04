using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum Presentation
        {
            Disabled = 0,
            Stretched = 1,
            Letterbox = 2,
            Overscan = 3,
            IntScaled = 4,
        }
    }
}