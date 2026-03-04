using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL_image
    {
        // Save
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool IMG_Save(SDL.Surface* surface, byte* path);
        public static bool SaveSurface(SDL.Surface* surface, string path)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return IMG_Save(surface, utf8);
            }
        }
        
        // Save Texture
        public static bool SaveTexture(SDL.Renderer* renderer, SDL.Texture* texture, string path)
        {
            SDL.Surface* surface = SDL.CreateSurfaceFromTexture(renderer, texture);
            {
                var bytes = SDL.StringToUtf8(path);

                fixed (byte* utf8 = bytes)
                {
                    var result = IMG_Save(surface, utf8);
                    {
                        SDL.DestroySurface(surface);
                        {
                            return result;
                        }
                    }
                }
            }
        }
    }
}