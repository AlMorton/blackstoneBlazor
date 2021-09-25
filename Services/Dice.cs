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
        int RollDice();
    }

    public class Dice : IDice
    {
        private readonly int _sides;
        private readonly RandomNumberGenerator _randomNumberGenerator;
        public Dice(int sides)
        {
            _sides = sides;
            _randomNumberGenerator = RandomNumberGenerator.Create();
        }

        public int RollDice()
        {
            
            byte[] randomNumber = new byte[1];
            do
            {
                _randomNumberGenerator.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0]));

            return (byte)((randomNumber[0] % _sides) + 1);
        }
        private bool IsFairRoll(byte roll)
        {
            int fullSetsOfValues = Byte.MaxValue / _sides;

            return roll < _sides * fullSetsOfValues;
        }
    }
}
