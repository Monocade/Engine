using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Set Clipboard Text
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetClipboardText(byte* text);
        public static bool SetClipboardText(string text)
        {
            var bytes = Utils.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                return SDL_SetClipboardText(utf8);
            }
        }
        
        // Get Clipboard Text
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte* SDL_GetClipboardText();
        public static string GetClipboardText()
        {
            return Utils.Utf8ToString(SDL_GetClipboardText());
        }
    }
}