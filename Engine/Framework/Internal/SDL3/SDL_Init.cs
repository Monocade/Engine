using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Init
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_Init(SDL.InitFlags flags);
        public static bool Init(SDL.InitFlags flags)
        {
            return SDL_Init(flags);
        }
        
        // Quit
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_Quit();
        public static void Quit()
        {
            SDL_Quit();
        }
    }
}