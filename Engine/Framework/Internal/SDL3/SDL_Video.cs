using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Create Window
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Window* SDL_CreateWindow(byte* title, int w, int h, SDL.WindowFlags flags);
        public static SDL.Window* CreateWindow(string title, int w, int h, SDL.WindowFlags flags)
        {
            var bytes = SDL.StringToUtf8(title);

            fixed (byte* utf8 = bytes)
            {
                return SDL_CreateWindow(utf8, w, h, flags);
            }
        }
        
        // Destroy Window
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_DestroyWindow(SDL.Window* window);
        public static void DestroyWindow(SDL.Window* window)
        {
            SDL_DestroyWindow(window);
        }
        
        // Get Window ID
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint SDL_GetWindowID(SDL.Window* window);
        public static uint GetWindowID(SDL.Window* window)
        {
            return SDL_GetWindowID(window);
        }
        
        // Get Window From ID
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Window* SDL_GetWindowFromID(uint windowID);
        public static SDL.Window* GetWindowFromID(uint windowID)
        {
            return SDL_GetWindowFromID(windowID);
        }
        
        // Set Window Icon
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowIcon(SDL.Window* window, SDL.Surface* surface);
        public static bool SetWindowIcon(SDL.Window* window, SDL.Surface* surface)
        {
            return SDL_SetWindowIcon(window, surface);
        }
        
        // Get Window Flags
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.WindowFlags SDL_GetWindowFlags(SDL.Window* window);
        public static SDL.WindowFlags GetWindowFlags(SDL.Window* window)
        {
            return SDL_GetWindowFlags(window);
        }
        
        // Get Window Safe Area
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GetWindowSafeArea(SDL.Window* window, out SDL.Rect rect);
        public static bool GetWindowSafeArea(SDL.Window* window, out SDL.Rect rect)
        {
            return SDL_GetWindowSafeArea(window, out rect);
        }
        
        // Get Window Size In Pixels
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GetWindowSizeInPixels(SDL.Window* window, out int w, out int h);
        public static bool GetWindowSizeInPixels(SDL.Window* window, out int w, out int h)
        {
            return SDL_GetWindowSizeInPixels(window, out w, out h);
        }
        
        // Get Window Borders Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GetWindowBordersSize(SDL.Window* window, out int top, out int left, out int bottom, out int right);
        public static bool GetWindowBordersSize(SDL.Window* window, out int top, out int left, out int bottom, out int right)
        {
            return SDL_GetWindowBordersSize(window, out top, out left, out bottom, out right);
        }
        
        // Get Window Pixel Density
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern float SDL_GetWindowPixelDensity(SDL.Window* window);
        public static float GetWindowPixelDensity(SDL.Window* window)
        {
            return SDL_GetWindowPixelDensity(window);
        }

        // Get Window Display Scale
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern float SDL_GetWindowDisplayScale(SDL.Window* window);
        public static float GetWindowDisplayScale(SDL.Window* window)
        {
            return SDL_GetWindowDisplayScale(window);
        }
        
        // Set Window Title
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowTitle(SDL.Window* window, byte* title);
        public static bool SetWindowTitle(SDL.Window* window, string title)
        {
            var bytes = SDL.StringToUtf8(title);

            fixed (byte* utf8 = bytes)
            {
                return SDL_SetWindowTitle(window, utf8);
            }
        }
        
        // Get Window Title
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte* SDL_GetWindowTitle(SDL.Window* window);
        public static string GetWindowTitle(SDL.Window* window)
        {
            return SDL.Utf8ToString(SDL_GetWindowTitle(window));
        }
        
        // Set Window Position
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowPosition(SDL.Window* window, int x, int y);
        public static bool SetWindowPosition(SDL.Window* window, int x, int y)
        {
            return SDL_SetWindowPosition(window, x, y);
        }
        
        // Get Window Position
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GetWindowPosition(SDL.Window* window, out int x, out int y);
        public static bool GetWindowPosition(SDL.Window* window, out int x, out int y)
        {
            return SDL_GetWindowPosition(window, out x, out y);
        }
        
        // Set Window Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowSize(SDL.Window* window, int w, int h);
        public static bool SetWindowSize(SDL.Window* window, int w, int h)
        {
            return SDL_SetWindowSize(window, w, h);
        }
        
        // Get Window Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GetWindowSize(SDL.Window* window, out int w, out int h);
        public static bool GetWindowSize(SDL.Window* window, out int w, out int h)
        {
            return SDL_GetWindowSize(window, out w, out h);
        }
        
        // Set Window Aspect Ratio
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowAspectRatio(SDL.Window* window, float min, float max);
        public static bool SetWindowAspectRatio(SDL.Window* window, float min, float max)
        {
            return SDL_SetWindowAspectRatio(window, min, max);
        }
        
        // Get Window Aspect Ratio
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GetWindowAspectRatio(SDL.Window* window, out float min, out float max);
        public static bool GetWindowAspectRatio(SDL.Window* window, out float min, out float max)
        {
            return SDL_GetWindowAspectRatio(window, out min, out max);
        }
        
        // Set Window Minimum Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowMinimumSize(SDL.Window* window, int w, int h);
        public static bool SetWindowMinimumSize(SDL.Window* window, int w, int h)
        {
            return SDL_SetWindowMinimumSize(window, w, h);
        }
        
        // Get Window Minimum Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GetWindowMinimumSize(SDL.Window* window, out int w, out int h);
        public static bool GetWindowMinimumSize(SDL.Window* window, out int w, out int h)
        {
            return SDL_GetWindowMinimumSize(window, out w, out h);
        }
        
        // Set Window Maximum Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowMaximumSize(SDL.Window* window, int w, int h);
        public static bool SetWindowMaximumSize(SDL.Window* window, int w, int h)
        {
            return SDL_SetWindowMaximumSize(window, w, h);
        }
        
        // Get Window Maximum Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GetWindowMaximumSize(SDL.Window* window, out int w, out int h);
        public static bool GetWindowMaximumSize(SDL.Window* window, out int w, out int h)
        {
            return SDL_GetWindowMaximumSize(window, out w, out h);
        }
        
        // Set Window Resizable
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowResizable(SDL.Window* window, SDL.Bool resizable);
        public static bool SetWindowResizable(SDL.Window* window, bool resizable)
        {
            return SDL_SetWindowResizable(window, resizable);
        }
        
        // Set Window Bordered
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowBordered(SDL.Window* window, SDL.Bool bordered);
        public static bool SetWindowBordered(SDL.Window* window, bool bordered)
        {
            return SDL_SetWindowBordered(window, bordered);
        }
        
        // Set Window Fullscreen
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowFullscreen(SDL.Window* window, SDL.Bool fullscreen);
        public static bool SetWindowFullscreen(SDL.Window* window, bool fullscreen)
        {
            return SDL_SetWindowFullscreen(window, fullscreen);
        }
        
        // Set Window Always On Top
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowAlwaysOnTop(SDL.Window* window, SDL.Bool enabled);
        public static bool SetWindowAlwaysOnTop(SDL.Window* window, bool enabled)
        {
            return SDL_SetWindowAlwaysOnTop(window, enabled);
        }
        
        // Set Window Focusable
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_SetWindowFocusable(SDL.Window* window, SDL.Bool focusable);
        public static bool SetWindowFocusable(SDL.Window* window, bool focusable)
        {
            return SDL_SetWindowFocusable(window, focusable);
        }
        
        // Show Window
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_ShowWindow(SDL.Window* window);
        public static bool ShowWindow(SDL.Window* window)
        {
            return SDL_ShowWindow(window);
        }
        
        // Hide Window
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_HideWindow(SDL.Window* window);
        public static bool HideWindow(SDL.Window* window)
        {
            return SDL_HideWindow(window);
        }
        
        // Raise Window
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_RaiseWindow(SDL.Window* window);
        public static bool RaiseWindow(SDL.Window* window)
        {
            return SDL_RaiseWindow(window);
        }
        
        // Maximize Window
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_MaximizeWindow(SDL.Window* window);
        public static bool MaximizeWindow(SDL.Window* window)
        {
            return SDL_MaximizeWindow(window);
        }
        
        // Minimize Window
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_MinimizeWindow(SDL.Window* window);
        public static bool MinimizeWindow(SDL.Window* window)
        {
            return SDL_MinimizeWindow(window);
        }
        
        // Restore Window
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_RestoreWindow(SDL.Window* window);
        public static bool RestoreWindow(SDL.Window* window)
        {
            return SDL_RestoreWindow(window);
        }
    }
}