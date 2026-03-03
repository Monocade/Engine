using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Create Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* SDL_CreateSurface(int width, int height, SDL.PixelFormat format);
        public static SDL.Surface* CreateSurface(int width, int height, SDL.PixelFormat format)
        {
            return SDL_CreateSurface(width, height, format);
        }
        
        // Destroy Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_DestroySurface(SDL.Surface* surface);
        public static void DestroySurface(SDL.Surface* surface)
        {
            SDL_DestroySurface(surface);
        }
        
        // Lock Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_LockSurface(SDL.Surface* surface);
        public static bool LockSurface(SDL.Surface* surface)
        {
            return SDL_LockSurface(surface);
        }
        
        // Unlock Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_UnlockSurface(SDL.Surface* surface);
        public static void UnlockSurface(SDL.Surface* surface)
        {
            SDL_UnlockSurface(surface);
        }
        
        // Flip Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_FlipSurface(SDL.Surface* surface, SDL.FlipMode mode);
        public static bool FlipSurface(SDL.Surface* surface, SDL.FlipMode mode)
        {
            return SDL_FlipSurface(surface, mode);
        }
        
        // Rotate Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* SDL_RotateSurface(SDL.Surface* surface, float angle);
        public static SDL.Surface* RotateSurface(SDL.Surface* surface, float angle)
        {
            return SDL_RotateSurface(surface, angle);
        }
        
        // Duplicate Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* SDL_DuplicateSurface(SDL.Surface* surface);
        public static SDL.Surface* DuplicateSurface(SDL.Surface* surface)
        {
            return SDL_DuplicateSurface(surface);
        }
        
        // Scale Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* SDL_ScaleSurface(SDL.Surface* surface, int width, int height, SDL.ScaleMode mode);
        public static SDL.Surface* ScaleSurface(SDL.Surface* surface, int width, int height, SDL.ScaleMode mode)
        {
            return SDL_ScaleSurface(surface, width, height, mode);
        }
        
        // Clear Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_ClearSurface(SDL.Surface* surface, float r, float g, float b, float a);
        public static bool ClearSurface(SDL.Surface* surface, float r, float g, float b, float a)
        {
            return SDL_ClearSurface(surface, r, g, b, a);
        }
        
        // Convert Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* SDL_ConvertSurface(SDL.Surface* surface, SDL.PixelFormat format);
        public static SDL.Surface* ConvertSurface(SDL.Surface* surface, SDL.PixelFormat format)
        {
            return SDL_ConvertSurface(surface, format);
        }
    }
}