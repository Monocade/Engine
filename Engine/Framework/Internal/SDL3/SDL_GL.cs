using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // GL Load Library
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GL_LoadLibrary(byte* path);
        public static bool GLLoadLibrary(string path)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return SDL_GL_LoadLibrary(utf8);
            }
        }
        
        // GL Unload Library
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_GL_UnloadLibrary();
        public static void GLUnloadLibrary()
        {
            SDL_GL_UnloadLibrary();
        }
        
        // GL Get Proc Address
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GL_GetProcAddress(byte* proc);
        public static IntPtr GLGetProcAddress(string proc)
        {
            var bytes = SDL.StringToUtf8(proc);

            fixed (byte* utf8 = bytes)
            {
                return SDL_GL_GetProcAddress(utf8);
            }
        }
        
        // EGL Get Proc Address
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_EGL_GetProcAddress(byte* proc);
        public static IntPtr EGLGetProcAddress(string proc)
        {
            var bytes = SDL.StringToUtf8(proc);

            fixed (byte* utf8 = bytes)
            {
                return SDL_EGL_GetProcAddress(utf8);
            }
        }
        
        // GL Extension Supported
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GL_ExtensionSupported(byte* extension);
        public static bool GLExtensionSupported(string extension)
        {
            var bytes = SDL.StringToUtf8(extension);

            fixed (byte* utf8 = bytes)
            {
                return SDL_GL_ExtensionSupported(utf8);
            }
        }
        
        // GL Set Attribute
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GL_SetAttribute(SDL.GLAttribute attribute, int value);
        public static bool GLSetAttribute(SDL.GLAttribute attribute, int value)
        {
            return SDL_GL_SetAttribute(attribute, value);
        }
        
        // GL Get Attribute
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GL_GetAttribute(SDL.GLAttribute attribute, out int value);
        public static bool GLGetAttribute(SDL.GLAttribute attribute, out int value)
        {
            return SDL_GL_GetAttribute(attribute, out value);
        }
        
        // GL Set Swap Interval
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GL_SetSwapInterval(int interval);
        public static bool GLSetSwapInterval(int interval)
        {
            return SDL_GL_SetSwapInterval(interval);
        }

        // GL Get Swap Interval
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GL_GetSwapInterval(out int interval);
        public static bool GLGetSwapInterval(out int interval)
        {
            return SDL_GL_GetSwapInterval(out interval);
        }
        
        // GL Reset Attributes
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_GL_ResetAttributes();
        public static void GLResetAttributes()
        {
            SDL_GL_ResetAttributes();
        }
        
        // GL Make Current
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GL_MakeCurrent(SDL.Window* window, SDL.GLContext* context);
        public static bool GLMakeCurrent(SDL.Window* window, SDL.GLContext* context)
        {
            return SDL_GL_MakeCurrent(window, context);
        }
        
        // GL Swap Window
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GL_SwapWindow(SDL.Window* window);
        public static bool GLSwapWindow(SDL.Window* window)
        {
            return SDL_GL_SwapWindow(window);
        }
        
        // GL Create Context
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.GLContext* SDL_GL_CreateContext(SDL.Window* window);
        public static SDL.GLContext* GLCreateContext(SDL.Window* window)
        {
            return SDL_GL_CreateContext(window);
        }
        
        // GL Destroy Context
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_GL_DestroyContext(SDL.GLContext* context);
        public static bool GLDestroyContext(SDL.GLContext* context)
        {
            return SDL_GL_DestroyContext(context);
        }
    }
}