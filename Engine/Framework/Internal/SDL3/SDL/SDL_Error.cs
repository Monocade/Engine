using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Set Error
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetError(byte* fmt);
        public static bool SetError(string error)
        {
            var bytes = Utils.StringToUtf8(error);

            fixed (byte* utf8 = bytes)
            {
                return SDL_SetError(utf8);
            }
        }
        
        // Get Error
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte* SDL_GetError();
        public static string GetError()
        {
            return Utils.Utf8ToString(SDL_GetError());
        }
    }
}