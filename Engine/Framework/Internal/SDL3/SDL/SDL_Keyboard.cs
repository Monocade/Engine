using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Has Keyboard
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool SDL_HasKeyboard();
        public static bool HasKeyboard()
        {
            return SDL_HasKeyboard();
        }
        
        // Get Keyboards
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetKeyboards(out int count);
        public static uint[] GetKeyboards(out int count)
        {
            IntPtr ptr = SDL_GetKeyboards(out count);

            if (ptr == IntPtr.Zero || count == 0)
                return Array.Empty<uint>();

            uint[] ids = new uint[count];
            Marshal.Copy(ptr, (int[])(object)ids, 0, count);
            SDL_free(ptr);
            return ids;
        }
        
        // Get Mod State
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.KeyModifier SDL_GetModState();
        public static SDL.KeyModifier GetModState()
        {
            return SDL_GetModState();
        }

        // Set Mod State
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_SetModState(SDL.KeyModifier keyModifier);
        public static void SetModState(SDL.KeyModifier keyModifier)
        {
            SDL_SetModState(keyModifier);
        }
        
        // Get Key Code From Scan Code
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.KeyCode SDL_GetKeyFromScancode(SDL.ScanCode scanCode, SDL.KeyModifier keyModifier, Utils.Bool keyEvent);
        public static SDL.KeyCode GetKeyCodeFromScanCode(SDL.ScanCode scanCode, SDL.KeyModifier keyModifier, Utils.Bool keyEvent)
        {
            return SDL_GetKeyFromScancode(scanCode, keyModifier, keyEvent);
        }
        
        // Get Scan Code From Key Code
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.ScanCode SDL_GetScancodeFromKey(SDL.KeyCode keyCode, SDL.KeyModifier keyModifier);
        public static SDL.ScanCode GetScanCodeFromKeyCode(SDL.KeyCode keyCode, SDL.KeyModifier keyModifier)
        {
            return SDL_GetScancodeFromKey(keyCode, keyModifier);
        }
    }
}