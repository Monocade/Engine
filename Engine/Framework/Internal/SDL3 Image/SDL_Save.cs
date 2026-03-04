using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL_Image
    {
        // Save
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool IMG_Save(SDL.Surface* surface, byte* path);
        public static bool Save(SDL.Surface* surface, string path)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return IMG_Save(surface, utf8);
            }
        }
        
        // Save BMP
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool IMG_SaveBMP(SDL.Surface* surface, byte* path);
        public static bool SaveBMP(SDL.Surface* surface, string path)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return IMG_SaveBMP(surface, utf8);
            }
        }
        
        // Save JPG
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool IMG_SaveJPG(SDL.Surface* surface, byte* path, int quality);
        public static bool SaveJPG(SDL.Surface* surface, string path, int quality)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return IMG_SaveJPG(surface, utf8, quality);
            }
        }
        
        // Save PNG
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool IMG_SavePNG(SDL.Surface* surface, byte* path);
        public static bool SavePNG(SDL.Surface* surface, string path)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return IMG_SavePNG(surface, utf8);
            }
        }
        
        // Save WEBP
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool IMG_SaveWEBP(SDL.Surface* surface, byte* path, float quality);
        public static bool SaveWEBP(SDL.Surface* surface, string path, float quality)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return IMG_SaveWEBP(surface, utf8, quality);
            }
        }
    }
}