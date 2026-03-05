using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL_mixer
    {
        // Create Mixer Device
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Mixer* MIX_CreateMixerDevice(uint deviceID, SDL.AudioSpec* spec);
        public static SDL.Mixer* CreateMixerDevice(uint deviceID, SDL.AudioSpec spec)
        {
            return MIX_CreateMixerDevice(deviceID, &spec);
        }
        
        // Create Mixer
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Mixer* MIX_CreateMixer(SDL.AudioSpec* spec);
        public static SDL.Mixer* CreateMixer(SDL.AudioSpec spec)
        {
            return MIX_CreateMixer(&spec);
        }
        
        // Destroy Mixer
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void MIX_DestroyMixer(SDL.Mixer* mixer);
        public static void DestroyMixer(SDL.Mixer* mixer)
        {
            MIX_DestroyMixer(mixer);
        }
        
        // MS To Frames
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern long MIX_MSToFrames(int sampleRate, long ms);
        public static long MixerMsToFrames(int sampleRate, long ms)
        {
            return MIX_MSToFrames(sampleRate, ms);
        }
        
        // Frames To MS
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern long MIX_FramesToMS(int sampleRate, long frames);
        public static long MixerFramesToMs(int sampleRate, long frames)
        {
            return MIX_FramesToMS(sampleRate, frames);
        }
        
        // Set Mixer Gain
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool MIX_SetMixerGain(SDL.Mixer* mixer, float gain);
        public static bool SetMixerGain(SDL.Mixer* mixer, float gain)
        {
            return MIX_SetMixerGain(mixer, gain);
        }
        
        // Get Mixer Gain
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern float MIX_GetMixerGain(SDL.Mixer* mixer);
        public static float GetMixerGain(SDL.Mixer* mixer)
        {
            return MIX_GetMixerGain(mixer);
        }
        
        // Set Mixer Frequency Ratio
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL.Bool MIX_SetMixerFrequencyRatio(SDL.Mixer* mixer, float ratio);
        public static bool SetMixerFrequencyRatio(SDL.Mixer* mixer, float ratio)
        {
            return MIX_SetMixerFrequencyRatio(mixer, ratio);
        }
        
        // Get Mixer Frequency Ratio
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern float MIX_GetMixerFrequencyRatio(SDL.Mixer* mixer);
        public static float GetMixerFrequencyRatio(SDL.Mixer* mixer)
        {
            return MIX_GetMixerFrequencyRatio(mixer);
        }
    }
}