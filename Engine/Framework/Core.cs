using System;

namespace Engine
{
    public unsafe class Core
    {
        private bool IsRunning = true;
        
        private SDL.Track* track;
        private SDL.Audio* audio;
        private SDL.Mixer* mixer;
        private SDL.Renderer* renderer;
        private SDL.Window* window;
        
        public void Run()
        {
            if (!SDL.Init(SDL.InitFlags.Video)) throw new Exception("Failed to initialize SDL");
            if (!SDL_image.Init()) throw new Exception("Failed to initialize Image");
            if (!SDL_mixer.Init()) throw new Exception("Failed to initialize Mixer");
            if (!SDL_ttf.Init()) throw new Exception("Failed to initialize TTF");

            var spec = new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S32,
                channels = 2,
                freq = 44100,
            };

            mixer = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, spec);
            if (mixer == null) throw new Exception("Failed to create mixer device: " + SDL.GetError());

            track = SDL_mixer.CreateTrack(mixer);
            if (track == null) throw new Exception("Failed to create track: " + SDL.GetError());

            audio = SDL_mixer.LoadAudio(mixer, SDL.GetBasePath() + "/Resources/Sounds/Sound.ogg", false);
            if (audio == null) throw new Exception("Failed to create audio: " + SDL.GetError());
            
            window = SDL.CreateWindow("Monocade", 800, 600, SDL.WindowFlags.HighPixelDensity);
            renderer = SDL.CreateRenderer(window, null);
            
            SDL.Font* font = SDL_ttf.OpenFont(SDL.GetBasePath() + "/Resources/Fonts/Font.ttf", 32);
            if (font == null) throw new Exception($"Failed to load font: " + SDL.GetError());

            SDL_mixer.SetTrackAudio(track, audio);
            SDL_mixer.PlayTrack(track, 0);
            
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

                SDL.SetRenderDrawColor(renderer, 0, 0, 0, 255);
                SDL.RenderClear(renderer);
                
                SDL.RenderPresent(renderer);
            }
            
            SDL.DestroyRenderer(renderer);
            SDL.DestroyWindow(window);
            SDL.Quit();
        }
    }
}