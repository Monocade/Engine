using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum AppResult
        {
            Continue = 0,
            Success = 1,
            Failed = 2,
        }
    }
}