using System;

namespace MobyDick
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MobyDickGame game = new MobyDickGame())
            {
                game.Run();
            }
        }
    }
#endif
}

