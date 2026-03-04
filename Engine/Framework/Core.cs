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
            if (!SDL.Init(SDL.InitFlags.Video)) throw new Exception("Failed to initialize SDL");
            if (!SDL_ttf.Init()) throw new Exception("Failed to initialize TTF");
            
            window = SDL.CreateWindow("Monocade", 800, 600, SDL.WindowFlags.HighPixelDensity);
            renderer = SDL.CreateRenderer(window, null);
            
            string path = SDL.GetBasePath() + "/Resources/Fonts/Font.ttf";
            SDL.Font* font = SDL_ttf.OpenFont(path, 32);
            if (font == null) throw new Exception($"Failed to load font:  {path} " + SDL.GetError());
            
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

                SDL.Surface* surface = SDL_ttf.RenderTextSolid(font, "Hello world", new SDL.Color());
                SDL.Texture* texture = SDL.CreateTextureFromSurface(renderer, surface);
                SDL.RenderTexture(renderer, texture, null, null);
                
                SDL.DestroySurface(surface);
                SDL.DestroyTexture(texture);
                
                SDL.RenderPresent(renderer);
            }
            
            SDL.DestroyRenderer(renderer);
            SDL.DestroyWindow(window);
            SDL.Quit();
        }
    }
}