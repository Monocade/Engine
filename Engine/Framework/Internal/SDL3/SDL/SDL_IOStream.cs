using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Open IO
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern IOStream* SDL_IOFromMem(void* mem, nuint size);
        public static IOStream* OpenIO(void* memory, nuint size)
        {
            return SDL_IOFromMem(memory, size);
        }
    
        // Close IO
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_CloseIO(SDL.IOStream* stream);
        public static bool CloseIO(SDL.IOStream* stream)
        {
            return SDL_CloseIO(stream);
        }
    }
}