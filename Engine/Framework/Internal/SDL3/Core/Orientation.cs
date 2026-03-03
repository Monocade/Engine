using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum Orientation
        {
            Unknown = 0,
            Landscape = 1,
            LandscapeFlipped = 2,
            Portrait = 3,
            PortraitFlipped = 4,
        }
    }
}