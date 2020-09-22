using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CodeSnippet.ConsoleApp
{
    public class ProjectEuler253
    {
        public class PieceSegment
        {
            public int PiecePlaced { get; set; }
            public int SegmentsSoFar { get; set; }
        }
        public class MaximumNumberPossibility
        {
            public int M { get; set; }
            public int Possibilities { get; set; }
        }
        public class AverageMaximumModel
        {
            public decimal AverageMaximum { get; set; }
            public decimal Numerator { get; set; }
            public decimal Denominator { get; set; }
        }
        public bool PrimeNumberTester(int primeNumber)
        {
            return true;
        }

        public List<int> OutputPrimeNumbersBetweenRange(int from, int to)
        {
            List<int> primeNumbersBetweenRange = new List<int>();

            return primeNumbersBetweenRange;
        }
        public int ModularMultiplicativeInverse(int integer, int Modulo)
        {
            int mmi = 0;
            return mmi;
        }
        public (int numerator, int denominator) ExpressFractionInSimplestForm(int numerator, int denominator)
        {
            return default;
        }
        public AverageMaximumModel AverageMaximum(MaximumNumberPossibility[] maximumNumberPossibilities)
        {
            decimal averageMax = 0; /*decimal numerator = 0; decimal denominator = 0; */int totalMaxPossibilities = 0;int totalPossibilities = 0;
            for(int i = 0; i < maximumNumberPossibilities.Count(); i++)
            {
                totalMaxPossibilities += maximumNumberPossibilities[i].M * maximumNumberPossibilities[i].Possibilities;
                totalPossibilities += maximumNumberPossibilities[i].Possibilities;
            }
            averageMax = totalMaxPossibilities / totalPossibilities;
            (int numerator, int denominator) = ExpressFractionInSimplestForm(totalMaxPossibilities, totalPossibilities);
            var resp = new AverageMaximumModel
            {
                AverageMaximum = averageMax,
                Numerator = numerator,
                Denominator = denominator
            };
            return resp;
        }
        public MaximumNumberPossibility[] Possibilities(int numberOfPieces, int trials)
        {
            int tableRowCount = Convert.ToInt32(Math.Ceiling((decimal)numberOfPieces/ 2));
            MaximumNumberPossibility[] resp = new MaximumNumberPossibility[tableRowCount];
            for (int i = 0; i < tableRowCount; i++)
            {
                resp[i] = new MaximumNumberPossibility();
                resp[i].M = i + 1;
            }
            for (int i = 0; i < trials; i++)
            {
                var m = MaximumNumber(PopulatePieceSegment(numberOfPieces));
                resp[m-1].Possibilities += 1; 
            }
            return resp;
        }
        public int MaximumNumber(List<PieceSegment> m)
        {
            int max = 0;
            foreach(var i in m)
            {
                if(i.SegmentsSoFar > max)
                {
                    max = i.SegmentsSoFar;
                }
            }
            return max;
        }
        public List<PieceSegment> PopulatePieceSegment(int numberOfPieces)
        {
            List<PieceSegment> pieceSegments = new List<PieceSegment>();//representing the table-1 in Project Euler 253
            int[] shuffledArray = ShuffleNumberCaterpillar(numberOfPieces);
            for(int i = 0; i < numberOfPieces; i++)
            {
                int segments = 1;
                if(pieceSegments.Count != 0)
                {
                    segments = pieceSegments[pieceSegments.Count - 1].SegmentsSoFar + 1;
                    foreach (var pp in pieceSegments)
                    {
                        if(Math.Abs(pp.PiecePlaced - shuffledArray[i]) == 1)
                        {
                            segments = segments - 1;
                        }
                    }
                }
                var row = new PieceSegment
                {
                    PiecePlaced = shuffledArray[i],
                    SegmentsSoFar = segments
                };
                pieceSegments.Add(row);
            }
            return pieceSegments;
        }
        public int[] ShuffleNumberCaterpillar(int numberOfPieces)
        {
            int[] piecesArray = new int[numberOfPieces];
            int[] shuffledArray = new int[numberOfPieces];
            for(int i = 0; i < numberOfPieces; i++)//say 0 - 39
            {
                piecesArray[i] = i + 1;//say 1 - 40
            }
            for (int i = 0; i < numberOfPieces; i++)//say 0 - 39 
            {
                Random random = new Random();
                int r = random.Next(0, numberOfPieces - i);
                //Console.WriteLine(piecesArray[r]);
                shuffledArray[i] = piecesArray[r];
                piecesArray = piecesArray.Where(p=> p != piecesArray[r]).ToArray();
                if(piecesArray.Length == 0)
                {
                    break;
                }
            }
            return shuffledArray;
        }
    }
}
//var x = new ProjectEuler253().PopulatePieceSegment(40);
//foreach(var y in x)
//{
//    Console.WriteLine($"{y.PiecePlaced}::{y.SegmentsSoFar}");
//}
//var a1 = new ProjectEuler253().Possibilities(40, 1_000_000);
//foreach(var x in a1)
//{
//    Console.WriteLine($"{x.M}::{x.Possibilities}");
//}