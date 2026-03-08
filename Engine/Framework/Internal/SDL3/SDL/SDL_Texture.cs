using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Create Texture
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Texture* SDL_CreateTexture(SDL.Renderer* renderer, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h);
        public static SDL.Texture* CreateTexture(SDL.Renderer* renderer, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h)
        {
            return SDL_CreateTexture(renderer, format, access, w, h);
        }
        
        // Create Texture From Surface
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Texture* SDL_CreateTextureFromSurface(SDL.Renderer* renderer, SDL.Surface* surface);
        public static SDL.Texture* CreateTextureFromSurface(SDL.Renderer* renderer, SDL.Surface* surface)
        {
            return SDL_CreateTextureFromSurface(renderer, surface);
        }
        
        // Destroy Texture
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_DestroyTexture(SDL.Texture* texture);
        public static void DestroyTexture(SDL.Texture* texture)
        {
            SDL_DestroyTexture(texture);
        }
        
        // Get Texture Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_GetTextureSize(SDL.Texture* texture, out float w, out float h);
        public static bool GetTextureSize(SDL.Texture* texture, out float w, out float h)
        {
            return SDL_GetTextureSize(texture, out w, out h);
        }
        
        // Set Texture Color Mod
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetTextureColorMod(SDL.Texture* texture, byte r, byte g, byte b);
        public static bool SetTextureColorMod(SDL.Texture* texture, byte r, byte g, byte b)
        {
            return SDL_SetTextureColorMod(texture, r, g, b);
        }
        
        // Get Texture Color Mod
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_GetTextureColorMod(SDL.Texture* texture, out byte r, out byte g, out byte b);
        public static bool GetTextureColorMod(SDL.Texture* texture, out byte r, out byte g, out byte b)
        {
            return SDL_GetTextureColorMod(texture, out r, out g, out b);
        }
        
        // Set Texture Color Mod Float
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetTextureColorModFloat(SDL.Texture* texture, float r, float g, float b);
        public static bool SetTextureColorModFloat(SDL.Texture* texture, float r, float g, float b)
        {
            return SDL_SetTextureColorModFloat(texture, r, g, b);
        }
        
        // Get Texture Color Mod Float
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_GetTextureColorModFloat(SDL.Texture* texture, out float r, out float g, out float b);
        public static bool GetTextureColorModFloat(SDL.Texture* texture, out float r, out float g, out float b)
        {
            return SDL_GetTextureColorModFloat(texture, out r, out g, out b);
        }
        
        // Set Texture Alpha Mod
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetTextureAlphaMod(SDL.Texture* texture, byte alpha);
        public static bool SetTextureAlphaMod(SDL.Texture* texture, byte alpha)
        {
            return SDL_SetTextureAlphaMod(texture, alpha);
        }
        
        // Get Texture Alpha Mod
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_GetTextureAlphaMod(SDL.Texture* texture, out byte alpha);
        public static bool GetTextureAlphaMod(SDL.Texture* texture, out byte alpha)
        {
            return SDL_GetTextureAlphaMod(texture, out alpha);
        }
        
        // Set Texture Alpha Mod Float
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetTextureAlphaModFloat(SDL.Texture* texture, float alpha);
        public static bool SetTextureAlphaModFloat(SDL.Texture* texture, float alpha)
        {
            return SDL_SetTextureAlphaModFloat(texture, alpha);
        }
        
        // Get Texture Alpha Mod Float
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_GetTextureAlphaModFloat(SDL.Texture* texture, out float alpha);
        public static bool GetTextureAlphaModFloat(SDL.Texture* texture, out float alpha)
        {
            return SDL_GetTextureAlphaModFloat(texture, out alpha);
        }
        
        // Set Texture Blend Mode
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetTextureBlendMode(SDL.Texture* texture, SDL.BlendMode mode);
        public static bool SetTextureBlendMode(SDL.Texture* texture, SDL.BlendMode mode)
        {
            return SDL_SetTextureBlendMode(texture, mode);
        }
        
        // Get Texture Blend Mode
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_GetTextureBlendMode(SDL.Texture* texture, out SDL.BlendMode mode);
        public static bool GetTextureBlendMode(SDL.Texture* texture, out SDL.BlendMode mode)
        {
            return SDL_GetTextureBlendMode(texture, out mode);
        }
        
        // Set Texture Scale Mode
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetTextureScaleMode(SDL.Texture* texture, SDL.ScaleMode mode);
        public static bool SetTextureScaleMode(SDL.Texture* texture, SDL.ScaleMode mode)
        {
            return SDL_SetTextureScaleMode(texture, mode);
        }
        
        // Get Texture Scale Mode
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_GetTextureScaleMode(SDL.Texture* texture, out SDL.ScaleMode mode);
        public static bool GetTextureScaleMode(SDL.Texture* texture, out SDL.ScaleMode mode)
        {
            return SDL_GetTextureScaleMode(texture, out mode);
        }
        
        // Set Default Texture Scale Mode
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_SetDefaultTextureScaleMode(SDL.Renderer* renderer, SDL.ScaleMode mode);
        public static bool SetDefaultTextureScaleMod(SDL.Renderer* renderer, SDL.ScaleMode mode)
        {
            return SDL_SetDefaultTextureScaleMode(renderer, mode);
        }

        // Get Default Texture Scale Mode
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_GetDefaultTextureScaleMode(SDL.Renderer* renderer, out SDL.ScaleMode mode);
        public static bool GetDefaultTextureScaleMode(SDL.Renderer* renderer, out SDL.ScaleMode mode)
        {
            return SDL_GetDefaultTextureScaleMode(renderer, out mode);
        }
        
        // Update Texture
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_UpdateTexture(SDL.Texture* texture, SDL.Rect* rect, IntPtr pixels, int pitch);
        public static bool UpdateTexture(SDL.Texture* texture, SDL.Rect? rect, byte[] pixels, int width)
        {
            fixed (byte* p = pixels)
            {
                var r = rect.GetValueOrDefault();
                var rv = rect.HasValue ? &r : null;
                
                return SDL_UpdateTexture(texture, rv, (IntPtr)p, width * 4);
            }
        }
    }
}