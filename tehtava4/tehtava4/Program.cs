using System;

namespace tehtava4
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				Application.Run();
			}
			catch (Exception e)
			{

				Console.WriteLine($"Virhe: {e.Message}");
			}
        }
    }
}
