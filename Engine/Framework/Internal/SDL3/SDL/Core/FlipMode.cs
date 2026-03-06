using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum FlipMode
        {
            None = 0,
            Horizontal = 1,
            Vertical = 2,
            HorizontalVertical = 3,
        }
    }
}