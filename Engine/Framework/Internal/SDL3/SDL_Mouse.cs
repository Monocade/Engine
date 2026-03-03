using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Has Mouse
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_HasMouse();
        public static bool HasMouse()
        {
            return SDL_HasMouse();
        }
        
        // Get Mice
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetMice(out int count);
        public static uint[] GetMice(out int count)
        {
            IntPtr ptr = SDL_GetMice(out count);

            if (ptr == IntPtr.Zero || count == 0)
                return Array.Empty<uint>();

            uint[] ids = new uint[count];
            Marshal.Copy(ptr, (int[])(object)ids, 0, count);
            SDL_free(ptr);
            return ids;
        }
        
        // Show Cursor
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_ShowCursor();
        public static bool ShowCursor()
        {
            return SDL_ShowCursor();
        }
        
        // Hide Cursor
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_HideCursor();
        public static bool HideCursor()
        {
            return SDL_HideCursor();
        }
    }
}