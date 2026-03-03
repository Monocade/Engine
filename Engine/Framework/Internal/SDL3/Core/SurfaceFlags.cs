using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [Flags]
        public enum SurfaceFlags : uint
        {
            Preallocated = 0x1,
            LockRequired = 0x2,
            Locked = 0x4,
            SIMDAligned = 0x08,
        }
    }
}