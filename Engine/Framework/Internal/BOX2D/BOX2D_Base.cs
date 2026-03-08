using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class BOX2D
    {
        // Alloc Fcn
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr b2AllocFcn(uint size, int alignment);
        
        // Free Fcn
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void b2FreeFcn(IntPtr mem, uint size);
        
        // Assert Fcn
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void b2AssertFcn(byte* condition, byte* filename, int lineNumber);
        
        // Log Fcn
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void b2LogFcn(byte* message);
        
        
        // Get Version
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern BOX2D.Version b2GetVersion();
        public static BOX2D.Version GetVersion()
        {
            return b2GetVersion();
        }
        
        // Get Ticks
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern ulong b2GetTicks();
        public static ulong GetTicks()
        {
            return b2GetTicks();
        }
        
        // Get Milliseconds
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern float b2GetMilliseconds(ulong ticks);
        public static float GetMilliseconds(ulong ticks)
        {
            return b2GetMilliseconds(ticks);
        }
        
        // Get Milliseconds And Reset
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern float b2GetMillisecondsAndReset(ulong ticks);
        public static float GetMillisecondsAndReset(ulong ticks)
        {
            return b2GetMillisecondsAndReset(ticks);
        }
        
        // Yield
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void b2Yield();
        public static void Yield()
        {
            b2Yield();
        }
        
        // Hash
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint b2Hash(uint hash, byte* data, int count);
        public static uint Hash(uint hash, byte* data, int count)
        {
            return b2Hash(hash, data, count);
        }
        
        // Get Byte Count
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int b2GetByteCount();
        public static int GetByteCount()
        {
            return b2GetByteCount();
        }
        
        // Internal Assert Fcn
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern int b2InternalAssertFcn(byte* condition, byte* filename, int lineNumber);
        public static int InternalAssertFcn(string condition, string filename, int lineNumber)
        {
            var conditionBytes = Utils.StringToUtf8(condition);
            var fileBytes = Utils.StringToUtf8(filename);

            fixed (byte* conditionUtf8 = conditionBytes)
            fixed (byte* fileUtf8 = fileBytes)
            {
                return b2InternalAssertFcn(conditionUtf8, fileUtf8, lineNumber);
            }
        }
        
        // Set Allocator
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void b2SetAllocator(b2AllocFcn allocFcn, b2FreeFcn freeFcn);
        public static void SetAllocator(b2AllocFcn allocFcn, b2FreeFcn freeFcn)
        {
            b2SetAllocator(allocFcn, freeFcn);
        }
        
        // Set Assert Fcn
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void b2SetAssertFcn(b2AssertFcn assertFcn);
        public static void SetAssertFcn(b2AssertFcn assertFcn)
        {
            b2SetAssertFcn(assertFcn);
        }
        
        // Set Log Fnc
        [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
        private static extern void b2SetLogFcn(b2LogFcn logFcn);
        public static void SetLogFcn(b2LogFcn logFcn)
        {
            b2SetLogFcn(logFcn);
        }
    }
}