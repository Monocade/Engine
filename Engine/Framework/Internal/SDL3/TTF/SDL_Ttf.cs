using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL_ttf
    {
        // Open Font
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Font* TTF_OpenFont(byte* path, float size);
        public static SDL.Font* OpenFont(string path, float size)
        {
            var bytes = SDL.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return TTF_OpenFont(utf8, size);
            }
        }
        
        // Open Font IO
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Font* TTF_OpenFontIO(SDL.IOStream* stream, SDL.Bool close, float size);
        public static SDL.Font* OpenFontIO(SDL.IOStream* stream, bool close, float size)
        {
            return TTF_OpenFontIO(stream, close, size);
        }
        
        // Close Font
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_CloseFont(SDL.Font* font);
        public static void CloseFont(SDL.Font* font)
        {
            TTF_CloseFont(font);
        }
        
        // Add Fallback Font
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_AddFallbackFont(SDL.Font* font, SDL.Font* fallback);
        public static bool AddFallbackFont(SDL.Font* font, SDL.Font* fallback)
        {
            return TTF_AddFallbackFont(font, fallback);
        }
        
        // Remove Fallback Font
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_RemoveFallbackFont(SDL.Font* font, SDL.Font* fallback);
        public static void RemoveFallbackFont(SDL.Font* font, SDL.Font* fallback)
        {
            TTF_RemoveFallbackFont(font, fallback);
        }
        
        // Clear Fallback Fonts
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_ClearFallbackFonts(SDL.Font* font);
        public static void ClearFallbackFonts(SDL.Font* font)
        {
            TTF_ClearFallbackFonts(font);
        }
        
        // Set Font Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_SetFontSize(SDL.Font* font, float size);
        public static bool SetFontSize(SDL.Font* font, float size)
        {
            return TTF_SetFontSize(font, size);
        }
        
        // Get Font Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern float TTF_GetFontSize(SDL.Font* font);
        public static float GetFontSize(SDL.Font* font)
        {
            return TTF_GetFontSize(font);
        }
        
        // Set Font SDF
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_SetFontSDF(SDL.Font* font, SDL.Bool enabled);
        public static bool SetFontSDF(SDL.Font* font, bool enabled)
        {
            return TTF_SetFontSDF(font, enabled);
        }
        
        // Get Font SDF
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_GetFontSDF(SDL.Font* font);
        public static bool GetFontSDF(SDL.Font* font)
        {
            return TTF_GetFontSDF(font);
        }
        
        // Get Font Weight
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontWeight(SDL.Font* font);
        public static int GetFontWeight(SDL.Font* font)
        {
            return TTF_GetFontWeight(font);
        }
        
        // Get Font Height
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontHeight(SDL.Font* font);
        public static int GetFontHeight(SDL.Font* font)
        {
            return TTF_GetFontHeight(font);
        }
        
        // Get Font Ascent
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontAscent(SDL.Font* font);
        public static int GetFontAscent(SDL.Font* font)
        {
            return TTF_GetFontAscent(font);
        }
        
        // Get Font Descent
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontDescent(SDL.Font* font);
        public static int GetFontDescent(SDL.Font* font)
        {
            return TTF_GetFontDescent(font);
        }
        
        // Set Font Kerning
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_SetFontKerning(SDL.Font* font, SDL.Bool enabled);
        public static void SetFontKerning(SDL.Font* font, bool enabled)
        {
            TTF_SetFontKerning(font, enabled);
        }
        
        // Get Font Kerning
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_GetFontKerning(SDL.Font* font);
        public static bool GetFontKerning(SDL.Font* font)
        {
            return TTF_GetFontKerning(font);
        }
        
        // Set Font Char Spacing
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_SetFontCharSpacing(SDL.Font* font, int spacing);
        public static bool SetFontCharSpacing(SDL.Font* font, int spacing)
        {
            return TTF_SetFontCharSpacing(font, spacing);
        }
        
        // Get Font Char Spacing
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontCharSpacing(SDL.Font* font);
        public static int GetFontCharSpacing(SDL.Font* font)
        {
            return TTF_GetFontCharSpacing(font);
        }
        
        // Set Font Line Spacing
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_SetFontLineSkip(SDL.Font* font, int lineSkip);
        public static void SetFontLineSpacing(SDL.Font* font, int lineSkip)
        {
            TTF_SetFontLineSkip(font, lineSkip);
        }
        
        // Get Font Line Spacing
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontLineSkip(SDL.Font* font);
        public static int GetFontLineSpacing(SDL.Font* font)
        {
            return TTF_GetFontLineSkip(font);
        }
        
        // Set Font Style
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_SetFontStyle(SDL.Font* font, SDL.FontStyle style);
        public static void SetFontStyle(SDL.Font* font, SDL.FontStyle style)
        {
            TTF_SetFontStyle(font, style);
        }
        
        // Get Font Style
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.FontStyle TTF_GetFontStyle(SDL.Font* font);
        public static SDL.FontStyle GetFontStyle(SDL.Font* font)
        {
            return TTF_GetFontStyle(font);
        }
        
        // Set Font Direction
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_SetFontDirection(SDL.Font* font, SDL.FontDirection direction);
        public static bool SetFontDirection(SDL.Font* font, SDL.FontDirection direction)
        {
            return TTF_SetFontDirection(font, direction);
        }
        
        // Get Font Direction
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.FontDirection TTF_GetFontDirection(SDL.Font* font);
        public static SDL.FontDirection GetFontDirection(SDL.Font* font)
        {
            return TTF_GetFontDirection(font);
        }

        // Set Font Outline
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_SetFontOutline(SDL.Font* font, int outline);
        public static bool SetFontOutline(SDL.Font* font, int outline)
        {
            return TTF_SetFontOutline(font, outline);
        }
        
        // Get Font Outline
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontOutline(SDL.Font* font);
        public static int GetFontOutline(SDL.Font* font)
        {
            return TTF_GetFontOutline(font);
        }
        
        // Get Font Number Of Faces
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetNumFontFaces(SDL.Font* font);
        public static int GetFontNumberOfFaces(SDL.Font* font)
        {
            return TTF_GetNumFontFaces(font);
        }
        
        // Get String Size
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_GetStringSize(SDL.Font* font, byte* text, UIntPtr size, out int w, out int h);
        public static bool GetStringSize(SDL.Font* font, string text, out int w, out int h)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_GetStringSize(font, utf8, size, out w, out h);
            }
        }
    
        // Measure String
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool TTF_MeasureString(SDL.Font* font, byte* text, UIntPtr size, int maxWidth, out int width, out UIntPtr length);
        public static bool MeasureString(SDL.Font* font, string text, int maxWidth, out int width, out UIntPtr length)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_MeasureString(font, utf8, size, maxWidth, out width, out length);
            }
        }
        
        // Render Text Solid
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* TTF_RenderText_Solid(SDL.Font* font, byte* text, UIntPtr size, SDL.Color color);
        public static SDL.Surface* RenderTextSolid(SDL.Font* font, string text, SDL.Color color)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_RenderText_Solid(font, utf8, size, color);
            }
        }
        
        // Render Text Solid Wrapped
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* TTF_RenderText_Solid_Wrapped(SDL.Font* font, byte* text, UIntPtr size, SDL.Color color, int wrapLength);
        public static SDL.Surface* RenderTextSolidWrapped(SDL.Font* font, string text, SDL.Color color, int wrapLength)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_RenderText_Solid_Wrapped(font, utf8, size, color, wrapLength);
            }
        }
        
        // Render Text Shaded
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* TTF_RenderText_Shaded(SDL.Font* font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background);
        public static SDL.Surface* RenderTextShaded(SDL.Font* font, string text, SDL.Color foreground, SDL.Color background)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_RenderText_Shaded(font, utf8, size, foreground, background);
            }
        }
        
        // Render Text Shaded Wrapped
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* TTF_RenderText_Shaded_Wrapped(SDL.Font* font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background, int wrapWidth);
        public static SDL.Surface* RenderTextShadedWrapped(SDL.Font* font, string text, SDL.Color foreground, SDL.Color background, int wrapWidth)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_RenderText_Shaded_Wrapped(font, utf8, size, foreground, background, wrapWidth);
            }
        }
        
        // Render Text Blended
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* TTF_RenderText_Blended(SDL.Font* font, byte* text, UIntPtr size, SDL.Color color);
        public static SDL.Surface* RenderTextBlended(SDL.Font* font, string text, SDL.Color color)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_RenderText_Blended(font, utf8, size, color);
            }
        }
        
        // Render Text Blended Wrapped
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* TTF_RenderText_Blended_Wrapped(SDL.Font* font, byte* text, UIntPtr size, SDL.Color color, int wrapWidth);
        public static SDL.Surface* RenderTextBlendedWrapped(SDL.Font* font, string text, SDL.Color color, int wrapWidth)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_RenderText_Blended_Wrapped(font, utf8, size, color, wrapWidth);
            }
        }
        
        // Render Text LCD
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* TTF_RenderText_LCD(SDL.Font* font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background);
        public static SDL.Surface* RenderTextLCD(SDL.Font* font, string text, SDL.Color foreground, SDL.Color background)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_RenderText_LCD(font, utf8, size, foreground, background);
            }
        }
        
        // Render Text LCD Wrapped
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Surface* TTF_RenderText_LCD_Wrapped(SDL.Font* font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background, int wrapWidth);
        public static SDL.Surface* RenderTextLCDWrapped(SDL.Font* font, string text, SDL.Color foreground, SDL.Color background, int wrapWidth)
        {
            var bytes = SDL.StringToUtf8(text);

            fixed (byte* utf8 = bytes)
            {
                UIntPtr size = (UIntPtr)(bytes.Length - 1);
                return TTF_RenderText_LCD_Wrapped(font, utf8, size, foreground, background, wrapWidth);
            }
        }
    }
}