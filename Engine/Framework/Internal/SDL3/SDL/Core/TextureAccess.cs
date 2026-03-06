using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum TextureAccess
        {
            Static = 0,
            Streaming = 1,
            Target = 2,
        }
    }
}