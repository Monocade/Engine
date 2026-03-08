using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Open URL
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_OpenURL(byte* url);
        public static bool OpenURL(string url)
        {
            var bytes = Utils.StringToUtf8(url);

            fixed (byte* utf8 = bytes)
            {
                return SDL_OpenURL(utf8);
            }
        }
    }
}