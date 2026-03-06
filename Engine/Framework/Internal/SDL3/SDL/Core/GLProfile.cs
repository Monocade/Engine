using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [Flags]
        public enum GLProfile : uint
        {
            Core = 0x0001,
            Compatibility = 0x0002,
            ES = 0x0004,
        }
    }
}