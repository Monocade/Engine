using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum FontDirection : int
        {
            Invalid = 0,
            LTR     = 4,
            RTL     = 5,
            TTB     = 6,
            BTT     = 7
        }
    }
}