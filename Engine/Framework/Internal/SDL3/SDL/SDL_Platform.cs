using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Get Platform
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte* SDL_GetPlatform();
        public static string GetPlatform()
        {
            return Utf8ToString(SDL_GetPlatform());
        }
    }
}