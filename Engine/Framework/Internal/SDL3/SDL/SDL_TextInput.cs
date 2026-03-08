using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Start Text Input
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_StartTextInput(SDL.Window* window);
        public static bool StartTextInput(SDL.Window* window)
        {
            return SDL_StartTextInput(window);
        }
        
        // Stop Text Input
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_StopTextInput(SDL.Window* window);
        public static bool StopTextInput(SDL.Window* window)
        {
            return SDL_StopTextInput(window);
        }
        
        // Has Screen Keyboard Support
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_HasScreenKeyboardSupport();
        public static bool HasScreenKeyboardSupport()
        {
            return SDL_HasScreenKeyboardSupport();
        }
        
        // Screen Keyboard Shown
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_ScreenKeyboardShown(SDL.Window* window);
        public static bool ScreenKeyboardShown(SDL.Window* window)
        {
            return SDL_ScreenKeyboardShown(window);
        }
        
        // Clear Composition
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_ClearComposition(SDL.Window* window);
        public static bool ClearComposition(SDL.Window* window)
        {
            return SDL_ClearComposition(window);
        }
    }
}