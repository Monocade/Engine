using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        public enum GLAttribute
        {
            Stereo = 12,
            RedSize = 0,
            GreenSize = 1,
            BlueSize = 2,
            AlphaSize = 3,
            BufferSize = 4,
            DoubleBuffer = 5,
            DepthSize = 6,
            StencilSize = 7,
            AccumulatedRedSize = 8,
            AccumulatedGreenSize = 9,
            AccumulatedBlueSize = 10,
            AccumulatedAlphaSize = 11,
            MultiSampleBuffers = 13,
            MultiSampleSamples = 14,
            AcceleratedVisual = 15,
            RetainedBacking = 16,
            ContextReleaseBehaviour = 23,
            ContextResetNotification = 24,
            ContextMajorVersion = 17,
            ContextMinorVersion = 18,
            ContextNoError = 25,
            ContextProfile = 20,
            ContextFlags = 19,
            ShareWithCurrentContext = 21,
            FrameBufferSRGBCapable = 22,
            FloatBuffers = 26,
            EGLPlatform = 27,
        }
    }
}