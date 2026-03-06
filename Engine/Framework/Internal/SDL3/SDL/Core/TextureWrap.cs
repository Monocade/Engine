using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum TextureWrap
        {
            Auto = 0,
            Clamp = 1,
            Wrap = 2,
        }
    }
}