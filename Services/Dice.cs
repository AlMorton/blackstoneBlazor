using BlazorApp.Models;
using System;
using System.Security.Cryptography;

namespace BlazorApp.Services
{
    public interface IDiceRollService
    {
        int GetRoll();
    }

    public class DiceRollService : IDiceRollService
    {
        private readonly IDice _dice;        

        public DiceRollService(IDice dice)
        {
            _dice = dice;            
        }

        public int GetRoll()
        {   
            return _dice.RollDice();
        }
    }

    public interface IDice
    {
        int Sides { get; }

        int RollDice();
    }

    public class Dice : IDice
    {
        public int Sides { get; private set; }

        private readonly RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public Dice(int sides)
        {
            Sides = sides;
        }

        public int RollDice()
        {
            byte[] randomNumber = new byte[1];
            do
            {
                rngCsp.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0]));

            return (byte)((randomNumber[0] % Sides) + 1);
        }

        private bool IsFairRoll(byte roll)
        {
            int fullSetsOfValues = Byte.MaxValue / Sides;

            return roll < Sides * fullSetsOfValues;
        }
    }
}
