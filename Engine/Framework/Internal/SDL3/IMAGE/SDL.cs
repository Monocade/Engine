using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL_image
    {
        // Library
        private const string library = "SDL3_image";
        
        
        // Init (Deprecated)
        public static bool Init()
        {
            return true;
        }
        
        // Quit (Deprecated)
        public static void Quit()
        {
            
        }
    }
}