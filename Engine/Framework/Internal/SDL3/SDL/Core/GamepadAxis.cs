using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum GamepadAxis : byte
        {
            LeftHorizontal = 0,
            LeftVertical = 1,
            RightHorizontal = 2,
            RightVertical = 3,
            LeftTrigger = 4,
            RightTrigger = 5,
        }
    }
}