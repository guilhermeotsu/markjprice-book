using System;

namespace PacktLibrary
{
    public interface IPlayable
    {
        void Play();
        void Pause();

        // Implementando interfaces default
        void Stop()
        {
            Console.WriteLine("Default implementation of Stop.");
        }
    }
}