using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Get Base Path
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte* SDL_GetBasePath();
        public static string GetBasePath()
        {
            return SDL.Utf8ToString(SDL_GetBasePath());
        }
    }
}