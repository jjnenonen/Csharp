using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

namespace tehtava4
{
    static class Application
    {
        //staattiset muuttujat
        static int LastOperationId = 0;
        static List<Operation> Operations = new List<Operation>();
        static Random r = new Random();
        static int MaxBreaks = 10;
        static int MinTimeInSeconds = 5;
        static int MaxTimeInSeconds = 10;

        static void PrintOperations(List<Operation> operations)
        {
            foreach (Operation o in operations)
            {
                o.PrintEnded();
            }
        }

        static async Task KaynnistaOperaatioAsync(Operation o)
        {
            await Task.Run(() => {
                int aikams = (int)((o.TotalTimeInSeconds * 1.0 / o.Breaks) * 1000);
                int i = 1;
                do
                {
                    Thread.Sleep(aikams);
                    o.SpendTimeInSeconds = (int)(o.TotalTimeInSeconds * i * 1.0 / o.Breaks);
                    o.Print();
                    i++; 
                } while (i <= o.Breaks);
                o.Ended = DateTime.Now;
            });
        }

        public static void Run()
        {
            do
            {
                SetCursorPosition(0, 0);
                Write(new string(' ', 60));
                SetCursorPosition(0, 0);
                Write("Käynnistä uusi operaatio = K, Lopeta ohjelma = L: ");
                string syote = ReadLine();
                //WriteLine();
                if (syote.ToUpper() == "L")
                {
                    SetCursorPosition(0, 0);
                    Write(new string(' ', 60));
                    SetCursorPosition(0, 0);
                    Write("Paina Enter, kun kaikki operaatiot on suoritettu.");
                    PrintOperations(Operations);
                    ReadKey();
                    break;
                }

                if (syote.ToUpper() == "K")
                {
                    LastOperationId++;
                    Operation o = new Operation() {
                    Id = LastOperationId,
                    Breaks = r.Next(1, MaxBreaks),
                    TotalTimeInSeconds = r.Next(MinTimeInSeconds, MaxTimeInSeconds)
                    };

                    Operations.Add(o);
                    Task task = KaynnistaOperaatioAsync(o);
                }
            } while (true);
        }
    }
}
