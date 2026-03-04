using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL_image
    {
        // Load Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* IMG_Load(byte* path);
        public static SDL.Surface* LoadSurface(string path)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return IMG_Load(utf8);
            }
        }
        
        // Load Texture
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Texture* IMG_LoadTexture(SDL.Renderer* renderer, byte* path);
        public static SDL.Texture* LoadTexture(SDL.Renderer* renderer, string path)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return IMG_LoadTexture(renderer, utf8);
            }
        }
        
        // Load Surface IO
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* IMG_Load_IO(SDL.IOStream* stream, SDL.Bool close);
        public static SDL.Surface* LoadSurfaceIO(SDL.IOStream* stream, bool close)
        {
            return IMG_Load_IO(stream, close);
        }
        
        // Load Texture IO
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Texture* IMG_LoadTexture_IO(SDL.Renderer* renderer, SDL.IOStream* stream, SDL.Bool close);
        public static SDL.Texture* LoadTextureIO(SDL.Renderer* renderer, SDL.IOStream* stream, bool close)
        {
            return IMG_LoadTexture_IO(renderer, stream, close);
        }
    }
}