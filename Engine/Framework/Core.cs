using System;

namespace Engine
{
    public unsafe class Core
    {
        private bool IsRunning = true;
        
        private SDL.Surface* surface;
        private SDL.Texture* texture;
        private SDL.Renderer* renderer;
        private SDL.Window* window;
        
        public void Run()
        {
            if (!SDL.Init(SDL.InitFlags.Video))
            {
                throw new Exception("Failed to initialize");
            }
            
            window = SDL.CreateWindow("Monocade", 800, 600, SDL.WindowFlags.HighPixelDensity);
            renderer = SDL.CreateRenderer(window, null);
            
            // Load Texture
            
            // Load Surface
            surface = SDL_image.LoadSurface(SDL.GetBasePath() + "Resources/Icon.png");
            texture = SDL.CreateTextureFromSurface(renderer, surface);

            if (texture == null)
            {
                throw new Exception("Failed to load texture: " + SDL.GetError());
            }
            
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
                
                // Draw Texture
                SDL.RenderTexture(renderer, texture, null, null);
                
                SDL.RenderPresent(renderer);
            }
            
            SDL.DestroyRenderer(renderer);
            SDL.DestroyWindow(window);
            SDL.Quit();
        }
    }
}