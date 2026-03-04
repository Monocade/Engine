using System;

namespace Engine
{
    public unsafe class Core
    {
        private bool IsRunning = true;
        
        private SDL.Renderer* renderer;
        private SDL.Window* window;
        
        public void Run()
        {
            if (!SDL.Init(SDL.InitFlags.Video))
            {
                throw new Exception("Failed to initialize");
            }
            
            window = SDL.CreateWindow("Monocade", 600, 400, SDL.WindowFlags.HighPixelDensity);
            renderer = SDL.CreateRenderer(window, null);

            while (IsRunning)
            {
                while (SDL.PollEvent(out SDL.Event e))
                {
                    switch (e.type)
                    {
                        case SDL.EventType.Quit:
                        {
                            IsRunning = false;
                            break;
                        }
                    }
                }

                SDL.SetRenderDrawColor(renderer, 255, 128, 128, 255);
                SDL.RenderClear(renderer);
                
                // Draw
                
                SDL.RenderPresent(renderer);
            }
            
            SDL.DestroyRenderer(renderer);
            SDL.DestroyWindow(window);
            SDL.Quit();
        }
    }
}