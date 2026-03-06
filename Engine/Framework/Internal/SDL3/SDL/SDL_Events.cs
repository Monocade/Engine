using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Poll Event
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_PollEvent(out SDL.Event e);
        public static bool PollEvent(out SDL.Event e)
        {
            return SDL_PollEvent(out e);
        }
    
        // Push Event
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_PushEvent(SDL.Event* e);
        public static bool PushEvent(SDL.Event e)
        {
            return SDL_PushEvent(&e);
        }
    
        // Has Event
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_HasEvent(SDL.EventType e);
        public static bool HasEvent(SDL.EventType e)
        {
            return SDL_HasEvent(e);
        }
    }
}