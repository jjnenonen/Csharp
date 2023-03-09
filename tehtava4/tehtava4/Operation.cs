using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace tehtava4
{
    class Operation
    {
        //automaattiset ominaisuudet
        public int Id { get; set; }
        public int TotalTimeInSeconds { get; set; }
        public int SpendTimeInSeconds { get; set; }
        public int Breaks { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }

        public Operation()
        {
            Started = DateTime.Now;
        }

        public void Print()
        {
            //otetaan talteen edellinen kohdistimen sijainti
            int tmpRow = CursorTop;
            int tmpCol = CursorLeft;

            SetCursorPosition(0, Id);

            WriteLine($"{Id} {Started.ToLongTimeString()} {Math.Round(Math.Round((1.0 * SpendTimeInSeconds / TotalTimeInSeconds), 2) * 100, 2)} %");

            //kohdistimen palautus
            SetCursorPosition(tmpCol, tmpRow);
        }

        public void PrintEnded()
        {
            int tmpRow = CursorTop;
            int tmpCol = CursorLeft;

            SetCursorPosition(0, Id);
            
            WriteLine($"{Id} {Started.ToLongTimeString()} - {Ended.ToLongTimeString()} = duration {(Ended - Started).Seconds} seconds");

            SetCursorPosition(tmpCol, tmpRow);
        }
    }
}
