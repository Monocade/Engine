using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL_mixer
    {
        // Load Audio
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Audio* MIX_LoadAudio(SDL.Mixer* mixer, byte* path, Utils.Bool predecode);
        public static SDL.Audio* LoadAudio(SDL.Mixer* mixer, string path, bool predecode)
        {
            var bytes = Utils.StringToUtf8(path);

            fixed (byte* utf8 = bytes)
            {
                return MIX_LoadAudio(mixer, utf8, predecode);
            }
        }
        
        // Load Audio IO
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Audio* MIX_LoadAudio_IO(SDL.Mixer* mixer, SDL.IOStream* stream, Utils.Bool predecode, Utils.Bool close);
        public static SDL.Audio* LoadAudioIO(SDL.Mixer* mixer, SDL.IOStream* stream, bool predecode, bool close)
        {
            return MIX_LoadAudio_IO(mixer, stream, predecode, close);
        }
        
        // Destroy Audio
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void MIX_DestroyAudio(SDL.Audio* audio);
        public static void DestroyAudio(SDL.Audio* audio)
        {
            MIX_DestroyAudio(audio);
        }
        
        // Create Sine Wave Audio
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Audio* MIX_CreateSineWaveAudio(SDL.Mixer* mixer, int hz, float amplitude, long ms);
        public static SDL.Audio* CreateSineWaveAudio(SDL.Mixer* mixer, int hz, float amplitude, long ms)
        {
            return MIX_CreateSineWaveAudio(mixer, hz, amplitude, ms);
        }
        
        // Get Audio Duration
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern long MIX_GetAudioDuration(SDL.Audio* audio);
        public static long GetAudioDuration(SDL.Audio* audio)
        {
            return MIX_GetAudioDuration(audio);
        }
        
        // Get Audio Format
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool MIX_GetAudioFormat(SDL.Audio* audio, out SDL.AudioSpec spec);
        public static bool GetAudioFormat(SDL.Audio* audio, out SDL.AudioSpec spec)
        {
            return MIX_GetAudioFormat(audio, out spec);
        }
        
        // Audio MS To Frames
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern long MIX_AudioMSToFrames(SDL.Audio* audio, long ms);
        public static long AudioMsToFrames(SDL.Audio* audio, long ms)
        {
            return MIX_AudioMSToFrames(audio, ms);
        }
        
        // Audio Frame To MS
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern long MIX_AudioFramesToMS(SDL.Audio* audio, long frames);
        public static long AudioFramesToMS(SDL.Audio* audio, long frames)
        {
            return MIX_AudioFramesToMS(audio, frames);
        }
        
        // Play Audio
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern Utils.Bool MIX_PlayAudio(SDL.Mixer* mixer, SDL.Audio* audio);
        public static bool PlayAudio(SDL.Mixer* mixer, SDL.Audio* audio)
        {
            return MIX_PlayAudio(mixer, audio);
        }
    }
}