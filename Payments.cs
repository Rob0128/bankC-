using System;
using System.Collections.Generic;

namespace bank
{
    public class pay
    {
        static public void paySomeOne(Account a1, Account a2, int amount)
        {
            if (Checkers.checkPositive(amount))
            {
                if (a1.accountBalance >= amount)
                {
                    a1.accountBalance -= amount;
                    a2.accountBalance += amount;
                }
                else
                {
                    Console.WriteLine("Insuficcient funds");
                }
            }
            else
            {
                Console.WriteLine("Needs to be a positive amount");
            }
        }
    }


}