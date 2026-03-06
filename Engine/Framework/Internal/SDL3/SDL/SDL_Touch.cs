using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Has Touch
        public static bool HasTouch()
        {
            var devices = GetTouchDevices(out int count);
            {
                return devices.Length > 0 || count > 0;
            }
        }
        
        // Get Touch Devices
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetTouchDevices(out int count);
        public static uint[] GetTouchDevices(out int count)
        {
            IntPtr ptr = SDL_GetTouchDevices(out count);

            if (ptr == IntPtr.Zero || count == 0)
                return Array.Empty<uint>();

            uint[] ids = new uint[count];
            Marshal.Copy(ptr, (int[])(object)ids, 0, count);
            SDL_free(ptr);
            return ids;
        }
    }
}