using System;

namespace Ini_1._0
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Ini game = new Ini())
            {
                game.Run();
            }
        }
    }
}

