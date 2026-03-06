using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Has Gamepad
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_HasGamepad();
        public static bool HasGamepad()
        {
            return SDL_HasGamepad();
        }
        
        // Get Gamepads
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetGamepads(out int count);
        public static uint[] GetGamepads(out int count)
        {
            IntPtr ptr = SDL_GetGamepads(out count);

            if (ptr == IntPtr.Zero || count == 0)
                return Array.Empty<uint>();

            uint[] ids = new uint[count];
            Marshal.Copy(ptr, (int[])(object)ids, 0, count);
            SDL_free(ptr);
            return ids;
        }
        
        // Get Gamepad ID
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint SDL_GetGamepadID(SDL.Gamepad* gamepad);
        public static uint GetGamepadID(SDL.Gamepad* gamepad)
        {
            return SDL_GetGamepadID(gamepad);
        }
        
        // Get Gamepad From ID
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Gamepad* SDL_GetGamepadFromID(uint gamepadID);
        public static SDL.Gamepad* GetGamepadFromID(uint gamepadID)
        {
            return SDL_GetGamepadFromID(gamepadID);
        }
        
        // Get Gamepad Steam Handle
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern ulong SDL_GetGamepadSteamHandle(SDL.Gamepad* gamepad);
        public static ulong GetGamepadSteamHandle(SDL.Gamepad* gamepad)
        {
            return SDL_GetGamepadSteamHandle(gamepad);
        }
        
        // Open Gamepad
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Gamepad* SDL_OpenGamepad(uint gamepadID);
        public static SDL.Gamepad* OpenGamepad(uint gamepadID)
        {
            return SDL_OpenGamepad(gamepadID);
        }
        
        // Close Gamepad
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_CloseGamepad(SDL.Gamepad* gamepad);
        public static void CloseGamepad(SDL.Gamepad* gamepad)
        {
            SDL_CloseGamepad(gamepad);
        }
        
        // Rumble Gamepad
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_RumbleGamepad(SDL.Gamepad* gamepad, ushort left, ushort right, uint ms);
        public static bool RumbleGamepad(SDL.Gamepad* gamepad, ushort left, ushort right, uint ms)
        {
            return SDL_RumbleGamepad(gamepad, left, right, ms);
        }

        // Rumble Gamepad Triggers
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool SDL_RumbleGamepadTriggers(SDL.Gamepad* gamepad, ushort left, ushort right, uint ms);
        public static bool RumbleGamepadTriggers(SDL.Gamepad* gamepad, ushort left, ushort right, uint ms)
        {
            return SDL_RumbleGamepadTriggers(gamepad, left, right, ms);
        }
    }
}