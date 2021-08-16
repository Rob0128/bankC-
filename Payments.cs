using System;
using System.Collections.Generic;

namespace bank
{
    public class pay
    {
        static public void paySomeOne(Account a1, Account a2, int amount)
        {
            //check payee is valid 
            if (a2.accountNo == null)
            {
                System.Console.WriteLine("Invalid payee account");
            }
            else
            {
                if (Checkers.checkPositive(amount))
                {
                    if (a1.accountBalance >= amount)
                    {
                        a1.withdraw(amount);
                        a2.deposit(amount);
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


}