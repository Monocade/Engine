using System;

namespace Engine
{
    public unsafe class Core
    {
        private SDL.Renderer* renderer;
        private SDL.Texture* texture;
        private SDL.Window* window;
        private bool IsRunning = true;
        
        public void Run()
        {
            if (!SDL.Init(SDL.InitFlags.Video))
            {
                throw new Exception("Failed to initialize");
            }
            
            window = SDL.CreateWindow("Hello", 600, 400, SDL.WindowFlags.HighPixelDensity);

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
            }

            var rect = new SDL.FRect();

            SDL.RenderTexture(renderer, texture, &rect, null);
            
            SDL.DestroyWindow(window);
            SDL.Quit();
        }
    }
}