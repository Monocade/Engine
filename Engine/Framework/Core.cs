using System;

namespace Engine
{
    public unsafe class Core
    {
        private SDL.Window* window;
        
        public void Run()
        {
            if (!SDL.Init(SDL.InitFlags.Video)) throw new Exception("Failed to initialize");
            window = SDL.CreateWindow("Hello", 600, 400, SDL.WindowFlags.HighPixelDensity);

            while (true)
            {
                
            }
            
            SDL.DestroyWindow(window);
            SDL.Quit();
        }
    }
}