using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        // Default Audio Devices
        public const uint DefaultPlaybackDevice = 0xFFFFFFFFu;
        public const uint DefaultRecordingDevice = 0xFFFFFFFEu;
        
        
        // Get Audio Playback Devices
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetAudioPlaybackDevices(out int count);
        public static uint[] GetAudioPlaybackDevices(out int count)
        {
            IntPtr ptr = SDL_GetAudioPlaybackDevices(out count);

            if (ptr == IntPtr.Zero || count == 0)
                return Array.Empty<uint>();

            uint[] ids = new uint[count];
            Marshal.Copy(ptr, (int[])(object)ids, 0, count);
            SDL_free(ptr);
            return ids;
        }

        // Get Audio Recording Devices
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetAudioRecordingDevices(out int count);
        public static uint[] GetAudioRecordingDevices(out int count)
        {
            IntPtr ptr = SDL_GetAudioRecordingDevices(out count);

            if (ptr == IntPtr.Zero || count == 0)
                return Array.Empty<uint>();

            uint[] ids = new uint[count];
            Marshal.Copy(ptr, (int[])(object)ids, 0, count);
            SDL_free(ptr);
            return ids;
        }
    }
}