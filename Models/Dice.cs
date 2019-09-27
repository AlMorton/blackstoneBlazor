using System;
using System.Security.Cryptography;

namespace BlazorApp.Models
{
    public class Dice : IRollRange
    {
        public int Sides { get; private set; }
        public int From { get; private set; }
        public int To => From;

        private readonly RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public Dice(int sides)
        {
            Sides = sides;
        }

        public void RollDice()
        {
            byte[] randomNumber = new byte[1];
            do
            {
                rngCsp.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0]));

            From = (byte)((randomNumber[0] % Sides) + 1);
        }

        private bool IsFairRoll(byte roll)
        {
            int fullSetsOfValues = Byte.MaxValue / Sides;
            
            return roll < Sides * fullSetsOfValues;
        }
    }
}
