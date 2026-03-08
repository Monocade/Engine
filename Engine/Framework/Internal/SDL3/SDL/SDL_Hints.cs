using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Set Hint
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetHint(byte* name, byte* value);
        public static bool SetHint(string name, string value)
        {
            var nameBytes = Utils.StringToUtf8(name);
            var valueBytes = Utils.StringToUtf8(value);

            fixed (byte* nameUtf8 = nameBytes)
            fixed (byte* valueUtf8 = valueBytes)
            {
                return SDL_SetHint(nameUtf8, valueUtf8);
            }
        }
        
        // Get Hint
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte* SDL_GetHint(byte* name);
        public static string GetHint(string name)
        {
            var nameBytes = Utils.StringToUtf8(name);

            fixed (byte* nameUtf8 = nameBytes)
            {
                return Utils.Utf8ToString(SDL_GetHint(nameUtf8));
            }
        }
    }
}