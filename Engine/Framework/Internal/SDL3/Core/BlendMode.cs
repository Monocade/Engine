using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [Flags]
        public enum BlendMode : uint
        {
            NONE = 0x00000000u, // no blending
            BLEND = 0x00000001u, // alpha blending
            BLEND_PREMULTIPLIED = 0x00000010u, // premultiplied alpha blending
            ADD = 0x00000002u, // additive blending
            ADD_PREMULTIPLIED = 0x00000020u, // premultiplied additive blending
            MOD = 0x00000004u, // color modulate
            MUL = 0x00000008u, // color multiply
            INVALID = 0x7FFFFFFFu
        }
    }
}