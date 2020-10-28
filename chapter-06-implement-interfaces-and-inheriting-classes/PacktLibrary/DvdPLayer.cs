using static System.Console;

namespace PacktLibrary
{
    public class DvdPLayer : IPlayable
    {
        public void Pause()
        {
            WriteLine("Dvd player pausado!");
        }

        public void Play()
        {
            WriteLine("Dvd Player play!");
        }
    }
}