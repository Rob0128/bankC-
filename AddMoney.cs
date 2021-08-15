using System;
using System.Collections.Generic;

namespace bank
{

    public class addMoneyToAccount
    {

        public static void addMoney(Account account, int amount)
        {
            if (Checkers.checkPositive(amount))
            {
                account.accountBalance += amount;
            }
            else
            {
                Console.WriteLine("Must be a positive amount");
            }
        }

    }

}