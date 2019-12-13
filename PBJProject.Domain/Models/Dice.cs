using System;
using System.Collections.Generic;
using System.Linq;

namespace PBJProject.Domain.Models
{
   public class Dice
   {
      public int NumberOfSides { get; set; }
      public int NumberOfDice { get; set; }
      public List<int> Values { get; set; }
      public int Highest
      {
         get
         {
            if(Values == null)
            {
               return 0;
            }

            return Values.Max();
         }
      }
      public int Sum
      {
         get
         {
            int sum = 0;

            if(Values == null)
            {
               return 0;
            }

            foreach(var value in Values)
            {
               sum = sum + value;
            }

            return sum;
         }
      }

      public Dice(int numberOfDice, int numberOfSides)
      {
         if(Values == null)
         {
            Values = new List<int>();
         }

         this.NumberOfDice = numberOfDice;
         this.NumberOfSides = numberOfSides;
      }

      public void Roll()
      {
         Values.Clear();
         Random randomizer = new Random();
         int result;

         for(int number = 1; number <= this.NumberOfDice; number++)
         {
            result = randomizer.Next(1, this.NumberOfSides + 1);
            Values.Add(result);
         }
      }

      public void RemoveOneDieFromPool()
      {
         NumberOfDice = NumberOfDice - 1;
      }

      public void AddOneDieToPool()
      {
         NumberOfDice = NumberOfDice + 1;
      }
   }
}